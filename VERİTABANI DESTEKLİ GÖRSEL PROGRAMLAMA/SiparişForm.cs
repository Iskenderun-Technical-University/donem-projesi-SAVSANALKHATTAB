﻿using System;
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
    public partial class SiparişForm : Form
    {
        public SiparişForm()
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
           Öğeler öğeler  = new Öğeler();
            öğeler.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            KullanıcılarForm kullanıcı = new KullanıcılarForm();
            kullanıcı.Show();
            

        }

        private void SiparişForm_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
