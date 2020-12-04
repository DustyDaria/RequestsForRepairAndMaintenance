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
    public partial class Form1 : Form
    {
        Style style = new Style();
        public Form1()
        {
            InitializeComponent();

            Label label_Header = new Label();

            Controls.Add(style.Header("lbl1", "this is header", 3, 3, 12));
        }
    }
}
