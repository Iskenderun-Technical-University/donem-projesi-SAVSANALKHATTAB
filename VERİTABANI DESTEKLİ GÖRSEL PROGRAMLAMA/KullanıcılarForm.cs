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
    public partial class KullanıcılarForm : Form
    {
        public KullanıcılarForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            KullanıcılarForm uform = new KullanıcılarForm();
            uform.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sipariş öğeler = new Sipariş();
            öğeler.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }
    }
}
