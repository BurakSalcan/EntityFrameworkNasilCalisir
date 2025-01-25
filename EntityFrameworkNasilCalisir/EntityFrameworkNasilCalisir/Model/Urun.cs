using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNasilCalisir.Model
{
    public class Urun
    {
        public int ID { get; set; }

        public string Isim { get; set; }

        public int KategoriID { get; set; }

        public decimal Fiyat { get; set; }

        public short Stok { get; set; }

        public Kategori Kategori { get; set; }
    }
}
