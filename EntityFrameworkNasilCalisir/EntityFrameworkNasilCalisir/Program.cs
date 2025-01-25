using EntityFrameworkNasilCalisir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkNasilCalisir.Entity;

namespace EntityFrameworkNasilCalisir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DataModel dm = new DataModel();
            //List<Urun> urunler = dm.UrunListele();

            //foreach (Urun item in urunler)
            //{
            //    Console.WriteLine($"ID={item.ID} ) {item.Isim}\n{item.Kategori.Isim} {item.Kategori.Aciklama}");
            //    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            //}
            NORTHWNDEntities1 db = new NORTHWNDEntities1();

            Categories c = db.Categories.Find(8);

            foreach (Products item in c.Products)
            {
                Console.WriteLine(item.ProductID + " )" + item.ProductName + " && " + item.Suppliers.CompanyName);
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*");
            }
        }
    }
}
