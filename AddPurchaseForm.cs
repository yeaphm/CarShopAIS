using System;
using System.Windows.Forms;

namespace CarShopAIS
{
    public partial class AddPurchaseForm : Form
    {
        public AddPurchaseForm()
        {
            InitializeComponent();
        }

        // Save new purchase in database
        private void SavePurch_Click(object sender, EventArgs e)
        {
            if (PassportMTB.MaskFull &&
                !String.IsNullOrEmpty(VinTB.Text) &&
                !String.IsNullOrEmpty(PurchPriceTB.Text))
            {
                // Check if client exists
                if (ClientTable.GetClientID(PassportMTB.Text) < 1)
                {
                    DialogResult askForNewClient = MessageBox.Show($"Клиента с данным паспортом не существует! \n" +
                        $"Проверьте корректнотсь ввода или добавьте нового клиента. \n" +
                        $"Добавить клиента?",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (askForNewClient == DialogResult.Yes)
                    {
                        AddClientForm addClientForm = new AddClientForm();
                        addClientForm.Show();

                        return;
                    }
                    else if (askForNewClient == DialogResult.No)
                    {
                        return;
                    }
                }

                // Check if car exists
                if (CarTable.GetCarID(VinTB.Text) < 1)
                {
                    DialogResult askForNewCar = MessageBox.Show($"Автомобиля с данным VIN не существует! \n" +
                        $"Проверьте корректнотсь ввода или добавьте новый автомобиль. \n" +
                        $"Добавить автомобиль?",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (askForNewCar == DialogResult.Yes)
                    {
                        AddCarForm addCarForm = new AddCarForm();
                        addCarForm.Show();

                        return;
                    }
                    else if (askForNewCar == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    // Check car's state
                    if (CarTable.GetCarState(VinTB.Text) == "В пути")
                    {
                        MessageBox.Show("Этот автомобиль ещё в пути! Покупка невозможна.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (CarTable.GetCarState(VinTB.Text) == "Продано")
                    {
                        MessageBox.Show("Этот автомобиль уже продан! Покупка невозможна.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Add new purchase
                try
                {
                    PurchaseTable.AddPurchase(VinTB.Text, PassportMTB.Text,
                        PurchDatePckr.Value.ToShortDateString(), Convert.ToDecimal(PurchPriceTB.Text));

                    MessageBox.Show("Покупка успешно оформлена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (Application.OpenForms["Form1"] != null)
                    {
                        (Application.OpenForms["Form1"] as Form1).Update_Tables();
                    }

                    ActiveForm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Cancel adding the purchase
        private void CancelAddPurch_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        // Prevent invalid price input
        private void PurchPriceTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)
            {
                if (PurchPriceTB.Text.Contains(","))
                {
                    if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back))
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
