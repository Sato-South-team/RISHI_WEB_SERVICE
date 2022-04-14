// Decompiled with JetBrains decompiler
// Type: RISHI_WEB_SERVICE.Entity_Layer.Transaction
// Assembly: RISHI_WEB_SERVICE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FCDBD3EF-8149-4CAD-A076-8C736CE9926A
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\WEB_SERVICE\bin\RISHI_WEB_SERVICE.dll

using System.Data;

namespace RISHI_WEB_SERVICE.Entity_Layer
{
    public static class Transaction
    {
        private static DataTable _dtEtrusion;
        private static DataTable _dtWrapping;
        private static DataTable _dtWeaving;
        private static DataTable _dtKnitting;
        private static string _Type;
        private static string _TransactionType;
        private static string _UserID;
        private static string _Password;
        private static string _MachineBarcode;
        private static string _ItemBarcode;
        private static string _Serialno;
        private static string _Remarks;
        private static string _InvoiceNo;
        private static string _BatchNo;
        private static string _NoofBobbins;
        private static string _AssetBarcode;
        private static string _TotalTrolleyWeigt;
        private static string _Width;
        private static string _Length;
        private static string _NoOfEnds;
        private static string _WOrkOrderNo;
        private static string _FGWeight;
        private static string _CustCode;

        public static string Type
        {
            get => Transaction._Type;
            set => Transaction._Type = value;
        }

        public static string TransactionType
        {
            get => Transaction._TransactionType;
            set => Transaction._TransactionType = value;
        }

        public static string UserID
        {
            get => Transaction._UserID;
            set => Transaction._UserID = value;
        }

        public static string Password
        {
            get => Transaction._Password;
            set => Transaction._Password = value;
        }

        public static string Serialno
        {
            get => Transaction._Serialno;
            set => Transaction._Serialno = value;
        }

        public static string Remarks
        {
            get => Transaction._Remarks;
            set => Transaction._Remarks = value;
        }

        public static DataTable DtEtrusion
        {
            get => Transaction._dtEtrusion;
            set => Transaction._dtEtrusion = value;
        }

        public static DataTable DtWrapping
        {
            get => Transaction._dtWrapping;
            set => Transaction._dtWrapping = value;
        }

        public static DataTable DtWeaving
        {
            get => Transaction._dtWeaving;
            set => Transaction._dtWeaving = value;
        }

        public static string MachineBarcode
        {
            get => Transaction._MachineBarcode;
            set => Transaction._MachineBarcode = value;
        }

        public static string ItemBarcode
        {
            get => Transaction._ItemBarcode;
            set => Transaction._ItemBarcode = value;
        }

        public static string BatchNo
        {
            get => Transaction._BatchNo;
            set => Transaction._BatchNo = value;
        }

        public static string NoofBobbins
        {
            get => Transaction._NoofBobbins;
            set => Transaction._NoofBobbins = value;
        }

        public static string AssetBarcode
        {
            get => Transaction._AssetBarcode;
            set => Transaction._AssetBarcode = value;
        }

        public static string TotalTrolleyWeigt
        {
            get => Transaction._TotalTrolleyWeigt;
            set => Transaction._TotalTrolleyWeigt = value;
        }

        public static string Width
        {
            get => Transaction._Width;
            set => Transaction._Width = value;
        }

        public static string Length
        {
            get => Transaction._Length;
            set => Transaction._Length = value;
        }

        public static string NoOfEnds
        {
            get => Transaction._NoOfEnds;
            set => Transaction._NoOfEnds = value;
        }

        public static string WOrkOrderNo
        {
            get => Transaction._WOrkOrderNo;
            set => Transaction._WOrkOrderNo = value;
        }

        public static DataTable DtKnitting
        {
            get => Transaction._dtKnitting;
            set => Transaction._dtKnitting = value;
        }

        public static string FGWeight
        {
            get => Transaction._FGWeight;
            set => Transaction._FGWeight = value;
        }

        public static string CustCode
        {
            get => Transaction._CustCode;
            set => Transaction._CustCode = value;
        }

        public static string InvoiceNo
        {
            get => Transaction._InvoiceNo;
            set => Transaction._InvoiceNo = value;
        }
    }
}
