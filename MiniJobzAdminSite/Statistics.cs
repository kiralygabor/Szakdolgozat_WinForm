using System;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniJobzAdminSite
{
    public partial class Statistics : Form
    {
        private string username;
        private string connectionString = "Server=localhost;Database=minijobz;Uid=root";

        public Statistics(string username)
        {
            InitializeComponent();
            this.username = username;

            this.Load += Statistics_Load;
            this.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            CreateHeader();
            CreateDashboardCards();
        }

        private void CreateHeader()
        {
            Label headerLabel = new Label();
            headerLabel.Text = "Statisztikák";
            headerLabel.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            headerLabel.ForeColor = Color.FromArgb(80, 114, 255);  
            headerLabel.AutoSize = true;
            headerLabel.Location = new Point(100, 60);

            this.Controls.Add(headerLabel);
        }

        private void CreateDashboardCards()
        {
            int startX = 100;
            int startY = 150;
            int gap = 20;

            string imgPath = Path.Combine(Application.StartupPath, @"..\..\..\img");

            int usersCount = GetUsersCount();
            int advertisementsCount = GetAdvertisementsCount();
            int completedAdvertisementsCount = GetCompletedAdvertisementsCount();
            int sanctionsCount = GetSanctionsCount();

            this.Controls.Add(CreateCard(
                "Felhasználók száma",
                usersCount.ToString(),
                Path.Combine(imgPath, "businessman.png"),
                startX,
                startY));

            this.Controls.Add(CreateCard(
                "Hirdetések száma",
                advertisementsCount.ToString(),
                Path.Combine(imgPath, "billboard.png"),
                startX + 270 + gap,
                startY));

            this.Controls.Add(CreateCard(
                "Teljesített hirdetések",
                completedAdvertisementsCount.ToString(),
                Path.Combine(imgPath, "approved.png"),
                startX,
                startY + 150 + gap));

            this.Controls.Add(CreateCard(
                "Büntetések száma",
                sanctionsCount.ToString(),
                Path.Combine(imgPath, "jail-cell.png"),
                startX + 270 + gap,
                startY + 150 + gap));
        }

        private int GetUsersCount()
        {
            int userCount = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    userCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázis kapcsolatban: " + ex.Message);
                }
            }

            return userCount;
        }

        private int GetAdvertisementsCount()
        {
            int advertisementsCount = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM advertisements";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    advertisementsCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázis kapcsolatban: " + ex.Message);
                }
            }

            return advertisementsCount;
        }

        private int GetCompletedAdvertisementsCount()
        {
            int completedAdvertisementsCount = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM advertisements WHERE status = 'completed';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    completedAdvertisementsCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázis kapcsolatban: " + ex.Message);
                }
            }

            return completedAdvertisementsCount;
        }

        private int GetSanctionsCount()
        {
            int sanctionsCount = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM blacklist";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    sanctionsCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt az adatbázis kapcsolatban: " + ex.Message);
                }
            }

            return sanctionsCount;
        }

        private Panel CreateCard(string title, string value, string iconPath, int x, int y)
        {
            Panel card = new Panel();
            card.Size = new Size(250, 120);
            card.Location = new Point(x, y);
            card.BackColor = Color.FromArgb(46, 51, 73);
            card.BorderStyle = BorderStyle.FixedSingle;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.ForeColor = Color.FromArgb(80, 114, 255);  
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblTitle.Location = new Point(15, 15);
            lblTitle.AutoSize = true;

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.ForeColor = Color.DeepSkyBlue;
            lblValue.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblValue.Location = new Point(15, 45);
            lblValue.AutoSize = true;


            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(40, 40);
            pictureBox.Location = new Point(card.Width - 55, 40);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            try
            {
                pictureBox.Image = Image.FromFile(iconPath); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a kép betöltésekor: {ex.Message}");
            }

            pictureBox.BackColor = Color.Transparent;

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            card.Controls.Add(pictureBox);

            return card;
        }
    }
}
