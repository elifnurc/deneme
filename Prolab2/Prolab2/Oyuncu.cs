using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab2
{
    public class Oyuncu
    {
        // Properties
        public int OyuncuID { get; set; }
        public string OyuncuAdi { get; set; }
        public int Skor { get; private set; }
        public List<SavasAraclari> KartListesi { get; private set; }
        private HashSet<int> KullanilmisKartIndexleri { get; set; }
        private Random random;

        // Constructors
        public Oyuncu()
        {
            KartListesi = new List<SavasAraclari>();
            KullanilmisKartIndexleri = new HashSet<int>();
            Skor = 0;
            random = new Random();
        }

        public Oyuncu(int oyuncuID, string oyuncuAdi)
        {
            OyuncuID = oyuncuID;
            OyuncuAdi = oyuncuAdi;
            Skor = 0;
            KartListesi = new List<SavasAraclari>();
            KullanilmisKartIndexleri = new HashSet<int>();
            random = new Random();
        }

        // Kart işlemleri
        public void KartEkle(SavasAraclari kart)
        {
            KartListesi.Add(kart);
        }

        public void KartCikar(int index)
        {
            if (index >= 0 && index < KartListesi.Count)
            {
                KartListesi.RemoveAt(index);
            }
        }

        public SavasAraclari KartAl(int index)
        {
            if (index >= 0 && index < KartListesi.Count)
            {
                return KartListesi[index];
            }
            return null;
        }

        public int KartSayisi()
        {
            return KartListesi.Count;
        }

        // Seçili kartları getir (Windows Forms için)
        public List<SavasAraclari> SeciliKartlariGetir(List<int> secilenIndexler)
        {
            var secilenKartlar = new List<SavasAraclari>();
            foreach (int index in secilenIndexler)
            {
                if (index >= 0 && index < KartListesi.Count)
                {
                    secilenKartlar.Add(KartListesi[index]);
                    KullanilmisKartIndexleri.Add(index);
                }
            }
            return secilenKartlar;
        }

        // Bilgisayar için otomatik kart seçimi
        public List<SavasAraclari> BilgisayarKartSec()
        {
            var secilenKartlar = new List<SavasAraclari>();
            var kullanilabilirIndexler = new List<int>();

            // Kullanılabilir kartların indexlerini bul
            for (int i = 0; i < KartListesi.Count; i++)
            {
                if (!KullanilmisKartIndexleri.Contains(i))
                {
                    kullanilabilirIndexler.Add(i);
                }
            }

            // Eğer tüm kartlar kullanılmışsa, kullanılmış kartları sıfırla
            if (kullanilabilirIndexler.Count == 0)
            {
                KullanilmisKartIndexleri.Clear();
                for (int i = 0; i < KartListesi.Count; i++)
                {
                    kullanilabilirIndexler.Add(i);
                }
            }

            // Rastgele 3 kart seç
            for (int i = 0; i < Math.Min(3, kullanilabilirIndexler.Count); i++)
            {
                int randomIndex = random.Next(kullanilabilirIndexler.Count);
                int secilenIndex = kullanilabilirIndexler[randomIndex];
                secilenKartlar.Add(KartListesi[secilenIndex]);
                KullanilmisKartIndexleri.Add(secilenIndex);
                kullanilabilirIndexler.RemoveAt(randomIndex);
            }

            return secilenKartlar;
        }

        // Skor işlemleri
        public void SkorArttir(int puan)
        {
            Skor += puan;
        }

        public void SkorGoster()
        {
            Console.WriteLine($"{OyuncuAdi} Skor: {Skor}");
        }

        // Toplam dayanıklılık hesaplama
        public int ToplamDayaniklilik()
        {
            return KartListesi.Sum(kart => kart.Dayaniklilik);
        }

        // Seviye kontrolü
        public bool SeviyeKontrol(int gerekliSeviye)
        {
            return KartListesi.Any(kart => kart.SeviyePuani >= gerekliSeviye);
        }

        // Kartları temizle
        public void KullanilmisKartlariSifirla()
        {
            KullanilmisKartIndexleri.Clear();
        }

        // Kartları göster (debug için)
        public void KartlariGoster()
        {
            Console.WriteLine($"\n{OyuncuAdi} Kartları:");
            for (int i = 0; i < KartListesi.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Kart:");
                KartListesi[i].KartPuaniGoster();
                Console.WriteLine("-------------------------");
            }
        }
    }
}
