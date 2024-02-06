using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;

namespace CarShopAIS
{
    class ClientTable
    {
        /// <summary>
        /// Load information about clients
        /// </summary>
        /// <returns> Datatable with clients' info </returns>
        public static DataTable DataLoad()
        {
            FbManager.fbConn.Open(); 

            DataTable ClientDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "SELECT CLIENT_ID, CLIENT_SURNAME as \"Фамилия\", " +
                "CLIENT_NAME as \"Имя\", CLIENT_PATRONYMIC as \"Отчество\", " +
                "CLIENT_PASSPORT as \"Паспорт\" " +
                "from CLIENT;",
                FbManager.fbConn);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            ClientDT.Load(dr);

            FbManager.fbConn.Close(); 

            return ClientDT;
        }

        /// <summary>
        /// Add new client to the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="patronymic"></param>
        /// <param name="passport"></param>
        public static void AddClient(string name, string surname, string patronymic, string passport)
        {
            FbManager.fbConn.Open(); 

            FbCommand cmd = new FbCommand(
                "INSERT INTO CLIENT (client_name, client_surname, client_patronymic, client_passport) " +
                "values(@name, @surname, @patronymic, @passport); ",
                FbManager.fbConn);

            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("surname", surname);
            cmd.Parameters.AddWithValue("patronymic", patronymic);
            cmd.Parameters.AddWithValue("passport", passport);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            FbManager.fbConn.Close(); 
        }

        /// <summary>
        /// Delete client from the database
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static bool DeleteClient(int clientID)
        {

            if (FbManager.fbConn.State == ConnectionState.Closed)
            {
                FbManager.fbConn.Open(); 
            }

            FbCommand cmdDeleteCl = new FbCommand(
                "DELETE FROM client " +
                "WHERE client_id = @id",
                FbManager.fbConn);

            cmdDeleteCl.Parameters.AddWithValue("id", clientID);

            FbTransaction fbt = FbManager.fbConn.BeginTransaction();

            cmdDeleteCl.Transaction = fbt;

            try
            {
                cmdDeleteCl.ExecuteNonQuery();
                fbt.Commit();

                cmdDeleteCl.Dispose();
                FbManager.fbConn.Close(); 

                return true;
            }
            catch
            {
                fbt.Rollback();
                cmdDeleteCl.Dispose();
                FbManager.fbConn.Close(); 

                return false;
            }
        }

        /// <summary>
        /// Get client's ID by passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        public static int GetClientID(string passport)
        {
            int clientID = -1;

            FbManager.fbConn.Open();

            FbCommand cmd = new FbCommand();
            cmd.Connection = FbManager.fbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_CLIENT_ID_PROC";

            cmd.Parameters.AddWithValue("passport", passport);
            cmd.Parameters.Add(new FbParameter("clientID", FbDbType.VarChar, 5000));
            cmd.Parameters["clientID"].Direction = ParameterDirection.Output;
            
            cmd.ExecuteNonQuery();

            try
            {
                clientID = Convert.ToInt32(cmd.Parameters["clientID"].Value);
            }
            catch
            {
                clientID = -1;
            }
            
            cmd.Dispose();
            FbManager.fbConn.Close();

            return clientID;
        }
    }
}
