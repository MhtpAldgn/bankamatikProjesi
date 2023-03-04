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

namespace bankamatikProjesi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B2AV4A5\\SQLDEVELOPER;Initial Catalog=DbBankamatikProje;Integrated Security=True");     
        void temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTc.Text = "";
            mskHesapno.Text = "";
            txtSifre.Text = "";
            mskTelefon.Text = "";
            txtAd.Focus();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into TBLKISILER(AD,SOYAD,TC,TELEFON,HESAPNO,SIFRE) values(@e1,@e2,@e3,@e4,@e5,@e6)", baglanti);
            kmt.Parameters.AddWithValue("@e1", txtAd.Text);
            kmt.Parameters.AddWithValue("@e2", txtSoyad.Text);
            kmt.Parameters.AddWithValue("@e3", mskTc.Text);
            kmt.Parameters.AddWithValue("@e4", mskTelefon.Text);
            kmt.Parameters.AddWithValue("@e5", mskHesapno.Text);
            kmt.Parameters.AddWithValue("@e6", txtSifre.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            

            baglanti.Open();
            SqlCommand kmt2 = new SqlCommand("insert into TBLHESAP (HESAPNO) values(@h1)", baglanti);
            kmt2.Parameters.AddWithValue("@h1", mskHesapno.Text);
            kmt2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Bilgileri Sisteme Kaydedildi");
            temizle();

        }

        private void btnHesapno_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int hesapno = rastgele.Next(100000, 1000000);
            mskHesapno.Text = hesapno.ToString();
        }
    }
}
