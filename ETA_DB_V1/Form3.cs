using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ETA_DB_V1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"data source=DESKTOP-PO14I2G\ETA; database=master; uid=sa; password=Viisoara2020#;");

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.VehiculeITP' table. You can move, or remove it, as needed.
            this.vehiculeITPTableAdapter.Fill(this.masterDataSet.VehiculeITP);
            this.dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StergereIntrare StergereInt = new StergereIntrare();
            StergereInt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintGDPR printare = new PrintGDPR();
            printare.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificareDataITP data = new ModificareDataITP();
            data.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
