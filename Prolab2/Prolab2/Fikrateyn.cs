using System;

namespace Prolab2
{
    public class Firkateyn : Deniz
    {
        private int _havaVurusAvantaji;
        private string _altSinif;

        private const int BASLANGIC_DAYANIKLILIK = 25;  // PDF'de belirtildiği gibi
        private const int BASLANGIC_VURUS = 10;
        private const int HAVA_VURUS_AVANTAJI = 5;

        // Properties from Deniz class
        public override int HavaVurusAvantaji
        {
            get { return _havaVurusAvantaji; }
            set { _havaVurusAvantaji = value; }
        }

        public override string AltSinif
        {
            get { return _altSinif; }
            set { _altSinif = value; }
        }

        // Constructors
        public Firkateyn() : base()
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _havaVurusAvantaji = HAVA_VURUS_AVANTAJI;
            _altSinif = "Firkateyn";
            SeviyePuani = 0;  // PDF'de belirtildiği gibi başlangıç seviyesi 0
        }

        public Firkateyn(int seviyePuani) : base(seviyePuani)
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _havaVurusAvantaji = HAVA_VURUS_AVANTAJI;
            _altSinif = "Firkateyn";
        }

        // Saldırı gücü hesaplama metodu
        public int SaldiriGucuHesapla(SavasAraclari rakip)
        {
            int saldiriGucu = this.Vurus;

            // Hava sınıfına karşı avantaj
            if (rakip.Sinif == "Hava")
            {
                saldiriGucu += this.HavaVurusAvantaji;
            }

            return saldiriGucu;
        }

        // Override methods
        public override void DurumGuncelle(int saldiriGucu, int seviyePuaniArtisi)
        {
            base.DurumGuncelle(saldiriGucu, seviyePuaniArtisi);
        }

        public override void KartPuaniGoster()
        {
            base.KartPuaniGoster();
        }
    }
}