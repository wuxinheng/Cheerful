using System.Reflection;

namespace Cheerful.Test
{
    [TestClass()]
    public class RandomConfigurationAttributeTests
    {
        [TestMethod()]
        public void RandomConfigurationAttributeTest()
        {
            RandomConfigurationAttribute attribute = new RandomConfigurationAttribute(10);
            var property = typeof(RandomConfigurationAttribute).GetProperty("Length", BindingFlags.NonPublic | BindingFlags.Instance);
            var propertyInfo = typeof(RandomConfigurationAttribute).GetProperty("RandomType", BindingFlags.NonPublic | BindingFlags.Instance);
            var value1 = propertyInfo?.GetValue(attribute)?.ToString();
            var value = Convert.ToInt32(property?.GetValue(attribute));
            Assert.IsTrue(value1 == "Length");
            Assert.IsTrue(value == 10);
        }

        [TestMethod()]
        public void RandomConfigurationAttributeTest1()
        {
            RandomConfigurationAttribute attribute = new RandomConfigurationAttribute(2, 5);
            var property = typeof(RandomConfigurationAttribute).GetProperty("Range", BindingFlags.NonPublic | BindingFlags.Instance);
            var propertyInfo = typeof(RandomConfigurationAttribute).GetProperty("RandomType", BindingFlags.NonPublic | BindingFlags.Instance);
            var value1 = propertyInfo?.GetValue(attribute)?.ToString();
            var value = ((int Min, int Max)?)property?.GetValue(attribute);
            Assert.IsTrue(value1 == "Range");
            Assert.IsTrue(value?.Min == 2 && value?.Max == 5);
        }

        [TestMethod()]
        public void RandomConfigurationAttributeTest2()
        {
            RandomConfigurationAttribute attribute = new RandomConfigurationAttribute(BuildType.Name);
            var property = typeof(RandomConfigurationAttribute).GetProperty("BuildType", BindingFlags.NonPublic | BindingFlags.Instance);
            var propertyInfo = typeof(RandomConfigurationAttribute).GetProperty("RandomType", BindingFlags.NonPublic | BindingFlags.Instance);
            var value1 = propertyInfo?.GetValue(attribute)?.ToString();
            var value = (BuildType?)property?.GetValue(attribute);
            Assert.IsTrue(value== BuildType.Name);
            Assert.IsTrue(value1 == "Type");
        }

        [TestMethod()]
        public void ToRandomTest()
        {
            RandomConfigurationAttribute attribute = new RandomConfigurationAttribute(2, 5);
            var value = attribute.ToRandom(typeof(int));
            Assert.IsTrue(value >= 2 && value <= 5);
        }
    }
}