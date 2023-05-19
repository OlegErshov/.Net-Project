using Application.Abstractions.TaskAbstractions;
using Plugin.Questions;
using Plugin.Tasks;
using Repository.Repositories.TasksRepositories;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TaskServices
{
    public  class InsertTaskService : ITaskService<InsertTask,InsertQuestion>
    {
        private IUnitOfWork _unitOfWork;
        public InsertTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;    
        }

        public Task AddAsync(InsertTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertTaskRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(InsertTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertTaskRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<InsertTask> FirstOrDefaultAsync(Expression<Func<InsertTask, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertTaskRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<InsertTask>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertTaskRepository.ListAllAsync(cancellationToken);
        }

        public Task<IReadOnlyList<InsertQuestion>> GetAllQuestiounsAsync(int TaskId, CancellationToken cancellationToken = default)
        {
            var pos = _unitOfWork.InsertTaskRepository.ListAsync((pos) => pos.Id == TaskId, cancellationToken).Result; // ??? (pos) => pos.id
            var res = pos.Select(x => x.questions).First().ToList().AsReadOnly();
            return Task.FromResult((IReadOnlyList<InsertQuestion>)res);
        }

        public Task<InsertTask> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<InsertTask, object>>[]? includesProperties)
        {
            return _unitOfWork.InsertTaskRepository.GetByIdAsync(id, cancellationToken, includesProperties);
        }

        public Task<IReadOnlyList<InsertTask>> ListAsync(Expression<Func<InsertTask, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<InsertTask, object>>[]? includesProperties)
        {
            return _unitOfWork.InsertTaskRepository.ListAsync(filter, cancellationToken, includesProperties);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(InsertTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertTaskRepository.UpdateAsync(item, cancellationToken);
        }
    }
}
