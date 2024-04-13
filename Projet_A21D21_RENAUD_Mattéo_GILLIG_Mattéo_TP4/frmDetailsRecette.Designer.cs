namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    partial class frmDetailsRecette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailsRecette));
            this.pnlIntegral = new System.Windows.Forms.Panel();
            this.ucRecapRecette = new Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCRecapRecette();
            this.btnChangeEnEtapes = new System.Windows.Forms.Button();
            this.pnlEtapeParEtape = new System.Windows.Forms.Panel();
            this.btnEtapeAfficheIngredients = new System.Windows.Forms.Button();
            this.ucEtapeIngredients = new Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCEtapeIngredients();
            this.ucEtape = new Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCEtape();
            this.lblInvisible = new System.Windows.Forms.Label();
            this.btnDernier = new System.Windows.Forms.Button();
            this.btnPrecedent = new System.Windows.Forms.Button();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.btnPremier = new System.Windows.Forms.Button();
            this.btnChangeEnIntegral = new System.Windows.Forms.Button();
            this.btnRevenirRecettes = new System.Windows.Forms.Button();
            this.btnNoterRecette = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnRetourAccueil = new System.Windows.Forms.Button();
            this.pnlIntegral.SuspendLayout();
            this.pnlEtapeParEtape.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlIntegral
            // 
            this.pnlIntegral.BackColor = System.Drawing.Color.Transparent;
            this.pnlIntegral.Controls.Add(this.ucRecapRecette);
            this.pnlIntegral.Location = new System.Drawing.Point(10, 10);
            this.pnlIntegral.Name = "pnlIntegral";
            this.pnlIntegral.Size = new System.Drawing.Size(1062, 600);
            this.pnlIntegral.TabIndex = 0;
            // 
            // ucRecapRecette
            // 
            this.ucRecapRecette.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.ucRecapRecette.Location = new System.Drawing.Point(30, 3);
            this.ucRecapRecette.Name = "ucRecapRecette";
            this.ucRecapRecette.Size = new System.Drawing.Size(1000, 200);
            this.ucRecapRecette.TabIndex = 0;
            this.ucRecapRecette.TexteBudget = "Budget : ";
            this.ucRecapRecette.TexteDescription = "Description";
            this.ucRecapRecette.TexteNombrePersonne = "Nombre de personne : ";
            this.ucRecapRecette.TexteNomRecette = "Nom_Recette";
            this.ucRecapRecette.TexteTempsCuisson = "Temps de cuisson : ";
            // 
            // btnChangeEnEtapes
            // 
            this.btnChangeEnEtapes.BackColor = System.Drawing.Color.Coral;
            this.btnChangeEnEtapes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeEnEtapes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeEnEtapes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeEnEtapes.Location = new System.Drawing.Point(918, 616);
            this.btnChangeEnEtapes.Name = "btnChangeEnEtapes";
            this.btnChangeEnEtapes.Size = new System.Drawing.Size(144, 59);
            this.btnChangeEnEtapes.TabIndex = 1;
            this.btnChangeEnEtapes.Text = "En étapes par étapes";
            this.btnChangeEnEtapes.UseVisualStyleBackColor = false;
            this.btnChangeEnEtapes.Click += new System.EventHandler(this.btnChangeEnEtapes_Click);
            // 
            // pnlEtapeParEtape
            // 
            this.pnlEtapeParEtape.BackColor = System.Drawing.Color.Transparent;
            this.pnlEtapeParEtape.Controls.Add(this.btnEtapeAfficheIngredients);
            this.pnlEtapeParEtape.Controls.Add(this.ucEtapeIngredients);
            this.pnlEtapeParEtape.Controls.Add(this.ucEtape);
            this.pnlEtapeParEtape.Controls.Add(this.lblInvisible);
            this.pnlEtapeParEtape.Controls.Add(this.btnDernier);
            this.pnlEtapeParEtape.Controls.Add(this.btnPrecedent);
            this.pnlEtapeParEtape.Controls.Add(this.btnSuivant);
            this.pnlEtapeParEtape.Controls.Add(this.btnPremier);
            this.pnlEtapeParEtape.Location = new System.Drawing.Point(10, 5);
            this.pnlEtapeParEtape.Name = "pnlEtapeParEtape";
            this.pnlEtapeParEtape.Size = new System.Drawing.Size(1062, 600);
            this.pnlEtapeParEtape.TabIndex = 1;
            this.pnlEtapeParEtape.Visible = false;
            // 
            // btnEtapeAfficheIngredients
            // 
            this.btnEtapeAfficheIngredients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnEtapeAfficheIngredients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEtapeAfficheIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEtapeAfficheIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtapeAfficheIngredients.ForeColor = System.Drawing.Color.Black;
            this.btnEtapeAfficheIngredients.Location = new System.Drawing.Point(77, 462);
            this.btnEtapeAfficheIngredients.Name = "btnEtapeAfficheIngredients";
            this.btnEtapeAfficheIngredients.Size = new System.Drawing.Size(153, 57);
            this.btnEtapeAfficheIngredients.TabIndex = 11;
            this.btnEtapeAfficheIngredients.Text = "Ingrédients";
            this.btnEtapeAfficheIngredients.UseVisualStyleBackColor = false;
            this.btnEtapeAfficheIngredients.Click += new System.EventHandler(this.btnEtapeAfficheIngredients_Click);
            // 
            // ucEtapeIngredients
            // 
            this.ucEtapeIngredients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.ucEtapeIngredients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucEtapeIngredients.Location = new System.Drawing.Point(165, 21);
            this.ucEtapeIngredients.Name = "ucEtapeIngredients";
            this.ucEtapeIngredients.Size = new System.Drawing.Size(750, 403);
            this.ucEtapeIngredients.TabIndex = 10;
            // 
            // ucEtape
            // 
            this.ucEtape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.ucEtape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucEtape.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucEtape.Location = new System.Drawing.Point(140, 29);
            this.ucEtape.Name = "ucEtape";
            this.ucEtape.Size = new System.Drawing.Size(800, 396);
            this.ucEtape.TabIndex = 9;
            // 
            // lblInvisible
            // 
            this.lblInvisible.AutoSize = true;
            this.lblInvisible.Location = new System.Drawing.Point(600, 412);
            this.lblInvisible.Name = "lblInvisible";
            this.lblInvisible.Size = new System.Drawing.Size(80, 13);
            this.lblInvisible.TabIndex = 7;
            this.lblInvisible.Text = "chemin_recette";
            // 
            // btnDernier
            // 
            this.btnDernier.BackColor = System.Drawing.Color.White;
            this.btnDernier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDernier.BackgroundImage")));
            this.btnDernier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDernier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDernier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDernier.Location = new System.Drawing.Point(713, 443);
            this.btnDernier.Name = "btnDernier";
            this.btnDernier.Size = new System.Drawing.Size(100, 100);
            this.btnDernier.TabIndex = 3;
            this.btnDernier.UseVisualStyleBackColor = false;
            this.btnDernier.Click += new System.EventHandler(this.btnDernier_Click);
            // 
            // btnPrecedent
            // 
            this.btnPrecedent.BackColor = System.Drawing.Color.White;
            this.btnPrecedent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrecedent.BackgroundImage")));
            this.btnPrecedent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrecedent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrecedent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrecedent.Location = new System.Drawing.Point(411, 443);
            this.btnPrecedent.Name = "btnPrecedent";
            this.btnPrecedent.Size = new System.Drawing.Size(100, 100);
            this.btnPrecedent.TabIndex = 2;
            this.btnPrecedent.UseVisualStyleBackColor = false;
            this.btnPrecedent.Click += new System.EventHandler(this.btnPrecedent_Click);
            // 
            // btnSuivant
            // 
            this.btnSuivant.BackColor = System.Drawing.Color.White;
            this.btnSuivant.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSuivant.BackgroundImage")));
            this.btnSuivant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSuivant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuivant.Location = new System.Drawing.Point(563, 443);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(100, 100);
            this.btnSuivant.TabIndex = 1;
            this.btnSuivant.UseVisualStyleBackColor = false;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // btnPremier
            // 
            this.btnPremier.BackColor = System.Drawing.Color.White;
            this.btnPremier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPremier.BackgroundImage")));
            this.btnPremier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPremier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPremier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPremier.Location = new System.Drawing.Point(266, 443);
            this.btnPremier.Name = "btnPremier";
            this.btnPremier.Size = new System.Drawing.Size(100, 100);
            this.btnPremier.TabIndex = 0;
            this.btnPremier.UseVisualStyleBackColor = false;
            this.btnPremier.Click += new System.EventHandler(this.btnPremier_Click);
            // 
            // btnChangeEnIntegral
            // 
            this.btnChangeEnIntegral.BackColor = System.Drawing.Color.Coral;
            this.btnChangeEnIntegral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeEnIntegral.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeEnIntegral.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeEnIntegral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChangeEnIntegral.Location = new System.Drawing.Point(918, 616);
            this.btnChangeEnIntegral.Name = "btnChangeEnIntegral";
            this.btnChangeEnIntegral.Size = new System.Drawing.Size(141, 59);
            this.btnChangeEnIntegral.TabIndex = 0;
            this.btnChangeEnIntegral.Text = "En mode intégral";
            this.btnChangeEnIntegral.UseVisualStyleBackColor = false;
            this.btnChangeEnIntegral.Click += new System.EventHandler(this.btnChangeEnIntegral_Click);
            // 
            // btnRevenirRecettes
            // 
            this.btnRevenirRecettes.BackColor = System.Drawing.Color.Coral;
            this.btnRevenirRecettes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevenirRecettes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRevenirRecettes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevenirRecettes.Location = new System.Drawing.Point(13, 618);
            this.btnRevenirRecettes.Name = "btnRevenirRecettes";
            this.btnRevenirRecettes.Size = new System.Drawing.Size(169, 61);
            this.btnRevenirRecettes.TabIndex = 2;
            this.btnRevenirRecettes.Text = "Revenir aux recettes";
            this.btnRevenirRecettes.UseVisualStyleBackColor = false;
            this.btnRevenirRecettes.Click += new System.EventHandler(this.btnRevenirRecettes_Click);
            // 
            // btnNoterRecette
            // 
            this.btnNoterRecette.BackColor = System.Drawing.Color.Yellow;
            this.btnNoterRecette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoterRecette.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNoterRecette.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoterRecette.Location = new System.Drawing.Point(464, 618);
            this.btnNoterRecette.Name = "btnNoterRecette";
            this.btnNoterRecette.Size = new System.Drawing.Size(182, 61);
            this.btnNoterRecette.TabIndex = 3;
            this.btnNoterRecette.Text = "Noter la recette";
            this.btnNoterRecette.UseVisualStyleBackColor = false;
            this.btnNoterRecette.Click += new System.EventHandler(this.btnNoterRecette_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.ForeColor = System.Drawing.Color.Black;
            this.btnPDF.Location = new System.Drawing.Point(276, 618);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(145, 61);
            this.btnPDF.TabIndex = 4;
            this.btnPDF.Text = "Imprimer en PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnRetourAccueil
            // 
            this.btnRetourAccueil.BackColor = System.Drawing.Color.Coral;
            this.btnRetourAccueil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetourAccueil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetourAccueil.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetourAccueil.Location = new System.Drawing.Point(682, 618);
            this.btnRetourAccueil.Name = "btnRetourAccueil";
            this.btnRetourAccueil.Size = new System.Drawing.Size(141, 61);
            this.btnRetourAccueil.TabIndex = 5;
            this.btnRetourAccueil.Text = "Retour Accueil";
            this.btnRetourAccueil.UseVisualStyleBackColor = false;
            this.btnRetourAccueil.Click += new System.EventHandler(this.btnRetourAccueil_Click);
            // 
            // frmDetailsRecette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 691);
            this.Controls.Add(this.btnRetourAccueil);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnNoterRecette);
            this.Controls.Add(this.btnChangeEnEtapes);
            this.Controls.Add(this.btnChangeEnIntegral);
            this.Controls.Add(this.btnRevenirRecettes);
            this.Controls.Add(this.pnlEtapeParEtape);
            this.Controls.Add(this.pnlIntegral);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetailsRecette";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Détails de la recette";
            this.Load += new System.EventHandler(this.frmDetailsRecette_Load);
            this.pnlIntegral.ResumeLayout(false);
            this.pnlEtapeParEtape.ResumeLayout(false);
            this.pnlEtapeParEtape.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIntegral;
        private Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCRecapRecette ucRecapRecette;
        private System.Windows.Forms.Button btnChangeEnEtapes;
        private System.Windows.Forms.Panel pnlEtapeParEtape;
        private System.Windows.Forms.Button btnChangeEnIntegral;
        private System.Windows.Forms.Button btnRevenirRecettes;
        private System.Windows.Forms.Button btnDernier;
        private System.Windows.Forms.Button btnPrecedent;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Button btnPremier;
        private System.Windows.Forms.Label lblInvisible;
        private Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCEtape ucEtape;
        private System.Windows.Forms.Button btnEtapeAfficheIngredients;
        private Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCEtapeIngredients ucEtapeIngredients;
        private System.Windows.Forms.Button btnNoterRecette;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnRetourAccueil;
    }
}