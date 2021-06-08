using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinarna_Ambulanta_Milenici
{
    public class NovTermin
    {
        public string ImeNaPacient { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public NovTermin() { }


        public override string ToString()
        {
            return string.Format("Име на пациент:{0}, Датум и час на преглед:{1}", ImeNaPacient, Date + Time);
        }
    }
}
