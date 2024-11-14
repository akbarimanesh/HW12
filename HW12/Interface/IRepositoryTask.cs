using HW12.Dto;
using HW12.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Interface
{
    public interface IRepositoryTask
    {
        public void CreateTask(TaskUser taskUser);
        public List<GetTaskDto> GetAllTask(User user);
        public void UpdateTask(TaskUser taskUser);
        public void DeleteTask(int id);
        public TaskUser GetTaskById(int id);
        
        public void UpdateStatus(TaskUser task, int id);
        public TaskUser SearchTask(string title);


    }
}
