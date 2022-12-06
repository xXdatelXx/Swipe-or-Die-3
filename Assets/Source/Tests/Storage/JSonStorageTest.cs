using NUnit.Framework;
using Source.Tests.Dummys;
using SwipeOrDie.Storage;

namespace Source.Tests.Storage
{
    public sealed class JSonStorageTest
    {
        [Test]
        public void SavesCorrectly()
        {
            const string path = nameof(JSonStorageTest);
            var test = new StorageTest<StorageDummyValue>(new JSonStorage<StorageDummyValue>(path),
                new StorageDummyValue(10), new FileDestructor(path));
            
            Assert.That(test.SavesCorrectly);
        }
    }
}