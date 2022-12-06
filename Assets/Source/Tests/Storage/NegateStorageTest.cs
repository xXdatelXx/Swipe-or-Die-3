using NUnit.Framework;
using SwipeOrDie.Storage;

namespace Source.Tests.Storage
{
    public sealed class NegateStorageTest
    {
        [Test]
        public void SavesCorrectly()
        {
            const string path = nameof(NegateStorageTest);
            var storage = new NegateStorage(new BinaryStorage<bool>(path));
            var destructor = new FileDestructor(path);
            
            storage.Negate();
            Assert.That(storage.Value == false);
            
            storage.Negate();
            Assert.That(storage.Value == true);
            
            destructor.Destruct();
        }
    }
}