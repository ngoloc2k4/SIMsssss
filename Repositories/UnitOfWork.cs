using System;
using System.Threading.Tasks;
using SIM_Project.Data;
using SIM_Project.Models;

namespace SIM_Project.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Admins = new Repository<Admin>(_context);
            Courses = new Repository<Course>(_context);
            Students = new Repository<Student>(_context);
            Teachers = new Repository<Teacher>(_context);
            Semesters = new Repository<Semester>(_context);
        }

        public IRepository<Admin> Admins { get; private set; }
        public IRepository<Course> Courses { get; private set; }
        public IRepository<Student> Students { get; private set; }
        public IRepository<Teacher> Teachers { get; private set; }
        public IRepository<Semester> Semesters { get; private set; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
