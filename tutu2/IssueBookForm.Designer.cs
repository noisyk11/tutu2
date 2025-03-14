namespace tutu2
{
    partial class IssueBookForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox cmbReaders;
        private System.Windows.Forms.ComboBox cmbBooks;
        private System.Windows.Forms.Button btnIssueBook;

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
            this.cmbReaders = new System.Windows.Forms.ComboBox();
            this.cmbBooks = new System.Windows.Forms.ComboBox();
            this.btnIssueBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbReaders
            // 
            this.cmbReaders.FormattingEnabled = true;
            this.cmbReaders.Location = new System.Drawing.Point(15, 16);
            this.cmbReaders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbReaders.Name = "cmbReaders";
            this.cmbReaders.Size = new System.Drawing.Size(151, 21);
            this.cmbReaders.TabIndex = 0;
            // 
            // cmbBooks
            // 
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.Location = new System.Drawing.Point(15, 41);
            this.cmbBooks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(151, 21);
            this.cmbBooks.TabIndex = 1;
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.Location = new System.Drawing.Point(15, 65);
            this.btnIssueBook.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(150, 24);
            this.btnIssueBook.TabIndex = 2;
            this.btnIssueBook.Text = "Выдать книгу";
            this.btnIssueBook.UseVisualStyleBackColor = true;
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // IssueBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 106);
            this.Controls.Add(this.btnIssueBook);
            this.Controls.Add(this.cmbBooks);
            this.Controls.Add(this.cmbReaders);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "IssueBookForm";
            this.Text = "Выдача книги";
            this.Load += new System.EventHandler(this.IssueBookForm_Load);
            this.ResumeLayout(false);

        }
    }
}