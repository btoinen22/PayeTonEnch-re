using PayeTonEnchère.models;
using PayeTonEnchère.VueModels;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PayeTonEnchère.services;
using System.Threading.Tasks;

namespace PayeTonEnchère.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsciptionVue : ContentView
    {
        api inscriptionapi = new api();

        public InsciptionVue()
        {
            InitializeComponent();
            BindingContext = new InscriptionVueModele();
        }

        // code pour vérifier si l'adresse email est valide 
        Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }

        /* public void NewEmailOrNot()
        {
            User.SuppresionProfessionnelExistant();
            User.SuppresionProfessionnelNouveauAttente();
            // voir si l'email est déjà présent dans la collection
            ObservableCollection<User> LesProfessionnels = User.GetListSQLite();
            foreach (User unProfessionnel in LesProfessionnels)
            {
                if (EmailEntry.Text != unProfessionnel.Email)
                {
                    User.AjoutProfessionnelNouveauAttente(unProfessionnel);
                }
                else
                {
                    User.AjoutProfessionnelExistant(unProfessionnel);
                }
            }
        } */

        // private string genreChoice;
        // public string GenreChoice { get => genreChoice; set => genreChoice = value; }
        // code pour que l'utilisateur puisse s'inscrire
        async void OnButtonClickedProfessionel(object sender, EventArgs e)
        {   // verifir si l'utilisateur a rentre toutes les informations demande
            if (!string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text)
                && !string.IsNullOrEmpty(PasswordVerifyEntry.Text) && !string.IsNullOrEmpty(NomEntry.Text)
                && !string.IsNullOrEmpty(PrenomEntry.Text) && !string.IsNullOrEmpty(NumEntry.Text)
                && !string.IsNullOrEmpty(AdresseEntry.Text)
                && !string.IsNullOrEmpty(CodePostaleEntry.Text) && !string.IsNullOrEmpty(PseudoEntry.Text)
             ){
                // vérifie que l'email saisie est correct
                if (ValidateEmail(EmailEntry.Text))
                {
                    if (User._collClass.Count() == 0)
                    {
                        // vérifier que le mot de passe entré et le même entré dans le mot de passe de vérification
                       if (PasswordEntry.Text == PasswordVerifyEntry.Text)
                        {
                           await inscriptionapi.PostAsync(new User
                           {
                                Name = NomEntry.Text,
                                Firstname = PrenomEntry.Text,
                                Address = AdresseEntry.Text,
                                Codepostale = CodePostaleEntry.Text,
                                City = VilleEntry.Text,
                                Phone = NumEntry.Text,
                                Email = EmailEntry.Text,
                                Password = PasswordEntry.Text,
                                Pseudo = PseudoEntry.Text,
                            },"user");

                            await DisplayAlert("Bravo", "enregistrement réussi", "ok");
                            Application.Current.MainPage = new Page();
                        }
                        else
                        {
                            await DisplayAlert("Erreur", "Vos mots de passes ne sont pas les mêmes", "ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Erreur", "Cette adresse email est déjà existante! Vous avez peut-être déjà un compte ?", "ok");
                    }
                }
                else
                {
                    await DisplayAlert("Erreur", "Votre adresse email n'est pas valide", "ok");
                }
            }
            else
            {
                await DisplayAlert("Erreur", "Vous n'avez pas remplis tous les champs nécessaire !", "ok");
            }
        }

        private Task DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}