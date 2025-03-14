using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using tutu2;

namespace tutu2
{
    public partial class ReaderHistoryForm : Form
    {
        private int readerId; // ID читателя

        public ReaderHistoryForm(int readerId)
        {
            InitializeComponent();
            this.readerId = readerId;
            LoadReaderHistory();
        }

        // Загрузка истории выдачи книг для читателя
        private void LoadReaderHistory()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                var cmd = new NpgsqlCommand(
                    "SELECT Books.Title, BookLoans.LoanDate, BookLoans.ReturnDate, BookLoans.Status " +
                    "FROM BookLoans " +
                    "JOIN Books ON BookLoans.BookID = Books.BookID " +
                    "WHERE BookLoans.ReaderID = @readerId", db.GetConnection());
                cmd.Parameters.AddWithValue("readerId", readerId);

                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewHistory.DataSource = dt;

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке истории: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReaderHistoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}