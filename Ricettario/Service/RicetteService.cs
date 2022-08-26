
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
        
        private string _urlIngredient = "http://forchettina.azurewebsites.net/api/recipes/get/";

        public  RicetteService()
        { 
        
        }

        //// ReturnContinentModels = new AsyncObservableCollection<ContentModel>(root.products);

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


        public async Task<RecipeFullModel> GetIngredientModels(string id)
        {
            RecipeFullModel ReturnContinentModels = new RecipeFullModel();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
                    using (HttpResponseMessage HttpResponseMessage = await httpClient.GetAsync(string.Concat(_urlIngredient, id), HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                    {
                        if (HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                            using (HttpContent HttpContent = HttpResponseMessage.Content)
                            {
                                string responseBody = await HttpContent.ReadAsStringAsync();
                                return JsonConvert.DeserializeObject<RecipeFullModel>(responseBody);
                           
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

     

    }
}
