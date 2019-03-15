using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GirisProjesi4.Models
{
    public class Urun
    {
        //private static int counter = 1;
        //public Urun()
        //{           
        //    counter++;
        //}
        
        [BindNever]
        public int UrunID { get; set; } /*= counter;*/

        public string Isim { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string Kategori { get; set; }

     
    }
}
