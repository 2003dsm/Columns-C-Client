using System;

namespace Cliente
{
    partial class Form4
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
            this.EntrarSalas = new System.Windows.Forms.Button();
            this.EntrarRep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EntrarSalas
            // 
            this.EntrarSalas.Location = new System.Drawing.Point(12, 12);
            this.EntrarSalas.Name = "EntrarSalas";
            this.EntrarSalas.Size = new System.Drawing.Size(141, 77);
            this.EntrarSalas.TabIndex = 0;
            this.EntrarSalas.Text = "Salas";
            this.EntrarSalas.UseVisualStyleBackColor = true;
            this.EntrarSalas.Click += new System.EventHandler(this.salas);
            // 
            // EntrarRep
            // 
            this.EntrarRep.Location = new System.Drawing.Point(175, 12);
            this.EntrarRep.Name = "EntrarRep";
            this.EntrarRep.Size = new System.Drawing.Size(141, 77);
            this.EntrarRep.TabIndex = 1;
            this.EntrarRep.Text = "Repeticiones";
            this.EntrarRep.UseVisualStyleBackColor = true;
            this.EntrarRep.Click += new System.EventHandler(this.rep);
            // 
            // Form4
            // 
            this.ClientSize = new System.Drawing.Size(336, 104);
            this.Controls.Add(this.EntrarRep);
            this.Controls.Add(this.EntrarSalas);
            this.Name = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EntrarSalas;
        private System.Windows.Forms.Button EntrarRep;
    }
}