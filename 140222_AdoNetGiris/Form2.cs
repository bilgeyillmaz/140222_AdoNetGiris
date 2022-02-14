using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _140222_AdoNetGiris
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       SqlConnection baglanti = new SqlConnection("server=localhost; Database=KuzeyYeli;user=sa;password=1234");
        private void Form2_Load(object sender, EventArgs e)
        {
            //Disconnected mimari: yalnızca select sorguları için kullanılır , insert, update, delete için connected mimari kullanılır.
            //adaptördeki bilgiyi git dt ye doldur.
            UrunListele();

        }

        private void UrunListele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT*FROM Urunler", baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);


            dataGridView1.DataSource = dt;
            dataGridView1.Columns["UrunID"].Visible = false;
            dataGridView1.Columns["KategoriID"].Visible = false;
            dataGridView1.Columns["TedarikciID"].Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            string urunad = txtUrunAdi.Text;
            decimal fiyat = nudFiyat.Value;
            decimal stok = nudStok.Value;

            komut.CommandText = string.Format( "insert Urunler(UrunAdi,Fiyat,Stok) values('{0}',{1},{2})",urunad,fiyat,stok);
            komut.Connection = baglanti;
            baglanti.Open();
            int sonuc= komut.ExecuteNonQuery();
            if (sonuc > 0)
            {
                MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                UrunListele();
            }
            else
                MessageBox.Show("Kayıt ekleme sırasında hata oluştu.");

            baglanti.Close();
            
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            Kategoriler k = new Kategoriler();
            k.Show();
        }
    }
}
