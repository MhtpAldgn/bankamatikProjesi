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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B2AV4A5\\SQLDEVELOPER;Initial Catalog=DbBankamatikProje;Integrated Security=True");

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from TBLKISILER where HESAPNO=@p1 and SIFRE=@p2", baglanti);
            kmt.Parameters.AddWithValue("@p1", mskHesapno.Text);
            kmt.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader rd = kmt.ExecuteReader();
            if (rd.Read())
            {
                Form2 frm2 = new Form2();
                frm2.hesap = mskHesapno.Text;
                frm2.Show();
            }
            else
            {
                MessageBox.Show("Hesap numarası veya şifre yanlış");
            }
            baglanti.Close();
        }
    }
}
