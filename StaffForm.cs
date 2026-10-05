using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    public partial class StaffForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-NDRNKPSE;Initial Catalog=Holiday;Integrated Security=True;";
        private DataTable originalWorkloadTable;
        public StaffForm()
        {
            InitializeComponent();
            dataGridView1.DataError += dataGridView_DataError;

            SearchButton.Click += SearchButton_Click;
            btnResetFilters.Click += BtnResetFilters_Click;
            comboBoxStatus.SelectedIndexChanged += ComboBoxStatus_SelectedIndexChanged;
            comboBoxStatus.SelectedIndex = -1; // Ничего не выбрано
        }
        public StaffForm(Size size, Point location, FormWindowState state)
        {
            InitializeComponent();
            dataGridView1.DataError += dataGridView_DataError;
            SearchButton.Click += SearchButton_Click;
            btnResetFilters.Click += BtnResetFilters_Click;
            comboBoxStatus.SelectedIndexChanged += ComboBoxStatus_SelectedIndexChanged;
            comboBoxStatus.SelectedIndex = -1;
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
        private void StaffForm_Load(object sender, EventArgs e)
        {
            LoadStaffData();
            LoadEmployeeLoad();
        }

        private void LoadStaffData()
        {
            try
            {
                this.staffTableAdapter.Fill(this.holidayDataSet13.Staff);
                dataGridView1.Columns[0].Visible = false; 
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка загрузки", "Не удалось загрузить данные сотрудников",
                    $"Ошибка: {ex.Message}");
            }
        }

        private void LoadEmployeeLoad()
        {
            try
            {
                string query = @"
            SELECT 
                s.Surname + ' ' + s.First_Name + ISNULL(' ' + s.Last_Name, '') AS [ФИО сотрудника],
                s.Phone_Number AS [Телефон],
                s.Passport AS [Паспорт],
                COUNT(e.ID_Event) AS [Количество предстоящих мероприятий],
                CASE 
                    WHEN COUNT(e.ID_Event) = 0 THEN 'Нет загруженности'
                    WHEN COUNT(e.ID_Event) = 1 THEN 'Низкая'
                    WHEN COUNT(e.ID_Event) = 2 THEN 'Низкая'
                    WHEN COUNT(e.ID_Event) = 3 THEN 'Средняя'
                    WHEN COUNT(e.ID_Event) = 4 THEN 'Средняя'
                    WHEN COUNT(e.ID_Event) >= 5 THEN 'Высокая'
                END AS [Загруженность]
            FROM Staff s
            LEFT JOIN Event e ON s.ID_Employee = e.ID_Employee 
                AND e.Data_Event > GETDATE()
            GROUP BY 
                s.Surname, s.First_Name, s.Last_Name, s.Phone_Number, s.Passport
            ORDER BY [Количество предстоящих мероприятий] DESC, [ФИО сотрудника]";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    originalWorkloadTable = new DataTable();
                    adapter.Fill(originalWorkloadTable);
                    dataGridView2.DataSource = originalWorkloadTable;

                    // Настройка ширины столбцов
                    if (dataGridView2.Columns.Count > 0)
                    {
                        dataGridView2.Columns["ФИО сотрудника"].Width = 250;
                        dataGridView2.Columns["Телефон"].Width = 150;
                        dataGridView2.Columns["Паспорт"].Width = 150;
                        dataGridView2.Columns["Количество предстоящих мероприятий"].Width = 180;
                        dataGridView2.Columns["Загруженность"].Width = 150;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка загрузки", "Не удалось загрузить данные о загруженности",
                    $"Ошибка: {ex.Message}");
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
            LoadStaffData();
            LoadEmployeeLoad();
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadStaffData();
                return;
            }

            try
            {
                DataTable result = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SearchStaff", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SearchText", searchText);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(result);
                    }
                }

                if (result != null && result.Rows.Count > 0)
                {
                    dataGridView1.DataSource = result;
                    // Скрываем колонку ID (первая колонка)
                    if (dataGridView1.Columns.Count > 0)
                        dataGridView1.Columns[0].Visible = false;
                }
                else
                {
                    ShowInfo("Сотрудники не найдены.");
                    LoadStaffData();
                    LoadEmployeeLoad();
                }
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка поиска", "Не удалось выполнить поиск", ex.Message);
            }
        }

        // ==================== ФИЛЬТРАЦИЯ ЗАГРУЖЕННОСТИ ====================

        private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (originalWorkloadTable == null) return;

            // Если ничего не выбрано или выбрано "Все" - показываем все данные
            if (comboBoxStatus.SelectedIndex == -1)
            {
                dataGridView2.DataSource = originalWorkloadTable;
                return;
            }

            string selectedStatus = comboBoxStatus.SelectedItem.ToString();

            if (selectedStatus == "Все")
            {
                dataGridView2.DataSource = originalWorkloadTable;
                return;
            }

            // Фильтруем данные
            DataView dv = originalWorkloadTable.DefaultView;
            dv.RowFilter = $"[Загруженность] = '{selectedStatus}'";

            if (dv.Count == 0)
            {
                // Если нет сотрудников с выбранным статусом, показываем исходную таблицу
                dataGridView2.DataSource = originalWorkloadTable;
                // Сбрасываем выбор в комбобоксе, чтобы пользователь видел, что фильтр не активен
                comboBoxStatus.SelectedIndex = -1;
                ShowInfo($"Нет сотрудников со статусом загруженности \"{selectedStatus}\"");
                LoadStaffData();
                LoadEmployeeLoad();
            }
            else
            {
                dataGridView2.DataSource = dv;
            }
        }

        private void BtnResetFilters_Click(object sender, EventArgs e)
        {
            comboBoxStatus.SelectedIndex = -1;
            dataGridView2.DataSource = originalWorkloadTable;
            LoadStaffData();
            LoadEmployeeLoad();
        }


        // получение данных из ячеек
        private string GetCellValue(DataGridView grid, int columnIndex)
        {
            if (grid.CurrentRow == null) return "";
            if (grid.CurrentRow.Cells[columnIndex].Value == null) return "";
            if (grid.CurrentRow.Cells[columnIndex].Value == DBNull.Value) return "";
            return grid.CurrentRow.Cells[columnIndex].Value.ToString();
        }

        // поверки
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

        private bool IsValidPassport(string passport)
        {
            if (string.IsNullOrWhiteSpace(passport)) return false;
            if (passport.Length != 11) return false;
            return true;
        }

        // обработчки ошибок
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
                                  "Примеры: 89161234567, 89678765746";
                }
                else if (columnName.Contains("Паспорт") || columnName.Contains("Passport"))
                {
                    errorMessage = "Некорректный формат паспортных данных";
                    errorDetails = $"Вы ввели: \"{enteredValue}\"\n\n" +
                                  "Паспортные данные должны содержать 11 символов.\n\n" +
                                  "Примеры: 1234 567890, 5676 479309";
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
                errorDetails = $"Ошибка: {e.Exception.Message}";
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
                string passport = GetCellValue(dataGridView1, 5);
                string login = GetCellValue(dataGridView1, 6);
                string password = GetCellValue(dataGridView1, 7);
                string role = GetCellValue(dataGridView1, 8);

                if (string.IsNullOrWhiteSpace(surname))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Фамилия не введена",
                        "Пожалуйста, введите фамилию сотрудника.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(firstName))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Имя не введено",
                        "Пожалуйста, введите имя сотрудника.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(phone))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Телефон не введен",
                        "Пожалуйста, введите номер телефона (11 цифр).");
                    return;
                }

                if (!IsValidPhone(phone))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Некорректный формат телефона",
                        $"Вы ввели: \"{phone}\"\n\nТелефон должен содержать 11 цифр.\nПример: 89161234567");
                    return;
                }

                if (string.IsNullOrWhiteSpace(passport))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Паспортные данные не введены",
                        "Пожалуйста, введите паспортные данные (11 символов).");
                    return;
                }

                if (!IsValidPassport(passport))
                {
                    ShowErrorWithDetails("Ошибка добавления", "Некорректный формат паспорта",
                        $"Вы ввели: \"{passport}\"\n\nПаспортные данные должны содержать 11 символов.\nПример: 1234 567890");
                    return;
                }

                if (string.IsNullOrWhiteSpace(role))
                {
                    role = "Сотрудник";
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("AddStaff", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Surname", surname);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", string.IsNullOrWhiteSpace(lastName) ? (object)DBNull.Value : lastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                        cmd.Parameters.AddWithValue("@Passport", passport);
                        cmd.Parameters.AddWithValue("@Login", string.IsNullOrWhiteSpace(login) ? (object)DBNull.Value : login);
                        cmd.Parameters.AddWithValue("@Password", string.IsNullOrWhiteSpace(password) ? (object)DBNull.Value : password);
                        cmd.Parameters.AddWithValue("@Role", role);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string result = reader["Сообщение"].ToString();
                                if (result.Contains("Ошибка"))
                                {
                                    ShowErrorWithDetails("Ошибка добавления сотрудника", result,
                                        "Проверьте правильность введенных данных.");
                                }
                                else
                                {
                                    ShowInfo(result);
                                    LoadStaffData();
                                    LoadEmployeeLoad();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка", "Произошла ошибка при добавлении",
                    $"Ошибка: {ex.Message}");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Не выбран сотрудник",
                        "Выберите строку с сотрудником, которого хотите отредактировать.");
                    return;
                }

                int employeeId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string surname = GetCellValue(dataGridView1, 1);
                string firstName = GetCellValue(dataGridView1, 2);
                string lastName = GetCellValue(dataGridView1, 3);
                string phone = GetCellValue(dataGridView1, 4);
                string passport = GetCellValue(dataGridView1, 5);
                string login = GetCellValue(dataGridView1, 6);
                string password = GetCellValue(dataGridView1, 7);
                string role = GetCellValue(dataGridView1, 8);

                if (string.IsNullOrWhiteSpace(surname))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Фамилия не может быть пустой",
                        "Пожалуйста, введите фамилию сотрудника.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(firstName))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Имя не может быть пустым",
                        "Пожалуйста, введите имя сотрудника.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(phone))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Телефон не введен",
                        "Пожалуйста, введите номер телефона (11 цифр).");
                    return;
                }

                if (!IsValidPhone(phone))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Некорректный формат телефона",
                        $"Вы ввели: \"{phone}\"\n\nТелефон должен содержать 11 цифр.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(passport))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Паспортные данные не введены",
                        "Пожалуйста, введите паспортные данные (11 символов).");
                    return;
                }

                if (!IsValidPassport(passport))
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Некорректный формат паспорта",
                        $"Вы ввели: \"{passport}\"\n\nПаспортные данные должны содержать 11 символов.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(role))
                {
                    role = "Сотрудник";
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateStaff", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Employee", employeeId);
                        cmd.Parameters.AddWithValue("@Surname", surname);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", string.IsNullOrWhiteSpace(lastName) ? (object)DBNull.Value : lastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                        cmd.Parameters.AddWithValue("@Passport", passport);
                        cmd.Parameters.AddWithValue("@Login", string.IsNullOrWhiteSpace(login) ? (object)DBNull.Value : login);
                        cmd.Parameters.AddWithValue("@Password", string.IsNullOrWhiteSpace(password) ? (object)DBNull.Value : password);
                        cmd.Parameters.AddWithValue("@Role", role);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string result = reader["Сообщение"].ToString();
                                if (result.Contains("Ошибка"))
                                {
                                    ShowErrorWithDetails("Ошибка редактирования сотрудника", result,
                                        "Проверьте правильность введенных данных.");
                                }
                                else
                                {
                                    ShowInfo(result);
                                    LoadStaffData();
                                    LoadEmployeeLoad();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка", "Произошла ошибка при редактировании",
                    $"Ошибка: {ex.Message}");
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    ShowErrorWithDetails("Ошибка удаления", "Не выбран сотрудник",
                        "Выберите строку с сотрудником, которого хотите удалить.");
                    return;
                }

                int employeeId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string fullName = GetCellValue(dataGridView1, 1) + " " + GetCellValue(dataGridView1, 2);

                DialogResult result = ShowQuestion($"Удалить сотрудника \"{fullName}\"?",
           "Подтверждение удаления");

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("DeleteStaff", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_Employee", employeeId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string message = reader["Сообщение"].ToString();
                                    if (message.Contains("Ошибка"))
                                    {
                                        ShowErrorWithDetails("Ошибка удаления сотрудника", message,
                                            "Возможные причины:\n" +
                                            "• Сотрудник назначен на будущие мероприятия\n\n" +
                                            "Сначала переназначьте или отмените мероприятия этого сотрудника.");
                                    }
                                    else
                                    {
                                        ShowInfo(message);
                                        LoadStaffData();
                                        LoadEmployeeLoad();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка", "Произошла ошибка при удалении",
                    $"Ошибка: {ex.Message}");
            }
        }
        private DialogResult ShowQuestion(string message, string title = "Подтверждение")
        {
            Form questionForm = new Form();
            questionForm.Text = title;
            questionForm.StartPosition = FormStartPosition.CenterParent;
            questionForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            questionForm.MaximizeBox = false;
            questionForm.MinimizeBox = false;
            questionForm.Size = new Size(450, 200);
            questionForm.BackColor = Color.White;

            PictureBox iconBox = new PictureBox();
            iconBox.Image = SystemIcons.Question.ToBitmap();
            iconBox.Location = new Point(15, 20);
            iconBox.Size = new Size(32, 32);
            iconBox.SizeMode = PictureBoxSizeMode.StretchImage;

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblMessage.Location = new Point(60, 20);
            lblMessage.Size = new Size(310, 50);
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            Label lblNote = new Label();
            lblNote.Text = "Внимание: Если у сотрудника есть будущие мероприятия, \nудаление будет запрещено!";
            lblNote.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblNote.ForeColor = Color.FromArgb(220, 53, 69);
            lblNote.Location = new Point(60, 70);
            lblNote.Size = new Size(360, 45);
            lblNote.TextAlign = ContentAlignment.MiddleLeft;


            Button btnYes = new Button();
            btnYes.Text = "Да";
            btnYes.Location = new Point(215, 125);
            btnYes.Size = new Size(85, 30);
            btnYes.BackColor = Color.WhiteSmoke;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.Silver;
            btnYes.FlatAppearance.BorderSize = 0;
            btnYes.FlatStyle = FlatStyle.Flat;
            btnYes.Cursor = Cursors.Hand;
            btnYes.DialogResult = DialogResult.Yes;

            Button btnNo = new Button();
            btnNo.Text = "Нет";
            btnNo.Location = new Point(320, 125);
            btnNo.Size = new Size(85, 30);
            btnNo.BackColor = Color.WhiteSmoke;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.Silver;
            btnNo.FlatAppearance.BorderSize = 0;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Cursor = Cursors.Hand;
            btnNo.DialogResult = DialogResult.No;

            questionForm.Controls.Add(iconBox);
            questionForm.Controls.Add(lblMessage);
            questionForm.Controls.Add(lblNote);
            questionForm.Controls.Add(btnYes);
            questionForm.Controls.Add(btnNo);

            return questionForm.ShowDialog();
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
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Cursor = Cursors.Hand;
            btnOK.Click += (s, ev) => infoForm.Close();

            infoForm.Controls.Add(iconBox);
            infoForm.Controls.Add(lblMessage);
            infoForm.Controls.Add(btnOK);

            infoForm.ShowDialog();
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
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.Cursor = Cursors.Hand;

            Button btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Location = new Point(330, 85);
            btnClose.Size = new Size(100, 30);
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.ForeColor = Color.Black;
            btnClose.FlatAppearance.BorderColor = Color.Silver;
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