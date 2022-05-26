using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsersManager.Core.Models;

namespace UsersManager.DAL.Repositories.Tests
{
    [TestClass()]
    public class UsersRepositoryTests
    {

        private UsersManagerContext _context = null!;


        [TestInitialize()]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<UsersManagerContext>()
                .UseInMemoryDatabase("InMemoryDB")
                .Options;
            _context = new UsersManagerContext(options);
            _context.Database.EnsureCreated();
        }

        [TestCleanup()]
        public void Clean()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }


        [TestMethod()]
        public void CreateTest()
        {
            var user = new User
            {
                Address = "Test address",
                Email = "Test email",
                Estimate = 40.2f,
                Name = "Test name",
                Phone = "Test phone"
            };

            var repo = new UsersRepository(_context);
            var newUser = repo.Create(user);

            Assert.IsNotNull(newUser);
            Assert.AreEqual(user.Name, newUser.Name);
            Assert.AreEqual(user.Email, newUser.Email);
            Assert.AreEqual(user.Estimate, newUser.Estimate);
            Assert.IsTrue(newUser.Id > 0);
        }


        [TestMethod()]
        public void UpdateTest()
        {
            var user = new User
            {
                Address = "Test address",
                Email = "Test email",
                Estimate = 40.2f,
                Name = "Test name",
                Phone = "Test phone"
            };
            var entity = _context.Users.Add(user);
            _context.SaveChanges();
            entity.State = EntityState.Detached;
            user = _context.Users.AsNoTracking().Single(u => u.Email == user.Email);

            var repo = new UsersRepository(_context);
            var _user = new User
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                Estimate = user.Estimate,
                Name = user.Name,
                Phone = "Phone changed",
            };
            var updatedUser = repo.Update(_user);

            Assert.AreEqual(updatedUser.Address, user.Address);
            Assert.AreEqual(updatedUser.Email, user.Email);
            Assert.AreEqual(updatedUser.Estimate, user.Estimate);
            Assert.AreEqual(updatedUser.Name, user.Name);
            Assert.AreEqual(updatedUser.Phone, "Phone changed");
            Assert.AreEqual(updatedUser.Id, user.Id);
        }


        [TestMethod()]
        public void DeleteTest()
        {
            var user = new User
            {
                Address = "Test address",
                Email = "Test email",
                Estimate = 40.2f,
                Name = "Test name",
                Phone = "Test phone"
            };
            var entity = _context.Users.Add(user);
            _context.SaveChanges();
            entity.State = EntityState.Detached;
            user = _context.Users.AsNoTracking().Single(u => u.Email == user.Email);

            var repo = new UsersRepository(_context);
            repo.Delete(user.Id);

            var useExist = _context.Users.Any(u => u.Id == user.Id);
            Assert.IsFalse(useExist);
        }


        [TestMethod()]
        public void GetTest()
        {
            User[] users = new User[]
            {
                new User
                {
                    Address = "Address 1",
                    Email = "Email 1",
                    Estimate = 40.2f,
                    Name = "Name 1",
                    Phone = "Phone 1"
                },
                new User
                {
                    Address = "Address 2",
                    Email = "Email 2",
                    Estimate = 80.2f,
                    Name = "Name 2",
                    Phone = "Phone 2"
                },
            };
            _context.Users.AddRange(users);
            _context.SaveChanges();

            var _user = _context.Users.Single(u => u.Email == "Email 1");

            var repo = new UsersRepository(_context);
            var user = repo.Get(_user.Id);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Email, _user.Email);
            Assert.AreEqual(user.Phone, _user.Phone);
        }


        [TestMethod()]
        public void GetAllTest()
        {
            User[] users = new User[]
            {
                new User
                {
                    Address = "Address 1",
                    Email = "Email 1",
                    Estimate = 40.2f,
                    Name = "Name 1",
                    Phone = "Phone 1"
                },
                new User
                {
                    Address = "Address 2",
                    Email = "Email 2",
                    Estimate = 80.2f,
                    Name = "Name 2",
                    Phone = "Phone 2"
                },
            };
            _context.Users.AddRange(users);
            _context.SaveChanges();

            var repo = new UsersRepository(_context);
            var _users = repo.GetAll();

            Assert.AreEqual(_users.Count(), users.Length);

            for (int i = 0; i < _users.Count(); i++)
            {
                var user = users[i];
                var _user = _users.First(u => u.Id == user.Id);

                Assert.AreEqual(_user.Name, user.Name);
                Assert.AreEqual(_user.Phone, user.Phone);
                Assert.AreEqual(_user.Id, user.Id);
            }

        }


        [TestMethod()]
        public void SearchTest()
        {
            User[] users = new User[]
            {
                new User
                {
                    Address = "Address 1",
                    Email = "Email 1",
                    Estimate = 40.2f,
                    Name = "Name 1",
                    Phone = "Phone 1"
                },
                new User
                {
                    Address = "Address 2",
                    Email = "Email 2",
                    Estimate = 80.2f,
                    Name = "Name 2",
                    Phone = "Phone 2"
                },
            };
            _context.Users.AddRange(users);
            _context.SaveChanges();

            var repo = new UsersRepository(_context);
            var _users = repo.Search(u => u.Address == "Address 2");
            var _usersOri = users.Where(u => u.Address == "Address 2");

            Assert.AreEqual(_users.Count(), _usersOri.Count());

            for (int i = 0; i < _users.Count(); i++)
            {
                var user = _usersOri.ElementAt(i);
                var _user = _users.First(u => u.Id == user.Id);

                Assert.AreEqual(_user.Name, user.Name);
                Assert.AreEqual(_user.Phone, user.Phone);
            }

        }

    }
}