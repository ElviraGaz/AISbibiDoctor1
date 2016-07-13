using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace AISbibiDoctor1
{
    public partial class Glavvrach : Form
    {
        private string connection_string = "Data Source=XE;User Id=bibi;Password=9";
        private BindingSource bindingsource = new BindingSource();
        private DataTable Doctors;
        private DataTable Dates;
        private DataTable Raspisanie;
        private DataTable Doc_count_dej;
        private DataTable pacient_on_stacionar;
        private DataTable table_kart_pacienta;
        private DataTable table_chambers;
        private DataTable table_no_priem;
        private string cell;
        private string surname;
        private DateTime[] MONTHDates;
        private int i = 3;
        
        public Glavvrach()
        {
            InitializeComponent();

        }


        private void Glavvrach_Load(object sender, EventArgs e)
        {
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DOCTOR". При необходимости она может быть перемещена или удалена.
            this.dOCTORTableAdapter.Fill(this.dataSet1.DOCTOR);
            Doctors = new DataTable();
            Dates = new DataTable();
            Raspisanie = new DataTable();
            Doc_count_dej = new DataTable();
            pacient_on_stacionar = new DataTable();
            table_kart_pacienta = new DataTable();
            table_chambers = new DataTable();
            table_no_priem = new DataTable();
        }

     //-------------расписание Врачей----------------
       
        private void combo_unit_MouseClick(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select name from unit", con);
            combo_unit.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    combo_unit.Items.Add(reader.GetValue(0));
                }
            }
        }




        private void combo_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                month_calendar_bolded_dates();
                show_table_doctors();
                show_table_raspisanie();
                month_calendar_bolded_dates();
                label_help.Text = "Для выбора врача-одинарный клик \nпо столбцу Фамилия";
                Dates.Clear();
            }
            catch { }
        }




        void month_calendar_bolded_dates()
        {
            int i = 0;
           
            MONTHDates = new DateTime[31];


            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com = new OracleCommand("SELECT DAT FROM RASPISANIE_VRACHEI R,DOCTOR D WHERE extract (month from(TO_DATE(DAT,'DD-MM-yy')))='" + monthCal_raspisanie.SelectionEnd.Month.ToString() + "' AND D.ID=R.DOCTOR_ID AND D.UNIT_ID=GET_UNIT_ID('"+combo_unit.Text.ToString()+"')", con);
            con.Open();
            OracleDataReader reader = com.ExecuteReader();
            while (reader.Read() && i < 31)
            {
                MONTHDates[i] = Convert.ToDateTime(reader[0]);
                i++;
            }
            con.Close();
            monthCal_raspisanie.BoldedDates = MONTHDates;
        }



        void show_table_doctors_count()
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com = new OracleCommand("Select d.surname as Фамилия,count(*) as Количество  from doctor d right join raspisanie_vrachei r on d.id=r.doctor_id where extract(month from to_date(r.dat,'dd-mm-yy'))='" + monthCal_raspisanie.TodayDate.Month.ToString() + "' and d.unit_id=get_unit_id('" + combo_unit.Text.ToString() + "') group by d.surname", con);
            Doc_count_dej.Columns.Clear();
            Doc_count_dej.Clear();
            con.Open();
            OracleDataAdapter adapter = new OracleDataAdapter(com);            
            adapter.Fill(Doc_count_dej);
            con.Close();
            raspisanie_doctor.DataSource = Doc_count_dej;
        }

        void show_table_doctors() 
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com = new OracleCommand("Select d.surname as Фамилия  from doctor d where d.unit_id=get_unit_id('" + combo_unit.Text.ToString() + "') order by d.post_id desc", con);
            Doc_count_dej.Columns.Clear();
            Doc_count_dej.Clear();
            con.Open();
            OracleDataAdapter adapter = new OracleDataAdapter(com);
            adapter.Fill(Doc_count_dej);
            con.Close();
            raspisanie_doctor.DataSource = Doc_count_dej;
        }


        void show_table_raspisanie() 
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com2 = new OracleCommand();         
            com2.CommandText = "select r.dat as Дата ,d.surname as Фамилия from raspisanie_vrachei r left join doctor d on d.id=r.doctor_id where d.unit_id=get_unit_id('" + combo_unit.Text.ToString() + "') and TO_DATE(DAT,'DD-MM-yy')>='" + dateTimePicker_s.Value.ToShortDateString() + "' and TO_DATE(DAT,'DD-MM-yy')<='" + dateTimePicker_po.Value.ToShortDateString() + "'";
            com2.Connection = con;
            Raspisanie.Clear();
            con.Open();
            OracleDataAdapter adapter2 = new OracleDataAdapter(com2);
            adapter2.Fill(Raspisanie);
            con.Close();
            dataGridView_show_pasp.DataSource = Raspisanie;
        }

        

        //Дни дежурства месяца врача
        void show_days_dejurstva()
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com2 = new OracleCommand("SELECT dat as Дата FROM RASPISANIE_VRACHEI WHERE DOCTOR_ID=GET_DOCTOR_ID('" + surname + "') and extract (month from(TO_DATE(DAT,'DD-MM-yy')))='" + monthCal_raspisanie.SelectionEnd.Month.ToString() + "'", con);
            con.Open();
            OracleDataAdapter adapter = new OracleDataAdapter(com2);
            Dates.Columns.Clear();
            Dates.Clear();
            adapter.Fill(Dates);
            dataGridView_dates.DataSource = Dates;
            con.Close();
        }

        private void button_dejurit_Click(object sender, EventArgs e)
        {
            try
            {
                if (combo_unit.Text == "")
                    MessageBox.Show("Для начала выберите отделение!");
                else if (label_name.Text == "Фамилия Имя Отчество")
                    MessageBox.Show("Выберите врача!");
                else
                {
                    foreach (DateTime date in MONTHDates)
                        if (date.Date.Equals(monthCal_raspisanie.SelectionEnd.Date))
                        {
                            MessageBox.Show("Уже дежурят!");
                            return;
                        }

                    OracleConnection con = new OracleConnection(connection_string);
                    OracleCommand com = new OracleCommand("INSERT INTO RASPISANIE_VRACHEI VALUES('" + monthCal_raspisanie.SelectionEnd.ToShortDateString() + "', get_doctor_id('" + surname + "'))", con);
                    show_days_dejurstva();
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("УСПЕХ!");
                    show_days_dejurstva();
                    show_table_doctors();
                    show_table_raspisanie();
                    month_calendar_bolded_dates();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неудача!");
            }

        }

        private void raspisanie_doctor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                label_help.Text = "";
                surname = raspisanie_doctor[e.ColumnIndex, e.RowIndex].Value.ToString();
                OracleConnection con = new OracleConnection(connection_string);
                OracleCommand com = new OracleCommand("SELECT SURNAME,NAME,OTCHESTVO FROM DOCTOR WHERE ID=GET_DOCTOR_ID('" + raspisanie_doctor[e.ColumnIndex, e.RowIndex].Value.ToString() + "')", con);
                con.Open();
                OracleDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    label_name.Text = reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString();

                }
                con.Close();
                show_days_dejurstva();
            }
            catch
            {
            }
        }

        
       
        
        
        
        //insert doctor

        private void button_insert_new_doctor_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);
            try
            {

                OracleCommand com = new OracleCommand("INSERT into DOCTOR (SURNAME,NAME,OTCHESTVO,PASPORT,SPECIALTY_ID,UNIT_ID,POST_ID) Values ('" + textBox_surname.Text.ToString() + "','" + textBox_name.Text.ToString() + "','" + textBox_otchestvo.Text.ToString() + "','" + textBox_passport.Text.ToString() + "'," + "(SELECT ID FROM SPECIALITY WHERE NAME='" + comboBox_speciality.Text.ToString() + "')," + "(SELECT ID FROM UNIT WHERE NAME='" + comboBox_unit.Text.ToString() + "'),(SELECT ID FROM POST WHERE NAME='" + comboBox_post.Text.ToString() + "'))", con);


                if (textBox_surname.Text == "" || textBox_name.Text == "" || textBox_otchestvo.Text == "" || textBox_passport.Text == "")
                {
                    MessageBox.Show("Данных недостаточно!");

                }
                else
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Врач добавлен!");


                }
                textBox_surname.Clear();
                textBox_name.Clear();
                textBox_otchestvo.Clear();
                textBox_passport.Clear();
            }
            catch
            {
                MessageBox.Show("Невозможно добавить врача!");

            }
        }

        private void comboBox_speciality_MouseClick(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select name from speciality", con);
            comboBox_speciality.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox_speciality.Items.Add(reader.GetValue(0));
                }
            }
        }

        private void comboBox_unit_MouseClick(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select name from unit", con);
            comboBox_unit.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox_unit.Items.Add(reader.GetValue(0));
                }
            }
        }

        private void comboBox_post_MouseClick(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select name from post", con);
            comboBox_post.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox_post.Items.Add(reader.GetValue(0));
                }
            }
        }


        //-----редактирование данных о врачах------
        private void comboBox_unit_1_MouseClick(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select name from unit", con);
            comboBox_unit_1.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox_unit_1.Items.Add(reader.GetValue(0));
                }
            }
        }

        private void comboBox_unit_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com = new OracleCommand("SELECT surname as Фамилия, name as Имя,otchestvo as Отчество,pasport as Паспорт,speciality as Специальность,post as Должность FROM VIEW_DOCTORS WHERE UNIT='" + comboBox_unit_1.Text.ToString() + "'", con);
            con.Open();
            OracleDataAdapter adapter = new OracleDataAdapter(com);
            Doctors.Columns.Clear();
            Doctors.Clear();
            adapter.Fill(Doctors);
            con.Close();
            dataGridView_doctors.DataSource = Doctors;
            

        }

        private void dataGridView_doctors_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(connection_string);
                switch (e.ColumnIndex)
                {

                    case 0:
                        {
                            OracleCommand com = new OracleCommand("update view_doctors set surname='" + dataGridView_doctors[e.ColumnIndex, e.RowIndex].Value.ToString() + "' where pasport='" + dataGridView_doctors[3, e.RowIndex].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 1:
                        {
                            OracleCommand com = new OracleCommand("update view_doctors set name='" + dataGridView_doctors[e.ColumnIndex, e.RowIndex].Value.ToString() + "' where pasport='" + dataGridView_doctors[3, e.RowIndex].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 2:
                        {
                            OracleCommand com = new OracleCommand("update view_doctors set otchestvo='" + dataGridView_doctors[e.ColumnIndex, e.RowIndex].Value.ToString() + "' where pasport='" + dataGridView_doctors[3, e.RowIndex].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 3:
                        {
                            OracleCommand com = new OracleCommand("update view_doctors set pasport='" + dataGridView_doctors[e.ColumnIndex, e.RowIndex].Value.ToString() + "' where surname='" + dataGridView_doctors[0, e.RowIndex].Value.ToString() + "' and name='" + dataGridView_doctors[1, e.RowIndex].Value.ToString() + "'", con);
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
                dataGridView_doctors[e.ColumnIndex, e.RowIndex].Value = cell;
            }
        }

        private void dataGridView_doctors_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
              
                cell = dataGridView_doctors[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            catch { }
        }

        
        

       
        //-------------------------пациенты---------------------

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_glav_vrach.SelectedIndex == 2)
            {
                OracleConnection con = new OracleConnection(connection_string);
                OracleCommand com = new OracleCommand("select count(*) from pacient_in_chamber", con);
                OracleCommand com2 = new OracleCommand("select * from pacients_in_stacionar", con);
                OracleCommand com3 = new OracleCommand("Select pac.surname as Фамилия,pac.name as Имя,pac.policy as Полис,w.data as Дата_приема,w.surname as Врач from waiting_pacient w,priem p,pacient pac where w.data<'"+DateTime.Now.Date.ToShortDateString()+"' and p.id=w.priem_id and p.pacient_id=pac.id", con);
                con.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(com2);
                OracleDataAdapter adapter3 = new OracleDataAdapter(com3);
                pacient_on_stacionar.Columns.Clear();
                pacient_on_stacionar.Clear();
                table_no_priem.Columns.Clear();
                table_no_priem.Clear();
                adapter.Fill(pacient_on_stacionar);
                adapter3.Fill(table_no_priem);
                OracleDataReader reader = com.ExecuteReader();
                while (reader.Read())
                    label_count_stac.Text = reader[0].ToString();
                con.Close();
                dataGridView_pac_on_stac.DataSource = pacient_on_stacionar;
                dataGridView_no_priem.DataSource = table_no_priem;

            }

        }

        private void button_prosmotr_Click(object sender, EventArgs e)
        {
            if (combo_unit.Text.ToString() == "")
                MessageBox.Show("Для начала выберите отделение!");
            else if (dateTimePicker_s.Value > dateTimePicker_po.Value)
                MessageBox.Show("Проверьте даты");
            else
            show_table_raspisanie();
        }





         private void dataGridView_pac_on_stac_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                OracleConnection con = new OracleConnection(connection_string);
                table_kart_pacienta.Columns.Clear();
                table_kart_pacienta.Clear();
                OracleCommand com = new OracleCommand("Select * from view_medical_history where номер_карты='" + dataGridView_pac_on_stac[0, e.RowIndex].Value.ToString() + "'", con);
                con.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(com);
                adapter.Fill(table_kart_pacienta);
                con.Close();
                dataGridView_karta.DataSource = table_kart_pacienta;
            }
            catch { }
         }






        //  --------  Дерево------

        void ReadData_tree()
         {
            


            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com = new OracleCommand("Select * from post");
            
            com.Connection = con;
            OracleDataAdapter adapter = new OracleDataAdapter(com);
            
            DataSet dataset = new DataSet();
            
            adapter.Fill(dataset);
            
            con.Close();
            

            DataRelation relation = new DataRelation("post", dataset.Tables[0].Columns[0], dataset.Tables[0].Columns[2]);
            dataset.Relations.Add(relation);


            foreach (DataRow row in dataset.Tables[0].Rows)
                if (row.IsNull(2))
                    AddTreenode(row, null);
            
                 
                
            
        }
        void AddTreenode(DataRow row, TreeNode node)
        {
          
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com2 = new OracleCommand("Select surname,name,otchestvo from Doctor where post_id='" + i.ToString() + "' and unit_id=get_unit_id('"+comboBox_unit_2.Text.ToString()+"') order by surname", con);
            OracleCommand com_glav = new OracleCommand("Select surname,name,otchestvo from Doctor where post_id='" + i.ToString() + "'", con);
            
            con.Open();
            OracleDataReader reader = com2.ExecuteReader();
            OracleDataReader reader_gv = com_glav.ExecuteReader();
            
           


            TreeNode currnode;
            if (node == null)
            {
                currnode = treeView1.Nodes.Add(row.ItemArray[1].ToString());
                while (reader_gv.Read())
                    currnode.Nodes.Add(reader_gv[0].ToString()+" "+reader_gv[1].ToString()+" "+reader_gv[2].ToString());
                --i;
            }
            else {
                currnode = node.Nodes.Add(row.ItemArray[1].ToString());
                while(reader.Read())
                    currnode.Nodes.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                --i;
                  }
            foreach (DataRow currow in row.GetChildRows("post"))
            {
                AddTreenode(currow, currnode);
            }
            con.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i = 3;
            treeView1.Nodes.Clear();       
            ReadData_tree();
           
        }

        
        private void comboBox_unit_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_insert_chamber.Enabled = true;
            get_table_chamber();
            i = 3;
            treeView1.Nodes.Clear();
            ReadData_tree();
           
        }

        private void comboBox_unit_2_MouseClick(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select name from unit", con);
            comboBox_unit_2.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox_unit_2.Items.Add(reader.GetValue(0));
                }
            }
        }

        private void button_insert_chamber_Click(object sender, EventArgs e)
        {
            if (textBox_chamber.Text == "")
                MessageBox.Show("Не указали количество мест");
            else
            { OracleConnection con = new OracleConnection(connection_string);
              OracleCommand com = new OracleCommand("insert into chamber(unit_id,quantity,free_places) values(get_unit_id('"+comboBox_unit_2.Text.ToString()+"'),'"+textBox_chamber.Text.ToString()+"','"+textBox_chamber.Text.ToString()+"')",con);
              con.Open();
              com.ExecuteNonQuery();
              con.Close();
              MessageBox.Show("Палата добавлена");
            }

        }

        //Данные о палатах
        void get_table_chamber()
        {
            OracleConnection con = new OracleConnection(connection_string);
            con.Open();
            OracleCommand cmd_palati = new OracleCommand("Select id AS Номер, quantity as Вместимость,free_places as Свободно from chamber where unit_id=get_unit_id('"+comboBox_unit_2.Text.ToString()+"')order by id", con);
            OracleDataAdapter adapter_p = new OracleDataAdapter(cmd_palati);
            table_chambers.Clear();
            table_chambers.Columns.Clear();
            adapter_p.Fill(table_chambers);
            con.Close();
            dataGridView_chamber.DataSource = table_chambers;
        }

        private void comboBox_doc_MouseClick(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select surname from doctor where unit_id=get_unit_id('"+comboBox_unit_2.Text.ToString()+"')", con);
            comboBox_doc.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox_doc.Items.Add(reader.GetValue(0));
                }
            }
        }

        private void comboBox_un_MouseClick(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select name from post where id>1", con);
            comboBox_pos.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox_pos.Items.Add(reader.GetValue(0));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
               
                
                if (comboBox_unit_2.Text.ToString() == "")
                    MessageBox.Show("Выберите отделение!");
                else if (comboBox_doc.Text.ToString() == "")
                    MessageBox.Show("Выберите врача!");
                else if (comboBox_pos.Text.ToString() == "")
                    MessageBox.Show("Выберите должность!");
                else
                {
                    OracleConnection con = new OracleConnection(connection_string);
                    OracleCommand com = new OracleCommand("update doctor set post_id=get_post_id('" + comboBox_pos.Text.ToString() + "') where surname='" + comboBox_doc.Text.ToString() + "'", con);
                    OracleCommand com1 = new OracleCommand("update doctor set post_id=1 where id=(select id from doctor where post_id=get_post_id('" + comboBox_pos.Text.ToString() + "') and unit_id=get_unit_id('" + comboBox_unit_2.Text.ToString() + "'))", con);
                    OracleCommand com3 = new OracleCommand("do_glav_vrach", con);
                    com3.CommandType = CommandType.StoredProcedure;
                    com3.Parameters.Add("post_name", OracleType.NVarChar);                   
                    com3.Parameters[0].Value = comboBox_pos.Text.ToString();

                    con.Open();
                    com3.ExecuteNonQuery();
                    com1.ExecuteNonQuery();
                    com.ExecuteNonQuery();
                    
                    con.Close();
                    MessageBox.Show("Успех!");
                    i = 3;
                    treeView1.Nodes.Clear();
                    ReadData_tree();
                    comboBox_doc.Text = "";
                    comboBox_pos.Text = "";

                }
            }
           catch (Exception)
           {
               MessageBox.Show("Не удалось изменить!");
           }
        }

       

        

        

       

        //-----------------------------------
        
    }
}

