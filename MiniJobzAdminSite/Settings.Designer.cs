namespace MiniJobzAdminSite
{
    partial class Settings
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
            this.ProfilePictureSettingBtn = new System.Windows.Forms.Button();
            this.PasswordSettingBtn = new System.Windows.Forms.Button();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProfilePictureSettingBtn
            // 
            this.ProfilePictureSettingBtn.Location = new System.Drawing.Point(289, 139);
            this.ProfilePictureSettingBtn.Name = "ProfilePictureSettingBtn";
            this.ProfilePictureSettingBtn.Size = new System.Drawing.Size(183, 23);
            this.ProfilePictureSettingBtn.TabIndex = 0;
            this.ProfilePictureSettingBtn.Text = "Profilkép módosítása";
            this.ProfilePictureSettingBtn.UseVisualStyleBackColor = true;
            this.ProfilePictureSettingBtn.Click += new System.EventHandler(this.ProfilePictureSettingBtn_Click);
            // 
            // PasswordSettingBtn
            // 
            this.PasswordSettingBtn.Location = new System.Drawing.Point(289, 168);
            this.PasswordSettingBtn.Name = "PasswordSettingBtn";
            this.PasswordSettingBtn.Size = new System.Drawing.Size(183, 23);
            this.PasswordSettingBtn.TabIndex = 1;
            this.PasswordSettingBtn.Text = "Jelszó módosítása";
            this.PasswordSettingBtn.UseVisualStyleBackColor = true;
            this.PasswordSettingBtn.Click += new System.EventHandler(this.PasswordSettingBtn_Click);
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Location = new System.Drawing.Point(289, 197);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(183, 23);
            this.LogoutBtn.TabIndex = 2;
            this.LogoutBtn.Text = "Kijelentkezés";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.PasswordSettingBtn);
            this.Controls.Add(this.ProfilePictureSettingBtn);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProfilePictureSettingBtn;
        private System.Windows.Forms.Button PasswordSettingBtn;
        private System.Windows.Forms.Button LogoutBtn;
    }
}