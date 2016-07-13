using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using System.Data.OracleClient;

namespace AISbibiDoctor1
{
    public partial class Sister : Form
    {
        private string cellrow;
        private string cell;
        private string connection_string = "Data Source=XE;User Id=bibi;Password=9";
        DateTime data_time;

        public Sister()
        {
            InitializeComponent();
            data_time = DateTime.Now;
           
        }


        

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(connection_string);
                con.Open();
                this.pACIENTTableAdapter.Fill(this.dataSet1.PACIENT);
                FindPacient();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
     

        private void FindPacient()
        {         
            
            ArrayList filteringFields = new ArrayList();
            //Если элемент  доступен для поиска
            if (userControl11.SearchEnabled && userControl11.ColumnValue.Length != 0)
            
            {
                filteringFields.Add("Фамилия LIKE \'" + userControl11.ColumnValue + "%\'");
              
            }
            if (userControl12.SearchEnabled && userControl12.ColumnValue.Length != 0)
            { 
                filteringFields.Add("Имя LIKE \'" + userControl12.ColumnValue + "%\'");
             
            }
            string filter = "";
            //Комбинируем введенные в текстовые поля значения.
           
            if (filteringFields.Count == 1)
                filter = filteringFields[0].ToString();
            else if (filteringFields.Count > 1)
            {
                for (int i = 0; i < filteringFields.Count - 1; i++)
                    filter += filteringFields[i].ToString() + " AND ";
                filter += filteringFields[filteringFields.Count - 1].ToString();
            }
            
            DataView dvSearch = new DataView(this.dataSet1.PACIENT);
           
            dvSearch.RowFilter = filter;
            dataGridView_search_pacient.DataSource = dvSearch;
        }

        


        private void Sister_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.PACIENT". При необходимости она может быть перемещена или удалена.
            this.pACIENTTableAdapter.Fill(this.dataSet1.PACIENT);
           
        }

       
            

          
          
        
        private void btn_new_karta_Click(object sender, EventArgs e)//новая мед карта
        {
            
            OracleConnection con = new OracleConnection(connection_string);
            try
            {
                
               OracleCommand com = new OracleCommand("INSERT into PACIENT (SURNAME,NAME,OTCHESTVO,POLICY,DATE_OF_BIRTH) Values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox5.Text.ToString() + "','"+dateTimePicker_DATE_BIRTH.Value.Date.ToShortDateString()+"')", con);

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Данных недостаточно!");
                    
                }
                else
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Пациент добавлен!");
                    

                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
            }
            catch
            {
                MessageBox.Show("Невозможно добавить пациента!");
                
            }
        }



        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
           
