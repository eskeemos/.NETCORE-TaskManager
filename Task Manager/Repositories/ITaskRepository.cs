using System.Linq;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        TaskModel Get(int id);
        IQueryable<TaskModel> GetAllActive();
        void Add(TaskModel task);
        void Update(TaskModel task, int id);
        void Delete(int id);
    }
}
