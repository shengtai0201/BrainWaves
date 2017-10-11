using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainWaves.Models
{
    public class CategorySeries
    {
        public int Index { get; set; }

        public double Delta { get; set; }

        public double Theta { get; set; }

        public double Alpha { get; set; }

        public double Beta { get; set; }

        public double Gamma { get; set; }
    }
}
