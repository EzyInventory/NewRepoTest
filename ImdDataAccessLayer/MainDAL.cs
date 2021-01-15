                   using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.IO;

namespace ImdDataAccessLayer
{
    public class MainDAL
    {
        public bool Login(string _user, string _pass)
        {
            bool status = false;
            try
            {
                string ssql = "";
                OleDbConnection oledCon = new OleDbConnection();
                OleDbCommand oledCom = new OleDbCommand();
                DataTable _dt = new DataTable();
                oledCon.ConnectionString = GetDbConnectionString();
                oledCon.Open();
                oledCom.Connection = oledCon;
                ssql = "select usc_code from users where usc_username='" + _user.Replace("'", "''") + "' and usc_password='" + _pass.Replace("'", "''") + "'";
                oledCom.CommandText = ssql;
                OleDbDataReader reader = oledCom.ExecuteReader();
                if (reader.HasRows)
                {
                    status = true;
                }
                reader.Close();
                oledCon.Close();

                return status;
            }
            catch (Exception ex)
            {
                ErrWriteLog("Method : Login Error: " + ex.Message);
                return status;
            }
        }
        public DataTable GetDataTable(string ssql)
        {

            OleDbConnection oledCon = new OleDbConnection();
            OleDbCommand oledCom = new OleDbCommand();
            DataTable _dt = new DataTable();
            oledCon.ConnectionString = GetDbConnectionString();
            oledCon.Open();
            oledCom.Connection = oledCon;
            oledCom.CommandText = ssql;
            OleDbDataReader reader = oledCom.ExecuteReader();
            _dt.Load(reader);
            reader.Close();
            oledCon.Close();
            return _dt;
        }

        public string GetDbConnectionString()
        {

            return ConfigurationManager.ConnectionStrings["ConString"].ToString();

        }
        public void ErrWriteLog(string err)
        {

            string path = Directory.GetCurrentDirectory() + "\\errorlog.txt";
            // File.WriteAllText(@path, err);
            File.AppendAllText(@path, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " : " + err + Environment.NewLine);

        }
    }
}
