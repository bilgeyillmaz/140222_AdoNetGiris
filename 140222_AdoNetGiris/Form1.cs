using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _140222_AdoNetGiris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { //connected mimari 
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "server=localhost; Database=KuzeyYeli;user=sa;password=1234";
            // localhost yerine . da yazabiliriz
            //bir kullanıcımız yoksa
            //baglanti.ConnectionString = "server=localhost;database=KuzeyYeli;Integrated Security=true"; //windows authentication 

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "select*from urunler";
            komut.Connection = baglanti;

            baglanti.Open();
            SqlDataReader rdr =  komut.ExecuteReader();
            while (rdr.Read())
            {
               string ad=  rdr["UrunAdi"].ToString();
               string fiyat=  rdr["Fiyat"].ToString();
                string stok = rdr["Stok"].ToString();
                lstUrunler.Items.Add(string.Format("{0}--{1}--{2}", ad, fiyat, stok));
            }
            baglanti.Close();

            SqlCommand komut2 = new SqlCommand();
            komut2.CommandText = "select*from Kategoriler";
            komut2.Connection = baglanti;
            baglanti.Open();
            SqlDataReader rdr2 = komut2.ExecuteReader();
            while(rdr2.Read())
            {
                string kategoriad = rdr2["KategoriAdi"].ToString();
                string tanim = rdr2["Tanimi"].ToString();
                lstKategoriler.Items.Add(string.Format("{0}--{1}", kategoriad, tanim));

            }
            baglanti.Close();






        }
    }
}
