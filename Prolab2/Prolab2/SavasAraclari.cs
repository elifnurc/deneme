using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab2
{
  
        public abstract class SavasAraclari
        {
            // Abstract properties
            public abstract int Dayaniklilik { get; set; }
            public abstract string Sinif { get; set; }
            public abstract int Vurus { get; set; }

            // Concrete property
            private int _seviyePuani;
            public int SeviyePuani
            {
                get { return _seviyePuani; }
                set { _seviyePuani = value; }
            }

            // Constructors
            protected SavasAraclari()
            {
                _seviyePuani = 0; // Başlangıç seviye puanı 0
            }

            protected SavasAraclari(int seviyePuani)
            {
                _seviyePuani = seviyePuani;
            }

            // Kart puanı gösterme metodu
            public virtual void KartPuaniGoster()
            {
                Console.WriteLine($"Dayaniklilik: {Dayaniklilik}");
                Console.WriteLine($"Seviye Puani: {SeviyePuani}");
                Console.WriteLine($"Sinif: {Sinif}");
                Console.WriteLine($"Vurus Gucu: {Vurus}");
            }

            // Abstract durum güncelleme metodu
            public abstract void DurumGuncelle(int saldiriGucu, int seviyePuaniArtisi);
        }
    }
