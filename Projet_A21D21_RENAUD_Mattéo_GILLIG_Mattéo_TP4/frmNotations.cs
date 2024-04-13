using Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4;

namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    public partial class frmNotations : Form
    {
        public frmNotations()
        {
            InitializeComponent();
            this.codeRecette = -1;
            //Ici, on vient forcément depuis l'accueil, donc panel de consultation
            // + je masque le bouton de noter une recette
            //(car on vient les consulter, pas les noter)
            this.btnRetourNotations.Visible = false;
            this.pnlConsultationAvis.Visible = true;
            this.pnlNoterLaRecetteDeProvenance.Visible = false;
            this.btnRetourAccueil.Visible = true;
        }
        public frmNotations(int codeRecette, string nomRecette)
        {
            InitializeComponent();
            this.codeRecette = codeRecette;
            //Par là, on vient forcément depuis la recette, donc je mets la notation
            //Je mets le Panel qui affiche le nom de la recette visible (il sera sur la ComboBox, donc l'utilisateur ne pourra pas changer)
            this.pnlNoterLaRecetteDeProvenance.Visible = true;
            //Je désactive la ComboBox au cas où (pour ne pas qu'il puisse changer de recette)
            this.cboRecettes.Enabled = false;
            this.lblNoterLaRecetteProvenance.Text = "Noter la recette : \n" + nomRecette;
            this.btnRetourAccueil.Visible = false;
        }

        //Le code de la recette d'où l'on vient (si on vient par la recette) et le nombre d'étoiles pour l'avis
        private int codeRecette;
        private int nbEtoileConsultationAvis = 1;
        private void frmNotations_Load(object sender, EventArgs e)
        {          
            /*
            try
            {
                //On créé la table 1 seule fois évidemment           
                frmAccueil.connec.Open();

                //Partie connectée (pour insérer dans la base)
                //Je créé la table en dur dans la base de données pour pouvoir y stocker les avis de façon permanente
                string requeteCreation = @"CREATE TABLE tblAvis (
                                        codeRecette INTEGER,
                                        pseudo TEXT,
                                        dateAvis DATE,
                                        etoiles INT,
                                        commentaire TEXT,
                                        PRIMARY KEY (codeRecette,pseudo,dateAvis),
                                        FOREIGN KEY (codeRecette) REFERENCES Recettes(codeRecette)
                                        )";


                OleDbCommand cd = new OleDbCommand(requeteCreation, frmAccueil.connec);
                cd.ExecuteNonQuery();
            }
            //L'exception qui gère l'erreur d'accès à la base
            catch (InvalidExpressionException)
            {
                MessageBox.Show("Erreur d'accès à la base.", "Erreur d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //L'exception qui gère l'erreur dans la requête SQL
            catch (OleDbException)
            {
                MessageBox.Show("Erreur dans la requête SQL.", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Ce que je fais dans tous les cas
            finally
            {
                //Si la connexion est ouverte
                if (frmAccueil.connec.State == ConnectionState.Open)
                {
                    //Je ferme la connexion
                    frmAccueil.connec.Close();
                }
            }*/

            //Je mets en commentaire, car comme on a déjà créé la table dans la base, elle existe déjà
            /*
            try
            {
                //Création de la table des avis en local
                DataTable tblAvis = new DataTable();
                tblAvis.TableName = "tblAvis";

                //Création des 5 colonnes nécessaires
                DataColumn colonne1 = tblAvis.Columns.Add("CodeRecette", typeof(Int32));
                DataColumn colonne2 = tblAvis.Columns.Add("Pseudo", typeof(String));
                DataColumn colonne3 = tblAvis.Columns.Add("DateAvis", typeof(DateTime));
                DataColumn colonne4 = tblAvis.Columns.Add("Note", typeof(Int32));
                DataColumn colonne5 = tblAvis.Columns.Add("Appréciation", typeof(String));

                //Ajout de la table au DataSet
                frmAccueil.monDS.Tables.Add(tblAvis);

                //Mise en place de la clé primaire (une clé primaire triple)
                //Car on dit que plusieurs personnes peuvent laisser des avis différents sur les mêmes recettes à des dates différentes
                DataColumn champPK1 = frmAccueil.monDS.Tables["tblAvis"].Columns["CodeRecette"];
                DataColumn champPK2 = frmAccueil.monDS.Tables["tblAvis"].Columns["Pseudo"];
                DataColumn champPK3 = frmAccueil.monDS.Tables["tblAvis"].Columns["DateAvis"];

                //Ajout de la clé primaire
                frmAccueil.monDS.Tables["tblAvis"].PrimaryKey = new DataColumn[] { champPK1, champPK2, champPK3 };

                //Mise en place de clé étrangère
                ForeignKeyConstraint FK_tblAvisRecette = new ForeignKeyConstraint(       
                    frmAccueil.monDS.Tables["Recettes"].Columns["codeRecette"],
                    frmAccueil.monDS.Tables["tblAvis"].Columns["CodeRecette"]);

                //Ajout de la clé étrangère
                frmAccueil.monDS.Tables["tblAvis"].Constraints.Add(FK_tblAvisRecette);              
            }
            catch(System.ArgumentException)
            {
                MessageBox.Show("Erreur dans la création de la table locale des avis.", "Erreur de création", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(System.Data.DuplicateNameException)
            {
                MessageBox.Show("La table locale existe déjà.", "Table dèjà existante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            //Je charge les ComboBox
            ChargerLesComboBox();
            //Je mets en place les images pour les étoiles
            ChargerImagesEtoiles();
            //Je recharge le Label du choix du nombre d'étoiles pour la consultation des avis
            RechargerLabelEtoileConsultationAvis();
            //J'affiche les avis les plus pertinents
            AffichierLesAvisLesPlusPertinents();
        }

        private void ChargerLesComboBox()
        {
            //Chargement des ComboBox avec le dataset directement en local (comme cela, pas besoin de boucle)
            //La ComboBox pour noter une recette
            cboRecettes.DataSource = frmAccueil.monDS.Tables["Recettes"];
            cboRecettes.DisplayMember = "description";
            cboRecettes.ValueMember = "codeRecette";

            //Je place la ComboBox sur la recette (si je viens d'une recette)
            if (codeRecette != -1)
                cboRecettes.SelectedIndex = codeRecette - 1;
            else
                cboRecettes.SelectedIndex = -1;

            //La ComboBox pour choisir une recette pour voir les avis
            cboRecettesConsulationAvis.DataSource = frmAccueil.monDS.Tables["Recettes"];
            cboRecettesConsulationAvis.DisplayMember = "description";
            cboRecettesConsulationAvis.ValueMember = "codeRecette";
        }

        private void ChargerImagesEtoiles()
        {
            try
            {
                //Je mets en place les images d'étoiles pour le UCEtoile
                Image img1 = Image.FromFile("../../Images/etoile_remplis.png");
                Image img2 = Image.FromFile("../../Images/etoile_vide.png");
                ucEtoiles.MettreEnPlaceImage(img1, img2);
            }
            catch (System.IO.FileNotFoundException erreur)
            {
                MessageBox.Show("L'image n'a pas été trouvée.\n" + erreur, "Image non-trouvée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            //Je quitte le formulaire
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            //J'enlève les 2 ErrorProvider
            errSaisie.SetError(txtPseudo, "");
            errSaisie.SetError(cboRecettes, "");

            //Si j'ai choisi une recette dans la ComboBox
            if (cboRecettes.SelectedIndex!=-1)
            {
                int codeRecetteAvis;
                string pseudo;
                string date;
                string datePourLocal;
                int note;
                string appreciation;

                //Si la TextBox du pseudo n'est pas vide
                if (txtPseudo.Text!=String.Empty)
                {
                    //Je récupère le code de la recette
                    codeRecetteAvis = int.Parse(cboRecettes.SelectedValue.ToString());
                    //Je récupère le pseudo
                    pseudo=txtPseudo.Text;
                    //Je remplace les apostrophes par 2 apostrophes (pour normaliser ce caractère dans la requête SQL (car les chaînes de caractères sont entre des quotes simples, donc pour normaliser, on en met 2 en SQL ici))
                    pseudo = pseudo.Replace("'", "''");

                    //Je récupère la date actuelle
                    date=DateTime.Now.ToString();
                    //Je mets dans une autre variable pour la date dans la table en locale
                    datePourLocal = date;

                    //Je récupère le jour, le mois et l'année
                    string jour = date.Substring(0, 2);
                    string mois = date.Substring(3, 2);
                    string annee = date.Substring(6, 4);
                    string heuresMinutes = date.Substring(11);

                    //Je construis la date pour cette version de SQL
                    //Le format pour ici
                    date = "#"+mois+"/"+jour+"/"+annee+" "+heuresMinutes+"#";//format de la date a voir lequel est bon
    
                    //MessageBox.Show(date);

                    //Je récupère la note en fonction du nombre d'étoiles
                    note = RecupereNoteEtoiles();

                    //Je récupère le commentaire (s'il en a mis un) et je normalise les apostrophes
                    appreciation=txtDeGensPeterDeThunes.Text;
                    appreciation = appreciation.Replace("'", "''");

                    //Mise en local de l'avis
                    try
                    {
                        //Je créé une nouvelle ligne à la table des avis
                        DataRow ligne = frmAccueil.monDS.Tables["tblAvis"].NewRow();
                        //Je remplis les cases
                        ligne[0] = codeRecetteAvis;
                        ligne[1] = pseudo;
                        ligne[2] = datePourLocal;
                        ligne[3] = note;
                        ligne[4] = appreciation;
                        //J'ajoute la ligne
                        frmAccueil.monDS.Tables["tblAvis"].Rows.Add(ligne);
                    }
                    //L'erreur qui gère la clé primaire
                    catch(System.Data.ConstraintException)
                    {
                        MessageBox.Show("Nous n'avons pas pu insérer votre opinion dans la base de données.", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
                    }
                    //L'erreur qui gère la clé étrangère
                    catch(InvalidConstraintException)
                    {
                        MessageBox.Show("La recette n'existe pas.", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
                    }

                    try
                    { 
                        //Maintenant, j'insère la même chose dans la base en dur

                        //La requête d'insertion
                        string requete="INSERT INTO tblAvis (codeRecette,pseudo,dateAvis,etoiles,commentaire) VALUES ("+ codeRecetteAvis.ToString()+", '"+pseudo+"',"+ date + ", "+note+", ";
                        
                        //Si l'utilisateur n'a pas mis de commentaires, je mets NULL dans la base
                        if (txtDeGensPeterDeThunes.Text == String.Empty)
                            requete += "NULL)";
                        //Sinon, il y a son avis
                        else
                            requete += "'" + appreciation + "')";

                        //MessageBox pour nous, pour voir la requête
                        //MessageBox.Show(requete);

                        //J'ouvre la connexion, créé un objet Command et exécute la requête avec un ExecuteNonQuery (car requête LMD) et affiche un MessageBox pour informer l'utilisateur
                        frmAccueil.connec.Open();
                        OleDbCommand cd = new OleDbCommand(requete, frmAccueil.connec);
                        cd.ExecuteNonQuery();
                        ReinitialiseAvis();
                        MessageBox.Show("Votre avis a été insérer avec succès dans la base.", "Insertion d'avis utilisteur",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    //L'exception qui gère l'erreur d'accès à la base
                    catch (System.InvalidOperationException)
                    {
                            MessageBox.Show("Erreur d'accès à la base.", "Erreur d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    //L'exception qui gère l'erreur dans la requête SQL
                    catch (OleDbException)
                    {
                            MessageBox.Show("Erreur dans la requête SQL.", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //Ce que je fais dans tous les cas
                    finally
                    {
                        //Si la connexion est ouverte
                        if (frmAccueil.connec.State == ConnectionState.Open)
                        {
                            //Je ferme la connexion
                            frmAccueil.connec.Close();
                        }
                    }
                }
                //Sinon, s'il n'y a pas de pseudo
                else
                {
                    //ErrorProvider pour dire qu'il faut un pseudo
                    errSaisie.SetError(txtPseudo, "Entrez votre pseudo");
                }
            }
            //Sinon, s'il n'y a pas de recette sélectionnée
            else
            {
                //ErrorProvider pour dire qu'il faut choisir une recette
                errSaisie.SetError(cboRecettes, "Choisissez une recette");
            }         
        }

        //La méthode qui récupère la note en fonction du nombre d'étoiles
        private int RecupereNoteEtoiles()
        {
            int note = 0;
            //Je parcours chaque PictureBox du UserControl des étoiles
            foreach(PictureBox imgBoite in ucEtoiles.Controls.OfType<PictureBox>())
            {
                //Je récupère la dernière partie du Tag (qui est le bouléen pour savoir si l'étoile est remplie ou non)
                if(int.Parse(imgBoite.Tag.ToString().Substring(1,1))==1)
                {
                    //J'augmente la note
                    note++;
                }
            }
            //Je renvoie
            return note;
        }

        //La méthode qui réinitialise les champs après l'enregistrement dans la base
        private void ReinitialiseAvis()
        {
            //Je vide les 2 TextBox
            this.txtDeGensPeterDeThunes.Text = String.Empty;
            this.txtPseudo.Text = String.Empty;
            //J'appelle la méthode qui remet à 1 étoile dans le UserControl
            ucEtoiles.RemettreAUneEtoile();
        }

        private void btnRetourNotations_Click(object sender, EventArgs e)
        {
            //Le Panel de consultation des avis devient invisible et je ne mets pas de recette sélectionnée dans la ComboBox
            pnlConsultationAvis.Visible = false;
            this.cboRecettes.SelectedIndex = -1;
        }

        private void btnVoirAvis_Click(object sender, EventArgs e)
        {
            //Le Panel de consultation devient visible, celui de la recette de provenance invisible et je réactive la ComboBox
            pnlConsultationAvis.Visible = true;
            this.pnlNoterLaRecetteDeProvenance.Visible = false;
            this.cboRecettes.Enabled=true;
        }

        //Les méthodes Click des 4 CheckBox pour le filtre des avis
        //Elles affichent ou pas le filtre correspondant
        private void chkRecette_Click(object sender, EventArgs e)
        {
            bool etat = cboRecettesConsulationAvis.Visible;
            etat = !etat;
            cboRecettesConsulationAvis.Visible = etat;
        }

        private void chkPseudo_CheckedChanged(object sender, EventArgs e)
        {
            bool etat = pnlPseudoConsultationAvis.Visible;
            etat = !etat;
            pnlPseudoConsultationAvis.Visible = etat;
        }

        private void chkNote_CheckedChanged(object sender, EventArgs e)
        {
            bool etat = pnlNbEtoilesConsultationAvis.Visible;
            etat = !etat;
            pnlNbEtoilesConsultationAvis.Visible = etat;
        }

        private void chkCommentaire_CheckedChanged(object sender, EventArgs e)
        {
            bool etat = pnlCommentaireConsultationAvis.Visible;
            etat = !etat;
            pnlCommentaireConsultationAvis.Visible=etat;
        }

        private void btnRechercheAvis_Click(object sender, EventArgs e)
        {
            //Je supprime tous les Controls du Panel d'affichage des avis
            pnlVoirAvis.Controls.Clear();

            //Je récupère dans des bouléens si l'utilisateur veut des filtres
            bool veutRecette = chkRecette.Checked;
            bool veutPseudo = chkPseudo.Checked;
            bool veutNote = chkNote.Checked;
            bool veutCommentaire = (chkCommentaire.Checked&&rdbCommentaireSansFiltre.Checked);
            bool veutCommentairePrecis = (chkCommentaire.Checked && rdbCommentaireAvecFiltre.Checked);
            bool veutTout = (veutRecette && veutPseudo && veutNote && (veutCommentaire || veutCommentairePrecis));

            //Une variable pour la quantité de filtres que l'utilisateur veut
            int nbVeut = 0;
            if (veutRecette)
                nbVeut++;
            if (veutPseudo)
                nbVeut++;
            if (veutNote)
                nbVeut++;
            if (veutCommentaire || veutCommentairePrecis)
                nbVeut++;

            //Un MessageBox pour nous pour voir l'état des bouléens
            //MessageBox.Show("Affichage des bouléens\nRecette : "+veutRecette.ToString()+"\nPseudo : "+veutPseudo.ToString()+"\nNote : "+veutNote.ToString()+"\nCommentaire\nCommentaire avec filtre : "+veutCommentaire.ToString()+"\nCommentaire avec filtre :"+veutCommentairePrecis.ToString());

            try
            {
                //La requête
                string requete = "SELECT * FROM tblAvis";

                //S'il veut au moins un filtre, je rajoute WHERE
                if (nbVeut != 0)
                    requete += " WHERE ";

                //S'il veut une recette
                if(veutRecette)
                {
                    requete+="codeRecette=" + int.Parse(cboRecettesConsulationAvis.SelectedValue.ToString());
                }

                //S'il veut un pseudo
                if(veutPseudo)
                {
                    //Et qu'il a aussi voulu une recette (je rajoute un AND)
                    if (veutRecette)
                        requete += " AND ";

                    //Je mets en minuscule (avec ToLower() et utilise LCASE) + j'utilise LIKE et je normalise les apostrophes et remplace les espaces par des % (n'importe quel caractère) + aussi au début et à la fin
                    requete += " LCASE(pseudo) LIKE '%" + txtPseudoConsulationAvis.Text.Replace("'", "''").Replace(" ","%").ToLower()+"%'";
                }

                //S'il veut une note
                if(veutNote)
                {
                    //Et qu'il a déjà voulu une recette ou un pseudo (je rajoute un AND)
                    if (veutRecette||veutPseudo)
                        requete += " AND ";

                    requete += " etoiles=" + nbEtoileConsultationAvis;
                }

                //S'il veut un commentaire ou un commentaire précis
                if (veutCommentaire || veutCommentairePrecis)
                {
                    //Et qu'il a déjà voulu une recette, un pseudo ou une note (je rajoute un AND)
                    if (veutPseudo || veutNote || veutRecette)
                        requete += " AND ";

                    //Si on veut n'importe quel commentaire (donc là où ce n'est pas NULL)
                    if (veutCommentaire)
                        requete += " commentaire IS NOT NULL";
                    //Sinon, on va rechercher un commentaire avec comme pour le pseudo LCASE,LIKE,normalisation des apostropes et remplacement des espaces par % + aussi au début et à la fin
                    else if (veutCommentairePrecis)
                        requete += " LCASE(commentaire) LIKE '%" + txtCommentairePrecis.Text.Replace("'", "''").Replace(" ", "%").ToLower()+"%'";
                }

                //MessageBox pour nous pour voir la requête
                //MessageBox.Show(requete);

                //J'ouvre la connexion
                frmAccueil.connec.Open();

                //Un objet Command
                OleDbCommand cd = new OleDbCommand(requete, frmAccueil.connec);
                //Et un OleDbDataReader qui va lire le flux de données (donc ExecuteReader)
                OleDbDataReader oldr=cd.ExecuteReader();
                //La méthode qui va afficher les avis (je lui donne en paramêtre le OleDbDataReader)
                AfficherLesAvis(oldr);               
            }
            //L'exception qui gère l'erreur d'accès à la base
            catch (System.InvalidOperationException)
            {
                 MessageBox.Show("Erreur d'accès à la base.", "Erreur d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //L'exception qui gère l'erreur dans la requête SQL
            catch (OleDbException)
            {
                 MessageBox.Show("Erreur dans la requête SQL.", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Ce que je fais dans tous les cas
            finally
            {
                 //Si la connexion est ouverte
                 if (frmAccueil.connec.State == ConnectionState.Open)
                 {
                      //Je ferme la connexion
                      frmAccueil.connec.Close();
                 }
            }               
        }

        //Les 2 méthodes click des boutons Plus ou Moins pour choisir la note
        private void btnPlus_Click(object sender, EventArgs e)
        {
            //J'augmente la variable
            nbEtoileConsultationAvis++;
            //Si c'est plus grand que 5, je reste à 5
            if (nbEtoileConsultationAvis > 5)
                nbEtoileConsultationAvis = 5;
            //Je recharge le Label
            RechargerLabelEtoileConsultationAvis();
        }

        private void btnMoins_Click(object sender, EventArgs e)
        {
            //Je diminue la variable
            nbEtoileConsultationAvis--;
            //Si c'est plus petit que 1, je reste à 1
            if (nbEtoileConsultationAvis < 1)
                nbEtoileConsultationAvis = 1;
            //Je recharge le Label
            RechargerLabelEtoileConsultationAvis();
        }

        private void RechargerLabelEtoileConsultationAvis()
        {
            //Mise en place du texte du nombre d'étoiles pour la consultation des avis
            lblNoteConsultationAvis.Text = nbEtoileConsultationAvis.ToString() + " étoile";
            //Si j'ai plus que 1 étoile, je mets le mot au pluriel
            if (nbEtoileConsultationAvis != 1)
                lblNoteConsultationAvis.Text += "s";
        }

        //La méthode qui affiche les avis les plus pertinents
        //(Utilisée au chargement du formulaire pour avoir un truc stylé avec déjà des avis intéressants)
        private void AffichierLesAvisLesPlusPertinents()
        {
            try
            {
                //J'ouvre la connexion
                frmAccueil.connec.Open();

                //Les avis que je dis pertinents sont ceux avec 5 étoiles et un commentaire
                string requete = @"SELECT * FROM tblAvis 
                                WHERE etoiles=5 AND commentaire IS NOT NULL";

                OleDbCommand cd = new OleDbCommand(requete, frmAccueil.connec);
                OleDbDataReader oldr = cd.ExecuteReader();
                AfficherLesAvis(oldr);
            }
            //L'exception qui gère l'erreur d'accès à la base
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Erreur d'accès à la base.", "Erreur d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //L'exception qui gère l'erreur dans la requête SQL
            catch (OleDbException)
            {
                MessageBox.Show("Erreur dans la requête SQL.", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Ce que je fais dans tous les cas
            finally
            {
                //Si la connexion est ouverte
                if (frmAccueil.connec.State == ConnectionState.Open)
                {
                    //Je ferme la connexion
                    frmAccueil.connec.Close();
                }
            }
        }

        int pourAfficherTextePertinent = 0;
        private void AfficherLesAvis(OleDbDataReader oldr)
        {
            int haut = 10;
            int gauche = 10;
            int nbAvis = 0;

            //Les 2 images des étoiles
            Image img1=null;
            Image img2=null;

            try
            {
                img1 = Image.FromFile("../../Images/etoile_remplis.png");
                img2 = Image.FromFile("../../Images/etoile_vide.png");

            }
            catch (System.IO.FileNotFoundException erreur)
            {
                MessageBox.Show("L'image pour l'étoile n'a pas été trouvée.\n" + erreur, "Image non-trouvée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Tant qu'il y a des lignes à lire
            while (oldr.Read())
            {
                string nomRec = "";

                //Je récupère le nom de la recette pour cet avis particulier
                foreach (DataRow ligne in frmAccueil.monDS.Tables["Recettes"].Rows)
                {
                    //Si le code de la recette correspond avec le code de la recette de la ligne
                    if (int.Parse(ligne[0].ToString()) == int.Parse(oldr.GetValue(0).ToString()))
                    {
                        //Je récupère le nom de la recette
                        nomRec = ligne[1].ToString();
                    }
                }

                //Je créé un UCAvis avec en paramêtre, le nom de la recette, le pseudo, la date, la note et le commentaire
                UCAvis ucAvis = new UCAvis(nomRec, oldr.GetValue(1).ToString(), oldr.GetValue(2).ToString(), oldr.GetInt32(3), oldr.GetValue(4).ToString());

                //Position
                ucAvis.Top = haut;
                ucAvis.Left = gauche;
                //Visible
                ucAvis.Visible = true;

                try
                {
                    //Je mets en place les images
                    ucAvis.GetUCEtoiles().MettreEnPlaceImage(img1, img2);
                }
                catch (System.IO.FileNotFoundException erreur)
                {
                    MessageBox.Show("L'image n'a pas été trouvée.\n" + erreur, "Image non-trouvée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //J'affiche le nombre d'étoiles de l'avis, puis adapte les images à la taille du UC et inverse l'ordre des images (car elles apparaissent à l'envers)
                ucAvis.GetUCEtoiles().AfficherNombreEtoilePourConsultationAvis(oldr.GetInt32(3));
                ucAvis.GetUCEtoiles().AdapterImageALaTailleDuUserControl();
                ucAvis.GetUCEtoiles().InverserOrdreEtoiles();

                //Incrémente les variables de position pour le prochain avis
                gauche += ucAvis.Width + 10;
                if (gauche > pnlConsultationAvis.Width - ucAvis.Width)
                {
                    haut += ucAvis.Height + 10;
                    gauche = 10;
                }
                //J'ajoute le composant
                pnlVoirAvis.Controls.Add(ucAvis);

                //J'augmente la variable qui compte le nombre d'avis
                nbAvis++;
            }

            //Si pas de lignes
            if (!oldr.HasRows)
            {
                //Petit label pour dire qu'il n'y a aucun avis qui correspond à la recherche
                Label lblPasDeLigne = new Label();
                lblPasDeLigne.AutoSize = true;
                lblPasDeLigne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                lblPasDeLigne.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblPasDeLigne.ForeColor = System.Drawing.Color.Red;
                lblPasDeLigne.Location = new System.Drawing.Point(242, 101);
                lblPasDeLigne.Name = "lbltemp";
                lblPasDeLigne.Size = new System.Drawing.Size(587, 31);
                lblPasDeLigne.TabIndex = 0;
                lblPasDeLigne.Text = "Aucun avis ne correspond à votre recherche";
                this.pnlVoirAvis.Controls.Add(lblPasDeLigne);
            }

            if(pourAfficherTextePertinent!=0)
            {
                //Si un seul avis correspond à la recherche
                if(nbAvis==1)
                    lblAvisPertinents.Text = "Un seul avis correspond à votre recherche";
                //Sinon, si plusieurs
                else
                    lblAvisPertinents.Text = nbAvis + " avis correspondent à votre recherche";
            }
            pourAfficherTextePertinent++;
        }

        private void btnRetourAccueil_Click(object sender, EventArgs e)
        {
            //Je ferme le formulaire
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
