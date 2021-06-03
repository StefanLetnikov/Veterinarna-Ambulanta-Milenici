using System;
using System.IO;

namespace Veterinarna_Ambulanta_Milenici
{
    public class DBHelper
    {
        public static readonly string SELECTALLTERMINI = "SELECT * FROM Termini WHERE datum='" + getDate() + "'";

        public static readonly string SELECTALLMILENICI = "SELECT * FROM Milenici"; //ми е потребно како query string за да ги добијам сите миленици од датабазата
        public static readonly string SELECTTOP1 = "SELECT TOP 1 * FROM Milenici WHERE id="; //ми е потребно како query string за да го добијам селектираниот миленик преку пребарување

        public static readonly string SELECTALLANAMNEZA = "SELECT * FROM Anamneza WHERE milenikId=";
        public static readonly string INSERTANAMNEZA = "INSERT INTO Anamneza (MilenikId, Anamneza, Datum) VALUES(@milenikId,@anamneza,@datum)";

        public static readonly string SELECTALLDIJAGNOSTICKIMETODI = "SELECT * FROM DijagnostickiMetodi WHERE milenikId=";
        public static readonly string INSERTDIJAGNOSTICKIMETODI = "INSERT INTO DijagnostickiMetodi (MilenikId, DijagnostickiMetodi, Datum) VALUES(@milenikId,@dijagnostickiMetodi,@datum)";

        public static readonly string SELECTALLTERAPIJA = "SELECT * FROM Terapija WHERE milenikId=";
        public static readonly string INSERTTERAPIJA = "INSERT INTO Terapija (MilenikId, Terapija, Datum) VALUES(@milenikId,@terapija,@datum)";

        public static readonly string SELECTALLVAKCINI = "SELECT * FROM Vakcini WHERE milenikId=";

        public static readonly string SELECTALLUSLUGI = "SELECT * FROM Uslugi WHERE milenikId=";

        public static readonly string SELECTALLTABLETI = "SELECT * FROM Tableti WHERE milenikId=";

        public static readonly string INSERTMILENIK = "INSERT INTO Milenici" +
                        "(ImeSopstvenik,PrezimeSopstvenik,Email,Kontakt,VidZivotno,RasaZivotno,ImeZivotno,StarostZivotno,Pol,Mikrocip, Datum) " +
                        "VALUES(@imeSopstvenik,@prezimeSopstvenik,@email,@kontakt,@vidZivotno,@rasaZivotno,@imeZivotno,@starostZivotno,@pol,@mikrocip,@datum)";

        public static readonly string INSERTVAKCINA = "INSERT INTO Vakcini (Datum,Vakcina,MilenikId) VALUES(@datum,@vakcina,@milenikId)";
        public static readonly string INSERTUSLUGA = "INSERT INTO Uslugi (Datum,Usluga,MilenikId) VALUES(@datum,@usluga,@milenikId)";
        public static readonly string INSERTABLETA = "INSERT INTO Tableti (Datum,Tableta,MilenikId) VALUES(@datum,@tableta,@milenikId)";


        public static string ConnVal()
        {
            //Ова е стринг кој враќа конекција со датабазата
            //Подоцна треба да се промени

            //return "Data Source=DESKTOP-6ANAM7J;Initial Catalog=VeterinaryDB;Persist Security Info=True;User ID=sa;Password=letnikov11";
            return "Data Source=DESKTOP-D3LRTE7\\SQLEXPRESS;Initial Catalog=VeterinaryDB;Persist Security Info=True;User ID=sa;Password=076999298";
            
           // string path = Path.GetFullPath(Environment.CurrentDirectory);
           // string dbName = "VeterinarnaDB.mdf";
            
            //return "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + path + "\\" + dbName + ";Integrated Security = True; Trusted_Connection = Yes;";
        
            //D:\milenici\Veterinarna Ambulanta Milenici\Veterinarna Ambulanta Milenici\Database1.mdf
        }

        public static string getDate()
        {
            //DateTime.Now.Date prikazuva vo ovoj format
            //10/27/2020 12:00:00 AM

            //"dd/MM/yyyy" format

            string fullDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string[] parts = fullDate.Split(null);
            string date = parts[0];
            return date; 
        }
    }
}
