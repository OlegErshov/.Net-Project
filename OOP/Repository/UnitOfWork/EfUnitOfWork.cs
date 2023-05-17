using Plugin.Authorization;
using Repository.Data;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Student>> _studentRepository;
        private readonly Lazy<IRepository<Teacher>> _teacherRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _studentRepository = new Lazy<IRepository<Student>>(() =>
            new EfRepository<Student>(context));
            _teacherRepository = new Lazy<IRepository<Teacher>>(() =>
            new EfRepository<Teacher>(context));
        }

        public IRepository<Student> StudentRepository => _studentRepository.Value;

        public IRepository<Teacher> TeacherRepository => _teacherRepository.Value;

        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }
        public async Task RemoveDatbaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }
        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
