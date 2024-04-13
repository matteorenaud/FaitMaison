namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    partial class frmNotations
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotations));
            this.lblTitre = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.cboRecettes = new System.Windows.Forms.ComboBox();
            this.lblRecetteANoter = new System.Windows.Forms.Label();
            this.lblPseudo = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblAvis = new System.Windows.Forms.Label();
            this.txtPseudo = new System.Windows.Forms.TextBox();
            this.txtDeGensPeterDeThunes = new System.Windows.Forms.RichTextBox();
            this.errSaisie = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnVoirAvis = new System.Windows.Forms.Button();
            this.pnlConsultationAvis = new System.Windows.Forms.Panel();
            this.btnRetourAccueil = new System.Windows.Forms.Button();
            this.lblAvisPertinents = new System.Windows.Forms.Label();
            this.pnlVoirAvis = new System.Windows.Forms.Panel();
            this.btnRechercheAvis = new System.Windows.Forms.Button();
            this.btnRetourNotations = new System.Windows.Forms.Button();
            this.grpFiltre = new System.Windows.Forms.GroupBox();
            this.pnlCommentaireConsultationAvis = new System.Windows.Forms.Panel();
            this.rdbCommentaireSansFiltre = new System.Windows.Forms.RadioButton();
            this.rdbCommentaireAvecFiltre = new System.Windows.Forms.RadioButton();
            this.txtCommentairePrecis = new System.Windows.Forms.TextBox();
            this.pnlNbEtoilesConsultationAvis = new System.Windows.Forms.Panel();
            this.btnMoins = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.lblNoteConsultationAvis = new System.Windows.Forms.Label();
            this.pnlPseudoConsultationAvis = new System.Windows.Forms.Panel();
            this.lblPseudoConsulationAvis = new System.Windows.Forms.Label();
            this.txtPseudoConsulationAvis = new System.Windows.Forms.TextBox();
            this.cboRecettesConsulationAvis = new System.Windows.Forms.ComboBox();
            this.chkCommentaire = new System.Windows.Forms.CheckBox();
            this.chkNote = new System.Windows.Forms.CheckBox();
            this.chkPseudo = new System.Windows.Forms.CheckBox();
            this.chkRecette = new System.Windows.Forms.CheckBox();
            this.lblConsultationAvis = new System.Windows.Forms.Label();
            this.pnlNoterLaRecetteDeProvenance = new System.Windows.Forms.Panel();
            this.lblNoterLaRecetteProvenance = new System.Windows.Forms.Label();
            this.ucEtoiles = new Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCEtoiles();
            ((System.ComponentModel.ISupportInitialize)(this.errSaisie)).BeginInit();
            this.pnlConsultationAvis.SuspendLayout();
            this.grpFiltre.SuspendLayout();
            this.pnlCommentaireConsultationAvis.SuspendLayout();
            this.pnlNbEtoilesConsultationAvis.SuspendLayout();
            this.pnlPseudoConsultationAvis.SuspendLayout();
            this.pnlNoterLaRecetteDeProvenance.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTitre.Font = new System.Drawing.Font("Lucida Handwriting", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(294, 25);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(422, 48);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Noter une recette !";
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Location = new System.Drawing.Point(629, 598);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(160, 60);
            this.btnValider.TabIndex = 1;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Coral;
            this.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(239, 598);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(160, 60);
            this.btnAnnuler.TabIndex = 2;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // cboRecettes
            // 
            this.cboRecettes.BackColor = System.Drawing.SystemColors.Menu;
            this.cboRecettes.Cursor = System.Windows.Forms.Cursors.PanNorth;
            this.cboRecettes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboRecettes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRecettes.FormattingEnabled = true;
            this.cboRecettes.Location = new System.Drawing.Point(259, 133);
            this.cboRecettes.Name = "cboRecettes";
            this.cboRecettes.Size = new System.Drawing.Size(476, 33);
            this.cboRecettes.TabIndex = 3;
            // 
            // lblRecetteANoter
            // 
            this.lblRecetteANoter.AutoSize = true;
            this.lblRecetteANoter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRecetteANoter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecetteANoter.Location = new System.Drawing.Point(264, 90);
            this.lblRecetteANoter.Name = "lblRecetteANoter";
            this.lblRecetteANoter.Size = new System.Drawing.Size(461, 31);
            this.lblRecetteANoter.TabIndex = 4;
            this.lblRecetteANoter.Text = "Quelle recette voulez-vous noter ?";
            // 
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPseudo.Location = new System.Drawing.Point(403, 182);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(211, 31);
            this.lblPseudo.TabIndex = 5;
            this.lblPseudo.Text = "Votre pseudo ?";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(414, 257);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(173, 31);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "Votre note ?";
            // 
            // lblAvis
            // 
            this.lblAvis.AutoSize = true;
            this.lblAvis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAvis.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvis.Location = new System.Drawing.Point(370, 388);
            this.lblAvis.Name = "lblAvis";
            this.lblAvis.Size = new System.Drawing.Size(310, 31);
            this.lblAvis.TabIndex = 7;
            this.lblAvis.Text = "Votre avis ? (facultatif)";
            // 
            // txtPseudo
            // 
            this.txtPseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPseudo.Location = new System.Drawing.Point(347, 216);
            this.txtPseudo.Name = "txtPseudo";
            this.txtPseudo.Size = new System.Drawing.Size(308, 38);
            this.txtPseudo.TabIndex = 8;
            // 
            // txtDeGensPeterDeThunes
            // 
            this.txtDeGensPeterDeThunes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeGensPeterDeThunes.Location = new System.Drawing.Point(239, 422);
            this.txtDeGensPeterDeThunes.Name = "txtDeGensPeterDeThunes";
            this.txtDeGensPeterDeThunes.Size = new System.Drawing.Size(550, 170);
            this.txtDeGensPeterDeThunes.TabIndex = 9;
            this.txtDeGensPeterDeThunes.Text = "";
            // 
            // errSaisie
            // 
            this.errSaisie.ContainerControl = this;
            // 
            // btnVoirAvis
            // 
            this.btnVoirAvis.BackColor = System.Drawing.Color.Coral;
            this.btnVoirAvis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoirAvis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoirAvis.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoirAvis.Location = new System.Drawing.Point(430, 598);
            this.btnVoirAvis.Name = "btnVoirAvis";
            this.btnVoirAvis.Size = new System.Drawing.Size(175, 72);
            this.btnVoirAvis.TabIndex = 12;
            this.btnVoirAvis.Text = "Consulter les avis";
            this.btnVoirAvis.UseVisualStyleBackColor = false;
            this.btnVoirAvis.Click += new System.EventHandler(this.btnVoirAvis_Click);
            // 
            // pnlConsultationAvis
            // 
            this.pnlConsultationAvis.Controls.Add(this.btnRetourAccueil);
            this.pnlConsultationAvis.Controls.Add(this.lblAvisPertinents);
            this.pnlConsultationAvis.Controls.Add(this.pnlVoirAvis);
            this.pnlConsultationAvis.Controls.Add(this.btnRechercheAvis);
            this.pnlConsultationAvis.Controls.Add(this.btnRetourNotations);
            this.pnlConsultationAvis.Controls.Add(this.grpFiltre);
            this.pnlConsultationAvis.Controls.Add(this.lblConsultationAvis);
            this.pnlConsultationAvis.Location = new System.Drawing.Point(0, -2);
            this.pnlConsultationAvis.Name = "pnlConsultationAvis";
            this.pnlConsultationAvis.Size = new System.Drawing.Size(1100, 689);
            this.pnlConsultationAvis.TabIndex = 13;
            this.pnlConsultationAvis.Visible = false;
            // 
            // btnRetourAccueil
            // 
            this.btnRetourAccueil.BackColor = System.Drawing.Color.Coral;
            this.btnRetourAccueil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetourAccueil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetourAccueil.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetourAccueil.Location = new System.Drawing.Point(847, 360);
            this.btnRetourAccueil.Name = "btnRetourAccueil";
            this.btnRetourAccueil.Size = new System.Drawing.Size(157, 74);
            this.btnRetourAccueil.TabIndex = 7;
            this.btnRetourAccueil.Text = "Retour à l\'accueil";
            this.btnRetourAccueil.UseVisualStyleBackColor = false;
            this.btnRetourAccueil.Click += new System.EventHandler(this.btnRetourAccueil_Click);
            // 
            // lblAvisPertinents
            // 
            this.lblAvisPertinents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAvisPertinents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisPertinents.Location = new System.Drawing.Point(18, 380);
            this.lblAvisPertinents.Name = "lblAvisPertinents";
            this.lblAvisPertinents.Size = new System.Drawing.Size(198, 57);
            this.lblAvisPertinents.TabIndex = 6;
            this.lblAvisPertinents.Text = "Les avis les plus pertinents";
            this.lblAvisPertinents.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlVoirAvis
            // 
            this.pnlVoirAvis.AutoScroll = true;
            this.pnlVoirAvis.Location = new System.Drawing.Point(22, 440);
            this.pnlVoirAvis.Name = "pnlVoirAvis";
            this.pnlVoirAvis.Size = new System.Drawing.Size(1039, 230);
            this.pnlVoirAvis.TabIndex = 5;
            // 
            // btnRechercheAvis
            // 
            this.btnRechercheAvis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnRechercheAvis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRechercheAvis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRechercheAvis.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercheAvis.Location = new System.Drawing.Point(397, 360);
            this.btnRechercheAvis.Name = "btnRechercheAvis";
            this.btnRechercheAvis.Size = new System.Drawing.Size(217, 74);
            this.btnRechercheAvis.TabIndex = 4;
            this.btnRechercheAvis.Text = "Valider";
            this.btnRechercheAvis.UseVisualStyleBackColor = false;
            this.btnRechercheAvis.Click += new System.EventHandler(this.btnRechercheAvis_Click);
            // 
            // btnRetourNotations
            // 
            this.btnRetourNotations.BackColor = System.Drawing.Color.Coral;
            this.btnRetourNotations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetourNotations.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetourNotations.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetourNotations.Location = new System.Drawing.Point(845, 360);
            this.btnRetourNotations.Name = "btnRetourNotations";
            this.btnRetourNotations.Size = new System.Drawing.Size(159, 74);
            this.btnRetourNotations.TabIndex = 2;
            this.btnRetourNotations.Text = "Noter une recette";
            this.btnRetourNotations.UseVisualStyleBackColor = false;
            this.btnRetourNotations.Click += new System.EventHandler(this.btnRetourNotations_Click);
            // 
            // grpFiltre
            // 
            this.grpFiltre.BackColor = System.Drawing.Color.White;
            this.grpFiltre.Controls.Add(this.pnlCommentaireConsultationAvis);
            this.grpFiltre.Controls.Add(this.pnlNbEtoilesConsultationAvis);
            this.grpFiltre.Controls.Add(this.pnlPseudoConsultationAvis);
            this.grpFiltre.Controls.Add(this.cboRecettesConsulationAvis);
            this.grpFiltre.Controls.Add(this.chkCommentaire);
            this.grpFiltre.Controls.Add(this.chkNote);
            this.grpFiltre.Controls.Add(this.chkPseudo);
            this.grpFiltre.Controls.Add(this.chkRecette);
            this.grpFiltre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltre.Location = new System.Drawing.Point(67, 76);
            this.grpFiltre.Name = "grpFiltre";
            this.grpFiltre.Size = new System.Drawing.Size(937, 278);
            this.grpFiltre.TabIndex = 1;
            this.grpFiltre.TabStop = false;
            this.grpFiltre.Text = "Choissisez votre filtre ou validez";
            // 
            // pnlCommentaireConsultationAvis
            // 
            this.pnlCommentaireConsultationAvis.Controls.Add(this.rdbCommentaireSansFiltre);
            this.pnlCommentaireConsultationAvis.Controls.Add(this.rdbCommentaireAvecFiltre);
            this.pnlCommentaireConsultationAvis.Controls.Add(this.txtCommentairePrecis);
            this.pnlCommentaireConsultationAvis.Location = new System.Drawing.Point(257, 181);
            this.pnlCommentaireConsultationAvis.Name = "pnlCommentaireConsultationAvis";
            this.pnlCommentaireConsultationAvis.Size = new System.Drawing.Size(606, 81);
            this.pnlCommentaireConsultationAvis.TabIndex = 15;
            this.pnlCommentaireConsultationAvis.Visible = false;
            // 
            // rdbCommentaireSansFiltre
            // 
            this.rdbCommentaireSansFiltre.AutoSize = true;
            this.rdbCommentaireSansFiltre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbCommentaireSansFiltre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbCommentaireSansFiltre.Location = new System.Drawing.Point(17, 3);
            this.rdbCommentaireSansFiltre.Name = "rdbCommentaireSansFiltre";
            this.rdbCommentaireSansFiltre.Size = new System.Drawing.Size(272, 29);
            this.rdbCommentaireSansFiltre.TabIndex = 7;
            this.rdbCommentaireSansFiltre.Text = "Avis avec commentaire";
            this.rdbCommentaireSansFiltre.UseVisualStyleBackColor = true;
            // 
            // rdbCommentaireAvecFiltre
            // 
            this.rdbCommentaireAvecFiltre.AutoSize = true;
            this.rdbCommentaireAvecFiltre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbCommentaireAvecFiltre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbCommentaireAvecFiltre.Location = new System.Drawing.Point(17, 44);
            this.rdbCommentaireAvecFiltre.Name = "rdbCommentaireAvecFiltre";
            this.rdbCommentaireAvecFiltre.Size = new System.Drawing.Size(357, 29);
            this.rdbCommentaireAvecFiltre.TabIndex = 8;
            this.rdbCommentaireAvecFiltre.Text = "Avis avec commentaire précis :";
            this.rdbCommentaireAvecFiltre.UseVisualStyleBackColor = true;
            // 
            // txtCommentairePrecis
            // 
            this.txtCommentairePrecis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCommentairePrecis.Location = new System.Drawing.Point(391, 42);
            this.txtCommentairePrecis.Name = "txtCommentairePrecis";
            this.txtCommentairePrecis.Size = new System.Drawing.Size(190, 31);
            this.txtCommentairePrecis.TabIndex = 9;
            // 
            // pnlNbEtoilesConsultationAvis
            // 
            this.pnlNbEtoilesConsultationAvis.Controls.Add(this.btnMoins);
            this.pnlNbEtoilesConsultationAvis.Controls.Add(this.btnPlus);
            this.pnlNbEtoilesConsultationAvis.Controls.Add(this.lblNoteConsultationAvis);
            this.pnlNbEtoilesConsultationAvis.Location = new System.Drawing.Point(212, 139);
            this.pnlNbEtoilesConsultationAvis.Name = "pnlNbEtoilesConsultationAvis";
            this.pnlNbEtoilesConsultationAvis.Size = new System.Drawing.Size(193, 35);
            this.pnlNbEtoilesConsultationAvis.TabIndex = 14;
            this.pnlNbEtoilesConsultationAvis.Visible = false;
            // 
            // btnMoins
            // 
            this.btnMoins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMoins.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoins.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMoins.Location = new System.Drawing.Point(3, 0);
            this.btnMoins.Name = "btnMoins";
            this.btnMoins.Size = new System.Drawing.Size(35, 35);
            this.btnMoins.TabIndex = 10;
            this.btnMoins.Text = "-";
            this.btnMoins.UseVisualStyleBackColor = false;
            this.btnMoins.Click += new System.EventHandler(this.btnMoins_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlus.Location = new System.Drawing.Point(153, 0);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(35, 35);
            this.btnPlus.TabIndex = 11;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lblNoteConsultationAvis
            // 
            this.lblNoteConsultationAvis.Location = new System.Drawing.Point(35, 5);
            this.lblNoteConsultationAvis.Name = "lblNoteConsultationAvis";
            this.lblNoteConsultationAvis.Size = new System.Drawing.Size(120, 25);
            this.lblNoteConsultationAvis.TabIndex = 12;
            this.lblNoteConsultationAvis.Text = " étoiles";
            this.lblNoteConsultationAvis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPseudoConsultationAvis
            // 
            this.pnlPseudoConsultationAvis.Controls.Add(this.lblPseudoConsulationAvis);
            this.pnlPseudoConsultationAvis.Controls.Add(this.txtPseudoConsulationAvis);
            this.pnlPseudoConsultationAvis.Location = new System.Drawing.Point(212, 82);
            this.pnlPseudoConsultationAvis.Name = "pnlPseudoConsultationAvis";
            this.pnlPseudoConsultationAvis.Size = new System.Drawing.Size(455, 48);
            this.pnlPseudoConsultationAvis.TabIndex = 13;
            this.pnlPseudoConsultationAvis.Visible = false;
            // 
            // lblPseudoConsulationAvis
            // 
            this.lblPseudoConsulationAvis.AutoSize = true;
            this.lblPseudoConsulationAvis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPseudoConsulationAvis.Location = new System.Drawing.Point(3, 11);
            this.lblPseudoConsulationAvis.Name = "lblPseudoConsulationAvis";
            this.lblPseudoConsulationAvis.Size = new System.Drawing.Size(200, 25);
            this.lblPseudoConsulationAvis.TabIndex = 6;
            this.lblPseudoConsulationAvis.Text = "Entrer le pseudo :";
            // 
            // txtPseudoConsulationAvis
            // 
            this.txtPseudoConsulationAvis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPseudoConsulationAvis.Location = new System.Drawing.Point(220, 8);
            this.txtPseudoConsulationAvis.Name = "txtPseudoConsulationAvis";
            this.txtPseudoConsulationAvis.Size = new System.Drawing.Size(217, 31);
            this.txtPseudoConsulationAvis.TabIndex = 5;
            // 
            // cboRecettesConsulationAvis
            // 
            this.cboRecettesConsulationAvis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboRecettesConsulationAvis.Cursor = System.Windows.Forms.Cursors.PanNorth;
            this.cboRecettesConsulationAvis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboRecettesConsulationAvis.FormattingEnabled = true;
            this.cboRecettesConsulationAvis.Location = new System.Drawing.Point(212, 43);
            this.cboRecettesConsulationAvis.Name = "cboRecettesConsulationAvis";
            this.cboRecettesConsulationAvis.Size = new System.Drawing.Size(510, 33);
            this.cboRecettesConsulationAvis.TabIndex = 4;
            this.cboRecettesConsulationAvis.Visible = false;
            // 
            // chkCommentaire
            // 
            this.chkCommentaire.AutoSize = true;
            this.chkCommentaire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkCommentaire.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkCommentaire.Location = new System.Drawing.Point(29, 181);
            this.chkCommentaire.Name = "chkCommentaire";
            this.chkCommentaire.Size = new System.Drawing.Size(220, 29);
            this.chkCommentaire.TabIndex = 3;
            this.chkCommentaire.Text = "Par commentaire :";
            this.chkCommentaire.UseVisualStyleBackColor = true;
            this.chkCommentaire.CheckedChanged += new System.EventHandler(this.chkCommentaire_CheckedChanged);
            // 
            // chkNote
            // 
            this.chkNote.AutoSize = true;
            this.chkNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkNote.Location = new System.Drawing.Point(29, 135);
            this.chkNote.Name = "chkNote";
            this.chkNote.Size = new System.Drawing.Size(132, 29);
            this.chkNote.TabIndex = 2;
            this.chkNote.Text = "Par note :";
            this.chkNote.UseVisualStyleBackColor = true;
            this.chkNote.CheckedChanged += new System.EventHandler(this.chkNote_CheckedChanged);
            // 
            // chkPseudo
            // 
            this.chkPseudo.AutoSize = true;
            this.chkPseudo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPseudo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPseudo.Location = new System.Drawing.Point(29, 92);
            this.chkPseudo.Name = "chkPseudo";
            this.chkPseudo.Size = new System.Drawing.Size(163, 29);
            this.chkPseudo.TabIndex = 1;
            this.chkPseudo.Text = "Par pseudo :";
            this.chkPseudo.UseVisualStyleBackColor = true;
            this.chkPseudo.CheckedChanged += new System.EventHandler(this.chkPseudo_CheckedChanged);
            // 
            // chkRecette
            // 
            this.chkRecette.AutoSize = true;
            this.chkRecette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRecette.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkRecette.Location = new System.Drawing.Point(29, 43);
            this.chkRecette.Name = "chkRecette";
            this.chkRecette.Size = new System.Drawing.Size(159, 29);
            this.chkRecette.TabIndex = 0;
            this.chkRecette.Text = "Par recette :";
            this.chkRecette.UseVisualStyleBackColor = true;
            this.chkRecette.Click += new System.EventHandler(this.chkRecette_Click);
            // 
            // lblConsultationAvis
            // 
            this.lblConsultationAvis.AutoSize = true;
            this.lblConsultationAvis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblConsultationAvis.Font = new System.Drawing.Font("Engravers MT", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultationAvis.Location = new System.Drawing.Point(194, 9);
            this.lblConsultationAvis.Name = "lblConsultationAvis";
            this.lblConsultationAvis.Size = new System.Drawing.Size(711, 47);
            this.lblConsultationAvis.TabIndex = 0;
            this.lblConsultationAvis.Text = "Consultation des avis";
            // 
            // pnlNoterLaRecetteDeProvenance
            // 
            this.pnlNoterLaRecetteDeProvenance.Controls.Add(this.lblNoterLaRecetteProvenance);
            this.pnlNoterLaRecetteDeProvenance.Location = new System.Drawing.Point(119, 20);
            this.pnlNoterLaRecetteDeProvenance.Name = "pnlNoterLaRecetteDeProvenance";
            this.pnlNoterLaRecetteDeProvenance.Size = new System.Drawing.Size(786, 146);
            this.pnlNoterLaRecetteDeProvenance.TabIndex = 14;
            // 
            // lblNoterLaRecetteProvenance
            // 
            this.lblNoterLaRecetteProvenance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNoterLaRecetteProvenance.Font = new System.Drawing.Font("Lucida Handwriting", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoterLaRecetteProvenance.Location = new System.Drawing.Point(3, 5);
            this.lblNoterLaRecetteProvenance.Name = "lblNoterLaRecetteProvenance";
            this.lblNoterLaRecetteProvenance.Size = new System.Drawing.Size(780, 131);
            this.lblNoterLaRecetteProvenance.TabIndex = 0;
            this.lblNoterLaRecetteProvenance.Text = "Nom_de_la_recette_de_provenance";
            this.lblNoterLaRecetteProvenance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucEtoiles
            // 
            this.ucEtoiles.Location = new System.Drawing.Point(239, 285);
            this.ucEtoiles.Name = "ucEtoiles";
            this.ucEtoiles.Size = new System.Drawing.Size(520, 100);
            this.ucEtoiles.TabIndex = 10;
            // 
            // frmNotations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1080, 682);
            this.Controls.Add(this.pnlConsultationAvis);
            this.Controls.Add(this.pnlNoterLaRecetteDeProvenance);
            this.Controls.Add(this.btnVoirAvis);
            this.Controls.Add(this.ucEtoiles);
            this.Controls.Add(this.txtDeGensPeterDeThunes);
            this.Controls.Add(this.txtPseudo);
            this.Controls.Add(this.lblAvis);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblPseudo);
            this.Controls.Add(this.lblRecetteANoter);
            this.Controls.Add(this.cboRecettes);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNotations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Les notations !";
            this.Load += new System.EventHandler(this.frmNotations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errSaisie)).EndInit();
            this.pnlConsultationAvis.ResumeLayout(false);
            this.pnlConsultationAvis.PerformLayout();
            this.grpFiltre.ResumeLayout(false);
            this.grpFiltre.PerformLayout();
            this.pnlCommentaireConsultationAvis.ResumeLayout(false);
            this.pnlCommentaireConsultationAvis.PerformLayout();
            this.pnlNbEtoilesConsultationAvis.ResumeLayout(false);
            this.pnlPseudoConsultationAvis.ResumeLayout(false);
            this.pnlPseudoConsultationAvis.PerformLayout();
            this.pnlNoterLaRecetteDeProvenance.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.ComboBox cboRecettes;
        private System.Windows.Forms.Label lblRecetteANoter;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblAvis;
        private System.Windows.Forms.TextBox txtPseudo;
        private System.Windows.Forms.RichTextBox txtDeGensPeterDeThunes;
        private Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4.UCEtoiles ucEtoiles;
        private System.Windows.Forms.ErrorProvider errSaisie;
        private System.Windows.Forms.Button btnVoirAvis;
        private System.Windows.Forms.Panel pnlConsultationAvis;
        private System.Windows.Forms.Button btnRetourNotations;
        private System.Windows.Forms.GroupBox grpFiltre;
        private System.Windows.Forms.Label lblConsultationAvis;
        private System.Windows.Forms.Label lblPseudoConsulationAvis;
        private System.Windows.Forms.TextBox txtPseudoConsulationAvis;
        private System.Windows.Forms.ComboBox cboRecettesConsulationAvis;
        private System.Windows.Forms.CheckBox chkCommentaire;
        private System.Windows.Forms.CheckBox chkNote;
        private System.Windows.Forms.CheckBox chkPseudo;
        private System.Windows.Forms.CheckBox chkRecette;
        private System.Windows.Forms.TextBox txtCommentairePrecis;
        private System.Windows.Forms.RadioButton rdbCommentaireAvecFiltre;
        private System.Windows.Forms.RadioButton rdbCommentaireSansFiltre;
        private System.Windows.Forms.Label lblNoteConsultationAvis;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMoins;
        private System.Windows.Forms.Panel pnlCommentaireConsultationAvis;
        private System.Windows.Forms.Panel pnlNbEtoilesConsultationAvis;
        private System.Windows.Forms.Panel pnlPseudoConsultationAvis;
        private System.Windows.Forms.Button btnRechercheAvis;
        private System.Windows.Forms.Panel pnlVoirAvis;
        private System.Windows.Forms.Label lblAvisPertinents;
        private System.Windows.Forms.Panel pnlNoterLaRecetteDeProvenance;
        private System.Windows.Forms.Label lblNoterLaRecetteProvenance;
        private System.Windows.Forms.Button btnRetourAccueil;
    }
}