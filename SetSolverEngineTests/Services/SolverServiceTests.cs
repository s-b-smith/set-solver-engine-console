using SetSolverEngineConsole.Services;

namespace SetSolverEngineTests.Services
{
    public partial class SolverServiceTests
    {
        private SolverService _solverService;

        [SetUp]
        public void Setup()
        {
            _solverService = new SolverService();
        }

        [TestCaseSource(nameof(TestCases))]
        public void FindSetsTest(TestDataSet td)
        {
            var result = _solverService.FindSets(td.cards);

            Assert.That(result, Is.EqualTo(td.solveResult));
        }
    }
}