namespace CMS_ScanningSystem
{
    partial class ScanningSystem
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
            this.components = new System.ComponentModel.Container();
            this.LeftContainer = new System.Windows.Forms.Panel();
            this.LeftContainerBottom = new System.Windows.Forms.Panel();
            this.btnRoom = new System.Windows.Forms.Button();
            this.RightContainer = new System.Windows.Forms.Panel();
            this.TopContainer = new System.Windows.Forms.Panel();
            this.lbRoomName = new System.Windows.Forms.Label();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.CenterContainer = new System.Windows.Forms.Panel();
            this.lbTimeInOrOut = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerSaveData = new System.Windows.Forms.Timer(this.components);
            this.LeftContainer.SuspendLayout();
            this.LeftContainerBottom.SuspendLayout();
            this.TopContainer.SuspendLayout();
            this.CenterContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftContainer
            // 
            this.LeftContainer.BackColor = System.Drawing.Color.Transparent;
            this.LeftContainer.Controls.Add(this.LeftContainerBottom);
            this.LeftContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftContainer.Location = new System.Drawing.Point(0, 0);
            this.LeftContainer.Name = "LeftContainer";
            this.LeftContainer.Size = new System.Drawing.Size(199, 900);
            this.LeftContainer.TabIndex = 0;
            // 
            // LeftContainerBottom
            // 
            this.LeftContainerBottom.Controls.Add(this.btnRoom);
            this.LeftContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LeftContainerBottom.Location = new System.Drawing.Point(0, 780);
            this.LeftContainerBottom.Name = "LeftContainerBottom";
            this.LeftContainerBottom.Size = new System.Drawing.Size(199, 120);
            this.LeftContainerBottom.TabIndex = 1;
            // 
            // btnRoom
            // 
            this.btnRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoom.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom.ForeColor = System.Drawing.Color.White;
            this.btnRoom.Location = new System.Drawing.Point(12, 14);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Size = new System.Drawing.Size(181, 94);
            this.btnRoom.TabIndex = 1;
            this.btnRoom.Text = "Change Room";
            this.btnRoom.UseVisualStyleBackColor = false;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // RightContainer
            // 
            this.RightContainer.BackColor = System.Drawing.Color.Transparent;
            this.RightContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightContainer.Location = new System.Drawing.Point(1000, 0);
            this.RightContainer.Name = "RightContainer";
            this.RightContainer.Size = new System.Drawing.Size(200, 900);
            this.RightContainer.TabIndex = 1;
            // 
            // TopContainer
            // 
            this.TopContainer.BackColor = System.Drawing.Color.Transparent;
            this.TopContainer.Controls.Add(this.lbRoomName);
            this.TopContainer.Controls.Add(this.txtScan);
            this.TopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopContainer.Location = new System.Drawing.Point(199, 0);
            this.TopContainer.Name = "TopContainer";
            this.TopContainer.Size = new System.Drawing.Size(801, 250);
            this.TopContainer.TabIndex = 2;
            // 
            // lbRoomName
            // 
            this.lbRoomName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbRoomName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoomName.Location = new System.Drawing.Point(0, 0);
            this.lbRoomName.Name = "lbRoomName";
            this.lbRoomName.Size = new System.Drawing.Size(801, 164);
            this.lbRoomName.TabIndex = 1;
            this.lbRoomName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtScan
            // 
            this.txtScan.BackColor = System.Drawing.Color.White;
            this.txtScan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtScan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtScan.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScan.ForeColor = System.Drawing.Color.White;
            this.txtScan.Location = new System.Drawing.Point(0, 191);
            this.txtScan.Name = "txtScan";
            this.txtScan.PasswordChar = '*';
            this.txtScan.Size = new System.Drawing.Size(801, 59);
            this.txtScan.TabIndex = 0;
            this.txtScan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtScan.TextChanged += new System.EventHandler(this.txtScan_TextChanged);
            // 
            // CenterContainer
            // 
            this.CenterContainer.BackColor = System.Drawing.Color.Transparent;
            this.CenterContainer.Controls.Add(this.lbTimeInOrOut);
            this.CenterContainer.Controls.Add(this.lbTime);
            this.CenterContainer.Controls.Add(this.lbName);
            this.CenterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterContainer.Location = new System.Drawing.Point(199, 250);
            this.CenterContainer.Name = "CenterContainer";
            this.CenterContainer.Size = new System.Drawing.Size(801, 650);
            this.CenterContainer.TabIndex = 3;
            // 
            // lbTimeInOrOut
            // 
            this.lbTimeInOrOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTimeInOrOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTimeInOrOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeInOrOut.Location = new System.Drawing.Point(0, 229);
            this.lbTimeInOrOut.Name = "lbTimeInOrOut";
            this.lbTimeInOrOut.Size = new System.Drawing.Size(801, 184);
            this.lbTimeInOrOut.TabIndex = 2;
            this.lbTimeInOrOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTimeInOrOut.Visible = false;
            // 
            // lbTime
            // 
            this.lbTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(0, 413);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(801, 237);
            this.lbTime.TabIndex = 1;
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTime.Visible = false;
            // 
            // lbName
            // 
            this.lbName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(0, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(801, 229);
            this.lbName.TabIndex = 0;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerSaveData
            // 
            this.timerSaveData.Tick += new System.EventHandler(this.timerSaveData_Tick);
            // 
            // ScanningSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 900);
            this.Controls.Add(this.CenterContainer);
            this.Controls.Add(this.TopContainer);
            this.Controls.Add(this.RightContainer);
            this.Controls.Add(this.LeftContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScanningSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScanningSystem_Load);
            this.LeftContainer.ResumeLayout(false);
            this.LeftContainerBottom.ResumeLayout(false);
            this.TopContainer.ResumeLayout(false);
            this.TopContainer.PerformLayout();
            this.CenterContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftContainer;
        private System.Windows.Forms.Panel RightContainer;
        private System.Windows.Forms.Panel TopContainer;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.Label lbRoomName;
        private System.Windows.Forms.Panel CenterContainer;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Panel LeftContainerBottom;
        private System.Windows.Forms.Button btnRoom;
        private System.Windows.Forms.Label lbTimeInOrOut;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timerSaveData;
    }
}

