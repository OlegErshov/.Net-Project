using Microsoft.AspNetCore.Identity;
using Plugin.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public  interface IBaseService<T> where T : IdentityUser
    {
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includesProperties);

        Task AddAsync(T item, CancellationToken cancellationToken = default);

        Task UpdateAsync(T item, CancellationToken cancellationToken = default);

        Task DeleteAsync(T item, CancellationToken cancellationToken = default);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken
       cancellationToken = default);

        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includesProperties);

        Task SaveChangesAsync();
    }
}
