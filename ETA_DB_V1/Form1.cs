using System;
using System.Windows.Forms;

namespace ETA_DB_V1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 AdaugareAutovehicul = new Form2();
            AdaugareAutovehicul.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 VizualizareExpirareITP = new Form3();
            VizualizareExpirareITP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 CalculareNoxe = new Form4();
            CalculareNoxe.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 SMSITPziCurenta = new Form5();
            SMSITPziCurenta.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
