using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GirisProjesi4.Models.Soyut
{
    public interface IAmbar
    {
        void UrunEkle(Urun urun);

        IEnumerable<Urun> Urunler { get; }
    }
}
