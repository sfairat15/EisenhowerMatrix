using EisenhowerMatrix.Entities;
using EisenhowerMatrix.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EisenhowerMatrix.Repositories.Ef
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private TodoDbContext context;

        public TodoTaskRepository(TodoDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(TodoTask todoTask, CancellationToken token)
        {
            context.TodoTasks.Add(todoTask);
            await context.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(TodoTask todoTask, CancellationToken token)
        {
            context.TodoTasks.Remove(todoTask);
            await context.SaveChangesAsync(token);
        }

        public async Task<IList<TodoTask>> GetAsync(bool showOnlyNonFinished, CancellationToken token)
        {
            if (showOnlyNonFinished)
            {
                return await context.TodoTasks.Where(x => x.IsFinished)
                                        .AsNoTracking()
                                        .ToListAsync();
            }
            else
            {
                return await context.TodoTasks.AsNoTracking().ToListAsync();
            }
        }

        public async Task<TodoTask> GetAsync(int id, CancellationToken token)
        {
            return await context.TodoTasks.FindAsync(id);
        }

        public async Task UpdateAsync(TodoTask todoTask, CancellationToken token)
        {
            context.TodoTasks.Update(todoTask);
            await context.SaveChangesAsync(token);
        }
    }
}
