using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarShopAIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // When app is launched
        private void Form1_Load(object sender, EventArgs e)
        {
            // Connect to the Firebird Database
            try
            {
                FbManager.DB_Connect();
                Update_Tables();
            }
            catch
            {
                MessageBox.Show("Возникли проблемы при попытке поключения базы данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Update all the tables
        public void Update_Tables()
        {
            #region CarTable Loading

            CarGridView.DataSource = CarTable.DataLoad();

            // Set id data columns invisible
            for (int i = 0; i < 2; i++)
            {
                CarGridView.Columns[i].Visible = false;
            }

            // Set special style for the table
            CarGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            CarGridView.Columns[5].Width = 150;

            #endregion

            #region ClientTable Loading

            ClientsGridView.DataSource = ClientTable.DataLoad();

            // Set id data column invisible
            ClientsGridView.Columns[0].Visible = false;

            // Set special style for the table
            ClientsGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);

            #endregion

            #region PurchaseTable Loading

            PurTable = 0;

            // Show purchase filter
            PurchFilterGB.Enabled = true;
            
            // Refresh purchase table
            PurchaseGridView.DataSource = null;
            PurchaseGridView.DataSource = PurchaseTable.AllDataLoad();

            // Set id data columns invisible
            for (int i = 0; i < 2; i++)
            {
                PurchaseGridView.Columns[i].Visible = false;
            }
            // Format table
            PurchaseGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            PurchaseGridView.Columns[9].DefaultCellStyle.Format = "### ### ### ##0.00##";

            SalesCountTB.Text = PurchaseTable.CountSales().ToString();
            SalesSumTB.Text = PurchaseTable.SumSales().ToString("### ### ### ##0.00##");

            #endregion
        }

        #region CarTab

        // Get full information about the car
        private void CarGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int config_id; // Current config ID
            int car_id; // Current car's ID

            try
            {
                config_id = (int)CarGridView.CurrentRow.Cells[1].Value; 
                car_id = (int)CarGridView.CurrentRow.Cells[0].Value;  
            }
            catch // If user clicks on the empty cell
            {
                return;
            }

            DataTable ConfigData = new DataTable();

            ConfigData = CarTable.GetConfig(config_id);

            // Add config info into form
            CarBodyTB.Text = ConfigData.Rows[0][0].ToString();
            EngineTypeTB.Text = ConfigData.Rows[0][1].ToString();
            if (!(ConfigData.Rows[0][2].ToString() == ""))
            {
                EngineVolumeTB.Text = Convert.ToDouble(ConfigData.Rows[0][2].ToString()).ToString("F1");
            }
            else // If Engine's volume  is null, set value "0.0"
            {
                EngineVolumeTB.Text = "0.0";
            }
            DoorsNumTB.Text = ConfigData.Rows[0][3].ToString();
            SeatsNumTB.Text = ConfigData.Rows[0][4].ToString();
            CarStateCB.Text = ConfigData.Rows[0][5].ToString();

            CarPicture.Image = CarTable.GetCarImage(car_id);
        }

        // Add new car to the database
        private void AddCarMenuItem_Click(object sender, EventArgs e)
        {
            AddCarForm addCarForm = new AddCarForm();
            addCarForm.Show();
        }

        // Delete car from database
        private void DeleteCarBt_Click(object sender, EventArgs e)
        {
            int CarID; // Current car's ID

            // Check if any car is chosen
            if (CarGridView.CurrentRow != null)
            {
                CarID = (int)CarGridView.CurrentRow.Cells[0].Value;
            }
            else 
            {
                MessageBox.Show("Выберите авто из таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить {CarGridView.CurrentRow.Cells[2].Value} " +
                $"{CarGridView.CurrentRow.Cells[3].Value} (VIN: {CarGridView.CurrentRow.Cells[5].Value})? \nИнформация о продаже так же будет удалена.",
                "Удалить авто", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (CarTable.DeleteCar(CarID))
                {
                    MessageBox.Show("Автомобиль успешно удалён!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Возникли проблемы при удалении автомобиля!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            Update_Tables();
        }

        // Update car's data
        private void UpdateCarBt_Click(object sender, EventArgs e)
        {
            int car_id; // Current car's ID
            string car_VIN; // Current car's VIN

            // Check if any car is chosen
            if (CarGridView.CurrentRow != null)
            {
                car_id = (int)CarGridView.CurrentRow.Cells[0].Value;
                car_VIN = CarGridView.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                MessageBox.Show("Выберите авто из таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm update
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите обновить информацию о {CarGridView.CurrentRow.Cells[2].Value} " +
                $"{CarGridView.CurrentRow.Cells[3].Value} (VIN: {CarGridView.CurrentRow.Cells[5].Value})?",
                "Обновить", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    CarTable.UpdateCarImage(car_VIN, CarPicture.Image);
                    CarTable.UpdateCarState(car_id, CarStateCB.Text);

                    MessageBox.Show("Информация обновлена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка обновления информации!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            Update_Tables();
        }

        // Set car's table filter
        private void FilterChanged(object sender, EventArgs e)
        {
            if (StateFilterCB.SelectedIndex < 1)
            {
                (CarGridView.DataSource as DataTable).DefaultView.RowFilter = $"Марка LIKE '%{BrandFilterTB.Text}%' " +
                $"AND Модель LIKE '%{ModelFilterTB.Text}%' " +
                $"AND VIN LIKE '%{VINfilterTB.Text}%'";
            }
            else
            {
                (CarGridView.DataSource as DataTable).DefaultView.RowFilter = $"Марка LIKE '%{BrandFilterTB.Text}%' " +
                $"AND Модель LIKE '%{ModelFilterTB.Text}%' " +
                $"AND Статус LIKE '%{StateFilterCB.Text}%' " +
                $"AND VIN LIKE '%{VINfilterTB.Text}%'";
            }
        }

        // Drop car's table filter
        private void DropFilterBt_Click(object sender, EventArgs e)
        {
            ModelFilterTB.Text = "";
            BrandFilterTB.Text = "";
            VINfilterTB.Text = "";
            StateFilterCB.SelectedIndex = -1;

            Update_Tables();
        }

        // Load car image from file
        private void PhotoLoadBt_Click(object sender, EventArgs e)
        {
            Bitmap image; // Bitmap for the opening picture

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    CarPicture.Image = image;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Delete car image
        private void PhotoDeleteBt_Click(object sender, EventArgs e)
        {
            CarPicture.Image = null;
        }

        #endregion

        #region ClientTab

        // Open window to add new client
        private void AddClientMenuItem_Click(object sender, EventArgs e)
        {
            AddClientForm addClientForm = new AddClientForm();
            addClientForm.Show();
        }

        // Delete client from the database
        private void DeleteClientBt_Click(object sender, EventArgs e)
        {
            int CurrClientID; 

            // Check if any car is selected
            if (ClientsGridView.CurrentRow != null)
            {
                CurrClientID = (int)ClientsGridView.CurrentRow.Cells[0].Value;
            }
            else 
            {
                MessageBox.Show("Выберите клиента из таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить клиента: {ClientsGridView.CurrentRow.Cells[1].Value} " +
                $"{ClientsGridView.CurrentRow.Cells[2].Value} {ClientsGridView.CurrentRow.Cells[3].Value} (Паспорт: {ClientsGridView.CurrentRow.Cells[4].Value})? \n" +
                $"Информация о его купленных автомобилях так же будет удалена.",
                "Удалить клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                // Check for success deletion
                if (ClientTable.DeleteClient(CurrClientID))
                {
                    MessageBox.Show("Клиент успешно удалён!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Возникли проблемы при удалении клиента!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            Update_Tables();
        }

        // Client search
        private void ClientParamsChanged(object sender, EventArgs e)
        {
            (ClientsGridView.DataSource as DataTable).DefaultView.RowFilter = $"Фамилия LIKE '%{SurnameTB.Text}%' " +
                $"AND Имя LIKE '%{NameTB.Text}%' " +
                $"AND Отчество LIKE '%{PatronymTB.Text}%' " +
                $"AND Паспорт LIKE '%{PassportSerTB.Text + ' ' + PassportNumTB.Text}%'";
        }

        // Drop client search
        private void DropClientSearchBt_Click(object sender, EventArgs e)
        {
            SurnameTB.Text = "";
            NameTB.Text = "";
            PatronymTB.Text = "";
            PassportSerTB.Text = "";
            PassportNumTB.Text = "";
        }

        #endregion

        #region PurchaseTab

        // Purchase tables index for PurchaseGridView (0 - Main purchase table,
        // 1 - Brand statistic, 2 - Model statistic)
        private int PurTable = 0;

        // Show all purchases
        private void AllPurchasesMenuItem_Click(object sender, EventArgs e)
        {
            Update_Tables();
        }

        // Show summ of sold cars grouped by mark
        private void SumByMarkMenuItem_Click(object sender, EventArgs e)
        {
            PurTable = 1;

            // Hide purchase filter
            PurchFilterGB.Enabled = false;

            PurchaseGridView.DataSource = PurchaseTable.SoldMarksCount();
            PurchaseGridView.Columns[2].DefaultCellStyle.Format = "### ### ### ### ##0.00##";
        }

        // Show summ of sold cars grouped by model
        private void SumByModelMenuItem_Click(object sender, EventArgs e)
        {
            Update_Tables();

            // Hide purchase filter
            PurchFilterGB.Enabled = false;

            PurTable = 2;
            PurchaseGridView.DataSource = PurchaseTable.SoldModelsCount();
            PurchaseGridView.Columns[3].DefaultCellStyle.Format = "### ### ### ### ##0.00##";
        }

        // Show data purchases for the current dates
        private void DatePckr_ValueChanged(object sender, EventArgs e)
        {
            DateToPckr.MinDate = DateFromPckr.Value;
            DateToPckr.Enabled = true;

            SalesCountTB.Text = PurchaseTable.CountSales(DateFromPckr.Value.ToShortDateString(), DateToPckr.Value.ToShortDateString()).ToString();
            SalesSumTB.Text = PurchaseTable.SumSales(DateFromPckr.Value.ToShortDateString(), DateToPckr.Value.ToShortDateString()).ToString("### ### ### ##0.00##");

            // Edit main table
            if (PurTable == 0)
            {
                PurchaseGridView.DataSource = PurchaseTable.AllDataLoad(DateFromPckr.Value.ToShortDateString(), DateToPckr.Value.ToShortDateString());

                // Set id data columns invisible
                for (int i = 0; i < 2; i++)
                {
                    PurchaseGridView.Columns[i].Visible = false;
                }
                // Format table
                PurchaseGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                PurchaseGridView.Columns[9].DefaultCellStyle.Format = "### ### ### ##0.00##";
            }
            
            // Edit brands table
            if (PurTable == 1)
            {
                PurchaseGridView.DataSource = PurchaseTable.SoldMarksCount(DateFromPckr.Value.ToShortDateString(), DateToPckr.Value.ToShortDateString());
            }

            // Edit models table
            if (PurTable == 2)
            {
                PurchaseGridView.DataSource = PurchaseTable.SoldModelsCount(DateFromPckr.Value.ToShortDateString(), DateToPckr.Value.ToShortDateString());
            }
        }

        // Show full date info
        private void ShowAllPurchBt_Click(object sender, EventArgs e)
        {
            if (PurTable == 0)
            {
                Update_Tables();
            }
           
            if (PurTable == 1)
            {
                SalesCountTB.Text = PurchaseTable.CountSales().ToString();
                SalesSumTB.Text = PurchaseTable.SumSales().ToString("### ### ### ##0.00##");
                PurchaseGridView.DataSource = PurchaseTable.SoldMarksCount();
            }

            if (PurTable == 2)
            {
                SalesCountTB.Text = PurchaseTable.CountSales().ToString();
                SalesSumTB.Text = PurchaseTable.SumSales().ToString("### ### ### ##0.00##");
                PurchaseGridView.DataSource = PurchaseTable.SoldModelsCount();
            }
        }

        // Add new purchase form open
        private void AddPurchaseMenuItem_Click(object sender, EventArgs e)
        {
            AddPurchaseForm addPurchaseForm = new AddPurchaseForm();
            addPurchaseForm.Show();
        }

        // Delete purchase
        private void DeletePurchBt_Click(object sender, EventArgs e)
        {
            // Suggest moving to the main purchase table
            if (PurTable != 0)
            {
                DialogResult ShiftDialogRes = MessageBox.Show($"Перейти во вкладку всех продаж?",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ShiftDialogRes == DialogResult.Yes)
                {
                    Update_Tables();
                    return;
                }
                else if (ShiftDialogRes == DialogResult.No)
                {
                    return;
                }
            }

            int CurrCarID;

            // Check if any purchase is chosen
            if (PurchaseGridView.CurrentRow != null)
            {
                CurrCarID = (int)PurchaseGridView.CurrentRow.Cells[1].Value;
            }
            else
            {
                MessageBox.Show("Выберите поле продажи из таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion
            DialogResult DeleteDialogRes = MessageBox.Show($"Вы уверены, что хотите удалить продажу {PurchaseGridView.CurrentRow.Cells[5].Value} " +
                $"{PurchaseGridView.CurrentRow.Cells[6].Value} \n(VIN: {PurchaseGridView.CurrentRow.Cells[7].Value}) " +
                $"от {Convert.ToDateTime(PurchaseGridView.CurrentRow.Cells[8].Value).ToShortDateString()}?",
                "Удалить продажу автомобиля", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DeleteDialogRes == DialogResult.Yes)
            {
                if (PurchaseTable.DeletePurchase(CurrCarID))
                {
                    MessageBox.Show("Информация о продаже успешно удалена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Возникли проблемы при удалении информации о продаже!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (DeleteDialogRes == DialogResult.No)
            {
                return;
            }

            Update_Tables();
        }

        // Drop purchase filter
        private void DropPurchFilter_Click(object sender, EventArgs e)
        {
            PurchMarkFTB.Text = "";
            PurchModelFTB.Text = "";
            PurchVinFTB.Text = "";
            PurchPasSerFTB.Text = "";
            PurchPasNumFTB.Text = "";
        }

        // Set purchase table filter
        private void PurchTabFilter_Changed(object sender, EventArgs e)
        {
            (PurchaseGridView.DataSource as DataTable).DefaultView.RowFilter = $"Марка LIKE '%{PurchMarkFTB.Text}%' " +
                $"AND Модель LIKE '%{PurchModelFTB.Text}%' " +
                $"AND VIN LIKE '%{PurchVinFTB.Text}%' " +
                $"AND Паспорт LIKE '%{PurchPasSerFTB.Text + ' ' + PurchPasNumFTB.Text}%'";
        }

        #endregion
    }
}
