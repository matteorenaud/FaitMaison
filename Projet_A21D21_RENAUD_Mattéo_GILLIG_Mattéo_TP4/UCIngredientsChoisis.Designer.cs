namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    partial class UCIngredientsChoisis
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
            this.grpIngredientsChoisis = new System.Windows.Forms.GroupBox();
            this.lblRienChoisis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grpIngredientsChoisis
            // 
            this.grpIngredientsChoisis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpIngredientsChoisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpIngredientsChoisis.Location = new System.Drawing.Point(5, 3);
            this.grpIngredientsChoisis.Name = "grpIngredientsChoisis";
            this.grpIngredientsChoisis.Size = new System.Drawing.Size(530, 140);
            this.grpIngredientsChoisis.TabIndex = 0;
            this.grpIngredientsChoisis.TabStop = false;
            this.grpIngredientsChoisis.Text = "Les ingrédients que avez choisis :";
            // 
            // lblRienChoisis
            // 
            this.lblRienChoisis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRienChoisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRienChoisis.ForeColor = System.Drawing.Color.Red;
            this.lblRienChoisis.Location = new System.Drawing.Point(109, 50);
            this.lblRienChoisis.Name = "lblRienChoisis";
            this.lblRienChoisis.Size = new System.Drawing.Size(313, 58);
            this.lblRienChoisis.TabIndex = 0;
            this.lblRienChoisis.Text = "Choissisez 3 ingrédients ou passez à l\'étape suivante";
            this.lblRienChoisis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCIngredientsChoisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblRienChoisis);
            this.Controls.Add(this.grpIngredientsChoisis);
            this.Name = "UCIngredientsChoisis";
            this.Size = new System.Drawing.Size(542, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpIngredientsChoisis;
        private System.Windows.Forms.Label lblRienChoisis;
    }
}
