using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    public partial class UCAfficheIngredients : UserControl
    {
        public UCAfficheIngredients()
        {
            InitializeComponent();
            listeIngredients = new List<string>();
            codeIngredients = new List<int>();
        }

        //Un attribut UCIngredientsChoisis pour pouvoir communiquer
        //La liste des ingrédients et des codes
        private UCIngredientsChoisis ucIngredientsChoisis;
        private List<string> listeIngredients;
        private List<int> codeIngredients;

        //Un setter pour le UCIngredientsChoisis
        public void SetUCListeFamille(UCIngredientsChoisis ucIngredientsChoisis)
        {
            this.ucIngredientsChoisis = ucIngredientsChoisis;
        }

        //Un getter pour le UserControl des ingrédients choisis
        public UCIngredientsChoisis GetUCIngredientsChoisis()
        {
            if (this.ucIngredientsChoisis != null)
                return this.ucIngredientsChoisis;
            else
                throw new NullReferenceException("Il n'y a pas de UCIngredientsChoisis");
        }

        //Le texte du titre
        public string Titre
        {
            get
            {
                return lblTitre.Text;
            }
            set
            {
                lblTitre.Text = value;
            }
        }

        //La méthode qui ajoute un ingrédient et son code en parallèle aux listes
        public void AjouterIngredients(string ingredient, int code)
        {
            //Si cet ingrédient n'est pas déjà présent
            if (!listeIngredients.Contains(ingredient))
            {
                //J'ajoute l'ingrédient et le code
                listeIngredients.Add(ingredient);
                codeIngredients.Add(code);
            }
        }

        //Un getter pour la liste des ingrédients
        public List<String> GetListeIngredients()
        {
            return this.listeIngredients;
        }

        //La méthode qui génère les ingrédients
        public void GenererIngredients(Button leBoutonCliquer)
        {
            this.pnlIngredients.Height = 10;

            //Je parcours la table des ingrédients
            foreach (DataRow ligne in frmAccueil.monDS.Tables["Ingrédients"].Rows)
            {
                //Si le code de la famille d'ingrédients correspond avec le Tag du bouton
                if (ligne[2].ToString() == leBoutonCliquer.Tag.ToString())
                {
                    //J'ajoute l'ingrédients et le code aux 2 listes
                    listeIngredients.Add(ligne[1].ToString());
                    codeIngredients.Add(int.Parse(ligne[0].ToString()));
                }
            }

            //2 variables pour positionner les CheckBox
            int haut = 10;
            int gauche = 10;
           
            //Trier les ingrédients par ordre alphabétique et mettre en correspondance les codes
            TrierLesIngredientsEnOrdreAlpabetiqueV2();

            for (int i = 0; i < listeIngredients.Count; i++)
            {
                CheckBox chkIngredient = new CheckBox();

                //Texte et Tag
                chkIngredient.Text = listeIngredients[i];
                chkIngredient.Tag = codeIngredients[i];

                //Police d'écriture, style et tpe de curseur
                chkIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
                chkIngredient.FlatStyle = FlatStyle.Popup;
                chkIngredient.Cursor = Cursors.Hand;

                //chkIngredient.Width = 130;
                //chkIngredient.Height = 50;
                //AutoSize fait tout tout seul, donc pas besoin de Width et Height
                chkIngredient.AutoSize = true;

                //Position
                chkIngredient.Top = haut;
                chkIngredient.Left = gauche;

                //Pour chaque ingrédient dans la liste des ingrédients que j'ai choisis
                for (int j = 0; j < ucIngredientsChoisis.GetIngredientsChoisis().Count; j++)
                {
                    //Si j'ai cet ingrédient dans la liste (donc que j'ai choisi cet ingrédient)
                    if (chkIngredient.Text == ucIngredientsChoisis.GetIngredientsChoisis()[j])
                        //Je coche la CheckBox de cet ingrédient
                        chkIngredient.Checked = true;
                }

                //J'attribue un évènement clique à la CheckBox
                chkIngredient.CheckedChanged += new System.EventHandler(CliqueIngredient);

                //J'ajoute la CheckBox au Panel des ingrédients
                pnlIngredients.Controls.Add(chkIngredient);

                //J'incrémente la variable gauche pour la prochaine CheckBox
                gauche += chkIngredient.Width + 10;

                //Si c'est trop grand             
                if (gauche > pnlIngredients.Width - chkIngredient.Width - 30)
                {
                    //Je reviens à la ligne
                    haut += chkIngredient.Height + 15;
                    gauche = 10;
                }
            }

            //Le texte du titre est le nom de la famille
            lblTitre.Text = leBoutonCliquer.Text + " :";
            //La taille du UserControl s'adapta à la taille du Panel
            this.Height = pnlIngredients.Height + 30;

            //Une hauteur limite pour ne pas avoir une taille de l'extrême
            if (this.Height > 240)
                this.Height = 240;
        }

        public void EnleverLesIngredients()
        {
            //Je vide la liste des ingrédients, celle des codes et supprime tous les controls du Panel
            listeIngredients.Clear();
            codeIngredients.Clear();
            pnlIngredients.Controls.Clear();
        }

        //L'évènement Clique de la CheckBox
        public void CliqueIngredient(object sender, EventArgs e)
        {
            //Je cast le sender en CheckBox
            CheckBox boiteCocher = (CheckBox)sender;
            //J'enlève l'Error Provider
            errNbIngredients.SetError(lblTitre, "");

            //Si la boite est cochée
            if (boiteCocher.Checked)
            {
                //Si le nombre d'ingrédients de la liste est strictement supérieur à 2
                //(Qu'on a déjà choisi 3 ingrédients)
                if (ucIngredientsChoisis.GetIngredientsChoisis().Count > 2)
                {
                    //Je décoche la CheckBox
                    boiteCocher.Checked = false;
                    //Je mets un ErrorProvider pour dire qu'il faut au maximum 3 ingrédients
                    errNbIngredients.SetError(lblTitre, "Maximum 3 ingrédients");
                    //Je quitte la méthode
                    return;
                }

                //Si tout est bon, j'ajoute, cet ingrédient à la liste des ingrédients choisis
                ucIngredientsChoisis.AjouterIngredient(boiteCocher.Text, int.Parse(boiteCocher.Tag.ToString()));
                //Je régénère les ingrédients choisis dans le UserControl qui affiche les ingrédients choisis
                ucIngredientsChoisis.GenereIngredients();
            }
            //Sinon
            else
            {
                //Je retire cet ingrédient de la liste
                ucIngredientsChoisis.RetirerIngredient(boiteCocher.Text);
                //Je régénère les ingrédients choisis dans le UserControl qui affiche les ingrédients choisis
                //(Pour que l'affichage soit cohérent)
                ucIngredientsChoisis.GenereIngredients();
                //J'appelle la méthode qui affiche le Label Rien s'il n'y a aucun ingrédient de choisi
                ucIngredientsChoisis.AfficherLabelRien();
            }
        }

        //Un getter pour le Panel des ingrédients
        public Panel GetPanelIngredients()
        {
            return this.pnlIngredients;
        }

        /*
        //La méthode pas du tout optimisée qui trie dans l'ordre alphabétique les ingrédients et met en correspondance les codes
        private void TrierParOrdreAlphabetiqueLesIngredientsEtMettreEnCorrespondanceLesCodes()
        {
            //Je créé une 3ème liste
            List<string> cherche = new List<string>();

            //Cette liste contient le nom de l'ingrédient, puis le code à la suite
            for(int i=0;i<listeIngredients.Count;i++)
            {
                listeIngredients[i] += codeIngredients[i].ToString();
            }

            //Je vide la liste des codes et trie celle des ingrédients
            codeIngredients.Clear();
            listeIngredients.Sort();

            //Pour chaque ingrédient dans la liste
            for (int i = 0; i < listeIngredients.Count; i++)
            {
                //Une variable pour la taille du code (= la longueur de l'entier) et une pour stocker le code une fois trouvé
                int taille = 1;
                int code=0;

                bool trouve = false;
                while(!trouve)
                {
                    try
                    {
                        //Je tente de convertir le code
                        //Je prends un nombre de caractères (grâce à la variable taille) et j'essaie de le convertir en int
                        code = int.Parse(listeIngredients[i].Substring(taille));
                        trouve = true;
                    }
                    //J'attrape les 3 erreurs que peut renvoyer int.Parse et incrémente la variable taille pour le prochain tour de boucle
                    catch(ArgumentNullException)
                    {
                        taille++;
                    }
                    catch(FormatException)
                    {
                        taille++;
                    }
                    catch (OverflowException)
                    {
                        taille++;
                    }
                }

                //Dès que j'ai trouvé le code, je peux remettre juste le nom de l'ingrédient et ajouter le code correspondant
                listeIngredients[i] = listeIngredients[i].Substring(0, taille);
                codeIngredients.Add(code);
            }
        }*/

        //La 2ème version de la méthode qui trie les ingrédients en ordre alphabétique et met en correspondance les codes
        private void TrierLesIngredientsEnOrdreAlpabetiqueV2()
        {
            //Je créé une 3ème liste
            List<string> cherche = new List<string>();

            //Cette liste contient le nom de l'ingrédient, puis le code à la suite
            for (int i = 0; i < listeIngredients.Count; i++)
            {
                listeIngredients[i] += codeIngredients[i].ToString();
            }

            //Je vide la liste des codes et trie celle des ingrédients
            codeIngredients.Clear();
            listeIngredients.Sort();

            //Je parcours chaque ingrédient dans la liste
            for (int i = 0; i < listeIngredients.Count; i++)
            {
                bool fait = false;
                string code_temp = "";
                int taille = listeIngredients[i].Length - 1;

                //Tant que je n'ai pas tout le code
                while (!fait)
                {
                    //Je regarde caractère par caractère en partant de la fin
                    //Si c'est un chiffre
                    if ((listeIngredients[i].Substring(taille, 1)) == "0" ||
                        (listeIngredients[i].Substring(taille, 1)) == "1" ||
                        (listeIngredients[i].Substring(taille, 1)) == "2" ||
                        (listeIngredients[i].Substring(taille, 1)) == "3" ||
                        (listeIngredients[i].Substring(taille, 1)) == "4" ||
                        (listeIngredients[i].Substring(taille, 1)) == "5" ||
                        (listeIngredients[i].Substring(taille, 1)) == "6" ||
                        (listeIngredients[i].Substring(taille, 1)) == "7" ||
                        (listeIngredients[i].Substring(taille, 1)) == "8" ||
                        (listeIngredients[i].Substring(taille, 1)) == "9")
                    {
                        //J'ajoute le chiffre à un string
                        code_temp += listeIngredients[i].Substring(taille, 1);
                        //Je diminue de 1 pour chercher le prochain caractère
                        taille--;
                    }
                    //Sinon, dès que ce n'est plus un chiffre (donc qu'on a fini de parcourir le code)
                    else if(code_temp!="")
                    {
                        //Je peux sortir de la boucle
                        fait = true;
                    }
                }

                //Partie où on inverse l'ordre (car le code est inversé)
                string code_dans_ordre = "";
                for (int j = code_temp.Length-1; j >= 0; j--)
                    code_dans_ordre += code_temp.Substring(j, 1);

                //Je convertis
                int code = int.Parse(code_dans_ordre);
                //J'ajoute le code et j'enlève le code à la suite du nom de l'ingrédient
                codeIngredients.Add(code);
                listeIngredients[i] = listeIngredients[i].Substring(0, taille+1);
            }
        }
    }
}
