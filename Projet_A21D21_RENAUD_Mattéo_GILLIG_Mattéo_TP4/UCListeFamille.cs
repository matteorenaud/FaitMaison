using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    //Le chemin vers l'icône pour le UserControl
    //[ToolboxBitmap(typeof(UCListeFamille),@"C:\Users\Elève\source\repos\Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4\Icones\control_utilisateur_choix_ingredients.ico")]

    public partial class UCListeFamille : UserControl
    {
        public UCListeFamille()
        {
            InitializeComponent();

            //Je vais bien mettre la group box (en fonction de la taille du UserControl)
            grpListeFamilles.Width = this.Width - 40;
            grpListeFamilles.Height = this.Height - 40;
        }

        //Texte de la GroupBox
        public string NomGroupBox
        {
            get
            {
                return grpListeFamilles.Text;
            }
            set
            {
                grpListeFamilles.Text = value;
            }
        }

        //Une liste avec le nom de famille
        public List<string> libelleFamille = new List<string>();
        //Un attribut UCAfficheIngredients qui permet d'avoir un lien pour l'affichage des ingrédients
        private UCAfficheIngredients controleListeIngredients;

        //Un setter et un getter pour l'UCAfficheIngredients
        public void SetControleListeIngredients(UCAfficheIngredients controle)
        {
            this.controleListeIngredients = controle;
        }
        public UCAfficheIngredients GetControleListeIngredients()
        {
            return this.controleListeIngredients;
        }

        //La méthode qui ajoute un élément à la liste
        public void AjouterElementALaListe(string element)
        {
            libelleFamille.Add(element);
        }

        //La méthode qui génère les boutons des familles
        public void GenererBoutonsFamille()
        {
            int longueurGrp = grpListeFamilles.Width;
            int hauteurGrp = grpListeFamilles.Height;

            int haut = 30;
            int gauche = 25;
            int i = 0;

            //Je parcours la table des familles dans le DataSet
            foreach (DataRow ligne in frmAccueil.monDS.Tables["Famille"].Rows)
            {
                //Je créé un bouton
                Button bouton = new Button();

                //Taille
                bouton.Width = longueurGrp / 6 + 50;
                bouton.Height = hauteurGrp / 7 + 5;

                //Le texte est le nom de la famille et le Tag est le code
                bouton.Text = ligne[1].ToString();
                bouton.Tag = ligne[0].ToString();

                //Couleur de fond + style + police d'écriture + curseur
                bouton.BackColor = Color.AliceBlue;
                bouton.FlatStyle = FlatStyle.Popup;
                bouton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bouton.Cursor = Cursors.Hand;
                //Je lui attribue dynamiquement un évènement clique
                bouton.Click += new System.EventHandler(CliqueFamilleIngredient);

                //Si je suis au 12ème élément ou plus
                if (i > 11)
                {
                    bouton.Top = haut;

                    //Si je suis au 12ème, je fais en sorte de l'aligner au milieu
                    if (i == 12)
                        bouton.Left = 55 + bouton.Width;
                    else
                        bouton.Left = 85 + bouton.Width * 2;
                }
                else
                {
                    bouton.Top = haut;
                    bouton.Left = gauche;
                }

                int hauteurBouton = bouton.Height;
                int longueurBouton = bouton.Width;

                //J'attribue dynamiquement 4 évènements pour que le bouton change de couleur quand on survole et clique dessus
                bouton.MouseEnter += new System.EventHandler(survoleEntrerSouris);
                bouton.MouseLeave += new System.EventHandler(survoleSortitSouris);
                bouton.GotFocus += new System.EventHandler(FocusBouton);
                bouton.LostFocus += new System.EventHandler(LostFocusBouton);
                //J'ajoute le bouton
                grpListeFamilles.Controls.Add(bouton);

                //J'incrémente la variable de position
                gauche += bouton.Width + 30;

                //Je remets en place les variables de position, si trop grand
                if (gauche > grpListeFamilles.Width - bouton.Width)
                {
                    gauche = 25;
                    haut += bouton.Height + 10;
                }
                i++;
            }
        }

        //Les méthodes pour avoir la couleur du bouton qui change quand on survol et clique dessus
        private void FocusBouton(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = Color.LightBlue;
            bt.MouseLeave += new System.EventHandler(sortitClick);
        }
        private void sortitClick(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            bouton.BackColor = Color.LightBlue;
        }
        private void LostFocusBouton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.AliceBlue;
            btn.MouseLeave += new System.EventHandler(SortitSourisLostFocus);
        }
        private void SortitSourisLostFocus(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.AliceBlue;
        }
        private void survoleEntrerSouris(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            bouton.BackColor = Color.CornflowerBlue;
        }
        private void survoleSortitSouris(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            bouton.BackColor = Color.AliceBlue;
        }


        //La méthode Click des boutons
        private void CliqueFamilleIngredient(object sender, EventArgs e)
        {
            //Je récupère le sender
            Button leBoutonCliquer = (Button)sender;
            //J'enlève les ingrédients affichés
            controleListeIngredients.EnleverLesIngredients();
            //Et je réaffiche les ingrédients de cette famille
            controleListeIngredients.GenererIngredients(leBoutonCliquer);
        }
    }
}
