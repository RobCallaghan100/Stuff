using NUnit.Framework;

namespace Lists
{
    [TestFixture]
    public class StackTest
    {
        private Stack _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new Stack();
        }

        [TearDown]
        public void Teardown()
        {
            _stack = null;
        }

        [Test]
        public void ShouldPushIntoStack()
        {
            _stack.Push(1);
            _stack.Push(2);

            Assert.That(_stack.Count(), Is.EqualTo(2));
            Assert.That(_stack.Peek(), Is.EqualTo(2));
        }

        [Test]
        public void ShouldPopFromStack()
        {
            _stack.Push(1);
            _stack.Push(2);

            var value = _stack.Pop();

            Assert.That(value, Is.EqualTo(2));
            Assert.That(_stack.Peek(), Is.EqualTo(1));
        }

        // TODO: test to make sure an exception is raised when popping too many
    }
}
