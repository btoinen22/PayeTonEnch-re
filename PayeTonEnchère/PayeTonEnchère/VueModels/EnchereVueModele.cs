using PayeTonEnchère.models;
using PayeTonEnchère.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
            this.GetOneEnchere(new Enchere(DateTime.Now, DateTime.Now, 0, 0, new Produit("nom","photo",0),new TypeEnchere("nom")));
        }


        #endregion

        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEnchere { get => _maListeEnchere; set => _maListeEnchere = value; }

        #endregion

        #region Methodes
        public async void GetOneEnchere(Enchere uneEnchere)
        {
            Enchere._collClass.Clear();
            /*MaListeEnchere = await _apiServices.GetOneAsync<Enchere>
                   ("api/getEnchere", Enchere._collClass, uneEnchere);*/
        }
        #endregion
    }
}
