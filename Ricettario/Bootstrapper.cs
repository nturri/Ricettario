using Caliburn.Micro;
using Ricettario.ViewModels;
using System;
using System.Windows;

namespace Ricettario
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<RecipesViewModel>();


           
        }

       
    }
}
