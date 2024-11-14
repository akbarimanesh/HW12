using HW12.Dto;
using HW12.Entity;
using HW12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Repository
{
    internal class RepositoryTask : IRepositoryTask
    {
        private readonly AppDbContext appDbContext;
        public RepositoryTask()
        {
            appDbContext = new AppDbContext();
        }
        public void CreateTask(TaskUser taskUser1)
        {
            appDbContext.taskUser.Add(taskUser1);
            appDbContext.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            appDbContext.taskUser.Remove(appDbContext.taskUser.Find(id));
            appDbContext.SaveChanges();
        }

        public List<GetTaskDto> GetAllTask(User user)
        {
            return appDbContext.taskUser.Where(x => x.UserId == user.Id)
                .Select(x => new GetTaskDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    TimeToDone = x.TimeToDone,
                    Priority = x.Priority,
                    State = x.State,
                    UserName = x.User.UserName,
                }).ToList();



        }

        public TaskUser GetTaskById(int id)
        {
            return appDbContext.taskUser.Where(x => x.Id == id).FirstOrDefault();
              
              
        }

        public TaskUser SearchTask(string title)
        {
            return appDbContext.taskUser.FirstOrDefault(p => p.Title == title);
        }

        public void UpdateStatus(TaskUser task, int id)
        {
            var taskU = appDbContext.taskUser.FirstOrDefault(p => p.Id == id);
            taskU.State = task.State;
            appDbContext.SaveChanges();
        }

        public void UpdateTask(TaskUser taskUser1)
        {
            var taskU = appDbContext.taskUser.FirstOrDefault(p => p.Id == taskUser1.Id);
            taskU.Title = taskUser1.Title;
            taskU.Priority = taskUser1.Priority;
            taskU.TimeToDone = taskUser1.TimeToDone;
            taskU.Description = taskUser1.Description;
            appDbContext.SaveChanges();
        }
    }
}
