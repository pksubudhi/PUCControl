using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace BisEn
{
    public partial class frmCancelList : Form
    {
        public frmCancelList()
        {
            InitializeComponent();
        }
        ReportViewer rvCert;
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
            frmView tmp = new frmView();
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

        private void btnRef_Click(object sender, EventArgs e)
        {
            if (optAll.Checked)
            {
                //FillPCert();
                FillDCert();
            }
            else
            {
                if ((dtpDate.Value.Date > Utility.opnDate.Date) || (dtpToDate.Value.Date > Utility.opnDate.Date))
                {
                    MessageBox.Show("Selected date (s) cannot be beyond System OPENING Date..", "Invalid Date selection..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDate.Focus();
                }
                else
                {
                    //FillPCert();
                    FillDCert();
                }
            }
        }
        /*void FillPCert()
        {
            DataSet ds = new DataSet();
            if (optAll.Checked)
            {
                new OleDbDataAdapter("SELECT ChkCode,PPUCRecord.VchCode, PVchRecord.VchCode, ChkDate,ChkTime,ValUpto, VchRegNo,VchMake,VchModel, OwnerName, DriverName FROM PPUCRecord, PVchRecord WHERE PVchRecord.VchCode=PPUCRecord.VchCode ORDER BY ChkCode DESC", Db.GetCon()).Fill(ds, "vch");
            }
            else
            {
                new OleDbDataAdapter("SELECT ChkCode, PPUCRecord.VchCode, PVchRecord.VchCode, ChkDate, ChkTime, ValUpto, VchRegNo, VchMake, VchModel, OwnerName, DriverName FROM PPUCRecord, PVchRecord WHERE PVchRecord.VchCode=PPUCRecord.VchCode AND (ChkDate>=#" + dtpDate.Value.Date + "# AND ChkDate<=#" + dtpToDate.Value.Date + "#) ORDER BY ChkCode DESC", Db.GetCon()).Fill(ds, "vch");
            }
            lvwPData.Items.Clear();
            lstPCode.Items.Clear();
            if (ds.Tables["vch"].Rows.Count > 0)
            {
                int Cnt = 1;
                ListViewItem lvi;
                foreach (DataRow r in ds.Tables["vch"].Rows)
                {
                    lvi = new ListViewItem(Cnt.ToString());
                    lvi.SubItems.Add(r.ItemArray[6].ToString());
                    lvi.SubItems.Add(r.ItemArray[7].ToString());
                    lvi.SubItems.Add(r.ItemArray[8].ToString());
                    lvi.SubItems.Add(r.ItemArray[9].ToString());
                    lvi.SubItems.Add(r.ItemArray[10].ToString());

                    lvi.SubItems.Add(DateTime.Parse(r.ItemArray[3].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(r.ItemArray[4].ToString());
                    lvi.SubItems.Add(DateTime.Parse(r.ItemArray[5].ToString()).ToString("dd-MMM-yyyy"));

                    lstPCode.Items.Add(r.ItemArray[0].ToString());
                    lvwPData.Items.Add(lvi);
                    Cnt++;
                }
            }
        }*/
        void FillDCert()
        {
            this.Cursor = Cursors.WaitCursor;
            DataSet ds = new DataSet();
            if (optAll.Checked)
            {
                new OleDbDataAdapter("SELECT ChkCode,DPUCRecord.VchCode, DVchRecord.VchCode, ChkDate,ChkTime,ValUpto, VchRegNo,VchMake,VchModel, OwnerName, DriverName, CancelledOn, VchType, CancelReason FROM DPUCRecord, DVchRecord WHERE DVchRecord.VchCode=DPUCRecord.VchCode AND CancelFlag=True ORDER BY ChkCode", Db.GetCon()).Fill(ds, "vch");
            }
            else
            {
                new OleDbDataAdapter("SELECT ChkCode, DPUCRecord.VchCode, DVchRecord.VchCode, ChkDate,ChkTime,ValUpto, VchRegNo,VchMake,VchModel, OwnerName, DriverName, CancelledOn, VchType, CancelReason FROM DPUCRecord, DVchRecord WHERE DVchRecord.VchCode=DPUCRecord.VchCode AND (CancelledOn>=#" + dtpDate.Value.Date + "# AND CancelledOn<=#" + dtpToDate.Value.Date + "#) AND CancelFlag=True ORDER BY ChkCode", Db.GetCon()).Fill(ds, "vch");
            }
            lvwDData.Items.Clear();
            //lstDCode.Items.Clear();
            if (ds.Tables["vch"].Rows.Count > 0)
            {
                int Cnt = 1, vType;
                ListViewItem lvi;
                string pucc;
                foreach (DataRow r in ds.Tables["vch"].Rows)
                {
                    pucc = "INDOR 18" + string.Format("{0:000000}", int.Parse(r.ItemArray[0].ToString()));
                    lvi = new ListViewItem(Cnt.ToString());
                    lvi.SubItems.Add(r.ItemArray[6].ToString());
                    lvi.SubItems.Add(r.ItemArray[7].ToString());
                    //lvi.SubItems.Add(r.ItemArray[8].ToString());
                    vType = int.Parse(r.ItemArray[12].ToString());
                    lvi.SubItems.Add(Db.GetStr("DVchTypes","VchDesc","VchCode",vType));

                    lvi.SubItems.Add(r.ItemArray[9].ToString());
                    lvi.SubItems.Add(pucc);
                    //lvi.SubItems.Add(r.ItemArray[10].ToString());
                    lvi.SubItems.Add(DateTime.Parse(r.ItemArray[3].ToString()).ToString("dd-MMM-yyyy"));
                    
                    lvi.SubItems.Add(DateTime.Parse(r.ItemArray[11].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(r.ItemArray[13].ToString());

                    // Cancellation Date
                    //lstDCode.Items.Add(r.ItemArray[0].ToString());
                    lvwDData.Items.Add(lvi);
                    Cnt++;
                }
            }
            this.Cursor = Cursors.Default;
        }
        private void optAll_CheckedChanged(object sender, EventArgs e)
        {
            if (optAll.Checked)
            {
                dtpDate.Enabled = false;
                dtpToDate.Enabled = false;
                btnPrintList.Enabled = false;
            }
        }

        private void optDate_CheckedChanged(object sender, EventArgs e)
        {
            if (optDate.Checked)
            {
                dtpDate.Enabled = true;
                dtpToDate.Enabled = true;
                dtpDate.Value = DateTime.Today;
                dtpToDate.Value = DateTime.Today;
                btnPrintList.Enabled = true;
            }
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            OleDbConnection con = Db.GetCon();
            con.Open();
            new OleDbCommand("DELETE FROM DCancelList", con).ExecuteNonQuery();
            con.Close();

            if (lvwDData.Items.Count > 0)
            {
                string licNo = "14/07";
                int Cnt = 1;
                con.Open();
                foreach (ListViewItem lvi in lvwDData.Items)
                {
                    new OleDbCommand("INSERT INTO DCancelList (SlNo,PUCNo,VchNo,VchType,Remark,FromDate,ToDate,LicenceNo) VALUES (" + Cnt + ",'" + lvi.SubItems[5].Text + "','" + lvi.SubItems[1].Text + "','" + lvi.SubItems[3].Text + "','" + lvi.SubItems[8].Text +  "','" + dtpDate.Value.ToString("dd-MMM-yyyy") + "','" + dtpToDate.Value.ToString("dd-MMM-yyyy") + "','" + licNo + "')", con).ExecuteNonQuery();
                    Cnt++;
                }
                con.Close();
            }
            DataSet ds = new DataSet();

            new OleDbDataAdapter("SELECT * FROM DCancelList", Db.GetCon()).Fill(ds, "vch");

            rvCert = new ReportViewer();

            rvCert.LocalReport.ReportPath = "rptCancelList.rdlc";
            rvCert.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsCancel", ds.Tables["vch"]));
            rvCert.RenderingComplete += new RenderingCompleteEventHandler(rvCert_RenderingComplete);
            //rvCert.pri
            //MessageBox.Show("Hello" + ds.Tables["vch"].Rows.Count);

            rvCert.RefreshReport();
        }
        private void rvCert_RenderingComplete(object sender, EventArgs e)
        {
            rvCert.PrintDialog();
        }

        private void frmCancelList_Load(object sender, EventArgs e)
        {

        }
       
    }
}
