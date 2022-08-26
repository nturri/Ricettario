
using Newtonsoft.Json;
using RestSharp;
using Ricettario.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ricettario
{
    public class RicetteService
    {
        private string _urlRecipe ="http://forchettina.azurewebsites.net/api/recipes/homepagerecipes";
        public  RicetteService()
        { 
        
        }
        /*
        public async Task<List<RecipeModel>>  _GetRicette()
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://forchettina.azurewebsites.net/api/recipes/homepagerecipes");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();


           var ricette = JsonConvert.DeserializeObject< List<RecipeModel>> (responseBody);

            return ricette;
        }
        */

        public async Task<List<RecipeModel>> GetRecipeModels()
        {
            List<RecipeModel> ReturnContinentModels = new List<RecipeModel> ();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
                    using (HttpResponseMessage HttpResponseMessage = await httpClient.GetAsync(string.Concat(_urlRecipe, ""), HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                    {
                        if (HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                            using (HttpContent HttpContent = HttpResponseMessage.Content)
                            {
                                string responseBody = await HttpContent.ReadAsStringAsync();
                                return JsonConvert.DeserializeObject<List<RecipeModel>>(responseBody);


                               // ReturnContinentModels = new AsyncObservableCollection<ContentModel>(root.products);
                            }
                    }
                }
            }
            catch (Exception ex) 
            
            { 
                
                Console.WriteLine(ex.Message); 
            
            }
            return ReturnContinentModels;
        }

        /*
        public async Task<List<IngredientModel>> GetRicetta(string id)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://forchettina.azurewebsites.net/api/recipes/get/"+id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();


            var ricette = JsonConvert.DeserializeObject<List<IngredientModel>>(responseBody);

            return ricette;
        }
        */

    }
}
