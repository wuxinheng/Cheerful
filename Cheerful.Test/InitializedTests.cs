using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cheerful;

namespace Cheerful.Test
{
    [TestClass]
    public class InitializedTests
    {
        [TestMethod]
        public void InitCollectionTest()
        {
            var reuslt = Initialized.InitCollection<HelpTestClass.TestClass1>(100000);
            Assert.IsTrue(reuslt.Any());
        }

        [TestMethod]
        public void InitTest()
        {
            var reuslt = Initialized.Init<HelpTestClass.TestClass1>();
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

        [TestMethod]
        public void InitTestByInspectionTaskDetail()
        {
            var reuslt = Initialized.Init<InspectionTaskDetail>();
            Assert.IsNotNull(reuslt);
        }

        [TestMethod]
        public void InitTestByTestClass2()
        {
            var reuslt = Initialized.Init<HelpTestClass.TestClass2>();
            Assert.IsNotNull(reuslt);
        }

        [TestMethod]
        public void InitEnumTest()
        {
            var reuslt = Initialized.InitEnum(typeof(HelpTestClass.Days));
            Assert.IsNotNull(reuslt);
        }

        [TestMethod]
        public void InitSystemBaseTypeTest()
        {
            var reuslt = Initialized.InitSystemBaseType(typeof(HelpTestClass.Days));
            Assert.IsNotNull(reuslt);
            var reusltInt = Initialized.InitSystemBaseType(typeof(int));
            Assert.IsNotNull(reusltInt);
            var reusltString = Initialized.InitSystemBaseType(typeof(string));
            Assert.IsNotNull(reusltString);
            var reusltFloat = Initialized.InitSystemBaseType(typeof(float));
            Assert.IsNotNull(reusltFloat);
            var reusltDecimal = Initialized.InitSystemBaseType(typeof(decimal));
            Assert.IsNotNull(reusltDecimal);
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

        public class TestClass2
        {
            public ErrorCode ErrorCode { get; set; }
            public ErrorCode? ErrorCode1 { get; set; }
        }
        public record Person
        {
            public string FirstName { get; init; } = default!;
            public string LastName { get; init; } = default!;
        };
    }

    #region Entity

    /// <summary>
    /// 巡检结果
    /// </summary>
    public enum InspectionResult
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,

        /// <summary>
        /// 异常
        /// </summary>
        Abnormal,
    }

    /// <summary>
    /// 巡检状态
    /// </summary>
    public enum InspectionStatus
    {
        /// <summary>
        /// 待巡检
        /// </summary>
        NotStarted,

        /// <summary>
        /// 已巡检
        /// </summary>
        Finished,

        /// <summary>
        /// 漏打卡
        /// </summary>
        Forget,

        /// <summary>
        /// 已超时
        /// </summary>
        TimeOut
    }

    /// <summary>
    /// 项目默认部门
    /// </summary>
    public enum ProjectDefaultDepartment
    {
        /// <summary>
        /// 工程部
        /// </summary>
        Engineering,

        /// <summary>
        /// 安保部
        /// </summary>
        Security,

        /// <summary>
        /// 保洁部
        /// </summary>
        Cleaning,

        /// <summary>
        /// 客服部
        /// </summary>
        CustomerService
    }

    /// <summary>
    /// 巡检任务详情
    /// </summary>
    public class InspectionTaskDetail
    {
        /// <summary>
        /// 巡检类型
        /// </summary>
        public ProjectDefaultDepartment @Type { get; set; }

        /// <summary>
        /// 实际巡检人Id
        /// </summary>
        public int ActUserId { get; set; }

        /// <summary>
        /// 实际巡检人姓名
        /// </summary>
        public string? ActUserName { get; set; }

        /// <summary>
        /// 巡检编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public int? Creater { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Desription { get; set; }

        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 巡检结果描述
        /// </summary>
        public string? InspectionResult { get; set; }

        /// <summary>
        /// 巡检状态
        /// </summary>
        public InspectionStatus InspectionState { get; set; }

        /// <summary>
        /// 实际巡检时间
        /// </summary>
        public DateTime InspectionTime { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime PlanEndTime { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime PlanStartTime { get; set; }

        /// <summary>
        /// 点位ID
        /// </summary>
        public int PointId { get; set; }

        /// <summary>
        /// 点位名称
        /// </summary>
        public string? PointName { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public int? ProjectId { get; set; }

        public string? Remark { get; set; }

        /// <summary>
        /// 工单编号
        /// </summary>
        public int? RepairId { get; set; }

        /// <summary>
        /// 任务状态（结果）
        /// </summary>
        public InspectionResult State { get; set; }

        /// <summary>
        /// 巡检任务ID
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int TenantId { get; set; } = -1;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 修改人Id
        /// </summary>
        public int? Updater { get; set; }
    }
    #endregion Entity

    #endregion HelpTestClass
}