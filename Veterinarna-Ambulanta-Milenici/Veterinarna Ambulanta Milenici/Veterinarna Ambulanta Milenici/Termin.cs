using System;
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

        public NovTermin termin = new NovTermin();

        public Termin()
        {
            InitializeComponent();
            dtpDatum.CustomFormat = "dd/MM/yyyy";
        }

        
          private void addNewAppointment()
        {
            

            //Отворање на конекција со датабазата co string за конекција од помошната класа DBHelper
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DBHelper.ConnVal();
            connection.Open();
 
            //sql query за додавање во табела
            string sql = "INSERT INTO Termini" +
                "(Datum,Cas,Ime) " +
                "VALUES(@datum,@cas,@ime)";
 
            //додавање вредности во командата (од sql query и конекцијата) која се извршува за додавање на нов ред во табелата
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@datum", termin.Date);
                cmd.Parameters.AddWithValue("@cas", termin.Time);
                cmd.Parameters.AddWithValue("@ime", termin.ImeNaPacient);

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
            termin.Date = dtpDatum.Text;
            termin.ImeNaPacient = tbTerminImePacient.Text;
            termin.Time = dtpCas.Text;

            if (termin.Date.Length == 0 || termin.ImeNaPacient.Length == 0 || termin.Time.Length == 0)
                MessageBox.Show("Задолжително потполнете ги сите полиња!", "", MessageBoxButtons.OK);
            else
            {
                addNewAppointment();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
