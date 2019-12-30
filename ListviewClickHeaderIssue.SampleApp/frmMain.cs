using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListviewClickHeaderIssue.SampleApp
{
    public partial class frmMain : Form
    {
        internal int ItemCount = 40;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            for(var i = 0; i < ItemCount; i++)
            {
                lvwItems.Items.Add($"Item {i + 1}");
            }
        }
    }
}
