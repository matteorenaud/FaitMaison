namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    partial class UCListeFamille
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
            this.grpListeFamilles = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpListeFamilles
            // 
            this.grpListeFamilles.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpListeFamilles.Location = new System.Drawing.Point(4, 4);
            this.grpListeFamilles.Name = "grpListeFamilles";
            this.grpListeFamilles.Size = new System.Drawing.Size(1040, 230);
            this.grpListeFamilles.TabIndex = 0;
            this.grpListeFamilles.TabStop = false;
            this.grpListeFamilles.Text = "Liste des familles :";
            // 
            // UCListeFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.grpListeFamilles);
            this.Name = "UCListeFamille";
            this.Size = new System.Drawing.Size(1050, 235);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpListeFamilles;
    }
}
