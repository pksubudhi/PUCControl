using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace BisEn
{
    public enum TextPosition
    {
        Start, End, Between
    }
    class Db
    {
        public static string BackupConStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Data\\BackUpRecord.mdb;Persist Security Info=False;Jet OLEDB:Database Password=sundatabackupboffin;";
        public static string ConStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Data\\PUCData.mdb;Persist Security Info=False;Jet OLEDB:Database Password=bisenboffin;";
        public static int GetMax(string tblName, string fldName)
        {
            DataSet ds= new DataSet();
            new OleDbDataAdapter("SELECT MAX("+fldName+") FROM "+tblName,GetCon()).Fill(ds,"tmp");
            if (ds.Tables["tmp"].Rows[0].ItemArray[0]==DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
        }
        public static int GetBackupCode()
        {
            OleDbConnection con = new OleDbConnection(BackupConStr);
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT MAX(BackupId) FROM BackupMaster", con).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows[0].ItemArray[0] == DBNull.Value)
            {
                return 1;
            }
            else
            {
                return int.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim())+1;
            }
        }
        public static int GetCount(string tblName, string fldName)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT COUNT(" + fldName + ") FROM " + tblName, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows[0].ItemArray[0] == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
        }
        public static int GetTotal(string tblName, string fldName)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT SUM(" + fldName + ") FROM " + tblName, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows[0].ItemArray[0] == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
        }
        public static OleDbConnection GetCon()
        {

            return new OleDbConnection(ConStr);
        }
        public static void FillListLike(string tblName, string fldName, string likeData, ListBox lst)
        {
            DataSet ds = new DataSet();
            if (likeData.Length == 0)
            {
                new OleDbDataAdapter("SELECT " + fldName + " FROM " + tblName + " ORDER BY " + fldName, GetCon()).Fill(ds, "tmp");
            }
            else
            {
                
                new OleDbDataAdapter("SELECT " + fldName + " FROM " + tblName + " WHERE " + fldName + " LIKE '" + likeData + "%' ORDER BY " + fldName, GetCon()).Fill(ds, "tmp");
                       
            }
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                lst.Items.Clear();
                for (int i = 0; i < ds.Tables["tmp"].Rows.Count; i++)
                {
                    lst.Items.Add(ds.Tables["tmp"].Rows[i].ItemArray[0].ToString().Trim());
                }
            }
            else
            {
                lst.Items.Clear();
            }
        }
        public static void FillListLikeAnyWhere(string tblName, string fldName, string likeData, ListBox lst)
        {
            DataSet ds = new DataSet();
            if (likeData.Length == 0)
            {
                new OleDbDataAdapter("SELECT " + fldName + " FROM " + tblName + " ORDER BY " + fldName, GetCon()).Fill(ds, "tmp");
            }
            else
            {

                new OleDbDataAdapter("SELECT " + fldName + " FROM " + tblName + " WHERE " + fldName + " LIKE '%" + likeData + "%' ORDER BY " + fldName, GetCon()).Fill(ds, "tmp");

            }
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                lst.Items.Clear();
                for (int i = 0; i < ds.Tables["tmp"].Rows.Count; i++)
                {
                    lst.Items.Add(ds.Tables["tmp"].Rows[i].ItemArray[0].ToString().Trim());
                }
            }
            else
            {
                lst.Items.Clear();
            }
        }
        public static void FillCombo(string tblName, string fldName, ComboBox cmb, bool SortFlag=true)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + fldName + " FROM " + tblName + " ORDER BY "+fldName, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                cmb.Items.Clear();
                for (int i = 0; i < ds.Tables["tmp"].Rows.Count; i++)
                {
                    cmb.Items.Add(ds.Tables["tmp"].Rows[i].ItemArray[0].ToString().Trim());
                }
            }
        }
        public static string GetItemDesc(int stockCode)
        {
            string iDesc = "";
           
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT ItemCode, BrandCode, ModelCode FROM StockMaster WHERE StockCode=" +stockCode, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                iDesc = GetStr("ItemMaster", "ItemDesc", "ItemCode", int.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString()));
                iDesc = iDesc + "-" + GetStr("BrandMaster", "BrandDesc", "BrandCode", int.Parse(ds.Tables["tmp"].Rows[0].ItemArray[1].ToString()));
                iDesc = iDesc + "," + GetStr("ModelMaster", "ModelDesc", "ModelCode", int.Parse(ds.Tables["tmp"].Rows[0].ItemArray[2].ToString()));
            }
            return iDesc;
        }
        public static string GetStr(string tblName, string reqFld, string baseFld, int baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "=" + baseVal, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim();
            }
            else
            {
                return "";
            }
        }
        public static string GetStr(string tblName, string reqFld, string baseFld, string baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "='" + baseVal+"'", GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return  ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim();
            }
            else
            {
                return "";
            }
        }

        public static bool GetBool(string tblName, string reqFld, string baseFld, int baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "=" + baseVal, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return bool.Parse( ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return false;
            }
        }
        public static bool GetBool(string tblName, string reqFld, string baseFld, string baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "='" + baseVal + "'", GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return bool.Parse( ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return false;
            }
        }
        public static DateTime GetDate(string tblName, string reqFld, string baseFld, int baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "=" + baseVal, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return DateTime.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return new DateTime();
            }
        }
        public static DateTime GetDate(string tblName, string reqFld, string baseFld, string baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "='" + baseVal + "'", GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return DateTime.Parse( ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return new DateTime();
            }
        }
        public static int GetCode(string tblName, string reqFld, string baseFld, int baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "=" + baseVal, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return int.Parse( ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return 0;
            }
        }
        public static int GetCode(string tblName, string reqFld, string baseFld, string baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "='" + baseVal+"'", GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return int.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return 0;
            }
        }

        public static bool IsExists(string tblName, string fldName, string fldData)
        {
             DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + fldName + " FROM " + tblName + " WHERE " + fldName + "='" + fldData + "'", GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsExists(string tblName, string fldName, int fldData)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + fldName + " FROM " + tblName + " WHERE " + fldName + "=" + fldData , GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValid(string tblName, string fldName, int startCode, int endCode)
        {
            for (int i = startCode; i <= endCode; i++)
            {
                if (IsExists(tblName, fldName, i))
                {
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsValid(string tblName, string fldName, int [] codeRange)
        {
            for (int i = 0; i < codeRange.Length;i++ )
            {
                if (IsExists(tblName, fldName, codeRange[i]))
                {
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsValid(string tblName, string fldName, int itemCode)
        {
                if (IsExists(tblName, fldName, itemCode))
                {
                    return true;
                }
                else
                {                    
                    return false;
                }
         }
        public static int GetTotStock(int iCode)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT SUM(StockInHand)  FROM StockMaster WHERE ItemCode=" + iCode, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows[0].ItemArray[0].Equals(DBNull.Value)==false)
            {
                return int.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return 0;
            }
        }
        public static double GetDouble(string tblName, string reqFld, string baseFld, int baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "=" + baseVal, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return double.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return 0;
            }
        }
        public static double GetDouble(string tblName, string reqFld, string baseFld, string baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "='" + baseVal + "'", GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return double.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return 0;
            }
        }
        public static float GetFloat(string tblName, string reqFld, string baseFld, int baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "=" + baseVal, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return float.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return 0;
            }
        }
        public static float GetFloat(string tblName, string reqFld, string baseFld, string baseVal)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT " + reqFld + " FROM " + tblName + " WHERE " + baseFld + "='" + baseVal + "'", GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return float.Parse(ds.Tables["tmp"].Rows[0].ItemArray[0].ToString().Trim());
            }
            else
            {
                return 0;
            }
        }
        static public bool IsStockFound(int iCode, int bCode, int mCode)
        {
            DataSet ds = new DataSet();
            new OleDbDataAdapter("SELECT * FROM StockMaster WHERE ItemCode="+iCode+" AND BrandCode="+bCode+" AND ModelCode="+mCode, GetCon()).Fill(ds, "tmp");
            if (ds.Tables["tmp"].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}

