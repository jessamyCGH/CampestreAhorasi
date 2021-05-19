
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnTenis = new System.Windows.Forms.Button();
            this.btnKGolf = new System.Windows.Forms.Button();
            this.btnConcierto = new System.Windows.Forms.Button();
            this.btnClausura = new System.Windows.Forms.Button();
            this.btnCerveza = new System.Windows.Forms.Button();
            this.btnInaguracion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtini = new System.Windows.Forms.DateTimePicker();
            this.dtf = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.cv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 64);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generar Reporte Alimentos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTenis
            // 
            this.btnTenis.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnTenis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTenis.Location = new System.Drawing.Point(0, 459);
            this.btnTenis.Name = "btnTenis";
            this.btnTenis.Size = new System.Drawing.Size(226, 63);
            this.btnTenis.TabIndex = 0;
            this.btnTenis.Text = "Generar Reporte de Tennis";
            this.btnTenis.UseVisualStyleBackColor = false;
            this.btnTenis.Click += new System.EventHandler(this.btnTenis_Click);
            // 
            // btnKGolf
            // 
            this.btnKGolf.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnKGolf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKGolf.Location = new System.Drawing.Point(0, 396);
            this.btnKGolf.Name = "btnKGolf";
            this.btnKGolf.Size = new System.Drawing.Size(226, 59);
            this.btnKGolf.TabIndex = 0;
            this.btnKGolf.Text = "Generar Reporte de Golf";
            this.btnKGolf.UseVisualStyleBackColor = false;
            this.btnKGolf.Click += new System.EventHandler(this.btnKGolf_Click);
            // 
            // btnConcierto
            // 
            this.btnConcierto.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnConcierto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConcierto.Location = new System.Drawing.Point(0, 332);
            this.btnConcierto.Name = "btnConcierto";
            this.btnConcierto.Size = new System.Drawing.Size(226, 60);
            this.btnConcierto.TabIndex = 0;
            this.btnConcierto.Text = "Generar Reporte de Conciertos";
            this.btnConcierto.UseVisualStyleBackColor = false;
            this.btnConcierto.Click += new System.EventHandler(this.btnConcierto_Click);
            // 
            // btnClausura
            // 
            this.btnClausura.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnClausura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClausura.Location = new System.Drawing.Point(-1, 264);
            this.btnClausura.Name = "btnClausura";
            this.btnClausura.Size = new System.Drawing.Size(226, 63);
            this.btnClausura.TabIndex = 0;
            this.btnClausura.Text = "Generar Reporte de Clausura";
            this.btnClausura.UseVisualStyleBackColor = false;
            this.btnClausura.Click += new System.EventHandler(this.btnClausura_Click);
            // 
            // btnCerveza
            // 
            this.btnCerveza.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCerveza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerveza.Location = new System.Drawing.Point(-1, 200);
            this.btnCerveza.Name = "btnCerveza";
            this.btnCerveza.Size = new System.Drawing.Size(227, 60);
            this.btnCerveza.TabIndex = 0;
            this.btnCerveza.Text = "Generar Reporte Cerveza";
            this.btnCerveza.UseVisualStyleBackColor = false;
            this.btnCerveza.Click += new System.EventHandler(this.btnCerveza_Click);
            // 
            // btnInaguracion
            // 
            this.btnInaguracion.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnInaguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInaguracion.Location = new System.Drawing.Point(0, 137);
            this.btnInaguracion.Name = "btnInaguracion";
            this.btnInaguracion.Size = new System.Drawing.Size(226, 60);
            this.btnInaguracion.TabIndex = 5;
            this.btnInaguracion.Text = "Generar Reporte Inaguracion";
            this.btnInaguracion.UseVisualStyleBackColor = false;
            this.btnInaguracion.Click += new System.EventHandler(this.btnInaguracion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(53)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.lblHasta);
            this.panel1.Controls.Add(this.dtf);
            this.panel1.Controls.Add(this.lblDesde);
            this.panel1.Controls.Add(this.btnCerveza);
            this.panel1.Controls.Add(this.dtini);
            this.panel1.Controls.Add(this.btnInaguracion);
            this.panel1.Controls.Add(this.btnConcierto);
            this.panel1.Controls.Add(this.btnClausura);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnKGolf);
            this.panel1.Controls.Add(this.btnTenis);
            this.panel1.Location = new System.Drawing.Point(-1, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 726);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDesde.Location = new System.Drawing.Point(13, 15);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(58, 16);
            this.lblDesde.TabIndex = 7;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.Visible = false;
            // 
            // dtini
            // 
            this.dtini.Location = new System.Drawing.Point(16, 33);
            this.dtini.Name = "dtini";
            this.dtini.Size = new System.Drawing.Size(200, 20);
            this.dtini.TabIndex = 6;
            this.dtini.Visible = false;
            // 
            // dtf
            // 
            this.dtf.Location = new System.Drawing.Point(16, 96);
            this.dtf.Name = "dtf";
            this.dtf.Size = new System.Drawing.Size(200, 20);
            this.dtf.TabIndex = 8;
            this.dtf.Visible = false;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHasta.Location = new System.Drawing.Point(13, 77);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(53, 16);
            this.lblHasta.TabIndex = 9;
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.Visible = false;
            // 
            // cv
            // 
            this.cv.ActiveViewIndex = -1;
            this.cv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cv.Cursor = System.Windows.Forms.Cursors.Default;
            this.cv.Location = new System.Drawing.Point(228, 64);
            this.cv.Name = "cv";
            this.cv.Size = new System.Drawing.Size(934, 726);
            this.cv.TabIndex = 8;
            this.cv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 798);
            this.Controls.Add(this.cv);
            this.Controls.Add(this.panel1);
            this.Name = "Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalReports.CRAlimentos CRAlimentos1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTenis;
        private System.Windows.Forms.Button btnKGolf;
        private System.Windows.Forms.Button btnConcierto;
        private System.Windows.Forms.Button btnClausura;
        private System.Windows.Forms.Button btnCerveza;
        private System.Windows.Forms.Button btnInaguracion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtf;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtini;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cv;
    }
}