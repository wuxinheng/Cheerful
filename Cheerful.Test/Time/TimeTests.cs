using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cheerful;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheerful.Test
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void GetIntersectTimeTest()
        {
            #region 示意
            //0:          11:00|------------------------------------------|11:30
            //1:                  11:05|--------------------|11:20
            //2:          11:00|---------------------------------------------|11:35
            //3:    10:50|-------|11:03
            //4:    10:50|----|10:58
            //5:    10:50|------------------------------------------------------|11:40
            //1:              11:05|-------------------------------------------|11:38
            #endregion

            #region 初始化
            var start = DateTime.Parse("2023/01/09 11:00");
            var end = DateTime.Parse("2023/01/09 11:30");

            var start1 = DateTime.Parse("2023/01/09 11:05");
            var end1 = DateTime.Parse("2023/01/09 11:20");

            var start2 = DateTime.Parse("2023/01/09 11:00");
            var end2 = DateTime.Parse("2023/01/09 11:35");

            var start3 = DateTime.Parse("2023/01/09 10:50");
            var end3 = DateTime.Parse("2023/01/09 11:03");

            var start4 = DateTime.Parse("2023/01/09 10:50");
            var end4 = DateTime.Parse("2023/01/09 10:58");

            var start5 = DateTime.Parse("2023/01/09 10:50");
            var end5 = DateTime.Parse("2023/01/09 11:40");

            var start6 = DateTime.Parse("2023/01/09 11:05");
            var end6 = DateTime.Parse("2023/01/09 11:38");
            #endregion

            var intersectTime1 = Time.GetIntersectTime(start, end, start1, end1);
            Assert.IsTrue(intersectTime1?.IsIntersect);
            Assert.IsTrue(intersectTime1?.IntersectRange?.Start == start1);
            Assert.IsTrue(intersectTime1.IntersectRange.End == end1);

            var intersectTime2 = Time.GetIntersectTime(start, end, start2, end2);
            Assert.IsTrue(intersectTime2?.IsIntersect);
            Assert.IsTrue(intersectTime2?.IntersectRange?.Start == start2);
            Assert.IsTrue(intersectTime2.IntersectRange.End == end);

            var intersectTime3 = Time.GetIntersectTime(start, end, start3, end3);
            Assert.IsTrue(intersectTime3?.IsIntersect);
            Assert.IsTrue(intersectTime3?.IntersectRange?.Start == start);
            Assert.IsTrue(intersectTime3.IntersectRange.End == end3);

            var intersectTime4 = Time.GetIntersectTime(start, end, start4, end4);
            Assert.IsNull(intersectTime4);

            var intersectTime5 = Time.GetIntersectTime(start, end, start5, end5);
            Assert.IsTrue(intersectTime5?.IsIntersect);
            Assert.IsTrue(intersectTime5?.IntersectRange?.Start == start);
            Assert.IsTrue(intersectTime5.IntersectRange.End == end);

            var intersectTime6 = Time.GetIntersectTime(start, end, start6, end6);
            Assert.IsTrue(intersectTime6?.IsIntersect);
            Assert.IsTrue(intersectTime6?.IntersectRange?.Start == start6);
            Assert.IsTrue(intersectTime6.IntersectRange.End == end);

        }

        [TestMethod]
        public void GetIntersectTimeTest1()
        {
            #region 示意
            //0:          11:00|------------------------------------------|11:30
            //1:                  11:05|--------------------|11:20
            //2:          11:00|---------------------------------------------|11:35
            //3:    10:50|-------|11:03
            //4:    10:50|----|10:58
            //5:    10:50|------------------------------------------------------|11:40
            //1:              11:05|-------------------------------------------|11:38
            #endregion

            #region 初始化
            var start = DateTime.Parse("2023/01/09 11:00");
            var end = DateTime.Parse("2023/01/09 11:30");
            var startEnd = new StartEnd<DateTime>(start, end);

            var start1 = DateTime.Parse("2023/01/09 11:05");
            var end1 = DateTime.Parse("2023/01/09 11:20");
            var startEnd1 = new StartEnd<DateTime>(start1, end1);

            var start2 = DateTime.Parse("2023/01/09 11:00");
            var end2 = DateTime.Parse("2023/01/09 11:35");
            var startEnd2 = new StartEnd<DateTime>(start2, end2);

            var start3 = DateTime.Parse("2023/01/09 10:50");
            var end3 = DateTime.Parse("2023/01/09 11:03");
            var startEnd3 = new StartEnd<DateTime>(start3, end3);

            var start4 = DateTime.Parse("2023/01/09 10:50");
            var end4 = DateTime.Parse("2023/01/09 10:58");
            var startEnd4 = new StartEnd<DateTime>(start4, end4);

            var start5 = DateTime.Parse("2023/01/09 10:50");
            var end5 = DateTime.Parse("2023/01/09 11:40");
            var startEnd5 = new StartEnd<DateTime>(start5, end5);

            var start6 = DateTime.Parse("2023/01/09 11:05");
            var end6 = DateTime.Parse("2023/01/09 11:38");
            var startEnd6 = new StartEnd<DateTime>(start6, end6);
            #endregion

            var intersectTime1 = startEnd.GetIntersectTime(startEnd1);
            Assert.IsTrue(intersectTime1?.IsIntersect);
            Assert.IsTrue(intersectTime1?.IntersectRange?.Start == start1);
            Assert.IsTrue(intersectTime1.IntersectRange.End == end1);

            var intersectTime2 = startEnd.GetIntersectTime(startEnd2);
            Assert.IsTrue(intersectTime2?.IsIntersect);
            Assert.IsTrue(intersectTime2?.IntersectRange?.Start == start2);
            Assert.IsTrue(intersectTime2.IntersectRange.End == end);

            var intersectTime3 = startEnd.GetIntersectTime(startEnd3);
            Assert.IsTrue(intersectTime3?.IsIntersect);
            Assert.IsTrue(intersectTime3?.IntersectRange?.Start == start);
            Assert.IsTrue(intersectTime3.IntersectRange.End == end3);

            var intersectTime4 = startEnd.GetIntersectTime(startEnd4);
            Assert.IsNull(intersectTime4);

            var intersectTime5 = startEnd.GetIntersectTime(startEnd5);
            Assert.IsTrue(intersectTime5?.IsIntersect);
            Assert.IsTrue(intersectTime5?.IntersectRange?.Start == start);
            Assert.IsTrue(intersectTime5.IntersectRange.End == end);

            var intersectTime6 = startEnd.GetIntersectTime(startEnd6);
            Assert.IsTrue(intersectTime6?.IsIntersect);
            Assert.IsTrue(intersectTime6?.IntersectRange?.Start == start6);
            Assert.IsTrue(intersectTime6.IntersectRange.End == end);
        }

        [TestMethod]
        public void GetIntersectTimeTest2()
        {
            #region 示意
            //0:          11:00|------------------------------------------|11:30
            //1:                  11:05|--------------------|11:20
            //2:          11:00|---------------------------------------------|11:35
            //3:    10:50|-------|11:03
            //4:    10:50|----|10:58
            //5:    10:50|------------------------------------------------------|11:40
            //1:              11:05|-------------------------------------------|11:38
            #endregion

            #region 初始化
            var start = DateTime.Parse("2023/01/09 11:00");
            var end = DateTime.Parse("2023/01/09 11:30");
            var startEnd = new StartEnd<DateTime>(start, end);

            var start1 = DateTime.Parse("2023/01/09 11:05");
            var end1 = DateTime.Parse("2023/01/09 11:20");


            var start2 = DateTime.Parse("2023/01/09 11:00");
            var end2 = DateTime.Parse("2023/01/09 11:35");

            var start3 = DateTime.Parse("2023/01/09 10:50");
            var end3 = DateTime.Parse("2023/01/09 11:03");

            var start4 = DateTime.Parse("2023/01/09 10:50");
            var end4 = DateTime.Parse("2023/01/09 10:58");

            var start5 = DateTime.Parse("2023/01/09 10:50");
            var end5 = DateTime.Parse("2023/01/09 11:40");

            var start6 = DateTime.Parse("2023/01/09 11:05");
            var end6 = DateTime.Parse("2023/01/09 11:38");
            #endregion

            var intersectTime1 = startEnd.GetIntersectTime(start1, end1);
            Assert.IsTrue(intersectTime1?.IsIntersect);
            Assert.IsTrue(intersectTime1?.IntersectRange?.Start == start1);
            Assert.IsTrue(intersectTime1.IntersectRange.End == end1);

            var intersectTime2 = startEnd.GetIntersectTime(start2, end2);
            Assert.IsTrue(intersectTime2?.IsIntersect);
            Assert.IsTrue(intersectTime2?.IntersectRange?.Start == start2);
            Assert.IsTrue(intersectTime2.IntersectRange.End == end);

            var intersectTime3 = startEnd.GetIntersectTime(start3, end3);
            Assert.IsTrue(intersectTime3?.IsIntersect);
            Assert.IsTrue(intersectTime3?.IntersectRange?.Start == start);
            Assert.IsTrue(intersectTime3.IntersectRange.End == end3);

            var intersectTime4 = startEnd.GetIntersectTime(start4, end4);
            Assert.IsNull(intersectTime4);

            var intersectTime5 = startEnd.GetIntersectTime(start5, end5);
            Assert.IsTrue(intersectTime5?.IsIntersect);
            Assert.IsTrue(intersectTime5?.IntersectRange?.Start == start);
            Assert.IsTrue(intersectTime5.IntersectRange.End == end);

            var intersectTime6 = startEnd.GetIntersectTime(start6, end6);
            Assert.IsTrue(intersectTime6?.IsIntersect);
            Assert.IsTrue(intersectTime6?.IntersectRange?.Start == start6);
            Assert.IsTrue(intersectTime6.IntersectRange.End == end);
        }
    }
}