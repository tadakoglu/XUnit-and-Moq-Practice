using System;
using System.Collections.Generic;
using System.Text;

namespace GirisProjesi4.BirimTestler
{
    //Bu sınıf iki ürün sınıfı objesi karşılaştırılırken kullanılacaktır.
    //Birim Test yaparken xUnit framework'ü Assert(teyit etme) metodu, işleri hızlandırmak için bir sınıflandırıcı isteyebilmektedir bu sebeple bu sınıf geliştirildi.
    class Karsilastirici<T> :IEqualityComparer<T>
    {
        //Karsilastirici<Urun>.Olustur<Urun>(T,T=> {}) ŞEKLİNDE ÇAĞIRMAK YERİNE
        //Karsilastirici.Olustur<Urun> şeklinde çağrı yapmak için aşağıdaki yardımcı (Karsilastirici) sınıfı oluşturdum
        
        //Bu metot da kullanılabilir. Ancak aşağıda yeni sınıfta oluşturulan metot kullanması daha pratik olacaktır.
        //public static Karsilastirici<U> Olustur<U>(Func<U, U, bool> karsilastirmaFonk)
        //{
        //    return new Karsilastirici<U>(karsilastirmaFonk);
        //}        

        private Func<T, T, bool> karsilastirmaFonk; //bu bir t ve t tipi iki değişken alıp bool döndüren bir delegate metottur.
        public Karsilastirici(Func<T, T, bool> karsilastirmaFonk)
        {
            this.karsilastirmaFonk = karsilastirmaFonk;
        }
        public bool Equals(T x, T y)  //IEqualityComparer<T> interfacesinden geliyor
        {
            return karsilastirmaFonk(x, y);
        }
        public int GetHashCode(T obj) //IEqualityComparer<T> interfacesinden geliyor
        {
            return obj.GetHashCode();
        }
    }
    class Karsilastirici // Bu bizim yardımcı sınıfımız sadece kısaltma amacıyla kullanıldı.
    {
        //Bu metot Karsilastirici.Olustur<Urun> şeklinde çok daha pratik çağrılabilir
        public static Karsilastirici<U> Olustur<U>(Func<U, U, bool> karsilastirmaFonk)
        {
            return new Karsilastirici<U>(karsilastirmaFonk);
        }
    }
}
