using SetSolverEngineConsole.Services;

namespace SetSolverEngineTests.Services
{
    public partial class SolverServiceTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void FindSetsTest(TestDataSet td)
        {
            var result = SolverService.FindSets(td.cards);

            Assert.That(result, Is.EqualTo(td.solveResult));
        }
    }
}