namespace Lists
{
    using NUnit.Framework;

    [TestFixture]
    public class LinkedListTests
    {
        private LinkedList _linkedList;

        [SetUp]
        public void Setup()
        {
            _linkedList = new LinkedList();
        }

        [TearDown]
        public void Teardown()
        {
            _linkedList = null;
        }

        [Test]
        public void ShouldAddToLinkedList()
        {
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);

            Assert.That(_linkedList.Head.Value, Is.EqualTo(1));
            Assert.That(_linkedList.Tail.Value, Is.EqualTo(3));
        }

        [Test]
        public void ShouldGetFromLinkedList()
        {
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);

            Assert.That(_linkedList.Get(0), Is.EqualTo(1));
            Assert.That(_linkedList.Get(1), Is.EqualTo(2));
            Assert.That(_linkedList.Get(2), Is.EqualTo(3));
        }

        [Test]
        public void ShouldAddAtSpecificIndex()
        {
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);

            _linkedList.Add(1, 4, TODO);

            Assert.That(_linkedList.Get(0), Is.EqualTo(1));
            Assert.That(_linkedList.Get(1), Is.EqualTo(4));
            Assert.That(_linkedList.Get(2), Is.EqualTo(2));
            Assert.That(_linkedList.Get(3), Is.EqualTo(3));
        }

        // check that number is not negative or too high
    }
}
