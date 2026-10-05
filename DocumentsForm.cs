using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    public partial class DocumentsForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-NDRNKPSE;Initial Catalog=Holiday;Integrated Security=True;";

        public DocumentsForm()
        {
            InitializeComponent();
            dataGridView1.DataError += dataGridView_DataError;
            dataGridView2.DataError += dataGridView_DataError;
            dataGridView3.DataError += dataGridView_DataError;
        }

        public DocumentsForm(Size size, Point location, FormWindowState state)
        {
            InitializeComponent();
            dataGridView1.DataError += dataGridView_DataError;
            dataGridView2.DataError += dataGridView_DataError;
            dataGridView3.DataError += dataGridView_DataError;

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
        private void DocumentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                this.event_CategoryTableAdapter.Fill(this.holidayDataSet7.Event_Category);
                dataGridView1.Columns[0].Visible = false;

                this.additional_ServicesTableAdapter2.Fill(this.holidayDataSet10.Additional_Services);
                dataGridView2.Columns[0].Visible = false;

                this.locationTableAdapter.Fill(this.holidayDataSet11.Location);
                dataGridView3.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка загрузки", "Не удалось загрузить данные",
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
            LoadData();
        }

        private string GetCellValue(DataGridView grid, int columnIndex)
        {
            if (grid.CurrentRow == null) return "";
            if (grid.CurrentRow.Cells[columnIndex].Value == null) return "";
            if (grid.CurrentRow.Cells[columnIndex].Value == DBNull.Value) return "";
            return grid.CurrentRow.Cells[columnIndex].Value.ToString();
        }
        private bool IsValidDecimal(string input, out decimal result)
        {
            result = 0;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            // Удаляем пробелы
            input = input.Trim();

            // Проверяем, есть ли буквы
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    return false;
                }
            }

            // Заменяем запятую на точку для унификации
            string normalizedInput = input.Replace(',', '.');

            // Проверяем, что после замены только одна точка
            int dotCount = normalizedInput.Count(c => c == '.');
            if (dotCount > 1)
            {
                return false;
            }

            // Пробуем распарсить
            return decimal.TryParse(normalizedInput, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out result);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == Category) // Категории
                {
                    if (dataGridView1.CurrentRow == null)
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Не выбрана строка",
                            "Выберите строку в таблице категорий, введите название и нажмите кнопку 'Добавить'.");
                        return;
                    }

                    string categoryName = GetCellValue(dataGridView1, 1);

                    if (string.IsNullOrWhiteSpace(categoryName))
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Название категории не введено",
                            "Пожалуйста, введите название категории в выбранной строке.");
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("AddEventCategory", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Title", categoryName);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string result = reader["Сообщение"].ToString();
                                    if (result.Contains("Ошибка"))
                                    {
                                        ShowErrorWithDetails("Ошибка добавления категории", result,
                                            "Проверьте правильность введенных данных.\n\n" +
                                            "Возможные причины:\n" +
                                            "- Название категории уже существует\n" +
                                            "- Название содержит недопустимые символы");
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
                else if (tabControl1.SelectedTab == Service) // Услуги
                {
                    if (dataGridView2.CurrentRow == null)
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Не выбрана строка",
                            "Выберите строку в таблице услуг, введите название и стоимость и нажмите кнопку 'Добавить'.");
                        return;
                    }

                    string serviceName = GetCellValue(dataGridView2, 1);
                    string costStr = GetCellValue(dataGridView2, 2);

                    // Проверка названия
                    if (string.IsNullOrWhiteSpace(serviceName))
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Название услуги не введено",
                            "Пожалуйста, введите название услуги в выбранной строке.");
                        return;
                    }

                    // Проверка стоимости на пустоту
                    if (string.IsNullOrWhiteSpace(costStr))
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Стоимость не введена",
                            "Пожалуйста, введите стоимость услуги.\n\n" +
                            "Примеры правильного ввода:\n" +
                            "- 1000\n" +
                            "- 1500.50\n" +
                            "- 2000,00");
                        return;
                    }

                    // Проверка стоимости на корректность
                    if (!IsValidDecimal(costStr, out decimal cost))
                    {
                        // Проверяем, есть ли буквы
                        bool hasLetters = false;
                        foreach (char c in costStr)
                        {
                            if (char.IsLetter(c))
                            {
                                hasLetters = true;
                                break;
                            }
                        }

                        if (hasLetters)
                        {
                            ShowErrorWithDetails("Ошибка добавления", "Стоимость содержит буквы",
                                "В поле стоимости можно вводить только цифры, точку или запятую.\n\n" +
                                "Примеры правильного ввода:\n" +
                                "- 1000\n" +
                                "- 1500.50\n" +
                                "- 2000,00\n\n" +
                                "Проверьте, что вы не ввели буквы (например, '1000руб' - неправильно).");
                        }
                        else
                        {
                            ShowErrorWithDetails("Ошибка добавления", "Некорректная стоимость",
                                "Введите корректную стоимость услуги.\n\n" +
                                "Примеры правильного ввода:\n" +
                                "- 1000\n" +
                                "- 1500.50\n" +
                                "- 2000,00\n\n" +
                                "Стоимость должна быть положительным числом.");
                        }
                        return;
                    }

                    if (cost <= 0)
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Стоимость должна быть положительной",
                            "Стоимость услуги не может быть равна нулю или отрицательной.\n\n" +
                            "Пожалуйста, введите положительное число.");
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("AddAdditionalService", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", serviceName);
                            cmd.Parameters.AddWithValue("@Cost", cost);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string result = reader["Сообщение"].ToString();
                                    if (result.Contains("Ошибка"))
                                    {
                                        ShowErrorWithDetails("Ошибка добавления услуги", result,
                                            "Проверьте правильность введенных данных.\n\n" +
                                            "Возможные причины:\n" +
                                            "- Название услуги уже существует\n" +
                                            "- Стоимость введена неверно");
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
                else if (tabControl1.SelectedTab == tabPageLocation) // Места
                {
                    if (dataGridView3.CurrentRow == null)
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Не выбрана строка",
                            "Выберите строку в таблице мест, введите данные и нажмите кнопку 'Добавить'.");
                        return;
                    }

                    string name = GetCellValue(dataGridView3, 1);
                    string address = GetCellValue(dataGridView3, 2);
                    string priceStr = GetCellValue(dataGridView3, 3);

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Название места не введено",
                            "Пожалуйста, введите название места.");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(address))
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Адрес не введен",
                            "Пожалуйста, введите адрес места.");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(priceStr))
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Стоимость аренды не введена",
                            "Пожалуйста, введите стоимость аренды места.");
                        return;
                    }

                    if (!IsValidDecimal(priceStr, out decimal price))
                    {
                        bool hasLetters = false;
                        foreach (char c in priceStr)
                        {
                            if (char.IsLetter(c))
                            {
                                hasLetters = true;
                                break;
                            }
                        }

                        if (hasLetters)
                        {
                            ShowErrorWithDetails("Ошибка добавления", "Стоимость аренды содержит буквы",
                                "В поле стоимости можно вводить только цифры, точку или запятую.\n\n" +
                                "Примеры: 5000, 7500.50, 10000,00");
                        }
                        else
                        {
                            ShowErrorWithDetails("Ошибка добавления", "Некорректная стоимость аренды",
                                "Введите корректную стоимость аренды.\n\n" +
                                "Примеры: 5000, 7500.50, 10000,00");
                        }
                        return;
                    }

                    if (price <= 0)
                    {
                        ShowErrorWithDetails("Ошибка добавления", "Стоимость аренды должна быть положительной",
                            "Стоимость аренды не может быть равна нулю или отрицательной.");
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("AddLocation", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.Parameters.AddWithValue("@RentalPrice", price);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string result = reader["Сообщение"].ToString();
                                    if (result.Contains("Ошибка"))
                                    {
                                        ShowErrorWithDetails("Ошибка добавления места", result,
                                            "Проверьте правильность введенных данных.");
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
                if (tabControl1.SelectedTab == Category) // Категории
                {
                    if (dataGridView1.CurrentRow == null)
                    {
                        ShowErrorWithDetails("Ошибка редактирования", "Не выбрана категория",
                            "Выберите строку с категорией, которую хотите отредактировать.");
                        return;
                    }

                    int categoryId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string categoryName = GetCellValue(dataGridView1, 1);

                    if (string.IsNullOrWhiteSpace(categoryName))
                    {
                        ShowErrorWithDetails("Ошибка редактирования", "Название категории не может быть пустым",
                            "Пожалуйста, введите название категории.");
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UpdateEventCategory", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_Event_Category", categoryId);
                            cmd.Parameters.AddWithValue("@Title", categoryName);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string result = reader["Сообщение"].ToString();
                                    if (result.Contains("Ошибка"))
                                    {
                                        ShowErrorWithDetails("Ошибка редактирования категории", result,
                                            "Проверьте правильность введенных данных.");
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
                else if (tabControl1.SelectedTab == Service) // Услуги
                {
                    if (dataGridView2.CurrentRow == null)
                    {
                        ShowErrorWithDetails("Ошибка редактирования", "Не выбрана услуга",
                            "Выберите строку с услугой, которую хотите отредактировать.");
                        return;
                    }

                    int serviceId = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                    string serviceName = GetCellValue(dataGridView2, 1);
                    string costStr = GetCellValue(dataGridView2, 2);

                    if (string.IsNullOrWhiteSpace(serviceName))
                    {
                        ShowErrorWithDetails("Ошибка редактирования", "Название услуги не может быть пустым",
                            "Пожалуйста, введите название услуги.");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(costStr))
                    {
                        ShowErrorWithDetails("Ошибка редактирования", "Стоимость не введена",
                            "Пожалуйста, введите стоимость услуги.");
                        return;
                    }

                    if (!IsValidDecimal(costStr, out decimal cost))
                    {
                        bool hasLetters = false;
                        foreach (char c in costStr)
                        {
                            if (char.IsLetter(c))
                            {
                                hasLetters = true;
                                break;
                            }
                        }

                        if (hasLetters)
                        {
                            ShowErrorWithDetails("Ошибка редактирования", "Стоимость содержит буквы",
                                "В поле стоимости можно вводить только цифры, точку или запятую.");
                        }
                        else
                        {
                            ShowErrorWithDetails("Ошибка редактирования", "Некорректная стоимость",
                                "Введите корректную стоимость услуги.");
                        }
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UpdateAdditionalService", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_Additional_Services", serviceId);
                            cmd.Parameters.AddWithValue("@Name", serviceName);
                            cmd.Parameters.AddWithValue("@Cost", cost);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string result = reader["Сообщение"].ToString();
                                    if (result.Contains("Ошибка"))
                                    {
                                        ShowErrorWithDetails("Ошибка редактирования услуги", result,
                                            "Проверьте правильность введенных данных.");
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
                else if (tabControl1.SelectedTab == tabPageLocation) // Места
                {
                    if (dataGridView3.CurrentRow == null)
                    {
                        ShowErrorWithDetails("Ошибка редактирования", "Не выбрано место",
                            "Выберите строку с местом, которое хотите отредактировать.");
                        return;
                    }

                    int locationId = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                    string name = GetCellValue(dataGridView3, 1);
                    string address = GetCellValue(dataGridView3, 2);
                    string priceStr = GetCellValue(dataGridView3, 3);

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        ShowErrorWithDetails("Ошибка редактирования", "Название места не может быть пустым",
                            "Пожалуйста, введите название места.");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(address))
                    {
                        ShowErrorWithDetails("Ошибка редактирования", "Адрес не может быть пустым",
                            "Пожалуйста, введите адрес места.");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(priceStr))
                    {
                        ShowErrorWithDetails("Ошибка редактирования", "Стоимость аренды не введена",
                            "Пожалуйста, введите стоимость аренды.");
                        return;
                    }

                    if (!IsValidDecimal(priceStr, out decimal price))
                    {
                        bool hasLetters = false;
                        foreach (char c in priceStr)
                        {
                            if (char.IsLetter(c))
                            {
                                hasLetters = true;
                                break;
                            }
                        }

                        if (hasLetters)
                        {
                            ShowErrorWithDetails("Ошибка редактирования", "Стоимость аренды содержит буквы",
                                "В поле стоимости можно вводить только цифры, точку или запятую.");
                        }
                        else
                        {
                            ShowErrorWithDetails("Ошибка редактирования", "Некорректная стоимость аренды",
                                "Введите корректную стоимость аренды.");
                        }
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UpdateLocation", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_Location", locationId);
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.Parameters.AddWithValue("@RentalPrice", price);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string result = reader["Сообщение"].ToString();
                                    if (result.Contains("Ошибка"))
                                    {
                                        ShowErrorWithDetails("Ошибка редактирования места", result,
                                            "Проверьте правильность введенных данных.");
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
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка", "Произошла ошибка при редактировании",
                    $"Ошибка: {ex.Message}");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == Category) // Категории
                {
                    if (dataGridView1.CurrentRow == null)
                    {
                        ShowErrorWithDetails("Ошибка удаления", "Не выбрана категория",
                            "Выберите строку с категорией, которую хотите удалить.");
                        return;
                    }

                    int categoryId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string categoryName = GetCellValue(dataGridView1, 1);

                    DialogResult result = ShowQuestion($"Удалить категорию \"{categoryName}\"?", "Подтверждение удаления");

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("DeleteEventCategory", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ID_Event_Category", categoryId);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string message = reader["Сообщение"].ToString();
                                        if (message.Contains("Ошибка"))
                                        {
                                            ShowErrorWithDetails("Ошибка удаления категории", message,
                                                "Возможные причины:\n" +
                                                "- Категория используется в будущих мероприятиях\n\n" +
                                                "Сначала удалите или измените мероприятия, использующие эту категорию.");
                                        }
                                        else
                                        {
                                            ShowInfo(message);
                                            LoadData();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (tabControl1.SelectedTab == Service) // Услуги
                {
                    if (dataGridView2.CurrentRow == null)
                    {
                        ShowErrorWithDetails("Ошибка удаления", "Не выбрана услуга",
                            "Выберите строку с услугой, которую хотите удалить.");
                        return;
                    }

                    int serviceId = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                    string serviceName = GetCellValue(dataGridView2, 1);

                    DialogResult result = ShowQuestion($"Удалить услугу \"{serviceName}\"?", "Подтверждение удаления");

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("DeleteAdditionalService", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ID_Additional_Services", serviceId);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string message = reader["Сообщение"].ToString();
                                        if (message.Contains("Ошибка"))
                                        {
                                            ShowErrorWithDetails("Ошибка удаления услуги", message,
                                                "Возможные причины:\n" +
                                                "- Услуга используется в будущих мероприятиях\n\n" +
                                                "Сначала удалите или измените мероприятия, использующие эту услугу.");
                                        }
                                        else
                                        {
                                            ShowInfo(message);
                                            LoadData();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (tabControl1.SelectedTab == tabPageLocation) // Места
                {
                    if (dataGridView3.CurrentRow == null)
                    {
                        ShowErrorWithDetails("Ошибка удаления", "Не выбрано место",
                            "Выберите строку с местом, которое хотите удалить.");
                        return;
                    }

                    int locationId = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                    string locationName = GetCellValue(dataGridView3, 1);

                    DialogResult result = ShowQuestion($"Удалить место \"{locationName}\"?", "Подтверждение удаления");

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("DeleteLocation", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ID_Location", locationId);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string message = reader["Сообщение"].ToString();
                                        if (message.Contains("Ошибка"))
                                        {
                                            ShowErrorWithDetails("Ошибка удаления места", message,
                                                "Возможные причины:\n" +
                                                "- Место используется в будущих мероприятиях\n\n" +
                                                "Сначала удалите или измените мероприятия, использующие это место.");
                                        }
                                        else
                                        {
                                            ShowInfo(message);
                                            LoadData();
                                        }
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
        // Обработчик ошибок DataGridView 
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Получаем DataGridView, в котором произошла ошибка
            DataGridView grid = (DataGridView)sender;
            string columnName = grid.Columns[e.ColumnIndex].HeaderText;

            // Получаем введенное значение
            string enteredValue = "";
            try
            {
                if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    enteredValue = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
            catch { }

            // Определяем тип ошибки
            string errorMessage = "";
            string errorDetails = "";

            if (e.Exception is FormatException)
            {
                if (columnName.Contains("Стоимость") || columnName.Contains("Аренда"))
                {
                    errorMessage = "Некорректный ввод стоимости";
                    errorDetails = $"Вы ввели: \"{enteredValue}\"\n\n" +
                                  "В поле стоимости можно вводить только цифры, точку или запятую.\n\n" +
                                  "Примеры правильного ввода:\n" +
                                  "- 1000\n" +
                                  "- 1500.50\n" +
                                  "- 2000,00\n\n" +
                                  "Проверьте, что вы не ввели буквы (например, '1000руб' - неправильно).";
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
            lblMessage.Size = new Size(360, 50);
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            Label lblNote = new Label();
            lblNote.Text = "Внимание: Если элемент используется в будущих мероприятиях,\nудаление будет невозможно!";
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
            btnOK.Location = new Point(285, 80);
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

