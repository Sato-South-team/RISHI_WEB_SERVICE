// Decompiled with JetBrains decompiler
// Type: RISHI_WEB_SERVICE.Entity_Layer.DatabaseSettings
// Assembly: RISHI_WEB_SERVICE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FCDBD3EF-8149-4CAD-A076-8C736CE9926A
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\WEB_SERVICE\bin\RISHI_WEB_SERVICE.dll

namespace RISHI_WEB_SERVICE.Entity_Layer
{
    public static class DatabaseSettings
    {
        private static string _SqldbServer;
        private static string _SqlDBName;
        private static string _SqlDBUserID;
        private static string _SqlDBPassword;
        private static string _MySqldbServer;
        private static string _MySqlDBName;
        private static string _MySqlDBUserID;
        private static string _MySqlDBPassword;

        public static string SqlDBPassword
        {
            get => DatabaseSettings._SqlDBPassword;
            set => DatabaseSettings._SqlDBPassword = value;
        }

        public static string SqlDBUserID
        {
            get => DatabaseSettings._SqlDBUserID;
            set => DatabaseSettings._SqlDBUserID = value;
        }

        public static string SqlDBName
        {
            get => DatabaseSettings._SqlDBName;
            set => DatabaseSettings._SqlDBName = value;
        }

        public static string SqldbServer
        {
            get => DatabaseSettings._SqldbServer;
            set => DatabaseSettings._SqldbServer = value;
        }

        public static string MySqldbServer
        {
            get => DatabaseSettings._MySqldbServer;
            set => DatabaseSettings._MySqldbServer = value;
        }

        public static string MySqlDBName
        {
            get => DatabaseSettings._MySqlDBName;
            set => DatabaseSettings._MySqlDBName = value;
        }

        public static string MySqlDBUserID
        {
            get => DatabaseSettings._MySqlDBUserID;
            set => DatabaseSettings._MySqlDBUserID = value;
        }

        public static string MySqlDBPassword
        {
            get => DatabaseSettings._MySqlDBPassword;
            set => DatabaseSettings._MySqlDBPassword = value;
        }
    }
}
