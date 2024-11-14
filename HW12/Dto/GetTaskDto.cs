using HW12.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Dto
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; }
        public DateTime TimeToDone { get; set; }
        public State State { get; set; } = State.Notdone;
        public string  UserName { get; set; }
    }
}
