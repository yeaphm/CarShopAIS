using FirebirdSql.Data.FirebirdClient;

namespace CarShopAIS
{
    class FbManager
    {
        public static string basePath; // Base location

        public static FbConnectionStringBuilder cs; // Object of the string connection
        public static FbConnection fbConn;

        /// <summary>
        /// Creating connection to the data base
        /// </summary>
        public static void DB_Connect()
        {
            basePath = System.IO.Path.GetFullPath("../Data/CARSHOP.FDB");

            cs = new FbConnectionStringBuilder();
            fbConn = new FbConnection();

            cs.DataSource = "localhost";    // Computer name, where base is located
            cs.UserID = "SYSDBA";           // Username of the base
            cs.Password = "masterkey";      // Password of the user
            cs.Database = basePath;         // Base location
            cs.Charset = "win1251";         // Encoding
            string ConnString = cs.ToString();

            fbConn.ConnectionString = ConnString;
        }
    }
}
