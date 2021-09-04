using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BisEn
{
    public partial class frmCal : Form
    {
        public frmCal()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form retForm = this.Owner;
            this.Dispose();
            frmTools tmp = new frmTools();
            tmp.ShowDialog(retForm);
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = btnCloseIn.Image;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = btnCloseOut.Image;
        }

        private void frmCal_Load(object sender, EventArgs e)
        {

        }
    }
}
