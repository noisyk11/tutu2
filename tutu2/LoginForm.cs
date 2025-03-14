using System;
using System.Windows.Forms;
using Npgsql;
using tutu2;

namespace tutu2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            SetLoginMode(); // Настройка формы в зависимости от выбранного режима
        }

        // Обработчик для переключателя
        private void rbAdminLibrarian_CheckedChanged(object sender, EventArgs e)
        {
            SetLoginMode();
        }

        // Настройка формы в зависимости от выбранного режима
        private void SetLoginMode()
        {
            if (rbAdminLibrarian.Checked)
            {
                // Режим администратора/библиотекаря
                lblUsername.Visible = true;
                txtUsername.Visible = true;
                lblPassword.Visible = true;
                txtPassword.Visible = true;
                lblReaderID.Visible = false;
                txtReaderID.Visible = false;
            }
            else
            {
                // Режим читателя
                lblUsername.Visible = false;
                txtUsername.Visible = false;
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblReaderID.Visible = true;
                txtReaderID.Visible = true;
            }
        }

        // Обработчик для кнопки "Войти"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (rbAdminLibrarian.Checked)
            {
                // Авторизация администратора/библиотекаря
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                try
                {
                    Database db = new Database();
                    db.OpenConnection();

                    // Проверяем логин и пароль в таблице Users
                    var cmd = new NpgsqlCommand(
                        "SELECT Role FROM Users WHERE Username = @username AND PasswordHash = @password", db.GetConnection());
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password); // В реальном приложении используйте хэширование паролей!

                    var role = cmd.ExecuteScalar()?.ToString();

                    db.CloseConnection();

                    if (role != null)
                    {
                        // Открываем главную форму с учетом роли
                        Form1 mainForm = new Form1(role);
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при авторизации: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Авторизация читателя
                if (int.TryParse(txtReaderID.Text, out int readerId))
                {
                    try
                    {
                        Database db = new Database();
                        db.OpenConnection();

                        // Проверяем, существует ли читатель с таким ReaderID
                        var cmd = new NpgsqlCommand(
                            "SELECT COUNT(*) FROM Readers WHERE ReaderID = @readerId", db.GetConnection());
                        cmd.Parameters.AddWithValue("readerId", readerId);

                        int readerExists = Convert.ToInt32(cmd.ExecuteScalar());

                        db.CloseConnection();

                        if (readerExists > 0)
                        {
                            // Открываем главную форму для читателя
                            Form1 mainForm = new Form1("Читатель", readerId);
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Читатель с таким ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при авторизации: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректный ReaderID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}