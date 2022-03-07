﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PayeTonEnchère.services
{
    internal class api
    {
        /// <summary>
        /// Cette methode est générique
        /// Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        /// 
        /// </summary>
        /// <typeparam name="T">la classe concernée</typeparam>
        /// <param name="paramUrl">l'adresse de l'API</param>
        /// <param name="param">la collection de classe concernee</param>
        /// public async void GetListe()
        ///{
        ///MaListeClients = await _apiServices.GetAllAsync<Client>("api/clients", Client.CollClasse);
        ///}
        /// <returns>la liste des occurences</returns>
        public async Task<ObservableCollection<T>> GetAllAsync<T>(string paramUrl, List<T> param)
        {
            try
            {
                var clientHttp = new HttpClient();
                var json = await clientHttp.GetStringAsync(Constantes.APIenchere + paramUrl);
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetListes<T>(param);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<ObservableCollection<T>> GetOneAsync<T>(string paramUrl, List<T> param, T param2)
        {
            try
            {
                var jsonstring = JsonConvert.SerializeObject(param2);
                var clientHttp = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");

                var response = await clientHttp.PostAsync(Constantes.APIenchere + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetListes<T>(param);
            }
            catch (Exception ex)
            {
                return null;
            }
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
    }
}
