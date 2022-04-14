// Decompiled with JetBrains decompiler
// Type: RISHI_WEB_SERVICE.Service1
// Assembly: RISHI_WEB_SERVICE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FCDBD3EF-8149-4CAD-A076-8C736CE9926A
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\WEB_SERVICE\bin\RISHI_WEB_SERVICE.dll

using RISHI_WEB_SERVICE.Business_Layer;
using Sato_Network_Client_DLL;
using System;
using System.Data;

namespace RISHI_WEB_SERVICE
{
    public class Service1 : IService1
    {
        private RISHI_WEB_SERVICE.Business_Layer.Transaction obj_Trans = new RISHI_WEB_SERVICE.Business_Layer.Transaction();
        private My_SQL_Transaction obj_Mysql_Trans = new My_SQL_Transaction();
        private NetworkClient networkClient = new NetworkClient();

        public string Connect()
        {
            try
            {
                return string.Format("You entered: {0}", (object)"True");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string LoginValidate(string UserID, string Password, string Type)
        {
            try
            {
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.UserID = UserID;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.Password = Password;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.Type = Type;
                return this.obj_Trans.BL_ValidateLogin();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet FetchMySqlData(string Type, string Value)
        {
            try
            {
                return this.obj_Mysql_Trans.BL_FetchMySqlData(Type, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateMySqlData(string Type, string Value)
        {
            try
            {
                return this.obj_Mysql_Trans.BL_UpdateMySqlData(Type, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet HHTScanning(
          string Type,
          string TransactionType,
          string MachineBarcode,
          string ItemBarcode,
          string Remarks,
          string InvoiceNo,
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
          string CustID)
        {
            try
            {
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.TransactionType = TransactionType;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.MachineBarcode = MachineBarcode;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.ItemBarcode = ItemBarcode;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.Serialno = DateTime.Now.ToString("ddMMyyyyHHmmss");
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.Remarks = Remarks;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.InvoiceNo = InvoiceNo;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.BatchNo = BatchNo;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.AssetBarcode = AssetBarcode;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.TotalTrolleyWeigt = TotalTrolleyWeight;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.NoofBobbins = NoOfBobins;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.UserID = CreatedBY;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.Width = Width;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.Length = Length;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.NoOfEnds = NoofEnds;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.WOrkOrderNo = WorkOrderNo;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.CustCode = CustID;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.FGWeight = FGWeight;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion = (DataTable)null;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWrapping = (DataTable)null;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving = (DataTable)null;
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting = (DataTable)null;
                if (TransactionType == "Extrusion")
                    RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion = this.FetchMySqlData(TransactionType, Value).Tables[0];
                if (TransactionType == "Warping_Output")
                    RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWrapping = this.FetchMySqlData(TransactionType, WorkOrderNo.Split('/')[0].ToString()).Tables[0];
                if (TransactionType == "Weaving_Output")
                    RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving = this.FetchMySqlData(TransactionType, WorkOrderNo).Tables[0];
                if (TransactionType == "Knitting_Output")
                    RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting = this.FetchMySqlData(TransactionType, WorkOrderNo).Tables[0];
                RISHI_WEB_SERVICE.Entity_Layer.Transaction.Type = Type;
                DataSet dataSet = this.obj_Trans.BL_HHTScanning();
                if (dataSet.Tables[0].Rows[0][0].ToString() == "Saved" && dataSet.Tables.Count == 2)
                {
                    this.networkClient = new NetworkClient();
                    this.networkClient.connection(dataSet.Tables[1].Rows[0]["PrinterIP"].ToString(), Convert.ToInt32(dataSet.Tables[1].Rows[0]["PrinterPort"]));
                    DateTime now;
                    if (TransactionType == "Extrusion")
                    {
                        string str1 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                        string newValue1 = RISHI_WEB_SERVICE.Entity_Layer.Transaction.Serialno + "|" + NoOfBobins + "|" + RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion.Rows[0]["doff_id"].ToString();
                        string str2 = str1;
                        now = DateTime.Now;
                        string newValue2 = now.ToString("dd MMM yyyy");
                        string str3 = str2.Replace("{Date}", newValue2);
                        now = DateTime.Now;
                        string newValue3 = now.ToString("HH:mm:ss");
                        string ErrorCode = str3.Replace("{Shift}", newValue3).Replace("{BatchNo}", BatchNo).Replace("{Dofflength}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion.Rows[0]["doff_length"].ToString()).Replace("{YarnDiameter}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion.Rows[0]["yarn_diameter"].ToString()).Replace("{Noofbobbins}", NoOfBobins).Replace("{TrolleyNumber}", AssetBarcode.Split('|')[1].ToString()).Replace("{TotalTrolleyWeight}", TotalTrolleyWeight).Replace("{MachineNo}", MachineBarcode.Split('|')[1].ToString()).Replace("{YarnID}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion.Rows[0]["yarn_id"].ToString()).Replace("{DoffNo}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion.Rows[0]["doff_id"].ToString()).Replace("{Denier}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion.Rows[0]["denier"].ToString()).Replace("{YarnColour}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtEtrusion.Rows[0]["yarn_colour"].ToString()).Replace("{Tareweight}", dataSet.Tables[0].Rows[0]["TareWeight"].ToString()).Replace("{Netweightofyarn}", dataSet.Tables[0].Rows[0]["Netweight"].ToString()).Replace("{Barcode}", newValue1).Replace("{Len}", newValue1.Length.ToString());
                        if (dataSet.Tables[0].Rows[0]["Status"].ToString() == "Completed")
                            this.UpdateMySqlData("Extrusion_Print_Status_Update", Value);
                        this.networkClient.Write(ErrorCode);
                    }
                    if (TransactionType == "Warping_Output")
                    {
                        string newValue4 = "";
                        string newValue5 = "";
                        for (int index = 0; index < RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWrapping.Rows.Count; ++index)
                        {
                            string str4 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                            now = DateTime.Now;
                            string newValue6 = now.ToString("dd MMM yyyy");
                            string str5 = str4.Replace("{Date}", newValue6);
                            now = DateTime.Now;
                            string newValue7 = now.ToString("HH:mm:ss");
                            string str6 = str5.Replace("{Shift}", newValue7).Replace("{WorkOrderNo}", WorkOrderNo).Replace("{Machine No}", dataSet.Tables[0].Rows[0]["machine"].ToString().Split('|')[1].ToString()).Replace("{BeamNo}", AssetBarcode.Split('|')[1].ToString()).Replace("{BeamSQNo}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWrapping.Rows[index]["beam_sequence_no"].ToString());
                            if (RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWrapping.Rows[index]["Product_Codes"].ToString() != "")
                            {
                                string str7 = RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWrapping.Rows[index]["Product_Codes"].ToString();
                                char[] chArray1 = new char[1] { '/' };
                                foreach (string str8 in str7.Split(chArray1))
                                {
                                    char[] chArray2 = new char[1] { '-' };
                                    string[] strArray = str8.Split(chArray2);
                                    if (strArray.Length != 0)
                                    {
                                        if (newValue4 == "")
                                            newValue4 = strArray[0] + "-" + strArray[1] + "-" + strArray[2] + "-" + strArray[4] + "-" + strArray[5];
                                        newValue5 = !(newValue5 == "") ? newValue5 + "/" + strArray[3] : strArray[3];
                                    }
                                }
                            }
                            string ErrorCode = str6.Replace("{ProductCode}", newValue4).Replace("{ProductCode1}", newValue5).Replace("{Width}", Width).Replace("{Length}", Length).Replace("{NoofEnds}", NoofEnds).Replace("{Barcode}", WorkOrderNo + "|" + RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWrapping.Rows[index]["beam_sequence_no"].ToString()).Replace("{Len}", (WorkOrderNo + "|" + RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWrapping.Rows[index]["beam_sequence_no"].ToString()).Length.ToString());
                            this.UpdateMySqlData("Warping_Print_Status_Update", WorkOrderNo.Split('/')[0]);
                            this.networkClient.Write(ErrorCode);
                        }
                    }
                    if (TransactionType == "Weaving_Output")
                    {
                        for (int index = 0; index < RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving.Rows.Count; ++index)
                        {
                            string str9 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                            string newValue8 = "";
                            string newValue9 = "";
                            string str10 = str9;
                            now = DateTime.Now;
                            string newValue10 = now.ToString("dd MMM yyyy");
                            string str11 = str10.Replace("{Date}", newValue10);
                            now = DateTime.Now;
                            string newValue11 = now.ToString("HH:mm:ss");
                            string str12 = str11.Replace("{Shift}", newValue11).Replace("{WorkOrderNo}", WorkOrderNo).Replace("{FabricID}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving.Rows[index]["fabric_id"].ToString());
                            if (RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving.Rows[index]["fabric_code"].ToString() != "")
                            {
                                string[] strArray = RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving.Rows[index]["fabric_code"].ToString().Split('-');
                                if (strArray.Length != 0)
                                {
                                    if (newValue8 == "")
                                        newValue8 = strArray[0] + "-" + strArray[1] + "-" + strArray[2] + "-" + strArray[4] + "-" + strArray[5];
                                    if (newValue9 == "")
                                        newValue9 = strArray[3];
                                }
                            }
                            string ErrorCode = str12.Replace("{ProductCode}", newValue8).Replace("{ProductCode1}", newValue9).Replace("{NoofPanels}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving.Rows[index]["no_of_panels"].ToString()).Replace("{Length}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving.Rows[index]["length"].ToString()).Replace("{JumboRollNo}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving.Rows[index]["roll_number"].ToString()).Replace("{Barcode}", WorkOrderNo + "|" + RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving.Rows[index]["roll_number"].ToString()).Replace("{Len}", (WorkOrderNo + "|" + RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtWeaving.Rows[index]["roll_number"].ToString()).Length.ToString());
                            this.UpdateMySqlData("Weaving_Print_Status_Update", WorkOrderNo);
                            this.networkClient.Write(ErrorCode);
                        }
                    }
                    if (TransactionType == "Knitting_Output")
                    {
                        for (int index = 0; index < RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting.Rows.Count; ++index)
                        {
                            string str13 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                            string newValue12 = "";
                            string newValue13 = "";
                            string str14 = str13;
                            now = DateTime.Now;
                            string newValue14 = now.ToString("dd MMM yyyy");
                            string str15 = str14.Replace("{Date}", newValue14);
                            now = DateTime.Now;
                            string newValue15 = now.ToString("HH:mm:ss");
                            string str16 = str15.Replace("{Shift}", newValue15).Replace("{WorkOrderNo}", WorkOrderNo).Replace("{FabricID}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting.Rows[index]["fabric_id"].ToString());
                            if (RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting.Rows[index]["fabric_code"].ToString() != "")
                            {
                                string[] strArray = RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting.Rows[index]["fabric_code"].ToString().Split('-');
                                if (strArray.Length != 0)
                                {
                                    if (newValue12 == "")
                                        newValue12 = strArray[0] + "-" + strArray[1] + "-" + strArray[2] + "-" + strArray[4] + "-" + strArray[5] + "-";
                                    if (newValue13 == "")
                                        newValue13 = strArray[3];
                                }
                            }
                            string ErrorCode = str16.Replace("{ProductCode}", newValue12).Replace("{ProductCode1}", newValue13).Replace("{NoofPanels}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting.Rows[index]["no_of_panels"].ToString()).Replace("{Length}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting.Rows[index]["length"].ToString()).Replace("{JumboRollNo}", RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting.Rows[index]["roll_number"].ToString()).Replace("{Barcode}", WorkOrderNo + "|" + RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting.Rows[index]["roll_number"].ToString()).Replace("{Len}", (WorkOrderNo + "|" + RISHI_WEB_SERVICE.Entity_Layer.Transaction.DtKnitting.Rows[index]["roll_number"].ToString()).Length.ToString());
                            this.UpdateMySqlData("Knitting_Print_Status_Update", WorkOrderNo);
                            this.networkClient.Write(ErrorCode);
                        }
                    }
                    if (TransactionType == "Inspection_Output")
                    {
                        string str17 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                        now = DateTime.Now;
                        string newValue16 = now.ToString("dd MMM yyyy");
                        string str18 = str17.Replace("{Date}", newValue16);
                        now = DateTime.Now;
                        string newValue17 = now.ToString("HH:mm:ss");
                        string str19 = str18.Replace("{Shift}", newValue17).Replace("{WorkOrderNo}", WorkOrderNo).Replace("{FabricID}", dataSet.Tables[0].Rows[0]["FabricID"].ToString()).Replace("{ProductCode}", dataSet.Tables[0].Rows[0]["ProductCode"].ToString()).Replace("{FGNo}", dataSet.Tables[0].Rows[0]["FGNo"].ToString()).Replace("{Mesh}", dataSet.Tables[0].Rows[0]["Mesh"].ToString()).Replace("{Colour}", dataSet.Tables[0].Rows[0]["Color"].ToString()).Replace("{GSM}", dataSet.Tables[0].Rows[0]["GSM"].ToString()).Replace("{Width}", dataSet.Tables[0].Rows[0][nameof(Width)].ToString()).Replace("{Length}", dataSet.Tables[0].Rows[0][nameof(Length)].ToString());
                        if (dataSet.Tables[0].Rows[0]["Remarks0"].ToString() == "")
                            str19 = str19.Replace("Importing Company Name and Address", "");
                        this.networkClient.Write(str19.Replace("{Remarks}", dataSet.Tables[0].Rows[0]["Remarks0"].ToString()).Replace("{Remarks1}", dataSet.Tables[0].Rows[0]["Remarks1"].ToString()).Replace("{Remarks2}", dataSet.Tables[0].Rows[0]["Remarks2"].ToString()).Replace("{Remarks3}", dataSet.Tables[0].Rows[0]["Remarks3"].ToString()).Replace("{Remarks4}", dataSet.Tables[0].Rows[0]["Remarks4"].ToString()).Replace("{Barcode}", dataSet.Tables[0].Rows[0]["FGNo"].ToString()).Replace("{Len}", dataSet.Tables[0].Rows[0]["FGNo"].ToString().Length.ToString()));
                    }
                    this.networkClient.Dispose();
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                this.networkClient.Dispose();
                throw ex;
            }
        }
    }
}
