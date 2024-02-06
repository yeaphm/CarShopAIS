using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;

namespace CarShopAIS
{
    class PurchaseTable
    {
        /// <summary>
        /// Load table with all purchases
        /// </summary>
        /// <returns> All purchases DataTable </returns>
        public static DataTable AllDataLoad()
        {
            FbManager.fbConn.Open(); 

            DataTable PurchgaseDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "SELECT pc.CLIENT_ID, pc.CAR_ID, cl.CLIENT_SURNAME AS \"Фамилия\", " +
                "cl.CLIENT_NAME AS \"Имя\", cl.CLIENT_PASSPORT AS \"Паспорт\", " +
                "br.BRAND_NAME AS \"Марка\", md.MODEL_NAME AS \"Модель\", " +
                "car.CAR_VIN AS \"VIN\", pc.PURCHASE_DATE AS \"Дата покупки\", " +
                "pc.PURCHASE_PRICE AS \"Цена\" " +
                "FROM PURCHASE pc " +
                "JOIN CLIENT cl ON cl.client_id = pc.client_id " +
                "JOIN CAR ON car.car_id = pc.car_id " +
                "JOIN MODEL md ON md.model_id = car.model_id " +
                "JOIN BRAND br ON br.brand_id = md.brand_id " +
                "ORDER BY pc.purchase_date desc; ",
                FbManager.fbConn);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            PurchgaseDT.Load(dr);

            FbManager.fbConn.Close(); 

            return PurchgaseDT;
        }

        /// <summary>
        /// Load table with all purchases between special dates
        /// </summary>
        /// <param name="Date1"></param>
        /// <param name="Date2"></param>
        /// <returns></returns>
        public static DataTable AllDataLoad(string Date1, string Date2)
        {
            FbManager.fbConn.Open(); 

            DataTable PurchgaseDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "SELECT pc.CLIENT_ID, pc.CAR_ID, cl.CLIENT_SURNAME AS \"Фамилия\", " +
                "cl.CLIENT_NAME AS \"Имя\", cl.CLIENT_PASSPORT AS \"Паспорт\", " +
                "br.BRAND_NAME AS \"Марка\", md.MODEL_NAME AS \"Модель\", " +
                "car.CAR_VIN AS \"VIN\", pc.PURCHASE_DATE AS \"Дата покупки\", " +
                "pc.PURCHASE_PRICE AS \"Цена\" " +
                "FROM PURCHASE pc " +
                "JOIN CLIENT cl ON cl.client_id = pc.client_id " +
                "JOIN CAR ON car.car_id = pc.car_id " +
                "JOIN MODEL md ON md.model_id = car.model_id " +
                "JOIN BRAND br ON br.brand_id = md.brand_id " +
                "WHERE pc.purchase_date BETWEEN @date1 AND @date2 " +
                "ORDER BY pc.purchase_date desc; ",
                FbManager.fbConn);

            cmd.Parameters.AddWithValue("date1", Date1);
            cmd.Parameters.AddWithValue("date2", Date2);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            PurchgaseDT.Load(dr);

            FbManager.fbConn.Close(); 

