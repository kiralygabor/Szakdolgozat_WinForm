using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniJobzAdminSite
{
    public partial class Main : Form
    {
        private string username;
        private Form activeForm = null; // itt tároljuk az aktuális aloldalt

        public Main()
        {
            InitializeComponent();
        }
        public Main(string username)
        {
            InitializeComponent();
            this.username = username;
            UsenameLabel.Text = username;

            // Menü gombok stílusa
            HomeBtn.Padding = new Padding(0, 0, 10, 0);
            HomeBtn.BackColor = Color.FromArgb(46, 51, 73);
            UsersBtn.Padding = new Padding(0, 0, 10, 0);
            StatistcBtn.Padding = new Padding(0, 0, 10, 0);
            ReportsBtn.Padding = new Padding(0, 0, 10, 0);
            EmailBtn.Padding = new Padding(0, 0, 10, 0);
            SettingsBtn.Padding = new Padding(0, 0, 10, 0);
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

        // Ez a metódus kezeli, hogy mindig csak egy aloldal legyen látható
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                this.Controls.Remove(activeForm); // eltávolítja a Main Controls-ból
                activeForm.Close(); // bezárja a formot
            }

            activeForm = childForm;
            childForm.TopLevel = false; // ne legyen külön ablak
            childForm.FormBorderStyle = FormBorderStyle.None; // keret nélkül
            childForm.Dock = DockStyle.Fill; // kitölti a Main formot
            this.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            HomeBtn.BackColor = Color.FromArgb(46, 51, 73);

            if (activeForm != null)
            {
                this.Controls.Remove(activeForm);
                activeForm.Close();
                activeForm = null;
            }
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

            // Ha kész lesz a Statistics form, itt nyisd meg
            // OpenChildForm(new Statistics(username));
        }

        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            ReportsBtn.BackColor = Color.FromArgb(46, 51, 73);

            // Ha kész lesz a Reports form, itt nyisd meg
            // OpenChildForm(new Reports(username));
        }

        private void EmailBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            EmailBtn.BackColor = Color.FromArgb(46, 51, 73);

            // Ha kész lesz az Email form, itt nyisd meg
            // OpenChildForm(new Email(username));
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            ResetMenuButtonColors();
            SettingsBtn.BackColor = Color.FromArgb(46, 51, 73);

            // Ha kész lesz a Settings form, itt nyisd meg
            // OpenChildForm(new Settings(username));
        }

        private void closeBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
