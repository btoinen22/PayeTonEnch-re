using PayeTonEnchère.models;
using PayeTonEnchère.services;
using PayeTonEnchère.Vues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PayeTonEnchère.VueModels
{
    internal class InscriptionVueModele : INotifyPropertyChanged
    {
        #region Attributs

        private readonly Api _apiServices = new Api();

        #endregion

        #region Constructeurs

        public InscriptionVueModele()
        {
            PostUser(new User("test", "test"));
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);
        }

        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonRetour { get; }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Methodes
        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new Page();
        }
        public async void PostUser(User unUser)
        {
            await _apiServices.PostAsync<User>(unUser, "postUser");
        }

        
        #endregion


    }
}
