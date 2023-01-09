namespace Cheerful
{
    public static class Time
    {

        public static IntersectTime? GetIntersectTime(this IStartEnd<DateTime> startEnd, DateTime start1, DateTime end1)
        {
            return GetIntersectTime(startEnd.Start, startEnd.End, start1, end1);
        }

        public static IntersectTime? GetIntersectTime(this IStartEnd<DateTime> startEnd, IStartEnd<DateTime> startEnd1)
        {
            return GetIntersectTime(startEnd.Start, startEnd.End, startEnd1.Start, startEnd1.End);
        }

        public static IntersectTime? GetIntersectTime(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            IntersectTime? intersectTime = null;
            StartEnd<DateTime> startEnd;
            bool isIntersect;

            if (start1 <= start2 && end1 >= end2)  // 1 contain 2
            {
                startEnd = new StartEnd<DateTime>(start2, end2);
                isIntersect = true;
            }
            else if (start1 >= start2 && end1 <= end2)  // 2 contain 1
            {
                startEnd = new StartEnd<DateTime>(start1, end1);
                isIntersect = true;
            }
            else if (start1 <= start2 && end1 <= end2 && end1 >= start1)
            {
                startEnd = new StartEnd<DateTime>(start2, end1);
                isIntersect = true;
            }
            else if (start1 >= start2 && start1 <= end2 && end1 >= end2)
            {
                startEnd = new StartEnd<DateTime>(start1, end2);
                isIntersect = true;
            }
            else
            {
                return intersectTime;
            }
            intersectTime = new IntersectTime(isIntersect, startEnd);

            return intersectTime;
        }
    }


}
