using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services
{
    public class Service
    {
        private TrainContext _context;
        public Service(TrainContext context)
        {
            _context = context;
        }

        public Users Authorization(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login)
                || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();
            var user = GetUsers().SingleOrDefault(x => x.Email == login && x.Password == password);
            if (user == null)
                throw new StackOverflowException();
            return user;
        }
        public void Registration(string login, string password,PassportData passport)
        {
            if (string.IsNullOrWhiteSpace(login)
               || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();
            var duplicate = GetUsers().Any(x => x.Email == login && x.Password == password);
            if (duplicate)
                throw new StackOverflowException("Duplicate data");
            Users user = new Users()
            {
                Email = login,
                Password = password,
                RoleID = 2,
                PassportData = passport
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public List<Users> GetUsers() => _context.Users.ToList();
        public List<Schedules> GetSchedules() => _context.Schedules.ToList();
        public List<Tickets> GetTickets() => _context.Tickets.ToList();

        public void AddTicket(Users user,PassportData passport, Schedules schedule, Wagons wagon)
        {
            var duplicate = GetTickets().Where(x=>x.UserID==user.ID)
                .Any(x => x.PassportData.LastName == passport.LastName
                && x.PassportData.FirstName == passport.FirstName);
            if (duplicate)
                throw new StackOverflowException("Duplicate data");
            Tickets ticket = new Tickets()
            {
                PassportData = passport,
                Confirmed = true,
                Wagons = wagon,
                Schedules = schedule,
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }
    }
}
