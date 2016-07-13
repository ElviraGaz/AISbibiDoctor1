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
    public partial class Doctor : Form
    {
        private string connection_string = "Data Source=XE;User Id=bibi;Password=9";
        private DataTable tabl;
        private DataTable table_waiting_pacient;
        private DataTable table_chambers;
        private DataTable table_med_karta;
        private DataTable table_stacionar_pac;
        private DataTable table_med_history;
        private DataTable table_raspisanie;
        private string cellrow;
        private string cell;
        private DateTime data_time;

        public Doctor()
        {
            InitializeComponent();
            data_time = DateTime.Now;
        }


        private void Doctor_Load(object sender, EventArgs e)
        {
            table_chambers = new DataTable();
            table_med_karta = new DataTable();
            table_waiting_pacient = new DataTable();
            tabl = new DataTable();
            table_stacionar_pac = new DataTable();
            table_med_history = new DataTable();
            table_raspisanie = new DataTable();
        }


        


        //ожидающие приема пациенты
        void get_table_waiting_pacient()
        {
            OracleConnection con = new OracleConnection(connection_string);
            con.Open();
            //OracleCommand cmd_waiting_pac = new OracleCommand("SELECT P.ID,P.SURNAME,P.NAME,P.OTCHESTVO, P.DATE_OF_BIRTH,P.POLICY FROM PACIENT P,PRIEM PR WHERE P.ID=PR.PACIENT_ID AND PR.DATA='" + dateTimePicker1.Value.Date.ToShortDateString() + "'AND PR.DOCTOR_ID= GET_DOCTOR_ID('" + doctor_fam.Text.ToString() + "')", con);
            OracleCommand cmd_waiting_pac = new OracleCommand("select w.pacient_id as Номер_карты,p.name as Имя,p.surname as Фамилия,p.date_of_birth as Дата_рождения,p.policy as Полис from waiting_pacient w,pacient p where p.id=w.pacient_id and data='"+dateTimePicker1.Value.ToShortDateString()+"' and w.surname='"+doctor_fam.Text.ToString()+"'",con);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd_waiting_pac);
            table_waiting_pacient.Clear();
            table_waiting_pacient.Columns.Clear();
            adapter.Fill(table_waiting_pacient);
            con.Close();
            dataGridView_pac_priem.DataSource = table_waiting_pacient;
        }



        //Данные о палатах
        void get_table_chamber()
        {
            OracleConnection con = new OracleConnection(connection_string);
            con.Open();
            OracleCommand cmd_palati = new OracleCommand("Select id AS Номер, quantity as Вместимость,free_places as Свободно from chamber where unit_id=GET_DOCTOR_UNIT_ID('" +doctor_fam.Text.ToString() + "') order by id", con);
            OracleDataAdapter adapter_p = new OracleDataAdapter(cmd_palati);
            table_chambers.Clear();
            table_chambers.Columns.Clear();
            adapter_p.Fill(table_chambers);
            con.Close();
            dataGridView_free_chamber.DataSource = table_chambers;
        }

        //Стационарные больные
        void get_table_stacionar_pacient()
        {
            OracleConnection con = new OracleConnection(connection_string);
            con.Open();
            OracleCommand cmd_stacionar_pac = new OracleCommand("SELECT distinct P.ID as Номер_карты, P.SURNAME as Фамилия,P.NAME as Имя,P.DATE_OF_BIRTH as Дата_рождения,P.POLICY as Полис,PC.CMB_ID as Палата FROM PACIENT P RIGHT JOIN PACIENT_IN_CHAMBER PC on p.id=pc.PAC_ID,PRIEM PR WHERE pc.PAC_ID=pr.PACIENT_ID AND PR.DOCTOR_ID=GET_DOCTOR_ID('" + doctor_fam.Text.ToString() + "') ORDER BY PC.CMB_ID", con);
            OracleDataAdapter adapter_lejat = new OracleDataAdapter(cmd_stacionar_pac);
            table_stacionar_pac.Clear();
            table_stacionar_pac.Columns.Clear();
            adapter_lejat.Fill(table_stacionar_pac);
            con.Close();
            dataGridView_obhod.DataSource = table_stacionar_pac;
        }
        //карта пациента
        void get_table_med_karta()
        {
            OracleConnection con = new OracleConnection(connection_string);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT PR.DATA as Дата,HIS.DATE_VIPISKI as Дата_выписки,D.SURNAME as Фамилия,HIS.COMPLAINS as Жалобы,HIS.OSMOTR as Осмотр,HIS.DIAGNISIS as Диагноз,HIS.MEDICATION as Лечение FROM MEDICAL_HISTIRY HIS, PRIEM PR, DOCTOR D, PACIENT P WHERE HIS.PRIEM_ID=PR.ID AND PR.DOCTOR_ID=D.ID AND P.ID=PR.PACIENT_ID AND P.ID='" + number_kart_combo_box.Text.ToString() + "'" + "ORDER BY PR.DATA ASC", con);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            table_med_karta.Clear();
            table_med_karta.Columns.Clear();
            adapter.Fill(table_med_karta);
            con.Close();
            dataGridView_medkarta.DataSource =table_med_karta;
        }


        void Show_massage() 
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com = new OracleCommand("Select surname,name,otchestvo from doctor where id=GET_DOCTOR_ID('" + doctor_fam.Text.ToString() + "')", con);
            OracleCommand com_count = new OracleCommand("select count(*) from waiting_pacient where data='" + dateTimePicker1.Value.Date.ToShortDateString() +"' and surname='" + doctor_fam.Text.ToString() + "'",con);
            OracleCommand com_stac=new OracleCommand("");
            con.Open();
            OracleDataReader reader = com.ExecuteReader();
            object count = com_count.ExecuteScalar();                              
            while (reader.Read())
            label_message.Text = "Добрый день " + reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + "!\n"+"Ожидают приема "+count.ToString()+" пациент(ов)!\n";           
            con.Close(); 
        }


        void show_doctor_raspisanie() 
        {
            OracleConnection con = new OracleConnection(connection_string);
            table_raspisanie.Clear();
            table_raspisanie.Columns.Clear();
            OracleCommand com = new OracleCommand("SELECT dat as Дата FROM RASPISANIE_VRACHEI WHERE DOCTOR_ID=GET_DOCTOR_ID('" + doctor_fam.Text.ToString() + "') and extract (month from(TO_DATE(DAT,'DD-MM-yy')))='" + dateTimePicker1.Value.Month.ToString() + "'", con);
            con.Open();
            OracleDataAdapter adapter = new OracleDataAdapter(com);
            adapter.Fill(table_raspisanie);
            con.Close();
            dataGridView_raspisanie.DataSource = table_raspisanie;
        }


        //вход
        private void vhod_btn_Click(object sender, EventArgs e)
        {
            
            

            OracleConnection con = new OracleConnection(connection_string);
            
           
            OracleCommand command = new OracleCommand("SELECT PASPORT FROM DOCTOR WHERE PASPORT= GET_PASSWORD('" + doctor_fam.Text.ToString() + "')", con);

            
               con.Open();
               object password = command.ExecuteScalar();
               con.Close();  

                    try
                    {
                        if (unit_combo.Text.ToString() == "")
                            MessageBox.Show("Выберите отделение!");
                        else if (password_text_box.Text.ToString() == password.ToString())
                        {
                            label_message.Visible = true;
                            btn_good.Visible = true;
                            Show_massage();
                            label_pasword_error.Text = "";

                            get_table_waiting_pacient();
                            get_table_chamber();
                            get_table_stacionar_pacient();
                            show_doctor_raspisanie();
                            panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
           
                        }
                        else  label_pasword_error.Text = "Неверный пароль!"; 
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Для входа введите Фамилию и пароль!");
                    }

                                
        }



        private void unit_combo_MouseClick(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);

            OracleCommand com = new OracleCommand("Select name from unit", con);
            unit_combo.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    unit_combo.Items.Add(reader.GetValue(0));
                }
            }

        }


        private void number_kart_combo_box_MouseClick(object sender, MouseEventArgs e)
        {
            btn_good.Visible = false;
            label_message.Visible = false;
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com = new OracleCommand("SELECT P.ID FROM PACIENT P,PRIEM PR WHERE P.ID=PR.PACIENT_ID AND PR.DATA='" + dateTimePicker1.Value.Date.ToShortDateString() + "'AND PR.DOCTOR_ID= GET_DOCTOR_ID('" + doctor_fam.Text.ToString() + "')", con);
            number_kart_combo_box.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    number_kart_combo_box.Items.Add(reader.GetValue(0));
                }

            }
            con.Close();

        }

        
  
        private void number_kart_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand command_pac_name = new OracleCommand("SELECT SURNAME,NAME,OTCHESTVO FROM PACIENT WHERE ID='" + number_kart_combo_box.Text.ToString() + "'", con);
            con.Open();
            OracleDataReader pac_reader = command_pac_name.ExecuteReader();    
            while (pac_reader.Read())
            label_name_pac.Text = pac_reader[0].ToString() + " " + pac_reader[1].ToString() + " " + pac_reader[2].ToString();
            get_table_med_karta();
            con.Close();  
        }


        private void comboBox_chamber_MouseClick(object sender, MouseEventArgs e)
        {
           
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com = new OracleCommand("Select id from chamber where free_places>0 and unit_id=GET_DOCTOR_UNIT_ID('" + doctor_fam.Text.ToString() + "') order by id", con);
            comboBox_chamber.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox_chamber.Items.Add(reader.GetValue(0));
                }
            }
            con.Close();
        }
        
        //Отправить пациента на стационарное лечение!
        private void button_on_stacionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (number_kart_combo_box.Text.ToString() == "")
                    MessageBox.Show("Пациент не выбран!");
                else if (comboBox_chamber.Text.ToString() == "")
                    MessageBox.Show("Выберите номер палаты");
                else if (richTextBox_complains.Text.ToString() == "")
                    MessageBox.Show("Вы не записали жалобы пациента!");
                else if (richTextBox_osmotr.Text.ToString() == "")
                    MessageBox.Show("Заполните поле 'Осмотр'!");
                else
                {
                    save_med_history();
                    OracleConnection con = new OracleConnection(connection_string);
                    con.Open();
                    OracleCommand cmd_on_stacionar = new OracleCommand("INSERT INTO PACIENT_IN_CHAMBER VALUES('" + number_kart_combo_box.Text.ToString() + "','" + comboBox_chamber.Text.ToString() + "')", con);
                    cmd_on_stacionar.ExecuteNonQuery();
                   
                    con.Close();

                    get_table_waiting_pacient();
                    get_table_stacionar_pacient();
                    get_table_chamber();
                    MessageBox.Show("Пациент успешно отправлен на стационарное лечение!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось!Проверьте поля ввода!Попробуйте еще раз!");
            }

        }

        //cохраняем историю болезни!
        void save_med_history() 
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO MEDICAL_HISTIRY(PRIEM_ID,COMPLAINS,OSMOTR,DIAGNISIS,MEDICATION) VALUES((SELECT ID FROM PRIEM WHERE DATA='" + dateTimePicker1.Value.Date.ToShortDateString() + "'" + "AND PACIENT_ID='" + number_kart_combo_box.Text.ToString() + "'" + "AND DOCTOR_ID=GET_DOCTOR_ID('" + doctor_fam.Text.ToString() + "')),'" + richTextBox_complains.Text.ToString() + "','" + richTextBox_osmotr.Text.ToString() + "','" + richTextBox_diagnosis.Text.ToString() + "','" + richTextBox_medicamentation.Text.ToString() + "')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        void update_date_vipiski_med_history() 
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "UPDATE MEDICAL_HISTIRY SET DATE_VIPISKI='" + dateTimePicker1.Value.Date.ToShortDateString() + "' WHERE PRIEM_ID=(SELECT ID FROM PRIEM WHERE DATA='" + dateTimePicker1.Value.Date.ToShortDateString() + "'" + "AND PACIENT_ID='" + number_kart_combo_box.Text.ToString() + "' AND DOCTOR_ID=GET_DOCTOR_ID('" + doctor_fam.Text.ToString() + "'))";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
        

        //отпустить домой!
        private void button_go_to_home_Click(object sender, EventArgs e)
        {
            try
            {
                if (number_kart_combo_box.Text.ToString() == "")
                    MessageBox.Show("Пациент не выбран!");
                else
                {
                    save_med_history();
                    update_date_vipiski_med_history();
                    get_table_waiting_pacient();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось выписать пациента!");
            }
            
        }

       


        private void comboBox_number_kart_MouseClick_1(object sender, MouseEventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand com = new OracleCommand("SELECT distinct P.ID FROM PACIENT P RIGHT JOIN PACIENT_IN_CHAMBER PC on p.id=pc.PAC_ID,PRIEM PR WHERE pc.PAC_ID=pr.PACIENT_ID AND PR.DOCTOR_ID=GET_DOCTOR_ID('" + doctor_fam.Text.ToString() + "') ORDER BY P.ID", con);
            comboBox_number_kart.Items.Clear();
            con.Open();
            OracleDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox_number_kart.Items.Add(reader.GetValue(0));
                }

            }
            con.Close();
        }

        private void comboBox_number_kart_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(connection_string);
            OracleCommand command_pac_name = new OracleCommand("SELECT SURNAME,NAME,OTCHESTVO FROM PACIENT WHERE ID='" + comboBox_number_kart.Text.ToString() + "'", con);
            con.Open();
            OracleDataReader pac_reader = command_pac_name.ExecuteReader();

            while (pac_reader.Read())
                label_name.Text = pac_reader[0].ToString() + " " + pac_reader[1].ToString() + " " + pac_reader[2].ToString();

            //med_karta
            OracleCommand cmd = new OracleCommand("SELECT PR.DATA as Дата,HIS.DATE_VIPISKI as Дата_выписки,D.SURNAME as Фамилия,HIS.COMPLAINS as Жалобы,HIS.OSMOTR as Осмотр,HIS.DIAGNISIS as Диагноз,HIS.MEDICATION as Лечение FROM MEDICAL_HISTIRY HIS, PRIEM PR, DOCTOR D, PACIENT P WHERE HIS.PRIEM_ID=PR.ID AND PR.DOCTOR_ID=D.ID AND P.ID=PR.PACIENT_ID AND P.ID='" + comboBox_number_kart.Text.ToString() + "'" + "ORDER BY PR.DATA ASC", con);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView_med_kart_2.DataSource = dataset.Tables[0];

            //история болезни
            OracleCommand cmd_ist = new OracleCommand("select m.complains as Жалобы,m.osmotr as Осмотр,m.diagnisis as Диагноз,m.medication as Лечение from medical_histiry m left join priem pr on m.PRIEM_ID=pr.ID where pr.PACIENT_ID='" + comboBox_number_kart.Text.ToString() + "' and m.DATE_VIPISKI is null",con);
            table_med_history.Clear();
            table_med_history.Columns.Clear();
            OracleDataAdapter adapter_ist = new OracleDataAdapter(cmd_ist);
            adapter_ist.Fill(table_med_history);
            dataGridView_med_history.DataSource = table_med_history;
            con.Close();

        }


        //выписать пациента
        private void button_vipisat_pacienta_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_number_kart.Text.ToString() == "")
                    MessageBox.Show("Пациент не выбран!Выберите номер карты!");
                else if (dataGridView_med_history[2,0].Value.ToString() == "")
                    MessageBox.Show("Вы не поставили диагноз пациенту!");
                else if (dataGridView_med_history[3, 0].Value.ToString() == "")
                    MessageBox.Show("Пожалуйста назначьте лечение пациенту!");
                else
                {

                    OracleConnection con = new OracleConnection(connection_string);
                    OracleCommand com = new OracleCommand("delete from pacient_in_chamber where pac_id='" + comboBox_number_kart.Text.ToString() + "'", con);
                    OracleCommand com_upd_ch = new OracleCommand("UPDATE CHAMBER C SET C.FREE_PLACES=C.QUANTITY-(SELECT COUNT(*) FROM PACIENT_IN_CHAMBER P WHERE P.CMB_ID=C.ID)", con);
                    OracleCommand com_date_vipiski = new OracleCommand("UPDATE MEDICAL_HISTIRY SET DATE_VIPISKI='"+dateTimePicker1.Value.ToShortDateString()+"' WHERE   priem_id=(select id from priem p,medical_histiry m where m.priem_id=p.id and p.pacient_id='"+comboBox_number_kart.SelectedItem.ToString()+"' and date_vipiski is null)",con);
                    con.Open();
                    com.ExecuteNonQuery();
                    com_upd_ch.ExecuteNonQuery();
                    com_date_vipiski.ExecuteNonQuery();
                    con.Close();

                    get_table_stacionar_pacient();
                    get_table_chamber();

                    MessageBox.Show("Пациент успешно выписан!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось выписать пациента!");
            }
        }

        private void btn_good_Click(object sender, EventArgs e)
        {
            label_message.Visible = false;
            btn_good.Visible = false;
            panel6.BackColor = System.Drawing.SystemColors.Control;
        }


       //редактируем историю болезни
       

        private void dataGridView_med_history_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(connection_string);
                switch (e.ColumnIndex)
                {

                    case 0:
                        {
                            OracleCommand com = new OracleCommand("update medical_histiry med set med.complains='" + dataGridView_med_history[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE med.PRIEM_ID =(select p.id from priem p right join medical_histiry m on p.ID=m.PRIEM_ID where p.pacient_id='" + comboBox_number_kart.Text.ToString() + "' and m.DATE_VIPISKI is null ) ", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 1:
                        {
                            OracleCommand com = new OracleCommand("update medical_histiry med set med.osmotr='" + dataGridView_med_history[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE med.PRIEM_ID =(select id from priem p right join medical_histiry m on p.ID=m.PRIEM_ID where pacient_id='" + comboBox_number_kart.Text.ToString() + "' and m.DATE_VIPISKI is null ) ", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 2:
                        {
                            OracleCommand com = new OracleCommand("update medical_histiry med set med.diagnisis='" + dataGridView_med_history[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE med.PRIEM_ID =(select id from priem p right join medical_histiry m on p.ID=m.PRIEM_ID where pacient_id='" + comboBox_number_kart.Text.ToString() + "' and m.DATE_VIPISKI is null ) ", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 3:
                        {
                            OracleCommand com = new OracleCommand("update medical_histiry med set med.medication='" + dataGridView_med_history[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE med.PRIEM_ID =(select id from priem p right join medical_histiry m on p.ID=m.PRIEM_ID where pacient_id='" + comboBox_number_kart.Text.ToString() + "' and m.DATE_VIPISKI is null ) ", con);
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
                dataGridView_med_history[e.ColumnIndex, e.RowIndex].Value = cell;

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = data_time ;
        }

       

        

       

        
    }
}
