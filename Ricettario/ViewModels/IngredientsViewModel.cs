using Ricettario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricettario.ViewModels
{
    public class IngredientsViewModel : BaseViewModel
    {

       

        public IngredientsViewModel()
        { 
        
        }


        protected Models.RecipeFullModel model = null;

        public IngredientsViewModel(Models.RecipeFullModel model)
        {
            this.model = model;
        }

        public string Name
        {
            get => model.Name;
            
        }

    }
}
