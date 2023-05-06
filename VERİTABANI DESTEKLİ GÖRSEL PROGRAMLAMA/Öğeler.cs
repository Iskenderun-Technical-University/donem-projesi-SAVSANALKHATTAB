using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VERİTABANI_DESTEKLİ_GÖRSEL_PROGRAMLAMA
{
    public partial class Öğeler : Form
    {
        public Öğeler()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\OneDrive\المستندات\KafeShopdb.mdf;Integrated Security=True;Connect Timeout=30");
        void populate()
        {
            con.Open();
            String query = " select * from ÖğeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ÖğeGV.DataSource = ds.Tables[0];
            con.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (ÖğeAdTb.Text == "" || ÖğenoTb.Text == "" || MikCb.Text == "")
            {
                MessageBox.Show("Tüm verileri doldur");
            }
            else
            {
                con.Open();
                String query = "insert into ÖğeTbl values('"+ ÖğeAdTb.Text +"',"+ ÖğenoTb.Text +",'" + MenCb.SelectedItem.ToString() + "', "+MikCb.Text+")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Öğe başarılı bir şekilde eklendi");
                con.Close();
                populate();
            }

        }

        private void Öğeler_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
