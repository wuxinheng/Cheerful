using Cheerful.PipeLine;

namespace Cheerful.Test
{
    [TestClass()]
    public class PipeLineTests
    {
        [TestMethod()]
        public void PipeLineTest()
        {
            TestContext context = new TestContext();
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

    public class TestContext
    {
        public int A { get; set; } = 0;
        public int R { get; set; } = 10;
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
}