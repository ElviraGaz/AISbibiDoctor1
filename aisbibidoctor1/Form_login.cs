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
    public partial class Form_login : Form
    {
       

        public Form_login()
        {
            InitializeComponent();

        }

        
        private void button_enter_Click(object sender, EventArgs e)
        {
          
               try
            {
                    switch (comboBox_user.SelectedItem.ToString())
                    {
                        case "Сестра":

                            Form sister = new Sister();
                            sister.ShowDialog();
                            break;
                        case "Врач":
                            Form doctor = new Doctor();
                            doctor.ShowDialog();
                            break;
                        case "Главный врач":
                            Glavvrach glavvrach = new Glavvrach();
                            glavvrach.Show();
                            break;
                    }
               }
               catch (Exception)
               {
                   MessageBox.Show("Проверьте поля ввода!");
               }
                    
            }

            



   
            
      
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox_user.Text == "сестра")
            {
                Form sis = new Sister();
                sis.ShowDialog();
            }
            if (comboBox_user.Text == "врач")
            {
                Form doc = new Doctor();
                doc.ShowDialog();
            }
            if (comboBox_user.Text == "главный врач")
            {
                Form glav = new Glavvrach();
                glav.ShowDialog();
            }


        }

        private void comboBox_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection("Data Source=XE;User Id=bibi;Password=9");
            OracleCommand cmd1 = conn.CreateCommand();
            OracleCommand cmd2 = conn.CreateCommand();
            OracleCommand cmd3 = conn.CreateCommand();
            cmd1.CommandText = "SELECT ID FROM PASSWORD WHERE USER_NAME='DOCTOR'";
            cmd2.CommandText = "SELECT ID FROM PASSWORD WHERE USER_NAME='SISTER'";
            cmd3.CommandText = "SELECT ID FROM PASSWORD WHERE USER_NAME='Glav_vrach'";
            conn.Open();
            try
            {
                textBox_login.Enabled = false;
                textBox_password.Enabled = false;

                if (comboBox_user.SelectedItem.ToString() == "Сестра")
                {
                    textBox_login.Clear();
                    textBox_login.Text = "Sister";
                    textBox_password.Text = cmd2.ExecuteOracleScalar().ToString();
                }


                if (comboBox_user.SelectedItem.ToString() == "Врач")
                {
                    textBox_login.Clear();
                    textBox_login.Text = "Doctor";
                    textBox_password.Text = cmd1.ExecuteOracleScalar().ToString();
                }



                if (comboBox_user.SelectedItem.ToString() == "Главный врач")
                {
                    textBox_login.Clear();
                    textBox_login.Text = "Glav_vrach";
                    textBox_password.Text = cmd3.ExecuteOracleScalar().ToString();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Проверьте поля ввода!");
            }
            conn.Close();
           
        }

       
    }
}
