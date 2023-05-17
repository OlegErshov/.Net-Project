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
    public class TeacherService : ITeacherService
    {
        private IUnitOfWork _unitOfWork;
        public TeacherService( IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public Task AddAsync(Teacher item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.TeacherRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(Teacher item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.TeacherRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<Teacher> FirstOrDefaultAsync(Expression<Func<Teacher, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.TeacherRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<Teacher>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.TeacherRepository.ListAllAsync(cancellationToken);   
        }

        public Task<Teacher> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Teacher, object>>[]? includesProperties)
        {
            return _unitOfWork.TeacherRepository.GetByIdAsync(id, cancellationToken, includesProperties);
        }

        public Task<IReadOnlyList<Student>> GetStudentsListAsync(int positionId, CancellationToken cancellationToken = default)
        {
            var pos = _unitOfWork.TeacherRepository.ListAsync((pos) => pos.Id == positionId, cancellationToken).Result; // ??? (pos) => pos.id
            var res = pos.Select(x => x.students).First().ToList().AsReadOnly();
            return Task.FromResult((IReadOnlyList<Student>)res);
        }

        public Task<IReadOnlyList<Teacher>> ListAsync(Expression<Func<Teacher, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Teacher, object>>[]? includesProperties)
        {
            return _unitOfWork.TeacherRepository.ListAsync(filter, cancellationToken);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(Teacher item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.TeacherRepository.UpdateAsync(item, cancellationToken);
        }
    }
}
