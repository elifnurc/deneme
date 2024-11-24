using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab2
{
    public abstract class Hava : SavasAraclari
    {
        private int _dayaniklilik;
        private string _sinif;
        private int _vurus;

        // Abstract properties specific to Hava class
        public abstract int KaraVurusAvantaji { get; set; }
        public abstract string AltSinif { get; set; }

        // Implementation of abstract properties from parent class
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
        protected Hava() : base()
        {
            _sinif = "Hava";
        }

        protected Hava(int seviyePuani) : base(seviyePuani)
        {
            _sinif = "Hava";
        }

        // Override durumGuncelle method
        public override void DurumGuncelle(int saldiriGucu, int seviyePuaniArtisi)
        {
            Dayaniklilik -= saldiriGucu;
            SeviyePuani += seviyePuaniArtisi;

            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }

        // Override kartPuaniGoster to add hava specific properties
        public override void KartPuaniGoster()
        {
            base.KartPuaniGoster();
            Console.WriteLine($"Alt Sinif: {AltSinif}");
            Console.WriteLine($"Kara Vurus Avantaji: {KaraVurusAvantaji}");
        }
    }
}
