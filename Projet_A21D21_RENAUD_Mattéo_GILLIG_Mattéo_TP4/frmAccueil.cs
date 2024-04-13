using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    public partial class frmAccueil : Form
    {
        public frmAccueil()
        {
            InitializeComponent();
        }

        //La chaîne de connexion, la connexion et le DataSet local
        //En static pour n'avoir qu'un seul DataSet, chaîne de connexion et connexion pour le projet + en public pour que les autres classes y aient accès
        //Comme on utilise une base .accdb, on n'utilise plus le provider JET, mais le ACE.OLEDB
        //Si cela ne marche pas, il faut installer Acces (il se peut qu'il faille ou pas régler des choses dans les options de Visual Studio 2022 et cela devrait marcher)
        //(Comme par exemple désactiver l'option Préférée en 32 bits dans Les propriétés du projet, puis dans la catégorie Build)
        //public static string chcon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Elève\source\repos\Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4\baseFrigo.accdb";

        //La deuxième base de données
        //C'est une base .mdb, donc on utilise le provider JET
        public static string chcon = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\Users\Elève\source\repos\Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4\baseFrigov2023.mdb";
        public static OleDbConnection connec = new OleDbConnection();  
        public static DataSet monDS = new DataSet();

        //Un objet Timer qui est un chronomêtre qui va nous permettre de déclencher des évènements à un intervalle défini
        //On va s'en servir pour que toutes les 5 secondes, l'écran d'accueil change
        System.Timers.Timer chronometre = new System.Timers.Timer();

        private void frmAccueil_Load(object sender, EventArgs e)
        {
            try
            {
                //Chargement en local du DataSet
                ChargementDataSetLocal();
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
                if (connec.State == ConnectionState.Open)
                {
                    //Je ferme la connexion
                    connec.Close();
                }
            }

            //La méthode qui affiche une première fois une image alétoire pour l'écran d'accueil
            AfficherImageAleatoire();
            //La méthode qui configure le chronomêtre
            ConfigurationChrometre();

            //3 méthodes pour les chargements nécessaires
            ChargerFamilleIngredients();
            ChargeAttributsUC();
            ChargerTypePlat();

            //La méthode qui charge les temps de cuisson dans la ComboBox du UserControl UCTempsCuisson
            ChargerTempsCuisson();

            try
            {
                //Liaison de données pour l'affichage en étapes par étapes
                //Je créé une relation entre le codeRecette de la table des recettes et le codeRecette de la table des étapes
                DataRelation relation = new DataRelation("maRelation",
                    frmAccueil.monDS.Tables["Recettes"].Columns["codeRecette"],
                    frmAccueil.monDS.Tables["EtapesRecette"].Columns["codeRecette"]);

                //J'ajoute ma relation au DataSet
                frmAccueil.monDS.Relations.Add(relation);
            }
            //L'exception qui gère le fait que le nom d'un objet est en double dans le DataSet
            catch(DuplicateNameException)
            {
                MessageBox.Show("Le nom est déjà présent dans la base de données pour un autre objet.", "Nom en double",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //L'exception qui gère une erreur de contrainte dans le DataSet
            catch(InvalidConstraintException)
            {
                MessageBox.Show("Erreur de contrainte dans la relation.", "Erreur de contrainte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //La procédure qui charge en local le DataSet
        private void ChargementDataSetLocal()
        {
            //Je donne la chaîne de connexion et ouvre la connexion
            connec.ConnectionString = chcon;
            connec.Open();

            //Un DROP TABLE tblAvis pour supprimer la table des avis
            //(Utilisé lors des tests dans la création)
            //Attention à ne pas avoir Access ouvert avec la base en lecture car sinon, il y a une erreur (il faut alors fermer Access)
            //OleDbCommand temp = new OleDbCommand("DROP TABLE tblAvis", frmAccueil.connec);
            //temp.ExecuteNonQuery();
            

            //Table des erreurs à enlever
            //OleDbCommand cd = new OleDbCommand("DROP TABLE [Table des erreurs]", connec);
            //cd.ExecuteNonQuery();

            //Je récupère dans une table les noms des tables de la base grâce à la méthode GetOlDbSchemaTable qui nous permet d'obtenir le schéma de notre base de données
            //Le nom des tables sera à la 3ème colonne (le type est à la 4ème colonne (c'est pour cela qu'il y a "TABLE"))
            DataTable schemaTable = connec.GetOleDbSchemaTable(
                OleDbSchemaGuid.Tables,
                new Object[] { null, null, null, "TABLE" });

            //Pour chaque ligne dans la DataTable
            foreach (DataRow ligne in schemaTable.Rows)
            {
                //La requête
                string requete = "select * from " + ligne[2].ToString();
                //Le OleDbAdapter qui fait la requête et remplit ensuite le DataSet avec toutes les tables
                OleDbDataAdapter da = new OleDbDataAdapter(requete, connec);
                da.Fill(monDS, ligne[2].ToString());
            }
        }

        //Un objet Random pour l'aléatoire
        public static Random rnd = new Random();

        //La méthode qui affiche une image aléatoire
        private void AfficherImageAleatoire()
        {
            //J'obtiens un nombre en 1 et 8 (9 est exclu) (car on a 8 images dans l'écran d'accueil)
            int numImage = rnd.Next(1,9);
            //Je construis le chemin vers l'image (on fait deux fois .. car quand on lance l'application, on est dans le dossier /bin/Debug, donc on doit remonter 2 fois)
            string chemin = "../../Img_Acceuil/Fond_Accueil_"+numImage.ToString()+".jpg";

            try
            {
                //Je mets l'image en fond d'écran et en mode Strech qui permet de faire en sorte qu'une image remplisse le rectangle de destination
                this.BackgroundImage = Image.FromFile(chemin);
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            catch(System.IO.FileNotFoundException)
            {
                //Pas d'image alors
            }
        }

        //La méthode qui configure le chronomêtre
        private void ConfigurationChrometre()
        {
            //Le temps de l'intervalle est de 5s
            double temps = 5000;
            //Je créé un objet Timer avec mon intervalle de temps
            chronometre = new System.Timers.Timer(temps);
            //Je fais en sorte que le chronomêtre se répète et qu'il soit activé
            chronometre.AutoReset = true;
            chronometre.Enabled = true;
            //Je lance le chronomêtre
            chronometre.Start();
            //Je mets en évènement quand le chronomêtre arrive au bout la méthode qui change l'image de fond
            chronometre.Elapsed += ChangeImage;
        }

        //La procédure qui change d'image de fond
        private void ChangeImage(Object source, ElapsedEventArgs e)
        {
            //Appelle la procédure qui affiche une image aléatoire
            AfficherImageAleatoire();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            //Quitter l'application
            Application.Exit();
        }

        private void btnDemarrer_Click(object sender, EventArgs e)
        {
            //La méthode qui affiche la page des ingrédients
            AfficherChoixIngredients();          
        }

        private void AfficherChoixIngredients()
        {
            //Je mets en pause le chronomêtre
            chronometre.Stop();

            //Le bouton démarrer, quitter et le label de bienvenue ne sont plus visibles
            btnDemarrer.Visible = false;
            btnQuitter.Visible = false;
            lblBienvenue.Visible = false;
            btnVoirAvis.Visible = false;

            //Le panel du choix des ingrédients et le bouton de retour à l'écran d'accueil deviennent visibles
            pnlChoixIngrdients.Visible = true;
            btnRetourAccueil.Visible = true;

            string chemin = "../../Images/fond_cuisine.jpg";

            try
            {
                //Je mets l'image en fond d'écran et en mode Strech qui permet de faire en sorte qu'une image remplisse le rectangle de destination
                this.BackgroundImage = Image.FromFile(chemin);
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            catch(System.IO.FileNotFoundException)
            {
                MessageBox.Show("Le chemin vers l'image du fond de cuisine", "Mauvais chemin de fichier",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnRetourAccueil_Click(object sender, EventArgs e)
        {
            //On fait dans cette méthode l'inverse que dans ChoixIngredients

            //Je relance le chronomêtre
            chronometre.Start();

            //Le bouton démarrer, quitter et le label de bienvenue sont visibles
            btnDemarrer.Visible = true;
            btnQuitter.Visible = true;
            btnVoirAvis.Visible = true;
            lblBienvenue.Visible = true;

            //Le panel du choix des ingrédients et le bouton de retour à l'écran d'accueil ne sont plus visibles
            pnlChoixIngrdients.Visible = false;
            btnRetourAccueil.Visible = false;

            AfficherImageAleatoire();
        }

        private void ChargerFamilleIngredients()
        {
            //J'appelle la méthode du UserControl pour générer les familles d'ingrédients
            ucListeFamilleIngredients.GenererBoutonsFamille();
        }

        private void ChargeAttributsUC()
        {
            //Dans notre projet, il n'y a que 4 UserControl suivants qui sont liés (ils ont un attribut qui est la classe du UserControl pour communiquer entre eux)
            // + ils ont spécialement été faits pour ce projet (c'est pour cela qu'ils sont dans le projet et pas dans la bibliothèque comme les autres)
            // - UCListeFamilleIngredients
            // - UCAfficheIngredientsDetails
            // - UCIngredientsChoisis
            // - UCBoutonAffichageIntegraleEtapes

            //J'utilise des Setters pour mettre en place les différents attributs
            ucListeFamilleIngredients.SetControleListeIngredients(ucAfficheIngredientsDetails);
            ucAfficheIngredientsDetails.SetUCListeFamille(ucIngredientsChoisis);
            ucIngredientsChoisis.SetUCAfficheIngredients(ucAfficheIngredientsDetails);
        }

        //Les 2 méthodes qui affichent ou cachent le panel de choix du type de plat, budget et temps de cuisson
        private void btnEtapeTypePlatBudgetTemps_Click(object sender, EventArgs e)
        {
            pnlTypePlatBudgetTemps.Visible = true;
        }

        private void btnRevenirChoixIngredients_Click(object sender, EventArgs e)
        {
            pnlTypePlatBudgetTemps.Visible = false;
        }

        //La méthode qui charge les types de plats
        private void ChargerTypePlat()
        {
            //Une liste pour le nom des plats et une autre en parallèle pour les codes
            List<string> plat = new List<string>();
            List<int> codePlat = new List<int>();

            //Je parcours la table Catégories
            foreach(DataRow ligne in monDS.Tables["Catégories"].Rows)
            {
                //Et je récupère le nom du plat et le code
                plat.Add(ligne[1].ToString());
                codePlat.Add(int.Parse(ligne[0].ToString()));
            }

            //La méthode qui va générer les plats disponibles
            ucTypePlat.GenererTypePlat(plat,codePlat);
        }
        private void ChargerTempsCuisson()
        {
            //Une liste d'entiers où je mets les temps de cuisson
            List<int> tempsDeCuisson = new List<int>();

            //Je parcours la table des recettes
            foreach (DataRow ligne in monDS.Tables["Recettes"].Rows)
            {
                //Si le temps de cuisson (qui est à la colonne n°4 (donc index 3)) n'est pas déjà dans la liste
                if (!tempsDeCuisson.Contains(int.Parse(ligne[3].ToString())))
                    //Je l'ajoute
                    tempsDeCuisson.Add(int.Parse(ligne[3].ToString()));
            }

            //Je trie du plus petit au plus grand temps de cuisson
            tempsDeCuisson.Sort();

            //La méthode qui remplit la ComboBox du temps de cuisson avec les temps de cuisson disponibles
            ucTempsCuissons.RemplirComboBoxTemps(tempsDeCuisson);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            //Je récupère le code de la recette, le code de la catégorie et le temps de cuisson grâce aux Getters des UserControls
            int codeCategorie = ucTypePlat.GetCodeCategorie();
            int laThune = ucBudget.GetArgent();
            int tempsCuisson = ucTempsCuissons.RecupererTempsDeCuisson();
            //Je récupère l'image de fond
            Image imageFond = this.BackgroundImage;

            //Je transmets toutes ces informations + la chaîne de connexion et la connexion aux formulaires qui affichent les recettes
            frmResultatRecettes lesRecettes = new frmResultatRecettes(ucIngredientsChoisis.GetIngredientsChoisis(),ucIngredientsChoisis.GetCodeIngredientsChoisis(),codeCategorie,laThune,tempsCuisson,imageFond);
            //Je mets le formulaire d'accueil
            lesRecettes.SetFrmAccueil(this);
            //Affichage du formulaire
            lesRecettes.ShowDialog();
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            //Je réinitialise le choix de l'utilisateur avec les méthodes des UserControls
            ucBudget.ReinitialiserRadioBoutton();
            ucTypePlat.ReinitialiserRadioBoutton();
            ucTempsCuissons.ReinitialiserCboTempsCuisson();
        }

        private void btnVoirAvis_Click(object sender, EventArgs e)
        {
            //Je créé le formulaire de notation pour consulter les avis
            frmNotations feuilleNotation = new frmNotations();
            feuilleNotation.ShowDialog();
        }

        //La méthode pour revenir à la page d'accueil
        //(c'est utilisé quand on est dans la recette et qu'on veut revenir directement à l'écran d'accueil)
        public void RetourAccueil(object sender,EventArgs e)
        {
            btnRevenirChoixIngredients_Click(sender, e);
            btnRetourAccueil_Click(sender, e);
        }
    }
}
