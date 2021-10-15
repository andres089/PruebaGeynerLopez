using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using FrontEnd.Models;

namespace FrontEnd.Controllers.Base
{
    public class BaseController : Controller
    {
        public static HttpClient httpClient;
        internal static void Initializer()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["Api"]);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", ConfigurationManager.AppSettings["Token"]);
            }
        }
        internal static async Task<T> GetAsync<T>(string path, string token) where T : class
        {
            Initializer();
            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<T>();
                return result;
            }
            return null;
        }

        internal static async Task<RespuestaViewModel> PostAsync<T, P>(string path, T element, string token) where T : class where P : class
        {
            Initializer();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(path, element);
            var rta = new RespuestaViewModel { Correcto = response.IsSuccessStatusCode };
            if (rta.Correcto)
                rta.Elemento = await response.Content.ReadAsAsync<P>();
            else
                rta.Mensaje = await response.Content.ReadAsAsync<string>();
            return rta;


        }

        internal static async Task<P> PutAsync<T, P>(string path, T element) where P : class where T : class
        {
            Initializer();
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(path, element);

            try
            {
                var result = await response.Content.ReadAsAsync<P>();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task<bool> DeleteAsync(string path)
        {
            Initializer();
            HttpResponseMessage response = await httpClient.DeleteAsync(path);
            return response.IsSuccessStatusCode;
        }

        
    }
}