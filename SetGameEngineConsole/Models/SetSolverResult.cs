using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetSolverEngineConsole.Models
{
    internal class SetSolverResult(int numSets, Set[] sets)
    {
        public readonly int numSets = numSets;
        public readonly Set[] sets = sets;
    }
}
