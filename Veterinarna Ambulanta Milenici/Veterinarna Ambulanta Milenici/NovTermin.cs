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
        public string DateAndTime { get; set; }
        public string Opis { get; set; }

        public NovTermin() { }

        public NovTermin(string ImeNaPacient,string DateAndTime,string Opis)
        {
            this.ImeNaPacient = ImeNaPacient;
            this.DateAndTime = DateAndTime;
            this.Opis = Opis;
        }

        public override string ToString()
        {
            return string.Format("Име на пациент:{0}, Датум и час на преглед:{1}\nОпис за преглед:{2}",ImeNaPacient,DateAndTime,Opis);
        }
    }
}
