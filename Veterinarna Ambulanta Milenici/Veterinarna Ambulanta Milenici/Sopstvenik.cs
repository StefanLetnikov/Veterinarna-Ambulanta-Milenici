using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinarna_Ambulanta_Milenici
{
    public class Sopstvenik
    {
        public string ImeSopstvenik { get; set; }
        public string PrezimeSopsrvnik { get; set; }
        public string EmailSopsrtvenik { get; set; }
        public string BrojZaKontaktSopstvenik { get; set; }
        public List<Milenik> Milenici { get; set; }

        public Sopstvenik()
        {
            Milenici = new List<Milenik>();
        }

        public Sopstvenik(string ImeSopstvenik, string PrezimeSopsrvnik, string EmailSopsrtvenik, string BrojZaKontaktSopstvenik)
        {
            Milenici = new List<Milenik>();
            this.ImeSopstvenik = ImeSopstvenik;
            this.PrezimeSopsrvnik = PrezimeSopsrvnik;
            this.EmailSopsrtvenik = EmailSopsrtvenik;
            this.BrojZaKontaktSopstvenik = BrojZaKontaktSopstvenik;
        }

        public void addMilenik(Milenik milenik)
        {
            Milenici.Add(milenik);
        }

        public override string ToString()
        {
            return string.Format("Име на сопственикот:{0}\\Презиме на сопственикот:{1}\\Број за контакт на сопственикот:{2}\\E-mail адреса на сопственикот:{3}", ImeSopstvenik, PrezimeSopsrvnik, BrojZaKontaktSopstvenik, EmailSopsrtvenik);
        }

    }
}
