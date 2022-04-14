// Decompiled with JetBrains decompiler
// Type: RISHI_WEB_SERVICE.Business_Layer.My_SQL_Transaction
// Assembly: RISHI_WEB_SERVICE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FCDBD3EF-8149-4CAD-A076-8C736CE9926A
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\WEB_SERVICE\bin\RISHI_WEB_SERVICE.dll

using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace RISHI_WEB_SERVICE.Business_Layer
{
    public class My_SQL_Transaction
    {
        private MySqlConnection con = new MySqlConnection();
        private Transaction obj_Trans = new Transaction();

        public bool Connect()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbMySql"].ConnectionString;
                if (this.con.State == ConnectionState.Closed)
                {
                    this.con.ConnectionString = connectionString;
                    this.con.Open();
                }
                return this.con.State == ConnectionState.Open;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (this.con.State != ConnectionState.Open)
                    return;
                this.con.Close();
                this.con.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BL_FetchMySqlData(string Type, string Value)
        {
            try
            {
                DataSet dataSet1 = new DataSet();
                this.Connect();
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.Type = "GetMySqlQuery";
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.TransactionType = Type;
                DataSet dataSet2 = this.obj_Trans.BL_HHTScanning();
                DataSet dataSet3;
                if (Value != "")
                {
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(dataSet2.Tables[0].Rows[0]["MysqlQuery"].ToString() + "'" + Value + "'", this.con);
                    dataSet3 = new DataSet();
                    DataSet dataSet4 = dataSet3;
                    mySqlDataAdapter.Fill(dataSet4);
                }
                else
                {
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(dataSet2.Tables[0].Rows[0]["MysqlQuery"].ToString(), this.con);
                    dataSet3 = new DataSet();
                    DataSet dataSet5 = dataSet3;
                    mySqlDataAdapter.Fill(dataSet5);
                }
                this.Disconnect();
                return dataSet3;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BL_UpdateMySqlData(string Type, string Value)
        {
            try
            {
                DataSet dataSet1 = new DataSet();
                this.Connect();
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.Type = "GetMySqlQuery";
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.TransactionType = Type;
                DataSet dataSet2 = this.obj_Trans.BL_HHTScanning();
                if (Value != "")
                    new MySqlCommand(dataSet2.Tables[0].Rows[0]["MysqlQuery"].ToString() + "'" + Value + "'", this.con).ExecuteNonQuery();
                this.Disconnect();
                return "Updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
