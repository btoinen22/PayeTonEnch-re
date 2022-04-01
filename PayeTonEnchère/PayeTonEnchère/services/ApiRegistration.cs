using Newtonsoft.Json;
using PayeTonEnchère.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PayeTonEnchère.services
{
    class ApiRegistration
    {
        #region Methodes
        public async Task<bool> PostRegistrationAsync(User unUser)
        {

            var jsonstring = JsonConvert.SerializeObject(unUser);
            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.ApIenchere + "register", jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        #endregion
    }
}