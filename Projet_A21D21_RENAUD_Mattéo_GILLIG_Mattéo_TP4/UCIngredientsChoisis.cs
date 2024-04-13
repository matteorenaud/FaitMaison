using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    public partial class UCIngredientsChoisis : UserControl
    {
        public UCIngredientsChoisis()
        {
            InitializeComponent();
            ingredientsChoisis = new List<string>();
            codeIngredientsChoisis = new List<int>();
        }

        //La liste des ingrédients choisis avec la liste de leur code et le UCAfficheIngredients
        private List<int> codeIngredientsChoisis;
        private List<string> ingredientsChoisis;
        private UCAfficheIngredients ucAfficheIngredients;

        //Un setter pour le UCAfficheIngredients
        public void SetUCAfficheIngredients(UCAfficheIngredients ucAfficheIngredients)
        {
            this.ucAfficheIngredients = ucAfficheIngredients;
        }

        //Un getter pour le UCAfficheIngredients
        public UCAfficheIngredients GetUCAfficheIngredients()
        {
            return this.ucAfficheIngredients;
        }
        
        //Un getter pour la GroupBox
        public GroupBox GetGrpIngredientsChoisis()
        {
            return grpIngredientsChoisis;
        }

        //La méthode qui ajoute un ingrédient à la liste avec son code
        public void AjouterIngredient(string ingredient,int code)
        {
            //Si j'ai moins de 3 ingrédients et que cet ingrédient n'est pas déjà présent
            if (ingredientsChoisis.Count < 3 && !ingredientsChoisis.Contains(ingredient))
            {
                this.ingredientsChoisis.Add(ingredient);
                this.codeIngredientsChoisis.Add(code);
            }
        }

        //Un getter pour la liste des ingrédients choisis
        public List<string> GetIngredientsChoisis()
        {
            return this.ingredientsChoisis;
        }

        //Un autre getter pour la liste des codes des ingrédients choisis
        public List<int>GetCodeIngredientsChoisis()
        {
            return this.codeIngredientsChoisis;
        }

        //La méthode qui retire un ingrédient de la liste
        public void RetirerIngredient(string ingredientARetirer)
        {
            //Si l'ingrédient est présent dans la liste
            if (ingredientsChoisis.Contains(ingredientARetirer))
            {
                //Je récupère l'index de l'ingrédient
                int index = ingredientsChoisis.IndexOf(ingredientARetirer);
                //Je retire l'ingrédient et le code associé
                ingredientsChoisis.Remove(ingredientARetirer);
                codeIngredientsChoisis.RemoveAt(index);
            }
        }

        //La méthode qui génère le Label de chaque ingrédient choisi
        public void GenereIngredients()
        {
            //Je supprime tous les Controls du GroupBox et cache le Label de rien choisi
            grpIngredientsChoisis.Controls.Clear();
            lblRienChoisis.Visible = false;

            int haut = 5;
            int gauche = 5;
            int hautPanel = 25;

            //Si j'ai au moins un ingrédient dans la liste
            if (ingredientsChoisis.Count > 0)
            {
                //Je parcours chaque ingrédient
                for (int i = 0; i < ingredientsChoisis.Count; i++)
                {
                    //Je créé un Panel
                    Panel panel = new Panel();
                    //Je lui donne le nom de l'ingrédient en Tag
                    panel.Tag= codeIngredientsChoisis[i];

                    //Taille et position
                    panel.Width = 515;
                    panel.Height = 35;
                    panel.Top = hautPanel;
                    panel.Left = 10;
                    //Style de bordure
                    panel.BorderStyle = BorderStyle.FixedSingle;

                    //Je créé un Label
                    Label label = new Label();
                    //Le texte et le Tag de l'ingrédient
                    label.Text = ingredientsChoisis[i];
                    label.Tag = codeIngredientsChoisis[i];

                    //Police d'écriture
                    label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    //Taille et position
                    label.Width = 300;
                    label.Height = 30;
                    label.Top = haut;
                    label.Left = gauche;

                    //J'ajoute le Label au Panel
                    panel.Controls.Add(label);

                    //Et enfin je créé un bouton
                    Button bouton = new Button();
                    //Texte et Tag
                    bouton.Text = "Retirer";
                    bouton.Tag = codeIngredientsChoisis[i];

                    //Taille et position
                    bouton.Height = 30;
                    bouton.Width = 200;
                    bouton.Top = 2;
                    bouton.Left = label.Width + 5;

                    //Style, couleur de fond et type de curseur
                    bouton.FlatStyle = FlatStyle.Popup;
                    bouton.BackColor = Color.IndianRed;
                    bouton.Cursor = Cursors.Hand;
                    //Je lui attribue un évènement Clique
                    bouton.Click += new System.EventHandler(SuppressionBouton);
                    
                    //J'ajoute aussi ce bouton au Panel
                    panel.Controls.Add(bouton);

                    //J'ajoute le Panel au GroupBox
                    grpIngredientsChoisis.Controls.Add(panel);

                    hautPanel += panel.Height+3;
                }
            }
        }

        //La méthode Clique du bouton qui retire l'ingrédient
        public void SuppressionBouton(object sender,EventArgs e)
        {
            //Je récupère le sender
            Button boutonASupprimer = (Button)sender;

            //Pour chaque Controls dans le GroupBox
            foreach(Control c in grpIngredientsChoisis.Controls)
            {
                //Si c'est un Panel
                if(c is Panel)
                {
                    //Cast en Panel
                    Panel pnl = (Panel)c;

                    //Si le Tag du Panel et du bouton sont les mêmes (que c'est le même code ingrédient)
                    if(pnl.Tag.ToString()==boutonASupprimer.Tag.ToString())
                    {
                        //J'enlève le Panel
                        grpIngredientsChoisis.Controls.Remove(pnl);
                    }
                }
            }

            //Je retire le code et l'ingrédient des 2 listes
            int index = codeIngredientsChoisis.IndexOf(int.Parse(boutonASupprimer.Tag.ToString()));
            codeIngredientsChoisis.Remove(int.Parse(boutonASupprimer.Tag.ToString()));
            ingredientsChoisis.RemoveAt(index);

            //Je régénère les Panels des ingrédients choisis
            GenereIngredients();
            //Je décoche la CheckBox dans les ingrédients
            DecocheCheckBox(boutonASupprimer);
            //Je regarde si j'affiche le Label rien choisi
            AfficherLabelRien();
        }

        public void AfficherLabelRien()
        {
            //Si je n'ai aucun ingrédient dans la liste
            if (ingredientsChoisis.Count == 0)
                //J'affiche le Label Rien choisi
                lblRienChoisis.Visible = true;
            else
                //Sinon, je le cache
                lblRienChoisis.Visible = false;
        }

        public void DecocheCheckBox(Button boutonASupprimer)
        {
            //Pour chaque CheckBox dans le Panel du UCAfficheIngredients
            foreach (Control c in ucAfficheIngredients.GetPanelIngredients().Controls.OfType<CheckBox>())
            {
                CheckBox uneBoite = (CheckBox)c;
                //Si les Tag correspondent
                if (uneBoite.Tag.ToString() == boutonASupprimer.Tag.ToString())
                    //Je décoche
                    uneBoite.Checked = false;
            }
        }

        //Le texte du Label quand on n'a rien choisi
        public string TexteLabelRienChoisis
        {
            get
            {
                return this.lblRienChoisis.Text;
            }
            set
            {
                this.lblRienChoisis.Text = value;
            }
        }

    }
}
