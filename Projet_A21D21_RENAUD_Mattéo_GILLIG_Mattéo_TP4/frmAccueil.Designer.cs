namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    partial class frmAccueil
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccueil));
            this.btnDemarrer = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnRetourAccueil = new System.Windows.Forms.Button();
            this.pnlChoixIngrdients = new System.Windows.Forms.Panel();
            this.pnlTypePlatBudgetTemps = new System.Windows.Forms.Panel();
            this.ucBudget = new Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCBudget();
            this.ucTypePlat = new Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCTypePlat();
            this.btnReinitialiser = new System.Windows.Forms.Button();
            this.lblTypePlatBudgetCuisson = new System.Windows.Forms.Label();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.ucTempsCuissons = new Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCTempsCuissons();
            this.btnRevenirChoixIngredients = new System.Windows.Forms.Button();
            this.ucAfficheIngredientsDetails = new Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCAfficheIngredients();
            this.ucListeFamilleIngredients = new Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCListeFamille();
            this.btnEtapeTypePlatBudgetTemps = new System.Windows.Forms.Button();
            this.lblIndiquerIngredients = new System.Windows.Forms.Label();
            this.ucIngredientsChoisis = new Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCIngredientsChoisis();
            this.lblBienvenue = new System.Windows.Forms.Label();
            this.btnVoirAvis = new System.Windows.Forms.Button();
            this.pnlChoixIngrdients.SuspendLayout();
            this.pnlTypePlatBudgetTemps.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDemarrer
            // 
            this.btnDemarrer.BackColor = System.Drawing.Color.Coral;
            this.btnDemarrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDemarrer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDemarrer.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDemarrer.Location = new System.Drawing.Point(620, 345);
            this.btnDemarrer.Name = "btnDemarrer";
            this.btnDemarrer.Size = new System.Drawing.Size(360, 100);
            this.btnDemarrer.TabIndex = 0;
            this.btnDemarrer.Text = "Démarrer";
            this.btnDemarrer.UseVisualStyleBackColor = false;
            this.btnDemarrer.Click += new System.EventHandler(this.btnDemarrer_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Coral;
            this.btnQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuitter.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Location = new System.Drawing.Point(21, 620);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(218, 54);
            this.btnQuitter.TabIndex = 1;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnRetourAccueil
            // 
            this.btnRetourAccueil.BackColor = System.Drawing.Color.Coral;
            this.btnRetourAccueil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetourAccueil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetourAccueil.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetourAccueil.Location = new System.Drawing.Point(10, 565);
            this.btnRetourAccueil.Name = "btnRetourAccueil";
            this.btnRetourAccueil.Size = new System.Drawing.Size(209, 71);
            this.btnRetourAccueil.TabIndex = 2;
            this.btnRetourAccueil.Text = "Revenir à l\'écran d\'accueil";
            this.btnRetourAccueil.UseVisualStyleBackColor = false;
            this.btnRetourAccueil.Visible = false;
            this.btnRetourAccueil.Click += new System.EventHandler(this.btnRetourAccueil_Click);
            // 
            // pnlChoixIngrdients
            // 
            this.pnlChoixIngrdients.BackColor = System.Drawing.Color.Transparent;
            this.pnlChoixIngrdients.Controls.Add(this.pnlTypePlatBudgetTemps);
            this.pnlChoixIngrdients.Controls.Add(this.ucAfficheIngredientsDetails);
            this.pnlChoixIngrdients.Controls.Add(this.ucListeFamilleIngredients);
            this.pnlChoixIngrdients.Controls.Add(this.btnEtapeTypePlatBudgetTemps);
            this.pnlChoixIngrdients.Controls.Add(this.lblIndiquerIngredients);
            this.pnlChoixIngrdients.Controls.Add(this.btnRetourAccueil);
            this.pnlChoixIngrdients.Controls.Add(this.ucIngredientsChoisis);
            this.pnlChoixIngrdients.Location = new System.Drawing.Point(21, 12);
            this.pnlChoixIngrdients.Name = "pnlChoixIngrdients";
            this.pnlChoixIngrdients.Size = new System.Drawing.Size(1043, 668);
            this.pnlChoixIngrdients.TabIndex = 5;
            this.pnlChoixIngrdients.Visible = false;
            // 
            // pnlTypePlatBudgetTemps
            // 
            this.pnlTypePlatBudgetTemps.Controls.Add(this.ucBudget);
            this.pnlTypePlatBudgetTemps.Controls.Add(this.ucTypePlat);
            this.pnlTypePlatBudgetTemps.Controls.Add(this.btnReinitialiser);
            this.pnlTypePlatBudgetTemps.Controls.Add(this.lblTypePlatBudgetCuisson);
            this.pnlTypePlatBudgetTemps.Controls.Add(this.btnRecherche);
            this.pnlTypePlatBudgetTemps.Controls.Add(this.ucTempsCuissons);
            this.pnlTypePlatBudgetTemps.Controls.Add(this.btnRevenirChoixIngredients);
            this.pnlTypePlatBudgetTemps.Location = new System.Drawing.Point(3, 0);
            this.pnlTypePlatBudgetTemps.Name = "pnlTypePlatBudgetTemps";
            this.pnlTypePlatBudgetTemps.Size = new System.Drawing.Size(1043, 665);
            this.pnlTypePlatBudgetTemps.TabIndex = 11;
            this.pnlTypePlatBudgetTemps.Visible = false;
            // 
            // ucBudget
            // 
            this.ucBudget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.ucBudget.Location = new System.Drawing.Point(170, 313);
            this.ucBudget.Name = "ucBudget";
            this.ucBudget.Size = new System.Drawing.Size(700, 110);
            this.ucBudget.TabIndex = 8;
            this.ucBudget.TexteGroupBox = "Votre budget :";
            this.ucBudget.TexteRadioBoutonMoyen = "Moyen";
            this.ucBudget.TexteRadioBoutonPauvre = "Bas";
            this.ucBudget.TexteRadioBoutonRiche = "Haut";
            this.ucBudget.TexteRadioBoutonToutBudget = "Tout Budget";
            // 
            // ucTypePlat
            // 
            this.ucTypePlat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.ucTypePlat.Location = new System.Drawing.Point(20, 40);
            this.ucTypePlat.Name = "ucTypePlat";
            this.ucTypePlat.Size = new System.Drawing.Size(1015, 260);
            this.ucTypePlat.TabIndex = 7;
            this.ucTypePlat.TexteGroupBox = "Type de plat :";
            // 
            // btnReinitialiser
            // 
            this.btnReinitialiser.AccessibleDescription = "";
            this.btnReinitialiser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnReinitialiser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReinitialiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReinitialiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReinitialiser.Location = new System.Drawing.Point(452, 564);
            this.btnReinitialiser.Name = "btnReinitialiser";
            this.btnReinitialiser.Size = new System.Drawing.Size(150, 75);
            this.btnReinitialiser.TabIndex = 6;
            this.btnReinitialiser.Text = "Réinitialiser mon choix";
            this.btnReinitialiser.UseVisualStyleBackColor = false;
            this.btnReinitialiser.Click += new System.EventHandler(this.btnReinitialiser_Click);
            // 
            // lblTypePlatBudgetCuisson
            // 
            this.lblTypePlatBudgetCuisson.AutoSize = true;
            this.lblTypePlatBudgetCuisson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.lblTypePlatBudgetCuisson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTypePlatBudgetCuisson.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypePlatBudgetCuisson.ForeColor = System.Drawing.Color.Black;
            this.lblTypePlatBudgetCuisson.Location = new System.Drawing.Point(20, 10);
            this.lblTypePlatBudgetCuisson.Name = "lblTypePlatBudgetCuisson";
            this.lblTypePlatBudgetCuisson.Size = new System.Drawing.Size(993, 25);
            this.lblTypePlatBudgetCuisson.TabIndex = 5;
            this.lblTypePlatBudgetCuisson.Text = "Etape n°2 : Indiquez votre type de plat, budget et/ou temps de cuisson ou passez " +
    "cette étape";
            // 
            // btnRecherche
            // 
            this.btnRecherche.BackColor = System.Drawing.Color.Coral;
            this.btnRecherche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche.Location = new System.Drawing.Point(823, 564);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(204, 75);
            this.btnRecherche.TabIndex = 4;
            this.btnRecherche.Text = "Afficher les recettes";
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // ucTempsCuissons
            // 
            this.ucTempsCuissons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.ucTempsCuissons.Location = new System.Drawing.Point(215, 434);
            this.ucTempsCuissons.Name = "ucTempsCuissons";
            this.ucTempsCuissons.Size = new System.Drawing.Size(611, 113);
            this.ucTempsCuissons.TabIndex = 2;
            this.ucTempsCuissons.TexteGroupBox = "Temps de cuisson :";
            this.ucTempsCuissons.TexteLabel = "Choissisez votre temps de cuisson :";
            // 
            // btnRevenirChoixIngredients
            // 
            this.btnRevenirChoixIngredients.BackColor = System.Drawing.Color.Coral;
            this.btnRevenirChoixIngredients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevenirChoixIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRevenirChoixIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevenirChoixIngredients.Location = new System.Drawing.Point(23, 564);
            this.btnRevenirChoixIngredients.Name = "btnRevenirChoixIngredients";
            this.btnRevenirChoixIngredients.Size = new System.Drawing.Size(222, 75);
            this.btnRevenirChoixIngredients.TabIndex = 0;
            this.btnRevenirChoixIngredients.Text = "Revenir au choix des ingrédients";
            this.btnRevenirChoixIngredients.UseVisualStyleBackColor = false;
            this.btnRevenirChoixIngredients.Click += new System.EventHandler(this.btnRevenirChoixIngredients_Click);
            // 
            // ucAfficheIngredientsDetails
            // 
            this.ucAfficheIngredientsDetails.AutoSize = true;
            this.ucAfficheIngredientsDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.ucAfficheIngredientsDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucAfficheIngredientsDetails.Location = new System.Drawing.Point(16, 256);
            this.ucAfficheIngredientsDetails.Name = "ucAfficheIngredientsDetails";
            this.ucAfficheIngredientsDetails.Size = new System.Drawing.Size(1027, 240);
            this.ucAfficheIngredientsDetails.TabIndex = 12;
            this.ucAfficheIngredientsDetails.Titre = "Famille d\'ingrédients :";
            // 
            // ucListeFamilleIngredients
            // 
            this.ucListeFamilleIngredients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.ucListeFamilleIngredients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucListeFamilleIngredients.Location = new System.Drawing.Point(16, 38);
            this.ucListeFamilleIngredients.Name = "ucListeFamilleIngredients";
            this.ucListeFamilleIngredients.NomGroupBox = "Liste des familles :";
            this.ucListeFamilleIngredients.Size = new System.Drawing.Size(1024, 209);
            this.ucListeFamilleIngredients.TabIndex = 7;
            // 
            // btnEtapeTypePlatBudgetTemps
            // 
            this.btnEtapeTypePlatBudgetTemps.BackColor = System.Drawing.Color.Coral;
            this.btnEtapeTypePlatBudgetTemps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEtapeTypePlatBudgetTemps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEtapeTypePlatBudgetTemps.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtapeTypePlatBudgetTemps.Location = new System.Drawing.Point(821, 565);
            this.btnEtapeTypePlatBudgetTemps.Name = "btnEtapeTypePlatBudgetTemps";
            this.btnEtapeTypePlatBudgetTemps.Size = new System.Drawing.Size(208, 71);
            this.btnEtapeTypePlatBudgetTemps.TabIndex = 8;
            this.btnEtapeTypePlatBudgetTemps.Text = "Passez à l\'étape suivante";
            this.btnEtapeTypePlatBudgetTemps.UseVisualStyleBackColor = false;
            this.btnEtapeTypePlatBudgetTemps.Click += new System.EventHandler(this.btnEtapeTypePlatBudgetTemps_Click);
            // 
            // lblIndiquerIngredients
            // 
            this.lblIndiquerIngredients.AutoSize = true;
            this.lblIndiquerIngredients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.lblIndiquerIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblIndiquerIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndiquerIngredients.ForeColor = System.Drawing.Color.Black;
            this.lblIndiquerIngredients.Location = new System.Drawing.Point(20, 0);
            this.lblIndiquerIngredients.Name = "lblIndiquerIngredients";
            this.lblIndiquerIngredients.Size = new System.Drawing.Size(834, 25);
            this.lblIndiquerIngredients.TabIndex = 7;
            this.lblIndiquerIngredients.Text = "Etape n°1 : Indiquez les ingrédients que vous posseder ou passez cette étape";
            // 
            // ucIngredientsChoisis
            // 
            this.ucIngredientsChoisis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.ucIngredientsChoisis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucIngredientsChoisis.Location = new System.Drawing.Point(254, 502);
            this.ucIngredientsChoisis.Name = "ucIngredientsChoisis";
            this.ucIngredientsChoisis.Size = new System.Drawing.Size(540, 150);
            this.ucIngredientsChoisis.TabIndex = 13;
            this.ucIngredientsChoisis.TexteLabelRienChoisis = "Choissisez 3 ingrédients ou passez à l\'étape suivante";
            // 
            // lblBienvenue
            // 
            this.lblBienvenue.AutoSize = true;
            this.lblBienvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.lblBienvenue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblBienvenue.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenue.ForeColor = System.Drawing.Color.Black;
            this.lblBienvenue.Location = new System.Drawing.Point(130, 90);
            this.lblBienvenue.Name = "lblBienvenue";
            this.lblBienvenue.Size = new System.Drawing.Size(796, 69);
            this.lblBienvenue.TabIndex = 6;
            this.lblBienvenue.Text = "Bienvenue sur FaitMaison";
            // 
            // btnVoirAvis
            // 
            this.btnVoirAvis.BackColor = System.Drawing.Color.Yellow;
            this.btnVoirAvis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoirAvis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoirAvis.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoirAvis.Location = new System.Drawing.Point(61, 345);
            this.btnVoirAvis.Name = "btnVoirAvis";
            this.btnVoirAvis.Size = new System.Drawing.Size(455, 100);
            this.btnVoirAvis.TabIndex = 7;
            this.btnVoirAvis.Text = "Voir nos avis";
            this.btnVoirAvis.UseVisualStyleBackColor = false;
            this.btnVoirAvis.Click += new System.EventHandler(this.btnVoirAvis_Click);
            // 
            // frmAccueil
            // 
            this.AccessibleDescription = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 686);
            this.Controls.Add(this.pnlChoixIngrdients);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnDemarrer);
            this.Controls.Add(this.lblBienvenue);
            this.Controls.Add(this.btnVoirAvis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C\'est fait maison !";
            this.Load += new System.EventHandler(this.frmAccueil_Load);
            this.pnlChoixIngrdients.ResumeLayout(false);
            this.pnlChoixIngrdients.PerformLayout();
            this.pnlTypePlatBudgetTemps.ResumeLayout(false);
            this.pnlTypePlatBudgetTemps.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDemarrer;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnRetourAccueil;
        private System.Windows.Forms.Panel pnlChoixIngrdients;
        private System.Windows.Forms.Label lblBienvenue;
        private System.Windows.Forms.Label lblIndiquerIngredients;
        private System.Windows.Forms.Button btnEtapeTypePlatBudgetTemps;
        private System.Windows.Forms.Panel pnlTypePlatBudgetTemps;
        private System.Windows.Forms.Button btnRevenirChoixIngredients;
        private Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCTempsCuissons ucTempsCuissons;
        private System.Windows.Forms.Button btnRecherche;
        private System.Windows.Forms.Button btnReinitialiser;
        private System.Windows.Forms.Label lblTypePlatBudgetCuisson;
        private UCListeFamille ucListeFamilleIngredients;
        private UCAfficheIngredients ucAfficheIngredientsDetails;
        private Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCTypePlat ucTypePlat;
        private UCIngredientsChoisis ucIngredientsChoisis;
        private System.Windows.Forms.Button btnVoirAvis;
        private Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCBudget ucBudget;
    }
}

