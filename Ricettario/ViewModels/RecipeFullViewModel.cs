using Ricettario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricettario.ViewModels
{
    public class RecipeFullViewModel : BaseViewModel
    {

       
        public RecipeFullViewModel()
        { 
        
        }

       

        protected Models.RecipeFullModel model = new RecipeFullModel();

        public RecipeFullViewModel(Models.RecipeFullModel model)
        {
            this.model = model;
        }

        public string Name
        {
            get => model.Name;

            set
            {
                model.Name = value;
                Notify();
            }

        }

        public string Level
        {
            get => model.Level;

            set
            {
                model.Level = value;
                Notify();
            }

        }

    }
}
