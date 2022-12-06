using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SwipeOrDie.Storage;

namespace Source.Tests.Storage
{
    public sealed class CollectionStorageTest
    {
        [Test]
        public void SavesCorrectly()
        {
            const string path = nameof(CollectionStorageTest);
            var storage = new CollectionStorage<int>(path);
            var destructor = new FileDestructor(path);
            const int value = 10;

            storage.Add(value);
            storage.Add(value);

            Assert.That(storage.Load().SequenceEqual(new List<int> { value, value }));
            destructor.Destruct();
        }
    }
}