namespace MiniJobzAdminSite
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.NavBar = new System.Windows.Forms.Panel();
            this.PicBoxPanel = new System.Windows.Forms.Panel();
            this.closeBox = new System.Windows.Forms.PictureBox();
            this.UserBox = new System.Windows.Forms.PictureBox();
            this.EmailBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.ReportsBtn = new System.Windows.Forms.Button();
            this.StatistcBtn = new System.Windows.Forms.Button();
            this.UsersBtn = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.UsenameLabel = new System.Windows.Forms.Label();
            this.NavBar.SuspendLayout();
            this.PicBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // NavBar
            // 
            this.NavBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.NavBar.Controls.Add(this.UsenameLabel);
            this.NavBar.Controls.Add(this.UserBox);
            this.NavBar.Controls.Add(this.EmailBtn);
            this.NavBar.Controls.Add(this.SettingsBtn);
            this.NavBar.Controls.Add(this.ReportsBtn);
            this.NavBar.Controls.Add(this.StatistcBtn);
            this.NavBar.Controls.Add(this.UsersBtn);
            this.NavBar.Controls.Add(this.HomeBtn);
            this.NavBar.Controls.Add(this.PicBoxPanel);
            this.NavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavBar.Location = new System.Drawing.Point(0, 0);
            this.NavBar.Name = "NavBar";
            this.NavBar.Size = new System.Drawing.Size(186, 577);
            this.NavBar.TabIndex = 0;
            // 
            // PicBoxPanel
            // 
            this.PicBoxPanel.Controls.Add(this.Logo);
            this.PicBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PicBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.PicBoxPanel.Name = "PicBoxPanel";
            this.PicBoxPanel.Size = new System.Drawing.Size(186, 144);
            this.PicBoxPanel.TabIndex = 1;
            // 
            // closeBox
            // 
            this.closeBox.Image = global::MiniJobzAdminSite.Properties.Resources.close_x;
            this.closeBox.Location = new System.Drawing.Point(906, 12);
            this.closeBox.Name = "closeBox";
            this.closeBox.Size = new System.Drawing.Size(33, 31);
            this.closeBox.TabIndex = 1;
            this.closeBox.TabStop = false;
            this.closeBox.Click += new System.EventHandler(this.closeBox_Click);
            // 
            // UserBox
            // 
            this.UserBox.Image = global::MiniJobzAdminSite.Properties.Resources.userprofile;
            this.UserBox.Location = new System.Drawing.Point(148, 493);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(35, 33);
            this.UserBox.TabIndex = 7;
            this.UserBox.TabStop = false;
            // 
            // EmailBtn
            // 
            this.EmailBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmailBtn.FlatAppearance.BorderSize = 0;
            this.EmailBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmailBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.EmailBtn.Image = ((System.Drawing.Image)(resources.GetObject("EmailBtn.Image")));
            this.EmailBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EmailBtn.Location = new System.Drawing.Point(0, 312);
            this.EmailBtn.Name = "EmailBtn";
            this.EmailBtn.Size = new System.Drawing.Size(186, 42);
            this.EmailBtn.TabIndex = 6;
            this.EmailBtn.Text = "Email";
            this.EmailBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EmailBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.EmailBtn.UseVisualStyleBackColor = true;
            this.EmailBtn.Click += new System.EventHandler(this.EmailBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.FlatAppearance.BorderSize = 0;
            this.SettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.SettingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("SettingsBtn.Image")));
            this.SettingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SettingsBtn.Location = new System.Drawing.Point(0, 532);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(186, 42);
            this.SettingsBtn.TabIndex = 5;
            this.SettingsBtn.Text = "Beállítások";
            this.SettingsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SettingsBtn.UseVisualStyleBackColor = true;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // ReportsBtn
            // 
            this.ReportsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReportsBtn.FlatAppearance.BorderSize = 0;
            this.ReportsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportsBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.ReportsBtn.Image = ((System.Drawing.Image)(resources.GetObject("ReportsBtn.Image")));
            this.ReportsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ReportsBtn.Location = new System.Drawing.Point(0, 270);
            this.ReportsBtn.Name = "ReportsBtn";
            this.ReportsBtn.Size = new System.Drawing.Size(186, 42);
            this.ReportsBtn.TabIndex = 4;
            this.ReportsBtn.Text = "Jelentések";
            this.ReportsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReportsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ReportsBtn.UseVisualStyleBackColor = true;
            this.ReportsBtn.Click += new System.EventHandler(this.ReportsBtn_Click);
            // 
            // StatistcBtn
            // 
            this.StatistcBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatistcBtn.FlatAppearance.BorderSize = 0;
            this.StatistcBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatistcBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatistcBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.StatistcBtn.Image = ((System.Drawing.Image)(resources.GetObject("StatistcBtn.Image")));
            this.StatistcBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatistcBtn.Location = new System.Drawing.Point(0, 228);
            this.StatistcBtn.Name = "StatistcBtn";
            this.StatistcBtn.Size = new System.Drawing.Size(186, 42);
            this.StatistcBtn.TabIndex = 3;
            this.StatistcBtn.Text = "Statisztika";
            this.StatistcBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatistcBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.StatistcBtn.UseVisualStyleBackColor = true;
            this.StatistcBtn.Click += new System.EventHandler(this.StatistcBtn_Click);
            // 
            // UsersBtn
            // 
            this.UsersBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.UsersBtn.FlatAppearance.BorderSize = 0;
            this.UsersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsersBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.UsersBtn.Image = ((System.Drawing.Image)(resources.GetObject("UsersBtn.Image")));
            this.UsersBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UsersBtn.Location = new System.Drawing.Point(0, 186);
            this.UsersBtn.Name = "UsersBtn";
            this.UsersBtn.Size = new System.Drawing.Size(186, 42);
            this.UsersBtn.TabIndex = 2;
            this.UsersBtn.Text = "Felhasználókezelés";
            this.UsersBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UsersBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.UsersBtn.UseVisualStyleBackColor = true;
            this.UsersBtn.Click += new System.EventHandler(this.UsersBtn_Click);
            // 
            // HomeBtn
            // 
            this.HomeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.HomeBtn.FlatAppearance.BorderSize = 0;
            this.HomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.HomeBtn.Image = global::MiniJobzAdminSite.Properties.Resources.home__1_;
            this.HomeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HomeBtn.Location = new System.Drawing.Point(0, 144);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(186, 42);
            this.HomeBtn.TabIndex = 1;
            this.HomeBtn.Text = "Főoldal";
            this.HomeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // Logo
            // 
            this.Logo.Image = global::MiniJobzAdminSite.Properties.Resources.Minijobz_Logo;
            this.Logo.Location = new System.Drawing.Point(3, 3);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(180, 129);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // UsenameLabel
            // 
            this.UsenameLabel.AutoSize = true;
            this.UsenameLabel.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsenameLabel.Location = new System.Drawing.Point(3, 498);
            this.UsenameLabel.Name = "UsenameLabel";
            this.UsenameLabel.Size = new System.Drawing.Size(87, 21);
            this.UsenameLabel.TabIndex = 2;
            this.UsenameLabel.Text = "Username";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.closeBox);
            this.Controls.Add(this.NavBar);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.NavBar.ResumeLayout(false);
            this.NavBar.PerformLayout();
            this.PicBoxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.closeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NavBar;
        private System.Windows.Forms.Panel PicBoxPanel;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button ReportsBtn;
        private System.Windows.Forms.Button StatistcBtn;
        private System.Windows.Forms.Button UsersBtn;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Button EmailBtn;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.PictureBox closeBox;
        private System.Windows.Forms.PictureBox UserBox;
        private System.Windows.Forms.Label UsenameLabel;
    }
}