using Application.Abstractions.TaskAbstractions;
using Plugin.Questions;
using Plugin.Tasks;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TaskServices
{
    public class SentenceTaskService : ITaskService<SentenceTask,SentenceQuestion>
    {
        private IUnitOfWork _unitOfWork;
        public SentenceTaskService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(SentenceTask item, CancellationToken cancellationToken = default)
        {
            return  _unitOfWork.SentenceTaskRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(SentenceTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SentenceTaskRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<SentenceTask> FirstOrDefaultAsync(Expression<Func<SentenceTask, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SentenceTaskRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<SentenceTask>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SentenceTaskRepository.ListAllAsync(cancellationToken);
        }

        public Task<IReadOnlyList<SentenceQuestion>> GetAllQuestiounsAsync(int TaskId, CancellationToken cancellationToken = default)
        {
            var pos = _unitOfWork.SentenceTaskRepository.ListAsync((pos) => pos.Id == TaskId, cancellationToken).Result; // ??? (pos) => pos.id
            var res = pos.Select(x => x.questions).First().ToList().AsReadOnly();
            return Task.FromResult((IReadOnlyList<SentenceQuestion>)res);
        }

        public Task<SentenceTask> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<SentenceTask, object>>[]? includesProperties)
        {
            return _unitOfWork.SentenceTaskRepository.GetByIdAsync(id, cancellationToken, includesProperties);
        }

        public Task<List<SentenceTask>> ListAsync(Expression<Func<SentenceTask, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<SentenceTask, object>>[]? includesProperties)
        {
            return _unitOfWork.SentenceTaskRepository.ListAsync(filter, cancellationToken, includesProperties);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(SentenceTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SentenceTaskRepository.UpdateAsync(item, cancellationToken);
        }
    }
}
