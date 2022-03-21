using Android.Content.Res;
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
    internal class InscriptionVueModele : BaseVueModele
    {
        #region Attributs

        private readonly Api _apiServices = new Api();

        #endregion

        #region Constructeurs

        public InscriptionVueModele()
        {
            gotoconnexion = new Command(() => gotoco());
        }


        #endregion

        #region Getters/Setters

        public ICommand gotoconnexion { get; }

        #endregion

        #region Methodes
        public async void gotoco()
        {
            var route = $"{nameof(MaConnexionPage)}";
            await Shell.Current.GoToAsync(route);
        }
        
        #endregion


    }
}
