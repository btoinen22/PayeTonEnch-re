using PayeTonEnchère.models;
using PayeTonEnchère.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PayeTonEnchère.VueModels
{
    public class AccueilVueModele : BaseVueModele
    {
        #region Attributs

        private readonly Api _apiServices = new Api();
        private ObservableCollection<Enchere> _maListeEnchere;
        private ObservableCollection<Enchere> _maListeEnchereEnCours;

        public ObservableCollection<Enchere> MaListeEnchereEnCours
        {
            get { return _maListeEnchereEnCours; }
            set { SetProperty(ref _maListeEnchereEnCours, value); }
        }

        #endregion
        #region Constructeurs

        public AccueilVueModele()
        {
            GetEnchereEnCours();
        }


        #endregion

        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEnchere { get => _maListeEnchere; set => _maListeEnchere = value; }

        #endregion

        #region Methodes

        public async void GetEnchereEnCours()
        {
            MaListeEnchereEnCours = await _apiServices.GetAllAsync<Enchere>
                    ("getEncheresEnCours", Enchere.CollClass);
            
            Enchere.CollClass.Clear();
        }
        #endregion
    }
}
