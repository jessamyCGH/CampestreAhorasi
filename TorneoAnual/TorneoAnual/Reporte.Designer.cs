
namespace TorneoAnual
{
    partial class Reporte
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
            this.CRAlimentos1 = new TorneoAnual.CrystalReports.CRAlimentos();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cvAlimentos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dttenisf = new System.Windows.Forms.DateTimePicker();
            this.dttenisi = new System.Windows.Forms.DateTimePicker();
            this.cvTenis = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnTenis = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtf = new System.Windows.Forms.DateTimePicker();
            this.dtini = new System.Windows.Forms.DateTimePicker();
            this.cvGolf = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnKGolf = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cvConcierto = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnConcierto = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cvClausura = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnClausura = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cvCerveza = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnCerveza = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cvInaguracion = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnInaguracion = new System.Windows.Forms.Button();
            this.btnGolf = new System.Windows.Forms.TabControl();
            this.tabPage7.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.btnGolf.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.label1);
            this.tabPage7.Controls.Add(this.cvAlimentos);
            this.tabPage7.Controls.Add(this.button1);
            this.tabPage7.Controls.Add(this.dtFinal);
            this.tabPage7.Controls.Add(this.dtInicio);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1023, 576);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Alimentos";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desde:";
            // 
            // cvAlimentos
            // 
            this.cvAlimentos.ActiveViewIndex = -1;
            this.cvAlimentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvAlimentos.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvAlimentos.Location = new System.Drawing.Point(-4, 85);
            this.cvAlimentos.Name = "cvAlimentos";
            this.cvAlimentos.Size = new System.Drawing.Size(1024, 491);
            this.cvAlimentos.TabIndex = 3;
            this.cvAlimentos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generar Reporte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtFinal
            // 
            this.dtFinal.Location = new System.Drawing.Point(368, 32);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(200, 20);
            this.dtFinal.TabIndex = 1;
            // 
            // dtInicio
            // 
            this.dtInicio.Location = new System.Drawing.Point(97, 32);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(200, 20);
            this.dtInicio.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Controls.Add(this.dttenisf);
            this.tabPage6.Controls.Add(this.dttenisi);
            this.tabPage6.Controls.Add(this.cvTenis);
            this.tabPage6.Controls.Add(this.btnTenis);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1023, 576);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "KitTenis";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hasta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Desde:";
            // 
            // dttenisf
            // 
            this.dttenisf.Location = new System.Drawing.Point(359, 15);
            this.dttenisf.Name = "dttenisf";
            this.dttenisf.Size = new System.Drawing.Size(200, 20);
            this.dttenisf.TabIndex = 7;
            // 
            // dttenisi
            // 
            this.dttenisi.Location = new System.Drawing.Point(88, 15);
            this.dttenisi.Name = "dttenisi";
            this.dttenisi.Size = new System.Drawing.Size(200, 20);
            this.dttenisi.TabIndex = 6;
            // 
            // cvTenis
            // 
            this.cvTenis.ActiveViewIndex = -1;
            this.cvTenis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvTenis.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvTenis.Location = new System.Drawing.Point(3, 55);
            this.cvTenis.Name = "cvTenis";
            this.cvTenis.Size = new System.Drawing.Size(1017, 518);
            this.cvTenis.TabIndex = 1;
            this.cvTenis.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnTenis
            // 
            this.btnTenis.Location = new System.Drawing.Point(760, 6);
            this.btnTenis.Name = "btnTenis";
            this.btnTenis.Size = new System.Drawing.Size(189, 43);
            this.btnTenis.TabIndex = 0;
            this.btnTenis.Text = "Generar Reporte de Tennis";
            this.btnTenis.UseVisualStyleBackColor = true;
            this.btnTenis.Click += new System.EventHandler(this.btnTenis_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.dtf);
            this.tabPage5.Controls.Add(this.dtini);
            this.tabPage5.Controls.Add(this.cvGolf);
            this.tabPage5.Controls.Add(this.btnKGolf);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1023, 576);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Kit Golf";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Desde:";
            // 
            // dtf
            // 
            this.dtf.Location = new System.Drawing.Point(346, 35);
            this.dtf.Name = "dtf";
            this.dtf.Size = new System.Drawing.Size(200, 20);
            this.dtf.TabIndex = 7;
            // 
            // dtini
            // 
            this.dtini.Location = new System.Drawing.Point(75, 35);
            this.dtini.Name = "dtini";
            this.dtini.Size = new System.Drawing.Size(200, 20);
            this.dtini.TabIndex = 6;
            // 
            // cvGolf
            // 
            this.cvGolf.ActiveViewIndex = -1;
            this.cvGolf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvGolf.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvGolf.Location = new System.Drawing.Point(6, 78);
            this.cvGolf.Name = "cvGolf";
            this.cvGolf.Size = new System.Drawing.Size(1014, 498);
            this.cvGolf.TabIndex = 1;
            this.cvGolf.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnKGolf
            // 
            this.btnKGolf.Location = new System.Drawing.Point(612, 32);
            this.btnKGolf.Name = "btnKGolf";
            this.btnKGolf.Size = new System.Drawing.Size(75, 23);
            this.btnKGolf.TabIndex = 0;
            this.btnKGolf.Text = "button1";
            this.btnKGolf.UseVisualStyleBackColor = true;
            this.btnKGolf.Click += new System.EventHandler(this.btnKGolf_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cvConcierto);
            this.tabPage4.Controls.Add(this.btnConcierto);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1023, 576);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Concierto";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cvConcierto
            // 
            this.cvConcierto.ActiveViewIndex = -1;
            this.cvConcierto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvConcierto.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvConcierto.Location = new System.Drawing.Point(6, 89);
            this.cvConcierto.Name = "cvConcierto";
            this.cvConcierto.Size = new System.Drawing.Size(1011, 484);
            this.cvConcierto.TabIndex = 1;
            this.cvConcierto.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnConcierto
            // 
            this.btnConcierto.Location = new System.Drawing.Point(599, 16);
            this.btnConcierto.Name = "btnConcierto";
            this.btnConcierto.Size = new System.Drawing.Size(216, 43);
            this.btnConcierto.TabIndex = 0;
            this.btnConcierto.Text = "Generar Reporte de Conciertos";
            this.btnConcierto.UseVisualStyleBackColor = true;
            this.btnConcierto.Click += new System.EventHandler(this.btnConcierto_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cvClausura);
            this.tabPage3.Controls.Add(this.btnClausura);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1023, 576);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Clausura";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cvClausura
            // 
            this.cvClausura.ActiveViewIndex = -1;
            this.cvClausura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvClausura.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvClausura.Location = new System.Drawing.Point(3, 70);
            this.cvClausura.Name = "cvClausura";
            this.cvClausura.Size = new System.Drawing.Size(1017, 503);
            this.cvClausura.TabIndex = 1;
            this.cvClausura.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnClausura
            // 
            this.btnClausura.Location = new System.Drawing.Point(811, 3);
            this.btnClausura.Name = "btnClausura";
            this.btnClausura.Size = new System.Drawing.Size(209, 61);
            this.btnClausura.TabIndex = 0;
            this.btnClausura.Text = "Generar Reporte de Clausura";
            this.btnClausura.UseVisualStyleBackColor = true;
            this.btnClausura.Click += new System.EventHandler(this.btnClausura_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cvCerveza);
            this.tabPage2.Controls.Add(this.btnCerveza);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1023, 576);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cerveza";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cvCerveza
            // 
            this.cvCerveza.ActiveViewIndex = -1;
            this.cvCerveza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvCerveza.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvCerveza.Location = new System.Drawing.Point(3, 64);
            this.cvCerveza.Name = "cvCerveza";
            this.cvCerveza.Size = new System.Drawing.Size(1020, 509);
            this.cvCerveza.TabIndex = 1;
            this.cvCerveza.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnCerveza
            // 
            this.btnCerveza.Location = new System.Drawing.Point(775, 6);
            this.btnCerveza.Name = "btnCerveza";
            this.btnCerveza.Size = new System.Drawing.Size(201, 52);
            this.btnCerveza.TabIndex = 0;
            this.btnCerveza.Text = "Generar Reporte Cerveza";
            this.btnCerveza.UseVisualStyleBackColor = true;
            this.btnCerveza.Click += new System.EventHandler(this.btnCerveza_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cvInaguracion);
            this.tabPage1.Controls.Add(this.btnInaguracion);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1023, 576);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inaguracion";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cvInaguracion
            // 
            this.cvInaguracion.ActiveViewIndex = -1;
            this.cvInaguracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvInaguracion.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvInaguracion.Location = new System.Drawing.Point(6, 100);
            this.cvInaguracion.Name = "cvInaguracion";
            this.cvInaguracion.Size = new System.Drawing.Size(1014, 470);
            this.cvInaguracion.TabIndex = 5;
            this.cvInaguracion.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnInaguracion
            // 
            this.btnInaguracion.Location = new System.Drawing.Point(752, 22);
            this.btnInaguracion.Name = "btnInaguracion";
            this.btnInaguracion.Size = new System.Drawing.Size(224, 51);
            this.btnInaguracion.TabIndex = 5;
            this.btnInaguracion.Text = "Generar Reporte Inaguracion";
            this.btnInaguracion.UseVisualStyleBackColor = true;
            this.btnInaguracion.Click += new System.EventHandler(this.btnInaguracion_Click);
            // 
            // btnGolf
            // 
            this.btnGolf.Controls.Add(this.tabPage1);
            this.btnGolf.Controls.Add(this.tabPage2);
            this.btnGolf.Controls.Add(this.tabPage3);
            this.btnGolf.Controls.Add(this.tabPage4);
            this.btnGolf.Controls.Add(this.tabPage5);
            this.btnGolf.Controls.Add(this.tabPage6);
            this.btnGolf.Controls.Add(this.tabPage7);
            this.btnGolf.Location = new System.Drawing.Point(2, 65);
            this.btnGolf.Name = "btnGolf";
            this.btnGolf.SelectedIndex = 0;
            this.btnGolf.Size = new System.Drawing.Size(1031, 602);
            this.btnGolf.TabIndex = 6;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 668);
            this.Controls.Add(this.btnGolf);
            this.Name = "Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.btnGolf.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalReports.CRAlimentos CRAlimentos1;
        private System.Windows.Forms.TabPage tabPage7;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvAlimentos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.TabPage tabPage6;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvTenis;
        private System.Windows.Forms.Button btnTenis;
        private System.Windows.Forms.TabPage tabPage5;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvGolf;
        private System.Windows.Forms.Button btnKGolf;
        private System.Windows.Forms.TabPage tabPage4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvConcierto;
        private System.Windows.Forms.Button btnConcierto;
        private System.Windows.Forms.TabPage tabPage3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvClausura;
        private System.Windows.Forms.Button btnClausura;
        private System.Windows.Forms.TabPage tabPage2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvCerveza;
        private System.Windows.Forms.Button btnCerveza;
        private System.Windows.Forms.TabPage tabPage1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvInaguracion;
        private System.Windows.Forms.Button btnInaguracion;
        private System.Windows.Forms.TabControl btnGolf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dttenisf;
        private System.Windows.Forms.DateTimePicker dttenisi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtf;
        private System.Windows.Forms.DateTimePicker dtini;
    }
}