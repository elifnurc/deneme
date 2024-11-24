using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab2
{
    public class Siha : Hava
    {
        private int _karaVurusAvantaji;
        private int _denizVurusAvantaji;
        private string _altSinif;

        private const int BASLANGIC_DAYANIKLILIK = 15;
        private const int BASLANGIC_VURUS = 8;
        private const int KARA_VURUS_AVANTAJI = 3;
        private const int DENIZ_VURUS_AVANTAJI = 4;

        // Properties
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

        public int DenizVurusAvantaji
        {
            get { return _denizVurusAvantaji; }
            set { _denizVurusAvantaji = value; }
        }

        // Constructors
        public Siha() : base()
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _karaVurusAvantaji = KARA_VURUS_AVANTAJI;
            _denizVurusAvantaji = DENIZ_VURUS_AVANTAJI;
            _altSinif = "Siha";
        }

        public Siha(int seviyePuani) : base(seviyePuani)
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _karaVurusAvantaji = KARA_VURUS_AVANTAJI;
            _denizVurusAvantaji = DENIZ_VURUS_AVANTAJI;
            _altSinif = "Siha";
        }

        // Saldırı gücü hesaplama metodu
        public int SaldiriGucuHesapla(SavasAraclari rakip)
        {
            int saldiriGucu = Vurus;

            if (rakip.Sinif == "Kara")
            {
                saldiriGucu += KaraVurusAvantaji;
            }
            else if (rakip.Sinif == "Deniz")
            {
                saldiriGucu += DenizVurusAvantaji;
            }

            return saldiriGucu;
        }

        public override void KartPuaniGoster()
        {
            base.KartPuaniGoster();
            Console.WriteLine($"Deniz Vurus Avantaji: {DenizVurusAvantaji}");
        }

        public override string ToString()
        {
            return $"Siha [Dayaniklilik={Dayaniklilik}, " +
                   $"SeviyePuani={SeviyePuani}, " +
                   $"Vurus={Vurus}, " +
                   $"KaraVurusAvantaji={KaraVurusAvantaji}, " +
                   $"DenizVurusAvantaji={DenizVurusAvantaji}]";
        }
    }
}
