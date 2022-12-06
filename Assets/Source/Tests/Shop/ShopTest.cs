using NUnit.Framework;
using Source.Tests.Dummys;
using SwipeOrDie.Model;

namespace Source.Tests.Shop
{
    [TestFixture]
    public sealed class ShopTest
    {
        private IShop _shop;
        private IWallet _wallet;

        [SetUp]
        public void SetUp()
        {
            _wallet = new Wallet(new DummyStorage<int>());
            _shop = new SwipeOrDie.Model.Shop(_wallet, new DummyCollectionStorage<string>());
        }

        [Test]
        public void BuysCorrectly()
        {
            _wallet.Put(100);
            _shop.Buy(new DummyGood(nameof(DummyGood), 10));

            Assert.That(_wallet.Money == 90);
        }

        [Test]
        public void CanBuyItemsWorkCorrectly()
        {
            var good = new DummyGood(nameof(DummyGood), 10);

            _wallet.Put(10);
            _shop.Buy(good);

            Assert.That(_wallet.CanTake(good.Price) == false);
        }
    }
}