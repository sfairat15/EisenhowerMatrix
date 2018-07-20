using EisenhowerMatrix.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EisenhowerMatrix.Repositories.Interfaces
{
    public interface ITodoTaskRepository
    {
        Task<IList<TodoTask>> GetAsync(bool showOnlyNonFinished, CancellationToken token);
        Task<TodoTask> GetAsync(int id, CancellationToken token);

        Task DeleteAsync(TodoTask todoTask, CancellationToken token);
        Task UpdateAsync(TodoTask todoTask, CancellationToken token);
        Task CreateAsync(TodoTask todoTask, CancellationToken token);
    }
}
