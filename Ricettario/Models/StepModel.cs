using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricettario.Models
{
    public class StepModel
    {
        public int Index { get; set; } = 1;
        public long Type { get; set; } = 1;
        public string Value { get; set; } = "Lava le patate sotto l'acqua corrente, pelale e poi falle lessare dentro ad una pentola con abbondante acqua e un po' di sale.Scolale e passale allo schiacciapatate o in alternativa aiutati con una forchetta.";

        public string PicturePath { get; set; } = "http://www.forchettina.it/public/it/risotto-funghi-salsiccia.jpg";
    }
}
