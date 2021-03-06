using PayeTonEnchère.Models;
using PayeTonEnchère.services;
using PayeTonEnchère.VueModels;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PayeTonEnchère.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonInscriptionPage : ContentPage
    {
        public string Photo64
        {
            get; set;
        }
        //Création d'une instance d'api pour accéder au méthode de l'API symfony
        readonly Api _inscriptionapi = new Api();

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
        readonly Regex _emailValidate = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        /// <summary>
        /// Enregistre la valeur de l'Email présent dans l'entry
        /// puis vérifie sa validité avec l'instance Regex
        /// </summary>
        /// <returns> True si valide sinon retourne False </returns>
        public bool ValidateEmail()
        {
            string mail = EmailEntry.Text; // associe une variable à la valeur du EmailEntry
            Match match = _emailValidate.Match(mail); // verifie si l'Email correspond au exigence de validité du regex
            if (match.Success) // si c'est valide retourn true
                return true;
            else // sinon retourne False
                return false;
        }

        /// <summary>
        /// La méthode est celle qui est lancé quand les valeurs des Entry d'inscription
        /// sont rempli et que l'utilisateur clique sur le bouton s'inscrire
        ///cas 1 : Verifie l'existance d'un Email et sa validité
        /// si existe ou qu'il n'est pas valide 
        /// cas 2 : si l'Email n'existe pas et qu'il est valide
        /// alors lance l'inscription
        /// </summary>
        /// <returns> cas 1 : false cas 2 : true </returns>
        private async void EmailExistant_clicked(object sender, EventArgs e)
        {
            if (this.ValidateEmail() == true) // vérifie la validité du mail
            {
                this.Inscrire(); // alors lance l'inscription de l'utilisateur
            }
            else if (this.ValidateEmail() == false) // si email invalide affiche un message d'erreur
            {
                await DisplayAlert("Erreur", "Cette adresse email est incorrect", "ok", "cancel");
            }
        }

        /// <summary>
        /// La méthode ajoute un utilisateur sur la base de donnée à partir de l'API
        /// </summary>
        async void Inscrire()
        {
            // on vérifie que toutes les données demandé sont rentrés et qu'ils soit en string
            if (!string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text)
                && !string.IsNullOrEmpty(PasswordVerifyEntry.Text) && !string.IsNullOrEmpty(PseudoEntry.Text)
             )
            {
                // vérifier que le mot de passe entré et le même entré dans le mot de passe de vérification
                if (PasswordEntry.Text == PasswordVerifyEntry.Text)
                {
                    // ajout d'un user dans la base de donnée
                    // a partir des entry
                    await _inscriptionapi.PostAsync(new User(
                        EmailEntry.Text,
                        PasswordEntry.Text,
                        Photo64,
                        PseudoEntry.Text
                        ),ServiceApi.ApiPostUser) ;
                    // affiche un message disant que l'inscription à été faites
                    await DisplayAlert("Bravo", "enregistrement réussi", "ok", "cancel");
                    // redirection vers la page de connexion
                    await Navigation.PushAsync(new MaConnexionPage());
                }
                else // si les mdp sont différents affiche un message d'erreur
                {
                    await DisplayAlert("Erreur", "Vos mots de passes ne sont pas les mêmes", "ok", "cancel");
                }
            }
            else // affiche un message d'erreur si tout les champs ne sont pas remplis
                await DisplayAlert("Erreur", "Vous n'avez pas remplis tous les champs nécessaire !", "ok", "cancel");
        }

        async void AjoutPhoto(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();
                    image1.Source = ImageSource.FromStream(() => new MemoryStream(data));
                    Photo64 = Convert.ToBase64String(data);
                }
                
            }

                (sender as Button).IsEnabled = true;
        }

    } 
}