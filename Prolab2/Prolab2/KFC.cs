using System;

namespace Prolab2
{
    public class KFS : Kara
    {
        private int _denizVurusAvantaji;
        private int _havaVurusAvantaji;
        private string _altSinif;

        private const int BASLANGIC_DAYANIKLILIK = 10;
        private const int BASLANGIC_VURUS = 15;
        private const int DENIZ_VURUS_AVANTAJI = 3;
        private const int HAVA_VURUS_AVANTAJI = 8;
        public const int SEVIYE_SINIRI = 20;

        public KFS() : base()
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _denizVurusAvantaji = DENIZ_VURUS_AVANTAJI;
            _havaVurusAvantaji = HAVA_VURUS_AVANTAJI;
            _altSinif = "KFS";
            SeviyePuani = 0;
        }

        public KFS(int seviyePuani) : base(seviyePuani)
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _denizVurusAvantaji = DENIZ_VURUS_AVANTAJI;
            _havaVurusAvantaji = HAVA_VURUS_AVANTAJI;
            _altSinif = "KFS";
        }

        public override int DenizVurusAvantaji
        {
            get { return _denizVurusAvantaji; }
            set { _denizVurusAvantaji = value; }
        }

        public override string AltSinif
        {
            get { return _altSinif; }
            set { _altSinif = value; }
        }

        public int HavaVurusAvantaji
        {
            get { return _havaVurusAvantaji; }
            set { _havaVurusAvantaji = value; }
        }

        public int SaldiriGucuHesapla(SavasAraclari rakip)
        {
            int saldiriGucu = Vurus;

            if (rakip.Sinif == "Deniz")
            {
                saldiriGucu += DenizVurusAvantaji;
            }
            else if (rakip.Sinif == "Hava")
            {
                saldiriGucu += HavaVurusAvantaji;
            }

            return saldiriGucu;
        }

        public static bool SecilebilirMi(int oyuncuSeviyesi)
        {
            return oyuncuSeviyesi >= SEVIYE_SINIRI;
        }
    }
}