# Veterinarna-Ambulanta-Milenici

#1.Опис на апликацијата:

Апликацијата што ја развивме е апликација која решава практичен проблем во секојдневието на една ново отворена ветеринарна клиника. Проблемите со кои се справува нашата апликација се од типот на внесување на нови пациенти во системот, внесување на дијагнози  и терапии за истите, и потоа нивно разгледување како и закажување на термини за прегледи и нивно ажурирање.

#2.Упатство за користење на апликацијата:

  #2.1. Термини:
	
  Oвој прозорец (таб) е првото нешто што се појавува кога ќе се стартува апликацијата, и во него има форма во која се прикажуваат закажаните термини, и нивни информации за           прегледите кои се за денешниот ден.
  ![screenshoot1](https://imgur.com/a/VY4ZQX2)    ![screenshot2](https://imgur.com/a/sX19HIv)
  
  #2.2. Внеси Миленик:
  
  Во овој прозорец (таб) се поставени фоми за внесување на информации за нов миленик (пациент), информациите за неговиот сопственик, како и табела за лесен преглед на сите 				миленици во системот.
  ![screenshoot3](https://imgur.com/a/BlVSKFt)
    
   #2.3. Основна Здраствена Заштита:
   
   Овде имаме поле каде се пребарува некој миленик според некој од внесените параметри за истиот (пр. име, раса, вид на животно, број на чип, или според сопственик), а во случај да има повеќе пациенти со исто име и иста раса на пр. имаме листа во која корисникот може подетално да виде и да одбере за кој миленик точно ќе се прикажуваат информациите и истите би ги ажурирал. Потоа под неа стое форма за детални информации за пациентот како и полиња за внес на нови услуги кои се извршени за тој одреден пациент. Во полињата именувани "Вакцинација", "Надворешни" и "Внатрешни" се внесуаваат нови информации за миленикот од типот на кои вакцини ги има примено, какви надворешни ссредства и ампули се препишани за него или какви лекови се користат.
   ![screenshoot4]()
   
   #2.4. Медицинско Досие:
   
   Пвој прозорец е сличен на предходниот , во тоа што ги наследува првите две форми за прабарување и селектирање на пациент од внесените, а поднив стои форма за селектирање на тип на текстуална диагноза што ќе се зачува за пациентот , место за запишување на истата и простор за одбирање на веќе постоечки предходни дијагнози за лесен преглед на истите.
   ![scrennshoot5]()    ![screenshoot6]()
   
#3. Претставување на проблемот:

  #3.1 Податочни структури:
  
  Основната и главна класа е Form1.cs во која е сместен најголемиот дел од кодот, бидејќи користевме tab-view форма за корисничиот интерфејс, а покрај неа имаме одделни класи за информациите пациентите (милениците) Milenik.cs, и за секој сопственик, како и листа на миленици за секој сопственик (во случај еден сопственик да има повеќе од еден миленик),    Sopstvenik.cs. Потоа за да не биде се сместео во еден мал прозорец направивме дополнителна форма за внесување на нови термини за прегледи во системот, која се прикажува како нов прозорец Termin.cs и неговата класа за зачувување на податоците NovTermin.cs. На крај имаме уште една класа под името DBHelper.cs која ни е помошна класа, и во неа имаме врска на апликацијата со базата на податоци изработена во MSSQL Server.
  
 #3.2. Опис на фунцкија која работи со податоците од базата на податоци.
  Бидјќи работеме со база на податоци од типот на SQL потребно е да поставеме врска до серверот и исто така треба да извршуваме наредби од SSQL јазикот
  Па ќе го разгледаме делот во кој се поврзува и се чита од податочната база, а потоа е потполнуваат информациите за истите во data-grid-view форма.
   '''
   
   *************************************НОВ МИЛЕНИК**************************************************

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

                Sopstvenik novSopstvenik = new Sopstvenik(tbImeSopstvenik.Text, tbPrezimeSopstvenik.Text, tbEmailSopstvenik.Text, mtbKontakt.Text);
                Milenik novMilenik = new Milenik(tbVidZivotno.Text, tbRasaZivotno.Text, tbImeZivotno.Text, Convert.ToInt32(nudStarostZivotno.Text), pol, tbMikroCip.Text, novSopstvenik);

                novSopstvenik.addMilenik(novMilenik);

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
   '''
   На почетокот правеме конекција со базата, и ги вчитуваме зчуваните елементи од неа. Потоа креираме инстанца од datagridview  објектот и ги потполнуваме насловите на колоните со информациите кои сакаме да ги прикажуваме. Потоа правеме валидација за внесените информации во полињата за информации за миленикот и сопственикот за да не дозволеме null или празна вредност да се внеси во базата на податоци и потоа го дадоаваме нововнесениот миленик во системот со клик на копчето "Додади", па го прикажуваме во табелата десно од него. Потоа во фунцкијата *private void addNewAnimalToDatabase(string pol)* повторно отвараме конекција до базата и серверот, се поврзуваме со таблеата за Миленици, и ги запишуваме во истата новите податоци, ако е успешно внесен новиот миленик тој се прикажува во табелата десно, ако не се прикажува прозорец дека се случило грешка и за повторен обид за внес на информации. На крај ја затвараме конекцијата со серверот, и ги пребришуваме тексст полињата за да бидат спремни за нов внес на информации.
   
#4. Дизајн на апликацијата:

    GUI интерфејсот и дизајнот се направени да се совпаѓаат со дизајнот на и биоте на клиниката, како и за поглавје е искористено нивното лого. Дополнително димензиите на апликацијата се фиксирани за димензиите на мониторот кој се користи во амбулантата, и не е resizable или responsive бидејќи таква можност нема подршка за типот на апликација која ние ссе одлучивме да развиеме.