            return PurchgaseDT;
        }

        /// <summary>
        /// Get sales amount grouped by models
        /// </summary>
        /// <returns> DataTable with sales info </returns>
        public static DataTable SoldModelsCount()
        {
            FbManager.fbConn.Open(); 

            DataTable PurchgaseDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "select br.brand_name AS \"Марка\",  md.MODEL_NAME AS \"Модель\", " +
                "count(*) AS \"Кол-во продаж\", " +
                "sum(pc.purchase_price) AS \"Сумма (руб.)\" from purchase pc " +
                "join car on car.car_id = pc.car_id " +
                "join model md on md.model_id = car.model_id " +
                "join brand br on br.brand_id = md.brand_id " +
                "group by md.MODEL_NAME, br.brand_name " +
                "order by count(*) desc, br.brand_name, md.model_name;",
                FbManager.fbConn);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            PurchgaseDT.Load(dr);

            FbManager.fbConn.Close(); 

            return PurchgaseDT;
        }

        /// <summary>
        /// Get sales amount grouped by models between special dates
        /// </summary>
        /// <param name="Date1"></param>
        /// <param name="Date2"></param>
        /// <returns></returns>
        public static DataTable SoldModelsCount(string Date1, string Date2)
        {
            FbManager.fbConn.Open(); 

            DataTable PurchgaseDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "select br.brand_name AS \"Марка\",  md.MODEL_NAME AS \"Модель\", " +
                "count(*) AS \"Кол-во продаж\", " +
                "sum(pc.purchase_price) AS \"Сумма (руб.)\" from purchase pc " +
                "join car on car.car_id = pc.car_id " +
                "join model md on md.model_id = car.model_id " +
                "join brand br on br.brand_id = md.brand_id " +
                "WHERE pc.purchase_date BETWEEN @date1 AND @date2 " +
                "group by md.MODEL_NAME, br.brand_name " +
                "order by count(*) desc, br.brand_name, md.model_name;",
                FbManager.fbConn);

            cmd.Parameters.AddWithValue("date1", Date1);
            cmd.Parameters.AddWithValue("date2", Date2);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            PurchgaseDT.Load(dr);

            FbManager.fbConn.Close(); 

            return PurchgaseDT;
        }

        /// <summary>
        /// Get sales amount grouped by marks
        /// </summary>
        /// <returns> DataTable with sales info </returns>
        public static DataTable SoldMarksCount()
        {
            FbManager.fbConn.Open(); 

            DataTable PurchgaseDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "select br.brand_name AS \"Марка\", " +
                "count(*) AS \"Кол-во продаж\", " +
                "sum(pc.purchase_price) AS \"Сумма (руб.)\" from purchase pc " +
                "join car on car.car_id = pc.car_id " +
                "join model md on md.model_id = car.model_id " +
                "join brand br on br.brand_id = md.brand_id " +
                "group by br.brand_name " +
                "order by count(*) desc;",
                FbManager.fbConn);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            PurchgaseDT.Load(dr);

            FbManager.fbConn.Close(); 

            return PurchgaseDT;
        }

        /// <summary>
        /// Get sales amount grouped by marks between special dates
        /// </summary>
        /// <param name="Date1"></param>
        /// <param name="Date2"></param>
        /// <returns></returns>
        public static DataTable SoldMarksCount(string Date1, string Date2)
        {
            FbManager.fbConn.Open(); 

            DataTable PurchgaseDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "select br.brand_name AS \"Марка\", " +
                "count(*) AS \"Кол-во продаж\", " +
                "sum(pc.purchase_price) AS \"Сумма (руб.)\" from purchase pc " +
                "join car on car.car_id = pc.car_id " +
                "join model md on md.model_id = car.model_id " +
                "join brand br on br.brand_id = md.brand_id " +
                "WHERE pc.purchase_date BETWEEN @date1 AND @date2 " +
                "group by br.brand_name " +
                "order by count(*) desc;",
                FbManager.fbConn);

            cmd.Parameters.AddWithValue("date1", Date1);
            cmd.Parameters.AddWithValue("date2", Date2);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            PurchgaseDT.Load(dr);

            FbManager.fbConn.Close(); 

            return PurchgaseDT;
        }

        /// <summary>
        /// Delete purchase of the current car
        /// </summary>
        /// <param name="carID"></param>
        /// <returns></returns>
        public static bool DeletePurchase(int carID)
        {
            if (FbManager.fbConn.State == ConnectionState.Closed)
            {
                FbManager.fbConn.Open();
            }

            FbCommand cmdCarDel = new FbCommand(
                "DELETE FROM purchase WHERE car_id = @id;",
                FbManager.fbConn);

            FbCommand cmdCarUpdate = new FbCommand(
                "UPDATE car SET car_state = \'В наличии\' WHERE car_id = @id;",
                FbManager.fbConn);

            cmdCarDel.Parameters.AddWithValue("id", carID);
            cmdCarUpdate.Parameters.AddWithValue("id", carID);

            FbTransaction DelPurchaseTransaction = FbManager.fbConn.BeginTransaction();

            cmdCarDel.Transaction = DelPurchaseTransaction;
            cmdCarUpdate.Transaction = DelPurchaseTransaction;

            try
            {
                cmdCarDel.ExecuteNonQuery();
                cmdCarUpdate.ExecuteNonQuery();

                DelPurchaseTransaction.Commit();

                cmdCarDel.Dispose();
                cmdCarUpdate.Dispose();

                FbManager.fbConn.Close();

                return true;
            }
            catch
            {
                DelPurchaseTransaction.Rollback();

                cmdCarDel.Dispose();
                cmdCarUpdate.Dispose();

                FbManager.fbConn.Close();

                return false;
            }
        }

        /// <summary>
        /// Add new purchase
        /// </summary>
        /// <param name="carVIN"></param>
        /// <param name="passport"></param>
        /// <param name="date"></param>
        /// <param name="price"></param>
        public static void AddPurchase(string carVIN, string clientPassport, string date, decimal price)
        {
            if (FbManager.fbConn.State == ConnectionState.Closed)
            {
                FbManager.fbConn.Open();
            }

            // Purchase add command
            FbCommand cmdAddPurch = new FbCommand(
                "INSERT INTO purchase (client_id, car_id, purchase_date, purchase_price) " +
                "VALUES ((SELECT client_id FROM client WHERE client_passport = @passport), " +
                "(SELECT car_id FROM car where car_vin = @vin), " +
                "@date, @price);",
                FbManager.fbConn);

            // Change car's state command
            FbCommand cmdChangeState = new FbCommand(
                "UPDATE car SET car_state = 'Продано' WHERE car_vin = @vin",
                FbManager.fbConn);

            // Set parameters
            cmdAddPurch.Parameters.AddWithValue("passport", clientPassport);
            cmdAddPurch.Parameters.AddWithValue("vin", carVIN);
            cmdAddPurch.Parameters.AddWithValue("date", date);
            cmdAddPurch.Parameters.AddWithValue("price", price);

            cmdChangeState.Parameters.AddWithValue("vin", carVIN);

            FbTransaction fbt = FbManager.fbConn.BeginTransaction();

            cmdAddPurch.Transaction = fbt;
            cmdChangeState.Transaction = fbt;

            cmdAddPurch.ExecuteNonQuery();
            cmdChangeState.ExecuteNonQuery();

            fbt.Commit();

            cmdAddPurch.Dispose();
            cmdChangeState.Dispose();
            FbManager.fbConn.Close(); 
        }

        /// <summary>
        /// Get sum price info about all purchases
        /// </summary>
        /// <returns></returns>
        public static decimal SumSales()
        {
            decimal Sum = 0;

            FbManager.fbConn.Open();

            FbCommand cmd = new FbCommand();
            cmd.Connection = FbManager.fbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_SALES_SUM_PROC";

            cmd.Parameters.Add(new FbParameter("sales_sum", FbDbType.VarChar, 5000));
            cmd.Parameters["sales_sum"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            try
            {
                Sum = Convert.ToDecimal(cmd.Parameters["sales_sum"].Value);
            }
            catch
            {
                Sum = 0;
            }

            cmd.Dispose();
            FbManager.fbConn.Close();

            return Sum;
        }

        /// <summary>
        /// Get sum price info about all purchases in special dates
        /// </summary>
        /// <param name="Date1"></param>
        /// <param name="Date2"></param>
        /// <returns></returns>
        public static decimal SumSales(string Date2, string Date1)
        {
            decimal Sum = 0;

            FbManager.fbConn.Open();

            FbCommand cmd = new FbCommand();
            cmd.Connection = FbManager.fbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_SALES_SUM_DATE_PROC";

            cmd.Parameters.AddWithValue("date1", Date1);
            cmd.Parameters.AddWithValue("date2", Date2);
            cmd.Parameters.Add(new FbParameter("sales_sum", FbDbType.VarChar, 5000));
            cmd.Parameters["sales_sum"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            try
            {
                Sum = Convert.ToDecimal(cmd.Parameters["sales_sum"].Value);
            }
            catch
            {
                Sum = 0;
            }

            cmd.Dispose();
            FbManager.fbConn.Close();

            return Sum;
        }

        /// <summary>
        /// Get count of sold cars
        /// </summary>
        /// <returns></returns>
        public static int CountSales()
        {
            int CountCars = 0;

            FbManager.fbConn.Open();

            FbCommand cmd = new FbCommand();
            cmd.Connection = FbManager.fbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_COUNT_SALES_PROC";

            cmd.Parameters.Add(new FbParameter("sales_count", FbDbType.VarChar, 5000));
            cmd.Parameters["sales_count"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            try
            {
                CountCars = Convert.ToInt32(cmd.Parameters["sales_count"].Value);
            }
            catch
            {
                CountCars = 0;
            }

            cmd.Dispose();
            FbManager.fbConn.Close();

            return CountCars;
        }

        /// <summary>
        /// Get count of sold cars in special dates
        /// </summary>
        /// <param name="Date1"></param>
        /// <param name="Date2"></param>
        /// <returns></returns>
        public static int CountSales(string Date2, string Date1)
        {
            int CountCars = 0;

            FbManager.fbConn.Open();

            FbCommand cmd = new FbCommand();
            cmd.Connection = FbManager.fbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_COUNT_SALES_DATE_PROC";

            cmd.Parameters.AddWithValue("date1", Date1);
            cmd.Parameters.AddWithValue("date2", Date2);
            cmd.Parameters.Add(new FbParameter("sales_count", FbDbType.VarChar, 5000));
            cmd.Parameters["sales_count"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            try
            {
                CountCars = Convert.ToInt32(cmd.Parameters["sales_count"].Value);
            }
            catch
            {
                CountCars = 0;
            }

            cmd.Dispose();
            FbManager.fbConn.Close();

            return CountCars;
        }
    }
}
