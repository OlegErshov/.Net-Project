using Application.Abstractions.QuestionAbstractions;
using Plugin.Questions;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuestionServices
{
    public class VocabluaryQuestionService : IQuestionService<VocabluaryQuestion>
    {
        private IUnitOfWork _unitOfWork;
        public VocabluaryQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(VocabluaryQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryQuestionRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(VocabluaryQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryQuestionRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<VocabluaryQuestion> FirstOrDefaultAsync(Expression<Func<VocabluaryQuestion, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryQuestionRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<VocabluaryQuestion>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryQuestionRepository.ListAllAsync(cancellationToken);
        }

        public Task<VocabluaryQuestion> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<VocabluaryQuestion, object>>[]? includesProperties)
        {
            return _unitOfWork.VocabluaryQuestionRepository.GetByIdAsync(id, cancellationToken,includesProperties);
        }

        public Task<List<VocabluaryQuestion>> ListAsync(Expression<Func<VocabluaryQuestion, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<VocabluaryQuestion, object>>[]? includesProperties)
        {
            return _unitOfWork.VocabluaryQuestionRepository.ListAsync(filter, cancellationToken, includesProperties);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(VocabluaryQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.VocabluaryQuestionRepository.UpdateAsync(item, cancellationToken);
        }
    }
}
