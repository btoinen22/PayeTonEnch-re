using PayeTonEnchère.models;
using PayeTonEnchère.services;
using PayeTonEnchère.Vues;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PayeTonEnchère.VueModels
{
    public class AuthentificationVueModele : BaseVueModele
    {
        #region Attributs

        Api _apiService = new Api();

        protected Page page;
        private string _emailEntry,
            _passwordEntry;

        #endregion

        #region Constructeurs
        public AuthentificationVueModele(Page page)
        {
            this.page = page;
            CommandBoutonConnexion = new Command(OnSubmit);
            CommandBoutonInscription = new Command(Inscription);
        }
        #endregion

        #region Getters/Setters

        public string EmailEntry
        {
            get
            {
                return _emailEntry;
            }
            set
            {
                SetProperty(ref _emailEntry, value);
            }
        }

        public string PasswordEntry
        {
            get
            {
                return _passwordEntry;
            }
            set
            {
                SetProperty(ref _passwordEntry, value);
            }
        }

        public ICommand CommandBoutonConnexion { get; private set; } // getter/setter du boutton CommandBouttonConnexion
        public ICommand CommandBoutonInscription { get; private set; } // getter/setter du boutton  CommandBouttonInscription

        #endregion

        #region Methodes

        // méthode permettant à un utilisateur de se connecter
        public async void OnSubmit()
        {
            // créer un dictionnaire param
            Dictionary<string, object> param = new Dictionary<string, object>(); 
            //ajoute la valeur du mail et du mot de passe au dictionnaire
            param.Add("Email", EmailEntry);
            param.Add("Password", PasswordEntry);
            // crée une instance de user à partir des informations récupérer par le mot de passe et le mail à l'aide
            // de la méthode d'API GetUserByMdpAndMail
            User user = await GetUserByMdpAndMail(param);
            if (user == null) // si l'utilisateur n'existe pas affiche un message d'erreur
                await Application.Current.MainPage.DisplayAlert(ServiceApi.ErrorTitle,ServiceApi.ErrorDescriptionConnexion,
                    ServiceApi.ErrorCancel);
            else // sinon renvoi vers la page d'acceuil en tant qu'utilisateur connecté
            {
                Application.Current.MainPage = new AcceuilPage();
            }
        }


        /// <param name="param"></param> Dictionnaire d'objet initialiser dans le OnSubmit
        /// <returns>récupère les données d'un user à partir de la méthode d'API GetOneAsync</returns>
        public async Task<User> GetUserByMdpAndMail(Dictionary<string, object> param)
        {
            return await _apiService.GetOneAsync<User>(ServiceApi.ApiGetUserByMailAndPass, param);
        }

        /// <summary>
        /// redirige vers la page d'inscription
        /// </summary>
        public async void Inscription()
        {
            var route = $"{nameof(MonInscriptionPage)}"; // créer un objet ayant pour valeur la route shell de l'inscription
            await Shell.Current.GoToAsync(route); // redirige vers la valeur d'objet route
        }

        #endregion
        #region notifications
        #endregion
    }
}
