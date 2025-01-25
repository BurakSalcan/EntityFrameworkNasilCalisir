using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNasilCalisir.Model
{
    public class DataModel
    {

        public DataModel() 
        {
            
        }

        public List<Urun> UrunListele()
        {
            SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS;Integrated Security=True;Initial Catalog=NORTHWND");
            SqlCommand cmd = con.CreateCommand();

            try
            {
                List<Urun> urunler = new List<Urun>();

                cmd.CommandText = "SELECT ProductID, ProductName, CategoryID, UnitPrice, UnitInStock FROM Products";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Urun u = new Urun();
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.KategoriID = reader.GetInt32(2);
                    u.Fiyat = reader.GetDecimal(3);
                    u.Stok = reader.GetInt16(4);
                    u.Kategori = KategoriGetir(u.KategoriID);
                    urunler.Add(u);
                }

                return urunler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS;Integrated Security=True;Initial Catalog=NORTHWND");
            SqlCommand cmd = con.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT CategoryID, CategoryName, Description FROM Categories WHERE CategoryID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kategori k = new Kategori();
                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Aciklama = reader.GetString(2);
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
