using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using tutu2;

namespace tutu2
{
    public partial class ReturnBookForm : Form
    {
        private int readerId; // ID читателя
        public bool BookReturned { get; private set; } = false; // Флаг, указывающий, что книга была возвращена

        public ReturnBookForm(int readerId)
        {
            InitializeComponent();
            this.readerId = readerId;
            LoadLoans();
        }

        // Загрузка списка выданных книг для читателя
        private void LoadLoans()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                // SQL-запрос для получения выданных книг
                var cmd = new NpgsqlCommand(
                    "SELECT BookLoans.LoanID, BookLoans.BookID, Books.Title, BookLoans.LoanDate " +
                    "FROM BookLoans " +
                    "JOIN Books ON BookLoans.BookID = Books.BookID " +
                    "WHERE BookLoans.ReaderID = @readerId AND BookLoans.Status = 'Активна'", db.GetConnection());
                cmd.Parameters.AddWithValue("readerId", readerId);

                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                // Отладочное сообщение
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Нет активных выдач для этого читателя.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dataGridViewLoans.DataSource = dt;

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке выданных книг: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик для кнопки "Вернуть книгу"
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewLoans.SelectedRows.Count > 0)
            {
                int loanId = Convert.ToInt32(dataGridViewLoans.SelectedRows[0].Cells["LoanID"].Value);
                int bookId = Convert.ToInt32(dataGridViewLoans.SelectedRows[0].Cells["BookID"].Value);

                try
                {
                    Database db = new Database();
                    db.OpenConnection();

                    // Обновляем статус выдачи на "Возвращена"
                    var cmdReturnBook = new NpgsqlCommand(
                        "UPDATE BookLoans SET ReturnDate = @returnDate, Status = 'Возвращена' WHERE LoanID = @loanId", db.GetConnection());
                    cmdReturnBook.Parameters.AddWithValue("returnDate", DateTime.Today);
                    cmdReturnBook.Parameters.AddWithValue("loanId", loanId);
                    cmdReturnBook.ExecuteNonQuery();

                    // Увеличиваем количество доступных экземпляров книги и обновляем статус
                    var cmdUpdateCopies = new NpgsqlCommand(
                        "UPDATE Books SET CopiesAvailable = CopiesAvailable + 1, Status = 'В наличии' WHERE BookID = @bookId", db.GetConnection());
                    cmdUpdateCopies.Parameters.AddWithValue("bookId", bookId);
                    cmdUpdateCopies.ExecuteNonQuery();

                    db.CloseConnection();

                    BookReturned = true; // Устанавливаем флаг, что книга была возвращена

                    MessageBox.Show("Книга успешно возвращена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLoans(); // Обновляем список выданных книг
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при возврате книги: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для возврата.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReturnBookForm_Load(object sender, EventArgs e)
        {

        }
    }
}