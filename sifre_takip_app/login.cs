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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            DataTable dt = CLS.SQLConnectionClass.Table("select kul_ad from KULLANICILAR where kul_kod = '" + txt_kullanici_adi.Text + "' and kul_pw='" + txt_sifre.Text + "'");
            if (dt.Rows.Count > 0)
            {
                CLS.MyGlobals.Aktif_Kullanici_Adı = dt.Rows[0]["kul_ad"].ToString();
                CLS.MyGlobals.Aktif_Kullanici_Kodu = txt_kullanici_adi.Text;

                this.Hide();
                new Anaform().ShowDialog();
            }
            else
            {
                MessageBox.Show("bilgiler hatalı");
            }
        }

    }
}
