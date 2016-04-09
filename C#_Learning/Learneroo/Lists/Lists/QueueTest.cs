using NUnit.Framework;

namespace Lists
{
    [TestFixture]
    public class QueueTest
    {
        [Test]
        public void ShouldAddToQueue()
        {

            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.Peek(), Is.EqualTo(1));

            var x = new System.Collections.Generic.Queue<int>();
            x.Enqueue(1);
            x.Dequeue();
        }
    }
}
