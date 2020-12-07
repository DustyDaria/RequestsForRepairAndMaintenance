using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestsForRepairAndMaintenance
{
    public partial class Menu_Customers : Form
    {
        int mainID = 0;

        public Menu_Customers(int ID)
        {
            InitializeComponent();
            Authorization authorization = new Authorization();
            authorization.Close();

            mainID = ID;
        }
    }
}
