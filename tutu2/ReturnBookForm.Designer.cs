namespace tutu2
{
    partial class ReturnBookForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewLoans;
        private System.Windows.Forms.Button btnReturnBook;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewLoans = new System.Windows.Forms.DataGridView();
            this.btnReturnBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoans)).BeginInit();
            this.SuspendLayout();

            // dataGridViewLoans
            this.dataGridViewLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoans.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewLoans.Name = "dataGridViewLoans";
            this.dataGridViewLoans.Size = new System.Drawing.Size(600, 300);
            this.dataGridViewLoans.TabIndex = 0;

            // btnReturnBook
            this.btnReturnBook.Location = new System.Drawing.Point(20, 340);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(150, 30);
            this.btnReturnBook.TabIndex = 1;
            this.btnReturnBook.Text = "Вернуть книгу";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);

            // ReturnBookForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.dataGridViewLoans);
            this.Name = "ReturnBookForm";
            this.Text = "Возврат книги";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoans)).EndInit();
            this.ResumeLayout(false);
        }
    }
}