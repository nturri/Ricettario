using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricettario.Models
{
    public class RecipeModel
    {

        public int Id { get; set; }
        public long AggregatedTime { get; set; } = 45;

        public string Level { get; set; } = "facile";

        public string Minutes { get; set; } = "Tempo di preparazione: 20m. Tempo di cottura: 25m";

        public string Name { get; set; } 
            //"Risotto ai funghi porcini e salsiccia";

        public string People { get; set; } = "4";

        public string PicturePath { get; set; } = "http://www.forchettina.it/public/it/risotto-funghi-salsiccia.jpg";

        public DateTime PubDate { get; set; }

        public int ReadCount { get; set; }


    }
}
