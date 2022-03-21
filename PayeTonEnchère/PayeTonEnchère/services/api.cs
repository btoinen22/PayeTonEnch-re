using Newtonsoft.Json;
using PayeTonEnchère.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PayeTonEnchère.services
{
    internal class Api
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
                Console.Write(ex.ToString());
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
                Console.Write(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Ajout d'un objet à la base de donnée
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="paramUrl"></param>
        /// <returns></returns>
        public async Task<bool> PostAsync<T>(T param, string paramUrl)
        {

            var jsonstring = JsonConvert.SerializeObject(param); // sérialize l'objet ( convertion en json )

            try
            {
                var client = new HttpClient(); // création d'une instance httpClient
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json"); // création d'une instance stringContent
                var response = await client.PostAsync(Constantes.APIenchere +paramUrl, jsonContent);// Envoi de l'objet dans l'API
                var content = await response.Content.ReadAsStringAsync(); // ??
                var result = content == "OK" ? true : false; // valeur de vérification
                return result; // retourne la valeur de result
            }
            catch (Exception ex)
            {
                var error = string.Format("Time: {0}\r\nError: Unhandled Exception\r\n{1}\n\n", DateTime.Now, ex); // formatage de l'erreur
                Console.WriteLine(error); // affichage de l'erreur
                return false; // retourne false
            }
        }
        public async Task<bool> GetAuthAsync<T>(T param)
        {
            var jsonstring = JsonConvert.SerializeObject(param);
            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.APIenchere + "Get", jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                var result = content == "OK" ? true : false;
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        

        public async Task<bool> GetAuth<T>(T param)
        {
            var jsonstring = JsonConvert.SerializeObject(param);
            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.APIenchere + "GetUserByMailAndPass", jsonContent);
                var content = await response.Content.ReadAsStringAsync();
#pragma warning disable IDE0075 // Simplifier l’expression conditionnelle
                var result = content == "OK" ? true : false;
#pragma warning restore IDE0075 // Simplifier l’expression conditionnelle
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }
    }
}
