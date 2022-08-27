using Ricettario.Models;
using Ricettario.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ricettario.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class RecipeControl : UserControl
    {
        /*
        public static readonly RoutedEvent ClickB1Event = EventManager.RegisterRoutedEvent(
         "ClickB1", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RecipeControl));

  

        public event RoutedEventHandler ClickB1
        {
            add { AddHandler(ClickB1Event, value); }
            remove { RemoveHandler(ClickB1Event, value); }
        }
        */

        public RecipeControl()
        {
            InitializeComponent();

           
        }

        private void DettaglioRicetta_Click(object sender, RoutedEventArgs e)
        {

           var model =  DataContext as RecipeModel;


            GlobalVars.ultimoIDClikkato = model.Id;



        }


        #region Items
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                "Items",
                typeof(IEnumerable<RecipeModel>),
                typeof(RecipeControl),
                new UIPropertyMetadata(null));
        public IEnumerable<RecipeModel> Items
        {
            get { return (IEnumerable<RecipeModel>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        #endregion


        #region Dettaglio
        public static readonly DependencyProperty DettaglioItemProperty =
            DependencyProperty.Register(
                "Dettaglio",
                typeof(ICommand),
                typeof(RecipeControl),
                new UIPropertyMetadata(null));
        public ICommand Dettaglio
        {
            get { return 
                    
                    (ICommand)GetValue(DettaglioItemProperty);
            
            
            }
            set { SetValue(DettaglioItemProperty, value); }
        }
        #endregion*/
    }

}
