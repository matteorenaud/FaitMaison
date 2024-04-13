using System;
using System.Windows.Forms;

namespace Projet_A21D21_RENAUD_Mattéo_GILLIG_Mattéo_TP4
{
    public partial class UCBoutonAffichageIntegraleEtapes : UserControl
    {
        public UCBoutonAffichageIntegraleEtapes()
        {
            InitializeComponent();
        }

        //Le texte de la GroupBox
        public string TexteGroupBox
        {
            get
            {
                return this.grpConsultationRecette.Text;
            }
            set
            {
                this.grpConsultationRecette.Text = value;
            }
        }

        //Le texte du bouton intégral
        public string TexteBoutonIntegral
        {
            get
            {
                return this.btnAffichageIntergral.Text;
            }
            set
            {
                this.btnAffichageIntergral.Text = value;
            }
        }

        //Le texte du bouton Etapes par Etapes
        public string TexteBoutonEtapes
        {
            get
            {
                return this.btnAffichageEtapes.Text;
            }
            set
            {
                this.btnAffichageEtapes.Text = value;
            }
        }

        //La méthode qui met en place les Tag aux 2 boutons
        //(Le Tag est le code de la recette)
        public void SetTagAuxBoutons(string tag)
        {
            this.btnAffichageEtapes.Tag = tag;
            this.btnAffichageIntergral.Tag = tag;
        }

        private void btnAffichageIntergral_Click(object sender, EventArgs e)
        {
            //Partage du code entre les 2 boutons

            //Je cast en Bouton et récupère le Tag
            Button btn = (Button)sender;
            int numRecette = int.Parse(btn.Tag.ToString());

            //J'appelle la méthode qui va générer le formulaire de détails de la recette
            GenererFrmDetailsRecette(numRecette, (Button)sender);
        }

        //La méthode qui génère le formulaire
        private void GenererFrmDetailsRecette(int codeRecette,Button btnEnvoyeur)
        {
            //Je créé une instance du formulaire
            frmDetailsRecette feuille = new frmDetailsRecette(codeRecette,btnEnvoyeur);
            //Je mets en place les 2 formulaires (accueil et résultat recette)
            feuille.SetFrmAccueil(formAccueil);
            feuille.SetFrmResultatRecherche(formResultatsRecette);
            //Affichage
            feuille.ShowDialog();
        }

        //Les 2 formulaires
        frmAccueil formAccueil = null;
        frmResultatRecettes formResultatsRecette = null;

        //Les 2 setters pour les 2 formulaires
        public void SetFrmAccueil(frmAccueil accueil)
        {
            this.formAccueil = accueil;
        }
        public void SetFrmDetailsRecette(frmResultatRecettes resultatRecette)
        {
            this.formResultatsRecette = resultatRecette;
        }
    }
}
