namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    partial class frmResultatRecettes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResultatRecettes));
            this.pnlResultatRecherche = new System.Windows.Forms.Panel();
            this.lblResultatRecettes = new System.Windows.Forms.Label();
            this.btnRevenirEnArriere = new System.Windows.Forms.Button();
            this.pnlResultatRecherche.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlResultatRecherche
            // 
            this.pnlResultatRecherche.AutoScroll = true;
            this.pnlResultatRecherche.BackColor = System.Drawing.Color.Transparent;
            this.pnlResultatRecherche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResultatRecherche.Controls.Add(this.lblResultatRecettes);
            this.pnlResultatRecherche.Location = new System.Drawing.Point(13, 13);
            this.pnlResultatRecherche.Name = "pnlResultatRecherche";
            this.pnlResultatRecherche.Size = new System.Drawing.Size(1059, 594);
            this.pnlResultatRecherche.TabIndex = 0;
            // 
            // lblResultatRecettes
            // 
            this.lblResultatRecettes.AutoSize = true;
            this.lblResultatRecettes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.lblResultatRecettes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblResultatRecettes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultatRecettes.Location = new System.Drawing.Point(160, 9);
            this.lblResultatRecettes.Name = "lblResultatRecettes";
            this.lblResultatRecettes.Size = new System.Drawing.Size(538, 20);
            this.lblResultatRecettes.TabIndex = 0;
            this.lblResultatRecettes.Text = "Un certains nombre de recettes correspondent à votre recherche :";
            // 
            // btnRevenirEnArriere
            // 
            this.btnRevenirEnArriere.BackColor = System.Drawing.Color.Coral;
            this.btnRevenirEnArriere.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevenirEnArriere.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRevenirEnArriere.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevenirEnArriere.Location = new System.Drawing.Point(13, 620);
            this.btnRevenirEnArriere.Name = "btnRevenirEnArriere";
            this.btnRevenirEnArriere.Size = new System.Drawing.Size(225, 55);
            this.btnRevenirEnArriere.TabIndex = 1;
            this.btnRevenirEnArriere.Text = "Revenir aux filtres";
            this.btnRevenirEnArriere.UseVisualStyleBackColor = false;
            this.btnRevenirEnArriere.Click += new System.EventHandler(this.btnRevenirEnArriere_Click);
            // 
            // frmResultatRecettes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 686);
            this.Controls.Add(this.btnRevenirEnArriere);
            this.Controls.Add(this.pnlResultatRecherche);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmResultatRecettes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Les recettes !";
            this.Load += new System.EventHandler(this.frmResultatRecettes_Load);
            this.pnlResultatRecherche.ResumeLayout(false);
            this.pnlResultatRecherche.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlResultatRecherche;
        private System.Windows.Forms.Button btnRevenirEnArriere;
        private System.Windows.Forms.Label lblResultatRecettes;
    }
}