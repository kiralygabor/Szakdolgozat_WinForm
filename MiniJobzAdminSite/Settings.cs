using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace MiniJobzAdminSite
{
    public partial class Settings : Form
    {
        private string username;
        private Main mainForm;
        private string connectionString = "Server=localhost;Database=minijobz;Uid=root;Pwd=;";

        private TextBox oldBox;
        private TextBox newBox;
        private TextBox confirmBox;
        private Form passwordForm;

        public Settings(string username, Main mainForm)
        {
            InitializeComponent();
            this.username = username;
            this.mainForm = mainForm;
        }

        private void ProfilePictureSettingBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = openFileDialog.FileName;
                string projectImgFolder = Path.Combine(Application.StartupPath, "img");

                if (!Directory.Exists(projectImgFolder))
                    Directory.CreateDirectory(projectImgFolder);

                string destFileName = Path.Combine(projectImgFolder, Path.GetFileName(selectedPath));
                File.Copy(selectedPath, destFileName, true);

                string relativePath = Path.Combine("img", Path.GetFileName(selectedPath));
                mainForm.ChangeProfilePicture(destFileName);
                mainForm.UpdateDatabaseProfilePath(relativePath);

                MessageBox.Show("Profilkép sikeresen frissítve!");
            }
        }

        private void PasswordSettingBtn_Click(object sender, EventArgs e)
        {
            passwordForm = new Form();
            passwordForm.Text = "Jelszó módosítás";
            passwordForm.StartPosition = FormStartPosition.CenterParent;
            passwordForm.Size = new System.Drawing.Size(300, 220);
            passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            passwordForm.MaximizeBox = false;
            passwordForm.MinimizeBox = false;

            Label oldLabel = new Label() { Text = "Régi jelszó:", Left = 10, Top = 20, Width = 100 };
            oldBox = new TextBox() { Left = 120, Top = 20, Width = 150, PasswordChar = '*' };

            Label newLabel = new Label() { Text = "Új jelszó:", Left = 10, Top = 60, Width = 100 };
            newBox = new TextBox() { Left = 120, Top = 60, Width = 150, PasswordChar = '*' };

            Label confirmLabel = new Label() { Text = "Új jelszó újra:", Left = 10, Top = 100, Width = 100 };
            confirmBox = new TextBox() { Left = 120, Top = 100, Width = 150, PasswordChar = '*' };

            Button submitBtn = new Button() { Text = "Módosítás", Left = 100, Width = 100, Top = 140 };
            submitBtn.Click += PasswordSubmitBtn_Click;

            passwordForm.Controls.Add(oldLabel);
            passwordForm.Controls.Add(oldBox);
            passwordForm.Controls.Add(newLabel);
            passwordForm.Controls.Add(newBox);
            passwordForm.Controls.Add(confirmLabel);
            passwordForm.Controls.Add(confirmBox);
            passwordForm.Controls.Add(submitBtn);

            passwordForm.AcceptButton = submitBtn;
            passwordForm.ShowDialog();
        }

        private void PasswordSubmitBtn_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT password FROM admins WHERE username=@username";
                using (var cmd = new MySqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string storedHash = result.ToString();

                        if (BCrypt.Net.BCrypt.Verify(oldBox.Text, storedHash))
                        {
                            if (newBox.Text == confirmBox.Text)
                            {
                                string newHash = BCrypt.Net.BCrypt.HashPassword(newBox.Text);

                                string updateQuery = "UPDATE admins SET password=@newpass WHERE username=@username";
                                using (var updateCmd = new MySqlCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@newpass", newHash);
                                    updateCmd.Parameters.AddWithValue("@username", username);
                                    updateCmd.ExecuteNonQuery();
                                }

                                MessageBox.Show("Jelszó sikeresen módosítva!");
                                passwordForm.Close();
                            }
                            else
                            {
                                MessageBox.Show("Az új jelszavak nem egyeznek!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("A régi jelszó helytelen!");
                        }
                    }
                }
            }
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            mainForm.Close();
        }

        private void newAdminBtn_Click(object sender, EventArgs e)
        {
            string newUsername = newAdminName.Text.Trim();
            string newPassword = newAdminPassword.Text;
            string confirmPassword = newAdminPassword2.Text;

            if (string.IsNullOrEmpty(newUsername) ||
                string.IsNullOrEmpty(newPassword) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("A jelszavak nem egyeznek!");
                return;
            }

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM admins WHERE username=@username";
                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", newUsername);
                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Ez a felhasználónév már létezik!");
                        return;
                    }
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                string insertQuery = "INSERT INTO admins (username, password) VALUES (@username, @password)";
                using (var insertCmd = new MySqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@username", newUsername);
                    insertCmd.Parameters.AddWithValue("@password", hashedPassword);
                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Új admin sikeresen létrehozva!");

                newAdminName.Clear();
                newAdminPassword.Clear();
                newAdminPassword2.Clear();
            }
        }
    }
}