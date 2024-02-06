
namespace CarShopAIS
{
    partial class AddPurchaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.PassportMTB = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VinTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PurchPriceTB = new System.Windows.Forms.TextBox();
            this.PurchDatePckr = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SavePurch = new System.Windows.Forms.Button();
            this.CancelAddPurch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Серия и номер паспорта клиента*:";
            // 
            // PassportMTB
            // 
            this.PassportMTB.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.PassportMTB.Location = new System.Drawing.Point(227, 14);
            this.PassportMTB.Mask = "0000 000000";
            this.PassportMTB.Name = "PassportMTB";
            this.PassportMTB.Size = new System.Drawing.Size(179, 21);
            this.PassportMTB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "VIN-код автомобиля*:";
            // 
            // VinTB
            // 
            this.VinTB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.VinTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.VinTB.Location = new System.Drawing.Point(227, 41);
            this.VinTB.MaxLength = 20;
            this.VinTB.Name = "VinTB";
            this.VinTB.Size = new System.Drawing.Size(179, 21);
            this.VinTB.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Общая стоимость*:";
            // 
            // PurchPriceTB
            // 
            this.PurchPriceTB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PurchPriceTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PurchPriceTB.Location = new System.Drawing.Point(227, 72);
            this.PurchPriceTB.MaxLength = 0;
            this.PurchPriceTB.Name = "PurchPriceTB";
            this.PurchPriceTB.Size = new System.Drawing.Size(179, 21);
            this.PurchPriceTB.TabIndex = 21;
            this.PurchPriceTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PurchPriceTB_KeyPress);
            // 
            // PurchDatePckr
            // 
            this.PurchDatePckr.Location = new System.Drawing.Point(227, 131);
            this.PurchDatePckr.Name = "PurchDatePckr";
            this.PurchDatePckr.Size = new System.Drawing.Size(179, 21);
            this.PurchDatePckr.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Дата покупки:";
            // 
            // SavePurch
            // 
            this.SavePurch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.SavePurch.Location = new System.Drawing.Point(164, 174);
            this.SavePurch.Name = "SavePurch";
            this.SavePurch.Size = new System.Drawing.Size(119, 26);
            this.SavePurch.TabIndex = 24;
            this.SavePurch.Text = "Сохранить";
            this.SavePurch.UseVisualStyleBackColor = true;
            this.SavePurch.Click += new System.EventHandler(this.SavePurch_Click);
            // 
            // CancelAddPurch
            // 
            this.CancelAddPurch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.CancelAddPurch.Location = new System.Drawing.Point(289, 174);
            this.CancelAddPurch.Name = "CancelAddPurch";
            this.CancelAddPurch.Size = new System.Drawing.Size(119, 26);
            this.CancelAddPurch.TabIndex = 25;
            this.CancelAddPurch.Text = "Отмена";
            this.CancelAddPurch.UseVisualStyleBackColor = true;
            this.CancelAddPurch.Click += new System.EventHandler(this.CancelAddPurch_Click);
            // 
            // AddPurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 212);
            this.Controls.Add(this.CancelAddPurch);
            this.Controls.Add(this.SavePurch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PurchDatePckr);
            this.Controls.Add(this.PurchPriceTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VinTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PassportMTB);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddPurchaseForm";
            this.Text = "Оформление продажи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox PassportMTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox VinTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PurchPriceTB;
        private System.Windows.Forms.DateTimePicker PurchDatePckr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SavePurch;
        private System.Windows.Forms.Button CancelAddPurch;
    }
}