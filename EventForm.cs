using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    public partial class EventForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-NDRNKPSE;Initial Catalog=Holiday;Integrated Security=True;";
        private Size currentSize;
        private Point currentLocation;
        private FormWindowState currentState;

        private string currentFilterStatus = "Все";
        private DataTable currentDataTable;

        public EventForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // Настройка элементов поиска
            comboBoxSearchType.SelectedIndex = 0;
            if (comboBoxStatus != null)
                comboBoxStatus.SelectedIndex = 0;
            dtpFilterDate.MinDate = DateTime.Now.Date;
            dtpFilterDate.Value = DateTime.Now.Date;
            dtpFilterDate.ShowCheckBox = true;
            dtpFilterDate.Checked = false;

            // Подписка на события
            btnSearch.Click += BtnSearch_Click;
            btnResetFilters.Click += BtnResetFilters_Click;
            dtpFilterDate.CloseUp += DtpFilterDate_CloseUp;
            if (comboBoxStatus != null)
                comboBoxStatus.SelectedIndexChanged += ComboBoxStatus_SelectedIndexChanged;
        }

        public EventForm(Size size, Point location, FormWindowState state)
        {
            InitializeComponent();

            comboBoxSearchType.SelectedIndex = 0;
            if (comboBoxStatus != null)
                comboBoxStatus.SelectedIndex = 0;
            dtpFilterDate.MinDate = DateTime.Now.Date;
            dtpFilterDate.Value = DateTime.Now.Date;
            dtpFilterDate.ShowCheckBox = true;
            dtpFilterDate.Checked = false;

            btnSearch.Click += BtnSearch_Click;
            btnResetFilters.Click += BtnResetFilters_Click;
            dtpFilterDate.CloseUp += DtpFilterDate_CloseUp;
            if (comboBoxStatus != null)
                comboBoxStatus.SelectedIndexChanged += ComboBoxStatus_SelectedIndexChanged;

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

        private void close_Click(object sender, EventArgs e)
        {
            Size sizeToPass = this.WindowState == FormWindowState.Normal ? this.Size : this.RestoreBounds.Size;
            Point locationToPass = this.WindowState == FormWindowState.Normal ? this.Location : this.RestoreBounds.Location;
            FormWindowState stateToPass = this.WindowState;

            MainForm f = new MainForm(sizeToPass, locationToPass, stateToPass);
            f.Show();
            this.Close();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            LoadEvents();
            SetupColumnAlignment();
        }

        // Загрузка всех мероприятий через TableAdapter
        public void LoadEvents()
        {
            try
            {
                this.полнаяИнформацияОМероприятияхTableAdapter3.Fill(this.holidayDataSet23.ПолнаяИнформацияОМероприятиях);

                // Сохраняем данные в DataTable для фильтрации
                currentDataTable = this.holidayDataSet23.ПолнаяИнформацияОМероприятиях.CopyToDataTable();
                dataGridViewEvents.DataSource = currentDataTable;

                lblSearchStatus.Text = "Показаны все мероприятия";
                this.Refresh();
            }
            catch (Exception ex)
            {
                ShowWarning($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void ApplyStatusFilter()
        {
            if (currentDataTable == null) return;

            DataView dv = currentDataTable.DefaultView;
            string filter = "";

            switch (comboBoxStatus.SelectedIndex)
            {
                case 1: // Выполнено
                    filter = "[Статус] = 'Выполнено'";
                    break;
                case 2: // Сегодня
                    filter = "[Статус] = 'Сегодня'";
                    break;
                case 3: // Предстоящее
                    filter = "[Статус] = 'Предстоящее'";
                    break;
                default:
                    filter = "";
                    break;
            }

            dv.RowFilter = filter;
            dataGridViewEvents.DataSource = dv;

            int count = dv.Count;
            lblSearchStatus.Text = $"Показаны мероприятия со статусом: {comboBoxStatus.SelectedItem} (найдено: {count})";
        }

        private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStatus.SelectedIndex == 0)
            {
                // "Все" - показываем исходные данные
                dataGridViewEvents.DataSource = currentDataTable;
                lblSearchStatus.Text = "Показаны все мероприятия";
            }
            else
            {
                ApplyStatusFilter();
            }
        }


        private void SetupColumnAlignment()
        {
            if (dataGridViewEvents.Columns == null || dataGridViewEvents.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in dataGridViewEvents.Columns)
            {
                string colName = col.Name.ToLower();
                if (colName.Contains("стоимость") || colName.Contains("выручка") || colName.Contains("прибыль"))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.DefaultCellStyle.Format = "N2";
                }
                else if (colName.Contains("дата"))
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                else if (colName.Contains("телефон"))
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        // ==================== ПОИСК ====================

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            int searchType = comboBoxSearchType.SelectedIndex;

            if (string.IsNullOrEmpty(searchText))
            {
                LoadEvents();
                return;
            }

            try
            {
                DataTable result = null;
                string procName = "";
                string paramName = "";

                switch (searchType)
                {
                    case 0: // Заказчик
                        procName = "GetEventsByCustomerSurname";
                        paramName = "@CustomerSurname";
                        break;
                    case 1: // Категория
                        procName = "GetEventsByCategorySafe";
                        paramName = "@CategoryTitle";
                        break;
                    case 2: // Место проведения
                        procName = "GetEventsByLocation";
                        paramName = "@LocationName";
                        break;
                    case 3: // Дополнительная услуга
                        procName = "GetEventsByAdditionalService";
                        paramName = "@ServiceName";
                        break;
                    case 4: // Сотрудник
                        procName = "GetEventsByEmployeeSurname";
                        paramName = "@EmployeeSurname";
                        break;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(paramName, searchText);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        result = new DataTable();
                        adapter.Fill(result);
                    }
                }

                // Проверка на сообщение об ошибке от процедуры
                if (result != null && result.Columns.Contains("Сообщение") && result.Rows.Count > 0)
                {
                    ShowInfo(result.Rows[0]["Сообщение"].ToString());
                    LoadEvents();
                    return;
                }

                if (result != null && result.Rows.Count > 0)
                {
                    dataGridViewEvents.DataSource = result;
                    SetupColumnAlignment();
                    lblSearchStatus.Text = $"Найдено мероприятий: {result.Rows.Count}";
                }
                else
                {
                    ShowInfo("Ничего не найдено");
                    LoadEvents();
                }
            }
            catch (Exception ex)
            {
                ShowWarning($"Ошибка поиска: {ex.Message}");
                LoadEvents();
            }
        }

        // ==================== ФИЛЬТРАЦИЯ ПО ДАТЕ ====================

        private async void DtpFilterDate_CloseUp(object sender, EventArgs e)
        {
            if (!dtpFilterDate.Checked) return;

            DateTime selectedDate = dtpFilterDate.Value.Date;

            if (selectedDate < DateTime.Now.Date)
            {
                ShowWarning("Нельзя выбрать прошедшую дату!");
                dtpFilterDate.Value = DateTime.Now.Date;
                dtpFilterDate.Checked = false;
                LoadEvents();
                return;
            }

            await FilterByDate(selectedDate);
        }

        private async Task FilterByDate(DateTime date)
        {
            try
            {
                string query = "SELECT * FROM ПолнаяИнформацияОМероприятиях WHERE [Дата проведения] = @date";
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
                            dataGridViewEvents.DataSource = dt;
                            SetupColumnAlignment();
                            lblSearchStatus.Text = $"Мероприятия на {date:dd.MM.yyyy}";
                        }
                        else
                        {
                            ShowInfo($"На {date:dd.MM.yyyy} мероприятий не найдено");
                            dtpFilterDate.Checked = false;
                            LoadEvents();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowWarning($"Ошибка фильтрации: {ex.Message}");
                LoadEvents();
            }
        }

        // ==================== СБРОС ФИЛЬТРОВ ====================

        private void BtnResetFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            comboBoxSearchType.SelectedIndex = 0;
            dtpFilterDate.Checked = false;
            dtpFilterDate.Value = DateTime.Now.Date;
            LoadEvents();
        }

        // ==================== ОСНОВНЫЕ ДЕЙСТВИЯ ====================

        private void Insert_Click(object sender, EventArgs e)
        {
            AddEventForm f = new AddEventForm();
            f.ShowDialog();
            LoadEvents();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEvents.CurrentRow == null)
                {
                    ShowWarning("Выберите мероприятие из таблицы!");
                    return;
                }

                DataGridViewRow selectedRow = dataGridViewEvents.CurrentRow;
                string номерМероприятия = selectedRow.Cells["номерМероприятияDataGridViewTextBoxColumn"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(номерМероприятия))
                {
                    UpdateEventForm f = new UpdateEventForm(int.Parse(номерМероприятия));
                    f.ShowDialog();
                    LoadEvents();
                }
            }
            catch (Exception ex)
            {
                ShowWarning($"Ошибка: {ex.Message}");
            }
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            LoadEvents();
        }

        // ==================== ДИАЛОГОВЫЕ ОКНА ====================

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
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Cursor = Cursors.Hand;
            btnOK.Click += (s, e) => warningForm.Close();

            warningForm.Controls.Add(iconBox);
            warningForm.Controls.Add(lblMessage);
            warningForm.Controls.Add(btnOK);

            warningForm.ShowDialog();
        }
    }
}