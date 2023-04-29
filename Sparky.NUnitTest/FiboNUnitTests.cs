using NUnit.Framework;

namespace Sparky.NUnitTest
{
    [TestFixture]
    public class FiboNUnitTests
    {
        private Fibo fibo;

        [SetUp]
        public void SetUp()
        {
            fibo = new Fibo();
        }

        [Test]
        public void FiboCheck_InputRange1_ReturnsFiboSeries()
        {
            fibo.Range = 1;
            List<int> expectedList = new() { 0 };

            List<int> result = fibo.GetFiboSeries();

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Empty);
                Assert.That(result, Is.Ordered);
                Assert.That(result, Is.EquivalentTo(expectedList));
            });
        }

        [Test]
        public void FiboCheck_InputRange6_ReturnsFiboSeries()
        {
            fibo.Range = 6;
            List<int> expectedList = new() { 0, 1, 1, 2, 3, 5 };

            List<int> result = fibo.GetFiboSeries();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.Contain(3));
                Assert.That(result.Count, Is.EqualTo(6));
                Assert.That(result, Has.No.Member(4));
                Assert.That(result, Is.EquivalentTo(expectedList));
            });
        }
    }
}
