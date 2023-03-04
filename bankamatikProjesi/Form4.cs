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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B2AV4A5\\SQLDEVELOPER;Initial Catalog=DbBankamatikProje;Integrated Security=True");
        public string gonderen;
        private void Form4_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select GONDEREN,(AD+' '+SOYAD) AS 'ALICI',TUTAR from TBLHAREKET inner join TBLKISILER on TBLHAREKET.ALICI=TBLKISILER.HESAPNO where gonderen=" + gonderen, baglanti);
            SqlDataAdapter DA = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            baglanti.Open();
            SqlCommand kmt2 = new SqlCommand("select (AD+' '+SOYAD) AS 'GONDEREN',ALICI,TUTAR from TBLHAREKET inner join TBLKISILER on TBLHAREKET.GONDEREN=TBLKISILER.HESAPNO where ALICI=" + gonderen, baglanti);
            SqlDataAdapter DA2 = new SqlDataAdapter(kmt2);
            DataTable dt2 = new DataTable();
            DA2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            baglanti.Close();


        }
    }
}
