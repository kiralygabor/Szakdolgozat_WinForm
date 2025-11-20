using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniJobzAdminSite
{
    public partial class Email : Form
    {
        private string username;

        public Email(string username)
        {
            InitializeComponent();
            this.username = username;
        }
    }
}
