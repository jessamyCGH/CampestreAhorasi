
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
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtTerminacion = new System.Windows.Forms.DateTimePicker();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport1 = new TorneoAnual.CRInaguracion();
            this.btnInaguracion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtInicio
            // 
            this.dtInicio.Location = new System.Drawing.Point(53, 94);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(200, 20);
            this.dtInicio.TabIndex = 0;
            // 
            // dtTerminacion
            // 
            this.dtTerminacion.Location = new System.Drawing.Point(301, 94);
            this.dtTerminacion.Name = "dtTerminacion";
            this.dtTerminacion.Size = new System.Drawing.Size(200, 20);
            this.dtTerminacion.TabIndex = 1;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 159);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(974, 455);
            this.crystalReportViewer1.TabIndex = 2;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnInaguracion
            // 
            this.btnInaguracion.Location = new System.Drawing.Point(517, 106);
            this.btnInaguracion.Name = "btnInaguracion";
            this.btnInaguracion.Size = new System.Drawing.Size(75, 23);
            this.btnInaguracion.TabIndex = 3;
            this.btnInaguracion.Text = "Inaguracion";
            this.btnInaguracion.UseVisualStyleBackColor = true;
            this.btnInaguracion.Click += new System.EventHandler(this.btnInaguracion_Click);
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 615);
            this.Controls.Add(this.btnInaguracion);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.dtTerminacion);
            this.Controls.Add(this.dtInicio);
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.DateTimePicker dtTerminacion;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CRInaguracion CrystalReport1;
        private System.Windows.Forms.Button btnInaguracion;
    }
}