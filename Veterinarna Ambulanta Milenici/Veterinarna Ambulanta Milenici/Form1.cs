﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Veterinarna_Ambulanta_Milenici
{
    public partial class Form1 : Form
    {

        static readonly string SELECTALL = "SELECT * FROM Pacienti";

        public Form1()
        {
            InitializeComponent();
            displayData(SELECTALL);
        }

        private void displayData(string selectQuery)
        {
            //прочитај ги информациите од датабазата во data view grid
            DataTable dtPatients = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtPatients.Load(reader);
                    connection.Close();
                }
            }

            dgvInfoTabela.AutoGenerateColumns = true;
            dgvInfoTabela.DataSource = dtPatients;
            setColumnNames();
            //dgvInfoTabela.Sort(dgvInfoTabela.Columns[0], ListSortDirection.Ascending);

        }

        private void setColumnNames()
        {
            dgvInfoTabela.Columns[0].Visible = false;
            dgvInfoTabela.Columns[1].HeaderText = "Име Сопственик";
            dgvInfoTabela.Columns[2].HeaderText = "Презиме Сопственик";
            dgvInfoTabela.Columns[3].HeaderText = "Број за контакт";
            dgvInfoTabela.Columns[4].HeaderText = "Емаил";
            dgvInfoTabela.Columns[5].HeaderText = "Вид на животно";
            dgvInfoTabela.Columns[6].HeaderText = "Раса на животно";
            dgvInfoTabela.Columns[7].HeaderText = "Име на животно";
            dgvInfoTabela.Columns[8].HeaderText = "Старост на животно";
            dgvInfoTabela.Columns[9].HeaderText = "Пол на животно";
            dgvInfoTabela.Columns[10].HeaderText = "Број на микрочип";
            dgvInfoTabela.Columns[11].HeaderText = "Датум на креирање";
        }

        private void btnDodadi_Click(object sender, EventArgs e)
        {
            //Повторна валидација доколку се кликне Додади Пациент без прво да се посетат задолжителните полињa
            if (ValidateIme() && ValidatePrezime() && ValidateKontakt() && ValidateEmail() && ValidateVidZivotno() && ValidateRasaZivotno()
                && ValidateStarostZivotno() &&  ValidateImeZivotno() && ValidatePol() && ValidateMikrocip())
            {
                string pol = gbPol.Controls.OfType<RadioButton>().First(rb => rb.Checked).Text.ToString() ;

                Sopstvenik novSopstvenik = new Sopstvenik(tbImeSopstvenik.Text, tbPrezimeSopstvenik.Text, tbEmailSopstvenik.Text, mtbKontakt.Text);
                Milenik novMilenik = new Milenik(tbVidZivotno.Text, tbRasaZivotno.Text, tbImeZivotno.Text, Convert.ToInt32(tbStarostZivotno.Text), pol, tbMikroCip.Text, novSopstvenik);
                
                novSopstvenik.addMilenik(novMilenik);

                addToDatabase(pol);
                displayData(SELECTALL);
            }
        }

        private void addToDatabase(string pol)
        {
            //Отворање на конекција со датабазата co string за конекција од помошната класа DBHelper
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DBHelper.ConnVal();
            connection.Open();

            //sql query за додавање во табела
            string sql = "INSERT INTO Pacienti" +
                "(ImeSopstvenik,PrezimeSopstvenik,Email,Kontakt,VidZivotno,RasaZivotno,ImeZivotno,StarostZivotno,Pol,Mikrocip) " +
                "VALUES(@imeSopstvenik,@prezimeSopstvenik,@email,@kontakt,@vidZivotno,@rasaZivotno,@imeZivotno,@starostZivotno,@pol,@mikrocip)";

            //додавање вредности во командата (од sql query и конекцијата) која се извршува за додавање на нов ред во табелата
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@imeSopstvenik", tbImeSopstvenik.Text);
                cmd.Parameters.AddWithValue("@prezimeSopstvenik", tbPrezimeSopstvenik.Text);
                cmd.Parameters.AddWithValue("@email", tbEmailSopstvenik.Text);
                cmd.Parameters.AddWithValue("@kontakt", mtbKontakt.Text);
                cmd.Parameters.AddWithValue("@vidZivotno", tbVidZivotno.Text);
                cmd.Parameters.AddWithValue("@rasaZivotno", tbRasaZivotno.Text);
                cmd.Parameters.AddWithValue("@imeZivotno", tbImeZivotno.Text);
                cmd.Parameters.AddWithValue("@starostZivotno", Convert.ToInt32(tbStarostZivotno.Text));
                cmd.Parameters.AddWithValue("@pol", pol);
                cmd.Parameters.AddWithValue("@mikrocip", tbMikroCip.Text);

                cmd.CommandType = CommandType.Text;

                //пробај да ја извршиш командата, доколку е не е успешно прикажи порака
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("Додавањето на нов пациент во датабазата е неуспешно! Пробајте повторно.");
            }
            //Затвори ја конекцијата
            connection.Close();
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
