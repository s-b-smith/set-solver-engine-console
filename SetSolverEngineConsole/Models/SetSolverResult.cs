using System.Text;

namespace SetSolverEngineConsole.Models
{
    public class SetSolverResult(int numSets, HashSet<Set> sets)
    {
        public readonly int numSets = numSets;
        public readonly HashSet<Set> sets = sets;

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.Append($"{numSets} total set{(numSets == 1 ? "" : "s")}");
            if (numSets != 0)
            {
                sb.Append('\n');
                sb.Append(string.Join("\n\n", sets.ToList()));
            }

            return sb.ToString();
        }

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
