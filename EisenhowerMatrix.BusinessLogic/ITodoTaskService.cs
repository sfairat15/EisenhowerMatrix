using EisenhowerMatrix.BusinessLogic.Models;
using EisenhowerMatrix.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EisenhowerMatrix.BusinessLogic
{
    public interface ITodoTaskService
    {
        Task<IList<TodoTask>> GetAsync(ToDoTaskFilter filter, CancellationToken token);
        Task<TodoTask> GetAsync(int id, CancellationToken token);

        Task DeleteAsync(TodoTask todoTask, CancellationToken token);
        Task UpdateAsync(TodoTask todoTask, CancellationToken token);
        Task CreateAsync(TodoTask todoTask, CancellationToken token);
    }
}
