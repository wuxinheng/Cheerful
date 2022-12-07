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
        public void NextDecimalTest()
        {
            Assert.IsTrue(Random.Shared.NextDecimal(1, 10) is decimal result);
        }

        [TestMethod()]
        public void NextFloatTest()
        {
            Assert.IsTrue(Random.Shared.NextFloat(1, 10) is float result);
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
        public void NextSbyteTest()
        {
            Assert.IsTrue(Random.Shared.NextSbyte() is sbyte result);
        }

        [TestMethod()]
        public void NextShortTest()
        {
            Assert.IsTrue(Random.Shared.NextShort() is short result);
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
        [TestMethod()]
        public void NextUIntTest()
        {
            Assert.IsTrue(Random.Shared.NextUInt() is uint result);
        }

        [TestMethod()]
        public void NextULongTest()
        {
            Assert.IsTrue(Random.Shared.NextULong() is ulong result);
        }

        [TestMethod()]
        public void NextUShortTest()
        {
            Assert.IsTrue(Random.Shared.NextUShort() is ushort result);
        }
    }
}