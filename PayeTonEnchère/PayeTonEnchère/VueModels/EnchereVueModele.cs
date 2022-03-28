
using PayeTonEnchère.models;
using PayeTonEnchère.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PayeTonEnchère.VueModels
{
    internal class EnchereVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();
        private ObservableCollection<Enchere> _maListeEnchere;

        #endregion

        #region Constructeurs
        public EnchereVueModele()
        {
            GetListeEncheresEnCour();

        }



        #endregion

        #region Getters/Setters


        public ObservableCollection<Enchere> MaListeEnchere
        {
            get
            {
                return _maListeEnchere;
            }
            set { _maListeEnchere = value; }
        }

        #endregion

        #region Methodes

        /// Affichage de la liste des enchére en cours
        /// <returns>récupère les données des enchere en cours  à partir de la méthode d'API GetAllAsync</returns>
        
        public async void GetListeEncheresEnCour()
        {
            MaListeEnchere = await _apiServices.GetAllAsync<Enchere>
                (ServiceApi.ApiEncheresEnCours, Enchere.CollClass);
            Enchere.CollClass.Clear();
        }


        #endregion
    }
}

