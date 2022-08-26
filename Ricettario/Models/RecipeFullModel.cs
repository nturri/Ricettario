using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricettario.Models
{
    public class RecipeFullModel : RecipeModel
    {

        public List<IngredientModel> Ingredients { get; set; }

        public List<StepModel> Steps { get; set; }

        public string StepsAdditionalInfo { get; set; } = "In alternativa al solito piatto, per rendere più saporito il purè, aggiungi un pizzico di noce moscata e del parmigiano reggiano";

        public string IngredientsAdditionalInfo { get; set; }


    }
}
