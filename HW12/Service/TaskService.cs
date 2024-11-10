using HW12.Entity;
using HW12.Interface;
using HW12.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Service
{
    public class TaskService
    {
        IRepositoryTask taskrep;
        public TaskService()
        {
            taskrep = new RepositoryTask();
        }
        public Result CreateT(TaskUser taskUser)
        {
            taskrep.CreateTask(taskUser);
            return new Result(true, "Task added successfully.");
        }
        public List<TaskUser> GetAllT()
        {
            return taskrep.GetAllTask();
        }
        public TaskUser GetT(int id)
        {
            if (taskrep.GetTaskById(id) != null)
            {
                return taskrep.GetTaskById(id);

            }
            else
                return null;

        }
        public Result UpdateT(TaskUser taskUser)
        {
            if (taskrep.GetTaskById(taskUser.Id) != null)
            {
                taskrep.UpdateTask(taskUser);
                return new Result(true, "Task Edited successfully.");
            }
            else
                return new Result(false, " Task does not exist.");


        }
        public Result DeleteT(int id)
        {
            if (taskrep.GetTaskById(id) != null)
            {
                taskrep.DeleteTask(id);
                return new Result(true, "Task removed successfully.");
            }
            else
                return new Result(false, " Task does not exist.");

        }
        public Result UpdateS(TaskUser task, int id)
        {
            if (taskrep.GetTaskById(task.Id) != null)
            {
                taskrep.UpdateStatus(task,id);
                return new Result(true, "Task State Edited successfully.");
            }
            else
                return new Result(false, " Task does not exist.");

        }
        public TaskUser SearchT(string title)
        {
            if (taskrep.SearchTask(title) != null)
            {
                return taskrep.SearchTask(title);

            }
            else
                return null;
        }
    }
}
