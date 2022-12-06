using NUnit.Framework;
using SwipeOrDie.Storage;

namespace Source.Tests.Storage
{
    public sealed class BinaryStorageTest
    {
        [Test]
        public void SavesCorrectly()
        {
            const string path = nameof(BinaryStorageTest);
            var test = new StorageTest<int>(new BinaryStorage<int>(path), 10, new FileDestructor(path));
            
            Assert.That(test.SavesCorrectly);
        }
    }
}