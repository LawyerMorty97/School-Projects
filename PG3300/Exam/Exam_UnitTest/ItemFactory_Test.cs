namespace SoftwareDesignExam_UnitTests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using SoftwareDesignExam;

    [TestFixture]
    public class ItemFactory_Test
    {

        private List<Auctioneer> _auctioneers;


        [SetUp]
        public void SetUpStart()
        {
            _auctioneers = new List<Auctioneer>();

        }

        [Test]
        public void ShouldStartAsEmpty()
        {
            List<IItem> forSale = new List<IItem>();
            Assert.AreEqual(0, forSale.Count);
        }


        [Test]
        public void ShouldAddItems()
        {
            List<IItem> forSale = new List<IItem>();
            IItem firstItem = new TornBook();
            IItem secondItem = new DefaultBook();

            forSale.Add(firstItem);
            forSale.Add(secondItem);

            Assert.That(forSale.Contains(firstItem));
            Assert.That(forSale.Contains(secondItem));
        }

        [Test]
        public void ListNotNull()
        {
            List<IItem> forSale = new List<IItem>();
            IItem firstItem = new TornBook();
            IItem secondItem = new DefaultBook();

            forSale.Add(firstItem);
            forSale.Add(secondItem);

            Assert.NotNull(forSale);
        }

        [Test]
        public void AuctioneerShouldBeRandom()
        {
            int index = Utilities.GetRandomNumber(0, _auctioneers.Count);
            Assert.AreEqual(index, Utilities.GetRandomNumber(0, _auctioneers.Count));
        }

        [Test]
        public void AuctioneerNotNull()
        {
            int index = Utilities.GetRandomNumber(0, _auctioneers.Count);
            Assert.NotNull(index);
        }

        [Test]
        public void ItemNotNull()
        {
            int item = Utilities.GetRandomNumber(0, 4);
            Assert.NotNull(item);
        }

    }
}