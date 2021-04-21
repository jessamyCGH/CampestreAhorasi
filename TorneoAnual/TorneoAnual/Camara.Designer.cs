
namespace TorneoAnual
{
    partial class Camara
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
            this.picFoto2 = new System.Windows.Forms.PictureBox();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto2)).BeginInit();
            this.SuspendLayout();
            // 
            // picFoto2
            // 
            this.picFoto2.Location = new System.Drawing.Point(12, 69);
            this.picFoto2.Name = "picFoto2";
            this.picFoto2.Size = new System.Drawing.Size(407, 283);
            this.picFoto2.TabIndex = 0;
            this.picFoto2.TabStop = false;
            // 
            // btnCapturar
            // 
            this.btnCapturar.Location = new System.Drawing.Point(150, 382);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(75, 23);
            this.btnCapturar.TabIndex = 1;
            this.btnCapturar.Text = "Capturar";
            this.btnCapturar.UseVisualStyleBackColor = true;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Camara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 431);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCapturar);
            this.Controls.Add(this.picFoto2);
            this.Name = "Camara";
            this.Text = "Camara";
            ((System.ComponentModel.ISupportInitialize)(this.picFoto2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picFoto2;
        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.Button button1;
    }
}