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
        public void ShouldPassAcceptanceTestForAdding()
        {
            _linkedList.Add(3);
            Assert.That(_linkedList.Get(0), Is.EqualTo(3));
            _linkedList.Add(5);
            _linkedList.Add(7);
            Assert.That(_linkedList.Get(1), Is.EqualTo(5));
            _linkedList.Add(4);
            Assert.That(_linkedList.Get(3), Is.EqualTo(4));
            Assert.That(_linkedList.Get(0), Is.EqualTo(3));
            _linkedList.Add(12);
            _linkedList.Add(14);
            Assert.That(_linkedList.Get(2), Is.EqualTo(7));
            Assert.That(_linkedList.Get(5), Is.EqualTo(14));
        }

        [Test]
        public void ShouldAddAtSpecificIndex()
        {
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);

            _linkedList.Add(1, 4);

            Assert.That(_linkedList.Get(0), Is.EqualTo(1));
            Assert.That(_linkedList.Get(1), Is.EqualTo(4));
            Assert.That(_linkedList.Get(2), Is.EqualTo(2));
            Assert.That(_linkedList.Get(3), Is.EqualTo(3));
        }

        [Test]
        public void ShouldAddToFirstPosition()
        {
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);

            _linkedList.Add(0, 4);

            Assert.That(_linkedList.Get(0), Is.EqualTo(4));
            Assert.That(_linkedList.Get(1), Is.EqualTo(1));
            Assert.That(_linkedList.Get(2), Is.EqualTo(2));
            Assert.That(_linkedList.Get(3), Is.EqualTo(3));
        }

        [Test]
        public void ShouldAddToLastPosition()
        {
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);

            _linkedList.Add(2, 4);

            Assert.That(_linkedList.Get(0), Is.EqualTo(1));
            Assert.That(_linkedList.Get(1), Is.EqualTo(2));
            Assert.That(_linkedList.Get(2), Is.EqualTo(4));
            Assert.That(_linkedList.Get(3), Is.EqualTo(3));
        }

        // TODO: check that number is not negative or too high

        [Test]
        public void ShouldRemoveNodeAtIndex()
        {
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);

            _linkedList.Remove(1);

            Assert.That(_linkedList.Get(0), Is.EqualTo(1));
            Assert.That(_linkedList.Get(1), Is.EqualTo(3));
        }

        [Test]
        public void ShouldRemoveNodeAtHead()
        {
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);

            _linkedList.Remove(0);

            Assert.That(_linkedList.Get(0), Is.EqualTo(2));
            Assert.That(_linkedList.Get(1), Is.EqualTo(3));
        }

        [Test]
        public void ShouldRemoveNodeAtTail()
        {
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);

            _linkedList.Remove(2);

            Assert.That(_linkedList.Get(0), Is.EqualTo(1));
            Assert.That(_linkedList.Get(1), Is.EqualTo(2));
        }

        // TODO: check that index is in bounds

        [Test]
        public void ShouldPassAddAtSpecificIndexAndRemoveAcceptanceTest()
        {
            _linkedList.Add(3);
            Assert.That(_linkedList.Get(0), Is.EqualTo(3));
            _linkedList.Add(5);
            _linkedList.Add(1, 11);
            _linkedList.Add(7);
            _linkedList.Add(3, 13);
            _linkedList.Add(3, 14);
            Assert.That(_linkedList.Get(1), Is.EqualTo(11));
            Assert.That(_linkedList.Get(3), Is.EqualTo(14));
            Assert.That(_linkedList.Remove(2), Is.EqualTo(5));
            Assert.That(_linkedList.Remove(0), Is.EqualTo(3));
            Assert.That(_linkedList.Get(3), Is.EqualTo(7));
            _linkedList.Add(2, 10);
            _linkedList.Add(1, 9);
            Assert.That(_linkedList.Get(5), Is.EqualTo(7));
            Assert.That(_linkedList.Get(3), Is.EqualTo(10));
            Assert.That(_linkedList.Remove(0), Is.EqualTo(11));
            Assert.That(_linkedList.Remove(0), Is.EqualTo(9));
            Assert.That(_linkedList.Remove(0), Is.EqualTo(14));
            Assert.That(_linkedList.Remove(0), Is.EqualTo(10));
            Assert.That(_linkedList.Remove(0), Is.EqualTo(13));
            _linkedList.Add(2);
            _linkedList.Add(3);
            _linkedList.Add(1, 1);
            _linkedList.Add(3, 5);
            Assert.That(_linkedList.Get(4), Is.EqualTo(3));
            Assert.That(_linkedList.Get(2), Is.EqualTo(2));
        }

        [Test]
        public void ShouldReturnCorrectSize()
        {
            _linkedList.Add(3);
            _linkedList.Get(0);
            _linkedList.Add(5);
            _linkedList.Add(1, 11);
            _linkedList.Add(7);
            _linkedList.Add(3, 13);
            _linkedList.Add(3, 14);
            _linkedList.Get(1);
            _linkedList.Get(3);
            _linkedList.Remove(2);
            _linkedList.Remove(0);
            _linkedList.Get(3);
            _linkedList.Add(2, 10);
            _linkedList.Add(1, 9);
            _linkedList.Get(5);
            _linkedList.Get(3);
            _linkedList.Remove(0);
            _linkedList.Remove(0);
            _linkedList.Remove(0);
            _linkedList.Remove(0);
            _linkedList.Remove(0);
            _linkedList.Add(2);
            _linkedList.Add(3);
            _linkedList.Add(1, 1);
            _linkedList.Add(3, 5);
            _linkedList.Get(4);
            _linkedList.Get(2);

            Assert.That(_linkedList.Size, Is.EqualTo(5));
        }
    }
}
