using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BisEn
{
    public partial class frmCancell : Form
    {
        public frmCancell()
        {
            InitializeComponent();
        }

        private void frmCancell_Load(object sender, EventArgs e)
        {
            if (Utility.CertType == 0)
            {
                lblCertType.Text = "Petrol";
                lblCertType.ForeColor = Color.Green;
                lblPUCNo.Text = "";
            }
            else
            {
                int vCode = 0;
                lblCertType.Text = "Diesel";
                lblCertType.ForeColor = Color.Purple;
                lblPUCNo.Text="INDROR 18"+string.Format("{0:000000}",Utility.ChkCodeForCancel);
                
                lblChkDate.Text = Db.GetDate("DPUCRecord", "ChkDate", "ChkCode", Utility.ChkCodeForCancel).ToString("dd-MMM-yyyy");
                lblChkTime.Text = Db.GetStr("DPUCRecord", "ChkTime", "ChkCode", Utility.ChkCodeForCancel);
                vCode = Db.GetCode("DPUCRecord", "VchCode", "ChkCode", Utility.ChkCodeForCancel);
                lblVchNo.Text = Db.GetStr("DVchRecord", "VchRegNo", "VchCode", vCode);
                lblOwner.Text = Db.GetStr("DVchRecord", "OwnerName", "VchCode", vCode);
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Utility.ChkCodeForCancel = 0;
            this.Dispose();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to remove this record?", "Please confirm..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OleDbConnection con = Db.GetCon();
                con.Open();
                if (Utility.CertType == 1)
                {
                    new OleDbCommand("UPDATE DPUCRecord SET CancelFlag=True, CancelledOn=#"+Utility.opnDate.Date+"# , CancelReason='"+txtRemark.Text+"' WHERE ChkCode=" + Utility.ChkCodeForCancel, con).ExecuteNonQuery();
                }
                else
                {
                }
                con.Close();
                MessageBox.Show("Certificate is cancelled1", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
