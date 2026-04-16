using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniJobzAdminSite
{
    public partial class Reports : Form
    {
        private string username;

        private Panel mainPanel;
        private Panel topPanel;
        private DataGridView reportsGrid;
        private Button userReportsButton;
        private Button advertisementReportsButton;

        private bool isUserReports = true;

        private string connectionString = "Server=localhost;Database=minijobz;Uid=root";

        public Reports(string username)
        {
            InitializeComponent();
            this.username = username;

            SetupLayout();
            SetupTopButtons();
            SetupGrid();

            LoadUserReports();
        }

        private void SetupLayout()
        {
            mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(0, 50, 0, 0);
            mainPanel.BackColor = Color.FromArgb(46, 51, 73);
            this.Controls.Add(mainPanel);
        }

        private void SetupTopButtons()
        {
            topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 50;
            topPanel.Padding = new Padding(10);
            topPanel.BackColor = Color.FromArgb(46, 51, 73);
            this.Controls.Add(topPanel);

            userReportsButton = new Button();
            userReportsButton.Text = "Felhasználói jelentések";
            userReportsButton.Width = 200;
            userReportsButton.Height = 30;
            userReportsButton.Location = new Point(160, 10);
            userReportsButton.BackColor = Color.FromArgb(80, 114, 255);
            userReportsButton.ForeColor = Color.White;
            userReportsButton.FlatStyle = FlatStyle.Flat;
            userReportsButton.Click += UserReportsButton_Click;
            topPanel.Controls.Add(userReportsButton);

            advertisementReportsButton = new Button();
            advertisementReportsButton.Text = "Hirdetés jelentések";
            advertisementReportsButton.Width = 200;
            advertisementReportsButton.Height = 30;
            advertisementReportsButton.Location = new Point(380, 10);
            advertisementReportsButton.BackColor = Color.FromArgb(80, 114, 255);
            advertisementReportsButton.ForeColor = Color.White;
            advertisementReportsButton.FlatStyle = FlatStyle.Flat;
            advertisementReportsButton.Click += AdvertisementReportsButton_Click;
            topPanel.Controls.Add(advertisementReportsButton);
        }

        private void SetupGrid()
        {
            reportsGrid = new DataGridView();
            reportsGrid.Dock = DockStyle.Fill;
            reportsGrid.AllowUserToAddRows = false;
            reportsGrid.RowHeadersVisible = false;
            reportsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reportsGrid.EnableHeadersVisualStyles = false;
            reportsGrid.BackgroundColor = Color.FromArgb(46, 51, 73);
            reportsGrid.BorderStyle = BorderStyle.None;

            reportsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 30, 54);
            reportsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(80, 114, 255);
            reportsGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            reportsGrid.DefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            reportsGrid.DefaultCellStyle.ForeColor = Color.FromArgb(80, 114, 255);
            reportsGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 80, 120);
            reportsGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            reportsGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            reportsGrid.RowTemplate.Height = 50;
            reportsGrid.GridColor = Color.Gray;

            reportsGrid.CellClick += ReportsGrid_CellClick;
            reportsGrid.CellFormatting += ReportsGrid_CellFormatting;

            mainPanel.Controls.Add(reportsGrid);
        }

        private void UserReportsButton_Click(object sender, EventArgs e)
        {
            isUserReports = true;
            LoadUserReports();
        }

        private void AdvertisementReportsButton_Click(object sender, EventArgs e)
        {
            isUserReports = false;
            LoadAdvertisementReports();
        }

        private void LoadUserReports()
        {
            reportsGrid.Columns.Clear();
            reportsGrid.Rows.Clear();

            reportsGrid.Columns.Add("id", "ID");
            reportsGrid.Columns["id"].Visible = false;

            reportsGrid.Columns.Add("reporter", "Bejelentő");
            reportsGrid.Columns.Add("reported", "Jelentett felhasználó");
            reportsGrid.Columns.Add("description", "Leírás");
            reportsGrid.Columns.Add("status", "Státusz");

            AddActionButtonColumn();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT id, reporter_account_id, reported_account_id, description, status
                                 FROM user_reports";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    reportsGrid.Rows.Add(
                        reader["id"],
                        reader["reporter_account_id"],
                        reader["reported_account_id"],
                        reader["description"],
                        reader["status"]
                    );
                }
            }
        }

        private void LoadAdvertisementReports()
        {
            reportsGrid.Columns.Clear();
            reportsGrid.Rows.Clear();

            reportsGrid.Columns.Add("id", "ID");
            reportsGrid.Columns["id"].Visible = false;

            reportsGrid.Columns.Add("advertisement_id", "Hirdetés ID");
            reportsGrid.Columns.Add("reporter", "Bejelentő");
            reportsGrid.Columns.Add("reported", "Hirdető");
            reportsGrid.Columns.Add("description", "Leírás");
            reportsGrid.Columns.Add("status", "Státusz");

            AddActionButtonColumn();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT id, advertisement_id, reporter_account_id,
                                        reported_account_id, description, status
                                 FROM advertisement_reports";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    reportsGrid.Rows.Add(
                        reader["id"],
                        reader["advertisement_id"],
                        reader["reporter_account_id"],
                        reader["reported_account_id"],
                        reader["description"],
                        reader["status"]
                    );
                }
            }
        }

        private void AddActionButtonColumn()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Műveletek";
            buttonColumn.UseColumnTextForButtonValue = false;
            buttonColumn.FlatStyle = FlatStyle.Flat;
            buttonColumn.Name = "action";

            reportsGrid.Columns.Add(buttonColumn);
        }

        private void ReportsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (reportsGrid.Columns[e.ColumnIndex].Name == "action")
            {
                string status = reportsGrid.Rows[e.RowIndex].Cells["status"].Value?.ToString();

                if (status == "open")
                {
                    e.Value = "Elbírálás";
                    e.CellStyle.ForeColor = Color.White;
                    reportsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                }
                else
                {
                    e.Value = "Elbírálva";
                    e.CellStyle.ForeColor = Color.Gray;
                    reportsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                }
            }

            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ReportsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (reportsGrid.Columns[e.ColumnIndex].Name != "action")
                return;

            string status = reportsGrid.Rows[e.RowIndex].Cells["status"].Value.ToString();

            if (status == "closed" || status == "rejected")
            {
                MessageBox.Show("Ez a jelentés már le van zárva.");
                return;
            }

            long reportId = Convert.ToInt64(reportsGrid.Rows[e.RowIndex].Cells["id"].Value);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = isUserReports
                    ? "UPDATE user_reports SET status = 'closed' WHERE id = @id"
                    : "UPDATE advertisement_reports SET status = 'closed' WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@id", reportId);
                cmd.ExecuteNonQuery();
            }

            reportsGrid.Rows[e.RowIndex].Cells["status"].Value = "closed";
            reportsGrid.Refresh();

            MessageBox.Show("Jelentés sikeresen elbírálva.");
        }
    }
}