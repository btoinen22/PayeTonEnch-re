using PayeTonEnchère.models;
using PayeTonEnchère.services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PayeTonEnchère.VueModels
{
    public class AuthentificationVueModele : INotifyPropertyChanged
    {
        #region Attributs
        api _apiService = new api();

        private readonly ApiAuthentification _apiServices = new ApiAuthentification();
        private readonly ApiRegistration _apiServicesRegistration = new ApiRegistration();

        private string _identifiant;
        private string _motDePasse;
        private string _imgAuth = "https://st.depositphotos.com/1695366/1400/v/950/depositphotos_14001488-stock-illustration-cartoon-impatient-man-waiting.jpg";
        private bool auth;
        #endregion
        #region Constructeurs
        public AuthentificationVueModele()
        {
            CommandeButtonRegistration = new Command(ActionPageRegistration);
            CommandeButtonLogIn = new Command(ActionPage);
        }
        #endregion
        #region Getters/Setters
        public ICommand CommandeButtonLogIn { get; }
        public ICommand CommandeButtonRegistration { get; }
        public ICommand CommandeButtonListing { get; }
        public string Identifiant
        {
            get
            {
                return _identifiant;
            }
            set
            {
                if (_identifiant != value)
                {
                    _identifiant = value;
                    OnPropertyChanged(nameof(Identifiant));
                }
            }
        }
        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }
            set
            {
                if (_motDePasse != value)
                {
                    _motDePasse = value;
                    OnPropertyChanged(nameof(MotDePasse));
                }
            }
        }
        public string ImgAuth
        {
            get
            {
                return _imgAuth;
            }
            set
            {
                _imgAuth = value;
                OnPropertyChanged(nameof(ImgAuth));
            }
        }

        public bool Auth
        {
            get
            {
                return auth;
            }

            set
            {
                auth = value;
            }
        }
        #endregion
        #region Methodes
        public void ActionPageRegistration()
        {
            User unUser = new User(Identifiant,MotDePasse);
            Task.Run(async () =>
            {
                if (await _apiServicesRegistration.PostRegistrationAsync(unUser))
                {
                    ImgAuth = "https://www.aslbadminton.fr/wp-content/uploads/2016/11/Ok-257x300.png";
                    Auth = true;
                }
                else
                {
                    ImgAuth = "http://dd03.blogs.apf.asso.fr/media/02/01/2130280108.jpg";
                    Auth = false;
                }
            });
        }

        public void ActionPage()
        {

            Task.Run(async () =>
            {
                if (await _apiService.GetAuthAsync(new User(Identifiant,MotDePasse),"user"))
                {
                    ImgAuth = "https://www.aslbadminton.fr/wp-content/uploads/2016/11/Ok-257x300.png";
                    Auth = true;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage = new NavigationPage(new Page());
                    });

                }
                else
                {
                    ImgAuth = "http://dd03.blogs.apf.asso.fr/media/02/01/2130280108.jpg";
                    Auth = false;
                }

            });


        }

        #endregion
        #region notifications
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
