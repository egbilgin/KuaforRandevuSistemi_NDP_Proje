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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bahar_projeOdevi
{
    public partial class Form1 : Form
    {
        private DateTime startTime;
        public Form1()
        {
            InitializeComponent();
            label2.Text = DateTime.Now.ToShortDateString();
            timer1.Start();
            
            label4.Text = DateTime.Now.ToString("HH:mm:ss");

            startTime = DateTime.Now;
            // Timer'ı başlat
            timer2.Start();


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Hizmetler", 168);
            listView1.Items.Add(new ListViewItem("Saç Kesimi"));
            listView1.Items.Add(new ListViewItem("Saç Şekillendirme"));
            listView1.Items.Add(new ListViewItem("Saç Maskesi"));
            listView1.Items.Add(new ListViewItem("Komple Saç Boyama"));
            listView1.Items.Add(new ListViewItem("Dip Boyama"));
            listView1.Items.Add(new ListViewItem("Perma"));
            listView1.Items.Add(new ListViewItem("Röfle"));
            listView1.Items.Add(new ListViewItem("Balyaj"));
            listView1.Items.Add(new ListViewItem("Gölge"));
            listView1.Items.Add(new ListViewItem("Maşa"));
            listView1.Items.Add(new ListViewItem("Fön"));
            listView1.Items.Add(new ListViewItem("Ombre"));
            listView1.Items.Add(new ListViewItem("Brezilya Bakım"));
            listView1.Items.Add(new ListViewItem("Gelin Saçı"));
            listView1.Items.Add(new ListViewItem("Nişan Saçı"));
            listView1.Items.Add(new ListViewItem("Kına Saçı"));


            listView2.Columns.Add("Ücretler", 80);
            listView2.Items.Add(new ListViewItem("500"));
            listView2.Items.Add(new ListViewItem("200"));
            listView2.Items.Add(new ListViewItem("170"));
            listView2.Items.Add(new ListViewItem("650"));
            listView2.Items.Add(new ListViewItem("300"));
            listView2.Items.Add(new ListViewItem("190"));
            listView2.Items.Add(new ListViewItem("190"));
            listView2.Items.Add(new ListViewItem("400"));
            listView2.Items.Add(new ListViewItem("120"));
            listView2.Items.Add(new ListViewItem("150"));
            listView2.Items.Add(new ListViewItem("200"));
            listView2.Items.Add(new ListViewItem("500"));
            listView2.Items.Add(new ListViewItem("700"));
            listView2.Items.Add(new ListViewItem("2.000"));
            listView2.Items.Add(new ListViewItem("1.000"));
            listView2.Items.Add(new ListViewItem("700"));

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            this.Hide();

            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            label6.Text = string.Format("{0}.{1}", elapsedTime.Minutes, elapsedTime.Seconds);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
 