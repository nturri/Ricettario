using Caliburn.Micro;
using Ricettario.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace Ricettario.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {

        RicetteService ricetteService = new RicetteService();

        public BindableCollection<RecipeModel> Ricette { get; set; }

        public List<RecipeModel> RicetteFull { get; set; }

        private ObservableCollection<Page> _pages;

        public ObservableCollection<Page> Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }
        private Page _spage;

        private const int MAX_ELEMENT_FOR_PAGE = 4;

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

    

        public RecipesViewModel()
        {


            Pages = new ObservableCollection<Page>();

            GetRecipes();

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

            int inizio = page * MAX_ELEMENT_FOR_PAGE;
            int fine = inizio + MAX_ELEMENT_FOR_PAGE;

            for (int i = inizio; i < fine && i<  RicetteFull.Count; i++)
                Ricette.Add(RicetteFull[i]);



        }



        private void Items_CollectionChanbged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("");


          //  if (e.NewItems != null) SelectedItem = (string)e.NewItems[e.NewItems.Count - 1];

        }


      

    }
}
