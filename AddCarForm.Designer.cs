
namespace CarShopAIS
{
    partial class AddCarForm
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
            this.AddNewCarBt = new System.Windows.Forms.Button();
            this.CancelBt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CarPicAdd = new System.Windows.Forms.PictureBox();
            this.PhotoLoadBt = new System.Windows.Forms.Button();
            this.PhotoDeleteBt = new System.Windows.Forms.Button();
            this.CarStateCB = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SeatsNUD = new System.Windows.Forms.NumericUpDown();
            this.DoorsNUD = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.EngineValNUD = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BodyAddCB = new System.Windows.Forms.ComboBox();
            this.EngineAddCB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VINAddTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BrandAddCB = new System.Windows.Forms.ComboBox();
            this.ModelAddCB = new System.Windows.Forms.ComboBox();
            this.CountryAddCB = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarPicAdd)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeatsNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoorsNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EngineValNUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddNewCarBt
            // 
            this.AddNewCarBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddNewCarBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddNewCarBt.Location = new System.Drawing.Point(507, 388);
            this.AddNewCarBt.Name = "AddNewCarBt";
            this.AddNewCarBt.Size = new System.Drawing.Size(132, 30);
            this.AddNewCarBt.TabIndex = 22;
            this.AddNewCarBt.Text = "Сохранить";
            this.AddNewCarBt.UseVisualStyleBackColor = true;
            this.AddNewCarBt.Click += new System.EventHandler(this.AddNewCarBt_Click);
            // 
            // CancelBt
            // 
            this.CancelBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CancelBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelBt.Location = new System.Drawing.Point(645, 388);
            this.CancelBt.Name = "CancelBt";
            this.CancelBt.Size = new System.Drawing.Size(132, 30);
            this.CancelBt.TabIndex = 24;
            this.CancelBt.Text = "Отмена";
            this.CancelBt.UseVisualStyleBackColor = true;
            this.CancelBt.Click += new System.EventHandler(this.CancelBt_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.CarStateCB);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(5, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 363);
            this.panel1.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(596, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Статус*:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CarPicAdd);
            this.groupBox3.Controls.Add(this.PhotoLoadBt);
            this.groupBox3.Controls.Add(this.PhotoDeleteBt);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(361, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(427, 307);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Фото";
            // 
            // CarPicAdd
            // 
            this.CarPicAdd.BackColor = System.Drawing.Color.Transparent;
            this.CarPicAdd.BackgroundImage = global::CarShopAIS.Properties.Resources.default_car;
            this.CarPicAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CarPicAdd.InitialImage = null;
            this.CarPicAdd.Location = new System.Drawing.Point(14, 19);
            this.CarPicAdd.Margin = new System.Windows.Forms.Padding(2);
            this.CarPicAdd.MaximumSize = new System.Drawing.Size(3500, 2200);
            this.CarPicAdd.Name = "CarPicAdd";
            this.CarPicAdd.Size = new System.Drawing.Size(397, 233);
            this.CarPicAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CarPicAdd.TabIndex = 19;
            this.CarPicAdd.TabStop = false;
            // 
            // PhotoLoadBt
            // 
            this.PhotoLoadBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PhotoLoadBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhotoLoadBt.Location = new System.Drawing.Point(141, 259);
            this.PhotoLoadBt.Name = "PhotoLoadBt";
            this.PhotoLoadBt.Size = new System.Drawing.Size(132, 30);
            this.PhotoLoadBt.TabIndex = 20;
            this.PhotoLoadBt.Text = "Загрузить фото";
            this.PhotoLoadBt.UseVisualStyleBackColor = true;
            this.PhotoLoadBt.Click += new System.EventHandler(this.PhotoLoadBt_Click);
            // 
            // PhotoDeleteBt
            // 
            this.PhotoDeleteBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PhotoDeleteBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhotoDeleteBt.Location = new System.Drawing.Point(279, 259);
            this.PhotoDeleteBt.Name = "PhotoDeleteBt";
            this.PhotoDeleteBt.Size = new System.Drawing.Size(132, 30);
            this.PhotoDeleteBt.TabIndex = 21;
            this.PhotoDeleteBt.Text = "Удалить фото";
            this.PhotoDeleteBt.UseVisualStyleBackColor = true;
            this.PhotoDeleteBt.Click += new System.EventHandler(this.PhotoDeleteBt_Click);
            // 
            // CarStateCB
            // 
            this.CarStateCB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CarStateCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CarStateCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CarStateCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarStateCB.FormattingEnabled = true;
            this.CarStateCB.Items.AddRange(new object[] {
            "В наличии",
            "В пути",
            "Продано"});
            this.CarStateCB.Location = new System.Drawing.Point(657, 318);
            this.CarStateCB.MaximumSize = new System.Drawing.Size(300, 0);
            this.CarStateCB.Name = "CarStateCB";
            this.CarStateCB.Size = new System.Drawing.Size(115, 23);
            this.CarStateCB.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.SeatsNUD);
            this.groupBox2.Controls.Add(this.DoorsNUD);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.EngineValNUD);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.BodyAddCB);
            this.groupBox2.Controls.Add(this.EngineAddCB);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 186);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Технические характеристики";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Кол-во мест*:";
            // 
            // SeatsNUD
            // 
            this.SeatsNUD.Location = new System.Drawing.Point(120, 150);
            this.SeatsNUD.Name = "SeatsNUD";
            this.SeatsNUD.Size = new System.Drawing.Size(55, 21);
            this.SeatsNUD.TabIndex = 20;
            // 
            // DoorsNUD
            // 
            this.DoorsNUD.Location = new System.Drawing.Point(120, 123);
            this.DoorsNUD.Name = "DoorsNUD";
            this.DoorsNUD.Size = new System.Drawing.Size(55, 21);
            this.DoorsNUD.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Кол-во дверей*:";
            // 
            // EngineValNUD
            // 
            this.EngineValNUD.DecimalPlaces = 1;
            this.EngineValNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.EngineValNUD.Location = new System.Drawing.Point(120, 96);
            this.EngineValNUD.Name = "EngineValNUD";
            this.EngineValNUD.Size = new System.Drawing.Size(55, 21);
            this.EngineValNUD.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Объём двигателя:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Тип двигателя*:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Кузов*:";
            // 
            // BodyAddCB
            // 
            this.BodyAddCB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BodyAddCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BodyAddCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BodyAddCB.FormattingEnabled = true;
            this.BodyAddCB.Location = new System.Drawing.Point(120, 35);
            this.BodyAddCB.MaximumSize = new System.Drawing.Size(300, 0);
            this.BodyAddCB.Name = "BodyAddCB";
            this.BodyAddCB.Size = new System.Drawing.Size(217, 23);
            this.BodyAddCB.TabIndex = 9;
            // 
            // EngineAddCB
            // 
            this.EngineAddCB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EngineAddCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.EngineAddCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EngineAddCB.FormattingEnabled = true;
            this.EngineAddCB.Location = new System.Drawing.Point(120, 64);
            this.EngineAddCB.MaximumSize = new System.Drawing.Size(300, 0);
            this.EngineAddCB.Name = "EngineAddCB";
            this.EngineAddCB.Size = new System.Drawing.Size(217, 23);
            this.EngineAddCB.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.VINAddTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BrandAddCB);
            this.groupBox1.Controls.Add(this.ModelAddCB);
            this.groupBox1.Controls.Add(this.CountryAddCB);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 157);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основная информация";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "VIN-код*:";
            // 
            // VINAddTB
            // 
            this.VINAddTB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.VINAddTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.VINAddTB.Location = new System.Drawing.Point(120, 123);
            this.VINAddTB.MaxLength = 20;
            this.VINAddTB.Name = "VINAddTB";
            this.VINAddTB.Size = new System.Drawing.Size(217, 21);
            this.VINAddTB.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Изготовитель*:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Модель*:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Марка*:";
            // 
            // BrandAddCB
            // 
            this.BrandAddCB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BrandAddCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.BrandAddCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BrandAddCB.FormattingEnabled = true;
            this.BrandAddCB.Location = new System.Drawing.Point(120, 35);
            this.BrandAddCB.MaximumSize = new System.Drawing.Size(300, 0);
            this.BrandAddCB.Name = "BrandAddCB";
            this.BrandAddCB.Size = new System.Drawing.Size(217, 23);
            this.BrandAddCB.TabIndex = 9;
            this.BrandAddCB.SelectedIndexChanged += new System.EventHandler(this.BrandAddCB_SelectedIndexChanged);
            this.BrandAddCB.TextChanged += new System.EventHandler(this.BrandAddCB_SelectedIndexChanged);
            // 
            // ModelAddCB
            // 
            this.ModelAddCB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ModelAddCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ModelAddCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ModelAddCB.Enabled = false;
            this.ModelAddCB.FormattingEnabled = true;
            this.ModelAddCB.Location = new System.Drawing.Point(120, 64);
            this.ModelAddCB.MaximumSize = new System.Drawing.Size(300, 0);
            this.ModelAddCB.Name = "ModelAddCB";
            this.ModelAddCB.Size = new System.Drawing.Size(217, 23);
            this.ModelAddCB.TabIndex = 10;
            // 
            // CountryAddCB
            // 
            this.CountryAddCB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CountryAddCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CountryAddCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CountryAddCB.FormattingEnabled = true;
            this.CountryAddCB.Location = new System.Drawing.Point(120, 93);
            this.CountryAddCB.MaximumSize = new System.Drawing.Size(300, 0);
            this.CountryAddCB.Name = "CountryAddCB";
            this.CountryAddCB.Size = new System.Drawing.Size(217, 23);
            this.CountryAddCB.TabIndex = 11;
            // 
            // AddCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(811, 430);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CancelBt);
            this.Controls.Add(this.AddNewCarBt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddCarForm";
            this.Text = "Добавление нового автомобиля";
            this.Load += new System.EventHandler(this.AddCarForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CarPicAdd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeatsNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoorsNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EngineValNUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddNewCarBt;
        private System.Windows.Forms.Button CancelBt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox CarPicAdd;
        private System.Windows.Forms.Button PhotoLoadBt;
        private System.Windows.Forms.Button PhotoDeleteBt;
        private System.Windows.Forms.ComboBox CarStateCB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown SeatsNUD;
        private System.Windows.Forms.NumericUpDown DoorsNUD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown EngineValNUD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox BodyAddCB;
        private System.Windows.Forms.ComboBox EngineAddCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BrandAddCB;
        private System.Windows.Forms.ComboBox ModelAddCB;
        private System.Windows.Forms.ComboBox CountryAddCB;
        private System.Windows.Forms.TextBox VINAddTB;
    }
}