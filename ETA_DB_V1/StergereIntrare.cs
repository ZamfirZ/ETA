using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ETA_DB_V1
{
    public partial class StergereIntrare : Form
    {
        public StergereIntrare()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"data source=DESKTOP-PO14I2G\ETA; database=master; uid=sa; password=Viisoara2020#;");
        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

        private void button1_Click(object sender, EventArgs e)
        {
            string NrInmatriculare = NumarInmatriculare.Text;
            string GDPR = "";

            SqlCommand cmd = new SqlCommand("DELETE FROM VehiculeITP WHERE NumarInmatriculare='" + NrInmatriculare + "'", con);
            SqlCommand cmd2 = new SqlCommand("SELECT GDPR FROM VehiculeITP WHERE NumarInmatriculare='" + NrInmatriculare + "'", con);

            con.Open();
            SqlDataReader GDPRsql = null;
            GDPRsql = cmd2.ExecuteReader();
            while (GDPRsql.Read())
            {
                GDPR = path + GDPRsql["GDPR"].ToString();
            }
            con.Close();

            con.Open();
            cmd.ExecuteNonQuery(); // delete sql entry

            con.Close();

            if (File.Exists(GDPR)) // delete file
            {
                File.Delete(GDPR);
            }
            this.Close();

            MessageBox.Show("Stergere Efectuata");

        }
    }
}
