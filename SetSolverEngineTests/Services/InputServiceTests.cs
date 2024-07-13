using SetSolverEngineConsole.Services;

namespace SetSolverEngineTests.Services
{
    public partial class InputServiceTests
    {
        private InputService _inputService;

        [SetUp]
        public void Setup()
        {
            _inputService = new InputService();
        }

        [TestCaseSource(nameof(ValidateCardInputTestCases))]
        public void ValidateCardInputTest(ValidateInputTestDataSet td)
        {
            var result = _inputService.ValidateCardInput(td.cardInput);

            Assert.That(result, Is.EqualTo(td.result));
        }

        [TestCaseSource(nameof(GetCardInputTestCases))]
        public void GetCardInputTest(GetCardInputTestDataSet td)
        {
            var result = _inputService.GetCardFromInput(td.cardInput);

            Assert.That(result, Is.EqualTo(td.result));
        }
    }
}
