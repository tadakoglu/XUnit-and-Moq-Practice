using System;
using System.Collections.Generic;
using System.Text;
using GirisProjesi4.Models;
using GirisProjesi4.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using GirisProjesi4.Models.Ambar;
using GirisProjesi4.Models.Ambar.Sahte;
using Moq;
using GirisProjesi4.Models.Soyut;

namespace GirisProjesi4.BirimTestler
{
    public class UrunTestleri
    {
        [Fact]
        public void UrunAdiDegisebiliyorMu()
        {
            //Oluştur (Arrange)
            Urun u = new Urun { Isim = "Test", Fiyat = 50M };

            //Değiştir(Act)
            u.Isim = "XUnit İle Yeni";

            //İddia Et()
            Assert.Equal("XUnit İle Yeni", u.Isim); // İkisi eşit mi diye bir kontrol et.
        }
        //Burada KASITLI bir hata bırakıldı. XXUnit >> XUnit olmalıydı

        [Fact] //[Theory] sadece parametreli test metotlarına uygulanabilir. [Fact] ise parametresizlere.
        public void UrunKategorisiDegisebiliyorMuKasitliHatali()
        {
            //Oluştur (Arrange) setting up the conditions
            Urun u = new Urun { Isim = "Test", Fiyat = 50M ,Kategori="Test"};

            //Değiştir(Act) performing the test, and
            u.Kategori = "XXUnit İle Yeni Kategori";

            //İddia Et() verifying that the result
            Assert.Equal("XUnit İle Yeni Kategori", u.Kategori); // İkisi eşit mi diye bir kontrol et.
        }
        [Fact]
        public void UrunKategorisiDegisebiliyorMu()
        {
            //Oluştur (Arrange) setting up the conditions
            Urun u = new Urun { Isim = "Test", Fiyat = 50M, Kategori = "Test" };

            //Değiştir(Act) performing the test, and
            u.Kategori = "XUnit İle Yeni Kategori";

            //İddia Et() verifying that the result
            Assert.Equal("XUnit İle Yeni Kategori", u.Kategori); // İkisi eşit mi diye bir kontrol et.
        }
        [Fact]
        public void TumKatalogGosteriliyorMu()
        {
            var controller = new AnasayfaController();
            // Sahne Al(Perform,Act)
            //Index Action metotta POST REQUEST'TE arguman(parametre) olarak alınan Model'i getirelim.
            var AlinanModel = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Urun>;

            // Teyit Et(Assert, iki bilgi eşit mi vb.)//1.si  beklenen, 2.si gerçek/şu an ki sonuç
            Assert.Equal(OrnekVeriAmbari.Veri.Urunler, AlinanModel,Karsilastirici.Olustur<Urun>((u1, u2) => u1.Isim == u2.Isim && u1.Fiyat == u2.Fiyat));           
        }
        [Fact]
        public void Fiyati30TLAltindakiTumUrunlerGosteriliyorMu() //IAMBARI'I İMPLEMENTE EDEN SAHTE OBJE KULLANIMI
        {
            //Düzenle(Arrange)
            var controller = new AnasayfaController();
            controller.ambar = new SahteAmbarFiyati30TLdenKucukUrunler(); //Bu ambar sahtedir/gerçek ürünlerle alakası yok.
            //Harekete Geç(Act)
            var ViewModeli = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Urun>; // actual
            //Test Et(Assert)
            Assert.Equal(controller.ambar.Urunler, ViewModeli, Karsilastirici.Olustur<Urun>((u1, u2) => u1.Isim == u2.Isim && u1.Fiyat == u2.Fiyat));

        }
        [Theory] // Theory parametreli birim testler için kullanılır. [Fact] ise parametresiz olanlar için
        [InlineData(2.44,5.99,19.99, 20)] // bu parametreler fiyat argümanlarına geçirilir. ve metot testini yapar.
        [InlineData(5.99, 999, 0, 10)] // bu parametreler fiyat argümanlarına geçirilir. ve metot testini yapar.
        [InlineData(0, 0, 2, 1)] // bu parametreler fiyat argümanlarına geçirilir. ve metot testini yapar.
        public void FiyatlarDogruAktariliyorMu(decimal fiyat1, decimal fiyat2, decimal fiyat3, decimal fiyat4) //IAMBARI'I İMPLEMENTE EDEN SAHTE OBJE KULLANIMI
        {
            //Düzenle(Arrange)
            var controller = new AnasayfaController();
            controller.ambar = new SahteAmbarFiyati30TLdenKucukUrunler
            {
                Urunler = new[]{
                new Urun{  Isim = "Mazejik", Aciklama = "Kaliteli ağrı kesici",Kategori = "Ağrı kesiciler", Fiyat = fiyat1},
                new Urun{Isim = "Asprin", Aciklama = "Sıradan ağrı kesici",   Kategori = "Ağrı kesiciler",Fiyat = fiyat2},
                new Urun{Isim = "Aprana", Aciklama = "Güçlü ağrılar için", Kategori = "Ağrı kesiciler", Fiyat = fiyat3},
                new Urun{Isim = "4. Sahte Ürün", Aciklama = "Güçlü ağrılar için", Kategori = "Ağrı kesiciler", Fiyat = fiyat4}
            }
            };

            //Harekete Geç(Act)
            var ViewModeli = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Urun>; // actual
            
            //Test Et(Assert)
            Assert.Equal(controller.ambar.Urunler, ViewModeli, Karsilastirici.Olustur<Urun>((u1, u2) => u1.Isim == u2.Isim && u1.Fiyat == u2.Fiyat));

        }

        //[MemberData("statik klass ve member name yolu")]// bu şekilde Ürün nesnesi de parametre olarak birim test metoduna sınıf statik üyesinden geçirilebilir.
        //[ClassData(typeof("sınıf adı"))]// bu şekilde Ürün nesnesi de parametre olarak birim test metoduna ıenumerable implemente eden bir sınıftan geçirilebilir.
        //**Ancak bunlara pek fazla gerek yok biz bunun yerine sahte obje oluşturma aracı MOQ kullanarak işimizi hızlıca halletmeye çalışacağız.
        //MOQ bir "Fakes framework" örneğidir. Microsoft Fakes vb. örnekleri vardır.
        //Moq sadece birim test projesine eklenir. (Nuget ile)

        [Fact]
        public void AmbarUrunleriSadeceVeSadeceBirKereCagrildiMi_Index_AnasayfaMetodu() // MOQ KULLANIMI
        {
            //Düzenle
            var sahte = new Mock<IAmbar>();
            sahte.SetupGet(ambar => ambar.Urunler).Returns(new[] { new Urun { Isim = "Ürün 1",Aciklama="Açıklama", Fiyat = 100 } }); //IAmbar üzerindeki Ürünler özelliğine SetupGet ve Return ile sahte obje atadım.
            var controller = new AnasayfaController();
            controller.ambar = sahte.Object; // sahte obje Object ile getirilir.
            //Harekete Geç
            var sonuc = controller.Index();
            //Denetle
            sahte.VerifyGet(ambar => ambar.Urunler, Times.Once); //Ambar ürünlerinin controller'den index metodu çağrılışında sadece bir kere çekilip çekilmediğini denetledim
           
        }
    }
}
