namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    partial class UCAfficheIngredients
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlIngredients = new System.Windows.Forms.Panel();
            this.lblChoisirFamille = new System.Windows.Forms.Label();
            this.errNbIngredients = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errNbIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(212, -3);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(500, 31);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Famille d\'ingrédients :";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlIngredients
            // 
            this.pnlIngredients.AutoScroll = true;
            this.pnlIngredients.AutoSize = true;
            this.pnlIngredients.BackColor = System.Drawing.Color.White;
            this.pnlIngredients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIngredients.Controls.Add(this.lblChoisirFamille);
            this.pnlIngredients.Location = new System.Drawing.Point(10, 31);
            this.pnlIngredients.Name = "pnlIngredients";
            this.pnlIngredients.Size = new System.Drawing.Size(1010, 202);
            this.pnlIngredients.TabIndex = 1;
            // 
            // lblChoisirFamille
            // 
            this.lblChoisirFamille.AutoSize = true;
            this.lblChoisirFamille.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblChoisirFamille.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoisirFamille.ForeColor = System.Drawing.Color.Red;
            this.lblChoisirFamille.Location = new System.Drawing.Point(167, 76);
            this.lblChoisirFamille.Name = "lblChoisirFamille";
            this.lblChoisirFamille.Size = new System.Drawing.Size(706, 25);
            this.lblChoisirFamille.TabIndex = 0;
            this.lblChoisirFamille.Text = "Choisissez une famille d\'ingrédients ou passez à l\'étape suivante.";
            // 
            // errNbIngredients
            // 
            this.errNbIngredients.ContainerControl = this;
            // 
            // UCAfficheIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pnlIngredients);
            this.Controls.Add(this.lblTitre);
            this.Name = "UCAfficheIngredients";
            this.Size = new System.Drawing.Size(1025, 240);
            this.pnlIngredients.ResumeLayout(false);
            this.pnlIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errNbIngredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlIngredients;
        private System.Windows.Forms.Label lblChoisirFamille;
        private System.Windows.Forms.ErrorProvider errNbIngredients;
    }
}
