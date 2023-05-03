using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VERİTABANI_DESTEKLİ_GÖRSEL_PROGRAMLAMA
{
    public partial class Sepetim : Form
    {
        public Sepetim()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            KullanıcılarForm kullanıcı = new KullanıcılarForm();
            kullanıcı.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SiparişForm sipariş = new SiparişForm();
            sipariş.Show();



        }
    }
}
