using NUnit.Framework;
using Source.Tests.Dummys;
using SwipeOrDie.Storage;

namespace Source.Tests.Storage
{
    public sealed class PlayerPrefsStorageTest
    {
        [Test]
        public void SavesCorrectly()
        {
            const string path = nameof(PlayerPrefsStorageTest);
            var test = new StorageTest<StorageDummyValue>(new PlayerPrefsStorage<StorageDummyValue>(path),
                new StorageDummyValue(10), new FileDestructor(path));
            
            Assert.That(test.SavesCorrectly);
        }
    }
}