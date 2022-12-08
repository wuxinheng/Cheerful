namespace Cheerful.Test
{
    [TestClass]
    public class InitializedTests
    {
        [TestMethod]
        public void InitTest()
        {
            var reuslt = Cheerful.Initialized.Init<HelpTestClass.TestClass1>();
            Assert.IsNotNull(reuslt);
            Assert.IsTrue(reuslt.Bool || !reuslt.Bool);
            Assert.IsTrue(reuslt.Byte.GetHashCode() > 0);
            Assert.IsTrue(reuslt.Decimal != default);
            Assert.IsTrue(reuslt.Float.GetHashCode() > 0);
            Assert.IsTrue(reuslt?.String?.Length > 0);
            Assert.IsTrue(reuslt.Double != default);
            Assert.IsTrue(reuslt.Int != default);
            Assert.IsTrue(reuslt.Long != default);
            Assert.IsTrue(reuslt.Sbyte != default);
            Assert.IsTrue(reuslt.Short != default);
            Assert.IsTrue(reuslt.Uint != default);
            Assert.IsTrue(reuslt.Ulong != default);
            Assert.IsTrue(reuslt.Ushort != default);
        }

        [TestMethod()]
        public void InitCollectionTest()
        {
            var reuslt = Cheerful.Initialized.InitCollection<HelpTestClass.TestClass1>(100000);
            Assert.IsTrue(reuslt.Any());
        }
    }

    #region HelpTestClass

    public class HelpTestClass
    {
        public delegate string @Delegate();

        [Flags]
        public enum Days
        {
            None = 0b_0000_0000,  // 0
            Monday = 0b_0000_0001,  // 1
            Tuesday = 0b_0000_0010,  // 2
            Wednesday = 0b_0000_0100,  // 4
            Thursday = 0b_0000_1000,  // 8
            Friday = 0b_0001_0000,  // 16
            Saturday = 0b_0010_0000,  // 32
            Sunday = 0b_0100_0000,  // 64
            Weekend = Saturday | Sunday
        }

        public enum ErrorCode : ushort
        {
            None = 0,
            Unknown = 1,
            ConnectionLost = 100,
            OutlierReading = 200
        }

        public interface IDog
        {
            string? Name { get; set; }
        }

        public readonly struct Coords : IEquatable<Coords>
        {
            public Coords(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; init; }
            public double Y { get; init; }

            public bool Equals(Coords other)
            {
                throw new NotImplementedException();
            }

            public override string ToString() => $"({X}, {Y})";
        }

        public struct Coords1 : IEquatable<Coords1>
        {
            public Coords1(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; }
            public double Y { get; }

            public bool Equals(Coords1 other)
            {
                throw new NotImplementedException();
            }

            public override string ToString() => $"({X}, {Y})";
        }

        public class Dog : IDog
        {
            public string? Name { get; set; }
        }

        public class TestClass1
        {
            public @Delegate? @Delegate { get; set; }
            public double[]? Array { get; set; }
            public bool Bool { get; set; }
            public byte Byte { get; set; }
            public char Char { get; set; }
            public Coords Coords { get; set; }
            public Coords1 Coords1 { get; set; }
            public Days Days { get; set; }
            public decimal Decimal { get; set; }
            public Dog? Dog { get; set; }
            public double Double { get; set; }
            public double? DoubleNull { get; set; }
            public dynamic? Dynamic { get; set; }
            public ErrorCode ErrorCode { get; set; }
            public float Float { get; set; }
            public IDog? IDog { get; set; }
            public int Int { get; set; }
            public long Long { get; set; }
            public nint Nint { get; set; }
            public nuint Nuint { get; set; }
            public object? Object { get; set; }
            public Person? Person { get; set; }
            public sbyte Sbyte { get; set; }
            public short Short { get; set; }
            public string? String { get; set; }
            public (double, int) Types { get; set; }
            public uint Uint { get; set; }
            public ulong Ulong { get; set; }
            public ushort Ushort { get; set; }
        }

        public record Person
        {
            public string FirstName { get; init; } = default!;
            public string LastName { get; init; } = default!;
        };
    }

    #endregion HelpTestClass
}