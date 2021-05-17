﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinarna_Ambulanta_Milenici
{
    public partial class Termin : Form
    {
        public Termin()
        {
            InitializeComponent();
        }

        private void Termin_Load(object sender, EventArgs e)
        {
            
        }

        
          private void addNewAppointment()
        {
            string novdatum = dtpDatum.Value.ToString("dd-MM-yyyy");
            string cas = dtpCas.Value.ToString("h");
            string minuti = dtpCas.Value.ToString("m");

            //Отворање на конекција со датабазата co string за конекција од помошната класа DBHelper
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DBHelper.ConnVal();
            connection.Open();
 
            //sql query за додавање во табела
            string sql = "INSERT INTO Termini" +
                "(Datum,HH,MM,Ime) " +
                "VALUES(@datum,@hh,@mm,@ime)";
 
            //додавање вредности во командата (од sql query и конекцијата) која се извршува за додавање на нов ред во табелата
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@datum", novdatum); //ovie tbdate tbhour tbminutes si gi pisuvas od kaj so gi zemas informaciite
                cmd.Parameters.AddWithValue("@hh", cas);
                cmd.Parameters.AddWithValue("@mm", minuti);
 
                cmd.CommandType = CommandType.Text;
 
                //пробај да ја извршиш командата, доколку е не е успешно прикажи порака
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("Додавањето на нов миленик во датабазата е неуспешно! Пробајте повторно.");
            }
            //Затвори ја конекцијата
            connection.Close();
        }
         


        private void btnVnesi_Click(object sender, EventArgs e)
        {
            
            NovTermin novTermin = new NovTermin();
            novTermin.ImeNaPacient = tbTerminImePacient.Text;
            novTermin.DateAndTime = dtpDatum.Text;
            //novTermin.Opis = rtbKratokOpis.Text;
            
            DialogResult = DialogResult.OK;
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
