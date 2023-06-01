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
using BunifuAnimatorNS;

namespace VERİTABANI_DESTEKLİ_GÖRSEL_PROGRAMLAMA
{
    public partial class GuestSiparişForm : Form
    {
        public GuestSiparişForm()
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
            String query = " select * from ÖğeTbl where ÖğeTür = '" + Menücb.SelectedItem.ToString() + "' ";
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

        private void GuestSiparişForm_Load(object sender, EventArgs e)
        {
            populate();
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("Öğe", typeof(string));
            table.Columns.Add("Menü", typeof(string));
            table.Columns.Add("Miktar", typeof(int));
            table.Columns.Add("Toplam", typeof(int));
            SiparişGV.DataSource = table;
            Datelbl.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }
        int num = 0;
        int miktar, toplam;
        string öğe, menü;

        DataTable table = new DataTable();
        int flag = 0;
        int sum = 0;

        private void ÖğeGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            öğe = ÖğeGV.SelectedRows[0].Cells[0].Value.ToString();
            menü = ÖğeGV.SelectedRows[0].Cells[2].Value.ToString();
            miktar = Convert.ToInt32(ÖğeGV.SelectedRows[0].Cells[3].Value.ToString());
            flag = 1;
        }

        private void Datelbl_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "insert into SiparişTbl values(" + siparişNoTb.Text + ", '" + Datelbl.Text + "', '" + satıcıAdTb.Text + "', "+ OrderAmt.Text +" )";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sipariş başarılı bir şekilde eklendi");
            con.Close();
            
        }

        private void OrderAmt_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (miktarTb.Text == "")
            {
                MessageBox.Show("Öğe miktarı ne kadardır??");
            }
            else if (flag == 0)
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
            OrderAmt.Text = "" + sum;
        }

        private void Menücb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterbymenü();
        }
    }
}
