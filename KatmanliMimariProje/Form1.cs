using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using BusinessLayer;
using DataAccessLayer;

namespace KatmanliMimariProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            EntityDers ent = new EntityDers();
            ent.DersAd = TxtAd.Text;
            BlDers.DersEkleBL(ent);
            MessageBox.Show("Kaydetme İşlemi Başarılı","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            List<EntityDers> ders = BlDers.DersListesiBL();
            dataGridView1.DataSource = ders;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            byte deger;
            deger = byte.Parse(TxtID.Text);
            EntityDers ent = new EntityDers();
            ent.DersID = byte.Parse(deger.ToString());
            BlDers.DersSilBL(ent.DersID);
            MessageBox.Show("Silme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            EntityDers ent = new EntityDers();
            ent.DersAd = TxtAd.Text;
            ent.DersID = byte.Parse(TxtID.Text);
            BlDers.DersGüncelleBL(ent);
            MessageBox.Show("Güncelleme işlemi Başarılı","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
