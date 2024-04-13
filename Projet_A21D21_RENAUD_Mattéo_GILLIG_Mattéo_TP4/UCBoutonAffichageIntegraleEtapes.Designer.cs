namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    partial class UCBoutonAffichageIntegraleEtapes
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
            this.btnAffichageIntergral = new System.Windows.Forms.Button();
            this.btnAffichageEtapes = new System.Windows.Forms.Button();
            this.grpConsultationRecette = new System.Windows.Forms.GroupBox();
            this.grpConsultationRecette.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAffichageIntergral
            // 
            this.btnAffichageIntergral.BackColor = System.Drawing.Color.Coral;
            this.btnAffichageIntergral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAffichageIntergral.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnAffichageIntergral.FlatAppearance.BorderSize = 10;
            this.btnAffichageIntergral.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnAffichageIntergral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAffichageIntergral.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAffichageIntergral.Font = new System.Drawing.Font("OpenSymbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAffichageIntergral.Location = new System.Drawing.Point(6, 39);
            this.btnAffichageIntergral.Name = "btnAffichageIntergral";
            this.btnAffichageIntergral.Size = new System.Drawing.Size(130, 50);
            this.btnAffichageIntergral.TabIndex = 0;
            this.btnAffichageIntergral.Text = "Intégral";
            this.btnAffichageIntergral.UseVisualStyleBackColor = false;
            this.btnAffichageIntergral.Click += new System.EventHandler(this.btnAffichageIntergral_Click);
            // 
            // btnAffichageEtapes
            // 
            this.btnAffichageEtapes.BackColor = System.Drawing.Color.Coral;
            this.btnAffichageEtapes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAffichageEtapes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAffichageEtapes.Font = new System.Drawing.Font("OpenSymbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAffichageEtapes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAffichageEtapes.Location = new System.Drawing.Point(142, 39);
            this.btnAffichageEtapes.Name = "btnAffichageEtapes";
            this.btnAffichageEtapes.Size = new System.Drawing.Size(130, 50);
            this.btnAffichageEtapes.TabIndex = 1;
            this.btnAffichageEtapes.Text = "Par étape";
            this.btnAffichageEtapes.UseVisualStyleBackColor = false;
            this.btnAffichageEtapes.Click += new System.EventHandler(this.btnAffichageIntergral_Click);
            // 
            // grpConsultationRecette
            // 
            this.grpConsultationRecette.Controls.Add(this.btnAffichageEtapes);
            this.grpConsultationRecette.Controls.Add(this.btnAffichageIntergral);
            this.grpConsultationRecette.Font = new System.Drawing.Font("OpenSymbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConsultationRecette.Location = new System.Drawing.Point(3, 3);
            this.grpConsultationRecette.Name = "grpConsultationRecette";
            this.grpConsultationRecette.Size = new System.Drawing.Size(278, 103);
            this.grpConsultationRecette.TabIndex = 2;
            this.grpConsultationRecette.TabStop = false;
            this.grpConsultationRecette.Text = "Consulter la recette :";
            // 
            // UCBoutonAffichageIntegraleEtapes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpConsultationRecette);
            this.Name = "UCBoutonAffichageIntegraleEtapes";
            this.Size = new System.Drawing.Size(287, 109);
            this.grpConsultationRecette.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAffichageIntergral;
        private System.Windows.Forms.Button btnAffichageEtapes;
        private System.Windows.Forms.GroupBox grpConsultationRecette;
    }
}
