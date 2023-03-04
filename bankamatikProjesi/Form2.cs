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

namespace bankamatikProjesi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B2AV4A5\\SQLDEVELOPER;Initial Catalog=DbBankamatikProje;Integrated Security=True");

        public string hesap;
        private void Form2_Load(object sender, EventArgs e)
        {
            lblHesapNo.Text = hesap;

            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from TBLKISILER where HESAPNO=" + hesap, baglanti);
            SqlDataReader rd = kmt.ExecuteReader();
            while (rd.Read())
            {
                lblAdSoyad.Text = rd[1]+" " + rd[2];
                lblTelefon.Text = rd[4].ToString();
                lblTcKimlik.Text = rd[3].ToString();
            }
            baglanti.Close();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            //alıcı hesap bakiyesi güncelleme
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("UPDATE TBLHESAP SET BAKIYE=BAKIYE+@P1 WHERE HESAPNO=@P2", baglanti);
            kmt.Parameters.AddWithValue("@p2", mskHesapNo.Text);
            kmt.Parameters.AddWithValue("@p1", decimal.Parse(txtTutar.Text));
            kmt.ExecuteNonQuery();
            baglanti.Close();

            //gönderenin hesap bakiyesini güncelleme
            baglanti.Open();
            SqlCommand kmt2 = new SqlCommand("UPDATE TBLHESAP SET BAKIYE=BAKIYE-@P1 WHERE HESAPNO=@P2", baglanti);
            kmt2.Parameters.AddWithValue("@p2", hesap);
            kmt2.Parameters.AddWithValue("@p1", decimal.Parse(txtTutar.Text));
            kmt2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Para transferi gerçekleşti");

            //yapılan işlemi tblhareketler tablosuna ekleme
            baglanti.Open();
            SqlCommand kmt3 = new SqlCommand("insert into TBLHAREKET(GONDEREN,ALICI,TUTAR) VALUES(@E1,@E2,@E3)", baglanti);
            kmt3.Parameters.AddWithValue("@E1", hesap);
            kmt3.Parameters.AddWithValue("@E2", mskHesapNo.Text);
            kmt3.Parameters.AddWithValue("@E3", txtTutar.Text);
            kmt3.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.gonderen = lblHesapNo.Text;
            frm4.Show();
        }
    }
}
