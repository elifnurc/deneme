using System;

namespace Prolab2
{
    public class Sida : Deniz
    {
        private int _havaVurusAvantaji;
        private int _karaVurusAvantaji;
        private string _altSinif;

        private const int BASLANGIC_DAYANIKLILIK = 15;  // PDF'de belirtildiği gibi
        private const int BASLANGIC_VURUS = 12;
        private const int HAVA_VURUS_AVANTAJI = 4;
        private const int KARA_VURUS_AVANTAJI = 6;
        public const int SEVIYE_SINIRI = 20;  // PDF'de belirtildiği gibi erişim sınırı

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

        // Sida'ya özel property
        public int KaraVurusAvantaji
        {
            get { return _karaVurusAvantaji; }
            set { _karaVurusAvantaji = value; }
        }

        // Constructors
        public Sida() : base()
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _havaVurusAvantaji = HAVA_VURUS_AVANTAJI;
            _karaVurusAvantaji = KARA_VURUS_AVANTAJI;
            _altSinif = "Sida";
            SeviyePuani = 0;  // PDF'de belirtildiği gibi başlangıç seviyesi 0
        }

        public Sida(int seviyePuani) : base(seviyePuani)
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _havaVurusAvantaji = HAVA_VURUS_AVANTAJI;
            _karaVurusAvantaji = KARA_VURUS_AVANTAJI;
            _altSinif = "Sida";
        }

        // Seviye kontrolü için statik metod
        public static bool SecilebilirMi(int oyuncuSeviyesi)
        {
            return oyuncuSeviyesi >= SEVIYE_SINIRI;
        }

        // Saldırı gücü hesaplama metodu
        public int SaldiriGucuHesapla(SavasAraclari rakip)
        {
            int saldiriGucu = this.Vurus;

            if (rakip.Sinif == "Hava")
            {
                saldiriGucu += this.HavaVurusAvantaji;
            }
            else if (rakip.Sinif == "Kara")
            {
                saldiriGucu += this.KaraVurusAvantaji;
            }

            return saldiriGucu;
        }

        // Override methods
        public override void KartPuaniGoster()
        {
            base.KartPuaniGoster();
            Console.WriteLine($"Kara Vurus Avantaji: {KaraVurusAvantaji}");
        }

        public override void DurumGuncelle(int saldiriGucu, int seviyePuaniArtisi)
        {
            base.DurumGuncelle(saldiriGucu, seviyePuaniArtisi);
        }
    }
}