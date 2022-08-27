using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricettario
{
    public class GlobalVars
    {
        public static int ultimoIDClikkato=0;


        private readonly List<int> _fooSubject = new List<int>(0);
        public int FooState
        {
            get => _fooSubject[0];
            set => _fooSubject.Add(value);
        }
        public IObservable<int> ObservableFooState => (IObservable<int>) _fooSubject;

    }
}
