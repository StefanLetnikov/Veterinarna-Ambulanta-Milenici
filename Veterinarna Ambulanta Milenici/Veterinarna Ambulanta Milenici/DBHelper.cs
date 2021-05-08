namespace Veterinarna_Ambulanta_Milenici
{
    public class DBHelper
    {
        public static string ConnVal()
        {
            //Ова е стринг кој враќа конекција со датабазата
            //Подоцна треба да се промени
            return "Data Source=DESKTOP-D3LRTE7\\SQLEXPRESS;Initial Catalog=VeterinaryDB;Persist Security Info=True;User ID=sa;Password=076999298";
        }
    }
}
