using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    public partial class    SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            label1.Text = "Выберите тему поиска";
            comboBox1.SelectedIndex = 0;
        }
        public SearchForm(Size size, Point location, FormWindowState state)
        {
            InitializeComponent();
            label1.Text = "Выберите тему поиска";
            comboBox1.SelectedIndex = 0;

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
        private void Close_Click(object sender, EventArgs e)
        {
            Size sizeToPass = this.WindowState == FormWindowState.Normal ? this.Size : this.RestoreBounds.Size;
            Point locationToPass = this.WindowState == FormWindowState.Normal ? this.Location : this.RestoreBounds.Location;
            FormWindowState stateToPass = this.WindowState;

            MainForm f = new MainForm(sizeToPass, locationToPass, stateToPass);
            f.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "Введите место проведение";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label1.Text = "Введите доп услугу";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label1.Text = "Введите Категория";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                label1.Text = "Введите Сотрудника";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                label1.Text = "Введите Заказчика";
            }
            else
            {
                label1.Text = "Выберите тему поиска";
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-NDRNKPSE;Initial Catalog=Holiday;Integrated Security=True;";
            if (comboBox1.SelectedIndex == 0)
            {
                string NameLocation = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(NameLocation))
                {
                    ShowWarning("Введите название локации");
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("GetEventsByLocation", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@LocationName", NameLocation);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                // Проверяем результат
                                if (dt.Columns.Contains("Сообщение") && dt.Rows.Count > 0)
                                {
                                    ShowInfo(dt.Rows[0]["Сообщение"].ToString());
                                    dataGridView1.DataSource = null;
                                }
                                else
                                {
                                    dataGridView1.DataSource = dt;
                                    SetupColumnAlignment(dataGridView1);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Ошибка при выполнении поиска", ex.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                string AddService = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(AddService))
                {
                    ShowWarning("Введите название доп услуги");
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("GetEventsByAdditionalService", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ServiceName", AddService);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                // Проверяем результат
                                if (dt.Columns.Contains("Сообщение") && dt.Rows.Count > 0)
                                {
                                    ShowInfo(dt.Rows[0]["Сообщение"].ToString());

                                    dataGridView1.DataSource = null;
                                }
                                else
                                {
                                    dataGridView1.DataSource = dt;
                                    SetupColumnAlignment(dataGridView1);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Ошибка при выполнении поиска", ex.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                string categoryName = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(categoryName))
                {
                    ShowWarning("Введите название категории");
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("GetEventsByCategorySafe", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CategoryTitle", categoryName);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                // Проверяем результат
                                if (dt.Columns.Contains("Сообщение") && dt.Rows.Count > 0)
                                {
                                    ShowInfo(dt.Rows[0]["Сообщение"].ToString());

                                    dataGridView1.DataSource = null;
                                }
                                else
                                {
                                    dataGridView1.DataSource = dt;
                                    SetupColumnAlignment(dataGridView1);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Ошибка при выполнении поиска", ex.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                string SurnameStaff = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(SurnameStaff))
                {
                    ShowWarning("Введите фамилию сотрудника");
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("GetEventsByEmployeeSurname", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@EmployeeSurname", SurnameStaff);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                // Проверяем результат
                                if (dt.Columns.Contains("Сообщение") && dt.Rows.Count > 0)
                                {
                                    ShowInfo(dt.Rows[0]["Сообщение"].ToString());

                                    dataGridView1.DataSource = null;
                                }
                                else
                                {
                                    dataGridView1.DataSource = dt;
                                    SetupColumnAlignment(dataGridView1);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Ошибка при выполнении поиска", ex.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                string SurnameClient = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(SurnameClient))
                {
                    ShowWarning("Введите фамилию клиента");
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("GetEventsByCustomerSurname", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CustomerSurname", SurnameClient);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                // Проверяем результат
                                if (dt.Columns.Contains("Сообщение") && dt.Rows.Count > 0)
                                {
                                    ShowInfo(dt.Rows[0]["Сообщение"].ToString());

                                    dataGridView1.DataSource = null;
                                }
                                else
                                {
                                    dataGridView1.DataSource = dt;
                                    SetupColumnAlignment(dataGridView1);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Ошибка при выполнении поиска", ex.Message);
                }
            }
            else
            {
                ShowWarning("Выберите тему поиска");
            }
        }
        private void SetupColumnAlignment(DataGridView grid)
        {
            if (grid.Columns.Count == 0) return;

            foreach (DataGridViewColumn column in grid.Columns)
            {
                // Определяем тип данных столбца по имени
                string colName = column.Name.ToLower();

                // Числовые столбцы - вправо
                if (colName.Contains("стоимость") || colName.Contains("выручка") ||
                    colName.Contains("прибыль") || colName.Contains("сумма") ||
                    colName.Contains("price") || colName.Contains("cost"))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    if (column.ValueType == typeof(decimal) || column.ValueType == typeof(double))
                    {
                        column.DefaultCellStyle.Format = "N2";
                    }
                }
                // Даты - по центру
                else if (colName.Contains("дата") || colName.Contains("date"))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                // Телефоны - по центру
                else if (colName.Contains("телефон") || colName.Contains("phone"))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                // Текст - слева
                else
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                // Автоматическая ширина по содержимому
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void ShowError(string message, string details = null)
        {
            Form errorForm = new Form();
            errorForm.Text = "Ошибка";
            errorForm.StartPosition = FormStartPosition.CenterParent;
            errorForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            errorForm.MaximizeBox = false;
            errorForm.MinimizeBox = false;
            errorForm.Size = new Size(450, 160);
            errorForm.BackColor = Color.White;

            PictureBox iconBox = new PictureBox();
            iconBox.Image = SystemIcons.Error.ToBitmap();
            iconBox.Location = new Point(15, 20);
            iconBox.Size = new Size(32, 32);
            iconBox.SizeMode = PictureBoxSizeMode.StretchImage;

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblMessage.Location = new Point(60, 20);
            lblMessage.Size = new Size(360, 50);
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            Button btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Location = new Point(330, 85);
            btnClose.Size = new Size(100, 30);
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.ForeColor = Color.Black;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(220, 53, 69);
            btnClose.FlatAppearance.BorderSize = 1;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += (s, e) => errorForm.Close();

            Button btnDetails = null;
            Panel detailsPanel = null;
            RichTextBox rtbDetails = null;

            if (!string.IsNullOrEmpty(details))
            {
                btnDetails = new Button();
                btnDetails.Text = "Подробнее";
                btnDetails.Location = new Point(220, 85);
                btnDetails.Size = new Size(100, 30);
                btnDetails.BackColor = Color.WhiteSmoke;
                btnDetails.ForeColor = Color.Black;
                btnDetails.FlatAppearance.BorderColor = Color.Silver;
                btnDetails.FlatStyle = FlatStyle.Flat;
                btnDetails.Cursor = Cursors.Hand;

                detailsPanel = new Panel();
                detailsPanel.Location = new Point(15, 120);
                detailsPanel.Size = new Size(415, 200);
                detailsPanel.BackColor = Color.FromArgb(245, 245, 245);
                detailsPanel.BorderStyle = BorderStyle.FixedSingle;
                detailsPanel.Visible = false;

                rtbDetails = new RichTextBox();
                rtbDetails.Text = details;
                rtbDetails.Location = new Point(5, 5);
                rtbDetails.Size = new Size(403, 188);
                rtbDetails.Multiline = true;
                rtbDetails.ScrollBars = RichTextBoxScrollBars.Vertical;
                rtbDetails.ReadOnly = true;
                rtbDetails.BackColor = Color.FromArgb(245, 245, 245);
                rtbDetails.BorderStyle = BorderStyle.None;
                rtbDetails.Font = new Font("Segoe UI", 9);

                detailsPanel.Controls.Add(rtbDetails);

                bool detailsVisible = false;
                btnDetails.Click += (s, ev) =>
                {
                    detailsVisible = !detailsVisible;
                    detailsPanel.Visible = detailsVisible;

                    if (detailsVisible)
                    {
                        errorForm.Height = 380;
                        btnDetails.Text = "Скрыть";
                    }
                    else
                    {
                        errorForm.Height = 160;
                        btnDetails.Text = "Подробнее";
                    }
                };
            }

            errorForm.Controls.Add(iconBox);
            errorForm.Controls.Add(lblMessage);
            if (btnDetails != null) errorForm.Controls.Add(btnDetails);
            errorForm.Controls.Add(btnClose);
            if (detailsPanel != null) errorForm.Controls.Add(detailsPanel);

            errorForm.ShowDialog();
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
    }
}
