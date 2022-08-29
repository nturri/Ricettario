using Ricettario.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ricettario.ViewModels
{
    public class RecipeInsertViewModel : BaseViewModel
    {
        public RelayCommand InsertIngredient { get; }

        

        public IEnumerable<string> LevelItems { get; }

        public RecipeModel recipeModel;


        public ICommand SalvaRicetta { get; private set; }

        public string name { get; set; }

        public string minutes { get; set; }

        public string people { get; set; }

        public string ingredientsAdditionalInfo { get; set; }

        public string stepsAdditionalInfo { get; set; }

        public string ingredientsItem { get; set; }

        public string stepsItem { get; set; }

        private ObservableCollection<Level> _levels = new ObservableCollection<Level>
       {
        new Level { Id=1, Name = "Facile"},
        new Level { Id=1, Name = "Medio"},
        new Level { Id=1, Name = "Avanzato"},

      };


        public IEnumerable<Level> Levels
        {
            get { return _levels; }
        }


        private Level _NodeLevels;
        public Level NodeLevels
        {
            get
            {
                return _NodeLevels;
            }
            set
            {
                _NodeLevels = value;
                NotifyPropertyChanged("NodeLevels");

            }
        }

        public ObservableCollection<string> Ingredients { get; set; }

        public ObservableCollection<StepModel> Steps { get; set; }
        public string selectedName { get; set; }

        public RecipeInsertViewModel()
        {

            /*   LevelItems = new ObservableCollection<string>
               {
                   "Facile",
                   "Medio",
                   "Difficile"

               };
               */



            Ingredients = new ObservableCollection<string>();


            recipeModel = new RecipeModel();

            SalvaRicetta = new RelayCommand(saveMethod, saveCanExec);

            InsertIngredient = new RelayCommand(addIngredientMethod, addIngredientCanExec);

        }

        private void saveMethod(object param)
        {

            MessageBox.Show(name);

        }

        private bool saveCanExec(object param)
        {
            return true;
        }



        private void addIngredientMethod(object param)
        {
            Ingredients.Add(ingredientsItem);

            //MessageBox.Show(ingredientsItem);

        }

        private bool addIngredientCanExec(object param)
        {
            return true;
        }
    }
}
