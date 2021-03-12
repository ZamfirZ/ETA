using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ETA_DB_V1
{
    public partial class PrintGDPR : Form
    {
        public PrintGDPR()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"data source=DESKTOP-PO14I2G\ETA; database=master; uid=sa; password=Viisoara2020#;");

        private void button1_Click(object sender, EventArgs e)
        {
            using (PrintDocument GDPR = new PrintDocument())
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    string NrInmatriculare = NumarInmatriculare.Text;
                    string GDPRpath = "";
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT GDPR FROM VehiculeITP WHERE NumarInmatriculare='" + NrInmatriculare + "'", con);
                    SqlDataReader GDPRsql = null;
                    GDPRsql = cmd.ExecuteReader();
                    while (GDPRsql.Read())
                    {
                        GDPRpath = path + GDPRsql["GDPR"].ToString();
                    }
                    con.Close();
                    GDPR.OriginAtMargins = true;
                    GDPR.PrintPage += GDPR_PrintPage;
                    GDPR.DocumentName = GDPRpath;
                    GDPR.Print();
                    GDPR.PrintPage -= GDPR_PrintPage;
                }
            }
        }
        public void GDPR_PrintPage(object sender, PrintPageEventArgs e)
        {
            string labelPath = ((PrintDocument)sender).DocumentName;
            e.Graphics.DrawImage(new Bitmap(labelPath), 0, 0);
        }
    }

}
