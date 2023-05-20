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
    public class SentenceQuestonService : IQuestionService<SentenceQuestion>
    {
        private IUnitOfWork _unitOfWork;
        public SentenceQuestonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(SentenceQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SentenceQuestionRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(SentenceQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SentenceQuestionRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<SentenceQuestion> FirstOrDefaultAsync(Expression<Func<SentenceQuestion, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SentenceQuestionRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<SentenceQuestion>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SentenceQuestionRepository.ListAllAsync(cancellationToken);
        }

        public Task<SentenceQuestion> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<SentenceQuestion, object>>[]? includesProperties)
        {
            return _unitOfWork.SentenceQuestionRepository.GetByIdAsync(id,cancellationToken,includesProperties);
        }

        public Task<List<SentenceQuestion>> ListAsync(Expression<Func<SentenceQuestion, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<SentenceQuestion, object>>[]? includesProperties)
        {
            return _unitOfWork.SentenceQuestionRepository.ListAsync(filter,cancellationToken,includesProperties);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(SentenceQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SentenceQuestionRepository.UpdateAsync(item,cancellationToken);
        }
    }
}
