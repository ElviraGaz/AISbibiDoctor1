namespace AISbibiDoctor1
{
    partial class Sister
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.userControl12 = new WindowsFormsControlLibrary1.UserControl1();
            this.userControl11 = new WindowsFormsControlLibrary1.UserControl1();
            this.go_to_doctor = new System.Windows.Forms.Button();
            this.prosmotr_kartu = new System.Windows.Forms.Button();
            this.dataGridView_search_pacient = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btn_new_karta = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_DATE_BIRTH = new System.Windows.Forms.DateTimePicker();
            this.number_kart = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label_name_pacient = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.unit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.dataSet1 = new AISbibiDoctor1.DataSet1();
            this.pACIENTTableAdapter = new AISbibiDoctor1.DataSet1TableAdapters.PACIENTTableAdapter();
            this.pACIENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_search_pacient)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pACIENTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Controls.Add(this.userControl12);
            this.groupBox1.Controls.Add(this.userControl11);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(564, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 176);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск пациента";
            
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(97, 131);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "Поиск";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // userControl12
            // 
            this.userControl12.ColumnName = "Имя";
            this.userControl12.ColumnValue = "";
            this.userControl12.Location = new System.Drawing.Point(10, 69);
            this.userControl12.Name = "userControl12";
            this.userControl12.SearchEnabled = false;
            this.userControl12.Size = new System.Drawing.Size(162, 56);
            this.userControl12.TabIndex = 1;
            // 
            // userControl11
            // 
            this.userControl11.ColumnName = "Фамилия";
            this.userControl11.ColumnValue = "";
            this.userControl11.Location = new System.Drawing.Point(11, 19);
            this.userControl11.Name = "userControl11";
            this.userControl11.SearchEnabled = false;
            this.userControl11.Size = new System.Drawing.Size(162, 56);
            this.userControl11.TabIndex = 0;
            // 
            // go_to_doctor
            // 
            this.go_to_doctor.Location = new System.Drawing.Point(477, 56);
            this.go_to_doctor.Name = "go_to_doctor";
            this.go_to_doctor.Size = new System.Drawing.Size(130, 57);
            this.go_to_doctor.TabIndex = 5;
            this.go_to_doctor.Text = "Направить к врачу";
            this.go_to_doctor.UseVisualStyleBackColor = true;
            this.go_to_doctor.Click += new System.EventHandler(this.go_to_doctor_Click);
            // 
            // prosmotr_kartu
            // 
            this.prosmotr_kartu.Location = new System.Drawing.Point(477, 14);
            this.prosmotr_kartu.Name = "prosmotr_kartu";
            this.prosmotr_kartu.Size = new System.Drawing.Size(130, 32);
            this.prosmotr_kartu.TabIndex = 6;
            this.prosmotr_kartu.Text = "Просмотр карты";
            this.prosmotr_kartu.UseVisualStyleBackColor = true;
            this.prosmotr_kartu.Click += new System.EventHandler(this.prosmotr_kartu_Click_1);
            // 
            // dataGridView_search_pacient
            // 
            this.dataGridView_search_pacient.AllowUserToAddRows = false;
            this.dataGridView_search_pacient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_search_pacient.Location = new System.Drawing.Point(3, 2);
            this.dataGridView_search_pacient.Name = "dataGridView_search_pacient";
            this.dataGridView_search_pacient.Size = new System.Drawing.Size(543, 174);
            this.dataGridView_search_pacient.TabIndex = 1;
            this.dataGridView_search_pacient.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick_1);
            this.dataGridView_search_pacient.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(20, 479);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Добавление нового пациента";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(79, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(79, 76);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(121, 20);
            this.textBox3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отчество";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(307, 20);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(123, 20);
            this.textBox5.TabIndex = 7;
            // 
            // btn_new_karta
            // 
            this.btn_new_karta.Location = new System.Drawing.Point(308, 83);
            this.btn_new_karta.Name = "btn_new_karta";
            this.btn_new_karta.Size = new System.Drawing.Size(122, 34);
            this.btn_new_karta.TabIndex = 4;
            this.btn_new_karta.Text = "Завести карту";
            this.btn_new_karta.UseVisualStyleBackColor = true;
            this.btn_new_karta.Click += new System.EventHandler(this.btn_new_karta_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Номер полиса";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dateTimePicker_DATE_BIRTH);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btn_new_karta);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Location = new System.Drawing.Point(9, 495);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(572, 129);
            this.panel3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Дата рождения";
            // 
            // dateTimePicker_DATE_BIRTH
            // 
            this.dateTimePicker_DATE_BIRTH.Location = new System.Drawing.Point(306, 54);
            this.dateTimePicker_DATE_BIRTH.Name = "dateTimePicker_DATE_BIRTH";
            this.dateTimePicker_DATE_BIRTH.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker_DATE_BIRTH.TabIndex = 10;
            // 
            // number_kart
            // 
            this.number_kart.Location = new System.Drawing.Point(295, 16);
            this.number_kart.Name = "number_kart";
            this.number_kart.Size = new System.Drawing.Size(124, 20);
            this.number_kart.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Введите номер карты";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.unit);
            this.groupBox2.Controls.Add(this.go_to_doctor);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Controls.Add(this.prosmotr_kartu);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.number_kart);
            this.groupBox2.Location = new System.Drawing.Point(9, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 276);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Направление к врачу";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label_name_pacient);
            this.panel2.Location = new System.Drawing.Point(3, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(746, 34);
            this.panel2.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(70, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 18);
            this.label11.TabIndex = 12;
            this.label11.Text = "Пациент";
            // 
            // label_name_pacient
            // 
            this.label_name_pacient.AutoSize = true;
            this.label_name_pacient.Font = new System.Drawing.Font("Latha", 11.25F);
            this.label_name_pacient.Location = new System.Drawing.Point(209, 5);
            this.label_name_pacient.Name = "label_name_pacient";
            this.label_name_pacient.Size = new System.Drawing.Size(256, 23);
            this.label_name_pacient.TabIndex = 11;
            this.label_name_pacient.Text = "Фамилия Имя Отчество г.р.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Turquoise;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 101);
            this.panel1.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label9.Location = new System.Drawing.Point(1, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 39);
            this.label9.TabIndex = 12;
            this.label9.Text = "Сегодня";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(13, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(199, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Дежурный врач";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(295, 93);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(125, 20);
            this.textBox4.TabIndex = 12;
            // 
            // unit
            // 
            this.unit.FormattingEnabled = true;
            this.unit.Location = new System.Drawing.Point(295, 57);
            this.unit.Name = "unit";
            this.unit.Size = new System.Drawing.Size(124, 21);
            this.unit.TabIndex = 6;
            this.unit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.unit_MouseClick);
            this.unit.SelectedIndexChanged += new System.EventHandler(this.unit_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(177, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Выберите отделение";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listView1.Location = new System.Drawing.Point(0, 168);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(749, 102);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Дата поступления";
            this.columnHeader1.Width = 107;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Дата выписки";
            this.columnHeader2.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Врач";
            this.columnHeader3.Width = 72;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Жалобы";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Осмотр";
            this.columnHeader5.Width = 109;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Диагноз";
            this.columnHeader6.Width = 98;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Лечение";
            this.columnHeader7.Width = 158;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pACIENTTableAdapter
            // 
            this.pACIENTTableAdapter.ClearBeforeFill = true;
            // 
            // pACIENTBindingSource
            // 
            this.pACIENTBindingSource.DataMember = "PACIENT";
            this.pACIENTBindingSource.DataSource = this.dataSet1;
            // 
            // Sister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(793, 636);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView_search_pacient);
            this.Controls.Add(this.panel3);
            this.Name = "Sister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Медсестра приемного покоя";
            this.Load += new System.EventHandler(this.Sister_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_search_pacient)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pACIENTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private WindowsFormsControlLibrary1.UserControl1 userControl12;
        private WindowsFormsControlLibrary1.UserControl1 userControl11;
        private System.Windows.Forms.Button go_to_doctor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_search_pacient;
        private DataSet1 dataSet1;
        private AISbibiDoctor1.DataSet1TableAdapters.PACIENTTableAdapter pACIENTTableAdapter;
        private System.Windows.Forms.Button prosmotr_kartu;
        private System.Windows.Forms.BindingSource pACIENTBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btn_new_karta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox number_kart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label_name_pacient;
        private System.Windows.Forms.ComboBox unit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DATE_BIRTH;
    }
}