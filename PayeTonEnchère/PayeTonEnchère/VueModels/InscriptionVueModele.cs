using PayeTonEnchère.models;
using PayeTonEnchère.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PayeTonEnchère.VueModels
{
    internal class InscriptionVueModele : INotifyPropertyChanged
    {
        #region Attributs

        private readonly api _apiServices = new api();

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

        #endregion

        #region Methodes
        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new IndexPageVue();
        }
        public async void PostUser(User unUser)
        {

            int resultat = await _apiServices.PostAsync<User>(unUser, "api/postUser");
        }
        #endregion
          
        /* ---------------------------- */


    }
}
