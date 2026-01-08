using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniJobzAdminSite
{
    public partial class UserManagement : Form
    {
        private string username;
        private DataGridView usersGrid;
        private Panel usersPanel;
        private TextBox searchTextBox;  
        private Button searchButton;    

        private string connectionString = "Server=localhost;Database=minijobz_teszt;Uid=root";

        public UserManagement(string username)
        {
            InitializeComponent();
            this.username = username;

            SetupLayout();  
            SetupSearch();    
            SetupGrid();     
            LoadUsers();    
        }

        private void SetupLayout()
        {
            usersPanel = new Panel();
            usersPanel.Dock = DockStyle.Fill;
            usersPanel.Padding = new Padding(0, 50, 0, 0);
            usersPanel.BackColor = Color.FromArgb(46, 51, 73);
            this.Controls.Add(usersPanel);
            usersPanel.BringToFront();
        }

        private void SetupSearch()
        {
            Panel searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(46, 51, 73)
            };
            this.Controls.Add(searchPanel);  

            Label searchLabel = new Label
            {
                Text = "Keresés (Account ID):",
                Location = new Point(20, 23),
                ForeColor = Color.White,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            searchPanel.Controls.Add(searchLabel);

            searchTextBox = new TextBox
            {
                Location = new Point(160, 20),
                Width = 200,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(24, 30, 54),
                ForeColor = Color.White
            };
            searchPanel.Controls.Add(searchTextBox);

            searchButton = new Button
            {
                Text = "Keresés",
                Location = new Point(380, 17),
                Width = 100,
                Height = 30,
                BackColor = Color.FromArgb(80, 114, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            searchButton.Click += SearchButton_Click;
            searchPanel.Controls.Add(searchButton);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadUsers();
            }
            else
            {
                SearchUsers(searchTerm);
            }
        }

        private void SearchUsers(string searchTerm)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, account_id FROM users WHERE account_id LIKE @searchTerm;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    MySqlDataReader reader = cmd.ExecuteReader();

                    usersGrid.Rows.Clear();  
                    while (reader.Read())
                    {
                        string userId = reader["id"].ToString();
                        string accountId = reader["account_id"].ToString();

                        usersGrid.Rows.Add(accountId, userId, null, null, null);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a keresés során:\n" + ex.Message);
            }
        }

        private void SetupGrid()
        {
            usersGrid = new DataGridView();
            usersGrid.Dock = DockStyle.Top; 
            usersGrid.Height = 500;  
            usersGrid.BackgroundColor = Color.FromArgb(46, 51, 73);
            usersGrid.BorderStyle = BorderStyle.None;
            usersGrid.AllowUserToAddRows = false;
            usersGrid.RowHeadersVisible = false;
            usersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersGrid.EnableHeadersVisualStyles = false;
            usersGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 30, 54);
            usersGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(80, 114, 255);
            usersGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            usersGrid.RowTemplate.Height = 50;
            usersGrid.DefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            usersGrid.DefaultCellStyle.ForeColor = Color.FromArgb(80, 114, 255);
            usersGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 80, 120);
            usersGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            usersGrid.GridColor = Color.Gray;

            var colAccountId = new DataGridViewTextBoxColumn();
            colAccountId.HeaderText = "Azonosító";
            colAccountId.ReadOnly = true;
            colAccountId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAccountId.DefaultCellStyle.ForeColor = Color.FromArgb(80, 114, 255);
            usersGrid.Columns.Add(colAccountId);

            var colUserId = new DataGridViewTextBoxColumn();
            colUserId.HeaderText = "UserId";
            colUserId.Visible = false;
            usersGrid.Columns.Add(colUserId);

            string imgPath = System.IO.Path.Combine(Application.StartupPath, @"..\..\..\img");
            Image muteIcon = Image.FromFile(System.IO.Path.Combine(imgPath, "mute.png"));
            Image restrictIcon = Image.FromFile(System.IO.Path.Combine(imgPath, "restrict.png"));
            Image banIcon = Image.FromFile(System.IO.Path.Combine(imgPath, "ban.png"));

            var muteColumn = new DataGridViewImageColumn();
            muteColumn.Image = muteIcon;
            muteColumn.HeaderText = "Némítás";
            muteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            usersGrid.Columns.Add(muteColumn);

            var restrictColumn = new DataGridViewImageColumn();
            restrictColumn.Image = restrictIcon;
            restrictColumn.HeaderText = "Korlátozás";
            restrictColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            restrictColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            usersGrid.Columns.Add(restrictColumn);

            var banColumn = new DataGridViewImageColumn();
            banColumn.Image = banIcon;
            banColumn.HeaderText = "Tiltás";
            banColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            usersGrid.Columns.Add(banColumn);

            usersGrid.CellClick += UsersGrid_CellClick;

            usersPanel.Controls.Add(usersGrid);
        }


        private void UsersGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string userIdStr = usersGrid.Rows[e.RowIndex].Cells[1].Value?.ToString();

            if (string.IsNullOrWhiteSpace(userIdStr))
            {
                MessageBox.Show("Üres vagy érvénytelen felhasználó azonosító.");
                return;
            }

            if (!int.TryParse(userIdStr, out int userId))
            {
                MessageBox.Show($"Hibás felhasználó azonosító: {userIdStr}");
                return;
            }

            int penaltyId = 0;

            if (e.ColumnIndex == 2)
            {
                penaltyId = 1;
            }
            else if (e.ColumnIndex == 3)
            {
                penaltyId = 2;

            }
            else if (e.ColumnIndex == 4)
            {
                penaltyId = 3;
            }
            else
            {
                return;
            }

            Sanction sanctionForm = new Sanction(userId, penaltyId);
            sanctionForm.ShowDialog();
        }

        private void LoadUsers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, account_id FROM users;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string userId = reader["id"].ToString();         
                        string accountId = reader["account_id"].ToString(); 

                        usersGrid.Rows.Add(accountId, userId, null, null, null);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatok betöltésekor:\n" + ex.Message);
            }
        }
    }
}
