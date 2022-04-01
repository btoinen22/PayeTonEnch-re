using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PayeTonEnchère.services
{
    internal class ApiAuthentification
    {
        #region Attributs 
        #endregion
        #region Methodes
        /*public async Task<bool> GetAuthAsync(string Email, string password)
        {
            User modelData = new User(Email, password);
            var jsonstring = JsonConvert.SerializeObject(modelData);
            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.APIenchere + "api/login_check", jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                if (content.Contains("token"))
                {
                    Tokens token = JsonConvert.DeserializeObject<Tokens>(content);
                    this.StockerMotDePasse(token.Token);
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }*/

        /*public async void StockerMotDePasse(string letoken)
        {
            try
            {
                await SecureStorage.SetAsync("token", letoken);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }*/
        #endregion 
    }
}