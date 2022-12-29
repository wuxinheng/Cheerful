namespace Cheerful.Test
{
    [TestClass]
    public class RandomTests
    {
        [TestMethod]
        public void NextBooleanTest()
        {
            
            Assert.IsNotNull(Cheerful.Random.Shared.NextBoolean());
        }

        [TestMethod]
        public void NextByteTest()
        {
            Assert.IsNotNull(Cheerful.Random.Shared.NextByte());
        }

        [TestMethod]
        public void NextCharTest()
        {
            Assert.IsNotNull(Cheerful.Random.Shared.NextChar());
        }

        [TestMethod]
        public void NextChineseTest()
        {
            Assert.IsTrue(Cheerful.Random.Shared.NextChinese().Length == 1);
        }

        [TestMethod]
        public void NextChineseTest1()
        {
            Assert.IsTrue(Cheerful.Random.Shared.NextChinese(10).Length == 10);
        }

        [TestMethod]
        public void NextDecimalTest()
        {
            Assert.IsNotNull(Cheerful.Random.Shared.NextDecimal(1, 10));
        }

        [TestMethod]
        public void NextFloatTest()
        {
            Assert.IsNotNull(Cheerful.Random.Shared.NextFloat(1, 10));
        }

        [TestMethod]
        public void NextMajusculeTest()
        {
            var majusculeValue = Cheerful.Random.Shared.NextMajuscule();
            Assert.IsTrue(majusculeValue == majusculeValue.ToUpper());
        }

        [TestMethod]
        public void NextMinusculeTest()
        {
            var mnusculeValue = Cheerful.Random.Shared.NextMinuscule();
            Assert.IsTrue(mnusculeValue == mnusculeValue.ToLower());
        }

        [TestMethod]
        public void NextNumberStringTest()
        {
            var number = int.Parse(Cheerful.Random.Shared.NextNumberString());
            Assert.IsTrue(number >= 0 && number < 10);
        }

        [TestMethod]
        public void NextNumberTest()
        {
            var number = Cheerful.Random.Shared.NextNumber();
            Assert.IsTrue(number >= 0 && number <= 9);
        }

        [TestMethod]
        public void NextSbyteTest()
        {
            Assert.IsNotNull(Cheerful.Random.Shared.NextSbyte());
        }

        [TestMethod]
        public void NextShortTest()
        {
            Assert.IsNotNull(Cheerful.Random.Shared.NextShort());
        }

        [TestMethod]
        public void NextStringTest()
        {
            var stringValue = Cheerful.Random.Shared.NextString();
            Assert.IsTrue(stringValue.Length == 10);
        }

        [TestMethod]
        public void NextStringTest1()
        {
            Assert.IsTrue(Cheerful.Random.Shared.NextString(10).Length == 10);
        }
        [TestMethod]
        public void NextUIntTest()
        {
            Assert.IsNotNull(Cheerful.Random.Shared.NextUInt());
        }

        [TestMethod]
        public void NextULongTest()
        {
            Assert.IsNotNull(Cheerful.Random.Shared.NextULong());
        }

        [TestMethod]
        public void NextUShortTest()
        {
            Assert.IsNotNull(Cheerful.Random.Shared.NextUShort());
        }

        [TestMethod]
        public void NextDoubleTest()
        {
            var value = Cheerful.Random.Shared.NextDouble(10, 20);
            Assert.IsTrue(value < 20 && value > 10);
        }

        [TestMethod]
        public void NextShortTest1()
        {
            var value = Cheerful.Random.Shared.NextShort(10, 20);
            Assert.IsTrue(value <= 20 && value >= 10);
        }

        [TestMethod]
        public void NextUIntTest1()
        {
            var value = Cheerful.Random.Shared.NextUInt(10, 20);
            Assert.IsTrue(value < 20 && value > 10);
        }

        [TestMethod]
        public void NextUShortTest1()
        {
            var value = Cheerful.Random.Shared.NextUShort(10, 20);
            Assert.IsTrue(value <= 20 && value >= 10);
        }

        [TestMethod]
        public void NextULongTest1()
        {
            var value = Cheerful.Random.Shared.NextULong(10, 20);
            Assert.IsTrue(value < 20 && value > 10);
        }
    }
}