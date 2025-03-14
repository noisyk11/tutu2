using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using tutu2;

namespace tutu2
{
    public partial class IssueBookForm : Form
    {
        public IssueBookForm()
        {
            InitializeComponent();
            LoadReaders();
            LoadAvailableBooks();
        }

        // Загрузка списка читателей
        private void LoadReaders()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                var cmd = new NpgsqlCommand("SELECT ReaderID, Name FROM Readers", db.GetConnection());
                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                cmbReaders.DataSource = dt;
                cmbReaders.DisplayMember = "Name";
                cmbReaders.ValueMember = "ReaderID";

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке читателей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка списка доступных книг
        private void LoadAvailableBooks()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                var cmd = new NpgsqlCommand(
                    "SELECT BookID, Title FROM Books WHERE Status = 'В наличии' AND CopiesAvailable > 0", db.GetConnection());
                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                cmbBooks.DataSource = dt;
                cmbBooks.DisplayMember = "Title";
                cmbBooks.ValueMember = "BookID";

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке книг: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик для кнопки "Выдать книгу"
        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            int readerId = (int)cmbReaders.SelectedValue;
            int bookId = (int)cmbBooks.SelectedValue;

            try
            {
                Database db = new Database();
                db.OpenConnection();

                // Проверяем лимит книг для читателя
                var cmdCheckLimit = new NpgsqlCommand(
                    "SELECT BookLimit FROM Readers WHERE ReaderID = @readerId", db.GetConnection());
                cmdCheckLimit.Parameters.AddWithValue("readerId", readerId);
                int bookLimit = Convert.ToInt32(cmdCheckLimit.ExecuteScalar());

                var cmdCheckLoans = new NpgsqlCommand(
                    "SELECT COUNT(*) FROM BookLoans WHERE ReaderID = @readerId AND Status = 'Активна'", db.GetConnection());
                cmdCheckLoans.Parameters.AddWithValue("readerId", readerId);
                int activeLoans = Convert.ToInt32(cmdCheckLoans.ExecuteScalar());

                if (activeLoans >= bookLimit)
                {
                    MessageBox.Show("Читатель достиг лимита на выдачу книг.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверяем количество доступных экземпляров книги
                var cmdCheckCopies = new NpgsqlCommand(
                    "SELECT CopiesAvailable FROM Books WHERE BookID = @bookId", db.GetConnection());
                cmdCheckCopies.Parameters.AddWithValue("bookId", bookId);
                int copiesAvailable = Convert.ToInt32(cmdCheckCopies.ExecuteScalar());

                if (copiesAvailable <= 0)
                {
                    MessageBox.Show("Нет доступных экземпляров этой книги.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Выдаем книгу
                var cmdIssueBook = new NpgsqlCommand(
                    "INSERT INTO BookLoans (BookID, ReaderID, LoanDate, Status) " +
                    "VALUES (@bookId, @readerId, @loanDate, 'Активна')", db.GetConnection());
                cmdIssueBook.Parameters.AddWithValue("bookId", bookId);
                cmdIssueBook.Parameters.AddWithValue("readerId", readerId);
                cmdIssueBook.Parameters.AddWithValue("loanDate", DateTime.Today);
                cmdIssueBook.ExecuteNonQuery();

                // Уменьшаем количество доступных экземпляров книги
                var cmdUpdateCopies = new NpgsqlCommand(
                    "UPDATE Books SET CopiesAvailable = CopiesAvailable - 1 WHERE BookID = @bookId", db.GetConnection());
                cmdUpdateCopies.Parameters.AddWithValue("bookId", bookId);
                cmdUpdateCopies.ExecuteNonQuery();

                db.CloseConnection();

                MessageBox.Show("Книга успешно выдана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выдаче книги: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IssueBookForm_Load(object sender, EventArgs e)
        {

        }
    }
}