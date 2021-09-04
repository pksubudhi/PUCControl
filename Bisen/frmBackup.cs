using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace BisEn
{
    public partial class frmBackup : Form
    {
        public frmBackup()
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

        private void frmBackup_Load(object sender, EventArgs e)
        {
            lblTarget.Text="BK"+string.Format("{0:00}",Utility.opnDate.Day)+string.Format("{0:00}",Utility.opnDate.Month)+string.Format("{0:0000}",Utility.opnDate.Year)+string.Format("{0:00}",DateTime.Now.Hour)+string.Format("{0:00}",DateTime.Now.Minute)+string.Format("{0:00}",DateTime.Now.Second);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (optDef.Checked)
            {
                string srcFile=AppDomain.CurrentDomain.BaseDirectory+"Data\\PUCData.mdb";
                string tarFile =AppDomain.CurrentDomain.BaseDirectory+"BackUp\\"+ lblTarget.Text + ".mdb";
                File.Copy(srcFile, tarFile);
                MessageBox.Show("Backup Taken Sucessfully!", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
            }
        }
    }
}
