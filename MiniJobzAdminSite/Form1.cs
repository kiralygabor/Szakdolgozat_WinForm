using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace MiniJobzAdminSite
{
    public partial class AdminSite : Form
    {
        private string connectionString = "Server=localhost;Database=minijobz;Uid=root";
        public string LoggedInUser { get; private set; }

        public AdminSite()
        {
            InitializeComponent();
            this.Load += AdminSite_Load;
            LoginBtn.Click += LoginBtn_Click;
        }

        private void AdminSite_Load(object sender, EventArgs e)
        {
            PasswordInput.PasswordChar = '*';

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Nem sikerült csatlakoztatni az adatbázist: " + exp.Message);
                }
            }
        }

        private bool CheckLogin(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT password FROM admins WHERE username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string storedHash = result.ToString();
                            return BCrypt.Net.BCrypt.Verify(password, storedHash);
                        }

                        return false;
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Bejelentkezés sikertelen: " + exp.Message);
                    return false;
                }
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameInput.Text.Trim();
            string password = PasswordInput.Text;

            if (CheckLogin(username, password))
            {
                DialogResult = DialogResult.OK;
                LoggedInUser = username;
            }
            else
            {
                MessageBox.Show("Hibás felhasználónév vagy jelszó!");
            }
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            PasswordInput.PasswordChar = ShowPassword.Checked ? '\0' : '*';
            PasswordInput.Focus();
        }
    }
}