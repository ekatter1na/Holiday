using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Курсовая_Жирнова_Е.А._Holiday.Models;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    public partial class UpdateEventForm : Form
    {
        private int _eventId;
        private string connectionString = "Data Source=LAPTOP-NDRNKPSE;Initial Catalog=Holiday;Integrated Security=True;";

        public UpdateEventForm(int num_event)
        {
            InitializeComponent();
            _eventId = num_event;
            Save.Click += Save_Click;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            DialogResult result = ShowQuestion("Вы действительно хотите закрыть форму?\nИзменения не будут сохранены!", "Подтверждение");
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async void UpdateEventForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Загрузка категорий
                    string categoriesQuery = "SELECT ID_Event_Category, Title FROM Event_Category ORDER BY Title";
                    SqlCommand categoriesCmd = new SqlCommand(categoriesQuery, connection);
                    SqlDataReader categoriesReader = await categoriesCmd.ExecuteReaderAsync();

                    List<EventCategory> categories = new List<EventCategory>();
                    while (await categoriesReader.ReadAsync())
                    {
                        categories.Add(new EventCategory
                        {
                            ID_Event_Category = categoriesReader.GetInt32(0),
                            Title = categoriesReader.GetString(1)
                        });
                    }
                    categoriesReader.Close();

                    comboBoxCategories.DataSource = categories;
                    comboBoxCategories.DisplayMember = "Title";
                    comboBoxCategories.ValueMember = "ID_Event_Category";
                    comboBoxCategories.SelectedIndex = -1;

                    // Загрузка мест
                    string locationsQuery = "SELECT ID_Location, Name_Location, Address_Location, Rental_Price FROM Location ORDER BY Name_Location";
                    SqlCommand locationsCmd = new SqlCommand(locationsQuery, connection);
                    SqlDataReader locationsReader = await locationsCmd.ExecuteReaderAsync();

                    List<Location> locations = new List<Location>();
                    while (await locationsReader.ReadAsync())
                    {
                        locations.Add(new Location
                        {
                            ID_Location = locationsReader.GetInt32(0),
                            Name_Location = locationsReader.GetString(1),
                            Address_Location = locationsReader.GetString(2),
                            Rental_Price = locationsReader.GetDecimal(3)
                        });
                    }
                    locationsReader.Close();

                    comboBoxLocations.DataSource = locations;
                    comboBoxLocations.DisplayMember = "Name_Location";
                    comboBoxLocations.ValueMember = "ID_Location";
                    comboBoxLocations.SelectedIndex = -1;

                    // Загрузка сотрудников
                    string staffQuery = "SELECT ID_Employee, Surname, First_Name, Last_Name, Phone_Number, Role FROM Staff ORDER BY Surname, First_Name";
                    SqlCommand staffCmd = new SqlCommand(staffQuery, connection);
                    SqlDataReader staffReader = await staffCmd.ExecuteReaderAsync();

                    List<Staff> staffList = new List<Staff>();
                    while (await staffReader.ReadAsync())
                    {
                        staffList.Add(new Staff
                        {
                            ID_Employee = staffReader.GetInt32(0),
                            Surname = staffReader.GetString(1),
                            First_Name = staffReader.GetString(2),
                            Last_Name = staffReader.IsDBNull(3) ? null : staffReader.GetString(3),
                            Phone_Number = staffReader.GetString(4),
                            Role = staffReader.IsDBNull(5) ? null : staffReader.GetString(5)
                        });
                    }
                    staffReader.Close();

                    comboBoxStaff.DataSource = staffList;
                    comboBoxStaff.DisplayMember = "FullName";
                    comboBoxStaff.ValueMember = "ID_Employee";
                    comboBoxStaff.SelectedIndex = -1;

                    // Загрузка услуг
                    string servicesQuery = "SELECT ID_Additional_Services, Name_Services, Cost FROM Additional_Services ORDER BY Name_Services";
                    SqlCommand servicesCmd = new SqlCommand(servicesQuery, connection);
                    SqlDataReader servicesReader = await servicesCmd.ExecuteReaderAsync();

                    List<AdditionalService> services = new List<AdditionalService>();
                    while (await servicesReader.ReadAsync())
                    {
                        services.Add(new AdditionalService
                        {
                            ID_Additional_Services = servicesReader.GetInt32(0),
                            Name_Services = servicesReader.GetString(1),
                            Cost = servicesReader.GetDecimal(2)
                        });
                    }
                    servicesReader.Close();

                    comboBoxServices.DataSource = services;
                    comboBoxServices.DisplayMember = "Name_Services";
                    comboBoxServices.ValueMember = "ID_Additional_Services";
                    comboBoxServices.SelectedIndex = -1;

                    // Загрузка заказчиков
                    string customersQuery = "SELECT ID_Customer, Surname, First_Name, Last_Name, Phone_Number FROM Customer ORDER BY Surname, First_Name";
                    SqlCommand customersCmd = new SqlCommand(customersQuery, connection);
                    SqlDataReader customersReader = await customersCmd.ExecuteReaderAsync();

                    List<Customer> customers = new List<Customer>();
                    while (await customersReader.ReadAsync())
                    {
                        customers.Add(new Customer
                        {
                            ID_Customer = customersReader.GetInt32(0),
                            Surname = customersReader.GetString(1),
                            First_Name = customersReader.GetString(2),
                            Last_Name = customersReader.IsDBNull(3) ? null : customersReader.GetString(3),
                            Phone_Number = customersReader.GetString(4)
                        });
                    }
                    customersReader.Close();

                    comboBoxCustomers.DataSource = customers;
                    comboBoxCustomers.DisplayMember = "FullName";
                    comboBoxCustomers.ValueMember = "ID_Customer";
                    comboBoxCustomers.SelectedIndex = -1;

                    // Загрузка данных конкретного мероприятия
                    string eventQuery = @"
                        SELECT 
                            ID_Customer,
                            ID_Event_Category,
                            ID_Location,
                            Data_Event,
                            Beginning,
                            Duration,
                            Number_Participants,
                            ID_Employee,
                            Price,
                            ID_Additional_Services
                        FROM Event 
                        WHERE ID_Event = @eventId";

                    SqlCommand eventCmd = new SqlCommand(eventQuery, connection);
                    eventCmd.Parameters.AddWithValue("@eventId", _eventId);

                    SqlDataReader eventReader = await eventCmd.ExecuteReaderAsync();

                    if (await eventReader.ReadAsync())
                    {
                        // Устанавливаем выбранные значения
                        comboBoxCustomers.SelectedValue = eventReader.GetInt32(0);
                        comboBoxCategories.SelectedValue = eventReader.GetInt32(1);
                        comboBoxLocations.SelectedValue = eventReader.GetInt32(2);
                        comboBoxStaff.SelectedValue = eventReader.GetInt32(7);
                        comboBoxServices.SelectedValue = eventReader.GetInt32(9);

                        // Устанавливаем даты
                        DatePicker.Value = eventReader.GetDateTime(3);
                        TimePicker.Value = DateTime.Today.Add(eventReader.GetTimeSpan(4));

                        // Устанавливаем числовые значения
                        numericUpDownDuration.Value = eventReader.GetInt32(5);
                        numericUpDownParticipants.Value = eventReader.GetInt32(6);
                        numericUpDownPrice.Value = eventReader.GetDecimal(8);
                    }
                    else
                    {
                        ShowErrorWithDetails("Ошибка загрузки", $"Мероприятие с ID {_eventId} не найдено!",
                            "Проверьте, существует ли мероприятие в базе данных.");
                        this.Close();
                    }
                    eventReader.Close();
                }
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка загрузки", "Не удалось загрузить данные мероприятия",
                    $"Ошибка: {ex.Message}\n\nПроверьте подключение к базе данных.");
            }
        }

       

        // Метод для проверки корректности даты и времени
        private bool ValidateDateTime(DateTime date, TimeSpan time)
        {
            DateTime selectedDateTime = date.Date + time;
            DateTime now = DateTime.Now;

            if (selectedDateTime < now)
            {
                ShowErrorWithDetails("Ошибка валидации", "Дата и время не могут быть в прошлом",
                    $"Вы выбрали: {date:dd.MM.yyyy} {time:hh\\:mm}\n\n" +
                    $"Текущее время: {now:dd.MM.yyyy HH:mm}\n\n" +
                    "Пожалуйста, выберите дату и время не раньше текущего момента.");
                return false;
            }
            return true;
        }

        // Проверка времени начала 
        private bool ValidateStartTime(TimeSpan time)
        {
            TimeSpan minTime = new TimeSpan(8, 0, 0);  
            TimeSpan maxTime = new TimeSpan(23, 0, 0); 

            if (time < minTime || time > maxTime)
            {
                ShowErrorWithDetails("Ошибка валидации", "Некорректное время начала",
                    $"Вы выбрали: {time:hh\\:mm}\n\n" +
                    $"Время начала мероприятия должно быть в диапазоне от 08:00 до 23:00.\n\n" +
                    "Пожалуйста, выберите корректное время.");
                return false;
            }
            return true;
        }
        // Метод для проверки длительности
        private bool ValidateDuration(int duration)
        {
            if (duration < 1 || duration > 1000)
            {
                ShowErrorWithDetails("Ошибка валидации", "Некорректная длительность",
                    "Длительность мероприятия не должна превышать 1000 часов.\n\n" +
                    $"Вы указали: {duration} ч.");
                return false;
            }
            return true;
        }

        // Метод для проверки количества участников
        private bool ValidateParticipants(int participants)
        {
            if (participants < 1 || participants > 10000)
            {
                ShowErrorWithDetails("Ошибка валидации", "Некорректное количество участников",
                    "Количество участников должно быть от 1 до 10000 человек.\n\n" +
                    $"Вы указали: {participants} чел.");
                return false;
            }
            return true;
        }

        // Метод для проверки цены
        private bool ValidatePrice(decimal price)
        {
            if (price < 0)
            {
                ShowErrorWithDetails("Ошибка валидации", "Некорректная цена",
                    "Цена мероприятия не может быть отрицательной.\n\n" +
                    $"Вы указали: {price:C}");
                return false;
            }
            return true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCustomers.SelectedIndex == -1)
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Не выбран заказчик",
                        "Пожалуйста, выберите заказчика из списка.");
                    return;
                }

                if (comboBoxCategories.SelectedIndex == -1)
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Не выбрана категория",
                        "Пожалуйста, выберите категорию мероприятия.");
                    return;
                }

                if (comboBoxLocations.SelectedIndex == -1)
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Не выбрано место",
                        "Пожалуйста, выберите место проведения.");
                    return;
                }

                if (comboBoxStaff.SelectedIndex == -1)
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Не выбран сотрудник",
                        "Пожалуйста, выберите ответственного сотрудника.");
                    return;
                }

                if (comboBoxServices.SelectedIndex == -1)
                {
                    ShowErrorWithDetails("Ошибка редактирования", "Не выбрана услуга",
                        "Пожалуйста, выберите дополнительную услугу.");
                    return;
                }

                // Получаем ID выбранных объектов
                int customerId = (int)comboBoxCustomers.SelectedValue;
                int categoryId = (int)comboBoxCategories.SelectedValue;
                int locationId = (int)comboBoxLocations.SelectedValue;
                int staffId = (int)comboBoxStaff.SelectedValue;
                int serviceId = (int)comboBoxServices.SelectedValue;

                DateTime eventDate = DatePicker.Value.Date;
                TimeSpan eventTime = TimePicker.Value.TimeOfDay;
                int duration = (int)numericUpDownDuration.Value;
                int participants = (int)numericUpDownParticipants.Value;
                decimal price = numericUpDownPrice.Value;

                if (!ValidateDateTime(eventDate, eventTime)) return;
                if (!ValidateStartTime(eventTime)) return;
                if (!ValidateDuration(duration)) return;
                if (!ValidateParticipants(participants)) return;
                if (!ValidatePrice(price)) return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateEvent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EventID", _eventId);
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);
                        cmd.Parameters.AddWithValue("@ServiceID", serviceId);
                        cmd.Parameters.AddWithValue("@EmployeeID", staffId);
                        cmd.Parameters.AddWithValue("@EventDate", eventDate);
                        cmd.Parameters.AddWithValue("@Beginning", eventTime);
                        cmd.Parameters.AddWithValue("@Duration", duration);
                        cmd.Parameters.AddWithValue("@Participants", participants);
                        cmd.Parameters.AddWithValue("@Price", price);


                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0 && result.Columns.Contains("Сообщение"))
                            {
                                string message = result.Rows[0]["Сообщение"].ToString();

                                if (message.Contains("Ошибка"))
                                {
                                    
                                    ShowErrorWithDetails("Ошибка редактирования", "Не удалось обновить мероприятие", message);
                                    return;
                                }
                                else
                                {
                                    
                                    ShowInfo(message);
                                }
                            }
                            else
                            {
                                ShowInfo("Мероприятие успешно обновлено!");
                            }
                        }

                        EventForm f = Application.OpenForms.OfType<EventForm>().FirstOrDefault();
                        if (f != null)
                        {
                            f.LoadEvents(); 
                        }

                        this.Close(); 
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                string errorMessage = sqlEx.Message;
                string errorDetails = "";

                if (errorMessage.Contains("занято") || errorMessage.Contains("место"))
                {
                    errorDetails = "Выбранное место уже занято на указанную дату.\n\n" +
                                  "Пожалуйста, выберите другую дату или другое место проведения.";
                }
                else if (errorMessage.Contains("прошлом"))
                {
                    errorDetails = "Дата проведения не может быть в прошлом.\n\n" +
                                  "Пожалуйста, выберите дату не раньше сегодняшнего дня.";
                }
                else if (errorMessage.Contains("существует"))
                {
                    errorDetails = "Один из выбранных справочников (заказчик, категория, место, услуга, сотрудник) был удален.\n\n" +
                                  "Пожалуйста, обновите данные и попробуйте снова.";
                }
                else
                {
                    errorDetails = $"Код ошибки: {sqlEx.Number}\nСообщение: {sqlEx.Message}";
                }

                ShowErrorWithDetails("Ошибка редактирования", "Не удалось обновить мероприятие", errorDetails);
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка", "Произошла ошибка при редактировании мероприятия",
                    $"Ошибка: {ex.Message}\n\nПопробуйте еще раз.");
            }
        }
        private void ShowInfo(string message)
        {
            Form infoForm = new Form();
            infoForm.Text = "Успех";
            infoForm.StartPosition = FormStartPosition.CenterParent;
            infoForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            infoForm.MaximizeBox = false;
            infoForm.MinimizeBox = false;
            infoForm.Size = new Size(450, 210);
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
            lblMessage.Size = new Size(360, 100);
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Location = new Point(335, 125);
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

        private DialogResult ShowQuestion(string message, string title = "Подтверждение")
        {
            Form questionForm = new Form();
            questionForm.Text = title;
            questionForm.StartPosition = FormStartPosition.CenterParent;
            questionForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            questionForm.MaximizeBox = false;
            questionForm.MinimizeBox = false;
            questionForm.Size = new Size(450, 170);
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

            Button btnYes = new Button();
            btnYes.Text = "Да";
            btnYes.Location = new Point(215, 90);
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
            btnNo.Location = new Point(320, 90);
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
            questionForm.Controls.Add(btnYes);
            questionForm.Controls.Add(btnNo);

            return questionForm.ShowDialog();
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
