using GirisProjesi4.Models.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GirisProjesi4.Models.Ambar.Sahte
{
    public class SahteAmbarFiyati30TLdenKucukUrunler :IAmbar
    {
        public IEnumerable<Urun> Urunler { get; set; } = new Urun[]{ new Urun{ UrunID=1,

                    Isim = "Ürün 1",
                    Aciklama = "Kaliteli ağrı kesici",
                    Kategori = "Ağrı kesiciler",
                    Fiyat = 5m
                },new Urun{
                    UrunID=2,
                    Isim = "Ürün 2",
                    Aciklama = "Sıradan ağrı kesici",
                    Kategori = "Ağrı kesiciler",
                    Fiyat = 8m
                },new Urun{
                    UrunID=3,
                    Isim = "Ürün 3",
                    Aciklama = "Güçlü ağrılar için",
                    Kategori = "Ağrı kesiciler",
                    Fiyat = 22.4m
                }
            };

        public void UrunEkle(Urun urun)
        {
            throw new NotImplementedException();
        }
    }
}
