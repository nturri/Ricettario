using Ricettario.Dialog;
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
       


        static public void ShowDialog( string id)
        {

            RicetteService ricetteService = new RicetteService();


            var ContentTask = ricetteService.GetIngredientModels(id);


            ContentTask.Wait();

           var viewModel = ContentTask.Result;

           

          
        }
    }
}
