using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ETA_DB_V1
{
    public partial class ModificareDataITP : Form
    {
        public ModificareDataITP()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"data source=DESKTOP-PO14I2G\ETA; database=master; uid=sa; password=Viisoara2020#;");

        private void button1_Click(object sender, EventArgs e)
        {
            string NrInmatriculare = NumarInmatriculare.Text;
            string Data = DataInmatriculare.Text;
            string expirare = expirareITP.Text;

            DateTime DataNouaITP;
            DataNouaITP = DataNoua(Data, expirare); // calculare data noua ITP

            DateTime DataITP = DateTime.ParseExact(Data, "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture); //converteste data din format String in format DateTime


            string Nume1 = "";
            string Prenume1 = "";
            string NumarInmatriculare1 = "";
            string GDPR1 = "";
            string NumarTelefon = "";


            //comanda sql de adaugare date in BD
            SqlCommand cmd = new SqlCommand("select * from VehiculeITP WHERE NumarInmatriculare='" + NrInmatriculare + "'", con);

            con.Open();
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                Nume1 = (read["Nume"].ToString());
                Prenume1 = (read["Prenume"].ToString());
                NumarInmatriculare1 = (read["NumarInmatriculare"].ToString());
                GDPR1 = (read["GDPR"].ToString());
                if (!string.IsNullOrWhiteSpace(nrtelefon.Text))
                {
                    NumarTelefon = nrtelefon.Text;
                }
                else
                {
                    NumarTelefon = (read["Telefon"].ToString());
                }
            }

            con.Close();

            con.Open();

            SqlCommand cmd3 = new SqlCommand("insert into VehiculeITP (Nume,Prenume,Telefon,NumarInmatriculare,DataITP,ExpirareITP,DataNouaITP,GDPR)" + "values('" + Nume1 + "','" + Prenume1 + "','" + NumarTelefon + "', '" + NumarInmatriculare1 + "', '" + DataITP + "','" + expirare + "','" + DataNouaITP + "','" + GDPR1 + "')", con);
            SqlCommand cmd4 = new SqlCommand("DELETE FROM VehiculeITP WHERE NumarInmatriculare='" + NrInmatriculare + "';", con);


            cmd4.ExecuteNonQuery(); //sterge linia din tabel care trebuie modificata


            con.Close();

            con.Open();

            cmd3.ExecuteNonQuery();
            MessageBox.Show("Modificare Efectuata");

            con.Close();


            this.Close();
        }

        //converteste data din format String in format DateTime si calculeaza data de la urmatorul ITP
        private DateTime DataNoua(string DataITP, string ExpirareITP)
        {
            int expirare;

            //convert string to int
            expirare = Int32.Parse(ExpirareITP);

            //convert string to datetime
            DateTime Data = DateTime.ParseExact(DataITP, "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture);

            DateTime DataNoua;

            DataNoua = Data.AddMonths(expirare + 1).AddDays(-1);

            return DataNoua;
        }
    }
}
