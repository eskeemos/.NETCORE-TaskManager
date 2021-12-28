using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository taskRepository;

        public TaskController(ITaskRepository _taskRepository)
        {
            taskRepository = _taskRepository;
        }

        // GET: Task
        public ActionResult Index()
        {
            return View(taskRepository.GetAllActive());
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(taskRepository.Get(id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            taskRepository.Add(taskModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(taskRepository.Get(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            taskRepository.Update(taskModel, id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(taskRepository.Get(id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            taskRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Done/5
        public ActionResult Done(int id)
        {
            TaskModel task = taskRepository.Get(id);
            task.Done = true;
            taskRepository.Update(task, id);
            return RedirectToAction(nameof(Index));
        }
    }
}
