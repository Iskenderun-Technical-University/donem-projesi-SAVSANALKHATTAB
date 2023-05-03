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

namespace VERİTABANI_DESTEKLİ_GÖRSEL_PROGRAMLAMA
{
    public partial class KullanıcılarForm : Form
    {
        public KullanıcılarForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\pc\Desktop\veritabanı projesi\donem-projesi-SAVSANALKHATTAB\VERİTABANI DESTEKLİ GÖRSEL PROGRAMLAMA\Database.mdf"";Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SiparişForm sipariş = new SiparişForm();
            sipariş.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SiparişForm öğeler = new SiparişForm();
            öğeler.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "insert into KullanıcılarTbl values('" + kullanıcıadTb.Text + "', '" + kullanıcıtelTb.Text + "', '" + kullanıcışifTb.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı başarılı bir şekilde eklendi");
            con.Close();


        }
    }
}
