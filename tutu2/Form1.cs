using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using tutu2;

namespace tutu2
{
    public partial class Form1 : Form
    {
        private string userRole; // Роль пользователя
        private int readerId; // ID читателя (если роль "Читатель")

        public Form1(string role, int readerId = -1)
        {
            InitializeComponent();
            this.userRole = role;
            this.readerId = readerId;
            SetAccessLevels(); // Настройка уровней доступа
        }

        // Установка уровней доступа в зависимости от роли
        private void SetAccessLevels()
        {
            if (userRole == "Читатель")
            {
                btnAddBook.Visible = false;
                btnManageReaders.Visible = false;
                btnReturnBook.Visible = true;
                btnSearchBooks.Location = new System.Drawing.Point(20, 80); // Сдвигаем кнопку поиска
            }
            else if (userRole == "Библиотекарь")
            {
                btnManageReaders.Visible = false;
                btnReturnBook.Visible = false;
            }
            else if (userRole == "Администратор")
            {
                btnReturnBook.Visible = false;
            }
        }

        // Обработчик для кнопки "Добавить книгу"
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Form2 addBookForm = new Form2();
            addBookForm.ShowDialog();
            LoadBooks(); // Обновляем список книг
        }

        // Обработчик для кнопки "Поиск книг"
        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            Form3 searchBooksForm = new Form3();
            searchBooksForm.ShowDialog();
        }

        // Обработчик для кнопки "Управление читателями"
        private void btnManageReaders_Click(object sender, EventArgs e)
        {
            ManageReadersForm manageReadersForm = new ManageReadersForm();
            manageReadersForm.ShowDialog();
        }

        // Обработчик для кнопки "Вернуть книгу"
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            ReturnBookForm returnBookForm = new ReturnBookForm(readerId);
            returnBookForm.ShowDialog();

            if (returnBookForm.BookReturned)
            {
                LoadBooks(); // Обновляем список книг после возврата
            }
        }

        // Метод для загрузки списка книг из базы данных
        private void LoadBooks()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                var cmd = new NpgsqlCommand("SELECT * FROM Books", db.GetConnection());
                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                // Отладочное сообщение
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Таблица Books пустая или данные не загружены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dataGridViewBooks.DataSource = dt;

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке книг: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик двойного клика по строке в DataGridView
        private void dataGridViewBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int bookId = Convert.ToInt32(dataGridViewBooks.Rows[e.RowIndex].Cells["BookID"].Value);
                EditBookForm editBookForm = new EditBookForm(bookId);
                editBookForm.ShowDialog();
                LoadBooks(); // Обновляем список книг
            }
        }

        // Обработчик загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Настройка DataGridView
            dataGridViewBooks.AutoGenerateColumns = true;
            dataGridViewBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBooks.ReadOnly = true;

            // Подключаем обработчики событий для кнопок
            btnAddBook.Click += btnAddBook_Click;
            btnSearchBooks.Click += btnSearchBooks_Click;
            btnManageReaders.Click += btnManageReaders_Click;
            btnReturnBook.Click += btnReturnBook_Click;

            // Загружаем список книг при запуске формы
            LoadBooks();
        }
    }
}