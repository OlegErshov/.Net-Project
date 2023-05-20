using Application.Abstractions.QuestionAbstractions;
using Plugin.Questions;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuestionServices
{
    public  class InsertQuestionService : IQuestionService<InsertQuestion>
    {
        private IUnitOfWork _unitOfWork;
        public InsertQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(InsertQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertQuestionRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(InsertQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertQuestionRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<InsertQuestion> FirstOrDefaultAsync(Expression<Func<InsertQuestion, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertQuestionRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<InsertQuestion>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertQuestionRepository.ListAllAsync(cancellationToken);
        }

        public Task<InsertQuestion> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<InsertQuestion, object>>[]? includesProperties)
        {
            return _unitOfWork.InsertQuestionRepository.GetByIdAsync(id,cancellationToken,includesProperties);
        }

        public Task<List<InsertQuestion>> ListAsync(Expression<Func<InsertQuestion, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<InsertQuestion, object>>[]? includesProperties)
        {
            return _unitOfWork.InsertQuestionRepository.ListAsync(filter, cancellationToken, includesProperties);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(InsertQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.InsertQuestionRepository.UpdateAsync(item, cancellationToken);
        }
    }
}
