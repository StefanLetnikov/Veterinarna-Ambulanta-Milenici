
namespace Veterinarna_Ambulanta_Milenici
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainLogo = new System.Windows.Forms.PictureBox();
            this.mainTabControll = new System.Windows.Forms.TabControl();
            this.tabDoma = new System.Windows.Forms.TabPage();
            this.tabVnesiMilenik = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInfoTabela = new System.Windows.Forms.DataGridView();
            this.colImeSopstvenik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrezimeSopstvenik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKontakt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVidZivotno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRasaNaZivotno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImeNaZivotno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStarostNaZivotno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPolNaZivotno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDodadi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbZenskiPol = new System.Windows.Forms.CheckBox();
            this.cbMaskiPol = new System.Windows.Forms.CheckBox();
            this.tbImeZivotno = new System.Windows.Forms.TextBox();
            this.tbStarostZivotno = new System.Windows.Forms.TextBox();
            this.tbRasaZivotno = new System.Windows.Forms.TextBox();
            this.tbVidZivotno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbInfoSopstvenik = new System.Windows.Forms.GroupBox();
            this.mtbKontakt = new System.Windows.Forms.MaskedTextBox();
            this.tbEmailSopstvenik = new System.Windows.Forms.TextBox();
            this.tbPrezimeSopstvenik = new System.Windows.Forms.TextBox();
            this.tbImeSopstvenik = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainLogo)).BeginInit();
            this.mainTabControll.SuspendLayout();
            this.tabVnesiMilenik.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoTabela)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbInfoSopstvenik.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLogo
            // 
            this.mainLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainLogo.Image = ((System.Drawing.Image)(resources.GetObject("mainLogo.Image")));
            this.mainLogo.Location = new System.Drawing.Point(0, 0);
            this.mainLogo.Name = "mainLogo";
            this.mainLogo.Size = new System.Drawing.Size(1410, 205);
            this.mainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainLogo.TabIndex = 0;
            this.mainLogo.TabStop = false;
            // 
            // mainTabControll
            // 
            this.mainTabControll.Controls.Add(this.tabDoma);
            this.mainTabControll.Controls.Add(this.tabVnesiMilenik);
            this.mainTabControll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControll.Location = new System.Drawing.Point(0, 205);
            this.mainTabControll.Name = "mainTabControll";
            this.mainTabControll.SelectedIndex = 0;
            this.mainTabControll.Size = new System.Drawing.Size(1410, 475);
            this.mainTabControll.TabIndex = 1;
            // 
            // tabDoma
            // 
            this.tabDoma.Location = new System.Drawing.Point(4, 22);
            this.tabDoma.Name = "tabDoma";
            this.tabDoma.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoma.Size = new System.Drawing.Size(1402, 449);
            this.tabDoma.TabIndex = 0;
            this.tabDoma.Text = "Дома";
            this.tabDoma.UseVisualStyleBackColor = true;
            // 
            // tabVnesiMilenik
            // 
            this.tabVnesiMilenik.Controls.Add(this.groupBox2);
            this.tabVnesiMilenik.Controls.Add(this.btnDodadi);
            this.tabVnesiMilenik.Controls.Add(this.groupBox1);
            this.tabVnesiMilenik.Controls.Add(this.gbInfoSopstvenik);
            this.tabVnesiMilenik.Location = new System.Drawing.Point(4, 22);
            this.tabVnesiMilenik.Name = "tabVnesiMilenik";
            this.tabVnesiMilenik.Padding = new System.Windows.Forms.Padding(3);
            this.tabVnesiMilenik.Size = new System.Drawing.Size(1402, 449);
            this.tabVnesiMilenik.TabIndex = 1;
            this.tabVnesiMilenik.Text = "Внеси Миленик";
            this.tabVnesiMilenik.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.dgvInfoTabela);
            this.groupBox2.Location = new System.Drawing.Point(526, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(845, 368);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ново-додадени миленици";
            // 
            // dgvInfoTabela
            // 
            this.dgvInfoTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoTabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImeSopstvenik,
            this.colPrezimeSopstvenik,
            this.colKontakt,
            this.colVidZivotno,
            this.colRasaNaZivotno,
            this.colImeNaZivotno,
            this.colStarostNaZivotno,
            this.colPolNaZivotno});
            this.dgvInfoTabela.Location = new System.Drawing.Point(6, 19);
            this.dgvInfoTabela.Name = "dgvInfoTabela";
            this.dgvInfoTabela.Size = new System.Drawing.Size(833, 330);
            this.dgvInfoTabela.TabIndex = 0;
            // 
            // colImeSopstvenik
            // 
            this.colImeSopstvenik.HeaderText = "Име Сопственик";
            this.colImeSopstvenik.Name = "colImeSopstvenik";
            // 
            // colPrezimeSopstvenik
            // 
            this.colPrezimeSopstvenik.HeaderText = "Презиме Сопственик";
            this.colPrezimeSopstvenik.Name = "colPrezimeSopstvenik";
            // 
            // colKontakt
            // 
            this.colKontakt.HeaderText = "Број за контакт";
            this.colKontakt.Name = "colKontakt";
            // 
            // colVidZivotno
            // 
            this.colVidZivotno.HeaderText = "Вид на животно";
            this.colVidZivotno.Name = "colVidZivotno";
            // 
            // colRasaNaZivotno
            // 
            this.colRasaNaZivotno.HeaderText = "Раса на животно";
            this.colRasaNaZivotno.Name = "colRasaNaZivotno";
            // 
            // colImeNaZivotno
            // 
            this.colImeNaZivotno.HeaderText = "Име на животно";
            this.colImeNaZivotno.Name = "colImeNaZivotno";
            // 
            // colStarostNaZivotno
            // 
            this.colStarostNaZivotno.HeaderText = "Старост на животно";
            this.colStarostNaZivotno.Name = "colStarostNaZivotno";
            // 
            // colPolNaZivotno
            // 
            this.colPolNaZivotno.HeaderText = "Пол на животно";
            this.colPolNaZivotno.Name = "colPolNaZivotno";
            // 
            // btnDodadi
            // 
            this.btnDodadi.Location = new System.Drawing.Point(158, 399);
            this.btnDodadi.Name = "btnDodadi";
            this.btnDodadi.Size = new System.Drawing.Size(159, 33);
            this.btnDodadi.TabIndex = 3;
            this.btnDodadi.Text = "Додади";
            this.btnDodadi.UseVisualStyleBackColor = true;
            this.btnDodadi.Click += new System.EventHandler(this.btnDodadi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.cbZenskiPol);
            this.groupBox1.Controls.Add(this.cbMaskiPol);
            this.groupBox1.Controls.Add(this.tbImeZivotno);
            this.groupBox1.Controls.Add(this.tbStarostZivotno);
            this.groupBox1.Controls.Add(this.tbRasaZivotno);
            this.groupBox1.Controls.Add(this.tbVidZivotno);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(256, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 360);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информации за Миленик";
            // 
            // cbZenskiPol
            // 
            this.cbZenskiPol.AutoSize = true;
            this.cbZenskiPol.Location = new System.Drawing.Point(170, 324);
            this.cbZenskiPol.Name = "cbZenskiPol";
            this.cbZenskiPol.Size = new System.Drawing.Size(37, 17);
            this.cbZenskiPol.TabIndex = 17;
            this.cbZenskiPol.Text = "Ж";
            this.cbZenskiPol.UseVisualStyleBackColor = true;
            // 
            // cbMaskiPol
            // 
            this.cbMaskiPol.AutoSize = true;
            this.cbMaskiPol.Location = new System.Drawing.Point(129, 324);
            this.cbMaskiPol.Name = "cbMaskiPol";
            this.cbMaskiPol.Size = new System.Drawing.Size(35, 17);
            this.cbMaskiPol.TabIndex = 16;
            this.cbMaskiPol.Text = "М";
            this.cbMaskiPol.UseVisualStyleBackColor = true;
            // 
            // tbImeZivotno
            // 
            this.tbImeZivotno.Location = new System.Drawing.Point(26, 278);
            this.tbImeZivotno.Name = "tbImeZivotno";
            this.tbImeZivotno.Size = new System.Drawing.Size(159, 20);
            this.tbImeZivotno.TabIndex = 15;
            // 
            // tbStarostZivotno
            // 
            this.tbStarostZivotno.Location = new System.Drawing.Point(26, 211);
            this.tbStarostZivotno.Name = "tbStarostZivotno";
            this.tbStarostZivotno.Size = new System.Drawing.Size(159, 20);
            this.tbStarostZivotno.TabIndex = 14;
            // 
            // tbRasaZivotno
            // 
            this.tbRasaZivotno.Location = new System.Drawing.Point(26, 139);
            this.tbRasaZivotno.Name = "tbRasaZivotno";
            this.tbRasaZivotno.Size = new System.Drawing.Size(159, 20);
            this.tbRasaZivotno.TabIndex = 13;
            // 
            // tbVidZivotno
            // 
            this.tbVidZivotno.Location = new System.Drawing.Point(26, 62);
            this.tbVidZivotno.Name = "tbVidZivotno";
            this.tbVidZivotno.Size = new System.Drawing.Size(159, 20);
            this.tbVidZivotno.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Пол на животно";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Име на животно";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Старост на животно";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Раса на животно";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Вид на животно";
            // 
            // gbInfoSopstvenik
            // 
            this.gbInfoSopstvenik.AutoSize = true;
            this.gbInfoSopstvenik.Controls.Add(this.mtbKontakt);
            this.gbInfoSopstvenik.Controls.Add(this.tbEmailSopstvenik);
            this.gbInfoSopstvenik.Controls.Add(this.tbPrezimeSopstvenik);
            this.gbInfoSopstvenik.Controls.Add(this.tbImeSopstvenik);
            this.gbInfoSopstvenik.Controls.Add(this.label4);
            this.gbInfoSopstvenik.Controls.Add(this.label3);
            this.gbInfoSopstvenik.Controls.Add(this.label2);
            this.gbInfoSopstvenik.Controls.Add(this.label1);
            this.gbInfoSopstvenik.Location = new System.Drawing.Point(17, 18);
            this.gbInfoSopstvenik.Name = "gbInfoSopstvenik";
            this.gbInfoSopstvenik.Size = new System.Drawing.Size(200, 360);
            this.gbInfoSopstvenik.TabIndex = 1;
            this.gbInfoSopstvenik.TabStop = false;
            this.gbInfoSopstvenik.Text = "Информации за Сопственик";
            // 
            // mtbKontakt
            // 
            this.mtbKontakt.Location = new System.Drawing.Point(25, 284);
            this.mtbKontakt.Mask = "(999) 000-000";
            this.mtbKontakt.Name = "mtbKontakt";
            this.mtbKontakt.Size = new System.Drawing.Size(114, 20);
            this.mtbKontakt.TabIndex = 6;
            this.mtbKontakt.Text = "07";
            // 
            // tbEmailSopstvenik
            // 
            this.tbEmailSopstvenik.Location = new System.Drawing.Point(25, 211);
            this.tbEmailSopstvenik.Name = "tbEmailSopstvenik";
            this.tbEmailSopstvenik.Size = new System.Drawing.Size(144, 20);
            this.tbEmailSopstvenik.TabIndex = 5;
            // 
            // tbPrezimeSopstvenik
            // 
            this.tbPrezimeSopstvenik.Location = new System.Drawing.Point(25, 139);
            this.tbPrezimeSopstvenik.Name = "tbPrezimeSopstvenik";
            this.tbPrezimeSopstvenik.Size = new System.Drawing.Size(144, 20);
            this.tbPrezimeSopstvenik.TabIndex = 4;
            // 
            // tbImeSopstvenik
            // 
            this.tbImeSopstvenik.Location = new System.Drawing.Point(25, 62);
            this.tbImeSopstvenik.Name = "tbImeSopstvenik";
            this.tbImeSopstvenik.Size = new System.Drawing.Size(144, 20);
            this.tbImeSopstvenik.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Број за контакт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "E-mail адреса на сопственикот";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Презиме на сопственик";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Име на сопственикот";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 680);
            this.Controls.Add(this.mainTabControll);
            this.Controls.Add(this.mainLogo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainLogo)).EndInit();
            this.mainTabControll.ResumeLayout(false);
            this.tabVnesiMilenik.ResumeLayout(false);
            this.tabVnesiMilenik.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoTabela)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbInfoSopstvenik.ResumeLayout(false);
            this.gbInfoSopstvenik.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainLogo;
        private System.Windows.Forms.TabControl mainTabControll;
        private System.Windows.Forms.TabPage tabDoma;
        private System.Windows.Forms.TabPage tabVnesiMilenik;
        private System.Windows.Forms.GroupBox gbInfoSopstvenik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvInfoTabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImeSopstvenik;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrezimeSopstvenik;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKontakt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVidZivotno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRasaNaZivotno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImeNaZivotno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStarostNaZivotno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPolNaZivotno;
        private System.Windows.Forms.Button btnDodadi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbZenskiPol;
        private System.Windows.Forms.CheckBox cbMaskiPol;
        private System.Windows.Forms.TextBox tbImeZivotno;
        private System.Windows.Forms.TextBox tbStarostZivotno;
        private System.Windows.Forms.TextBox tbRasaZivotno;
        private System.Windows.Forms.TextBox tbVidZivotno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mtbKontakt;
        private System.Windows.Forms.TextBox tbEmailSopstvenik;
        private System.Windows.Forms.TextBox tbPrezimeSopstvenik;
        private System.Windows.Forms.TextBox tbImeSopstvenik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

