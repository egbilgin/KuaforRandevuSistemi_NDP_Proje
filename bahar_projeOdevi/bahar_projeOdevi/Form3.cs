/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**			         BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				          PROGRAMLAMAYA GİRİŞİ DERSİ
**	
**				ÖDEV NUMARASI…...: Bahar Proje Ödevi
**				ÖĞRENCİ ADI......: Esma Gülsüm BİLGİN
**				ÖĞRENCİ NUMARASI.: B231210027
**				DERS GRUBU…………: B 
****************************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace bahar_projeOdevi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            DosyayiOku();


        }

        private void anaMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        public class Insan
        {
            // İnsan özellikleri
            public string Ad { get; set; }
            public string Soyad { get; set; }

            // Kurucu method
            public Insan(string ad, string soyad)
            {
                Ad = ad;
                Soyad = soyad;
            }
        }

        public class Personeller:Insan
        {
            public string TCKN { get; set; }

            // Personel kurucu methodu
            public Personeller(string ad, string soyad, string tckn) : base(ad, soyad)
            {
                TCKN = tckn;
            }

            // ToString metodu, Kişi nesnesini nasıl göstereceğimizi belirler
            public override string ToString()
            {
                return $"{Ad} {Soyad}";
            }

            public void WriteToFile(string filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{Ad} {Soyad}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string ad = textBox1.Text.Trim();
            string soyad = textBox2.Text.Trim();
            string tckn = maskedTextBox1.Text.Trim();

            // Yeni bir Kişi nesnesi oluştur
            Personeller yeniKişi = new Personeller(ad, soyad, tckn);

            // Oluşturulan kişiyi ListBox'a ekle
            listBox1.Items.Add(yeniKişi);

            yeniKişi.WriteToFile("elemanlar.txt");

            // TextBox'ları temizle
            textBox1.Clear();
            textBox2.Clear();
        }
        private void DosyayiOku()
        {
            try
            {
                // elemanlar.txt dosyasını oku
                string[] isimler = File.ReadAllLines("elemanlar.txt");

                // Her bir ismi listBox1'e ekle
                foreach (string isim in isimler)
                {
                    listBox1.Items.Add(isim);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Dosya bulunamadı!");
            }

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


