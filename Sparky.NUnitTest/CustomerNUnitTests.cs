using NUnit.Framework;

namespace Sparky.NUnitTest
{
    [TestFixture]
    public class CustomerNUnitTests
    {

        private Customer customer;

        [SetUp] 
        public void SetUp() 
        {
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange

            //Act
            customer.GreetAndCombineName("Ben", "Spark");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
                Assert.That(customer.GreetMessage, Does.Contain("ben Spark").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });            
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange
            Customer customer = new Customer();

            //Act

            //Assert
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefoultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;

            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineName("ben", "");

            Assert.IsNotNull(customer.GreetMessage);
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("", "Spark"));

            Assert.That(exceptionDetails.Message, Is.EqualTo("Empty First Name"));
            Assert.That(() => customer.GreetAndCombineName("", "spark"), 
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));
            
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("", "Spark"));
            Assert.That(() => customer.GreetAndCombineName("", "spark"),
                Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;

            var result = customer.GetCustomerDetails();

            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatiniumCustomer()
        {
            customer.OrderTotal = 110;

            var result = customer.GetCustomerDetails();

            Assert.That(result, Is.TypeOf<PlatiniumCustomer>());
        }
    }
}
