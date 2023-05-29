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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\OneDrive\المستندات\KafeShopdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        

        private void label7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           /* SiparişForm uorder = new SiparişForm();
            uorder.Show();
            this.Hide(); 
           */
           if ( UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Kullanıcı adı veya şifreyi giriniz");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from KullanıcılarTbl where KullanıcıAd = '" + UnameTb.Text + "' and KullanıcıŞif = '" + PasswordTb.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SiparişForm uorder = new SiparişForm();
                    uorder.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya kullanıcı şifresi yanlış girdiniz!!!");
                }
                con.Close();
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestSiparişForm guest = new GuestSiparişForm();
            guest.Show();
            
           
           
            
            
        }
    }
}
