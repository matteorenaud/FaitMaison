using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4;

namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    public partial class frmDetailsRecette : Form
    {
        public frmDetailsRecette()
        {
            InitializeComponent();
            //Si de base je n'ai aucun paramêtre, j'affiche d'abords la recette en intégrale
            pnlIntegral.Visible = true;
            pnlEtapeParEtape.Visible = false;
        }
     

        public frmDetailsRecette(int codeRecette,Button btnEnvoyeur)
        {
            InitializeComponent();
            //Je mets le code de la recette et récupère le texte du bouton
            this.numRecette = codeRecette;
            string txtBtn = btnEnvoyeur.Text;

            //Comme le tag est déjà utilisé pour le code de la recette,
            //afin de savoir si on a cliqué sur Intégral ou Etapes par Etapes
            //Je regarde le texte du bouton et j'ai choisi de chercher la chaîne "par" afin de savoir quel affichage je dois faire
            if (txtBtn.ToLower().Contains("par"))
            {
                //Le Panel Integral n'est pas visible et le Panel Etapes l'est + les boutons pour changer de mode
                pnlIntegral.Visible = false;
                pnlEtapeParEtape.Visible = true;
                btnChangeEnEtapes.Visible = false;
                btnChangeEnIntegral.Visible = true;
            }
            //Sinon, si on clique sur Integral
            else
            {
                //Le Panel Integral est visible et le Panel Etapes ne l'est pas + les boutons pour changer de mode
                pnlIntegral.Visible = true;
                pnlEtapeParEtape.Visible = false;
                btnChangeEnEtapes.Visible = true;
                btnChangeEnIntegral.Visible = false;
            }
        }

        //J'ai le code de la recette, le nombre d'étapes de la recette, l'image de fond, le formulaire d'accueil et celui des résultats
        private int numRecette;
        private int nbEtapes = 0;
        private Image imageFond;
        frmAccueil formAccueil=null;
        frmResultatRecettes formResultatsRecette = null;

        //Les liaisons pour la liaison de données
        //Pour la partie étapes par étapes
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        BindingSource bs3 = new BindingSource();
        //Un BindingNavigator qui est un objet qui va me permettre de faire des actions avec les données (ex : consultation des données)
        BindingNavigator bn = new BindingNavigator();

        //2 listes de tableaux
        // - une avec toutes les informations pour chaque étape
        // - une autre avec toutes les informations pour les ingrédients
        List<string[]> libelleEtape = new List<string[]>();
        List<string[]> ingredients = new List<string[]>();

        //Des chaînes de caractères pour :
        // - le nom de la recette
        // - le nombre de personnes
        // - le temps de cuisson
        // - le chemin vers l'image
        // - le budget
        // - la description (s'il y en a une)
        string nomRecette = "";
        string nbPers = "";
        string tempsCuisson = "";
        string cheminImg = "";
        string budget = "";
        string description = "";

        private void frmDetailsRecette_Load(object sender, EventArgs e)
        {
            //Le Label Invisible qui me sert de transition pour le BindingSource pour afficher l'image (avec le bon chemin) devient vide
            lblInvisible.Text = String.Empty;
                   
            try
            {
                //J'ouvre la connexion
                frmAccueil.connec.Open();

                //La requête pour récupérer les informations globales sur la recette
                string requete = "SELECT * FROM Recettes WHERE codeRecette = " + numRecette;

                //Un objet OleDbCommand pour exécuter la requête
                OleDbCommand cd = new OleDbCommand(requete, frmAccueil.connec);

                //Un OleDbDataReader qui va lire le flux de données
                //Avec un ExecuteReader(), car je n'ai pas qu'une seule valeur, mais une seule ligne
                OleDbDataReader oldr = cd.ExecuteReader();
        
                int nbPassage = 0;
                //Tant qu'il y a des lignes à lire et que je n'ai pas encore fait un seul passage
                //(car je ne veux qu'une recette (même si normalement, il ne devrait y avoir qu'une seule recette grâce à la clé primaire))
                while (oldr.Read()&&nbPassage!=1)
                {
                    //Je récupère ce dont j'ai besoin
                    nomRecette = oldr.GetValue(1).ToString();
                    nbPers = oldr.GetValue(2).ToString();
                    tempsCuisson = oldr.GetValue(3).ToString();
                    cheminImg = "../../Images_Prof/" + oldr.GetValue(4).ToString();
                    budget = oldr.GetValue(5).ToString();
                    description = oldr.GetValue(6).ToString();
                    //J'incrémente le nombre de passages
                    nbPassage++;
                }

                //Je mets en place les différents textes du UserControl qui récapitule la recette
                ucRecapRecette.TexteBudget = "Budget : "+ConvertionCodeBudget(int.Parse(budget));
                ucRecapRecette.TexteDescription = description;
                ucRecapRecette.TexteNombrePersonne = "Nombre de personne : "+ nbPers;
                ucRecapRecette.TexteNomRecette = nomRecette;
                ucRecapRecette.TexteTempsCuisson = "Temps de cuisson : "+tempsCuisson+" min";
                ucRecapRecette.SetCheminImage(cheminImg);
                ucRecapRecette.ChargerImage();

                //La 2ème requête pour récupérer les instructions des étapes (pour en affichage intégral)
                string requete2 = "SELECT * FROM EtapesRecette WHERE codeRecette = "+numRecette+" ORDER BY numEtape";

                OleDbCommand cd2=new OleDbCommand(requete2,frmAccueil.connec);
                oldr = cd2.ExecuteReader();

                //Tant qu'il y a des lignes à lire
                while (oldr.Read())
                {
                    //Je créé un tableau de 3 cases (car je vais ranger 3 informations différentes concernant les étapes)
                    string[] tab = new string[3];
                    tab[0] = oldr.GetValue(1).ToString();//Numéros de l'étape
                    tab[1] = oldr.GetValue(2).ToString();//Texte de l'étape
                    tab[2] = "../../Images_Prof/" + oldr.GetValue(3).ToString();//Nom du fichier auquel je rajoute ../../Images_Prof/
                    //J'ajoute le tableau à la liste
                    libelleEtape.Add(tab);
                }

                //La 3ème requête pour récupérer les informations sur les ingrédients pour la recette
                //Je fais une jointure pour avoir en même temps le nom des ingrédients de la table Ingrédients et les quantités de chaque ingrédient de la table IngrédientsRecette
                string requete3 = @"SELECT i.libIngredient, ir.quantite, ir.unité 
                                    FROM IngrédientsRecette ir, Ingrédients i 
                                    WHERE ir.codeRecette="+numRecette +@" 
                                    AND i.codeIngredient=ir.codeIngredient";

                OleDbCommand cd3 = new OleDbCommand(requete3, frmAccueil.connec);
                oldr = cd3.ExecuteReader();

                //Tant qu'il y a des lignes à lire
                while(oldr.Read())
                {
                    //Je créé aussi un tableau de 3 cases (car j'ai besoin aussi de 3 informations sur les ingrédients)
                    string[] tab = new string[3];
                    tab[0] = oldr.GetValue(0).ToString();//Nom de l'ingrédient
                    tab[2] = oldr.GetValue(1).ToString();//Quantité
                    tab[1] = oldr.GetValue(2).ToString();//Unité
                    //J'ajoute à la liste
                    ingredients.Add(tab);
                }

                //Je créé un UserControl pour la recette intégrale qui, lui, génèrera le nombre d'étapes
                UCRecetteIntegrale ucEtapesRectte = new UCRecetteIntegrale(ingredients,libelleEtape);

                //Position et taille
                ucEtapesRectte.Top = ucRecapRecette.Height + 20;
                ucEtapesRectte.Left = 30;
                ucEtapesRectte.Height = 400;
                ucEtapesRectte.Width = 1000;
                //J'ajoute
                pnlIntegral.Controls.Add(ucEtapesRectte);             
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
            }

            //Si l'attribut n'est pas null
            if (imageFond != null)
            {
                //Je mets en place l'image de fond
                this.BackgroundImage = imageFond;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
          
            try
            {
                //Mise en place de la liaison de données pour le mode étapes par étapes
                bs1.DataSource = frmAccueil.monDS;
                bs1.DataMember = "Recettes";

                bs2.DataSource = bs1;
                bs2.DataMember = "maRelation";

                bn.BindingSource = bs2;
                Controls.Add(bn);

                //Mise en place des liaisons de données sur les composants
                this.ucEtape.GetLabelNomRecette().DataBindings.Add(new Binding("Text", bs1, "description"));
                this.ucEtape.GetLabelEtape().DataBindings.Add(new Binding("Text", bs2, "numEtape"));
                this.ucEtape.GetTxtDeGensPeterDeThunes().DataBindings.Add(new Binding("Text", bs2, "texteEtape"));
                this.lblInvisible.DataBindings.Add(new Binding("Text", bs2, "imageEtape"));

                //Maintenant les ingrédients
                ucEtapeIngredients.GenererIngredients(ingredients);

            }
            //L'erreur qui gère le fait qu'un nom d'objet est en double
            catch(DuplicateNameException)
            {
                MessageBox.Show("Un nom d'objet est en double dans le DataSet", "Noms identiques", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //La position du BindingSource
            //Je fais numRecette-1 car sinon je suis une recette trop loin
            //Car il commence à la position 0 et les codes des recettes ne commencent qu'à la position 1
            bs1.Position = numRecette-1;

            //Je compte le nombre d'étapes de la recette
            int nbEtapesMax = CompterEtapes();
            //Et je mets en place ce nombre d'étapes max dans le UCEtape
            ucEtape.MettreNombreEtapesMax(nbEtapesMax);

            //Je place le BindingNavigator sur la première étape
            btnPremier_Click(sender, e);
            RechargerImage();
        }

        //La méthode qui renvoie le libellé du budget en fonction du code
        private string ConvertionCodeBudget(int code)
        {
            string unMaxDeThunes="";
            if (code == 1)
                unMaxDeThunes = "Bas";
            else if (code == 2)
                unMaxDeThunes = "Moyen";
            else
                unMaxDeThunes = "Haut";

            return unMaxDeThunes;
        }

        //2 setters pour les formulaires d'accueil et de résultat des recherches
        public void SetFrmAccueil(frmAccueil accueil)
        {
            this.formAccueil = accueil;
        }
        public void SetFrmResultatRecherche(frmResultatRecettes resultatRecette)
        {
            this.formResultatsRecette = resultatRecette;
        }

        //Quand on passe en mode intégral
        private void btnChangeEnIntegral_Click(object sender, EventArgs e)
        {
            pnlEtapeParEtape.Visible = false;
            pnlIntegral.Visible = true;
            btnChangeEnIntegral.Visible = false;
            btnChangeEnEtapes.Visible = true;
        }

        //Quand on passe en mode étapes par étapes
        private void btnChangeEnEtapes_Click(object sender, EventArgs e)
        {
            pnlEtapeParEtape.Visible = true;
            pnlIntegral.Visible = false;
            btnChangeEnIntegral.Visible = true;
            btnChangeEnEtapes.Visible = false;
            RechargerImage();
        }

        private void btnRevenirRecettes_Click(object sender, EventArgs e)
        {
            //Le DialogResult est DialogResult.Cancel (annuler)
            this.DialogResult = DialogResult.Cancel;
        }

        //Les 4 méthodes des boutons pour la navigation entre les étapes
        private void btnPremier_Click(object sender, EventArgs e)
        {
            ucEtapeIngredients.Visible = false;
            ucEtape.Visible = true;

            //Je vide le texte du Label étape
            ucEtape.GetLabelEtape().Text = String.Empty;
            //Je place le BindingSource sur le 1er élément
            this.bs2.MoveFirst();

            RechargerImage();
            estEnEtapesIngredients = false;
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            ucEtapeIngredients.Visible = false;
            ucEtape.Visible = true;

            //Je vide le texte du Label étape
            ucEtape.GetLabelEtape().Text = String.Empty;
            //Je place le BindingSource sur l'élément précédent
            this.bs2.MovePrevious();

            RechargerImage();
            estEnEtapesIngredients = false;
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            ucEtapeIngredients.Visible = false;
            ucEtape.Visible = true;

            //Je vide le texte du Label étape
            ucEtape.GetLabelEtape().Text = String.Empty;
            //Je place le BindingSource sur l'élément suivant
            this.bs2.MoveNext();

            RechargerImage();
            estEnEtapesIngredients = false;
        }

        private void btnDernier_Click(object sender, EventArgs e)
        {
            ucEtapeIngredients.Visible = false;
            ucEtape.Visible = true;

            //Je vide le texte du Label étape
            ucEtape.GetLabelEtape().Text = String.Empty;
            //Je place le BindingSource sur le dernier élément
            this.bs2.MoveLast();

            RechargerImage();
            estEnEtapesIngredients = false;
        }

        //La méthode qui compte le nombre d'étapes de la recette
        private int CompterEtapes()
        {
            int res = 0;
            //Je compte le nombre d'éléments dans le BindingSource
            res = bs2.Count;
            return res;
        }

        //La méthode qui recharge l'image en étapes par étapes
        private void RechargerImage()
        {
            //Je récupère le chemin de l'image grâce au LabelInvisible (auquel j'ai attribué un Binding avec le nom de l'image dans la base de données)
            string chemin = "../../Images_Prof/" + lblInvisible.Text;

            try
            {
                //Je mets en place l'image dans le UCEtape
                ucEtape.GetPcbImage().Image = Image.FromFile(chemin);
            }
            //L'exception qui gère le fait que le fichier n'a pas été trouvé
            catch(FileNotFoundException)
            {
                try
                {
                    //Alors, chemin vers l'image par défaut
                    ucEtape.GetPcbImage().Image = Image.FromFile("../../Images_Prof/lama.png");
                }
                //La même exception (si vraiment le fichier n'existe pas non plus)
                catch (FileNotFoundException)
                {
                    //Alors, il n'y a vraiment pas d'image
                }
            }

            //Je recharge aussi le label du nombre d'étapes
            ucEtape.GetLabelEtape().Text="Etape : "+(bs2.Position+1)+" sur "+bs2.Count;
        }

        //Un bouléen pour savoir si on est dans les ingrédients du mode étape par étape
        bool estEnEtapesIngredients = false;

        private void btnEtapeAfficheIngredients_Click(object sender, EventArgs e)
        {
            //Je récupère l'inverse de l'état bouléen
            estEnEtapesIngredients = !estEnEtapesIngredients;
            //Je mets s'il est visible ou non
            ucEtapeIngredients.Visible = estEnEtapesIngredients;
            //L'état d'affichage du UCEtape est l'inverse de celui de l'affichage des ingrédients en étape
            ucEtape.Visible = !estEnEtapesIngredients;
        }

        private void btnNoterRecette_Click(object sender, EventArgs e)
        {
            //Je créé le formulaire de notations + affichage
            frmNotations note = new frmNotations(numRecette,nomRecette);
            note.ShowDialog();
        }

        //Le bouton qui permet de revenir directement à l'accueil
        private void btnRetourAccueil_Click(object sender, EventArgs e)
        {
            //Je ferme ce formulaire
            this.DialogResult = DialogResult.Cancel;

            if (formResultatsRecette != null)
            {
                //Puis, je ferme le formulaire des résultats
                formResultatsRecette.DialogResult = DialogResult.Cancel;

                if (formAccueil != null)
                {
                    //Et enfin, j'appelle la méthode de retour à l'accueil du formulaire d'accueil
                    formAccueil.RetourAccueil(sender, e);
                }
            }
        }

        //Le nombre d'étapes totales
        int nbEtapeGen = 0;

        //La méthode qui génère le PDF
        private void btnPDF_Click(object sender, EventArgs e)
        {
            nbEtapeGen = CompterEtapes();

            //Je crée le document PDF
            PdfDocument docu = new PdfDocument();

            //J'ajoute les pages qu'on aura besoin
            PdfPage page = docu.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            PdfPage page2 = docu.AddPage();
            XGraphics gfx2 = XGraphics.FromPdfPage(page2);
            PdfPage page3 = docu.AddPage(); ;
            XGraphics gfx3 = XGraphics.FromPdfPage(page3);

            //Je définit les différentes polices d'écriture ainsi que le crayon qui va être utiliser
            XFont font = new XFont("Verdana", 12, XFontStyle.Bold);
            XFont titre = new XFont("Verdana", 12, XFontStyle.Bold | XFontStyle.Underline);
            XPen pen = new XPen(XColors.Black, 1);

            //J'écrit tout d'abord les informations importants
            gfx.DrawString("Récapitulatifs pour : " + nomRecette, titre, XBrushes.Black,
                new XRect(0, 5, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString("Temps de cuisson : " + tempsCuisson + " min", font, XBrushes.Black,
               new XRect(300, 30, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Nombre de personne : " + nbPers, font, XBrushes.Black,
               new XRect(300, 50, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Budget : " + budget, font, XBrushes.Black,
               new XRect(300, 70, page.Width, page.Height), XStringFormats.TopLeft);


            try
            {
                //Je teste la longueur de la description pour que cela ne sorte pas de la page
                //Içi, je met la description sur 2 lignes
                if (description.Length >= 20 && description.Length < 40)
                {
                    //Je scinde la description en 2partie
                    String RetourLigne = "";
                    String Partie2 = "";

                    //La première partie aura une longueur de 23 caractères sauf si le mot n'est pas terminé
                    int i = 23;
                    for (int j = 0; j < 23; j++)
                    {
                        RetourLigne += description[j];
                    }

                    //Si le mot n'est pas terminé, j'ajoute les caractères jusqu'à trouver un espace qui indique la fin du mot
                    while (description[i] != ' ' && i < description.Length)
                    {
                        RetourLigne += description[i];
                        i++;
                    }
                    i++;

                    //La deuxième partie aura le reste de la description comme longueur
                    while (i < description.Length)
                    {
                        Partie2 += description[i];
                        i++;
                    }

                    //J'affiche d'abord la première partie
                    description = RetourLigne;
                    gfx.DrawString("Description : " + RetourLigne, font, XBrushes.Black,
                    new XRect(300, 90, page.Width, page.Height), XStringFormats.TopLeft);

                    //J'affiche ensuite la deuxième partie
                    gfx.DrawString(Partie2, font, XBrushes.Black,
                    new XRect(300, 110, page.Width, page.Height), XStringFormats.TopLeft);
                }

                //Dans ce cas présent, je met la description sur 3 lignes
                else if (description.Length >= 40 && description.Length < 90)
                {
                    //Je scinde la description en 3 parties
                    String RetourLigne = "";
                    String Partie2 = "";
                    String Partie3 = "";

                    //La première partie aura une longueur de 23 caractère sauf si le mot n'est pas terminé
                    int i = 23;
                    for (int j = 0; j < 23; j++)
                    {
                        RetourLigne += description[j];
                    }

                    //Si le mot n'est pas terminé, j'ajoute les caractères jusqu'à trouver un espace qui indique la fin du mot
                    while (description[i] != ' ')
                    {
                        RetourLigne += description[i];
                        i++;
                    }

                    //J'incrémente i de 1 pour skip l'espace
                    i++;

                    //La deuxième partie aura une longueur de 55 caractère sauf si le mot n'est pas terminé
                    int lim = 55;
                    for (int k = i; k < lim && k < description.Length; k++)
                    {
                        Partie2 += description[k];

                    }
                    //Si le mot n'est pas terminé, j'ajoute les caractères jusqu'à trouver un espace qui indique la fin du mot
                    while (description[lim] != ' ' && lim < description.Length)
                    {
                        Partie2 += description[lim];
                        lim++;
                    }

                    //J'incremente lim de 1 pour skip l'espace
                    lim++;

                    //La troisième partie aura la fin de la description comme longueur
                    while (lim < description.Length)
                    {
                        Partie3 += description[lim];
                        lim++;
                    }
                    int PosText = 90;

                    //J'affiche d'abord la première partie
                    gfx.DrawString("Description : " + RetourLigne, font, XBrushes.Black,
                    new XRect(300, PosText, page.Width, page.Height), XStringFormats.TopLeft);

                    //Je saute la ligne en ajoutant 20px a la position des ordonnées
                    PosText += 20;

                    //J'affiche ensuite la deuxième partie
                    gfx.DrawString(Partie2, font, XBrushes.Black,
                    new XRect(300, PosText, page.Width, page.Height), XStringFormats.TopLeft);
                    PosText += 20;

                    //J'affiche ensuite la troisième partie
                    gfx.DrawString(Partie3, font, XBrushes.Black,
                    new XRect(300, PosText, page.Width, page.Height), XStringFormats.TopLeft);
                }

                //Içi sur 4lignes
                else if (description.Length >= 90)
                {
                    //Je scinde la description en 4 partie
                    String RetourLigne = "";
                    String Partie2 = "";
                    String Partie3 = "";
                    String Partie4 = "";

                    //La première partie aura une longueur de 23 caractère 
                    int i = 23;
                    //J'ajoute les 23 premiers caractères
                    for (int j = 0; j < 23; j++)
                    {
                        RetourLigne += description[j];
                    }

                    //Si le mot n'est pas terminé, j'ajoute les caractères jusqu'à trouver un espace qui indique la fin du mot
                    while (description[i] != ' ')
                    {
                        RetourLigne += description[i];
                        i++;
                    }

                    //J'incrément i de 1 pour skip l'espace
                    i++;
                    //La deuxième partie aura une longueur de 27 caractère
                    int lim = 55;
                    //J'ajoute les caractères a partir de l'index i jusqu'à 55 
                    for (int k = i; k < lim; k++)
                    {
                        Partie2 += description[k];

                    }
                    //Si le mot n'est pas terminé, j'ajoute les caractères jusqu'à trouver un espace qui indique la fin du mot
                    while (description[lim] != ' ')
                    {
                        Partie2 += description[lim];
                        lim++;
                    }
                    //J'incrémente de 1 pour skip l'espace
                    lim++;
                    //La troisième partie aura une longueur 35 caractère
                    int lim2 = 90;
                    //J'ajoute les caractères à partir de l'index lim jusqu'à 90
                    for (int m = lim; m < lim2 && m < description.Length; m++)
                    {
                        Partie3 += description[m];

                    }
                    //Si le mot n'est pas terminé, j'ajoute les caractères jusqu'à trouver un espace qui indique la fin du mot
                    while (description[lim2] != ' ')
                    {
                        Partie3 += description[lim2];
                        lim2++;
                    }

                    //J'incrémente de 1 pour skip l'espace
                    lim2++;

                    //J'ajoute à la partie 4 la fin de la description
                    while (lim2 < description.Length)
                    {
                        Partie4 += description[lim2];
                        lim2++;
                    }

                    //La position de y pour les différentes lignes
                    int PosText = 90;

                    //Partie 1
                    gfx.DrawString("Description : " + RetourLigne, font, XBrushes.Black,
                    new XRect(300, PosText, page.Width, page.Height), XStringFormats.TopLeft);

                    //J'ajoute 20 sur la position pour la ligne suivante
                    PosText += 20;

                    //Partie 2
                    gfx.DrawString(Partie2, font, XBrushes.Black,
                    new XRect(300, PosText, page.Width, page.Height), XStringFormats.TopLeft);

                    PosText += 20;

                    //Partie 3
                    gfx.DrawString(Partie3, font, XBrushes.Black,
                    new XRect(300, PosText, page.Width, page.Height), XStringFormats.TopLeft);

                    PosText += 20;

                    //Partie 4
                    gfx.DrawString(Partie4, font, XBrushes.Black,
                    new XRect(300, PosText, page.Width, page.Height), XStringFormats.TopLeft);
                }

                //Sinon je met la description sur une ligne
                else
                {
                    //Je met le mot Description uniquement si une desc de la recette est présente
                    if (description.Length > 0)
                    {
                        gfx.DrawString("Description : " + description, font, XBrushes.Black,
                        new XRect(300, 90, page.Width, page.Height), XStringFormats.TopLeft);
                    }
                }
            }

            //J'intercepte içi les expections IndexOutOfRange et je met la description obligatoirement sur 2 lignes
            catch (IndexOutOfRangeException)
            {
                //Même code que avant pour 2 parties

                String RetourLigne = "";
                String Partie2 = "";
                int i = 15;
                for (int j = 0; j < 15; j++)
                {
                    RetourLigne += description[j];
                }
                while (description[i] != ' ' && i < description.Length)
                {
                    RetourLigne += description[i];
                    i++;
                }
                i++;

                while (i < description.Length)
                {
                    Partie2 += description[i];
                    i++;
                }

                description = RetourLigne;
                gfx.DrawString("Description : " + RetourLigne, font, XBrushes.Black,
                new XRect(300, 90, page.Width, page.Height), XStringFormats.TopLeft);

                gfx.DrawString(Partie2, font, XBrushes.Black,
                new XRect(300, 110, page.Width, page.Height), XStringFormats.TopLeft);

            }

            //Je met en place l'image de la recette
            XImage img;
            try
            {
                img = XImage.FromFile(cheminImg);
            }
            catch (System.IO.FileNotFoundException)
            {
                img = XImage.FromFile("../../Images_Prof/lama.png");
            }

            gfx.DrawImage(img, 65, 40, 130, 130);

            //Position après le récap
            int posTop = 220;



            //J'affiche les ingredients
            gfx.DrawString("Ingredients", titre, XBrushes.Black,
               new XRect(0, 185, page.Width, page.Height), XStringFormats.TopCenter);

            //Je vais scinder les ingredients en 2 colonnes
            //Je fait la première colonne
            for (int i = 0; i < (ingredients.Count / 2); i++)
            {
                try
                {
                    //Je récupère les différentes informations stockée dans ingredients
                    String Quantite = ingredients[i][2];
                    String Unite = ingredients[i][1];
                    String NomIngre = ingredients[i][0];
                    String ingreF = "- " + Quantite + " " + Unite + " de " + NomIngre;

                    //Je teste si l'entièreté de l'ingredient avec ses infos dépassent les 37 caractères
                    //Même code que pour 2 partie de la description
                    if (ingreF.Length >= 37)
                    {
                        String RetourLigne = "";
                        String Partie2 = "";
                        int k = 34;
                        for (int j = 0; j < 34; j++)
                        {
                            RetourLigne += ingreF[j];
                        }
                        while (ingreF[k] != ' ' && k < ingreF.Length)
                        {
                            RetourLigne += ingreF[k];
                            k++;
                        }
                        k++;

                        while (k < ingreF.Length)
                        {
                            Partie2 += ingreF[k];
                            k++;
                        }


                        gfx.DrawString(RetourLigne, font, XBrushes.Black,
                            new XRect(45, posTop, page.Width, page.Height), XStringFormats.TopLeft);
                        posTop += 20;

                        gfx.DrawString(Partie2, font, XBrushes.Black,
                            new XRect(45, posTop, page.Width, page.Height), XStringFormats.TopLeft);
                        posTop += 20;
                    }
                    else
                    {
                        gfx.DrawString("- " + Quantite + " " + Unite + " de " + NomIngre, font, XBrushes.Black,
                            new XRect(45, posTop, page.Width, page.Height), XStringFormats.TopLeft);
                        posTop += 20;
                    }
                }

                //Je catch les possibles exceptions indexOutOfRange et met l'ingredients obligatoirement dans une seule partie
                catch (IndexOutOfRangeException)
                {
                    String Quantite = ingredients[i][2];
                    String Unite = ingredients[i][1];
                    String NomIngre = ingredients[i][0];
                    gfx.DrawString("- " + Quantite + " " + Unite + " de " + NomIngre, font, XBrushes.Black,
                            new XRect(45, posTop, page.Width, page.Height), XStringFormats.TopLeft);
                    posTop += 20;
                }
            }

            //Position y de la 2ème colonne
            int posColonne2 = 220;

            //Même chose que pour la deuxième colonne
            for (int i = (ingredients.Count / 2); i < ingredients.Count; i++)
            {
                try
                {
                    String Quantite = ingredients[i][2];
                    String Unite = ingredients[i][1];
                    String NomIngre = ingredients[i][0];
                    String ingreF = "- " + Quantite + " " + Unite + " de " + NomIngre;

                    if (ingreF.Length >= 37)
                    {
                        String RetourLigne = "";
                        String Partie2 = "";
                        int k = 34;
                        for (int j = 0; j < 34; j++)
                        {
                            RetourLigne += ingreF[j];
                        }
                        while (ingreF[k] != ' ' && k < ingreF.Length)
                        {
                            RetourLigne += ingreF[k];
                            k++;
                        }
                        k++;

                        while (k < ingreF.Length)
                        {
                            Partie2 += ingreF[k];
                            k++;
                        }


                        gfx.DrawString(RetourLigne, font, XBrushes.Black,
                            new XRect(330, posColonne2, page.Width, page.Height), XStringFormats.TopLeft);
                        posColonne2 += 20;

                        gfx.DrawString(Partie2, font, XBrushes.Black,
                            new XRect(330, posColonne2, page.Width, page.Height), XStringFormats.TopLeft);
                        posColonne2 += 20;
                    }
                    else
                    {
                        gfx.DrawString("- " + Quantite + " " + Unite + " de " + NomIngre, font, XBrushes.Black,
                            new XRect(330, posColonne2, page.Width, page.Height), XStringFormats.TopLeft);
                        posColonne2 += 20;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    String Quantite = ingredients[i][2];
                    String Unite = ingredients[i][1];
                    String NomIngre = ingredients[i][0];
                    gfx.DrawString("- " + Quantite + " " + Unite + " de " + NomIngre, font, XBrushes.Black,
                            new XRect(330, posColonne2, page.Width, page.Height), XStringFormats.TopLeft);
                    posColonne2 += 20;
                }
            }

            //Position de la fin des ingredients + 40, position à partir de laquelle je peux afficher les étapes
            int posTop2 = posColonne2 + 40;

            //Nombre d'étape permettant de mettre une limite sur une page pour pas dépasser la page et ainsi ne pas afficher l'étape
            int nbEtape = 0;

            //Position y de la page 2 (ne sera pas utiliser si pas de page 2)
            int posPage2 = 15;

            //Position y de la page 3 (ne sera pas utiliser si pas de page 3)
            int posPage3 = 15;

            //Je commence les différentes boucles pour trouver les UC des etapes de la recette
            //Je parcours d'abord les UCRecetteIntegrale présent dans le panel du formulaire
            foreach (UCRecetteIntegrale recInte in pnlIntegral.Controls.OfType<UCRecetteIntegrale>())
            {
                //Je pacours ensuites les panels dans l'UCRecetteIntegrale
                foreach (Panel pnl in recInte.Controls.OfType<Panel>())
                {
                    //Je trouve enfin les UCEtapesRecette
                    foreach (UCEtapesRecette etp in pnl.Controls.OfType<UCEtapesRecette>())
                    {

                        //Je teste si le nombre d'étape afficher est inférieur à 3, si oui j'écris sur la permière page sinon page suivante
                        if (nbEtape < 3)
                        {
                            try
                            {
                                //Je créer les 2 points premiers point qui vont créer la ligne du haut du cadre autour de l'étape
                                XPoint x = new XPoint(4, posTop2 - 5);
                                XPoint y = new XPoint(page.Width - 4, posTop2 - 5);

                                //Je dessinge la ligne entre x et y
                                gfx.DrawLine(pen, x, y);

                                //J'écrit le numéros d'étape de la recette
                                gfx.DrawString(etp.GetNumEtape().ToString(), titre, XBrushes.Black,
                                new XRect(10, posTop2, page.Width, page.Height), XStringFormats.TopLeft);

                                //J'ajoute 15 a posTop2 qui représente la position y sur la page pour sauter une ligne
                                posTop2 += 15;

                                //Je créer l'image de l'étape
                                XImage imgEtp;

                                //J'essaie de trouver si l'image existe sinon image par défault
                                try
                                {
                                    imgEtp = XImage.FromFile(etp.GetChemin());
                                }
                                catch (System.IO.FileNotFoundException)
                                {
                                    imgEtp = XImage.FromFile("../../Images_Prof/lama.png");
                                }

                                //J'affiche l'image
                                gfx.DrawImage(imgEtp, 10, posTop2, 75, 75);

                                //J'ajoute 26 à la pos y
                                posTop2 += 26;

                                //J'affiche l'instruction
                                String Instruction = etp.GetInstruction();

                                //Si l'instruction est plus grande ou égale à 50 et est inférieur à 110, je met l'instruction sur 2 lignes
                                if (etp.GetInstruction().Length >= 50 && etp.GetInstruction().Length < 110)
                                {
                                    String RetourLigne = "";
                                    String Partie2 = "";

                                    //i est l'index de la partie 2
                                    int i = 50;

                                    //Jusqu'à l'index 50 j'ajoute les caratères à la partie 1 (RetourLigne)
                                    for (int j = 0; j < 50; j++)
                                    {
                                        RetourLigne += Instruction[j];
                                    }

                                    //Si le mot n'est pas terminé, j'ajoute les caractères jusqu'à trouver un espace qui indique la fin du mot
                                    while (Instruction[i] != ' ')
                                    {
                                        RetourLigne += Instruction[i];
                                        i++;
                                    }

                                    //J'incrément de 1 pour skip l'espace
                                    i++;

                                    //J'ajoute le reste de l'instruction à la partie 2
                                    while (i < etp.GetInstruction().Length)
                                    {
                                        Partie2 += Instruction[i];
                                        i++;
                                    }

                                    //J'affiche la partie 1
                                    gfx.DrawString(RetourLigne, font, XBrushes.Black,
                                    new XRect(110, posTop2, page.Width, page.Height), XStringFormats.TopLeft);

                                    //J'ajoute 20 pour passer à la ligne suivante
                                    posTop2 += 20;

                                    //J'affiche la partie 2
                                    gfx.DrawString(Partie2, font, XBrushes.Black,
                                    new XRect(110, posTop2, page.Width, page.Height), XStringFormats.TopLeft);
                                }


                                //Si l'instruction fait plus que 110 caractère je la met sur 3 ligne
                                else if (etp.GetInstruction().Length >= 110)
                                {
                                    String RetourLigne = "";
                                    String Partie2 = "";
                                    String Partie3 = "";

                                    //La deuxième partie commence à l'index 54
                                    int i = 54;

                                    //J'ajoute les caractère à la partie 1 jusqu'au 54ème caractère
                                    for (int j = 0; j < 54; j++)
                                    {
                                        RetourLigne += Instruction[j];
                                    }

                                    //Si le mot n'est pas terminé, j'ajoute les caractères jusqu'à trouver un espace qui indique la fin du mot
                                    while (Instruction[i] != ' ')
                                    {
                                        RetourLigne += Instruction[i];
                                        i++;
                                    }

                                    //J'incrémente de 1 pour skip l'espace
                                    i++;

                                    //La deuxième partie démarre à l'index i et termine à l'index 112
                                    int lim = 112;
                                    for (int k = i; k < 112; k++)
                                    {
                                        Partie2 += Instruction[k];

                                    }

                                    //Si le mot n'est pas terminé, j'ajoute les caractères jusqu'à trouver un espace qui indique la fin du mot
                                    while (Instruction[lim] != ' ')
                                    {
                                        Partie2 += Instruction[lim];
                                        lim++;
                                    }

                                    //J'incrémente de 1 pour skip l'espace
                                    lim++;

                                    //J'ajoute la fin de l'étape à la troisième partie
                                    while (lim < etp.GetInstruction().Length)
                                    {
                                        Partie3 += Instruction[lim];
                                        lim++;
                                    }

                                    //Je créer PosText qui équivaut à posTop2 qui sera la pos y du texte
                                    int PosText = posTop2;

                                    Instruction = RetourLigne;

                                    //J'affiche la partie 1
                                    gfx.DrawString(RetourLigne, font, XBrushes.Black,
                                    new XRect(110, PosText, page.Width, page.Height), XStringFormats.TopLeft);

                                    //J'ajoute 20 à la position y du Texte
                                    PosText += 20;

                                    //J'affiche la partie 2
                                    gfx.DrawString(Partie2, font, XBrushes.Black,
                                    new XRect(110, PosText, page.Width, page.Height), XStringFormats.TopLeft);

                                    //J'ajoute 20 à la position y du Texte
                                    PosText += 20;

                                    //J'affiche la partie 3
                                    gfx.DrawString(Partie3, font, XBrushes.Black,
                                    new XRect(110, PosText, page.Width, page.Height), XStringFormats.TopLeft);
                                }

                                //Si l'instruction fait moins que 50 caractère alors j'affiche l'instruction sur une seule ligne
                                else
                                {
                                    gfx.DrawString(Instruction, font, XBrushes.Black,
                                    new XRect(110, posTop2, page.Width, page.Height), XStringFormats.TopLeft);
                                }

                                //J'ajoute 75 pour mettre de l'espace entre cette étape et la prochaine
                                posTop2 += 75;

                                //J'incrémente le nombre d'étape
                                nbEtape++;

                                //Je créer les point x2 et y2 qui vont servir pour terminer le cadre
                                XPoint x2 = new XPoint(4, posTop2 - 15);
                                XPoint y2 = new XPoint(page.Width - 4, posTop2 - 15);

                                //Je dessine les lignes restantes pour former un cadre autour de l'etape
                                gfx.DrawLine(pen, x2, y2);
                                gfx.DrawLine(pen, x, x2);
                                gfx.DrawLine(pen, y, y2);
                            }

                            //Si je catch une expetion indexOutOfRange j'essaie tout de même de mettre l'instruction sur 2 lignes 
                            //Sinon je la met sur une ligne
                            catch (IndexOutOfRangeException)
                            {
                                try
                                {
                                    String Instruction = etp.GetInstruction();
                                    if (etp.GetInstruction().Length >= 50)
                                    {
                                        String RetourLigne = "";
                                        String Partie2 = "";
                                        int i = 50;
                                        for (int j = 0; j < 50; j++)
                                        {
                                            RetourLigne += Instruction[j];
                                        }
                                        while (Instruction[i] != ' ')
                                        {
                                            RetourLigne += Instruction[i];
                                            i++;
                                        }


                                        i++;

                                        while (i < etp.GetInstruction().Length)
                                        {
                                            Partie2 += Instruction[i];
                                            i++;
                                        }

                                        Instruction = RetourLigne;
                                        gfx.DrawString(RetourLigne, font, XBrushes.Black,
                                        new XRect(110, posTop2, page.Width, page.Height), XStringFormats.TopLeft);
                                        posTop2 += 20;
                                        gfx.DrawString(Partie2, font, XBrushes.Black,
                                        new XRect(110, posTop2, page.Width, page.Height), XStringFormats.TopLeft);
                                    }
                                    else
                                    {
                                        gfx.DrawString(Instruction, font, XBrushes.Black,
                                        new XRect(110, posTop2, page.Width, page.Height), XStringFormats.TopLeft);
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    gfx.DrawString(etp.GetInstruction(), font, XBrushes.Black,
                                        new XRect(110, posTop2, page.Width, page.Height), XStringFormats.TopLeft);
                                }
                                posTop2 += 75;
                                nbEtape++;
                                XPoint x = new XPoint(4, posTop2 - 140);
                                XPoint y = new XPoint(page.Width - 4, posTop2 - 140);
                                XPoint x2 = new XPoint(4, posTop2 - 25);
                                XPoint y2 = new XPoint(page.Width - 4, posTop2 - 25);
                                gfx.DrawLine(pen, x2, y2);
                                gfx.DrawLine(pen, x, x2);
                                gfx.DrawLine(pen, y, y2);
                            }
                        }

                        //Si le nombre d'étape dépasse 3 mais est inférieur à 9 alors je dessine sur la page suivante
                        //Même code que pour les étapes de la page une
                        else if (nbEtape >= 3 && nbEtape < 9)
                        {
                            try
                            {
                                XPoint x = new XPoint(4, posPage2 - 5);
                                XPoint y = new XPoint(page.Width - 4, posPage2 - 5);
                                gfx2.DrawLine(pen, x, y);
                                gfx2.DrawString(etp.GetNumEtape().ToString(), titre, XBrushes.Black,
                                new XRect(10, posPage2, page2.Width, page2.Height), XStringFormats.TopLeft);
                                posPage2 += 15;
                                XImage imgEtp;
                                try
                                {
                                    imgEtp = XImage.FromFile(etp.GetChemin());
                                }
                                catch (System.IO.FileNotFoundException)
                                {
                                    imgEtp = XImage.FromFile("../../Images_Prof/lama.png");
                                }
                                gfx2.DrawImage(imgEtp, 10, posPage2, 75, 75);
                                posPage2 += 26;
                                //gfx2.DrawString(etp.getInstruction(), font, XBrushes.Black,
                                //new XRect(110, posPage2, page2.Width, page2.Height), XStringFormats.TopLeft);
                                String Instruction = etp.GetInstruction();
                                if (etp.GetInstruction().Length >= 55 && etp.GetInstruction().Length < 110)
                                {
                                    String RetourLigne = "";
                                    String Partie2 = "";
                                    int i = 54;
                                    for (int j = 0; j < 54; j++)
                                    {
                                        RetourLigne += Instruction[j];
                                    }
                                    while (Instruction[i] != ' ')
                                    {
                                        RetourLigne += Instruction[i];
                                        i++;
                                    }


                                    i++;

                                    while (i < etp.GetInstruction().Length)
                                    {
                                        Partie2 += Instruction[i];
                                        i++;
                                    }

                                    Instruction = RetourLigne;
                                    gfx2.DrawString(RetourLigne, font, XBrushes.Black,
                                    new XRect(110, posPage2, page.Width, page.Height), XStringFormats.TopLeft);
                                    posPage2 += 20;
                                    gfx2.DrawString(Partie2, font, XBrushes.Black,
                                    new XRect(110, posPage2, page.Width, page.Height), XStringFormats.TopLeft);
                                }
                                else if (etp.GetInstruction().Length >= 110)
                                {
                                    String RetourLigne = "";
                                    String Partie2 = "";
                                    String Partie3 = "";
                                    int i = 54;
                                    for (int j = 0; j < 54; j++)
                                    {
                                        RetourLigne += Instruction[j];
                                    }
                                    while (Instruction[i] != ' ')
                                    {
                                        RetourLigne += Instruction[i];
                                        i++;
                                    }


                                    i++;

                                    int lim = 109;
                                    for (int k = i; k < 109; k++)
                                    {
                                        Partie2 += Instruction[k];

                                    }
                                    while (Instruction[lim] != ' ')
                                    {
                                        Partie2 += Instruction[lim];
                                        lim++;
                                    }

                                    lim++;

                                    while (lim < etp.GetInstruction().Length)
                                    {
                                        Partie3 += Instruction[lim];
                                        lim++;
                                    }

                                    Instruction = RetourLigne;
                                    gfx2.DrawString(RetourLigne, font, XBrushes.Black,
                                    new XRect(110, posPage2, page.Width, page.Height), XStringFormats.TopLeft);
                                    posPage2 += 20;
                                    gfx2.DrawString(Partie2, font, XBrushes.Black,
                                    new XRect(110, posPage2, page.Width, page.Height), XStringFormats.TopLeft);
                                    posPage2 += 20;
                                    gfx2.DrawString(Partie3, font, XBrushes.Black,
                                    new XRect(110, posPage2, page.Width, page.Height), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    gfx2.DrawString(Instruction, font, XBrushes.Black,
                                    new XRect(110, posPage2, page.Width, page.Height), XStringFormats.TopLeft);
                                }
                                posPage2 += 75;
                                XPoint x2 = new XPoint(4, posPage2 - 15);
                                XPoint y2 = new XPoint(page.Width - 4, posPage2 - 15);
                                gfx2.DrawLine(pen, x2, y2);
                                gfx2.DrawLine(pen, x, x2);
                                gfx2.DrawLine(pen, y, y2);

                            }

                            catch (IndexOutOfRangeException)
                            {
                                gfx2.DrawString(etp.GetInstruction(), font, XBrushes.Black,
                                    new XRect(110, posPage2, page.Width, page.Height), XStringFormats.TopLeft);
                                posPage2 += 75;
                                XPoint x2 = new XPoint(4, posPage2 - 15);
                                XPoint y2 = new XPoint(page.Width - 4, posPage2 - 15);
                                XPoint x = new XPoint(4, posPage2 - 120);
                                XPoint y = new XPoint(page.Width - 4, posPage2 - 120);
                                gfx2.DrawLine(pen, x2, y2);
                                gfx2.DrawLine(pen, x, x2);
                                gfx2.DrawLine(pen, y, y2);
                            }

                            nbEtape++;
                        }

                        //Si le nombre d'étape dépasse 9 je dessine sur la troisième page
                        //Même code que pour les étapes de la page une et deux
                        else
                        {
                            try
                            {
                                XPoint x = new XPoint(4, posPage3 - 5);
                                XPoint y = new XPoint(page.Width - 4, posPage3 - 5);
                                gfx3.DrawLine(pen, x, y);
                                gfx3.DrawString(etp.GetNumEtape().ToString(), titre, XBrushes.Black,
                                new XRect(10, posPage3, page3.Width, page3.Height), XStringFormats.TopLeft);
                                posPage3 += 15;
                                XImage imgEtp;
                                try
                                {
                                    imgEtp = XImage.FromFile(etp.GetChemin());
                                }
                                catch (System.IO.FileNotFoundException)
                                {
                                    imgEtp = XImage.FromFile("../../Images_Prof/lama.png");
                                }
                                gfx3.DrawImage(imgEtp, 10, posPage3, 75, 75);
                                posPage3 += 26;
                                //gfx2.DrawString(etp.getInstruction(), font, XBrushes.Black,
                                //new XRect(110, posPage2, page2.Width, page2.Height), XStringFormats.TopLeft);
                                String Instruction = etp.GetInstruction();
                                if (etp.GetInstruction().Length >= 55 && etp.GetInstruction().Length < 110)
                                {
                                    String RetourLigne = "";
                                    String Partie2 = "";
                                    int i = 54;
                                    for (int j = 0; j < 54; j++)
                                    {
                                        RetourLigne += Instruction[j];
                                    }
                                    while (Instruction[i] != ' ')
                                    {
                                        RetourLigne += Instruction[i];
                                        i++;
                                    }


                                    i++;

                                    while (i < etp.GetInstruction().Length)
                                    {
                                        Partie2 += Instruction[i];
                                        i++;
                                    }

                                    Instruction = RetourLigne;
                                    gfx3.DrawString(RetourLigne, font, XBrushes.Black,
                                    new XRect(110, posPage3, page.Width, page.Height), XStringFormats.TopLeft);
                                    posPage3 += 20;
                                    gfx3.DrawString(Partie2, font, XBrushes.Black,
                                    new XRect(110, posPage3, page.Width, page.Height), XStringFormats.TopLeft);
                                }
                                else if (etp.GetInstruction().Length >= 110)
                                {
                                    String RetourLigne = "";
                                    String Partie2 = "";
                                    String Partie3 = "";
                                    int i = 54;
                                    for (int j = 0; j < 54; j++)
                                    {
                                        RetourLigne += Instruction[j];
                                    }
                                    while (Instruction[i] != ' ')
                                    {
                                        RetourLigne += Instruction[i];
                                        i++;
                                    }


                                    i++;

                                    int lim = 109;
                                    for (int k = i; k < 109; k++)
                                    {
                                        Partie2 += Instruction[k];

                                    }
                                    while (Instruction[lim] != ' ')
                                    {
                                        Partie2 += Instruction[lim];
                                        lim++;
                                    }

                                    lim++;

                                    while (lim < etp.GetInstruction().Length)
                                    {
                                        Partie3 += Instruction[lim];
                                        lim++;
                                    }

                                    Instruction = RetourLigne;
                                    gfx3.DrawString(RetourLigne, font, XBrushes.Black,
                                    new XRect(110, posPage3, page.Width, page.Height), XStringFormats.TopLeft);
                                    posPage3 += 20;
                                    gfx3.DrawString(Partie2, font, XBrushes.Black,
                                    new XRect(110, posPage3, page.Width, page.Height), XStringFormats.TopLeft);
                                    posPage3 += 20;
                                    gfx3.DrawString(Partie3, font, XBrushes.Black,
                                    new XRect(110, posPage3, page.Width, page.Height), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    gfx3.DrawString(Instruction, font, XBrushes.Black,
                                    new XRect(110, posPage3, page.Width, page.Height), XStringFormats.TopLeft);
                                }
                                posPage3 += 75;
                                XPoint x2 = new XPoint(4, posPage3 - 15);
                                XPoint y2 = new XPoint(page.Width - 4, posPage3 - 15);
                                gfx3.DrawLine(pen, x2, y2);
                                gfx3.DrawLine(pen, x, x2);
                                gfx3.DrawLine(pen, y, y2);

                            }

                            catch (IndexOutOfRangeException)
                            {
                                gfx3.DrawString(etp.GetInstruction(), font, XBrushes.Black,
                                    new XRect(110, posPage3, page.Width, page.Height), XStringFormats.TopLeft);
                                posPage2 += 75;
                                XPoint x2 = new XPoint(4, posPage3 - 15);
                                XPoint y2 = new XPoint(page.Width - 4, posPage3 - 15);
                                XPoint x = new XPoint(4, posPage3 - 120);
                                XPoint y = new XPoint(page.Width - 4, posPage3 - 120);
                                gfx3.DrawLine(pen, x2, y2);
                                gfx3.DrawLine(pen, x, x2);
                                gfx3.DrawLine(pen, y, y2);
                            }

                            nbEtape++;
                        }
                    }
                }
            }

            //Si le nombre d'étape est inférieur ou égale à 3 je supprime les autres pages
            if (nbEtapeGen <= 3)
            {
                docu.Pages.Remove(page2);
                docu.Pages.Remove(page3);

            }

            //Si il y a plus de 3 étape mais moins de 9 étapes, alors je supprime seulement la dernière etape
            if (nbEtapeGen > 3 && nbEtapeGen <= 9)
            {
                docu.Pages.Remove(page3);
            }

            //Je m'occupe maintenant de la liste de course

            //Je créer une police d'écrite pour le titre
            XFont Coursetitre = new XFont("Verdana", 20, XFontStyle.Bold | XFontStyle.Underline);

            //J'ajoute une page au pdf dédier à la liste de course
            PdfPage pageListCourse = docu.AddPage();

            //Je créer un gfx pour la page de la liste de course
            XGraphics gfxCourse = XGraphics.FromPdfPage(pageListCourse);

            //J'écrite le titre avec la font et le gfx créer avant
            gfxCourse.DrawString("Liste des courses", Coursetitre, XBrushes.Black,
                new XRect(0, 20, pageListCourse.Width, pageListCourse.Height), XStringFormats.TopCenter);
            int posPageCourse = 90;

            //Je scinde les ingrédients en 2 colonnes

            //Je dessine la première colonne
            for (int i = 0; i < (ingredients.Count / 2); i++)
            {
                //Je créer les points pour dessiner un petit carré devant chaque ingrédients
                XPoint HG = new XPoint(10, posPageCourse);
                XPoint HD = new XPoint(30, posPageCourse);
                XPoint BG = new XPoint(10, posPageCourse + 20);
                XPoint BD = new XPoint(30, posPageCourse + 20);

                //Je dessine les lignes du petit carré
                gfxCourse.DrawLine(pen, HG, BG);
                gfxCourse.DrawLine(pen, HG, HD);
                gfxCourse.DrawLine(pen, BG, BD);
                gfxCourse.DrawLine(pen, HD, BD);


                try
                {

                    //Je récupère les infos de chaque 
                    String Quantite = ingredients[i][2];
                    String Unite = ingredients[i][1];
                    String NomIngre = ingredients[i][0];
                    String ingreF = "- " + Quantite + " " + Unite + " de " + NomIngre;

                    //Je teste si l'entièreté de l'ingredient avec ses infos dépassent les 37 caractères
                    //Même code que pour les ingrédients au début du pdf
                    if (ingreF.Length >= 37)
                    {
                        String RetourLigne = "";
                        String Partie2 = "";
                        int k = 34;
                        for (int j = 0; j < 34; j++)
                        {
                            RetourLigne += ingreF[j];
                        }
                        while (ingreF[k] != ' ' && k < ingreF.Length)
                        {
                            RetourLigne += ingreF[k];
                            k++;
                        }
                        k++;

                        while (k < ingreF.Length)
                        {
                            Partie2 += ingreF[k];
                            k++;
                        }


                        gfxCourse.DrawString(RetourLigne, font, XBrushes.Black,
                            new XRect(35, posPageCourse, page.Width, page.Height), XStringFormats.TopLeft);
                        posPageCourse += 20;

                        gfxCourse.DrawString(Partie2, font, XBrushes.Black,
                            new XRect(35, posPageCourse, page.Width, page.Height), XStringFormats.TopLeft);
                        posPageCourse += 50;
                    }
                    else
                    {
                        gfxCourse.DrawString("- " + Quantite + " " + Unite + " de " + NomIngre, font, XBrushes.Black,
                            new XRect(35, posPageCourse, page.Width, page.Height), XStringFormats.TopLeft);
                        posPageCourse += 50;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    String Quantite = ingredients[i][2];
                    String Unite = ingredients[i][1];
                    String NomIngre = ingredients[i][0];
                    gfxCourse.DrawString("- " + Quantite + " " + Unite + " de " + NomIngre, font, XBrushes.Black,
                            new XRect(35, posPageCourse, page.Width, page.Height), XStringFormats.TopLeft);
                    posPageCourse += 50;
                }
            }
            int posColonne = 90;

            for (int i = (ingredients.Count / 2); i < ingredients.Count; i++)
            {

                //Je créer les points du carré de l'ingredients de la colonne 2
                XPoint HG = new XPoint(300, posColonne);
                XPoint HD = new XPoint(320, posColonne);
                XPoint BG = new XPoint(300, posColonne + 20);
                XPoint BD = new XPoint(320, posColonne + 20);

                //Je dessine les lignes
                gfxCourse.DrawLine(pen, HG, BG);
                gfxCourse.DrawLine(pen, HG, HD);
                gfxCourse.DrawLine(pen, BG, BD);
                gfxCourse.DrawLine(pen, HD, BD);

                //Même code que pour les ingredients au début du pdf
                try
                {
                    String Quantite = ingredients[i][2];
                    String Unite = ingredients[i][1];
                    String NomIngre = ingredients[i][0];
                    String ingreF = "- " + Quantite + " " + Unite + " de " + NomIngre;

                    if (ingreF.Length >= 37)
                    {
                        String RetourLigne = "";
                        String Partie2 = "";
                        int k = 34;
                        for (int j = 0; j < 34; j++)
                        {
                            RetourLigne += ingreF[j];
                        }
                        while (ingreF[k] != ' ' && k < ingreF.Length)
                        {
                            RetourLigne += ingreF[k];
                            k++;
                        }
                        k++;

                        while (k < ingreF.Length)
                        {
                            Partie2 += ingreF[k];
                            k++;
                        }


                        gfxCourse.DrawString(RetourLigne, font, XBrushes.Black,
                            new XRect(325, posColonne, page.Width, page.Height), XStringFormats.TopLeft);
                        posColonne += 20;

                        gfxCourse.DrawString(Partie2, font, XBrushes.Black,
                            new XRect(325, posColonne, page.Width, page.Height), XStringFormats.TopLeft);
                        posColonne += 50;
                    }
                    else
                    {
                        gfxCourse.DrawString("- " + Quantite + " " + Unite + " de " + NomIngre, font, XBrushes.Black,
                            new XRect(325, posColonne, page.Width, page.Height), XStringFormats.TopLeft);
                        posColonne += 50;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    String Quantite = ingredients[i][2];
                    String Unite = ingredients[i][1];
                    String NomIngre = ingredients[i][0];
                    gfxCourse.DrawString("- " + Quantite + " " + Unite + " de " + NomIngre, font, XBrushes.Black,
                            new XRect(325, posColonne, page.Width, page.Height), XStringFormats.TopLeft);
                    posColonne += 50;
                }
            }

            //Je créer un stylo pour créer une ligne poitillé qui va terminer la liste de course
            XPen penLigne = new XPen(XColors.Black, 1);
            //Je donne au stylo le style poitillé
            penLigne.DashStyle = XDashStyle.Dot;

            //Je créer les points de la ligne
            XPoint LG = new XPoint(0, posColonne);
            XPoint LD = new XPoint(page.Width, posColonne);

            //Je dessine la ligne
            gfxCourse.DrawLine(penLigne, LG, LD);

            //Je créer le nom du pdf à partir du nom de la recette
            string filename = "Recette " + nomRecette + ".pdf";

            //Je sauvegarde le pdf
            docu.Save(filename);

            //J'ouvre le pdf
            Process.Start(filename);
        }
    }
}
