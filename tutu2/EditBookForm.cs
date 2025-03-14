using System;
using System.Windows.Forms;
using Npgsql;
using tutu2;

namespace tutu2
{
    public partial class EditBookForm : Form
    {
        private int bookId; // ID книги для редактирования

        public EditBookForm(int bookId)
        {
            InitializeComponent();
            this.bookId = bookId;
            LoadBookData();
        }

        // Загрузка данных о книге по её ID
        private void LoadBookData()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                var cmd = new NpgsqlCommand("SELECT * FROM Books WHERE BookID = @id", db.GetConnection());
                cmd.Parameters.AddWithValue("id", bookId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTitle.Text = reader["Title"].ToString();
                        txtAuthor.Text = reader["Author"].ToString();
                        txtYear.Text = reader["YearPublished"].ToString();
                        txtGenre.Text = reader["Genre"].ToString();
                        txtCopies.Text = reader["CopiesAvailable"].ToString();
                        cmbStatus.SelectedItem = reader["Status"].ToString();
                    }
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранение изменений
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                var cmd = new NpgsqlCommand(
                    "UPDATE Books SET Title = @title, Author = @author, YearPublished = @year, " +
                    "Genre = @genre, CopiesAvailable = @copies, Status = @status WHERE BookID = @id", db.GetConnection());

                cmd.Parameters.AddWithValue("title", txtTitle.Text);
                cmd.Parameters.AddWithValue("author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("year", int.Parse(txtYear.Text));
                cmd.Parameters.AddWithValue("genre", txtGenre.Text);
                cmd.Parameters.AddWithValue("copies", int.Parse(txtCopies.Text));
                cmd.Parameters.AddWithValue("status", cmbStatus.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("id", bookId);

                int rowsAffected = cmd.ExecuteNonQuery();
                db.CloseConnection();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось обновить данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditBookForm_Load(object sender, EventArgs e)
        {

        }
    }
}