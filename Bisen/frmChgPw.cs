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
    public partial class frmChgPw : Form
    {
        public frmChgPw()
        {
            InitializeComponent();
        }

        private void frmChgPw_Load(object sender, EventArgs e)
        {
            txtCurPw.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            OleDbConnection con = Db.GetCon();
            if (Db.GetStr("UserMaster", "UserPw", "UserId", Utility.WhoYouAre).Equals(txtCurPw.Text))
            {
                if (txtNewPw.Text.Equals(txtConf.Text))
                {
                    con.Open();
                    new OleDbCommand("UPDATE UserMaster SET UserPw='" + txtNewPw.Text + "' WHERE UserId='" + Utility.WhoYouAre + "'", con).ExecuteNonQuery();
                    con.Close();
                    
                    MessageBox.Show("New Password Set", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Confirmation does not match with the new password", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConf.Focus();
                }
            }
            else
            {
                MessageBox.Show("Unauthorised User", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurPw.Focus();
            }
        }

        private void txtCurPw_Enter(object sender, EventArgs e)
        {
            txtCurPw.SelectAll();
        }

        private void txtNewPw_Enter(object sender, EventArgs e)
        {
            txtNewPw.SelectAll();
        }

        private void txtConf_Enter(object sender, EventArgs e)
        {
            txtConf.SelectAll();
        }

        private void txtCurPw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtNewPw.Focus();
            }
        }

        private void txtNewPw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtConf.Focus();
            }
        }

        private void txtConf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnOk.Focus();
            }
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
            btnClose.Image = picCloseIn.Image;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = picCloseOut.Image;
        }
    }
}
