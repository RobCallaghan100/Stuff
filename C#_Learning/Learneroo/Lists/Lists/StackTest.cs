using NUnit.Framework;

namespace Lists
{
    [TestFixture]
    public class StackTest
    {
        [Test]
        public void ShouldPushIntoStack()
        {
            var stack = new Stack();

            stack.Push(1);
            stack.Push(2);

            Assert.That(stack.Count(), Is.EqualTo(2));
            Assert.That(stack.Peek(), Is.EqualTo(2));
        }
    }
}