            try
            {
                OracleConnection con = new OracleConnection(connection_string);
                switch (e.ColumnIndex)
                {
                   
                    case 0:
                        {
                            OracleCommand com = new OracleCommand("UPDATE PACIENT SET SURNAME='" + dataGridView_search_pacient[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE ID = '" + dataGridView_search_pacient[3, e.RowIndex].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 1:
                        {
                            OracleCommand com = new OracleCommand("UPDATE PACIENT SET NAME='" + dataGridView_search_pacient[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE ID = '" + dataGridView_search_pacient[3, e.RowIndex].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 2:
                        {
                            OracleCommand com = new OracleCommand("UPDATE PACIENT SET OTCHESTVO='" + dataGridView_search_pacient[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE ID = '" + dataGridView_search_pacient[3, e.RowIndex].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 3:
                        {
                            dataGridView_search_pacient[e.ColumnIndex, e.RowIndex].Value = cell;
                            MessageBox.Show("Нельзя!");
                            break;
                            
                        }
                    case 4:
                        {
                            OracleCommand com = new OracleCommand("UPDATE PACIENT SET POLICY='" + dataGridView_search_pacient[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE ID = '" + dataGridView_search_pacient[3, e.RowIndex].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
      
                            
                        }
                   
                   

                } 
            }
            catch
            {
                MessageBox.Show("Невозможно изменить!");
                dataGridView_search_pacient[e.ColumnIndex, e.RowIndex].Value = cell;

            }
        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cellrow = dataGridView_search_pacient[0, e.RowIndex].Value.ToString();
                cell = dataGridView_search_pacient[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            catch { }
        }

      

        private void prosmotr_kartu_Click_1(object sender, EventArgs e)
        {

            try
            {
                label_name_pacient.Text = "Фамилия Имя Отчество г.р.";
                if (number_kart.Text == "")
                    MessageBox.Show("Введите номер карты!");
                else
                {

                    OracleConnection con = new OracleConnection(connection_string);
                    OracleCommand cmd = new OracleCommand("SELECT P.SURNAME,P.NAME,P.OTCHESTVO, extract(year from TO_DATE(DATE_OF_BIRTH,'DD-MM-rr')) FROM PACIENT P WHERE P.ID='" + number_kart.Text.ToString() + "'", con);
                    OracleCommand command = new OracleCommand("SELECT to_date(PR.DATA,'dd-mm-yy'),HIS.DATE_VIPISKI,D.SURNAME,HIS.COMPLAINS,HIS.OSMOTR,HIS.DIAGNISIS,HIS.MEDICATION FROM MEDICAL_HISTIRY HIS, PRIEM PR, DOCTOR D, PACIENT P WHERE HIS.PRIEM_ID=PR.ID AND PR.DOCTOR_ID=D.ID AND P.ID=PR.PACIENT_ID AND P.ID='" + number_kart.Text.ToString() + "'", con);
                    con.Open();
          
                        OracleDataReader reader = command.ExecuteReader();
                        OracleDataReader reader1 = cmd.ExecuteReader();
                        
                        if(reader1.HasRows==false)
                            MessageBox.Show("Неверный номер карты!");
                        while (reader1.Read())
                            label_name_pacient.Text = reader1[0].ToString() + " " + reader1[1].ToString() + " " + reader1[2].ToString() + " " + reader1[3].ToString() + "г.р.";
                        int c = 0;
                        listView1.Items.Clear();

                        while (reader.Read())
                        {
                           
                            listView1.Items.Add(reader[0].ToString());//первый столбец listview1
                            for (int i = 1; i < 7;i++ )
                                listView1.Items[c].SubItems.Add(reader[i].ToString());
                                 //второй столбец listview1 является первым сабитемом первого столбца
                                 //третий столбец listview1 является вторым сабитемом первого столбца                      
                               c++;
                        }
                      
                        con.Close();
                    }
                   


                
            }
            catch
            {
                MessageBox.Show("Неверный номер карты!");

            }
        }



        void ReadData()
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT PR.DATA,HIS.DATE_VIPISKI,D.SURNAME,HIS.COMPLAINS,HIS.OSMOTR,HIS.DIAGNISIS,HIS.MEDICATION FROM MEDICAL_HISTIRY HIS, PRIEM PR, DOCTOR D, PACIENT P WHERE HIS.PRIEM_ID=PR.ID AND HIS.LECH_DOCTOR_ID=D.ID AND  P.ID='" + number_kart.Text.ToString() + "'", con);
            con.Open();
            //adapter.Fill(dataSet1);
            con.Close();
            foreach (DataColumn column in dataSet1.Tables[0].Columns)
                listView1.Columns.Add(column.Caption);
            foreach (DataRow row in dataSet1.Tables[0].Rows)
            {
                ListViewItem item = listView1.Items.Add(row.ItemArray[0].ToString());
                for (int i = 1; i < row.ItemArray.Length; i++)
                    item.SubItems.Add(row.ItemArray[i].ToString());


            }
        }

        private void unit_MouseClick(object sender, MouseEventArgs e)//заполнение combo_box_unit отделения
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select name from unit", con);
            unit.Items.Clear();
             con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    unit.Items.Add(reader.GetValue(0));
                }
            }
           
            
        }

        private void go_to_doctor_Click(object sender, EventArgs e)//НАПРАВИТЬ К ВРАЧУ
        {
            try
            {
                listView1.Items.Clear();
                label_name_pacient.Text = "Фамилия Имя Отчество г.р.";

                if (number_kart.Text == "" && unit.Text == "")
                    MessageBox.Show("Введите номер карты пациента и выберите отделение!");
                else if (number_kart.Text == "")
                {
                    MessageBox.Show("Введите номер карты пациента!");
                }
                else if (textBox4.Text == "")
                    MessageBox.Show("Нужно уточнить дежурного врача!");
                else if (unit.Text != "")
                {
                    OracleConnection con = new OracleConnection(connection_string);
                    OracleCommand command = new OracleCommand("INSERT INTO PRIEM (DATA, PACIENT_ID,DOCTOR_ID) Values ('" + dateTimePicker1.Value.ToShortDateString() + "','" + number_kart.Text.ToString() + "'," + "(SELECT ID FROM DOCTOR WHERE SURNAME='" + textBox4.Text.ToString() + "')" + ")", con);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Успех!");
                    number_kart.Clear();
                }
                else MessageBox.Show("Выберите отделение!");
            }
            catch
            {
                MessageBox.Show("Неудача!");
            }
        }

        private void unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand command = new OracleCommand("SELECT D.SURNAME FROM DOCTOR D, UNIT U, RASPISANIE_VRACHEI R WHERE D.UNIT_ID=U.ID AND R.DOCTOR_ID=D.ID AND R.DAT='" + dateTimePicker1.Value.Date.ToShortDateString() + "' AND U.NAME='" + unit.Text.ToString() + "'", con);
            con.Open();
            OracleDataReader reader1 = command.ExecuteReader();
            while (reader1.Read())
                textBox4.Text = reader1[0].ToString();
            con.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = data_time;
        }

        

        
        
        
    }
       

  }

    

