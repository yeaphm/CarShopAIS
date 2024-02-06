using System;
using System.Data;
using System.Windows.Forms;

namespace CarShopAIS
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }

        // Add new client to the database
        private void AddClientBt_Click(object sender, EventArgs e)
        {
            // Checking for all obligatory data
            if (!(String.IsNullOrWhiteSpace(NameTB.Text)) 
                && !(String.IsNullOrWhiteSpace(SurnameTB.Text))
                && PassportMTB.MaskFull)
            {
                try
                {
                    ClientTable.AddClient(NameTB.Text, SurnameTB.Text, PatronymicTB.Text, PassportMTB.Text);
                    
                    MessageBox.Show("Клиент успешно добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (Application.OpenForms["Form1"] != null)
                    {
                        (Application.OpenForms["Form1"] as Form1).Update_Tables();
                    }

                    ActiveForm.Close();
                }
                catch 
                {
                    MessageBox.Show("Клиент с такими паспортными данными уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (FbManager.fbConn.State == ConnectionState.Open)
                    {
                        FbManager.fbConn.Close();
                    }
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Exit from the form
        private void CancelBT_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
    }
}
