using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Test;
using Test.Services;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void GetAllSchedules()
        {
            //Arrange
            var schedules = new List<Schedules>
            {
                new Schedules{ID=1,Date=DateTime.Now,TrainID=1,RouteID=1,EconomyPrice=15000,Confirmed=true},
                new Schedules{ID=2,Date=DateTime.Now,TrainID=2,RouteID=2,EconomyPrice=10000,Confirmed=true},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Schedules>>();
            mockSet.As<IQueryable<Schedules>>().Setup(x => x.Provider).Returns(schedules.Provider);
            mockSet.As<IQueryable<Schedules>>().Setup(x => x.Expression).Returns(schedules.Expression);
            mockSet.As<IQueryable<Schedules>>().Setup(x => x.ElementType).Returns(schedules.ElementType);
            mockSet.As<IQueryable<Schedules>>().Setup(x => x.GetEnumerator()).Returns(schedules.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Schedules).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act
            var serviceSchedules = service.GetSchedules();
            //Act

            //Assert
            Assert.AreEqual(2, serviceSchedules.Count);
            //Assert
        }

        [TestMethod]
        public void GetAllTickets()
        {
            //Arrange
            var tickets = new List<Tickets>
            {
                new Tickets{ID=1,UserID=1,WagonID=1,ScheduleID=1,Confirmed=true},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Tickets>>();
            mockSet.As<IQueryable<Tickets>>().Setup(x => x.Provider).Returns(tickets.Provider);
            mockSet.As<IQueryable<Tickets>>().Setup(x => x.Expression).Returns(tickets.Expression);
            mockSet.As<IQueryable<Tickets>>().Setup(x => x.ElementType).Returns(tickets.ElementType);
            mockSet.As<IQueryable<Tickets>>().Setup(x => x.GetEnumerator()).Returns(tickets.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Tickets).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act
            var serviceTickets = service.GetTickets();
            //Act

            //Assert
            Assert.AreEqual(1, serviceTickets.Count);
            //Assert
        }

        [TestMethod]
        public void GetAllUsers()
        {
            //Arrange
            var users = new List<Users>
            {
                new Users{ID=1,Email="test@bk.ru",Password="QWEasd123",RoleID=1},
                new Users{ID=2,Email="test1@bk.ru",Password="QWEasd",RoleID=2},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(x => x.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<Users>>().Setup(x => x.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<Users>>().Setup(x => x.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(x => x.GetEnumerator()).Returns(users.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act
            var serviceUsers = service.GetUsers();
            //Act

            //Assert
            Assert.AreEqual(2, serviceUsers.Count);
            //Assert
        }

        #region Registration
        [TestMethod]
        public void Registration_ArgumentNullException()
        {
            //Arrange
            var users = new List<Users>
            {
                new Users{ID=1,Email="test@bk.ru",Password="QWEasd123",RoleID=1},
                new Users{ID=2,Email="test1@bk.ru",Password="QWEasd",RoleID=2},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(x => x.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<Users>>().Setup(x => x.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<Users>>().Setup(x => x.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(x => x.GetEnumerator()).Returns(users.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act with Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.Registration("", "", new PassportData()));
            //Act with Assert
        }

        [TestMethod]
        public void Registration_DuplicateException()
        {
            //Arrange
            var users = new List<Users>
            {
                new Users{ID=1,Email="test@bk.ru",Password="QWEasd123",RoleID=1},
                new Users{ID=2,Email="test1@bk.ru",Password="QWEasd",RoleID=2},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(x => x.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<Users>>().Setup(x => x.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<Users>>().Setup(x => x.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(x => x.GetEnumerator()).Returns(users.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act with Assert
            Assert.ThrowsException<StackOverflowException>(() => service.Registration("test@bk.ru", "QWEasd123", new PassportData()));
            //Act with Assert
        }

        [TestMethod]
        public void Registration_Successful()
        {
            //Arrange
            var users = new List<Users>
            {
                new Users{ID=1,Email="test@bk.ru",Password="QWEasd123",RoleID=1},
                new Users{ID=2,Email="test1@bk.ru",Password="QWEasd",RoleID=2},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(x => x.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<Users>>().Setup(x => x.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<Users>>().Setup(x => x.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(x => x.GetEnumerator()).Returns(users.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act
            service.Registration("test3@bk.ru", "QWEasd123", new PassportData { DateOfIssue = DateTime.Now, LastName = "Иванов", FirstName = "Иван", Number = "345678", Series = "123456" });
            //Act

            //Assert
            mockSet.Verify(x => x.Add(It.IsAny<Users>()), Times.Once());
            mockContext.Verify(x => x.SaveChanges(), Times.Once());
            //Assert
        }
        #endregion

        #region Authorization
        [TestMethod]
        public void Authorization_Successful()
        {
            //Arrange
            var users = new List<Users>
            {
                new Users{ID=1,Email="test@bk.ru",Password="QWEasd123",RoleID=1},
                new Users{ID=2,Email="test1@bk.ru",Password="QWEasd",RoleID=2},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(x => x.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<Users>>().Setup(x => x.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<Users>>().Setup(x => x.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(x => x.GetEnumerator()).Returns(users.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act
            var authUser = service.Authorization("test@bk.ru", "QWEasd123");
            //Act

            //Assert
            Assert.AreEqual(users.First(), authUser);
            //Assert
        }

        [TestMethod]
        public void Authorization_ArgumentNullException()
        {
            //Arrange
            var users = new List<Users>
            {
                new Users{ID=1,Email="test@bk.ru",Password="QWEasd123",RoleID=1},
                new Users{ID=2,Email="test1@bk.ru",Password="QWEasd",RoleID=2},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(x => x.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<Users>>().Setup(x => x.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<Users>>().Setup(x => x.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(x => x.GetEnumerator()).Returns(users.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act with Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.Authorization("", ""));
            //Act with Assert
        }

        [TestMethod]
        public void Authorization_NullReferenceException()
        {
            //Arrange
            var users = new List<Users>
            {
                new Users{ID=1,Email="test@bk.ru",Password="QWEasd123",RoleID=1},
                new Users{ID=2,Email="test1@bk.ru",Password="QWEasd",RoleID=2},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(x => x.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<Users>>().Setup(x => x.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<Users>>().Setup(x => x.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(x => x.GetEnumerator()).Returns(users.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act with Assert
            Assert.ThrowsException<StackOverflowException>(() => service.Authorization("test3@bk.ru", "123"));
            //Act with Assert
        }
        #endregion

        [TestMethod]
        public void AddTicket_Successful()
        {
            //Arrange
            var tickets = new List<Tickets>().AsQueryable();

            var mockSet = new Mock<DbSet<Tickets>>();
            mockSet.As<IQueryable<Tickets>>().Setup(x => x.Provider).Returns(tickets.Provider);
            mockSet.As<IQueryable<Tickets>>().Setup(x => x.Expression).Returns(tickets.Expression);
            mockSet.As<IQueryable<Tickets>>().Setup(x => x.ElementType).Returns(tickets.ElementType);
            mockSet.As<IQueryable<Tickets>>().Setup(x => x.GetEnumerator()).Returns(tickets.GetEnumerator());

            var mockContext = new Mock<TrainContext>();
            mockContext.Setup(x => x.Tickets).Returns(mockSet.Object);
            var service = new Service(mockContext.Object);
            //Arrange

            //Act
            service.AddTicket(new Users { Email = "test@bk.ru", Password = "123" }
            , new PassportData { DateOfIssue = DateTime.Now, LastName = "Иванов", FirstName = "Иван", Number = "345678", Series = "123456" }
            , new Schedules { Date = DateTime.Now, TrainID = 1, RouteID = 1, EconomyPrice = 15000, Confirmed = true }
            , new Wagons { Name = "Купе" });
            //Act

            //Assert
            mockSet.Verify(x => x.Add(It.IsAny<Tickets>()), Times.Once());
            mockContext.Verify(x => x.SaveChanges(), Times.Once());
            //Assert
        }
    }
}
