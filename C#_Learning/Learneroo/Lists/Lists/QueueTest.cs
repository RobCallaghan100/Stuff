using NUnit.Framework;

namespace Lists
{
    [TestFixture]
    public class QueueTest
    {
        [Test]
        public void ShouldEnQueue()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.Peek(), Is.EqualTo(1));
            Assert.That(queue.Count(), Is.EqualTo(2));
        }

        [Test]
        public void ShouldDeQueue()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            var result = queue.Dequeue();

            Assert.That(result, Is.EqualTo(1));
            Assert.That(queue.Peek(), Is.EqualTo(2));
            Assert.That(queue.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldDeQueueUntilEmpty()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Dequeue();
            var result = queue.Dequeue();

            Assert.That(queue.Peek(), Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(0));
            Assert.That(queue.Count(), Is.EqualTo(0));
        }

        // TODO: check we can not dequeue too many
    }
}
