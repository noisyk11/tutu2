using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql;
using tutu2;

namespace tutu2
{
    public partial class ManageReadersForm : Form
    {
        public ManageReadersForm()
        {
            InitializeComponent();
            LoadReaders();
        }

        // Загрузка списка читателей
        private void LoadReaders()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                var cmd = new NpgsqlCommand("SELECT * FROM Readers", db.GetConnection());
                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewReaders.DataSource = dt;

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке читателей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Добавление нового читателя
        private void btnAddReader_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                var cmd = new NpgsqlCommand(
                    "INSERT INTO Readers (Name, ContactInfo, BookLimit) VALUES (@name, @contact, @limit)", db.GetConnection());
                cmd.Parameters.AddWithValue("name", txtName.Text);
                cmd.Parameters.AddWithValue("contact", txtContactInfo.Text);
                cmd.Parameters.AddWithValue("limit", int.Parse(txtBookLimit.Text));

                cmd.ExecuteNonQuery();
                db.CloseConnection();

                MessageBox.Show("Читатель успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReaders(); // Обновляем список читателей
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении читателя: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Просмотр истории выдачи книг
        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.SelectedRows.Count > 0)
            {
                int readerId = Convert.ToInt32(dataGridViewReaders.SelectedRows[0].Cells["ReaderID"].Value);

                // Открываем форму для просмотра истории выдачи книг
                ReaderHistoryForm historyForm = new ReaderHistoryForm(readerId);
                historyForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите читателя для просмотра истории.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Настройка лимита книг
        private void btnSetLimit_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.SelectedRows.Count > 0)
            {
                int readerId = Convert.ToInt32(dataGridViewReaders.SelectedRows[0].Cells["ReaderID"].Value);
                int newLimit = int.Parse(txtNewLimit.Text);

                try
                {
                    Database db = new Database();
                    db.OpenConnection();

                    var cmd = new NpgsqlCommand(
                        "UPDATE Readers SET BookLimit = @limit WHERE ReaderID = @id", db.GetConnection());
                    cmd.Parameters.AddWithValue("limit", newLimit);
                    cmd.Parameters.AddWithValue("id", readerId);

                    cmd.ExecuteNonQuery();
                    db.CloseConnection();

                    MessageBox.Show("Лимит успешно обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReaders(); // Обновляем список читателей
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении лимита: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите читателя для настройки лимита.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Выдача книги читателю
        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.SelectedRows.Count > 0)
            {
                // Открываем форму выдачи книги
                IssueBookForm issueBookForm = new IssueBookForm();
                issueBookForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите читателя для выдачи книги.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ManageReadersForm_Load(object sender, EventArgs e)
        {

        }
    }
}