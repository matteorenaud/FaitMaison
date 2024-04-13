using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Bibliothèque_UserControl_ProjetA21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4;

namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    public partial class frmResultatRecettes : Form
    {
        public frmResultatRecettes()
        {
            InitializeComponent();
        }
     
        //Un deuxième constructeur avec en paramêtre tout ce qu'il faut pour faire la recherche
        //On a :
        // - la liste des noms des ingrédients choisis
        // - la liste des codes des ingrédients choisis (en parallèle des noms)
        // - le code du plat (si aucun plat n'est choisi, c'est -1)
        // - le code du budget (si aucun budget n'est choisi, c'est -1)
        // - le temps de cuisson (si aucun temps n'est choisi, c'est -1)
        // - l'image de fond
        public frmResultatRecettes( List<string> ingredientsChoisis,List<int>codeIngredientsChoisis, int plat,int budget,int temps,Image imgFond)
        {
            InitializeComponent();         
            this.codePlat = plat;
            this.codeBudget = budget;
            this.tempsCuisson = temps;
            //On garde la référence
            //Pas de besoin de malloc avec un new
            this.ingredients = ingredientsChoisis;
            this.codeIngredientsChoisis = codeIngredientsChoisis;
            this.imageFond = imgFond;
        }

        //Ici, c'est tous les codes pour faire la recherche avec ce qu'on a reçu en paramètre dans le constructeur
        List<string> ingredients;
        List<int> codeIngredientsChoisis;
        int codePlat;
        int codeBudget;
        int tempsCuisson;
        Image imageFond;
        frmAccueil formAccueil=null;

        public void SetFrmAccueil(frmAccueil accueil)
        {
            this.formAccueil = accueil;
        }

        private void btnRevenirEnArriere_Click(object sender, EventArgs e)
        {
            //Je ferme le formulaire avec un DialogRecult.Cancel (Annuler)
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmResultatRecettes_Load(object sender, EventArgs e)
        {
            //Je fais la recherche des plats en mode connecté
            FaireLaRechercheSQLEnModeConnecte();
        }
        private void FaireLaRechercheSQLEnModeConnecte()
        {
            try
            {
                //J'ouvre la connexion
                frmAccueil.connec.Open();

                //On va maintenant construire la requête en fonction de ce que l'utilisateur a choisi
                string requete = @"select * from Recettes";

                //Petite vérification temporaire pour voir les différents paramêtres reçus du constructeur
                //VerificationAvecMessageBoxDePassageDeParametreBien();

                //4 bouléens en fonction de ce que l'utilisateur veut
                bool veutIngredients = false;
                bool veutTypePlat = false;
                bool veutBudget = false;
                bool veutTempsCuisson = false;

                //------------------------Partie ingrédients-------------------------------
                string requeteIngredients="";

                //S'il l'utilisateur a choisi au moins 1 ingrédient
                if (ingredients.Count>0)
                {
                    veutIngredients = true;

                    //La partie imbriquée de la requête
                    requeteIngredients = "SELECT DISTINCT codeRecette FROM IngrédientsRecette WHERE codeIngredient IN (";

                    //Je parcours la liste des ingrédients
                    for(int i=0;i<ingredients.Count;i++)
                    {
                        //S'il n'a choisi qu'un seul ingrédient
                        if (ingredients.Count == 1)
                        {
                            //Je mets le code, puis ferme avec une parenthèse
                            requeteIngredients += codeIngredientsChoisis[i].ToString() + ")";
                        }
                        //Sinon
                        else
                        {
                            //Je mets le code, puis sépare par une virgule
                            requeteIngredients += codeIngredientsChoisis[i]+",";

                            //Si on est au dernier ingrédient (que ce soit 2 ou 3)
                            if (i==2||(i==1&&ingredients.Count==2))
                            {
                                //Je retire la virgule à la fin et remplace par une parenthèse
                                requeteIngredients = requeteIngredients.Substring(0,requeteIngredients.Length-1);
                                requeteIngredients += ")";                         
                            }
                        }                        
                    }
                    //Un MessageBox pour voir la requête lors des tests
                    //MessageBox.Show(requeteIngredients);
                }/*
                else
                {
                    //Je sélectionne tous les ingrédients
                    //N'est pas utile (c'est pour cela que c'est en commentaire)
                    requeteIngredients= "SELECT DISTINCT codeRecette FROM IngrédientsRecette";
                }*/

                //---------------------------------------------------------------------

                //----------------Partie type plat-------------------------------------

                string requetePlat="";

                //Si le code du plat n'est pas -1 (donc qu'il a choisi un type de plat)
                if(codePlat!=-1)
                {
                    veutTypePlat = true;
                    //La partie imbriquée de la requête pour récupérer la recette qui est dans cette catégorie
                    requetePlat = "SELECT codeRecette FROM CatégoriesRecette WHERE codeCategorie = "+codePlat;
                }/*
                else
                {
                    requetePlat = "SELECT DISTINCT codeRecette FROM CatégoriesRecette";
                }*/
                //MessageBox pour vérifier
                //MessageBox.Show(requetePlat);

                //---------------------------------------------------------------------
                
                //----------------Partie Budget et temps de cuissons-------------------

                string requeteBudgetEtTemps = "";

                //Si le code budget n'est pas -1 (qu'il a choisi un budget)
                if(codeBudget!=-1)
                {
                    //Je mets une condition WHERE (pas besoin de vérifier pour un AND car ce sera vérifié après)
                    requeteBudgetEtTemps = "WHERE categPrix =" + codeBudget;
                    veutBudget = true;
                }

                //S'il a choisi un temps de cuisson
                if(tempsCuisson!=-1)
                {
                    //S'il a aussi choisi un budget
                    if (codeBudget != -1)
                        //Je rajoute un AND
                        requeteBudgetEtTemps += " AND ";
                    //Sinon
                    else
                        //Je mets un WHERE
                        requeteBudgetEtTemps += "WHERE ";

                    veutTempsCuisson = true;
                    //La restriction
                    requeteBudgetEtTemps += "tempsCuisson <= " + tempsCuisson;
                }

                //-----------------------------------------------------------

                //Maintenant, la requête globale

                //Ici, c'est aucun filtre
                if(!veutIngredients&&!veutTypePlat&&!veutBudget&&!veutTempsCuisson)
                {
                    //Un simple SELECT * FROM Recettes pour tout sélectionner
                    requete = @"SELECT * FROM Recettes";
                }
                //Sinon, les filtres
                else
                {
                    //Budget et temps seront toujours comme cela
                    requete = @"SELECT * FROM Recettes " + requeteBudgetEtTemps;

                    //Maintenant, on va rajouter les 2 requêtes imbriquées
                    //S'il a choisi des ingrédients
                    if (veutIngredients)
                    {
                        //S'il a aussi pris le budget ou le temps de cuisson
                        if(veutBudget||veutTempsCuisson)
                        {
                            //Je rajoute un AND, puis la requête imbriquée
                            requete += " AND codeRecette IN (" + requeteIngredients + ")";
                        }
                        //Sinon
                        else
                        {
                            //Pas de AND, mais un WHERE, puis la requête imbriquée
                            requete += " WHERE codeRecette IN (" + requeteIngredients + ")";
                        }

                        //S'il veut aussi avec un type de plat
                        if(veutTypePlat)
                        {            
                            //Un AND et la requête imbriquée du type de plat
                            requete += " AND codeRecette IN (" + requetePlat + ")";                      
                        }                       
                    }
                    //Sinon
                    else
                    {
                        //S'il n'a donc pas d'ingrédients, mais veut un type de plat
                        if (veutTypePlat)
                        {
                            //S'il veut un budget ou temps de cuisson
                            if(veutBudget||veutTempsCuisson)
                                requete += " AND codeRecette IN (" + requetePlat + ")";
                            //Sinon, seulement un type de plat
                            else
                                requete+= " WHERE codeRecette IN (" + requetePlat + ")";
                        }
                    }                  
                }

                //MessageBox pour voir la requête
                //MessageBox.Show(requete,"La requête",MessageBoxButtons.OK,MessageBoxIcon.Information);

                //L'objet Command
                OleDbCommand cd = new OleDbCommand(requete, frmAccueil.connec);
                //Un OleDbDataReader qui va lire le flux de données
                //Que j'exécute ExecuteReader(), car la requête renvoie plusieurs lignes 
                OleDbDataReader oldr = cd.ExecuteReader();

                int haut = 40;
                int gauche = 20;
                int nbRecetteCorrespond = 0;

                //Tant qu'il y a des lignes à lire
                while (oldr.Read())
                {
                    //Je récupère le nom de la recette, le nombre de personnes, le temps de cuisson, le chemin de l'image et le code du budget
                    string nomRecette = oldr.GetString(1);
                    string nbPers = oldr.GetValue(2).ToString();
                    string tempsCuisson = oldr.GetValue(3).ToString();
                    string chemin = oldr.GetValue(4).ToString();
                    string budget = oldr.GetValue(5).ToString();

                    //En fonction du code, j'indique la catégorie
                    if (budget == "1")
                        budget = "Bas";
                    else if (budget.ToString() == "2")
                        budget = "Moyen";
                    else
                        budget = "Haut";

                    //Je mets en place l'image (on fait deux fois .., car quand on lance l'application, on est dans le dossier bin/Debug)
                    //Il faut donc remonter 2 fois

                    //L'image par défaut au cas où
                    UCApercuRecette.MettreImage_Par_Defaut("../../Images_Prof/lama.png");
                    //L'image de la recette
                    Image imgRecette=null;
                    try
                    {
                        imgRecette = Image.FromFile("../../Images_Prof/" + chemin);
                    }
                    catch(System.IO.FileNotFoundException)
                    {
                        try
                        {
                            imgRecette = Image.FromFile("../../Images_Prof/lama.png");
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            //Pas d'image
                        }
                    }

                    //Je génère dynamiquement un UserControls qui affiche l'aperçu de la recette
                    UCApercuRecette ucApercuRecette = new UCApercuRecette(nomRecette, tempsCuisson + " minutes", budget, "Nombre de personne : " + nbPers);
                    //Je mets en place l'image
                    ucApercuRecette.ImageRecette = imgRecette;
                  
                    //La position
                    ucApercuRecette.Top = haut;
                    ucApercuRecette.Left = gauche;
                    //La taille
                    //ucApercuRecette.Height = 200;
                    //ucApercuRecette.Width = 700;
                    //J'ajoute le composant au Panel du résultat des recherches
                    pnlResultatRecherche.Controls.Add(ucApercuRecette);

                    //Je génère aussi le bouton du choix de consultation de la recette
                    UCBoutonAffichageIntegraleEtapes ucBoutonAffichageIntegraleEtapes = new UCBoutonAffichageIntegraleEtapes();
                    //Position
                    ucBoutonAffichageIntegraleEtapes.Top = haut + 15;
                    //Je fais en sorte de le placer à gauche du UC de l'aperçu de la recette
                    ucBoutonAffichageIntegraleEtapes.Left = ucApercuRecette.Width+30;
                    //Taille
                    ucBoutonAffichageIntegraleEtapes.Height = 210;
                    ucBoutonAffichageIntegraleEtapes.Width = 300;
                    //Je mets en place le tag aux boutons (le tag est le code de la recette qui servira pour savoir quelle recette afficher quand on clique dessus)
                    ucBoutonAffichageIntegraleEtapes.SetTagAuxBoutons(oldr.GetValue(0).ToString());
                    //+ je mets en place les 2 formulaires
                    ucBoutonAffichageIntegraleEtapes.SetFrmAccueil(formAccueil);
                    ucBoutonAffichageIntegraleEtapes.SetFrmDetailsRecette(this);
                    //J'ajoute aussi ce UC au Panel de résultat de la recherche
                    pnlResultatRecherche.Controls.Add(ucBoutonAffichageIntegraleEtapes);

                    //J'incrémente la variable haut de la taille du UC + 40
                    haut += ucApercuRecette.Height + 40;
                    //J'incrémente le compteur qui compte le nombre de recettes
                    nbRecetteCorrespond++;
                }

                //En fonction, du nombre de recettes, j'indique le nombre de résultats qui correspondent
                if(nbRecetteCorrespond==1)
                    lblResultatRecettes.Text = nbRecetteCorrespond + " recette correspond à votre recherche";
                else if(nbRecetteCorrespond>1)
                    lblResultatRecettes.Text = nbRecetteCorrespond + " recettes correspondent à votre recherche";
                else
                    lblResultatRecettes.Text = "Aucune ligne ne correspond à votre recherche";
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
            if(imageFond!=null)
            {
                //Je mets en place l'image de fond
                this.BackgroundImage = imageFond;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
        }

        //Une méthode qui servait à vérifier le passage de paramêtre grâce à un MessageBox
        private void VerificationAvecMessageBoxDePassageDeParametreBien()
        {
            string ecritureIngredients = "Ingredients choisis :";

            //Si j'ai sélectionné des ingrédients
            if (ingredients.Count > 0)
            {
                //J'écris les ingrédients choisis
                for (int i = 0; i < ingredients.Count; i++)
                {
                    ecritureIngredients += "\n" + ingredients[i];
                }
            }
            //Sinon
            else
                //J'écris que je n'ai rien choisi
                ecritureIngredients += "\nAucun ingrédients choisis";

            //Affiche du MessageBox
            //MessageBox.Show(ecritureIngredients+"\nCode plat : "+codePlat+"\nCode budget :"+codeBudget+"\nTemps de cuisson : "+tempsCuisson+" min");
        }

        private void btnNotations_Click(object sender, EventArgs e)
        {
            //Je créé le formulaire des notations + affichage
            frmNotations note = new frmNotations();
            note.ShowDialog();
        }
    }
}
