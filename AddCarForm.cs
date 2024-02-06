using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarShopAIS
{
    public partial class AddCarForm : Form
    {
        public AddCarForm()
        {
            InitializeComponent();
        }

        // When add car menu is launched
        private void AddCarForm_Load(object sender, EventArgs e)
        {
            // Add collection of brands to the combobox
            BrandAddCB.Items.AddRange(CarTable.GetBrandList().ToArray()); 
            foreach (var item in CarTable.GetBrandList())
            {
                BrandAddCB.AutoCompleteCustomSource.Add(item.ToString());
            }

            // Add collection of countries to the combobox
            CountryAddCB.Items.AddRange(CarTable.GetCountryList().ToArray()); 
            foreach (var item in CarTable.GetCountryList()) 
            {
                CountryAddCB.AutoCompleteCustomSource.Add(item.ToString());
            }

            // Add collection of bodies to the combobox
            BodyAddCB.Items.AddRange(CarTable.GetBodyList().ToArray()); 

            // Add collection of engine types to the combobox
            EngineAddCB.Items.AddRange(CarTable.GetEngineList().ToArray()); 
        }

        // When brand is changed
        private void BrandAddCB_SelectedIndexChanged(object sender, EventArgs e)
        {

            // If brand name is entered correctly, allow access to the model adding and fill the model source
            if (BrandAddCB.SelectedIndex > -1 && BrandAddCB.AutoCompleteCustomSource.Contains(BrandAddCB.Text))
            {
                ModelAddCB.Enabled = true; 

                // Clear the model source
                ModelAddCB.Items.Clear();
                ModelAddCB.AutoCompleteCustomSource.Clear();
                ModelAddCB.Text = "";
                ModelAddCB.SelectedItem = -1;

                // Fill the model source
                ModelAddCB.Items.AddRange(CarTable.GetModelList(BrandAddCB.SelectedIndex).ToArray());
                foreach (var item in CarTable.GetModelList(BrandAddCB.SelectedIndex)) 
                {
                    ModelAddCB.AutoCompleteCustomSource.Add(item.ToString());
                }
            }
            else
            {
                // Clear the model source
                ModelAddCB.Items.Clear();
                ModelAddCB.AutoCompleteCustomSource.Clear();
                ModelAddCB.Text = "";
                ModelAddCB.SelectedItem = -1;

                ModelAddCB.Enabled = false; 
            }
        }

        // Add new photo
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
                    CarPicAdd.Image = image;
                }
                catch 
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Delete car's photo
        private void PhotoDeleteBt_Click(object sender, EventArgs e)
        {
            CarPicAdd.Image = null;
        }

        // Save new car in the dataBase
        private void AddNewCarBt_Click(object sender, EventArgs e)
        {
            // Check for all obligatory data
            if (BrandAddCB.SelectedIndex > -1 &&
                ModelAddCB.SelectedIndex > -1 &&
                CountryAddCB.SelectedIndex > -1 &&
                !(String.IsNullOrEmpty(VINAddTB.Text)) &&
                BrandAddCB.SelectedIndex > -1 &&
                EngineAddCB.SelectedIndex > -1 &&
                BodyAddCB.SelectedIndex > -1 &&
                CarStateCB.SelectedIndex > -1 &&
                DoorsNUD != null &&
                SeatsNUD != null &&
                ModelAddCB.AutoCompleteCustomSource.Contains(ModelAddCB.Text))
            {
                if (CarTable.AddCar(ModelAddCB.Text, CountryAddCB.SelectedIndex, CarStateCB.Text,
                    VINAddTB.Text, BodyAddCB.SelectedIndex, (int)DoorsNUD.Value, (int)SeatsNUD.Value, EngineAddCB.SelectedIndex,
                    (double)EngineValNUD.Value)) // If car has been added successfully
                {
                    CarTable.UpdateCarImage(VINAddTB.Text, CarPicAdd.Image);

                    MessageBox.Show("Автомобиль успешно добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (Application.OpenForms["Form1"] != null)
                    {
                        (Application.OpenForms["Form1"] as Form1).Update_Tables();
                    }

                    ActiveForm.Close();
                }
                else
                {
                    MessageBox.Show("Автомобиль с данным VIN-кодом уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (FbManager.fbConn.State == ConnectionState.Open)
                    {
                        FbManager.fbConn.Close();
                    }
                    return;
                }
            }
            else
            {
                MessageBox.Show("Убедитесь, что все необходимые данные введены корректно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Exit from the form
        private void CancelBt_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
    }
}
