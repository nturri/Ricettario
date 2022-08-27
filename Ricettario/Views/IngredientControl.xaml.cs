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
    /// Logica di interazione per IngredientControl.xaml
    /// </summary>
    public partial class IngredientControl : UserControl
    {

       
        public IngredientControl()
        {
            InitializeComponent();
        }

        private void StackPanel_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
