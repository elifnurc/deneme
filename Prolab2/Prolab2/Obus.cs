using System;

namespace Prolab2
{
    public class Obus : Kara
    {
        private int _denizVurusAvantaji;
        private string _altSinif;

        private const int BASLANGIC_DAYANIKLILIK = 20;
        private const int BASLANGIC_VURUS = 10;
        private const int DENIZ_VURUS_AVANTAJI = 5;

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

        public Obus() : base()
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _denizVurusAvantaji = DENIZ_VURUS_AVANTAJI;
            _altSinif = "Obus";
            SeviyePuani = 0;
        }

        public Obus(int seviyePuani) : base(seviyePuani)
        {
            Dayaniklilik = BASLANGIC_DAYANIKLILIK;
            Vurus = BASLANGIC_VURUS;
            _denizVurusAvantaji = DENIZ_VURUS_AVANTAJI;
            _altSinif = "Obus";
        }

        public int SaldiriGucuHesapla(SavasAraclari rakip)
        {
            int saldiriGucu = Vurus;

            if (rakip.Sinif == "Deniz")
            {
                saldiriGucu += DenizVurusAvantaji;
            }

            return saldiriGucu;
        }
    }
}
