using Caliburn.Micro;
using Ricettario.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Ricettario.ViewModels
{

  

    public class RecipesViewModel : BaseViewModel
    {

        RicetteService ricetteService = new RicetteService();

        public BindableCollection<RecipeModel> Ricette { get; set; }

        public ObservableCollection<IngredientModel> IngredientiRicetta { get; set; }

        public ObservableCollection<StepModel> StepRicetta { get; set; }


        public List<RecipeModel> RicetteFull { get; set; }

        private ObservableCollection<Page> _pages;

        public string Titolo = "Ricettario";

      

        public ObservableCollection<Page> Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }
        private Page _spage;

        private const int MAX_ELEMENT_FOR_PAGE = 4;



        public ICommand Dettaglio { get; private set; }


        public ObservableCollection<RecipeModel> Items { get; private set; }


        //  public BaseViewModel IngredientsVM = new IngredientsViewModel(new RecipeFullModel());

        public Page SPage
        {
            get {

                if (_spage != null)
                    { 

                      setPageRicetta(_spage.Id);
                    }

                return _spage; 
            
            
            }
            set { _spage = value; }
        }

    

        public RecipesViewModel(BaseViewModel _IngredientsVM)
        {

           

            Pages = new ObservableCollection<Page>();

            GetRecipes();

            GlobalVars.recipesViewModel = this;

        }

        public RecipesViewModel()
        {

            Dettaglio = new RelayCommand(dettaglioMethod, dettaglioCanExec);

            Pages = new ObservableCollection<Page>();

            GetRecipes();

            GlobalVars.recipesViewModel = this;
           
        }

        private void dettaglioMethod(object param)
        {

        }

        private bool dettaglioCanExec(object param)
        {
            return false; 
        }

        public void Aggiorna()
        {
           MessageBox.Show("aggiornato");

        }

     



        private void GetRecipes()

        {
            var ContentTask = ricetteService.GetRecipeModels();

            ContentTask.Wait();

            RicetteFull = ContentTask.Result;


            Ricette = new BindableCollection<RecipeModel>();

            setPageRicetta(0);

            calcolaPagine();
          

            Pages.CollectionChanged += Items_CollectionChanbged;


           


        }


        private void GetIngredient(string id)
        {
            RicetteService ricetteService = new RicetteService();


            Notify();

            var ContentTask = ricetteService.GetIngredientModels(id);

            ContentTask.Wait();

            var recipeFullModel = ContentTask.Result;


            RecipeName = recipeFullModel.Name;

           

            IngredientiRicetta = new  ObservableCollection<IngredientModel>();

            StepRicetta = new ObservableCollection<StepModel>();

            foreach (var ingred in recipeFullModel.Ingredients)

               IngredientiRicetta.Add (ingred);

            int countStep = 0;

            foreach (var step in recipeFullModel.Steps)
            {

                countStep++;

                if (step.Type == 1)
                {
                    step.PicturePath = "";
                }

                if (step.Type == 2)
                {
                    step.PicturePath = "http://www.forchettina.it" + step.Value;

                    step.Value = "";
                }


                step.Index = countStep;

                StepRicetta.Add(step);

              //  recipeFullModel.StepsAdditionalInfo = "test1";
               // recipeFullModel.IngredientsAdditionalInfo = "test2";


                stepsAdditionalInfo = recipeFullModel.StepsAdditionalInfo;
                ingredientsAdditionalInfo = recipeFullModel.IngredientsAdditionalInfo;
            }

            /*Notify(nameof(ingredientsAdditionalInfo));

            Notify(nameof(stepsAdditionalInfo));*/

            Notify(nameof(IngredientiRicetta));

            Notify(nameof(StepRicetta));

          //  Notify();
        }


        private void calcolaPagine()
        {
            int pagine = RicetteFull.Count / MAX_ELEMENT_FOR_PAGE;

            if (RicetteFull.Count % MAX_ELEMENT_FOR_PAGE != 0)
                pagine++;


            for (int i = 0; i < pagine; i++)
            {
                var el = "Pagina " + (i + 1).ToString();

                Page page = new Page();
                page.Id = i;
                page.Name = el;

                Pages.Add(page);

            }

        }


        private void setPageRicetta(int page)
        {
            Ricette.Clear();

            Items = new ObservableCollection<RecipeModel>();

            int inizio = page * MAX_ELEMENT_FOR_PAGE;
            int fine = inizio + MAX_ELEMENT_FOR_PAGE;

            for (int i = inizio; i < fine && i < RicetteFull.Count; i++)
            {
                Ricette.Add(RicetteFull[i]);
                Items.Add(RicetteFull[i]);
            }
            

           // GetIngredient(Ricette[0].Id.ToString());


        }

        public void setRicetta(string id)
        {
          


            GetIngredient(id);
        }



            private void Items_CollectionChanbged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("");


          //  if (e.NewItems != null) SelectedItem = (string)e.NewItems[e.NewItems.Count - 1];

        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                NotifyPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        private string recipeName;

        public string RecipeName { get => recipeName; set => SetProperty(ref recipeName, value); }



        private string titleRecipeName;

        public string TitleRecipeName { get => titleRecipeName; set => SetProperty(ref titleRecipeName, value); }




        public string stepsAdditionalInfo;

        public string StepsAdditionalInfo { get => stepsAdditionalInfo; set => SetProperty(ref stepsAdditionalInfo, value); }



        public string ingredientsAdditionalInfo;

        public string IngredientsAdditionalInfo { get => ingredientsAdditionalInfo; set => SetProperty(ref ingredientsAdditionalInfo, value); }


        /*

    public string IngredientsAdditionalInfo
    */

    }
}
