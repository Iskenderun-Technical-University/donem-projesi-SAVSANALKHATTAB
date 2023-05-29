using Microsoft.VisualBasic.Logging;
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
        void filterbymenü()
        {
            con.Open();
            String query = " select * from ÖğeTbl where ÖğeTür = '"+ Menücb.SelectedItem.ToString() +"' ";
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
        int num = 0;
        int miktar, toplam;
       string öğe, menü;

        private void button1_Click(object sender, EventArgs e)
        {
            if( miktarTb.Text == "")
            {
                MessageBox.Show("Öğe miktarı ne kadardır??");
            }
            else if( flag == 0)
            {
                MessageBox.Show("Sipariş edilecek ürün seçiniz..");
            }
            else
            {
                num = num + 1;
                toplam = miktar * Convert.ToInt32(miktarTb.Text);
                table.Rows.Add(num, öğe, menü, miktar, toplam);
                SiparişGV.DataSource = table;
                flag = 0;
            }
            sum = sum + toplam;
            LabelAmnt.Text = "TR " + sum;
        }

        DataTable table = new DataTable();
        int flag = 0;
        int sum = 0;

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filterbymenü();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void SiparişForm_Load(object sender, EventArgs e)
        {
            populate();
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("Öğe", typeof(string));
            table.Columns.Add("Menü", typeof(string));
            table.Columns.Add("Miktar", typeof(int));
            table.Columns.Add("Toplam", typeof(int));
            SiparişGV.DataSource = table;
            Datelbl.Text = DateTime.Today.Date.ToString();
        }

        private void ÖğeGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            öğe = ÖğeGV.SelectedRows[0].Cells[0].Value.ToString();
            menü = ÖğeGV.SelectedRows[0].Cells[2].Value.ToString();
            miktar = Convert.ToInt32( ÖğeGV.SelectedRows[0].Cells[3].Value.ToString());
            flag = 1;
        }

        
    }
}
