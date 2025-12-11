using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniJobzAdminSite
{
    public partial class Sanction : Form
    {
        private int userId;
        private int penaltyId;
        private string connectionString = "Server=localhost;Database=minijobz_teszt;Uid=root";

        private DateTimePicker dtPicker;
        private TextBox commentBox;
        private Button okButton;

        public Sanction(int userId, int penaltyId)
        {
            InitializeComponent();
            this.userId = userId;
            this.penaltyId = penaltyId;

            this.Text = "Szankció hozzáadása";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(46, 51, 73); 
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            SetupControls();
        }

        private void SetupControls()
        {
            Label lblExpiration = new Label
            {
                Text = "Szankció lejárata:",
                Location = new Point(20, 20),
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            this.Controls.Add(lblExpiration);

            dtPicker = new DateTimePicker
            {
                Location = new Point(20, 50),
                Width = 250,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd HH:mm:ss",
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(24, 30, 54),
                ForeColor = Color.White
            };
            this.Controls.Add(dtPicker);

            Label lblComment = new Label
            {
                Text = "Megjegyzés:",
                Location = new Point(20, 90),
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            this.Controls.Add(lblComment);

            commentBox = new TextBox
            {
                Location = new Point(20, 120),
                Width = 250,
                Height = 60,
                Multiline = true,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(24, 30, 54),
                ForeColor = Color.White
            };
            this.Controls.Add(commentBox);

            okButton = new Button
            {
                Text = "Szankció mentése",
                Location = new Point(100, 200),
                Width = 150,
                Height = 30,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(80, 114, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);

            okButton.FlatAppearance.BorderSize = 0;
            okButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 51, 73); 
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DateTime expiration = dtPicker.Value;
            string comment = commentBox.Text;

            if (string.IsNullOrWhiteSpace(comment))
            {
                MessageBox.Show("A megjegyzés mező nem lehet üres!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO blacklist (user_id, penalty_id, expiration_date, comment) " +
                                   "VALUES (@userId, @penaltyId, @expiration, @comment)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@penaltyId", penaltyId);
                    cmd.Parameters.AddWithValue("@expiration", expiration.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@comment", comment);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Szankció sikeresen mentve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis művelet során:\n" + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
