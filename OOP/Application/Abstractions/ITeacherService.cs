using Plugin.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface ITeacherService : IBaseService<Teacher>
    {
        Task<IReadOnlyList<Student>> GetStudentsListAsync(int positionId, CancellationToken cancellationToken = default);
    }
}
