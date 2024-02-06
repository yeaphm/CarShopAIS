using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.IO;
using System.Collections;
using System.Drawing;

namespace CarShopAIS
{
    class CarTable
    {
        /// <summary>
        /// Car's table loading
        /// </summary>
        /// <returns> Car's DataTable </returns>
        public static DataTable DataLoad()
        {
            FbManager.fbConn.Open(); 

            DataTable CarDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "SELECT car.CAR_ID, cf.CONFIG_ID, " +
                "br.BRAND_NAME AS \"Марка\", md.MODEL_NAME AS \"Модель\", " +
                "ct.COUNTRY_NAME AS \"Производитель\", car.CAR_VIN AS \"VIN\", " +
                "car.CAR_STATE AS \"Статус\" " +
                "FROM CAR JOIN MODEL md ON car.MODEL_ID = md.MODEL_ID " +
                "JOIN BRAND br ON md.BRAND_ID = br.BRAND_ID " +
                "JOIN COUNTRY ct ON car.COUNTRY_ID = ct.COUNTRY_ID " +
                "JOIN CONFIGURATION cf ON car.CONFIG_ID = cf.CONFIG_ID " +
                "ORDER BY br.BRAND_ID, md.MODEL_ID;",
                FbManager.fbConn);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            CarDT.Load(dr);

            FbManager.fbConn.Close(); 

            return CarDT;
        }

        /// <summary>
        /// Get car's configuration and state
        /// </summary>
        /// <param name="configID"></param>
        /// <returns> Config DataTable </returns>
        public static DataTable GetConfig(int configID)
        {
            FbManager.fbConn.Open(); 

            DataTable ConfigDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "SELECT bdy.BODY_NAME,  en.ENGINE_NAME, " +
                "cf.CONFIG_ENGINE_VOLUME, cf.CONFIG_DOORS, " +
                "cf.CONFIG_SEATS, car.CAR_STATE " +
                "FROM CONFIGURATION cf " +
                "JOIN BODY bdy ON bdy.BODY_ID = cf.BODY_ID " +
                "JOIN ENGINE_TYPE en ON cf.ENGINE_TYPE_ID = en.ENGINE_TYPE_ID " +
                "JOIN CAR ON cf.CONFIG_ID = car.CONFIG_ID " +
                "WHERE cf.CONFIG_ID = @config_ID; ",
                FbManager.fbConn);

            cmd.Parameters.AddWithValue("config_ID", configID);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            ConfigDT.Load(dr);

            FbManager.fbConn.Close(); 

