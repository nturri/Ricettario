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
using System.Windows.Shapes;

namespace Ricettario.Views
{
    /// <summary>
    /// Logica di interazione per ShellView.xaml
    /// </summary>
    public partial class RecipesView : Window
    {

        public RecipesView()
        {

           InitializeComponent();

            

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            ComboPage.SelectedIndex = 0;
        }
    }
}
