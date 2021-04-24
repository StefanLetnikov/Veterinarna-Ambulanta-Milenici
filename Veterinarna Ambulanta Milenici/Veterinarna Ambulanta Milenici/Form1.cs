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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDodadi_Click(object sender, EventArgs e)
        {
            Sopstvenik novSopstvenik = new Sopstvenik();
            Milenik novMilenik = new Milenik();
            novSopstvenik.ImeSopstvenik = tbImeSopstvenik.Text;
            novSopstvenik.PrezimeSopsrvnik = tbPrezimeSopstvenik.Text;
            novSopstvenik.EmailSopsrtvenik = tbEmailSopstvenik.Text;
            novSopstvenik.BrojZaKontaktSopstvenik = mtbKontakt.Text;

            novMilenik.TipZivotno = tbVidZivotno.Text;
            novMilenik.RasaZivotno = tbRasaZivotno.Text;
            novMilenik.ImeZivotno = tbImeZivotno.Text;
            int.TryParse(tbStarostZivotno.Text, out int starost);
            novMilenik.GodiniZivotno = starost;

            if (cbMaskiPol.Checked)
            {
                //MessageBox.Show("Test");
                novMilenik.PolZivotno = "М";
            }
            else if(cbZenskiPol.Checked)
            {
                novMilenik.PolZivotno = "Ж";
            }

            novSopstvenik.addMilenik(novMilenik);

            DataGridViewRow row = (DataGridViewRow)dgvInfoTabela.Rows[0].Clone();
            row.Cells[0].Value = novSopstvenik.ImeSopstvenik;
            row.Cells[1].Value = novSopstvenik.PrezimeSopsrvnik;
            row.Cells[2].Value = novSopstvenik.BrojZaKontaktSopstvenik;
            row.Cells[3].Value = novMilenik.TipZivotno;
            row.Cells[4].Value = novMilenik.RasaZivotno;
            row.Cells[5].Value = novMilenik.ImeZivotno;
            row.Cells[6].Value = novMilenik.GodiniZivotno;
            dgvInfoTabela.Rows.Add(row);
        }

        
    }
}
