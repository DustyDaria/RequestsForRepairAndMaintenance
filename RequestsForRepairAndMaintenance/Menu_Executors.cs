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
    public partial class Menu_Executors : Form
    {
        int mainID = 0;

        public Menu_Executors(int ID)
        {
            InitializeComponent();
            

            mainID = ID;
        }

        private void Menu_Executors_Load(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Close();
        }
    }
}
