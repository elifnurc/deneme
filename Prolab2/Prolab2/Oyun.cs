using System;
using System.Collections.Generic;

namespace Prolab2
{
    public class Oyun
    {
        private Oyuncu _insan;
        private Oyuncu _bilgisayar;
        private int _maxHamleSayisi;
        private int _mevcutHamle;
        private Random _random;
        private const int SEVIYE_SINIRI = 20;

        public Oyuncu InsanOyuncu => _insan;
        public Oyuncu BilgisayarOyuncu => _bilgisayar;
        public int MevcutHamle => _mevcutHamle;
        public bool OyunDevamEdiyor { get; private set; }

        public event EventHandler<string> OyunDurumDegisti;

        public Oyun(int maxHamleSayisi = 5)
        {
            _maxHamleSayisi = maxHamleSayisi;
            _mevcutHamle = 0;
            _random = new Random();
            _insan = new Oyuncu(1, "Oyuncu");
            _bilgisayar = new Oyuncu(2, "Bilgisayar");
            OyunDevamEdiyor = true;
        }

        public void OyunuBaslat()
        {
            BaslangicKartlariniDagit();
            DurumBildir("Oyun başladı. Kartlarınızı seçin.");
        }

        private void BaslangicKartlariniDagit()
        {
            for (int i = 0; i < 6; i++)
            {
                _insan.KartEkle(RastgeleBaslangicKartiOlustur());
                _bilgisayar.KartEkle(RastgeleBaslangicKartiOlustur());
            }
        }

        private SavasAraclari RastgeleBaslangicKartiOlustur()
        {
            switch (_random.Next(3))
            {
                case 0: return new Ucak();
                case 1: return new Obus();
                case 2: return new Firkateyn();
                default: return new Ucak();
            }
        }

        private void DurumBildir(string mesaj)
        {
            OyunDurumDegisti?.Invoke(this, mesaj);
        }

        public void HamleYap(List<int> secilenKartIndexleri)
        {
            if (!OyunDevamEdiyor || secilenKartIndexleri.Count != 3)
                return;

            _mevcutHamle++;
            // Hamle yapma mantığı...
        }

        public bool OyunBittiMi()
        {
            return _mevcutHamle >= _maxHamleSayisi ||
                   _insan.KartSayisi() == 0 ||
                   _bilgisayar.KartSayisi() == 0;
        }
    }
}