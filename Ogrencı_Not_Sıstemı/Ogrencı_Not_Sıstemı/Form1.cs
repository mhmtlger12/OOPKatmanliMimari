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
using EntityLayer;
using BusinessLogıcLayer;
using FacadeLayer;

namespace Ogrencı_Not_Sıstemı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void OgrListesi()
        {
            List<EntityOgrenci> ogrliste = BLLOgrencı.Lıstele();
            dataGridView1.DataSource = ogrliste;
            this.Text = "Ogrenci listesi başarılı";
        }
        void KulupListesi()
        {
            List<EntitKulup> Kuluplist = BLLKULUP.Lıstele();
            CMBKULUP.DisplayMember = "KULUPAD";
            CMBKULUP.ValueMember = "KULUPID";
            CMBKULUP.DataSource = Kuluplist;
        }
        void notlistesi()
        {
            List<EntityNotlar> EntNot = BLLNotlar.LISTELE();
            dataGridView1.DataSource = EntNot;
            this.Text = "Başarılı";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OgrListesi();
            KulupListesi();
        }

        private void BTNKAYDET_Click(object sender, EventArgs e)
        {
            EntityOgrenci ENT = new EntityOgrenci();
            ENT.AD = TXTAD.Text;
            ENT.SOYAD = TXTSOYAD.Text;
            ENT.FOTOGRAF = TXTFOTO.Text;
            ENT.KULUPID = Convert.ToInt32(CMBKULUP.SelectedValue);
            BLLOgrencı.ekle(ENT);
            MessageBox.Show("Öğrenci Kaydı Yapıldı");
            OgrListesi();
        }

        private void Btnguncelle_Click(object sender, EventArgs e)
        {
            EntityOgrenci ENT = new EntityOgrenci();
            ENT.AD = TXTAD.Text;
            ENT.SOYAD = TXTSOYAD.Text;
            ENT.FOTOGRAF = TXTFOTO.Text;
            ENT.KULUPID = Convert.ToInt32(CMBKULUP.SelectedValue);
            ENT.ID = Convert.ToInt32(TXTID.Text);
            BLLOgrencı.Guncelle(ENT);
            MessageBox.Show("Başarılı");
            OgrListesi();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            OgrListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text=="Ogrenci listesi başarılı")
            {

                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                TXTID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                TXTAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                TXTSOYAD.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                TXTFOTO.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            }
            if (this.Text == "Başarılı")
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                TXTOGRID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                TXTAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                TXTSOYAD.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                SINAV1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                SINAV2.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                SINAV3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                PROJE.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
                ORT.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

                DURUM.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();

            }


        }

        private void BTNNOTLISTELE_Click(object sender, EventArgs e)
        {
            notlistesi();
        }

        private void BTNNOTKAYDET_Click(object sender, EventArgs e)
        {
            
            EntityNotlar ENT = new EntityNotlar();
            ENT.OGRID = Convert.ToInt32(TXTOGRID.Text);
            ENT.SINAV1 = Convert.ToInt32(SINAV1.Text);
            ENT.SINAV2 = Convert.ToInt32(SINAV2.Text);
            ENT.SINAV3 = Convert.ToInt32(SINAV3.Text);
            ENT.PROJE = Convert.ToInt32(PROJE.Text);
            ENT.ORTALAMA = Convert.ToInt32(ORT.Text);
            ENT.DURUM = DURUM.Text;
            BLLNotlar.Guncelle(ENT);


        }
    }
}
