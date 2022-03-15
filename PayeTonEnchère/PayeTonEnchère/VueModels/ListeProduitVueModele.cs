using Newtonsoft.Json;
using PayeTonEnchère.models;
using PayeTonEnchère.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        /// <summary>
        /// ajout de tout les objets créer dans la base de donnée
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="paramUrl"></param>
        /// <returns></returns>
        public async Task<bool> PostAsync<T>(T param, string paramUrl)
        {

            var jsonstring = JsonConvert.SerializeObject(param);

            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.APIenchere + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                var result = content == "OK" ? true : false;
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

    }
}