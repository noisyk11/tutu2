namespace tutu2
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.RadioButton rbAdminLibrarian;
        private System.Windows.Forms.RadioButton rbReader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblReaderID;
        private System.Windows.Forms.TextBox txtReaderID;
        private System.Windows.Forms.Button btnLogin;

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
            this.rbAdminLibrarian = new System.Windows.Forms.RadioButton();
            this.rbReader = new System.Windows.Forms.RadioButton();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblReaderID = new System.Windows.Forms.Label();
            this.txtReaderID = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbAdminLibrarian
            // 
            this.rbAdminLibrarian.AutoSize = true;
            this.rbAdminLibrarian.Checked = true;
            this.rbAdminLibrarian.Location = new System.Drawing.Point(15, 16);
            this.rbAdminLibrarian.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbAdminLibrarian.Name = "rbAdminLibrarian";
            this.rbAdminLibrarian.Size = new System.Drawing.Size(181, 17);
            this.rbAdminLibrarian.TabIndex = 0;
            this.rbAdminLibrarian.TabStop = true;
            this.rbAdminLibrarian.Text = "Администратор/Библиотекарь";
            this.rbAdminLibrarian.UseVisualStyleBackColor = true;
            this.rbAdminLibrarian.CheckedChanged += new System.EventHandler(this.rbAdminLibrarian_CheckedChanged);
            // 
            // rbReader
            // 
            this.rbReader.AutoSize = true;
            this.rbReader.Location = new System.Drawing.Point(15, 41);
            this.rbReader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbReader.Name = "rbReader";
            this.rbReader.Size = new System.Drawing.Size(73, 17);
            this.rbReader.TabIndex = 1;
            this.rbReader.Text = "Читатель";
            this.rbReader.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(15, 65);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(41, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Логин:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(15, 81);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(151, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 106);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(15, 122);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(151, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblReaderID
            // 
            this.lblReaderID.AutoSize = true;
            this.lblReaderID.Location = new System.Drawing.Point(15, 65);
            this.lblReaderID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReaderID.Name = "lblReaderID";
            this.lblReaderID.Size = new System.Drawing.Size(56, 13);
            this.lblReaderID.TabIndex = 6;
            this.lblReaderID.Text = "ReaderID:";
            this.lblReaderID.Visible = false;
            // 
            // txtReaderID
            // 
            this.txtReaderID.Location = new System.Drawing.Point(15, 81);
            this.txtReaderID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReaderID.Name = "txtReaderID";
            this.txtReaderID.Size = new System.Drawing.Size(151, 20);
            this.txtReaderID.TabIndex = 7;
            this.txtReaderID.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(15, 146);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 24);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 187);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtReaderID);
            this.Controls.Add(this.lblReaderID);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.rbReader);
            this.Controls.Add(this.rbAdminLibrarian);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginForm";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}