using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Entity
{
    public class TaskUser
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; }
        public DateTime TimeToDone { get; set; }
        public State State { get; set; } = State.Notdone;

    }
    public enum State
    {
        Notdone=1,
        Inprogress,
        Done,
        Cancceled
       
    }


}
