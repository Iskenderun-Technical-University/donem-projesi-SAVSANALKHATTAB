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
    public partial class SiparişGörüntüle: Form
    {
        public SiparişGörüntüle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\OneDrive\المستندات\KafeShopdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void populate()
        {
            con.Open();
            String query = " select * from SiparişTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SiparişGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void SiparişGörüntüle_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
