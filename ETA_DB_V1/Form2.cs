using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ETA_DB_V1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"data source=DESKTOP-PO14I2G\ETA; database=master; uid=sa; password=Viisoara2020#;");

        private void button3_Click(object sender, EventArgs e)
        {
            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string Nume = textBox1.Text;
            string Prenume = textBox2.Text;
            string Telefon = textBox6.Text;
            string NumarInmatriculare = textBox3.Text;
            string Data = textBox4.Text;
            string ExpirareITP = textBox5.Text;
            DateTime DataNouaITP;

            DataNouaITP = DataNoua(Data, ExpirareITP); // calculare data noua ITP

            DateTime DataITP = DateTime.ParseExact(Data, "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture); //converteste data din format String in format DateTime

            //definire denumire document GDPR scanat
            string GDPR;
            GDPR = Nume + "_" + Prenume + "_" + NumarInmatriculare + ".pdf";

            //comanda sql de adaugare date in BD
            SqlCommand cmd2 = new SqlCommand("insert into VehiculeITP (Nume,Prenume,Telefon,NumarInmatriculare,DataITP,ExpirareITP,DataNouaITP,GDPR)" + "values('" + Nume + "','" + Prenume + "','" + Telefon + "', '" + NumarInmatriculare + "', '" + DataITP + "','" + ExpirareITP + "','" + DataNouaITP + "','\\GDPR\\" + GDPR + "')", con);

            //preluarea locatiei aplicatiei
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

            //verifica daca exista fisierul in folderul aplicatiei
            int ok = 0;
            if (File.Exists(path + "\\GDPR\\ " + GDPR))
            {
                ok = 1;
            }
            if (ok == 0)
            {
                System.IO.File.Copy(openFileDialog1.FileName, path + "\\GDPR\\" + GDPR); //copiaza fisierul in folderul aplicatiei
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Incarcare Efectuata");
            }
            else
            {
                MessageBox.Show("Exista deja in baza de date");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); //iesire FORM
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

            DataNoua = Data.AddMonths(expirare); //adauga lunile aferente expirarii ITP si scade o zi

            return DataNoua;
        }
    }
}