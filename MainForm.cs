using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using Курсовая_Жирнова_Е.А._Holiday.Models;
using static System.Windows.Forms.AxHost;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    public partial class MainForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-NDRNKPSE;Initial Catalog=Holiday;Integrated Security=True;";

        private Size currentSize;
        private Point currentLocation;
        private FormWindowState currentState;

        private BindingSource originalBindingSource;
        private bool isDatePickerClosed = false;

        public MainForm()
        {
            InitializeComponent();
            UpdateDateTime();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 60000;
            timer.Tick += Timer_Tick;
            timer.Start();
            originalBindingSource = this.предстоящиеМероприятияBindingSource3;

            comboBox1.SelectedIndex = 0;
            DatePicker.MinDate = DateTime.Now.Date;
            DatePicker.Value = DateTime.Now.Date;
            DatePicker.ShowCheckBox = true;
            DatePicker.Checked = false;

            buttonSearch.Click += buttonSearch_Click;
            buttonFilters.Click += buttonFilters_Click;
            DatePicker.CloseUp += DatePicker_CloseUp;


            this.WindowState = FormWindowState.Maximized;
        }
        public MainForm(Size size, Point location, FormWindowState state)
        {
            InitializeComponent();
            UpdateDateTime();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 60000;
            timer.Tick += Timer_Tick;
            timer.Start();

            originalBindingSource = this.предстоящиеМероприятияBindingSource3;

            comboBox1.SelectedIndex = 0;
            DatePicker.MinDate = DateTime.Now.Date;
            DatePicker.Value = DateTime.Now.Date;
            DatePicker.ShowCheckBox = true;
            DatePicker.Checked = false;

            buttonSearch.Click += buttonSearch_Click;
            buttonFilters.Click += buttonFilters_Click;
            DatePicker.CloseUp += DatePicker_CloseUp;

            if (state == FormWindowState.Normal)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = location;
                this.Size = size;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.Size = size;
                this.Location = location;
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                currentSize = this.Size;
                currentLocation = this.Location;
            }
            else
            {
                currentSize = this.RestoreBounds.Size;
                currentLocation = this.RestoreBounds.Location;
            }
            currentState = this.WindowState;
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                currentLocation = this.Location;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            label9.Text = DateTime.Now.ToString("dd/MM/yy HH:mm");
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        async private void MainForm_Load(object sender, EventArgs e)
        {
            await LoadStatistics();
            await LoadUpcomingEvents();
            SetupColumnAlignment();
        }

        private async Task LoadStatistics()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string sqlQuery = "SELECT COUNT(*) FROM Event";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    int count = (int)await command.ExecuteScalarAsync();
                    label2.Text = count.ToString();

                    sqlQuery = "SELECT ISNULL(SUM(Price), 0) FROM Event WHERE Data_Event < CAST(GETDATE() AS DATE)";
                    command = new SqlCommand(sqlQuery, connection);
                    decimal actualRevenue = (decimal)await command.ExecuteScalarAsync();
                    label3.Text = actualRevenue.ToString("N0");

                    sqlQuery = "SELECT COUNT(*) FROM Event WHERE Data_Event > CAST(GETDATE() AS DATE)";
                    command = new SqlCommand(sqlQuery, connection);
                    int futureEvents = (int)await command.ExecuteScalarAsync();
                    label5.Text = futureEvents.ToString();

                    sqlQuery = "SELECT COUNT(*) FROM Customer";
                    command = new SqlCommand(sqlQuery, connection);
                    int customers = (int)await command.ExecuteScalarAsync();
                    label7.Text = customers.ToString();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    label2.Text = "Ошибка";
                    label3.Text = "Ошибка";
                    label5.Text = "Ошибка";
                    label7.Text = "Ошибка";
                }
            }
        }

        private async Task LoadUpcomingEvents()
        {
            try
            {
                this.предстоящиеМероприятияTableAdapter3.Fill(this.holidayDataSet3.ПредстоящиеМероприятия);
                
                dataGridView1.DataSource = originalBindingSource;
                SetupColumnAlignment();
                this.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetupColumnAlignment()
        {
            string[] numericColumns = {
                "стоимостьАрендыDataGridViewTextBoxColumn",
                "стоимостьУслугиDataGridViewTextBoxColumn",
                "общаяСтоимостьDataGridViewTextBoxColumn",
                "прибыльDataGridViewTextBoxColumn",
                "длительностьчасовDataGridViewTextBoxColumn",
                "количествоУчастниковDataGridViewTextBoxColumn"
            };

            foreach (string colName in numericColumns)
            {
                if (dataGridView1.Columns[colName] != null)
                {
                    dataGridView1.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[colName].DefaultCellStyle.Format = "N2";
                }
            }

            string[] dateColumns = {
                "датаЗаказаDataGridViewTextBoxColumn",
                "датаПроведенияDataGridViewTextBoxColumn"
            };

            foreach (string colName in dateColumns)
            {
                if (dataGridView1.Columns[colName] != null)
                {
                    dataGridView1.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            string[] phoneColumns = {
                "телефонЗаказчикаDataGridViewTextBoxColumn",
                "телефонСотрудникаDataGridViewTextBoxColumn"
            };

            foreach (string colName in phoneColumns)
            {
                if (dataGridView1.Columns[colName] != null)
                {
                    dataGridView1.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            string[] textColumns = {
                "фИОЗаказчикаDataGridViewTextBoxColumn",
                "адресDataGridViewTextBoxColumn",
                "местоПроведенияDataGridViewTextBoxColumn",
                "дополнительнаяУслугаDataGridViewTextBoxColumn",
                "ответственныйСотрудникDataGridViewTextBoxColumn",
                "категорияDataGridViewTextBoxColumn"
            };

            foreach (string colName in textColumns)
            {
                if (dataGridView1.Columns[colName] != null)
                {
                    dataGridView1.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                await LoadUpcomingEvents();
                return;
            }

            int selectedIndex = comboBox1.SelectedIndex;

            try
            {
                DataTable result = null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    switch (selectedIndex)
                    {
                        case 0:
                            result = await ExecuteProcedure("GetEventsByLocation", "@LocationName", searchText, conn);
                            break;
                        case 1:
                            result = await ExecuteProcedure("GetEventsByAdditionalService", "@ServiceName", searchText, conn);
                            break;
                        case 2:
                            result = await ExecuteProcedure("GetEventsByCategorySafe", "@CategoryTitle", searchText, conn);
                            break;
                        case 3:
                            result = await ExecuteProcedure("GetEventsByEmployeeSurname", "@EmployeeSurname", searchText, conn);
                            break;
                        case 4:
                            result = await ExecuteProcedure("GetEventsByCustomerSurname", "@CustomerSurname", searchText, conn);
                            break;
                        default:
                            return;
                    }
                }

               
                if (result != null && result.Columns.Contains("Сообщение") && result.Rows.Count > 0)
                {
                    ShowInfo(result.Rows[0]["Сообщение"].ToString());
                    
                    await LoadUpcomingEvents();
                    return;
                }

                if (result != null && result.Rows.Count > 0)
                {
                    dataGridView1.DataSource = result;
                    SetupColumnAlignment();
                }
                else
                {
                    
                    ShowInfo("Ничего не найдено");
                    await LoadUpcomingEvents();
                }
            }
            catch (Exception ex)
            {
                ShowWarning($"Ошибка при выполнении поиска: {ex.Message}");
                await LoadUpcomingEvents();
            }
        }

        private async Task<DataTable> ExecuteProcedure(string procName, string paramName, string paramValue, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(paramName, paramValue);

                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    await Task.Run(() => adapter.Fill(dt));
                }
                return dt;
            }
        }

        private async void DatePicker_CloseUp(object sender, EventArgs e)
        {
            if (!DatePicker.Checked) return;

            DateTime selectedDate = DatePicker.Value.Date;

            if (selectedDate < DateTime.Now.Date)
            {
                ShowWarning("Нельзя выбрать прошедшую дату!");
                DatePicker.Value = DateTime.Now.Date;
                DatePicker.Checked = false;
                await LoadUpcomingEvents();
                return;
            }

            await FilterByDate(selectedDate);
        }

        private async Task FilterByDate(DateTime date)
        {
            try
            {
                string query = "SELECT * FROM ПредстоящиеМероприятия WHERE [Дата проведения] = @date";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                            SetupColumnAlignment();
                        }
                        else
                        {
                            
                            ShowInfo($"На {date:dd.MM.yyyy} мероприятий не найдено.");
                            DatePicker.Checked = false;
                            await LoadUpcomingEvents();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowWarning($"Ошибка фильтрации по дате: {ex.Message}");
                await LoadUpcomingEvents();
            }
        }

        private async void buttonFilters_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
            DatePicker.Checked = false;
            DatePicker.Value = DateTime.Now.Date;
            await LoadUpcomingEvents();
        }

        private void ShowInfo(string message)
        {
            Form infoForm = new Form();
            infoForm.Text = "Информация";
            infoForm.StartPosition = FormStartPosition.CenterParent;
            infoForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            infoForm.MaximizeBox = false;
            infoForm.MinimizeBox = false;
            infoForm.Size = new Size(400, 150);
            infoForm.BackColor = Color.White;

            PictureBox iconBox = new PictureBox();
            iconBox.Image = SystemIcons.Information.ToBitmap();
            iconBox.Location = new Point(15, 20);
            iconBox.Size = new Size(32, 32);
            iconBox.SizeMode = PictureBoxSizeMode.StretchImage;

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblMessage.Location = new Point(60, 20);
            lblMessage.Size = new Size(310, 50);
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Location = new Point(285, 75);
            btnOK.Size = new Size(85, 30);
            btnOK.BackColor = Color.WhiteSmoke;
            btnOK.ForeColor = Color.Black;
            btnOK.FlatAppearance.BorderColor = Color.Silver;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnOK.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Cursor = Cursors.Hand;
            btnOK.Click += (s, e) => infoForm.Close();

            infoForm.Controls.Add(iconBox);
            infoForm.Controls.Add(lblMessage);
            infoForm.Controls.Add(btnOK);

            infoForm.ShowDialog();
        }

        private void ShowWarning(string message)
        {
            Form warningForm = new Form();
            warningForm.Text = "Предупреждение";
            warningForm.StartPosition = FormStartPosition.CenterParent;
            warningForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            warningForm.MaximizeBox = false;
            warningForm.MinimizeBox = false;
            warningForm.Size = new Size(400, 150);
            warningForm.BackColor = Color.White;

            PictureBox iconBox = new PictureBox();
            iconBox.Image = SystemIcons.Warning.ToBitmap();
            iconBox.Location = new Point(15, 20);
            iconBox.Size = new Size(32, 32);
            iconBox.SizeMode = PictureBoxSizeMode.StretchImage;

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblMessage.Location = new Point(60, 20);
            lblMessage.Size = new Size(310, 50);
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Location = new Point(285, 75);
            btnOK.Size = new Size(85, 30);
            btnOK.BackColor = Color.WhiteSmoke;
            btnOK.ForeColor = Color.Black;
            btnOK.FlatAppearance.BorderColor = Color.Silver;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnOK.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Cursor = Cursors.Hand;
            btnOK.Click += (s, e) => warningForm.Close();

            warningForm.Controls.Add(iconBox);
            warningForm.Controls.Add(lblMessage);
            warningForm.Controls.Add(btnOK);

            warningForm.ShowDialog();
        }

        private void Event_Click(object sender, EventArgs e)
        {
            Size sizeToPass = this.WindowState == FormWindowState.Normal ? this.Size : this.RestoreBounds.Size;
            Point locationToPass = this.WindowState == FormWindowState.Normal ? this.Location : this.RestoreBounds.Location;
            FormWindowState stateToPass = this.WindowState;

            EventForm f = new EventForm(sizeToPass, locationToPass, stateToPass);
            f.Show();
            this.Close();
        }

        private void Documents_Click(object sender, EventArgs e)
        {
            Size sizeToPass = this.WindowState == FormWindowState.Normal ? this.Size : this.RestoreBounds.Size;
            Point locationToPass = this.WindowState == FormWindowState.Normal ? this.Location : this.RestoreBounds.Location;
            FormWindowState stateToPass = this.WindowState;

            DocumentsForm f = new DocumentsForm(sizeToPass, locationToPass, stateToPass);
            f.Show();
            this.Close();
        }

        private void Client_Click(object sender, EventArgs e)
        {
            Size sizeToPass = this.WindowState == FormWindowState.Normal ? this.Size : this.RestoreBounds.Size;
            Point locationToPass = this.WindowState == FormWindowState.Normal ? this.Location : this.RestoreBounds.Location;
            FormWindowState stateToPass = this.WindowState;

            ClientForm f = new ClientForm(sizeToPass, locationToPass, stateToPass);
            f.Show();
            this.Close();
        }

        private void Staff_Click(object sender, EventArgs e)
        {
            Size sizeToPass = this.WindowState == FormWindowState.Normal ? this.Size : this.RestoreBounds.Size;
            Point locationToPass = this.WindowState == FormWindowState.Normal ? this.Location : this.RestoreBounds.Location;
            FormWindowState stateToPass = this.WindowState;

            StaffForm f = new StaffForm(sizeToPass, locationToPass, stateToPass);
            f.Show();
            this.Close();
        }

        private void Analysis_Click(object sender, EventArgs e)
        {
            Size sizeToPass = this.WindowState == FormWindowState.Normal ? this.Size : this.RestoreBounds.Size;
            Point locationToPass = this.WindowState == FormWindowState.Normal ? this.Location : this.RestoreBounds.Location;
            FormWindowState stateToPass = this.WindowState;

            AnalisysForm f = new AnalisysForm(sizeToPass, locationToPass, stateToPass); 
            f.Show();
            this.Close();
        }

    }
}