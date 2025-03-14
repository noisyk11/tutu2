using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace tutu2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Поиск и фильтрация книг
            try
            {
                Database db = new Database();
                db.OpenConnection();
                var cmd = new NpgsqlCommand(
                    $"SELECT * FROM Books WHERE {cmbFilter.SelectedItem.ToString()} LIKE @search", db.GetConnection());
                cmd.Parameters.AddWithValue("search", $"%{txtSearch.Text}%");

                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                dgvBooks.DataSource = dt;
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Инициализация формы поиска книг
            txtSearch = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200 };
            cmbFilter = new ComboBox { Location = new System.Drawing.Point(120, 50), Width = 200 };
            cmbFilter.Items.AddRange(new string[] { "Title", "Author", "Genre", "Status" });
            dgvBooks = new DataGridView { Location = new System.Drawing.Point(20, 80), Width = 400, Height = 200 };

            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;

            this.Controls.AddRange(new Control[] {
                new Label { Text = "Поиск:", Location = new System.Drawing.Point(20, 20) },
                txtSearch,
                new Label { Text = "Фильтр:", Location = new System.Drawing.Point(20, 50) },
                cmbFilter,
                dgvBooks
            });
        }

        private TextBox txtSearch;
        private ComboBox cmbFilter;
        private DataGridView dgvBooks;
    }
}