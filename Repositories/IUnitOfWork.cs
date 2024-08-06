using System;
using System.Threading.Tasks;
using SIM_Project.Models;

namespace SIM_Project.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Admin> Admins { get; }
        IRepository<Course> Courses { get; }
        IRepository<Student> Students { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Semester> Semesters { get; }
        Task SaveAsync();
    }
}
