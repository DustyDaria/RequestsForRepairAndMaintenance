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
    public partial class UsersData : Form
    {
        int mainID = 0;
        int secondaryID = 0;
        string usersAction = string.Empty;

        public UsersData(int returnID, string action, int usersID)
        {
            InitializeComponent();

            mainID = returnID;
            secondaryID = usersID;
            usersAction = action;
        }
    }
}
