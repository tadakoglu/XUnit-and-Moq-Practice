using GirisProjesi4.Models.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GirisProjesi4.Models.Ambar
{
    public class OrnekVeriAmbari : IAmbar
    {
        //Static Veri değişkenindeki amaç direk verileri hızlıca OrnekVeriAmbari.Veri üzerinden çekmek
        public static OrnekVeriAmbari Veri = new OrnekVeriAmbari();

        //Bu static değişkenler sadece bir kere atanır(Initialization) ve o değeri hep korur.
        //Ambar ürünleri
        private Dictionary<string, Urun> urunler = new Dictionary<string, Urun>();
        public OrnekVeriAmbari()
        {
            Urun[] urunlerimiz =  new[]{ new Urun{
                   
                    Isim = "Mazejik",
                    Aciklama = "Kaliteli ağrı kesici",
                    Kategori = "Ağrı kesiciler",
                    Fiyat = 12.99m
                },new Urun{
                    
                    Isim = "Asprin",
                    Aciklama = "Sıradan ağrı kesici",
                    Kategori = "Ağrı kesiciler",
                    Fiyat = 5.99m
                },new Urun{
                  
                    Isim = "Apranax",
                    Aciklama = "Güçlü ağrılar için",
                    Kategori = "Ağrı kesiciler",
                    Fiyat = 48.99m
                }
            };
            foreach (Urun u in urunlerimiz)
            UrunEkle(u);
            //urunler.Add("Hatalı", null);
        }
        
        public void UrunEkle(Urun urun)
        {
            urun.UrunID = ++Startup.ID;
            urunler.Add(urun.Isim, urun);
        }
        public IEnumerable<Urun> Urunler => urunler.Values; //Urun[] olarak getirir. => fonksiyon/metot göstergesidir
    }
}
