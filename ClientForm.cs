using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    public partial class ClientForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-NDRNKPSE;Initial Catalog=Holiday;Integrated Security=True;";

        public ClientForm()
        {
            InitializeComponent();
            dataGridView1.DataError += dataGridView_DataError;
            this.WindowState = FormWindowState.Maximized;
        }

        public ClientForm(Size size, Point location, FormWindowState state)
        {
            InitializeComponent();
            dataGridView1.DataError += dataGridView_DataError;

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

        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                this.customerTableAdapter.Fill(this.holidayDataSet12.Customer);
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка загрузки", "Не удалось загрузить данные",
                    $"Ошибка: {ex.Message}\n\nВозможные причины:\n• Отсутствует подключение к базе данных\n• Ошибка в структуре данных");
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

        private void Restart_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            holidayDataSet12.Customer.DefaultView.RowFilter = "";
            LoadData();
        }

        private string GetCellValue(DataGridView grid, int columnIndex)
        {
            if (grid.CurrentRow == null) return "";
            if (grid.CurrentRow.Cells[columnIndex].Value == null) return "";
            if (grid.CurrentRow.Cells[columnIndex].Value == DBNull.Value) return "";
            return grid.CurrentRow.Cells[columnIndex].Value.ToString();
        }
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            if (phone.Length != 11) return false;

            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            string columnName = grid.Columns[e.ColumnIndex].HeaderText;
            string enteredValue = "";

            try
            {
                if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    enteredValue = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
            catch { }

            string errorMessage = "";
            string errorDetails = "";

            if (e.Exception is FormatException)
            {
                if (columnName.Contains("Телефон") || columnName.Contains("Phone"))
                {
                    errorMessage = "Некорректный формат телефона";
                    errorDetails = $"Вы ввели: \"{enteredValue}\"\n\n" +
                                  "Телефон должен содержать 11 цифр.\n\n" +
                                  "Примеры правильного ввода:\n" +
                                  "- 89161234567\n" +
                                  "- 89678765746\n\n" +
                                  "Проверьте, что вы не ввели буквы, пробелы или другие символы.";
                }
                else
                {
                    errorMessage = "Некорректный формат данных";
                    errorDetails = $"Вы ввели: \"{enteredValue}\"\n\n" +
                                  "Пожалуйста, введите данные в правильном формате.";
                }
            }
            else
            {
                errorMessage = "Ошибка ввода данных";
                errorDetails = $"Ошибка: {e.Exception.Message}\n\n" +
                              "Пожалуйста, проверьте правильность введенных данных.";
            }

            ShowErrorWithDetails("Ошибка ввода", errorMessage, errorDetails);
            e.ThrowException = false;
        }

     
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    ShowErrorWithDetails("Ошибка добавления", "Не выбрана строка",
                        "Выберите строку в таблице, введите данные и нажмите кнопку 'Добавить'.");
                    return;
                }

                string surname = GetCellValue(dataGridView1, 1);      
                string firstName = GetCellValue(dataGridView1, 2);    
                string lastName = GetCellValue(dataGridView1, 3);     
                string phone = GetCellValue(dataGridView1, 4);        

                if (string.IsNullOrWhiteSpace(surname))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Фамилия не введена",
                        "Пожалуйста, введите фамилию клиента.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(firstName))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Имя не введено",
                        "Пожалуйста, введите имя клиента.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(phone))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Телефон не введен",
                        "Пожалуйста, введите номер телефона.\n\nТелефон должен содержать 11 цифр.");
                    return;
                }

                if (!IsValidPhone(phone))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Некорректный формат телефона",
                        $"Вы ввели: \"{phone}\"\n\n" +
                        "Телефон должен содержать 11 цифр.\n\n" +
                        "Примеры правильного ввода:\n" +
                        "• 89161234567\n" +
                        "• 89678765746\n\n" +
                        "Проверьте, что вы не ввели буквы, пробелы или другие символы.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("AddCustomer", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Surname", surname);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", string.IsNullOrWhiteSpace(lastName) ? (object)DBNull.Value : lastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phone);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string result = reader["Сообщение"].ToString();
                                if (result.Contains("Ошибка"))
                                {
                                    if (result.Contains("телефоном уже существует"))
                                    {
                                        ShowErrorWithDetails("Ошибка добавления клиента", result,
                                            $"Клиент с номером телефона \"{phone}\" уже существует в системе.\n\n" +
                                            "Пожалуйста, проверьте правильность введенного номера.\n" +
                                            "Если клиент уже есть, не нужно добавлять его повторно.");
                                    }
                                    else
                                    {
                                        ShowErrorWithDetails("Ошибка добавления клиента", result,
                                            "Проверьте правильность введенных данных.\n\n" +
                                            "Возможные причины:\n" +
                                            "- Фамилия или имя не заполнены\n" +
                                            "- Телефон указан в неверном формате\n" +
                                            "- Клиент с таким телефоном уже существует");
                                    }
                                }
                                else
                                {
                                    ShowInfo(result);
                                    LoadData();
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ShowErrorWithDetails("Ошибка базы данных", "Не удалось добавить клиента",
                    $"Код ошибки: {sqlEx.Number}\nСообщение: {sqlEx.Message}\n\n" +
                    "Проверьте подключение к базе данных и повторите попытку.");
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка", "Произошла ошибка при добавлении",
                    $"Ошибка: {ex.Message}\n\nПопробуйте еще раз.");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Не выбран клиент",
                        "Выберите строку с клиентом, которого хотите отредактировать.");
                    return;
                }

                int customerId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string surname = GetCellValue(dataGridView1, 1);
                string firstName = GetCellValue(dataGridView1, 2);
                string lastName = GetCellValue(dataGridView1, 3);
                string phone = GetCellValue(dataGridView1, 4);

                if (string.IsNullOrWhiteSpace(surname))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Фамилия не может быть пустой",
                        "Пожалуйста, введите фамилию клиента.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(firstName))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Имя не может быть пустым",
                        "Пожалуйста, введите имя клиента.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(phone))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Телефон не введен",
                        "Пожалуйста, введите номер телефона.\n\nТелефон должен содержать 11 цифр.");
                    return;
                }

                if (!IsValidPhone(phone))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Некорректный формат телефона",
                        $"Вы ввели: \"{phone}\"\n\n" +
                        "Телефон должен содержать 11 цифр.\n\n" +
                        "Примеры правильного ввода:\n" +
                        "- 89161234567\n" +
                        "- 89678765746\n\n" +
                        "Проверьте, что вы не ввели буквы, пробелы или другие символы.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateCustomer", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Customer", customerId);
                        cmd.Parameters.AddWithValue("@Surname", surname);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", string.IsNullOrWhiteSpace(lastName) ? (object)DBNull.Value : lastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phone);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string result = reader["Сообщение"].ToString();
                                if (result.Contains("Ошибка"))
                                {
                                    if (result.Contains("телефоном уже существует"))
                                    {
                                        ShowErrorWithDetails("Ошибка редактирования клиента", result,
                                            $"Клиент с номером телефона \"{phone}\" уже существует в системе.\n\n" +
                                            "Пожалуйста, проверьте правильность введенного номера.");
                                    }
                                    else
                                    {
                                        ShowErrorWithDetails("Ошибка редактирования клиента", result,
                                            "Проверьте правильность введенных данных.\n\n" +
                                            "Возможные причины:\n" +
                                            "• Фамилия или имя не заполнены\n" +
                                            "• Телефон указан в неверном формате");
                                    }
                                }
                                else
                                {
                                    ShowInfo(result);
                                    LoadData();
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ShowErrorWithDetails("Ошибка базы данных", "Не удалось обновить данные клиента",
                    $"Код ошибки: {sqlEx.Number}\nСообщение: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка", "Произошла ошибка при редактировании",
                    $"Ошибка: {ex.Message}");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                ShowWarning("Введите ФИО или номер телефона для поиска");
                return;
            }

            try
            {
                DataView dv = holidayDataSet12.Customer.DefaultView;
                string safeSearchText = searchText.Replace("'", "''");
                dv.RowFilter = $"Surname LIKE '%{safeSearchText}%' OR " +
                               $"First_Name LIKE '%{safeSearchText}%' OR " +
                               $"Last_Name LIKE '%{safeSearchText}%' OR " +
                               $"Phone_Number LIKE '%{safeSearchText}%'";

                dataGridView1.DataSource = dv;

                // Проверяем реальное количество строк в источнике данных
                int actualRowCount = dv.Count;

                if (actualRowCount == 0)
                {
                    ShowInfo("Клиенты не найдены");
                    // Возвращаем все данные
                    dv.RowFilter = "";
                    dataGridView1.DataSource = dv;
                }
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка при поиске", "Не удалось выполнить поиск", ex.Message);
            }
        }

        private void ShowInfo(string message)
        {
            Form infoForm = new Form();
            infoForm.Text = "Информация";
            infoForm.StartPosition = FormStartPosition.CenterParent;
            infoForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            infoForm.MaximizeBox = false;
            infoForm.MinimizeBox = false;
            infoForm.Size = new Size(400, 160);
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
            btnOK.Location = new Point(285, 85);
            btnOK.Size = new Size(85, 30);
            btnOK.BackColor = Color.WhiteSmoke;
            btnOK.ForeColor = Color.Black;
            btnOK.FlatAppearance.BorderColor = Color.Silver;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnOK.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Cursor = Cursors.Hand;
            btnOK.Click += (s, ev) => infoForm.Close();

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
            warningForm.Size = new Size(400, 160);
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
            btnOK.Location = new Point(285, 85);
            btnOK.Size = new Size(85, 30);
            btnOK.BackColor = Color.WhiteSmoke;
            btnOK.ForeColor = Color.Black;
            btnOK.FlatAppearance.BorderColor = Color.Silver;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnOK.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Cursor = Cursors.Hand;
            btnOK.Click += (s, ev) => warningForm.Close();

            warningForm.Controls.Add(iconBox);
            warningForm.Controls.Add(lblMessage);
            warningForm.Controls.Add(btnOK);

            warningForm.ShowDialog();
        }

        private void ShowErrorWithDetails(string title, string shortMessage, string details)
        {
            Form errorForm = new Form();
            errorForm.Text = title;
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
            lblMessage.Text = shortMessage;
            lblMessage.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblMessage.Location = new Point(60, 20);
            lblMessage.Size = new Size(360, 50);
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            Button btnDetails = new Button();
            btnDetails.Text = "Подробнее";
            btnDetails.Location = new Point(220, 85);
            btnDetails.Size = new Size(100, 30);
            btnDetails.BackColor = Color.WhiteSmoke;
            btnDetails.ForeColor = Color.Black;
            btnDetails.FlatAppearance.BorderColor = Color.Silver;
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.Cursor = Cursors.Hand;

            Button btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Location = new Point(330, 85);
            btnClose.Size = new Size(100, 30);
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.ForeColor = Color.Black;
            btnClose.FlatAppearance.BorderColor = Color.Silver;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;

            Panel detailsPanel = new Panel();
            detailsPanel.Location = new Point(15, 120);
            detailsPanel.Size = new Size(415, 200);
            detailsPanel.BackColor = Color.FromArgb(245, 245, 245);
            detailsPanel.BorderStyle = BorderStyle.FixedSingle;
            detailsPanel.Visible = false;

            RichTextBox rtbDetails = new RichTextBox();
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
            btnDetails.Click += (sender, e) =>
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

            btnClose.Click += (sender, e) => errorForm.Close();

            errorForm.Controls.Add(iconBox);
            errorForm.Controls.Add(lblMessage);
            errorForm.Controls.Add(btnDetails);
            errorForm.Controls.Add(btnClose);
            errorForm.Controls.Add(detailsPanel);

            errorForm.ShowDialog();
        }
    }
}