// Decompiled with JetBrains decompiler
// Type: RISHI_WEB_SERVICE.IService1
// Assembly: RISHI_WEB_SERVICE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FCDBD3EF-8149-4CAD-A076-8C736CE9926A
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\WEB_SERVICE\bin\RISHI_WEB_SERVICE.dll

using System.Data;
using System.ServiceModel;

namespace RISHI_WEB_SERVICE
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string LoginValidate(string UserID, string Password, string Type);

        [OperationContract]
        DataSet HHTScanning(
          string Type,
          string TransactionType,
          string MachineBarcode,
          string ItemBarcode,
          string Remarks,
          string PicklistNo,
          string Value,
          string BatchNo,
          string TotalTrolleyWeight,
          string AssetBarcode,
          string NoOfBobins,
          string CreatedBY,
          string Width,
          string Length,
          string NoofEnds,
          string WorkOrderNo,
          string FGWeight,
          string CustID);

        [OperationContract]
        DataSet FetchMySqlData(string Type, string Value);

        string UpdateMySqlData(string Type, string Value);
    }
}
