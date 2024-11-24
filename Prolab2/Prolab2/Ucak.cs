using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab2
{
    public class Ucak : Hava
    {
        private int _karaVurusAvantaji;
        private string _altSinif;

        private const int BASLANGIC_DAYANIKLILIK = 20;
        private const int BASLANGIC_VURUS = 10;
        private const int KARA_VURUS_AVANTAJI = 5;

        // Override abstract properties
        public override int KaraVurusAvantaji
        {
            get { return _karaVurusAvantaji; }
            set { _karaVurusAvantaji = value; }
        }

        public override string AltSinif
        {
            get { return _altSinif; }
            set { _altSinif = value; }
        }

        // Constructors
        public Ucak() : base()
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _karaVurusAvantaji = KARA_VURUS_AVANTAJI;
            _altSinif = "Ucak";
        }

        public Ucak(int seviyePuani) : base(seviyePuani)
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _karaVurusAvantaji = KARA_VURUS_AVANTAJI;
            _altSinif = "Ucak";
        }

        // Saldırı gücü hesaplama metodu
        public int SaldiriGucuHesapla(SavasAraclari rakip)
        {
            int saldiriGucu = Vurus;

            if (rakip.Sinif == "Kara")
            {
                saldiriGucu += KaraVurusAvantaji;
            }

            return saldiriGucu;
        }

        public override string ToString()
        {
            return $"Ucak [Dayaniklilik={Dayaniklilik}, " +
                   $"SeviyePuani={SeviyePuani}, " +
                   $"Vurus={Vurus}, " +
                   $"KaraVurusAvantaji={KaraVurusAvantaji}]";
        }
    }
}
