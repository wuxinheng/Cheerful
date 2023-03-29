using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cheerful.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Net.Security;
using Cheerful.Repository.Entitys;
using Microsoft.EntityFrameworkCore;

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
        public void NewNoTest()
        {
            CheerfulContext context = new CheerfulContext();
            var repository = new Cheerful.Repository.Repository<User>(context);
            var newNo = repository.NewNo().GetAwaiter().GetResult();
            var user1 = new User()
            {
                Name = "测试姓名1",
                No = newNo
            };
            repository.Add(user1);
            repository.SaveChanges();
            newNo = repository.NewNo().GetAwaiter().GetResult();
            var user2 = new User()
            {
                Name = "测试姓名2",
                No = newNo
            };
            
            repository.Add(user2);
            repository.SaveChanges();
            Assert.IsTrue(user1.No== user2.No);
        }

        [TestMethod()]
        public void PageTest()
        {
            Assert.Fail();
        }
    }
}