using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniJobzAdminSite
{
    public partial class Main : Form
    {
        private string username;
        private Form activeForm = null;

        public Main()
        {
            InitializeComponent();
            this.Load += Main_Load;
        }

        public Main(string username)
        {
            InitializeComponent();
            this.username = username;
            this.Load += Main_Load;

            UsernameLabel.Text = username;

            GreetingLabel.AutoSize = false;
            GreetingLabel.Height = 80;
            GreetingLabel.Font = new Font("Segoe UI", 36, FontStyle.Bold);
            GreetingLabel.TextAlign = ContentAlignment.MiddleCenter;
            GreetingLabel.Text = $"Üdvözöljük {username}!";

            HomeBtn.Padding = new Padding(0, 0, 10, 0);
            HomeBtn.BackColor = Color.FromArgb(46, 51, 73);
            UsersBtn.Padding = new Padding(0, 0, 10, 0);
            StatistcBtn.Padding = new Padding(0, 0, 10, 0);
            ReportsBtn.Padding = new Padding(0, 0, 10, 0);
            EmailBtn.Padding = new Padding(0, 0, 10, 0);
            SettingsBtn.Padding = new Padding(0, 0, 10, 0);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            closeBox.Location = new Point(this.Width - closeBox.Width - 10, 10);
            closeBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Controls.Add(closeBox);
            closeBox.BringToFront();

            ContentPanel.Controls.Add(GreetingLabel);
            GreetingLabel.BringToFront();

            PositionGreetingLabel();
            GreetingLabel.Visible = true;
        }

        private void PositionGreetingLabel()
        {
            GreetingLabel.Width = Math.Min(600, ContentPanel.Width - 20);

            GreetingLabel.Left = (ContentPanel.Width - GreetingLabel.Width) / 2;
            GreetingLabel.Top = (ContentPanel.Height - GreetingLabel.Height) / 2 - 50;
        }

        private void ResetMenuButtonColors()
        {
            Color defaultColor = Color.FromArgb(24, 30, 54);
            HomeBtn.BackColor = defaultColor;
            UsersBtn.BackColor = defaultColor;
            StatistcBtn.BackColor = defaultColor;
            ReportsBtn.BackColor = defaultColor;
            EmailBtn.BackColor = defaultColor;
            SettingsBtn.BackColor = defaultColor;
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();

            GreetingLabel.Visible = false;
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            HomeBtn.BackColor = Color.FromArgb(46, 51, 73);

            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            ContentPanel.Controls.Clear();

            ContentPanel.Controls.Add(GreetingLabel);
            GreetingLabel.Visible = true;
            PositionGreetingLabel();
        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            UsersBtn.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new UserManagement(username));
        }

        private void StatistcBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            StatistcBtn.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new Statistics(username));
        }

        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            ReportsBtn.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new Reports(username));
        }

        private void EmailBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            EmailBtn.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new Email(username));
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            SettingsBtn.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new Settings(username));
        }

        private void closeBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
