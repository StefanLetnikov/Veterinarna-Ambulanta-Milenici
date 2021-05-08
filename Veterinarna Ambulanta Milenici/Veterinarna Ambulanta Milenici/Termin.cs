using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnVnesi_Click(object sender, EventArgs e)
        {
            NovTermin novTermin = new NovTermin();
            novTermin.ImeNaPacient = tbTerminImePacient.Text;
            novTermin.DateAndTime = dtpDatumICas.Text;
            novTermin.Opis = rtbKratokOpis.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
