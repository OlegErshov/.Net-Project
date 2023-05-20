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
    public class GrammaQuestionService : IQuestionService<GrammaQuestion>
    {

        private IUnitOfWork _unitOfWork;
        public GrammaQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AddAsync(GrammaQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaQuestionRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(GrammaQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaQuestionRepository.DeleteAsync(item, cancellationToken);
        }

        public Task<GrammaQuestion> FirstOrDefaultAsync(Expression<Func<GrammaQuestion, bool>> filter, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaQuestionRepository.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<IReadOnlyList<GrammaQuestion>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaQuestionRepository.ListAllAsync(cancellationToken);
        }

        public Task<GrammaQuestion> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<GrammaQuestion, object>>[]? includesProperties)
        {
            return _unitOfWork.GrammaQuestionRepository.GetByIdAsync(id,cancellationToken,includesProperties);
        }

        public Task<List<GrammaQuestion>> ListAsync(Expression<Func<GrammaQuestion, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<GrammaQuestion, object>>[]? includesProperties)
        {
            return _unitOfWork.GrammaQuestionRepository.ListAsync(filter,cancellationToken,includesProperties);
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAllAsync();
        }

        public Task UpdateAsync(GrammaQuestion item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GrammaQuestionRepository.UpdateAsync(item,cancellationToken);
        }
    }
}
