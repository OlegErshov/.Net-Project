using Plugin.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.QuestionAbstractions
{
    public interface IQuestionService<T> where T : AnswerTemplate
    {
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includesProperties);

        Task AddAsync(T item, CancellationToken cancellationToken = default);

        Task UpdateAsync(T item, CancellationToken cancellationToken = default);

        Task DeleteAsync(T item, CancellationToken cancellationToken = default);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken
       cancellationToken = default);

        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includesProperties);

        Task SaveChangesAsync();
    }
}
