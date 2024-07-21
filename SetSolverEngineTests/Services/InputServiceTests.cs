using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
using SetSolverEngineConsole.Services;
using static SetSolverEngineConsole.Constants.DisplayStrings;

namespace SetSolverEngineTests.Services
{
    public class InputServiceTests
    {
        [Test]
        public void ValidateCardInputTest_Valid1()
        {
            // Purple, Diamond, One, Empty
            var cardInput = "PD1E";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void ValidateCardInputTest_Valid2()
        {
            // Squiggle, Green, Striped, Two
            var cardInput = "QGT2";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void ValidateCardInputTest_Valid3()
        {
            // Three, Solid, Red, Circle
            var cardInput = "3SRC";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void ValidateCardInputTest_MixedCase_Valid()
        {
            // Green, Circle, Two, Striped
            var cardInput = "Gc2t";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void ValidateCardInputTest_NotEnoughChars()
        {
            // NA, Diamond, Three, Empty
            var cardInput = "D3e";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(GetDisplayStringWithUserInput(ARE_YOU_MISSING_INPUT, cardInput)));
        }

        [Test]
        public void ValidateCardInputTest_TooManyChars()
        {
            // Red, Circle, Squiggle, Two, Striped
            var cardInput = "RCq2t";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(GetDisplayStringWithUserInput(TOO_MANY_CHARACTERS, cardInput)));
        }

        [Test]
        public void ValidateCardInputTest_InvalidColor()
        {
            // INVALID, Squiggle, Three, Solid
            var cardInput = "xQ3s";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(GetDisplayStringWithUserInput(NO_VALID_COLOR_GIVEN, cardInput)));
        }

        [Test]
        public void ValidateCardInputTest_InvalidShape()
        {
            // Green, INVALID, One, Empty
            var cardInput = "go1e";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(GetDisplayStringWithUserInput(NO_VALID_SHAPE_GIVEN, cardInput)));
        }

        [Test]
        public void ValidateCardInputTest_InvalidNum()
        {
            // Purple, Diamond, INVALID, Striped
            var cardInput = "PD,T";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(GetDisplayStringWithUserInput(NO_VALID_NUMBER_GIVEN, cardInput)));
        }

        [Test]
        public void ValidateCardInputTest_InvalidShading()
        {
            // Red, Squiggle, Two, INVALID
            var cardInput = "Rq2@";
            var result = InputService.ValidateCardInput(cardInput);

            Assert.That(result, Is.EqualTo(GetDisplayStringWithUserInput(NO_VALID_SHADING_GIVEN, cardInput)));
        }

        [Test]
        public void GetCardFromInputTest_RedDiamondOneStriped()
        {
            // Red, Diamond, One, Striped
            var cardInput = "RD1T";
            var result = InputService.GetCardFromInput(cardInput);

            Assert.That(result, Is.EqualTo(
                new Card(CardProps.COLOR.RED, CardProps.SHAPE.DIAMOND, CardProps.NUM.ONE, CardProps.SHADING.STRIPED)));
        }

        [Test]
        public void GetCardFromInputTest_GreenSquiggleTwoSolid()
        {
            // Green, Squiggle, Two, Solid
            var cardInput = "GQ2S";
            var result = InputService.GetCardFromInput(cardInput);

            Assert.That(result, Is.EqualTo(
                new Card(CardProps.COLOR.GREEN, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.TWO, CardProps.SHADING.SOLID)));
        }

        [Test]
        public void GetCardFromInputTest_PurpleCircleThreeEmpty()
        {
            // Purple, Circle, Three, Empty
            var cardInput = "PC3E";
            var result = InputService.GetCardFromInput(cardInput);

            Assert.That(result, Is.EqualTo(
                new Card(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.THREE, CardProps.SHADING.EMPTY)));
        }

        [Test]
        public void GetCardFromInputTest_NotEnoughChars()
        {
            // Red, NA, Two, Solid
            var cardInput = "R2S";

            Assert.That(() => InputService.GetCardFromInput(cardInput),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo(ExceptionStrings.InvalidCardInput(cardInput)));
        }

        [Test]
        public void GetCardFromInputTest_TooManyChars()
        {
            // Green, Diamond, Squiggle, One, Striped
            var cardInput = "GDq1t";

            Assert.That(() => InputService.GetCardFromInput(cardInput),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo(ExceptionStrings.InvalidCardInput(cardInput)));
        }

        [Test]
        public void GetCardFromInputTest_InvalidColor()
        {
            // INVALID, Squiggle, Two, Empty
            var cardInput = "XQ2E";

            Assert.That(() => InputService.GetCardFromInput(cardInput),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo(ExceptionStrings.InvalidCardInput(cardInput)));
        }

        [Test]
        public void GetCardFromInputTest_InvalidShape()
        {
            // Red, INVALID, Three, Solid
            var cardInput = "R*3S";

            Assert.That(() => InputService.GetCardFromInput(cardInput),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo(ExceptionStrings.InvalidCardInput(cardInput)));
        }

        [Test]
        public void GetCardFromInputTest_InvalidNum()
        {
            // Purple, Diamond, INVALID, Striped
            var cardInput = "PD.T";

            Assert.That(() => InputService.GetCardFromInput(cardInput),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo(ExceptionStrings.InvalidCardInput(cardInput)));
        }

        [Test]
        public void GetCardFromInputTest_InvalidShading()
        {
            // Green, Circle, One, INVALID
            var cardInput = "GC1M";

            Assert.That(() => InputService.GetCardFromInput(cardInput),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo(ExceptionStrings.InvalidCardInput(cardInput)));
        }

        [Test]
        public void GetCardFromInputTest_ValidCharsButMissingProp()
        {
            // Red, Purple, Two, Solid
            var cardInput = "RP2S";

            Assert.That(() => InputService.GetCardFromInput(cardInput),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo(ExceptionStrings.InvalidCardInput(cardInput)));
        }
    }
}
