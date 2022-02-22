using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace matematikselformuller
{
    public partial class Form1 : Form
    {
        //dosyadan verileri okuyup geri döndürecek metot
        public Double[,] veriOku(String dizin)
        {
            Double[,] dizi = new Double[6, 3];
            StreamReader sr = new StreamReader(dizin);
            for (int i = 0; i < 6; i++)
            {
                String satir = sr.ReadLine();
                String[] d = satir.Split('	');
                
                dizi[i, 0] = Double.Parse(d[0]);
                dizi[i, 1] = Double.Parse(d[1]);
                dizi[i, 2] = Double.Parse(d[2]);
            }
            sr.Close();
            listboxEkle(dizi);
            return dizi;
        }

        //Harmonik ortalama alalım
        public Double harmonikHesapla(Double a,Double b,Double c)
        {
            Double sonuc;
            sonuc = 3 / (1 / a + 1 / b + 1 / c);
            return sonuc;
        }
        //verileri listbox a ekle
        public void listboxEkle(Double [,]dizi)
        {
            for (int i = 0; i < 6; i++)
            {
                listBox1.Items.Add(dizi[i, 0] + "-" + dizi[i, 1] + "-"+ dizi[i, 2]);
            }
        }
        //hesaplama işlemini yönet
        public void hesapla(String dizin)
        {
            Double[,] dizi = veriOku(dizin);
            for (int i = 0; i < 6; i++)
            {
                Double sonuc = harmonikHesapla(dizi[i, 0], dizi[i, 1], dizi[i, 2]);
                listBox2.Items.Add(sonuc);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            hesapla(openFileDialog1.FileName);
        }


    }
}
