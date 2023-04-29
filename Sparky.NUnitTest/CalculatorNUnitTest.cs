using NUnit.Framework;

namespace Sparky.NUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTest
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange

            //Act
            int result = calculator.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            //Arrange

            //Act
            bool isOdd = calculator.IsOddNumber(10);

            //Assert
            //Assert.That(isOdd, Is.EqualTo(false));
            Assert.IsFalse(isOdd);
        }

        [Test]
        [TestCase(13)]
        [TestCase(11)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange

            //Act
            bool isOdd = calculator.IsOddNumber(a);

            //Assert
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddNumber_InputNumber_ReturnTrueIfOdd(int a)
        {
            return calculator.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] //15.93
        [TestCase(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange

            //Act
            double result = calculator.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result, .2);
            //15.7-16.1
        }

        [Test]
        public void OddRanger_inputMinAndMaxRange_ReturnsValidOddNumerRange()
        {
            //Arrenge
            List<int> expectedOddRenge = new() { 5, 7, 9 }; //5-10

            //Act
            List<int> result = calculator.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRenge));
            //Assert.AreEqual(expectedOddRenge, result);
            //Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
