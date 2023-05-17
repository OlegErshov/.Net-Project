using Application.Abstractions;
using Plugin.Authorization;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public Task AddAsync(Student item, CancellationToken cancellationToken = default)
        {
           return _unitOfWork.StudentRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(Student item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.StudentRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<Student> FirstOrDefaultAsync(Expression<Func<Student, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.StudentRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.StudentRepository.ListAllAsync(cancellationToken);
        }

        public Task<Student> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Student, object>>[]? includesProperties)
        {
            return _unitOfWork.StudentRepository.GetByIdAsync(id,cancellationToken,includesProperties);
        }

        public Task<IReadOnlyList<Student>> ListAsync(Expression<Func<Student, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Student, object>>[]? includesProperties)
        {
            return _unitOfWork.StudentRepository.ListAsync(filter,cancellationToken,includesProperties);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(Student item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.StudentRepository.UpdateAsync(item,cancellationToken);
        }
    }
}
