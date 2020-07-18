using Xunit;

namespace UnitTests.Tests
{
    // Used to manager a order of call tests method
    // IMPORTANT: We must be careful to use this resource, specially in unit tests, because we shouldn't have coupling 
    // {namespace orderer} {namespace tests}
    [TestCaseOrderer("UnitTests.Tests.PriorityOrderer", "UnitTests.Tests")]
    public class OrderTests
    {
        private static bool test1Called;
        private static bool test2Called;
        private static bool test3Called;

        [Fact, TestPriority(2)]
        [Trait("Category", "OrderTests")]
        public void Test2()
        {
            test2Called = true;

            Assert.True(test1Called);
            Assert.False(test3Called);
        }

        [Fact, TestPriority(3)]
        [Trait("Category", "OrderTests")]
        public void Test3()
        {
            test3Called = true;

            Assert.True(test1Called);
            Assert.True(test2Called);
        }

        [Fact, TestPriority(1)]
        [Trait("Category", "OrderTests")]
        public void Test1()
        {
            test1Called = true;

            Assert.False(test2Called);
            Assert.False(test3Called);
        }
    }
}
