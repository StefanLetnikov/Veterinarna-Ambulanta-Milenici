using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinarna_Ambulanta_Milenici
{
    public class Milenik
    {
        public string TipZivotno { get; set; }
        public string RasaZivotno { get; set; }
        public string ImeZivotno { get; set; }
        public int GodiniZivotno { get; set; }
        public string PolZivotno { get; set; }
        public string MikroCip { get; set; }
        public Sopstvenik SopstvenikNaZivotno { get; set; }
        public Milenik()
        {

        }
        public Milenik(string TipZivotno, string RasaZivotno, string ImeZivotno, int GodiniZivotno, string PolZivotno, string MikroCip, Sopstvenik SopstvenikNaZivotno)
        {
            this.TipZivotno = TipZivotno;
            this.RasaZivotno = RasaZivotno;
            this.ImeZivotno = ImeZivotno;
            this.GodiniZivotno = GodiniZivotno;
            this.PolZivotno = PolZivotno;
            this.MikroCip = MikroCip;
            this.SopstvenikNaZivotno = SopstvenikNaZivotno;
        }

        public override string ToString()
        {
            return string.Format("Име на животно:{0}\\Тип на животно:{1}\\Раса наживотно:{2}\\Старост на животно:{3}\\Пол:{4}\\Броој на Микро-чип:{5}\\Сопственик на животно:{6}", ImeZivotno, TipZivotno, RasaZivotno, GodiniZivotno, PolZivotno, MikroCip,SopstvenikNaZivotno);
        }
    }
}
