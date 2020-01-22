using NUnit.Framework;

namespace ConnectFour.Tests
{
    [TestFixture]
    public class CurrentPlayerTests
    {
        [Test]
        public void InvertsCurrentPlayerEveryNextStep()
        {
            Assert.AreEqual(CurrentPlayer.Red, CurrentPlayer.Blue.GetNext());
            Assert.AreEqual(CurrentPlayer.Blue, CurrentPlayer.Red.GetNext());
        }

        [Test]
        public void CorrectlyConvertsItselfToSell()
        {
            Assert.AreEqual(Cell.Blue, CurrentPlayer.Blue.ToCell());
            Assert.AreEqual(Cell.Red, CurrentPlayer.Red.ToCell());
        }
    }
}