
namespace CarShopAIS
{
    partial class AddClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClientForm));
            this.NameTB = new System.Windows.Forms.TextBox();
            this.SurnameTB = new System.Windows.Forms.TextBox();
            this.PatronymicTB = new System.Windows.Forms.TextBox();
            this.PassportMTB = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AddClientBt = new System.Windows.Forms.Button();
            this.CancelBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameTB
            // 
            this.NameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTB.Location = new System.Drawing.Point(193, 29);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(159, 21);
            this.NameTB.TabIndex = 0;
            // 
            // SurnameTB
            // 
            this.SurnameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SurnameTB.Location = new System.Drawing.Point(193, 56);
            this.SurnameTB.Name = "SurnameTB";
            this.SurnameTB.Size = new System.Drawing.Size(159, 21);
            this.SurnameTB.TabIndex = 1;
            // 
            // PatronymicTB
            // 
            this.PatronymicTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatronymicTB.Location = new System.Drawing.Point(193, 83);
            this.PatronymicTB.Name = "PatronymicTB";
            this.PatronymicTB.Size = new System.Drawing.Size(159, 21);
            this.PatronymicTB.TabIndex = 2;
            // 
            // PassportMTB
            // 
            this.PassportMTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PassportMTB.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.PassportMTB.Location = new System.Drawing.Point(193, 110);
            this.PassportMTB.Mask = "0000 000000";
            this.PassportMTB.Name = "PassportMTB";
            this.PassportMTB.Size = new System.Drawing.Size(159, 21);
            this.PassportMTB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Фамилия*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отчество:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Серия и номер паспорта*:";
            // 
            // AddClientBt
            // 
            this.AddClientBt.Location = new System.Drawing.Point(150, 152);
            this.AddClientBt.Name = "AddClientBt";
            this.AddClientBt.Size = new System.Drawing.Size(98, 24);
            this.AddClientBt.TabIndex = 8;
            this.AddClientBt.Text = "Сохранить";
            this.AddClientBt.UseVisualStyleBackColor = true;
            this.AddClientBt.Click += new System.EventHandler(this.AddClientBt_Click);
            // 
            // CancelBT
            // 
            this.CancelBT.Location = new System.Drawing.Point(254, 152);
            this.CancelBT.Name = "CancelBT";
            this.CancelBT.Size = new System.Drawing.Size(98, 24);
            this.CancelBT.TabIndex = 9;
            this.CancelBT.Text = "Отмена";
            this.CancelBT.UseVisualStyleBackColor = true;
            this.CancelBT.Click += new System.EventHandler(this.CancelBT_Click);
            // 
            // AddClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 188);
            this.Controls.Add(this.CancelBT);
            this.Controls.Add(this.AddClientBt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PassportMTB);
            this.Controls.Add(this.PatronymicTB);
            this.Controls.Add(this.SurnameTB);
            this.Controls.Add(this.NameTB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddClientForm";
            this.Text = "Добавление клиента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox SurnameTB;
        private System.Windows.Forms.TextBox PatronymicTB;
        private System.Windows.Forms.MaskedTextBox PassportMTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddClientBt;
        private System.Windows.Forms.Button CancelBT;
    }
}