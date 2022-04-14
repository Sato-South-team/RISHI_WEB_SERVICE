// Decompiled with JetBrains decompiler
// Type: RISHI_WEB_SERVICE.Business_Layer.Transaction
// Assembly: RISHI_WEB_SERVICE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FCDBD3EF-8149-4CAD-A076-8C736CE9926A
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\WEB_SERVICE\bin\RISHI_WEB_SERVICE.dll

using RISHI_WEB_SERVICE.Data_Layer;
using System;
using System.Data;

namespace RISHI_WEB_SERVICE.Business_Layer
{
    public class Transaction
    {
        private DatabaseConnections obj_DB = new DatabaseConnections();

        public string BL_ValidateLogin()
        {
            try
            {
                return this.obj_DB.ExecuteProcedureParam("Proc_Login", (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.UserID, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.Password, (object)"", (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BL_HHTScanning()
        {
            try
            {
                return this.obj_DB.ExecuteDataSetParam("Proc_HHT_Scanning", (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWrapping, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.MachineBarcode, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.ItemBarcode, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.Serialno, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.Remarks, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.InvoiceNo, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.Type, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.TransactionType, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.BatchNo, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.TotalTrolleyWeigt, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.AssetBarcode, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.NoofBobbins, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.Width, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.Length, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.NoOfEnds, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.WOrkOrderNo, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.FGWeight, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.CustCode, (object)RISHI_WEB_SERVICE.Entity_Layer.Transaction.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
