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

        private void SiparişGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======MyCafe======", new Font("Abeezee", 20, FontStyle.Bold), Brushes.Red, new Point(200, 40));
            e.Graphics.DrawString("======Sipariş Özeti======", new Font("Abeezee", 20, FontStyle.Bold), Brushes.Red, new Point(208,70));
            e.Graphics.DrawString("Sipariş Numarası:" + SiparişGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Abeezee", 15, FontStyle.Regular), Brushes.Black, new Point(120, 135));
            e.Graphics.DrawString("Sipariş Tarihi:" + SiparişGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Abeezee", 15, FontStyle.Regular), Brushes.Black, new Point(120, 170));
            e.Graphics.DrawString("Satıcı Adı:" + SiparişGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Abeezee", 15, FontStyle.Regular), Brushes.Black, new Point(120, 205));
            e.Graphics.DrawString("Miktar:" + SiparişGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Abeezee", 15, FontStyle.Regular), Brushes.Black, new Point(120, 240));
            e.Graphics.DrawString("======Sipariş Özeti======", new Font("Abeezee", 20, FontStyle.Bold), Brushes.Red, new Point(208, 340));
        }

    }
}
