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
    public partial class Sipariş : Form
    {
        public Sipariş()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
           Sipariş öğeler  = new Sipariş();
            öğeler.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            KullanıcılarForm kullanıcı = new KullanıcılarForm();
            kullanıcı.Show();
            

        }
    }
}
