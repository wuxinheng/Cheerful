namespace Cheerful.Test
{
    [TestClass()]
    public class RandomTests
    {
        [TestMethod()]
        public void NextBooleanTest()
        {
            Assert.IsTrue(Random.Shared.NextBoolean() is bool result);
        }

        [TestMethod()]
        public void NextByteTest()
        {
            Assert.IsTrue(Random.Shared.NextByte() is byte result);
        }

        [TestMethod()]
        public void NextCharTest()
        {
            Assert.IsTrue(Random.Shared.NextChar() is char result);
        }

        [TestMethod()]
        public void NextChineseTest()
        {
            Assert.IsTrue(Random.Shared.NextChinese().Length == 1);
        }

        [TestMethod()]
        public void NextChineseTest1()
        {
            Assert.IsTrue(Random.Shared.NextChinese(10).Length == 10);
        }

        [TestMethod()]
        public void NextMajusculeTest()
        {
            var majusculeValue = Random.Shared.NextMajuscule();
            Assert.IsTrue(majusculeValue == majusculeValue.ToUpper());
        }

        [TestMethod()]
        public void NextMinusculeTest()
        {
            var mnusculeValue = Random.Shared.NextMinuscule();
            Assert.IsTrue(mnusculeValue == mnusculeValue.ToLower());
        }

        [TestMethod()]
        public void NextNumberStringTest()
        {
            var number = int.Parse(Random.Shared.NextNumberString());
            Assert.IsTrue(number >= 0 && number < 10);
        }

        [TestMethod()]
        public void NextNumberTest()
        {
            var number = Random.Shared.NextNumber();
            Assert.IsTrue(number >= 0 && number <= 9);
        }

        [TestMethod()]
        public void NextStringTest()
        {
            var stringValue = Random.Shared.NextString();
            Assert.IsTrue(stringValue.Length == 10);
        }

        [TestMethod()]
        public void NextStringTest1()
        {
            Assert.IsTrue(Random.Shared.NextString(10).Length == 10);
        }
    }
}