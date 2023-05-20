using Plugin.Questions;
using Plugin.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.TasksRepositories
{
    public interface ITaskRepository<T,P> where T : TaskTemplate<P> where P : AnswerTemplate
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default,
                               params Expression<Func<T, object>>[]? includesProperties);

        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);

        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter,
                                        CancellationToken cancellationToken = default,
                                        params Expression<Func<T, object>>[]? includesProperties);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken
       cancellationToken = default);
    }
}
