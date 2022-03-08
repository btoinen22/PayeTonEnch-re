using PayeTonEnchère.models;
using PayeTonEnchère.services;
using PayeTonEnchère.VueModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PayeTonEnchère.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonInscriptionPage : ContentPage
    {
        //Création d'une instance d'api pour accéder au méthode de l'API symfony
        readonly api inscriptionapi = new api();

        /// <summary>
        /// Initialisation d'une nouvelle instance de l'InsciptionVueModele
        /// </summary>
        public MonInscriptionPage()
        {
            InitializeComponent();
            BindingContext = new InscriptionVueModele();
        }

        // instance de la classe regex qui permet de vérifier la validité de caractère 
        // ici d'une adresse Email
        readonly Regex EmailValidate = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        /// <summary>
        /// Enregistre la valeur de l'Email présent dans l'entry
        /// puis vérifie sa validité avec l'instance Regex
        /// </summary>
        /// <returns> True si valide sinon retourne False </returns>
        public bool ValidateEmail()
        {
            string mail = EmailEntry.Text;
            Match match = EmailValidate.Match(mail);
            if (match.Success)
                return true;
            else
                return false;
        }

        /// <summary>
        ///cas 1 : Verifie l'existance d'un Email et sa validité
        /// si existe ou qu'il n'est pas valide 
        /// cas 2 : si l'Email n'existe pas et qu'il est valide
        /// alors lance l'inscription
        /// </summary>
        /// <returns> cas 1 : false cas 2 : true </returns>
        public async void EmailExistant()
        {
            if (this.ValidateEmail === true)
            {
                foreach (User Utilisateur in User._collClass)
                {
                    if (Utilisateur.Email != this.EmailEntry.Text)
                    {
                        this.Inscrire();
                    }
                    else
                        await DisplayAlert("Erreur", "Cette adresse email est déjà existante! Vous avez peut-être déjà un compte ?", "ok", "cancel");
                }
            }
            else this.ValidateEmail() === false;
            {
                await DisplayAlert("Erreur", "Cette adresse email est incorrect", "ok", "cancel");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        async void Inscrire()
        {
            // on vérifie que toutes les données demandé sont rentrés
            if (!string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text)
                && !string.IsNullOrEmpty(PasswordVerifyEntry.Text) && !string.IsNullOrEmpty(NameEntry.Text)
                && !string.IsNullOrEmpty(FirstnameEntry.Text) && !string.IsNullOrEmpty(NumEntry.Text)
                && !string.IsNullOrEmpty(AddressEntry.Text) && !string.IsNullOrEmpty(CityEntry.Text)
                && !string.IsNullOrEmpty(CodePostaleEntry.Text) && !string.IsNullOrEmpty(PseudoEntry.Text)
             )
            {
                // vérifier que le mot de passe entré et le même entré dans le mot de passe de vérification
                if (PasswordEntry.Text == PasswordVerifyEntry.Text)
                {
                    // ajout d'un user dans la base de donnée
                    // a partir des entry
                    await inscriptionapi.PostAsync(param: new User
                    {
                        Name = NameEntry.Text,
                        Firstname = FirstnameEntry.Text,
                        Address = AddressEntry.Text,
                        Codepostale = CodePostaleEntry.Text,
                        City = CityEntry.Text,
                        Phone = NumEntry.Text,
                        Email = EmailEntry.Text,
                        Password = PasswordEntry.Text,
                        Pseudo = PseudoEntry.Text,

                    }, "user");

                    await DisplayAlert("Bravo", "enregistrement réussi", "ok", "cancel");
                    Application.Current.MainPage = new Page();
                }
                else
                {
                    await DisplayAlert("Erreur", "Vos mots de passes ne sont pas les mêmes", "ok", "cancel");
                }
            }
            else
                await DisplayAlert("Erreur", "Vous n'avez pas remplis tous les champs nécessaire !", "ok", "cancel");
        }

    }
}