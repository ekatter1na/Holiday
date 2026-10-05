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
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Input_Click(object sender, EventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Text.Trim();

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                string errorMessage = "Не заполнены обязательные поля.";
                string errorDetails = "Для входа в систему необходимо ввести логин и пароль.\n\n" +
                                      "Поля, требующие заполнения:\n" +
                                      "- Логин\n" +
                                      "- Пароль\n\n" +
                                      "Пожалуйста, заполните все поля и повторите попытку.";

                ShowErrorWithDetails("Ошибка ввода", errorMessage, errorDetails);
                return;
            }

            string connectionString = "Data Source=LAPTOP-NDRNKPSE;Initial Catalog=Holiday;Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Проверяем, существует ли пользователь с таким логином
                    string checkLoginQuery = "SELECT COUNT(*) FROM Staff WHERE Login = @login";
                    int userExists;

                    using (SqlCommand checkCmd = new SqlCommand(checkLoginQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@login", login);
                        userExists = (int)checkCmd.ExecuteScalar();
                    }

                    if (userExists == 0)
                    {
                        string errorMessage = "Пользователь с таким логином не найден.";
                        string errorDetails = "Введенный логин '" + login + "' не зарегистрирован в системе.\n\n" +
                                              "Возможные причины:\n" +
                                              "- Логин введен с ошибкой (проверьте раскладку клавиатуры)\n" +
                                              "- Пользователь не имеет учетной записи\n" +
                                              "- Учетная запись была удалена\n\n" +
                                              "Рекомендации:\n" +
                                              "- Проверьте правильность написания логина\n" +
                                              "- Обратитесь к администратору для регистрации\n" +
                                              "- Попробуйте восстановить доступ через администратора";

                        ShowErrorWithDetails("Ошибка авторизации", errorMessage, errorDetails);
                        return;
                    }

                    // Проверяем, существует ли пользователь с таким паролем
                    string checkPasswordQuery = "SELECT COUNT(*) FROM Staff WHERE Login = @login AND Password = @password";
                    int passwordMatch;

                    using (SqlCommand checkPassCmd = new SqlCommand(checkPasswordQuery, conn))
                    {
                        checkPassCmd.Parameters.AddWithValue("@login", login);
                        checkPassCmd.Parameters.AddWithValue("@password", password);
                        passwordMatch = (int)checkPassCmd.ExecuteScalar();
                    }

                    if (passwordMatch == 0)
                    {
                        string errorMessage = "Неверный пароль.";
                        string errorDetails = "Введенный пароль не соответствует учетной записи.\n\n" +
                                              "Возможные причины:\n" +
                                              "- Пароль введен с ошибкой\n" +
                                              "- Неправильная раскладка клавиатуры (русский/английский)\n" +
                                              "- Учитывается регистр символов\n" +
                                              "- Пароль был изменен\n\n" +
                                              "Рекомендации:\n" +
                                              "- Проверьте раскладку клавиатуры\n" +
                                              "- Убедитесь, что Caps Lock выключен\n" +
                                              "- Попробуйте ввести пароль еще раз\n" +
                                              "- Если забыли пароль, обратитесь к администратору";

                        ShowErrorWithDetails("Ошибка авторизации", errorMessage, errorDetails);
                        return;
                    }

                    //  Проверяем роль пользователя
                    string checkRoleQuery = "SELECT Role FROM Staff WHERE Login = @login AND Password = @password";
                    string userRole = "";

                    using (SqlCommand roleCmd = new SqlCommand(checkRoleQuery, conn))
                    {
                        roleCmd.Parameters.AddWithValue("@login", login);
                        roleCmd.Parameters.AddWithValue("@password", password);
                        userRole = roleCmd.ExecuteScalar()?.ToString() ?? "";
                    }

                    if (userRole != "Администратор")
                    {
                        string errorMessage = "У вас нет прав администратора.";
                        string errorDetails = "Ваша роль в системе: " + userRole + "\n\n" +
                                              "Для входа в приложение администратора требуется роль 'Администратор'.\n\n" +
                                              "Возможные причины:\n" +
                                              "- Вы вошли как обычный сотрудник\n" +
                                              "- Учетная запись не имеет прав администратора\n" +
                                              "- Роль была изменена\n\n" +
                                              "Рекомендации:\n" +
                                              "- Используйте учетную запись администратора\n" +
                                              "- Обратитесь к администратору для повышения прав\n" +
                                              "- Проверьте правильность введенных данных";

                        ShowErrorWithDetails("Доступ запрещен", errorMessage, errorDetails);
                        return;
                    }

                    // авторизуем администратора
                    string query = @"
                        SELECT ID_Employee, Surname, First_Name, Last_Name, Role 
                        FROM Staff 
                        WHERE Login = @login AND Password = @password AND Role = 'Администратор'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int employeeId = reader.GetInt32(0);
                                string surname = reader.GetString(1);
                                string firstName = reader.GetString(2);
                                string lastName = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                string role = reader.GetString(4);

                                string fullName = $"{surname} {firstName} {lastName}".Trim();

                                MainForm mainForm = new MainForm();
                                mainForm.Show();
                                this.Hide();
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                string errorMessage = "Ошибка подключения к базе данных.";
                string errorDetails = $"Код ошибки: {sqlEx.Number}\n" +
                                      $"Сообщение: {sqlEx.Message}\n\n" +
                                      "Возможные причины:\n" +
                                      "- Отсутствует подключение к серверу\n" +
                                      "- Неверное имя сервера в строке подключения\n" +
                                      "- База данных недоступна\n" +
                                      "- Проблемы с сетевым подключением\n\n" +
                                      "Рекомендации:\n" +
                                      "- Проверьте подключение к сети\n" +
                                      "- Убедитесь, что SQL Server запущен\n" +
                                      "- Обратитесь к системному администратору";

                ShowErrorWithDetails("Ошибка базы данных", errorMessage, errorDetails);
            }
            catch (Exception ex)
            {
                string errorMessage = "Непредвиденная ошибка при авторизации.";
                string errorDetails = $"Тип ошибки: {ex.GetType().Name}\n" +
                                      $"Сообщение: {ex.Message}\n" +
                                      $"Стек вызовов: {ex.StackTrace}\n\n" +
                                      "Рекомендации:\n" +
                                      "- Перезапустите приложение\n" +
                                      "- Обратитесь в службу поддержки";

                ShowErrorWithDetails("Системная ошибка", errorMessage, errorDetails);
            }

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
            btnDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            btnDetails.ForeColor = Color.Black;
            btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            btnDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.Cursor = Cursors.Hand;

            Button btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Location = new Point(330, 85);
            btnClose.Size = new Size(100, 30);
            btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            btnClose.ForeColor = Color.Black;
            btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
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