using PayeTonEnchère.models;
using PayeTonEnchère.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PayeTonEnchère.VueModels
{
    public class ListeProduitVueModele
    {
        #region Attributs
        private readonly api _apiServices = new api();
        private bool _resultat;
        private ObservableCollection<Produit> maListeProduits;
        #endregion

        #region Constructeurs

        public ListeProduitVueModele()
        {
            Resultat = false;
            PostProduit(new Produit("test", "test", 10));
            //GetListeProduits();
        }


        #endregion

        #region Getters/Setters
        public bool Resultat { get => _resultat; set => _resultat = value; }
        internal ObservableCollection<Produit> MaListeProduits { get => maListeProduits; set => maListeProduits = value; }

        #endregion

        #region Methodes
        public async void GetListeProduits()
        {
            MaListeProduits = await _apiServices.GetAllAsync<Produit>
                   ("api/getProduits", Produit._collClass );
        }

        public async void PostProduit(Produit unProduit)
        {

            Resultat = await _apiServices.PostAsync<Produit>
                   (unProduit, "api/postProduit");
        }
        #endregion

    }
}