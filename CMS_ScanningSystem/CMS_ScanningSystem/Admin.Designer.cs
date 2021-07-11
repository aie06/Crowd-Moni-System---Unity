namespace CMS_ScanningSystem
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.AdminContainer = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDatabaseSetup = new System.Windows.Forms.Button();
            this.btnProgramClose = new System.Windows.Forms.Button();
            this.AdminContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(63, 62);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(253, 44);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Change Room";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // AdminContainer
            // 
            this.AdminContainer.BackColor = System.Drawing.Color.White;
            this.AdminContainer.Controls.Add(this.groupBox1);
            this.AdminContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminContainer.Location = new System.Drawing.Point(0, 0);
            this.AdminContainer.Margin = new System.Windows.Forms.Padding(2);
            this.AdminContainer.Name = "AdminContainer";
            this.AdminContainer.Size = new System.Drawing.Size(450, 415);
            this.AdminContainer.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnDatabaseSetup);
            this.groupBox1.Controls.Add(this.btnProgramClose);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 371);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(63, 277);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(253, 44);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDatabaseSetup
            // 
            this.btnDatabaseSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnDatabaseSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatabaseSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseSetup.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatabaseSetup.ForeColor = System.Drawing.Color.White;
            this.btnDatabaseSetup.Location = new System.Drawing.Point(63, 134);
            this.btnDatabaseSetup.Margin = new System.Windows.Forms.Padding(2);
            this.btnDatabaseSetup.Name = "btnDatabaseSetup";
            this.btnDatabaseSetup.Size = new System.Drawing.Size(253, 44);
            this.btnDatabaseSetup.TabIndex = 8;
            this.btnDatabaseSetup.Text = "Database Setup";
            this.btnDatabaseSetup.UseVisualStyleBackColor = false;
            this.btnDatabaseSetup.Click += new System.EventHandler(this.btnDatabaseSetup_Click);
            // 
            // btnProgramClose
            // 
            this.btnProgramClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnProgramClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProgramClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgramClose.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramClose.ForeColor = System.Drawing.Color.White;
            this.btnProgramClose.Location = new System.Drawing.Point(63, 205);
            this.btnProgramClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnProgramClose.Name = "btnProgramClose";
            this.btnProgramClose.Size = new System.Drawing.Size(253, 44);
            this.btnProgramClose.TabIndex = 7;
            this.btnProgramClose.Text = "Close Program";
            this.btnProgramClose.UseVisualStyleBackColor = false;
            this.btnProgramClose.Click += new System.EventHandler(this.btnProgramClose_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 415);
            this.Controls.Add(this.AdminContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.AdminContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel AdminContainer;
        private System.Windows.Forms.Button btnProgramClose;
        private System.Windows.Forms.Button btnDatabaseSetup;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}