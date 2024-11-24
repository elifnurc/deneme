using System;

namespace Prolab2
{
    public abstract class Kara : SavasAraclari
    {
        private int _dayaniklilik;
        private string _sinif;
        private int _vurus;

        // Abstract properties
        public abstract int DenizVurusAvantaji { get; set; }
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
        protected Kara() : base()
        {
            _sinif = "Kara";
        }

        protected Kara(int seviyePuani) : base(seviyePuani)
        {
            _sinif = "Kara";
        }

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
            Console.WriteLine($"Deniz Vurus Avantaji: {DenizVurusAvantaji}");
        }
    }
}
