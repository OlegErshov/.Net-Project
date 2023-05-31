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
    public class VocabluaryTaskService : ITaskService<VocabluaryTask,VocabluaryQuestion>
    {
        private IUnitOfWork _unitOfWork;
        public VocabluaryTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(VocabluaryTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryTaskRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(VocabluaryTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryTaskRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<VocabluaryTask> FirstOrDefaultAsync(Expression<Func<VocabluaryTask, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryTaskRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<VocabluaryTask>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryTaskRepository.ListAllAsync(cancellationToken);
        }

        public Task<IReadOnlyList<VocabluaryQuestion>> GetAllQuestiounsAsync(int TaskId, CancellationToken cancellationToken = default)
        {
            var pos = _unitOfWork.VocabluaryTaskRepository.ListAsync((pos) => pos.Id == TaskId, cancellationToken).Result; // ??? (pos) => pos.id
            var res = pos.Select(x => x.questions).First().ToList().AsReadOnly();
            return Task.FromResult((IReadOnlyList<VocabluaryQuestion>)res);
        }

        public Task<VocabluaryTask> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<VocabluaryTask, object>>[]? includesProperties)
        {
            return _unitOfWork.VocabluaryTaskRepository.GetByIdAsync(id, cancellationToken, includesProperties);
        }

        public Task<List<VocabluaryTask>> ListAsync(Expression<Func<VocabluaryTask, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<VocabluaryTask, object>>[]? includesProperties)
        {
            return _unitOfWork.VocabluaryTaskRepository.ListAsync(filter, cancellationToken, includesProperties);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(VocabluaryTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryTaskRepository.UpdateAsync(item, cancellationToken);
        }
    }
}
