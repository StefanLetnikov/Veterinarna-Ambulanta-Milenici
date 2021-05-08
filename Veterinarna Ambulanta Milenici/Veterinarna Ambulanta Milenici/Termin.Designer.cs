
namespace Veterinarna_Ambulanta_Milenici
{
    partial class Termin
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
            this.tbTerminImePacient = new System.Windows.Forms.TextBox();
            this.btnVnesi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDatumICas = new System.Windows.Forms.DateTimePicker();
            this.rtbKratokOpis = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbTerminImePacient
            // 
            this.tbTerminImePacient.Location = new System.Drawing.Point(58, 75);
            this.tbTerminImePacient.Name = "tbTerminImePacient";
            this.tbTerminImePacient.Size = new System.Drawing.Size(219, 20);
            this.tbTerminImePacient.TabIndex = 0;
            // 
            // btnVnesi
            // 
            this.btnVnesi.Location = new System.Drawing.Point(61, 374);
            this.btnVnesi.Name = "btnVnesi";
            this.btnVnesi.Size = new System.Drawing.Size(75, 23);
            this.btnVnesi.TabIndex = 1;
            this.btnVnesi.Text = "Внеси";
            this.btnVnesi.UseVisualStyleBackColor = true;
            this.btnVnesi.Click += new System.EventHandler(this.btnVnesi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Име на пацинетот:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Датум и час на преглед:";
            // 
            // dtpDatumICas
            // 
            this.dtpDatumICas.Location = new System.Drawing.Point(61, 171);
            this.dtpDatumICas.Name = "dtpDatumICas";
            this.dtpDatumICas.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumICas.TabIndex = 4;
            // 
            // rtbKratokOpis
            // 
            this.rtbKratokOpis.Location = new System.Drawing.Point(58, 252);
            this.rtbKratokOpis.Name = "rtbKratokOpis";
            this.rtbKratokOpis.Size = new System.Drawing.Size(219, 96);
            this.rtbKratokOpis.TabIndex = 5;
            this.rtbKratokOpis.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Краток опис за преглед:";
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(202, 374);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(75, 23);
            this.btnOtkazi.TabIndex = 7;
            this.btnOtkazi.Text = "Откажи";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // Termin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 422);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbKratokOpis);
            this.Controls.Add(this.dtpDatumICas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVnesi);
            this.Controls.Add(this.tbTerminImePacient);
            this.Name = "Termin";
            this.Text = "Termin";
            this.Load += new System.EventHandler(this.Termin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTerminImePacient;
        private System.Windows.Forms.Button btnVnesi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDatumICas;
        private System.Windows.Forms.RichTextBox rtbKratokOpis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOtkazi;
    }
}