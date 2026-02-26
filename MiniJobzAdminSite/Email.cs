using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniJobzAdminSite
{
    public partial class Email : Form
    {
        private string username;
        private string attachmentPath = "";

        private string connectionString =
            "Server=localhost;Database=minijobz;Uid=root;";

        public Email(string username)
        {
            InitializeComponent();
            this.username = username;
            this.Load += Email_Load;
        }

        private void Email_Load(object sender, EventArgs e)
        {
            titleBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadEmails();
        }

        private void LoadEmails()
        {
            try
            {
                titleBox.Items.Clear();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query =
                        "SELECT email FROM users WHERE email IS NOT NULL AND email != ''";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string email = reader["email"].ToString();
                            titleBox.Items.Add(email);
                        }
                    }
                }

                if (titleBox.Items.Count > 0)
                    titleBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Adatbázis hiba:\n" + ex.Message,
                    "DB hiba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void fileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Csatolmány kiválasztása";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                attachmentPath = ofd.FileName;
                attachmentLabel.Text = "Csatolt fájl: " + Path.GetFileName(attachmentPath);
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (titleBox.SelectedItem == null)
                {
                    MessageBox.Show("Nincs kiválasztott email!");
                    return;
                }

                string selectedEmail = titleBox.SelectedItem.ToString();

                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                mail.From = new MailAddress("minii.jobzz@gmail.com");
                mail.To.Add(selectedEmail);

                mail.Subject = "Admin üzenet";
                mail.Body = richTextBox1.Text;
                mail.IsBodyHtml = false;

                if (!string.IsNullOrEmpty(attachmentPath))
                {
                    mail.Attachments.Add(new Attachment(attachmentPath));
                }

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(
                    "minii.jobzz@gmail.com",
                    "pkdyspcljxgfcjgf"
                );

                smtp.Send(mail);

                MessageBox.Show(
                    "Email sikeresen elküldve!",
                    "Siker",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                attachmentPath = "";
                attachmentLabel.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Email küldési hiba:\n" + ex.Message,
                    "Hiba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
