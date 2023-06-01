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

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\OneDrive\المستندات\KafeShopdb.mdf;Integrated Security=True;Connect Timeout=30");
        void populate()
        {
            con.Open();
            String query = " select * from KullanıcılarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KullanıcıGV.DataSource = ds.Tables[0];
            con.Close();
        }
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
            populate();

        }

        private void KullanıcılarForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void KullanıcıGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            kullanıcıadTb.Text = KullanıcıGV.SelectedRows[0].Cells[0].Value.ToString();
            kullanıcıtelTb.Text = KullanıcıGV.SelectedRows[0].Cells[1].Value.ToString();
            kullanıcışifTb.Text = KullanıcıGV.SelectedRows[0].Cells[2].Value.ToString();


        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(kullanıcıtelTb.Text == "")
            {
                MessageBox.Show("Silinecek kullanıcıyı seçiniz");
            }
            else
            {
                con.Open();
                string query = "Delete from KullanıcılarTbl where KullanıcıTel = '" + kullanıcıtelTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı başarılı bir şekilde silindi");
                con.Close();
                populate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(kullanıcıtelTb.Text == "" || kullanıcışifTb.Text == "" || kullanıcıadTb.Text == "")
            {
                MessageBox.Show("Tüm boşlukları doldurunuz");
            }
            else
            {
                con.Open();
                string query = "update KullanıcılarTbl set KullanıcıAd = '" + kullanıcıadTb.Text + "' , KullanıcıŞif = '" + kullanıcışifTb.Text + "' where KullanıcıTel ='"+kullanıcıtelTb.Text+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı başarılı bir şekilde güncellendi");
                con.Close();
                populate();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
