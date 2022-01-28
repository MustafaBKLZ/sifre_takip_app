using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sifre_takip_app
{
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }

        private void Anaform_Load(object sender, EventArgs e)
        {
            txt_kayit_no.Text = "0";
            hoşGeldinToolStripMenuItem.Text += CLS.MyGlobals.Aktif_Kullanici_Adı;
            Grid_Doldur();
        }


        private void Grid_Doldur()
        {
            dataGridView1.DataSource = CLS.SQLConnectionClass.Table("select * from SIFRELER");
        }


        private void Anaform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            MYMODELS.SIFRELER.SIFRE sif = new MYMODELS.SIFRELER.SIFRE()
            {
                sif_RECno = Convert.ToInt32(txt_kayit_no.Text),
                sif_kul_adi_mail = txt_kul_adi.Text,
                sif_kul_sifre = txt_sifre.Text,
                sif_notlar = txt_notlar.Text,
                sif_site_adi = txt_site_ad.Text,
                sif_site_url = txt_url.Text
            };
            txt_kayit_no.Text = MYMODELS.SIFRELER.SIFRE_Kaydet(sif).ToString();
            Grid_Doldur();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            MYMODELS.SIFRELER.SIFRE_Sil(Convert.ToInt32(txt_kayit_no.Text));
            Temizle();
            Grid_Doldur();
        }

        private void btn_yeni_Click(object sender, EventArgs e)
        {
            txt_kayit_no.Text = "0";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txt_kayit_no.Text = row.Cells["sif_RECno"].Value.ToString();
                txt_kul_adi.Text = row.Cells["sif_kul_adi_mail"].Value.ToString();
                txt_sifre.Text = row.Cells["sif_kul_sifre"].Value.ToString();
                txt_notlar.Text = row.Cells["sif_notlar"].Value.ToString();
                txt_site_ad.Text = row.Cells["sif_site_adi"].Value.ToString();
                txt_url.Text = row.Cells["sif_site_url"].Value.ToString();
            }
        }

        void Temizle()
        {
            txt_kayit_no.Text = "0";
            txt_kul_adi.Text = "";
            txt_sifre.Text = "";
            txt_notlar.Text = "";
            txt_site_ad.Text = "";
            txt_url.Text = "";
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
