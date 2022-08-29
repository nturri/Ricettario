
using Ricettario.ViewModels;
using Ricettario.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricettario
{
  

        public static class WindowService
        {
            static public void ShowDialog(
                string titolo, BaseViewModel viewModel,
                double? width = null, double? height = null)
            {
                WindowServiceView window = new WindowServiceView()
                {
                    DataContext = viewModel
                };

                if (width != null)
                {
                    window.Width = width.Value;
                    if (height != null) window.Height = height.Value;
                }
                window.ShowDialog();
            }

        static public void ShowDialog2()
        {

            RecipeInsertViewModel recipeInsertViewModel = new RecipeInsertViewModel();

            RecipesInsert recipesInsert = new RecipesInsert();

            recipesInsert.DataContext = recipeInsertViewModel;

            recipesInsert.Show();
        
        }

        }


        /*  static public void ShowDialog( string id)
          {

              RicetteService ricetteService = new RicetteService();


              var ContentTask = ricetteService.GetIngredientModels(id);


              ContentTask.Wait();

             var viewModel = ContentTask.Result;




          }*/
    }

