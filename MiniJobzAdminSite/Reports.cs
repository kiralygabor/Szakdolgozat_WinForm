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
    public partial class Reports : Form
    {
        private string username;

        public Reports(string username)
        {
            InitializeComponent();
            this.username = username;
        }
    }
}
