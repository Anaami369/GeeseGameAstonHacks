using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeeseGameAstonHacks
{
    public partial class LoseScreen : UserControl
    {
        public LoseScreen()
        {
            InitializeComponent();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            HomePage ls = new HomePage();
            f.Controls.Add(ls);

            ls.Focus();
        }
    }
}
