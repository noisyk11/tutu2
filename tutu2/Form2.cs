using System;
using System.Windows.Forms;
using Npgsql;

namespace tutu2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Добавление книги в базу данных
            try
            {
                Database db = new Database();
                db.OpenConnection();
                var cmd = new NpgsqlCommand(
                    "INSERT INTO Books (Title, Author, YearPublished, Genre, CopiesAvailable, Status) " +
                    "VALUES (@title, @author, @year, @genre, @copies, @status)", db.GetConnection());

                cmd.Parameters.AddWithValue("title", txtTitle.Text);
                cmd.Parameters.AddWithValue("author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("year", int.Parse(txtYear.Text));
                cmd.Parameters.AddWithValue("genre", txtGenre.Text);
                cmd.Parameters.AddWithValue("copies", int.Parse(txtCopies.Text));
                cmd.Parameters.AddWithValue("status", cmbStatus.SelectedItem.ToString());

                cmd.ExecuteNonQuery();
                db.CloseConnection();

                MessageBox.Show("Книга успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Инициализация формы добавления книг
            txtTitle = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200 };
            txtAuthor = new TextBox { Location = new System.Drawing.Point(120, 50), Width = 200 };
            txtYear = new TextBox { Location = new System.Drawing.Point(120, 80), Width = 200 };
            txtGenre = new TextBox { Location = new System.Drawing.Point(120, 110), Width = 200 };
            txtCopies = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200 };
            cmbStatus = new ComboBox { Location = new System.Drawing.Point(120, 170), Width = 200 };
            cmbStatus.Items.AddRange(new string[] { "В наличии", "Выдана", "Утеряна" });
            btnAdd = new Button { Text = "Добавить", Location = new System.Drawing.Point(120, 200) };

            btnAdd.Click += btnAdd_Click;

            this.Controls.AddRange(new Control[] {
                new Label { Text = "Название:", Location = new System.Drawing.Point(20, 20) },
                txtTitle,
                new Label { Text = "Автор:", Location = new System.Drawing.Point(20, 50) },
                txtAuthor,
                new Label { Text = "Год издания:", Location = new System.Drawing.Point(20, 80) },
                txtYear,
                new Label { Text = "Жанр:", Location = new System.Drawing.Point(20, 110) },
                txtGenre,
                new Label { Text = "Количество экземпляров:", Location = new System.Drawing.Point(20, 140) },
                txtCopies,
                new Label { Text = "Статус:", Location = new System.Drawing.Point(20, 170) },
                cmbStatus,
                btnAdd
            });
        }

        private TextBox txtTitle, txtAuthor, txtYear, txtGenre, txtCopies;
        private ComboBox cmbStatus;
        private Button btnAdd;
    }
}