            return ConfigDT;
        }

        /// <summary>
        /// Get car's image 
        /// </summary>
        /// <returns> Image </returns>
        public static Image GetCarImage(int car_id)
        {
            Image image = null;

            FbManager.fbConn.Open();

            FbCommand cmd = new FbCommand($"SELECT car_photo FROM car WHERE car_id = {car_id}", FbManager.fbConn);
            FbDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    byte[] byteBLOBData = (byte[])reader["car_photo"];
                    image = ToImage(byteBLOBData);
                }
            }
            catch
            {
                image = null;
            }
            FbManager.fbConn.Close();

            return image;
        }

        /// <summary>
        /// Convert byte data to image
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns> image </returns>
        private static Image ToImage(byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }
            Image img;
            using (MemoryStream stream = new MemoryStream(imageData))
            {
                using (Image temp = Image.FromStream(stream))
                {
                    img = new Bitmap(temp);
                }
            }
            return img;
        }

        /// <summary>
        /// Updating car's image
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="image"></param>
        public static void UpdateCarImage(string vin, Image image)
        {
            FbCommand cmd;

            if (image != null)
            {
                cmd = new FbCommand("UPDATE car SET car_photo = @BLOBData WHERE car_vin = @cvin", FbManager.fbConn);

                //Save image from image variable into MemoryStream object.
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                //Read from MemoryStream into Byte array.
                Byte[] bytBLOBData = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(bytBLOBData, 0, Convert.ToInt32(ms.Length));

                // Create parameter to insert statement that contains image.
                FbParameter prm = new FbParameter("@BLOBData", FbDbType.Binary, bytBLOBData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytBLOBData);

                // Set parameters for the other fields
                cmd.Parameters.AddWithValue("cvin", vin);
                cmd.Parameters.Add(prm);
            }
            else
            {
                cmd = new FbCommand("UPDATE car SET car_photo = null WHERE car_vin = @cvin", FbManager.fbConn); 
                cmd.Parameters.AddWithValue("cvin", vin); 
            }

            FbManager.fbConn.Open();
            cmd.ExecuteNonQuery();
            FbManager.fbConn.Close();
        }

        /// <summary>
        /// Update car's state
        /// </summary>
        /// <param name="carID"></param>
        /// <param name="carState"></param>
        public static void UpdateCarState(int carID, string carState)
        {
            FbCommand cmd = new FbCommand("UPDATE car SET car_state = @state WHERE car_id = @id", FbManager.fbConn);

            cmd.Parameters.AddWithValue("id", carID);
            cmd.Parameters.AddWithValue("state", carState);

            FbManager.fbConn.Open();
            cmd.ExecuteNonQuery();
            FbManager.fbConn.Close();
        }

        /// <summary>
        /// Add new car to the database
        /// </summary>
        /// <param name="modelID"></param>
        /// <param name="countryID"></param>
        /// <param name="carState"></param>
        /// <param name="carVIN"></param>
        /// <param name="bodyID"></param>
        /// <param name="doors"></param>
        /// <param name="seats"></param>
        /// <param name="engineID"></param>
        /// <param name="engineVol"></param>
        /// <returns></returns>
        public static bool AddCar(string modelName, int countryID, string carState, string carVIN,
            int bodyID, int doors, int seats, int engineID, double engineVol)
        {
            // Increment all combobox values, to connect them with data base fields
            countryID++;
            bodyID++;
            engineID++;

            if (FbManager.fbConn.State == ConnectionState.Closed)
            {
                FbManager.fbConn.Open(); 
            }
            
            // Configuration add command
            FbCommand cmdConfig = new FbCommand(
                "INSERT INTO configuration (body_id, config_doors, config_seats, " +
                "engine_type_id, config_engine_volume) " +
                "values(@body, @doorsNum, @seatsNum, @engineTypeID, @engineVol); ",
                FbManager.fbConn);

            // Car add command
            FbCommand cmdCar = new FbCommand(
                "INSERT INTO car (model_id, country_id, config_id, car_state, car_vin) " +
                "values((SELECT model_id FROM model WHERE model_name = @model), @country, (SELECT MAX(config_id) FROM configuration), @state, @vin);",
                FbManager.fbConn);

            // Set parameters
            cmdConfig.Parameters.AddWithValue("body", bodyID);
            cmdConfig.Parameters.AddWithValue("doorsNum", doors);
            cmdConfig.Parameters.AddWithValue("seatsNum", seats);
            cmdConfig.Parameters.AddWithValue("engineTypeID", engineID);
            cmdConfig.Parameters.AddWithValue("engineVol", engineVol);

            cmdCar.Parameters.AddWithValue("model", modelName);
            cmdCar.Parameters.AddWithValue("country", countryID);
            cmdCar.Parameters.AddWithValue("state", carState);
            cmdCar.Parameters.AddWithValue("vin", carVIN);

            FbTransaction fbt = FbManager.fbConn.BeginTransaction(); 

            cmdConfig.Transaction = fbt; 
            cmdCar.Transaction = fbt;

            try
            {
                cmdConfig.ExecuteNonQuery(); 
                cmdCar.ExecuteNonQuery();

                fbt.Commit(); 

                cmdConfig.Dispose();
                cmdCar.Dispose();

                FbManager.fbConn.Close(); 

                return true;
            }
            catch 
            {
                fbt.Rollback();

                cmdConfig.Dispose();
                cmdCar.Dispose();

                FbManager.fbConn.Close();

                return false;
            }
        }

        /// <summary>
        /// Delete car from the database
        /// </summary>
        /// <param name="carID"></param>
        /// <returns></returns>
        public static bool DeleteCar(int carID)
        {
            if (FbManager.fbConn.State == ConnectionState.Closed)
            {
                FbManager.fbConn.Open(); 
            }

            FbCommand cmdPurchase = new FbCommand(
                "DELETE FROM purchase WHERE car_id = @id",
                FbManager.fbConn);

            FbCommand cmdCar = new FbCommand(
                "DELETE FROM car WHERE car_id = @id",
                FbManager.fbConn);

            cmdPurchase.Parameters.AddWithValue("id", carID);
            cmdCar.Parameters.AddWithValue("id", carID);

            FbTransaction fbt = FbManager.fbConn.BeginTransaction();

            cmdPurchase.Transaction = fbt;
            cmdCar.Transaction = fbt;

            try
            {
                cmdPurchase.ExecuteNonQuery();
                cmdCar.ExecuteNonQuery();

                fbt.Commit();

                cmdPurchase.Dispose();
                cmdCar.Dispose();

                FbManager.fbConn.Close(); 

                return true;
            }
            catch 
            {
                fbt.Rollback();

                cmdPurchase.Dispose();
                cmdCar.Dispose();

                FbManager.fbConn.Close();

                return false;
            }
        }

        /// <summary>
        /// Get car's ID by VIN
        /// </summary>
        /// <param name="carVIN"></param>
        /// <returns></returns>
        public static int GetCarID(string carVIN)
        {
            int carID = -1;

            FbManager.fbConn.Open();

            FbCommand cmd = new FbCommand();
            cmd.Connection = FbManager.fbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_CAR_ID_PROC";

            cmd.Parameters.AddWithValue("vin", carVIN);
            cmd.Parameters.Add(new FbParameter("carID", FbDbType.VarChar, 5000));
            cmd.Parameters["carID"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            try
            {
                carID = Convert.ToInt32(cmd.Parameters["carID"].Value);
            }
            catch
            {
                carID = -1;
            }

            cmd.Dispose();
            FbManager.fbConn.Close();

            return carID;
        }

        /// <summary>
        /// Get car's state by VIN
        /// </summary>
        /// <param name="carVIN"></param>
        /// <returns></returns>
        public static string GetCarState(string carVIN)
        {
            string carState = null;

            FbManager.fbConn.Open();

            FbCommand cmd = new FbCommand();
            cmd.Connection = FbManager.fbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_CAR_STATE_PROC";

            cmd.Parameters.AddWithValue("vin", carVIN);
            cmd.Parameters.Add(new FbParameter("state", FbDbType.VarChar, 5000));
            cmd.Parameters["state"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            carState = Convert.ToString(cmd.Parameters["state"].Value);

            cmd.Dispose();
            FbManager.fbConn.Close();

            return carState;
        }

        #region Lists of extra tables

        /// <summary>
        /// Get list of the all brands from database
        /// </summary>
        /// <returns> List of brands </returns>
        public static ArrayList GetBrandList()
        {
            ArrayList BrandList = new ArrayList();

            FbManager.fbConn.Open(); 

            DataTable BrandDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "select list(brand.brand_name) from brand",
                FbManager.fbConn);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            BrandDT.Load(dr);

            FbManager.fbConn.Close(); 

            BrandList.AddRange(BrandDT.Rows[0][0].ToString().Split(','));

            return BrandList;
        }

        /// <summary>
        /// Get list of the models connected with current model
        /// </summary>
        /// <returns> List of models </returns>
        public static ArrayList GetModelList(int brandID)
        {
            brandID++;

            ArrayList ModelList = new ArrayList();

            FbManager.fbConn.Open(); 

            DataTable ModelDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "SELECT LIST(model.model_name) FROM model WHERE model.brand_id = @ID;",
                FbManager.fbConn);

            cmd.Parameters.AddWithValue("ID", brandID);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            ModelDT.Load(dr);

            FbManager.fbConn.Close(); 

            ModelList.AddRange(ModelDT.Rows[0][0].ToString().Split(','));

            return ModelList;
        }

        /// <summary>
        /// Get list of the all countries from database
        /// </summary>
        /// <returns> List of coutries </returns>
        public static ArrayList GetCountryList()
        {
            ArrayList CountryList = new ArrayList();

            FbManager.fbConn.Open(); 

            DataTable CountryDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "SELECT LIST(country_name) FROM country",
                FbManager.fbConn);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            CountryDT.Load(dr);

            FbManager.fbConn.Close(); 

            CountryList.AddRange(CountryDT.Rows[0][0].ToString().Split(','));

            return CountryList;
        }

        /// <summary>
        /// Get list of the all bodies from database
        /// </summary>
        /// <returns> List of bodies </returns>
        public static ArrayList GetBodyList()
        {
            ArrayList BodyList = new ArrayList();

            FbManager.fbConn.Open(); 

            DataTable BodyDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "SELECT LIST(body_name) FROM body",
                FbManager.fbConn);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            BodyDT.Load(dr);

            FbManager.fbConn.Close(); 

            BodyList.AddRange(BodyDT.Rows[0][0].ToString().Split(','));

            return BodyList;
        }

        /// <summary>
        /// Get list of the all engines from database
        /// </summary>
        /// <returns> List of engines </returns>
        public static ArrayList GetEngineList()
        {
            ArrayList EngineList = new ArrayList();

            FbManager.fbConn.Open(); 

            DataTable EngineDT = new DataTable();
            FbCommand cmd = new FbCommand(
                "SELECT LIST(engine_name) FROM engine_type",
                FbManager.fbConn);

            cmd.CommandType = CommandType.Text;

            FbDataReader dr = cmd.ExecuteReader();

            EngineDT.Load(dr);

            FbManager.fbConn.Close(); 

            EngineList.AddRange(EngineDT.Rows[0][0].ToString().Split(','));

            return EngineList;
        }

        #endregion
    }
}
