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
            //Повторна валидација доколку се кликне Додади Пациент без прво да се посетат задолжителните полињa
            if (ValidateIme() && ValidatePrezime() && ValidateKontakt() && ValidateEmail() && ValidateVidZivotno() && ValidateRasaZivotno()
                && ValidateStarostZivotno() &&  ValidateImeZivotno() && ValidatePol() && ValidateMikrocip())
            {
                string pol = gbPol.Controls.OfType<RadioButton>().First(rb => rb.Checked).ToString();

                Sopstvenik novSopstvenik = new Sopstvenik(tbImeSopstvenik.Text, tbPrezimeSopstvenik.Text, tbEmailSopstvenik.Text, mtbKontakt.Text);
                Milenik novMilenik = new Milenik(tbVidZivotno.Text, tbRasaZivotno.Text, tbImeZivotno.Text, Convert.ToInt32(tbStarostZivotno.Text), pol, tbMikroCip.Text, novSopstvenik);
                
                novSopstvenik.addMilenik(novMilenik);

                //Приказ на информации за секој денеска ново додаден пациент во табела
                DataGridViewRow row = (DataGridViewRow)dgvInfoTabela.Rows[0].Clone();
                row.Cells[0].Value = novSopstvenik.ImeSopstvenik;
                row.Cells[1].Value = novSopstvenik.PrezimeSopsrvnik;
                row.Cells[2].Value = novSopstvenik.BrojZaKontaktSopstvenik;
                row.Cells[3].Value = novMilenik.TipZivotno;
                row.Cells[4].Value = novMilenik.RasaZivotno;
                row.Cells[5].Value = novMilenik.ImeZivotno;
                row.Cells[6].Value = novMilenik.GodiniZivotno;
                row.Cells[7].Value = novMilenik.PolZivotno;
                row.Cells[8].Value = novMilenik.MikroCip;
                dgvInfoTabela.Rows.Add(row);
            }

        }

        
        //Валидација на сите полиња за додавање на нов пациент
        private void tbImeSopstvenik_Validating(object sender, CancelEventArgs e)
        {
            ValidateIme();
        }

        private void tbPrezimeSopstvenik_Validating(object sender, CancelEventArgs e)
        {
            ValidatePrezime();
        }


        private void tbEmailSopstvenik_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail();
        }

        private void mtbKontakt_Validating(object sender, CancelEventArgs e)
        {
            ValidateKontakt();
        }

        private void tbVidZivotno_Validating(object sender, CancelEventArgs e)
        {
            ValidateVidZivotno();
        }

        private void tbRasaZivotno_Validating(object sender, CancelEventArgs e)
        {
            ValidateRasaZivotno();
        }

        private void tbStarostZivotno_Validating(object sender, CancelEventArgs e)
        {
            ValidateStarostZivotno();
        }

        private void tbImeZivotno_Validating(object sender, CancelEventArgs e)
        {
            ValidateImeZivotno();
        }

        private void gbPol_Validating(object sender, CancelEventArgs e)
        {
            ValidatePol();
        }

        private void tbMikroCip_Validating(object sender, CancelEventArgs e)
        {
            ValidateMikrocip();
        }


        //Валидација методи
        private bool ValidateImeZivotno()
        {
            if (tbImeZivotno.Text.Trim().Length == 0)
            {
                error_ime_zivotno.SetError(tbImeZivotno, "Полето е задолжително!");
                return false;
            }
            else
            {
                error_ime_zivotno.SetError(tbImeZivotno, null);
                return true;
            }
        }

        private bool ValidateMikrocip()
        {
            if (tbMikroCip.Text.Trim().Length == 0)
            {
                error_mikrocip.SetError(tbMikroCip, "Полето е задолжително!");
                return false;
            }
            else
            {
                error_mikrocip.SetError(tbMikroCip, null);
                return true;
            }
        }

        private bool ValidatePol()
        {
            if (!rbMaskiPol.Checked && !rbZenskiPol.Checked)
            {
                error_pol.SetError(gbPol, "Полето е задолжително!");
                return false;
            }
            else
            {
                error_pol.SetError(gbPol, null);
                return true;
            }
        }

        private bool ValidateStarostZivotno()
        {
            if (tbStarostZivotno.Text.Trim().Length == 0)
            {
                error_godini.SetError(tbStarostZivotno, "Полето е задолжително!");
                return false;
            }
            else if (!int.TryParse(tbStarostZivotno.Text, out int godini)){
                error_godini.SetError(tbStarostZivotno, "Невалидна вредност!");
                return false;
            }
            else
            {
                error_godini.SetError(tbStarostZivotno, null);
                return true;
            }
        }

        private bool ValidateRasaZivotno()
        {
            if (tbRasaZivotno.Text.Trim().Length == 0)
            {
                error_rasa.SetError(tbRasaZivotno, "Полето е задолжително!");
                return false;
            }
            else
            {
                error_rasa.SetError(tbRasaZivotno, null);
                return true;
            }
        }

        private bool ValidateVidZivotno()
        {
            if (tbVidZivotno.Text.Trim().Length == 0)
            {
                error_vid.SetError(tbVidZivotno, "Полето е задолжително!");
                return false;
            }
            else
            {
                error_vid.SetError(tbVidZivotno, null);
                return true;
            }
        }

        private bool ValidateEmail()
        {
            if (tbEmailSopstvenik.Text.Trim().Length == 0)
            {
                error_email.SetError(tbEmailSopstvenik, "Полето е задолжително!");
                return false;
            }
            else
            {
                error_email.SetError(tbEmailSopstvenik, null);
                return true;
            }
        }

        private bool ValidateKontakt()
        {
            if (mtbKontakt.Text.Length != 13)
            {
                error_broj.SetError(mtbKontakt, "Полето е задолжително!");
                return false;
            }
            else { 
                error_broj.SetError(mtbKontakt, null);
                return true;
            }
        }

        private bool ValidatePrezime()
        {
            if (tbPrezimeSopstvenik.Text.Trim().Length == 0)
            {
                error_prezime.SetError(tbPrezimeSopstvenik, "Полето е задолжително!");
                return false;
            }
            else
            {
                error_prezime.SetError(tbPrezimeSopstvenik, null);
                return true;
            }
        }

        private bool ValidateIme()
        {
            if (tbImeSopstvenik.Text.Trim().Length == 0)
            {
                error_ime.SetError(tbImeSopstvenik, "Полето е задолжително!");
                return false;
            }
            else
            {
                error_ime.SetError(tbImeSopstvenik, null);
                return true;
            }
        }

        //За да стартува формата во Fullscreen-mode
        //Не ги покажува копчињата за да се минимизира,максимизира или исклуче
        //Праве проблеми формата е над сите други па ако отвориме друга форма неможеме да имаме интеракција со истата
        /*private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            // Ако го смениме редоследот на следните два реда тогаш taskbar-от нема да се покажува
            this.WindowState = FormWindowState.Maximized;
            //Без последната линија ги покажува и копчињата за минимизирање,максимизирање,исклучување
            //this.FormBorderStyle = FormBorderStyle.None;
        }*/

        /*
         До тука генералнон дизајнот е направен,
        Треба да се додаде на почетниот таб "Дома" календар или потсетник(последно ќе го додадиме тоа)
        Формите и полињата се именувани, сега зависат од базата на податоци(database)
        Треба да се имплементира податочна база
        Траба да се додадат имињата на вакцините и ампулите,
        За имињата на вакцините и ампулите мислам дека најдобро во класата Миленик да ги доадиме како bool променливи и така да ги зачуваме во базата,
            зошто во табот каде што се внесуваат треба а ги вчитаме информациите за миленикот и за секој посебно да чуваме дали е вакциниран, 
            па на секое ново отварање информации за одреден миленик да проверуваме ако bool вредноста е труе во check-box-от да ги штиклираме имињата на вакцините што се примени
            и датумите да ги чуваме посебно за секоја вакцина/ампула кога е внесена исто да се додава динамично за секој миленик на повик на неговите информации

        ####Дизајнот ми е правен на монитор со поголема резулуција забележав дека на помал екран кога оде во full-screen мод различно ги проширува компонентите, може лошто да ти изгледа на твојот монитор###
         ###Најверојатно ќе го сменам начинот на кој се рашируват компонентите за да може да се прилагодат димензиите на секој монитор###

        Податоците во медицинското досие најдобро како string Променливи да ги чуваме пр. string anamneza, string dijagnostickimetodi, string terapija стринг може да биде од големина 2GB па доволно е за пациент еден стринг текст за секоја дијагноза
        Треба да се додаде фунција на копчињата за пребарување и да се синхронизират податоците што ќе се читат од базата за во медицинското досие

        Додаив нова класа и форма за додавање на нов термин за на почетниот таб, уште не е функционален, треба некако со база да го врзиме и да проверуваме во базата за секој ден(од кога же помине терминот да го бришиме од базата)
         */
    }
}
