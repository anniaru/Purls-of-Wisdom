using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public partial class UserControlBlank : UserControl
    {
        // This user control is created to fill the calendar where there is not a particular day to be shown.
        public UserControlBlank()
        {
            InitializeComponent();
        }
        private void UserControlBlank_Load(object sender, EventArgs e)
        {
        }
    }
}
