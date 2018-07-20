using EisenhowerMatrix.BusinessLogic.Models;
using EisenhowerMatrix.Entities;
using EisenhowerMatrix.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EisenhowerMatrix.BusinessLogic.Implementation
{
    class TodoTaskService : ITodoTaskService
    {
        private ITodoTaskRepository todoTaskRepository;

        public TodoTaskService(ITodoTaskRepository todoTaskRepository)
        {
            this.todoTaskRepository = todoTaskRepository;
        }

        public async Task CreateAsync(TodoTask todoTask, CancellationToken token)
        {
            await todoTaskRepository.CreateAsync(todoTask, token);
        }

        public async Task DeleteAsync(TodoTask todoTask, CancellationToken token)
        {
            await todoTaskRepository.DeleteAsync(todoTask, token);
        }

        public async Task<IList<TodoTask>> GetAsync(ToDoTaskFilter filter, CancellationToken token)
        {
            return await todoTaskRepository.GetAsync(filter.ShowOnlyNonFinished, token);
        }

        public async Task<TodoTask> GetAsync(int id, CancellationToken token)
        {
            return await todoTaskRepository.GetAsync(id, token);
        }

        public async Task UpdateAsync(TodoTask todoTask, CancellationToken token)
        {
            await todoTaskRepository.UpdateAsync(todoTask, token);
        }
    }
}
