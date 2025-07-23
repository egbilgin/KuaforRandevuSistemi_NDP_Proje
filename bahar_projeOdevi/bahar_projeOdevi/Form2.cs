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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bahar_projeOdevi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DosyayiOku();
        }
        private void DosyayiOku()
        {
            try
            {
                // elemanlar.txt dosyasını oku
                string[] isimler = File.ReadAllLines("elemanlar.txt");

                // Her bir ismi comboBox2'ye ekle
                foreach (string isim in isimler)
                {
                    comboBox2.Items.Add(isim);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Dosya bulunamadı!");
            }
        }

        private void anaMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        // İnsan sınıfı
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
        public class Musteri:Insan
        {
            
                // Müşteri özellikleri
                public string İletişimBilgileri { get; set; }

                // Müşteri kurucu methodu
                public Musteri(string ad, string soyad, string iletişimBilgileri) : base(ad, soyad)
                {
                    İletişimBilgileri = iletişimBilgileri;
                }
            

            public override string ToString()
            {
                return Ad + " " + Soyad + " " + İletişimBilgileri;
            }

            public void WriteToFile(string filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{Ad},{Soyad},{İletişimBilgileri}");
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string ad = textBox1.Text.Trim();
            string soyad = textBox2.Text.Trim();
            string iletisimBilgileri = maskedTextBox2.Text.Trim();

            Musteri yeniMusteri = new Musteri(ad, soyad, iletisimBilgileri);

            Randevular.Items.Add(yeniMusteri + " ~ " + comboBox1.SelectedItem + " ~ " + comboBox2.SelectedItem + " ~ " + dateTimePicker1.Value.ToString("dd/MM/yyyy HH:mm:ss") + " ~ " + maskedTextBox1.Text);

            yeniMusteri.WriteToFile("musteri.txt");

            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();


            try
            {
                using (StreamWriter writer = new StreamWriter("randevular.txt"))
                {
                    foreach (var item in Randevular.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
                MessageBox.Show("Randevular başarıyla dosyaya kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                // randevular.txt dosyasını oku
                using (StreamReader reader = new StreamReader("randevular.txt"))
                {
                    string line;
                    // Dosya sonuna kadar her satırı oku ve listbox'a ekle
                    while ((line = reader.ReadLine()) != null)
                    {
                        Randevular.Items.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

