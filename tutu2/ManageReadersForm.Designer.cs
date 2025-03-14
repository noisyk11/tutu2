namespace tutu2
{
    partial class ManageReadersForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtContactInfo;
        private System.Windows.Forms.TextBox txtBookLimit;
        private System.Windows.Forms.Button btnAddReader;
        private System.Windows.Forms.DataGridView dataGridViewReaders;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.TextBox txtNewLimit;
        private System.Windows.Forms.Button btnSetLimit;
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtContactInfo = new System.Windows.Forms.TextBox();
            this.txtBookLimit = new System.Windows.Forms.TextBox();
            this.btnAddReader = new System.Windows.Forms.Button();
            this.dataGridViewReaders = new System.Windows.Forms.DataGridView();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.txtNewLimit = new System.Windows.Forms.TextBox();
            this.btnSetLimit = new System.Windows.Forms.Button();
            this.btnIssueBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 16);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtContactInfo
            // 
            this.txtContactInfo.Location = new System.Drawing.Point(15, 41);
            this.txtContactInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new System.Drawing.Size(151, 20);
            this.txtContactInfo.TabIndex = 1;
            // 
            // txtBookLimit
            // 
            this.txtBookLimit.Location = new System.Drawing.Point(15, 65);
            this.txtBookLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBookLimit.Name = "txtBookLimit";
            this.txtBookLimit.Size = new System.Drawing.Size(151, 20);
            this.txtBookLimit.TabIndex = 2;
            // 
            // btnAddReader
            // 
            this.btnAddReader.Location = new System.Drawing.Point(15, 89);
            this.btnAddReader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddReader.Name = "btnAddReader";
            this.btnAddReader.Size = new System.Drawing.Size(150, 24);
            this.btnAddReader.TabIndex = 3;
            this.btnAddReader.Text = "Добавить читателя";
            this.btnAddReader.UseVisualStyleBackColor = true;
            this.btnAddReader.Click += new System.EventHandler(this.btnAddReader_Click);
            // 
            // dataGridViewReaders
            // 
            this.dataGridViewReaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReaders.Location = new System.Drawing.Point(15, 122);
            this.dataGridViewReaders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewReaders.Name = "dataGridViewReaders";
            this.dataGridViewReaders.ReadOnly = true;
            this.dataGridViewReaders.Size = new System.Drawing.Size(450, 162);
            this.dataGridViewReaders.TabIndex = 4;
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Location = new System.Drawing.Point(15, 292);
            this.btnViewHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(150, 24);
            this.btnViewHistory.TabIndex = 5;
            this.btnViewHistory.Text = "Просмотр истории";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // txtNewLimit
            // 
            this.txtNewLimit.Location = new System.Drawing.Point(180, 292);
            this.txtNewLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNewLimit.Name = "txtNewLimit";
            this.txtNewLimit.Size = new System.Drawing.Size(76, 20);
            this.txtNewLimit.TabIndex = 6;
            // 
            // btnSetLimit
            // 
            this.btnSetLimit.Location = new System.Drawing.Point(262, 292);
            this.btnSetLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSetLimit.Name = "btnSetLimit";
            this.btnSetLimit.Size = new System.Drawing.Size(112, 24);
            this.btnSetLimit.TabIndex = 7;
            this.btnSetLimit.Text = "Установить лимит";
            this.btnSetLimit.UseVisualStyleBackColor = true;
            this.btnSetLimit.Click += new System.EventHandler(this.btnSetLimit_Click);
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.Location = new System.Drawing.Point(15, 325);
            this.btnIssueBook.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(150, 24);
            this.btnIssueBook.TabIndex = 8;
            this.btnIssueBook.Text = "Выдать книгу";
            this.btnIssueBook.UseVisualStyleBackColor = true;
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // ManageReadersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 366);
            this.Controls.Add(this.btnIssueBook);
            this.Controls.Add(this.btnSetLimit);
            this.Controls.Add(this.txtNewLimit);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(this.dataGridViewReaders);
            this.Controls.Add(this.btnAddReader);
            this.Controls.Add(this.txtBookLimit);
            this.Controls.Add(this.txtContactInfo);
            this.Controls.Add(this.txtName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManageReadersForm";
            this.Text = "Управление читателями";
            this.Load += new System.EventHandler(this.ManageReadersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}