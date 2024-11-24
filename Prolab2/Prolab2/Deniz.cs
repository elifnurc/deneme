using System;

namespace Prolab2
{
    public abstract class Deniz : SavasAraclari
    {
        private int _dayaniklilik;
        private string _sinif;
        private int _vurus;

        // Abstract properties for Deniz class
        public abstract int HavaVurusAvantaji { get; set; }
        public abstract string AltSinif { get; set; }

        // Implement abstract properties from SavasAraclari
        public override int Dayaniklilik
        {
            get { return _dayaniklilik; }
            set { _dayaniklilik = value; }
        }

        public override string Sinif
        {
            get { return _sinif; }
            set { _sinif = value; }
        }

        public override int Vurus
        {
            get { return _vurus; }
            set { _vurus = value; }
        }

        // Constructors
        protected Deniz() : base()
        {
            _sinif = "Deniz";
        }

        protected Deniz(int seviyePuani) : base(seviyePuani)
        {
            _sinif = "Deniz";
        }

        // Override methods from SavasAraclari
        public override void DurumGuncelle(int saldiriGucu, int seviyePuaniArtisi)
        {
            Dayaniklilik -= saldiriGucu;
            SeviyePuani += seviyePuaniArtisi;

            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }

        public override void KartPuaniGoster()
        {
            base.KartPuaniGoster();
            Console.WriteLine($"Alt Sinif: {AltSinif}");
            Console.WriteLine($"Hava Vurus Avantaji: {HavaVurusAvantaji}");
        }
    }
}