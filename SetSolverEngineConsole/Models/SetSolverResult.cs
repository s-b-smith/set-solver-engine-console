using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetSolverEngineConsole.Models
{
    public class SetSolverResult(int numSets, HashSet<Set> sets)
    {
        public readonly int numSets = numSets;
        public readonly HashSet<Set> sets = sets;

        public override bool Equals(object? obj)
        {
            return obj is SetSolverResult solveResult
                && solveResult.numSets == numSets
                && solveResult.sets.SetEquals(sets);
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash *= 8 * numSets;
            hash *= 9 * sets.GetHashCode();

            return hash;
        }
    }
}
