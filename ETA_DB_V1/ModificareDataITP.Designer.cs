
namespace ETA_DB_V1
{
    partial class ModificareDataITP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificareDataITP));
            this.label1 = new System.Windows.Forms.Label();
            this.NumarInmatriculare = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DataInmatriculare = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.expirareITP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nrtelefon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // NumarInmatriculare
            // 
            resources.ApplyResources(this.NumarInmatriculare, "NumarInmatriculare");
            this.NumarInmatriculare.Name = "NumarInmatriculare";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataInmatriculare
            // 
            resources.ApplyResources(this.DataInmatriculare, "DataInmatriculare");
            this.DataInmatriculare.Name = "DataInmatriculare";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // expirareITP
            // 
            resources.ApplyResources(this.expirareITP, "expirareITP");
            this.expirareITP.Name = "expirareITP";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // nrtelefon
            // 
            resources.ApplyResources(this.nrtelefon, "nrtelefon");
            this.nrtelefon.Name = "nrtelefon";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ModificareDataITP
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nrtelefon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expirareITP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataInmatriculare);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NumarInmatriculare);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModificareDataITP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumarInmatriculare;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox DataInmatriculare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox expirareITP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nrtelefon;
        private System.Windows.Forms.Label label6;
    }
}