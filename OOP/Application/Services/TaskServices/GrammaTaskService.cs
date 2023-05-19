using Application.Abstractions.TaskAbstractions;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using Repository.UnitOfWork;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TaskServices
{
    public class GrammaTaskService : ITaskService<GrammaTask, GrammaQuestion>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GrammaTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(GrammaTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaTaskRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(GrammaTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaTaskRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<GrammaTask> FirstOrDefaultAsync(Expression<Func<GrammaTask, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaTaskRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<GrammaTask>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaTaskRepository.ListAllAsync(cancellationToken);
        }

        public Task<IReadOnlyList<GrammaQuestion>> GetAllQuestiounsAsync(int grammaTaskId,CancellationToken cancellationToken = default)
        {
            var pos = _unitOfWork.GrammaTaskRepository.ListAsync((pos) => pos.Id == grammaTaskId, cancellationToken).Result; // ??? (pos) => pos.id
            var res = pos.Select(x => x.questions).First().ToList().AsReadOnly();
            return Task.FromResult((IReadOnlyList<GrammaQuestion>)res);
        }

        public Task<GrammaTask> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<GrammaTask, object>>[]? includesProperties)
        {
            return _unitOfWork.GrammaTaskRepository.GetByIdAsync(id, cancellationToken, includesProperties);
        }

        public Task<IReadOnlyList<GrammaTask>> ListAsync(Expression<Func<GrammaTask, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<GrammaTask, object>>[]? includesProperties)
        {
            return _unitOfWork.GrammaTaskRepository.ListAsync(filter, cancellationToken, includesProperties);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(GrammaTask item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaTaskRepository.UpdateAsync(item, cancellationToken);
        }
    }
}
