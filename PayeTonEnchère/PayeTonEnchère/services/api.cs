using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                var json = await clientHttp.GetStringAsync(Constantes.ApIenchere + paramUrl);
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
        /// Get One Item whith a list of parameters in the request
        /// This method is generic and work with values that have toString() method
        /// </summary>
        /// <param name="paramUrl"></param>
        /// <param name="parameters">Dictionnary with Key = param name  and Value = param value</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> GetOneAsync<T>(string paramUrl, Dictionary<string, object> parameters)
        {
            try
            {
                JObject getResult = JObject.Parse(GetJsonString(parameters));
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var clientHttp = new HttpClient();
                var response = await clientHttp.PostAsync(Constantes.ApIenchere + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                T res = JsonConvert.DeserializeObject<T>(json);
                return res;
            }
            catch (Exception)
            {
                return default;
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
                var response = await client.PostAsync(Constantes.ApIenchere +paramUrl, jsonContent);// Envoi de l'objet dans l'API
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
                var response = await client.PostAsync(Constantes.ApIenchere + "Get", jsonContent);
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
                var response = await client.PostAsync(Constantes.ApIenchere + "GetUserByMailAndPass", jsonContent);
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

        /// <summary>
        /// Get a Jsonstring for all the parameters with their name and value
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetJsonString(Dictionary<string, object> parameters)
        {
            string jsonString = @"{";
            int i = 0;
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                i++;
                jsonString += @"'" + parameter.Key + "':'" + parameter.Value + "'";
                if (i != parameters.Count)
                    jsonString += @",";
            }
            jsonString += @"}";
            return jsonString;
        }
    }
}
