using Cheerful.Repository.Entitys;

namespace Cheerful.Repository.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        [TestMethod()]
        public void RepositoryTest()
        {
            CheerfulContext context = new CheerfulContext();
            var repository = new Cheerful.Repository.Repository<User>(context);
            var user1 = new User()
            {
                Name = "测试姓名1"
            };
            var user2 = new User()
            {
                Name = "测试姓名2"
            };
            repository.Add(user1);
            repository.Add(user2);
            var count = repository.SaveChanges();
            Assert.AreEqual(2, count);
        }

        [TestMethod()]
        public async Task NewNoTest()
        {
            CheerfulContext context = new CheerfulContext();
            var repository = new Cheerful.Repository.Repository<User>(context);
            var newNo = await repository.NewNo();
            var user1 = new User()
            {
                Name = "测试姓名1",
                No = newNo
            };
            repository.Add(user1);
            repository.SaveChanges();
            newNo = await repository.NewNo();
            var user2 = new User()
            {
                Name = "测试姓名2",
                No = newNo
            };

            repository.Add(user2);
            repository.SaveChanges();
            Assert.IsFalse(user1.No == user2.No);
        }

        [TestMethod()]
        public void PageTest()
        {
            Assert.Fail();
        }
    }
}