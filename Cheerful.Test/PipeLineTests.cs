using Cheerful.PipeLine;

namespace Cheerful.Test
{
    [TestClass]
    public class PipeLineTests
    {
        [TestMethod]
        public void PipeLineTest()
        {
            var context = new TestContext(0, 10);
            var pipeLine = new PipeLine<TestContext>();
            pipeLine.Add<TestPipeLineService1>();
            pipeLine.Add<TestPipeLineService1>();
            pipeLine.Add<TestPipeLineService1>();
            pipeLine.Add<TestPipeLineService1>();
            pipeLine.Add<TestPipeLineService1>();
            pipeLine.Add<TestPipeLineService1>();
            pipeLine.Invoke(context);

            Assert.IsTrue(context.A == 6);
            Assert.IsTrue(context.R == 4);
        }
    }

    #region HelpTestClass
    public class TestContext
    {
        public TestContext(int a, int r)
        {
            A = a;
            R = r;
        }

        public int A { get; set; }
        public int R { get; set; }
    }

    public class TestPipeLineService1 : PipeLineService<TestContext>
    {
        public override void Invoke(TestContext t)
        {
            t.A++;
            NextService?.Invoke(t);
            t.R--;
        }
    }
    #endregion
}