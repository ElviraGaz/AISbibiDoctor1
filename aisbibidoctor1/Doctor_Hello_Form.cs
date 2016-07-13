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
    public partial class Doctor_Hello_Form : Form
    {
        private string connection_string = "Data Source=XE;User Id=bibi;Password=9";
        public Doctor_Hello_Form(string doctor)
        {
            InitializeComponent();
            
        }

        void hello()
        {
         // OracleConnection con = new OracleConnection(connection_string);
        //  OracleCommand command = new OracleCommand("SELECT COUNT(*) FROM PACIENT P,PRIEM PR WHERE P.ID=PR.PACIENT_ID AND PR.DATA='" +  + "'AND PR.DOCTOR_ID= GET_DOCTOR_ID('" +  + "')GROUP BY PR.DATA, PR.DOCTOR_ID", con);
          

        }
    }
}
