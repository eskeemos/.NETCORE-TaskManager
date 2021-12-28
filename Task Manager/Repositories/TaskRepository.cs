using System.Linq;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context context;
        public TaskRepository(Context _context)
        {
            context = _context;
        }
        public void Add(TaskModel task)
        {
            context.Tasks.Add(task);
            Save();
        }

        public void Delete(int id)
        {
            var res = Get(id);
            if (res != null)
            {
                context.Tasks.Remove(res);
                Save();
            }
        }

        public TaskModel Get(int id)
            => context.Tasks.SingleOrDefault(x => x.TaskId == id);

        public IQueryable<TaskModel> GetAllActive()
            => context.Tasks.Where(x => !x.Done);

        public void Update(TaskModel task, int id)
        {
            var res = Get(id);
            if(res != null)
            {
                res.Name = task.Name;
                res.Description = task.Description;
                res.Done = res.Done;
                Save();
            }
        }

        private void Save() => context.SaveChanges();
    }
}
