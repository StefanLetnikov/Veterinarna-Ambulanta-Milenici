using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Veterinarna_Ambulanta_Milenici
{
    public partial class Form1 : Form
    {
        private int milenikId;

        public Form1()
        {
            InitializeComponent();
            btnVnesiDijagnoza.Enabled = false;
        }

        //Кога ќе се вчита формата прикажи ги сите термини во денешниот ден
        private void Form1_Load(object sender, EventArgs e)
        {
            displayAppointments(DBHelper.SELECTALLTERMINI);
        }

        //При промена на таб вчитај ги информациите од датабазата
        private void mainTabControll_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mainTabControll.SelectedIndex)
            {
                case 1:
                    displayDataMilenici(DBHelper.SELECTALLMILENICI); //Нов Миленик
                    ClearTextBoxesMilenici();
                    break;
                case 2:
                    displayDataSearch(DBHelper.SELECTALLMILENICI, 0); //ООЗ
                    if (cbPrebarajOOZ.SelectedIndex == -1)
                        disableButtonsOOZ();
                    break;
                case 3:
                    displayDataSearch(DBHelper.SELECTALLMILENICI, 1); //МД
                    if (cbPrebarajMD.SelectedIndex == -1)
                        btnVnesiDijagnoza.Enabled = false;
                    break;
            }
        }

     

        //Приказ на податоци co Пребарувај
        private void displayDataSearch(string selectQuery, int tab)
        {
            cbPrebarajOOZ.Items.Clear();
            cbPrebarajMD.Items.Clear();
            //прочитај ги информациите од датабазата во data view grid
            SqlDataAdapter sda;
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection())
            {

                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    //додади ги потребните колони во comboBox
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Text = string.Format("{0, -30} {1, -30} {2, -20} {3, -30} {4, -30} {5, -30}",
                                ds.Tables[0].Rows[i][1], //име сопственик
                                ds.Tables[0].Rows[i][2], //презиме сопственик
                                ds.Tables[0].Rows[i][4], //контакт
                                ds.Tables[0].Rows[i][5], //вид животно
                                ds.Tables[0].Rows[i][6], //раса животно
                                ds.Tables[0].Rows[i][7]); //име животно
                        item.Value = Convert.ToInt32(ds.Tables[0].Rows[i][0]); //id на животното во датабазата

                        if (tab == 0)
                        { //ОЗ
                            cbPrebarajOOZ.Items.Add(item);
                            cbPrebarajOOZ.Text = "Одберете миленик"; //default вредност за опис на combobox
                        }
                        else
                        { //МД
                            cbPrebarajMD.Items.Add(item);
                            cbPrebarajMD.Text = "Одберете миленик"; //default вредност за опис на combobox
                        }
                    }
                    connection.Close();
                }
            }
        }


        //**************************************ТЕРМИНИ*****************************************************
        private void btnVnesiTermin_Click(object sender, EventArgs e)
        {
            Termin newTermin = new Termin();
            DialogResult rezultat = newTermin.ShowDialog();
            if (rezultat == DialogResult.OK)
            {
                displayAppointments(DBHelper.SELECTALLTERMINI);
                MessageBox.Show("Терминот е успешно внесен!");
            }
        }

       
        private void displayAppointments(string selectQuery)
        {
            //прочитај ги информациите од датабазата во data view grid
            DataTable dtTermini = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtTermini.Load(reader);
                    connection.Close();
                }
            }
            //dgvTermini == dataViewGridTermini
            dgvTermini.AutoGenerateColumns = true;
            dgvTermini.DataSource = dtTermini;
            setColumnNamesTermini();
        }

        private void setColumnNamesTermini()
        {
            dgvTermini.Columns[0].Visible = false;
            dgvTermini.Columns[1].HeaderText = "Датум";
            dgvTermini.Columns[2].HeaderText = "Час";
            dgvTermini.Columns[3].HeaderText = "Име";
        }


        //*************************************НОВ МИЛЕНИК**************************************************

        //Приказ на податоци во Нов Миленик
        private void displayDataMilenici(string selectQuery)
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
            setColumnNamesMilenici();
            
        }

        //Смени ги имињата на колоните во Нов Миленик dataViewGrid
        private void setColumnNamesMilenici()
        {
            dgvInfoTabela.Columns[0].Visible = false;
            dgvInfoTabela.Columns[1].HeaderText = "Име Сопственик";
            dgvInfoTabela.Columns[2].HeaderText = "Презиме Сопственик";
            dgvInfoTabela.Columns[3].HeaderText = "Емаил";
            dgvInfoTabela.Columns[4].HeaderText = "Број за контакт";
            dgvInfoTabela.Columns[5].HeaderText = "Вид на животно";
            dgvInfoTabela.Columns[6].HeaderText = "Раса на животно";
            dgvInfoTabela.Columns[7].HeaderText = "Име на животно";
            dgvInfoTabela.Columns[8].HeaderText = "Старост на животно";
            dgvInfoTabela.Columns[9].HeaderText = "Пол на животно";
            dgvInfoTabela.Columns[10].HeaderText = "Број на микрочип";
            dgvInfoTabela.Columns[11].HeaderText = "Датум на креирање";
        }

        //Додади нов миленик во dataViewGrid
        private void btnDodadi_Click(object sender, EventArgs e)
        {
            //Повторна валидација доколку се кликне Додади Пациент без прво да се посетат задолжителните полињa
            if (ValidateIme() && ValidatePrezime() && ValidateKontakt() && ValidateEmail() && ValidateVidZivotno() &&
                ValidateRasaZivotno() && ValidateImeZivotno() && ValidatePol() && ValidateMikrocip())
            {
                string pol = gbPol.Controls.OfType<RadioButton>().First(rb => rb.Checked).Text.ToString();

                addNewAnimalToDatabase(pol);
                displayDataMilenici(DBHelper.SELECTALLMILENICI);

                ClearTextBoxesMilenici();
            }
        }

        //Додади нов миленик во датабаза
        private void addNewAnimalToDatabase(string pol)
        {
            //Отворање на конекција со датабазата co string за конекција од помошната класа DBHelper
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DBHelper.ConnVal();
            connection.Open();

            //sql query за додавање во табела
            string sql = DBHelper.INSERTMILENIK;

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
                cmd.Parameters.AddWithValue("@starostZivotno", nudStarostZivotno.Value);
                cmd.Parameters.AddWithValue("@pol", pol);
                cmd.Parameters.AddWithValue("@mikrocip", tbMikroCip.Text);
                cmd.Parameters.AddWithValue("@datum", DBHelper.getDate());

                cmd.CommandType = CommandType.Text;

                //пробај да ја извршиш командата, доколку е не е успешно прикажи порака
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("Додавањето на нов миленик во датабазата е неуспешно! Пробајте повторно.");
            }
            //Затвори ја конекцијата
            connection.Close();
        }

        //Постави default вредности на textBoxes после додавање на нов миленик и на отварање на табот
        private void ClearTextBoxesMilenici()
        {
            tbImeSopstvenik.Text = "\\";
            tbPrezimeSopstvenik.Text = "\\";
            tbEmailSopstvenik.Text = "\\";
            //за контакт?
            tbVidZivotno.Text = "\\";
            tbRasaZivotno.Text = "\\";
            tbImeZivotno.Text = "\\";
            tbMikroCip.Text = "\\";
            rbMaskiPol.Checked = false;
            rbZenskiPol.Checked = false;
        }






        //****************************************ООЗ********************************************************


        //Приказ на податоци во ООЗ одбран миленик
        private void displayDataAnimalOOZ(string selectQuery)
        {
            //прочитај ги информациите од датабазата во data view grid
            SqlDataAdapter sda;
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection())
            {

                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    int s = ds.Tables[0].Rows.Count;
                    //додади ги потребните колони во comboBox
                    lbImeOZZ.Text = ds.Tables[0].Rows[0][7].ToString(); //име животно
                    lbVidZivotnoOZZ.Text = ds.Tables[0].Rows[0][5].ToString(); //вид животно
                    lbRasaOZZ.Text = ds.Tables[0].Rows[0][6].ToString(); //раса животнo
                    lbStarostOZZ.Text = ds.Tables[0].Rows[0][8].ToString(); //име животно
                    lbPolOZZ.Text = ds.Tables[0].Rows[0][9].ToString(); //пол
                    lbMikroCipOZZ.Text = ds.Tables[0].Rows[0][10].ToString(); //микрочип
                    lbSopstvenikOZZ.Text = ds.Tables[0].Rows[0][1].ToString() + " " + ds.Tables[0].Rows[0][2].ToString(); //сопственик

                    milenikId = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    
                }
                connection.Close();
            }
            displayVakcini();
            displayUslugi();
            displayTableti();
        }


        //При внес на текст во ООЗ Пребарај textBox да се прикажат соодветните миленици
        private void tbPrebaraj_TextChanged(object sender, EventArgs e)
        {
            string KEYWORD = tbPrebarajOOZ.Text;
            //селектирај ги сите редови каде некои колони личат на влезот од „пребарај“
            string query = "SELECT * FROM Milenici WHERE imeSopstvenik LIKE '%" + KEYWORD + "%' OR prezimeSopstvenik LIKE '%" + KEYWORD + "%' OR kontakt LIKE '%" + KEYWORD + "%' OR vidZivotno LIKE '%" + KEYWORD + "%' OR rasaZivotno LIKE '%" + KEYWORD + "%' OR imeZivotno LIKE '%" + KEYWORD + "%'";

            cbPrebarajOOZ.Items.Clear();
            displayDataSearchOOZ(query);
        }

        private void displayDataSearchOOZ(string query)
        {
            //при секое ново пребарување бриши ги старите информации во comboBox
            cbPrebarajOOZ.Items.Clear();
            if (tbPrebarajOOZ.Text.Trim().Length == 0)
            {
                cbPrebarajOOZ.Items.Clear();
                cbPrebarajOOZ.Text = "Одберете миленик";
            }

            displayDataSearch(query, 0); //0 за ООЗ
        }

        //При селектирање на миленик во ООЗ од comboBox да се прикажат соодветните информации за тој миленик
        private void cbPrebaraj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPrebarajOOZ.SelectedIndex != -1)
            {
                ComboBoxItem selectedItem = cbPrebarajOOZ.SelectedItem as ComboBoxItem;
                int id = (int)selectedItem.Value;
                string query = DBHelper.SELECTTOP1 + id.ToString();
                displayDataAnimalOOZ(query);

                btnVnesiVakciniOZZ.Enabled = true;
                btnVnesiUsluga.Enabled = true;
                btnVnesiTableti.Enabled = true;
            }
            else
            {
                cbPrebarajOOZ.Text = "Одберете миленик";
                ClearLabelsOOZ();
                disableButtonsOOZ();

            }
        }

        private void ClearLabelsOOZ()
        {
            lbImeOZZ.Text = "";
            lbVidZivotnoOZZ.Text = "";
            lbRasaOZZ.Text = "";
            lbStarostOZZ.Text = "";
            lbPolOZZ.Text = "";
            lbMikroCipOZZ.Text = "";
            lbSopstvenikOZZ.Text = "";
        }

        private void llClearOOZ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvVakcini.DataSource = null;
            dgvVakcini.Rows.Clear();
            dgvUslugi.DataSource = null;
            dgvUslugi.Rows.Clear();
            dgvTableti.DataSource = null;
            dgvTableti.Rows.Clear();

            cbPrebarajOOZ.Items.Clear();
            displayDataSearchOOZ(DBHelper.SELECTALLMILENICI);
            cbPrebarajOOZ.Text = "Одберете миленик";
            btnVnesiVakciniOZZ.Enabled = false;
            btnVnesiUsluga.Enabled = false;
            btnVnesiTableti.Enabled = false;
            ClearLabelsOOZ();
        }

        private void disableButtonsOOZ()
        {
            btnVnesiVakciniOZZ.Enabled = false;
            btnVnesiUsluga.Enabled = false;
            btnVnesiTableti.Enabled = false;
        }


        //----------------------------------------------ВАКЦИНИ---------------------------------------------
        //Приказ на вакцини за одбраниот миленик
        private void displayVakcini()
        {
            //прочитај ги информациите од датабазата во data view grid
            DataTable dtVakcini = new DataTable();

            string selectQuery = DBHelper.SELECTALLVAKCINI + milenikId;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtVakcini.Load(reader);
                    connection.Close();
                }
            }

            dgvVakcini.AutoGenerateColumns = true;
            dgvVakcini.DataSource = dtVakcini;
            setColumnNamesVakcini();
        }

        private void setColumnNamesVakcini()
        {
            dgvVakcini.Columns[0].Visible = false;
            dgvVakcini.Columns[1].HeaderText = "Датум";
            dgvVakcini.Columns[2].HeaderText = "Вакцина";
            dgvVakcini.Columns[3].Visible = false;

            dgvVakcini.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvVakcini.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void addVakcinaToDatabase()
        {
            if (cbVakcini.SelectedIndex == -1)
            {
                MessageBox.Show("Одберете вид на вакцина!", "", MessageBoxButtons.OK);
            }
            else
            {
                //Отворање на конекција со датабазата co string за конекција од помошната класа DBHelper
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = DBHelper.ConnVal();
                connection.Open();

                //sql query за додавање во табела
                string sql = DBHelper.INSERTVAKCINA;

                //додавање вредности во командата (од sql query и конекцијата) која се извршува за додавање на нов ред во табелата
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@datum", DBHelper.getDate());
                    cmd.Parameters.AddWithValue("@vakcina", cbVakcini.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@milenikId", milenikId);

                    cmd.CommandType = CommandType.Text;

                    //пробај да ја извршиш командата, доколку е не е успешно прикажи порака
                    if (cmd.ExecuteNonQuery() == 0)
                        MessageBox.Show("Додавањето на нов миленик во датабазата е неуспешно! Пробајте повторно.");
                }
                //Затвори ја конекцијата
                connection.Close();
            }
        }


        private void btnVnesiVakciniOZZ_Click(object sender, EventArgs e)
        {
            if (cbVakcini.SelectedIndex == -1)
                MessageBox.Show("Одберете Вакцина");
            else
            {
                addVakcinaToDatabase();
                displayVakcini();
            }
        }




        //----------------------------------------------УСЛУГИ---------------------------------------------
        //Приказ на аманмеза за одбраниот миленик
        private void displayUslugi()
        {
            //прочитај ги информациите од датабазата во data view grid
            DataTable dtUslugi = new DataTable();

            string selectQuery = DBHelper.SELECTALLUSLUGI + milenikId;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtUslugi.Load(reader);
                    connection.Close();
                }
            }

            dgvUslugi.AutoGenerateColumns = true;
            dgvUslugi.DataSource = dtUslugi;
            setColumnNamesUslugi();
        }

        private void setColumnNamesUslugi()
        {
            dgvUslugi.Columns[0].Visible = false;
            dgvUslugi.Columns[1].HeaderText = "Датум";
            dgvUslugi.Columns[2].HeaderText = "Услуга";
            dgvUslugi.Columns[3].Visible = false;

            dgvUslugi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUslugi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void addUslugaToDatabase()
        {
            if (cbUslugi.SelectedIndex == -1)
            {
                MessageBox.Show("Одберете вид на услуга!", "", MessageBoxButtons.OK);
            }
            else
            {
                //Отворање на конекција со датабазата co string за конекција од помошната класа DBHelper
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = DBHelper.ConnVal();
                connection.Open();

                //sql query за додавање во табела
                string sql = DBHelper.INSERTUSLUGA;

                //додавање вредности во командата (од sql query и конекцијата) која се извршува за додавање на нов ред во табелата
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@datum", DBHelper.getDate());
                    cmd.Parameters.AddWithValue("@usluga", cbUslugi.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@milenikId", milenikId);

                    cmd.CommandType = CommandType.Text;

                    //пробај да ја извршиш командата, доколку е не е успешно прикажи порака
                    if (cmd.ExecuteNonQuery() == 0)
                        MessageBox.Show("Додавањето на нов миленик во датабазата е неуспешно! Пробајте повторно.");
                }
                //Затвори ја конекцијата
                connection.Close();
            }
        }

        private void btnVnesiUsluga_Click(object sender, EventArgs e)
        {
            if (cbVakcini.SelectedIndex == -1)
                MessageBox.Show("Одберете Услуга");
            else
            {
                addUslugaToDatabase();
                displayUslugi();
            }
        }


        //----------------------------------------------ТАБЛЕТИ---------------------------------------------
        //Приказ на аманмеза за одбраниот миленик
        private void displayTableti()
        {
            //прочитај ги информациите од датабазата во data view grid
            DataTable dtTableti = new DataTable();

            string selectQuery = DBHelper.SELECTALLTABLETI + milenikId;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtTableti.Load(reader);
                    connection.Close();
                }
            }

            dgvTableti.AutoGenerateColumns = true;
            dgvTableti.DataSource = dtTableti;
            setColumnNamesTableti();
        }

        private void setColumnNamesTableti()
        {
            dgvTableti.Columns[0].Visible = false;
            dgvTableti.Columns[1].HeaderText = "Датум";
            dgvTableti.Columns[2].HeaderText = "Таблета";
            dgvTableti.Columns[3].Visible = false;

            dgvTableti.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTableti.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void addTabletaToDatabase()
        {
            if (tbTabletiVnatresni.Text.Trim().Length == 0)
            {
                MessageBox.Show("Внесете таблета!", "", MessageBoxButtons.OK);
            }
            else
            {
                //Отворање на конекција со датабазата co string за конекција од помошната класа DBHelper
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = DBHelper.ConnVal();
                connection.Open();

                //sql query за додавање во табела
                string sql = DBHelper.INSERTABLETA;

                //додавање вредности во командата (од sql query и конекцијата) која се извршува за додавање на нов ред во табелата
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@datum", DBHelper.getDate());
                    cmd.Parameters.AddWithValue("@tableta", tbTabletiVnatresni.Text);
                    cmd.Parameters.AddWithValue("@milenikId", milenikId);

                    cmd.CommandType = CommandType.Text;

                    //пробај да ја извршиш командата, доколку е не е успешно прикажи порака
                    if (cmd.ExecuteNonQuery() == 0)
                        MessageBox.Show("Додавањето на нов миленик во датабазата е неуспешно! Пробајте повторно.");
                }
                //Затвори ја конекцијата
                connection.Close();
            }
        }

        private void btnVnesiTableti_Click(object sender, EventArgs e)
        {
            if (cbVakcini.SelectedIndex == -1)
                MessageBox.Show("Внесете Таблета");
            else
            {
                addTabletaToDatabase();
                displayTableti();
            }
        }





        //****************************************МД********************************************************
        //Приказ на податоци во МД одбран миленик
        private void displayDataAnimalMD(string selectQuery)
        {
            //прочитај ги информациите од датабазата во data view grid
            SqlDataAdapter sda;
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    int s = ds.Tables[0].Rows.Count;
                    //додади ги потребните колони во comboBox
                    lbImeMD.Text = ds.Tables[0].Rows[0][7].ToString(); //име животно
                    lbVidZivotnoMD.Text = ds.Tables[0].Rows[0][5].ToString(); //вид животно
                    lbRasaZivotnoMD.Text = ds.Tables[0].Rows[0][6].ToString(); //раса животнo
                    lbStarostMD.Text = ds.Tables[0].Rows[0][8].ToString(); //име животно
                    lbPolMD.Text = ds.Tables[0].Rows[0][9].ToString(); //пол
                    lbMikrocipMD.Text = ds.Tables[0].Rows[0][10].ToString(); //микрочип
                    lbSopstvenikMD.Text = ds.Tables[0].Rows[0][1].ToString() + " " + ds.Tables[0].Rows[0][2].ToString(); //сопственик

                    milenikId = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    //displayDataDosie();
                    //displayDataDijagnostickiMetodi();
                    //displayDataTerapija();

                }
                connection.Close();
            }
        }

        //При внес на текст во МД Пребарај textBox да се прикажат соодветните миленици
        private void tbPrebarajMD_TextChanged(object sender, EventArgs e)
        {
            //селектирај ги сите редови каде некои колони личат на влезот од „пребарај“
            string KEYWORD = tbPrebarajMD.Text;
            string query = "SELECT * FROM Milenici WHERE imeSopstvenik LIKE '%" + KEYWORD + "%' OR prezimeSopstvenik LIKE '%" + KEYWORD + "%' OR kontakt LIKE '%" + KEYWORD + "%' OR vidZivotno LIKE '%" + KEYWORD + "%' OR rasaZivotno LIKE '%" + KEYWORD + "%' OR imeZivotno LIKE '%" + KEYWORD + "%'";

            cbPrebarajMD.Items.Clear();
            displayDataSearchMD(query);
        }

        private void displayDataSearchMD(string query)
        {
            //при секое ново пребарување бриши ги старите информации во comboBox
            cbPrebarajMD.Items.Clear();
            if (tbPrebarajMD.Text.Trim().Length == 0)
            {
                cbPrebarajMD.Items.Clear();
                cbPrebarajMD.Text = "Одберете миленик";
            }
            displayDataSearch(query, 1); //1 за МД
        }


        //При селектирање на миленик во МД од comboBox да се прикажат соодветните информации за тој миленик
        private void cbPrebarajMD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPrebarajMD.SelectedIndex != -1)
            {
                ComboBoxItem selectedItem = cbPrebarajMD.SelectedItem as ComboBoxItem;
                int id = (int)selectedItem.Value;
                string query = DBHelper.SELECTTOP1 + id.ToString();
                
                displayDataAnimalMD(query);
                displayDataAnamneza(); 
                displayDataDijagnostickiMetodi(); 
                displayDataTerapija();
                
                btnVnesiDijagnoza.Enabled = true;
            }
            else
            {
                cbPrebarajMD.Text = "Одберете миленик";
                ClearLabelsMD();
                btnVnesiDijagnoza.Enabled = false;
            }
        }

        private void ClearLabelsMD()
        {
            lbImeMD.Text = "";
            lbVidZivotnoMD.Text = "";
            lbRasaZivotnoMD.Text = "";
            lbStarostMD.Text = "";
            lbPolMD.Text = "";
            lbMikrocipMD.Text = "";
            lbSopstvenikMD.Text = "";
        }

        private void llbClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvAnamneza.DataSource = null;
            dgvAnamneza.Rows.Clear();
            dgvDijagnostickiMetodi.DataSource = null;
            dgvDijagnostickiMetodi.Rows.Clear();
            dgvTerapija.DataSource = null;
            dgvTerapija.Rows.Clear();

            rtbAnamneza.Clear();
            rtbDijagnostickiMetodi.Clear();
            rtbTerapija.Clear();

            cbPrebarajMD.Items.Clear();
            cbPrebarajMD.Text = "Одберете миленик";
            displayDataSearchMD(DBHelper.SELECTALLMILENICI);
            btnVnesiDijagnoza.Enabled = false;
            ClearLabelsMD();
        }

        //Внес на нова дијагноза
        private void btnVnesiDijagnoza_Click(object sender, EventArgs e)
        {
            switch (cbDijagnoza.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Одберете вид на дијагноза!", "", MessageBoxButtons.OK);
                    break;
                case 0:
                    addNewDiagnoseToDatabase(DBHelper.INSERTANAMNEZA, "anamneza"); //внеси нова анамнеза во датабазата
                    displayDataAnamneza(); //рефреширај dataGridView
                    break;
                case 1:
                    addNewDiagnoseToDatabase(DBHelper.INSERTDIJAGNOSTICKIMETODI, "dijagnostickiMetodi"); //внеси нова дијагностичка метода во датабазата
                    displayDataDijagnostickiMetodi(); //рефреширај dataGridView
                    break;
                case 2:
                    addNewDiagnoseToDatabase(DBHelper.INSERTTERAPIJA, "terapija"); //внеси нова терапија во датабазата
                    displayDataTerapija(); //рефреширај dataGridView
                    break;
            }
        }

        private void addNewDiagnoseToDatabase(string queryString, string diagnose)
        {
            if (rtbDijagnoza.Text.Trim().Length != 0)
            {
                //Отворање на конекција со датабазата co string за конекција од помошната класа DBHelper
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = DBHelper.ConnVal();
                connection.Open();

                //sql query за додавање во табела
                string sql = queryString;

                //додавање вредности во командата (од sql query и конекцијата) која се извршува за додавање на нов ред во табелата
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@milenikId", milenikId);
                    cmd.Parameters.AddWithValue("@"+ diagnose, rtbDijagnoza.Text);
                    cmd.Parameters.AddWithValue("@datum", DBHelper.getDate());

                    cmd.CommandType = CommandType.Text;

                    //пробај да ја извршиш командата, доколку е не е успешно прикажи порака
                    if (cmd.ExecuteNonQuery() == 0)
                        MessageBox.Show("Додавањето е неуспешно! Пробајте повторно.");
                }
                //Затвори ја конекцијата
                connection.Close();
            }
        }




        //-------------------------------------АНАМНЕЗА-------------------------------------------------------

        //Приказ на аманмеза за одбраниот миленик
        private void displayDataAnamneza()
        {
            //прочитај ги информациите од датабазата во data view grid
            DataTable dtAnamneza = new DataTable();

            string selectQuery = DBHelper.SELECTALLANAMNEZA + milenikId;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtAnamneza.Load(reader);
                    connection.Close();
                }
            }

            dgvAnamneza.AutoGenerateColumns = true;
            dgvAnamneza.DataSource = dtAnamneza;
            setColumnNamesAnamneza();
        }

        private void setColumnNamesAnamneza()
        {
            dgvAnamneza.Columns[0].Visible = false;
            dgvAnamneza.Columns[1].Visible = false;
            dgvAnamneza.Columns[2].HeaderText = "Анамнеза";
            dgvAnamneza.Columns[3].HeaderText = "Датум";
        }

        //Доколку се одбере некоја анамнеза од dataGridView да се прикаже целиот текст во richBoxText за анамнеза
        private void dgvAnamneza_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                    rtbAnamneza.Text = row.Cells[2].Value.ToString();
            }
        }








        //-------------------------------------ДИЈАГНОСТИЧКИ МЕТОДИ-------------------------------------

        //Приказ на досиеја за одбраниот миленик
        private void displayDataDijagnostickiMetodi()
        {
            //прочитај ги информациите од датабазата во data view grid
            DataTable dtDijagnostickiMetodi = new DataTable();

            string selectQuery = DBHelper.SELECTALLDIJAGNOSTICKIMETODI + milenikId;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtDijagnostickiMetodi.Load(reader);
                    connection.Close();
                }
            }

            dgvDijagnostickiMetodi.AutoGenerateColumns = true;
            dgvDijagnostickiMetodi.DataSource = dtDijagnostickiMetodi;
            setColumnNamesDijagnostickiMetodi();
        }
        private void setColumnNamesDijagnostickiMetodi()
        {
            dgvDijagnostickiMetodi.Columns[0].Visible = false;
            dgvDijagnostickiMetodi.Columns[1].Visible = false;
            dgvDijagnostickiMetodi.Columns[2].HeaderText = "Дијагностички методи";
            dgvDijagnostickiMetodi.Columns[3].HeaderText = "Датум";
        }

        private void dgvDijagnostickiMetodi_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                    rtbDijagnostickiMetodi.Text = row.Cells[2].Value.ToString();
            }
        }

        






        //-------------------------------------ТЕРАПИЈА-------------------------------------

        private void displayDataTerapija()
        {
            //прочитај ги информациите од датабазата во data view grid
            DataTable dtTerapija = new DataTable();

            string selectQuery = DBHelper.SELECTALLTERAPIJA + milenikId;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DBHelper.ConnVal();
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtTerapija.Load(reader);
                    connection.Close();
                }
            }

            dgvTerapija.AutoGenerateColumns = true;
            dgvTerapija.DataSource = dtTerapija;
            setColumnNamesTerapija();
        }

        private void setColumnNamesTerapija()
        {
            dgvTerapija.Columns[0].Visible = false;
            dgvTerapija.Columns[1].Visible = false;
            dgvTerapija.Columns[2].HeaderText = "Терапија";
            dgvTerapija.Columns[3].HeaderText = "Датум";
        }

        private void dgvTerapija_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                    rtbTerapija.Text = row.Cells[2].Value.ToString();
            }
        }







        //**********************************Валидација на сите полиња за додавање на нов пациент*********************************

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
            else
            {
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
