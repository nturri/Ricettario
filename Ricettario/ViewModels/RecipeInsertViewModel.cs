using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricettario.ViewModels
{
    public class RecipeInsertViewModel : BaseViewModel
    {
        public RelayCommand Insert { get; }

        public IEnumerable<string> LevelItems { get; }

        public RecipeInsertViewModel()
        {

            LevelItems = new ObservableCollection<string>
            {
                "Facile",
                "Medio",
                "Difficile"
               
            };

        }

    }
}
