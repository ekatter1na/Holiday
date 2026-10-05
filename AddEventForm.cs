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
    public partial class AddEventForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-NDRNKPSE;Initial Catalog=Holiday;Integrated Security=True;";

        public AddEventForm()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            DialogResult result = ShowQuestion("Вы действительно хотите закрыть форму?\nВведенные данные не будут сохранены!", "Подтверждение");
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            DatePicker.MinDate = DateTime.Now.Date;
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Загрузка заказчиков
                    string customersQuery = "SELECT ID_Customer, Surname, First_Name, Last_Name, Phone_Number FROM Customer ORDER BY Surname, First_Name";
                    SqlDataAdapter customersAdapter = new SqlDataAdapter(customersQuery, conn);
                    DataTable customersTable = new DataTable();
                    customersAdapter.Fill(customersTable);

                    List<Customer> customers = new List<Customer>();
                    foreach (DataRow row in customersTable.Rows)
                    {
                        customers.Add(new Customer
                        {
                            ID_Customer = Convert.ToInt32(row["ID_Customer"]),
                            Surname = row["Surname"].ToString(),
                            First_Name = row["First_Name"].ToString(),
                            Last_Name = row["Last_Name"] == DBNull.Value ? null : row["Last_Name"].ToString(),
                            Phone_Number = row["Phone_Number"].ToString()
                        });
                    }

                    comboBoxCustomers.DataSource = customers;
                    comboBoxCustomers.DisplayMember = "FullName";
                    comboBoxCustomers.ValueMember = "ID_Customer";
                    comboBoxCustomers.SelectedIndex = -1;

                    // Загрузка категорий
                    string categoriesQuery = "SELECT ID_Event_Category, Title FROM Event_Category ORDER BY Title";
                    SqlDataAdapter categoriesAdapter = new SqlDataAdapter(categoriesQuery, conn);
                    DataTable categoriesTable = new DataTable();
                    categoriesAdapter.Fill(categoriesTable);

                    List<EventCategory> categories = new List<EventCategory>();
                    foreach (DataRow row in categoriesTable.Rows)
                    {
                        categories.Add(new EventCategory
                        {
                            ID_Event_Category = Convert.ToInt32(row["ID_Event_Category"]),
                            Title = row["Title"].ToString()
                        });
                    }

                    comboBoxCategories.DataSource = categories;
                    comboBoxCategories.DisplayMember = "Title";
                    comboBoxCategories.ValueMember = "ID_Event_Category";
                    comboBoxCategories.SelectedIndex = -1;

                    // Загрузка мест
                    string locationsQuery = "SELECT ID_Location, Name_Location, Address_Location, Rental_Price FROM Location ORDER BY Name_Location";
                    SqlDataAdapter locationsAdapter = new SqlDataAdapter(locationsQuery, conn);
                    DataTable locationsTable = new DataTable();
                    locationsAdapter.Fill(locationsTable);

                    List<Location> locations = new List<Location>();
                    foreach (DataRow row in locationsTable.Rows)
                    {
                        locations.Add(new Location
                        {
                            ID_Location = Convert.ToInt32(row["ID_Location"]),
                            Name_Location = row["Name_Location"].ToString(),
                            Address_Location = row["Address_Location"].ToString(),
                            Rental_Price = Convert.ToDecimal(row["Rental_Price"])
                        });
                    }

                    comboBoxLocations.DataSource = locations;
                    comboBoxLocations.DisplayMember = "Name_Location";
                    comboBoxLocations.ValueMember = "ID_Location";
                    comboBoxLocations.SelectedIndex = -1;

                    // Загрузка сотрудников
                    string staffQuery = "SELECT ID_Employee, Surname, First_Name, Last_Name, Phone_Number, Role FROM Staff ORDER BY Surname, First_Name";
                    SqlDataAdapter staffAdapter = new SqlDataAdapter(staffQuery, conn);
                    DataTable staffTable = new DataTable();
                    staffAdapter.Fill(staffTable);

                    List<Staff> staffList = new List<Staff>();
                    foreach (DataRow row in staffTable.Rows)
                    {
                        staffList.Add(new Staff
                        {
                            ID_Employee = Convert.ToInt32(row["ID_Employee"]),
                            Surname = row["Surname"].ToString(),
                            First_Name = row["First_Name"].ToString(),
                            Last_Name = row["Last_Name"] == DBNull.Value ? null : row["Last_Name"].ToString(),
                            Phone_Number = row["Phone_Number"].ToString(),
                            Role = row["Role"] == DBNull.Value ? null : row["Role"].ToString()
                        });
                    }

                    comboBoxStaff.DataSource = staffList;
                    comboBoxStaff.DisplayMember = "FullName";
                    comboBoxStaff.ValueMember = "ID_Employee";
                    comboBoxStaff.SelectedIndex = -1;

                    // Загрузка услуг
                    string servicesQuery = "SELECT ID_Additional_Services, Name_Services, Cost FROM Additional_Services ORDER BY Name_Services";
                    SqlDataAdapter servicesAdapter = new SqlDataAdapter(servicesQuery, conn);
                    DataTable servicesTable = new DataTable();
                    servicesAdapter.Fill(servicesTable);

                    List<AdditionalService> services = new List<AdditionalService>();
                    foreach (DataRow row in servicesTable.Rows)
                    {
                        services.Add(new AdditionalService
                        {
                            ID_Additional_Services = Convert.ToInt32(row["ID_Additional_Services"]),
                            Name_Services = row["Name_Services"].ToString(),
                            Cost = Convert.ToDecimal(row["Cost"])
                        });
                    }

                    comboBoxServices.DataSource = services;
                    comboBoxServices.DisplayMember = "Name_Services";
                    comboBoxServices.ValueMember = "ID_Additional_Services";
                    comboBoxServices.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка загрузки", "Не удалось загрузить данные",
                    $"Ошибка: {ex.Message}\n\nПроверьте подключение к базе данных.");
            }
        }

        // Проверка даты и времени
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

        // Проверка длительности
        private bool ValidateDuration(int duration)
        {
            if (duration < 1 || duration > 100)
            {
                ShowErrorWithDetails("Ошибка валидации", "Некорректная длительность",
                    "Длительность мероприятия не должна превышать 1000 часов.\n\n" +
                    $"Вы указали: {duration} ч.");
                return false;
            }
            return true;
        }

        // Проверка количества участников
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

        // Проверка цены
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

        // Проверка выбора в ComboBox
        private bool ValidateComboBox(ComboBox cb, string fieldName)
        {
            if (cb.SelectedIndex == -1)
            {
                ShowErrorWithDetails("Ошибка добавления", $"Не выбран {fieldName}",
                    $"Пожалуйста, выберите {fieldName} из списка.");
                return false;
            }
            return true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка заполнения всех полей
                if (!ValidateComboBox(comboBoxCustomers, "заказчик")) return;
                if (!ValidateComboBox(comboBoxCategories, "категория")) return;
                if (!ValidateComboBox(comboBoxLocations, "место проведения")) return;
                if (!ValidateComboBox(comboBoxStaff, "сотрудник")) return;
                if (!ValidateComboBox(comboBoxServices, "дополнительная услуга")) return;

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
                    using (SqlCommand cmd = new SqlCommand("AddEvent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

                ShowErrorWithDetails("Ошибка создания мероприятия", "Не удалось создать мероприятие", errorDetails);
            }
            catch (Exception ex)
            {
                ShowErrorWithDetails("Ошибка", "Произошла ошибка при создании мероприятия",
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

