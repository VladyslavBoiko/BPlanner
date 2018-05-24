using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TasksFactory
{
    public interface ITasksCreator
    {
        CalendarTasks.CalendarTask Create(string name, DateTime? date, CalendarTasks.PriorityOfTask priorityOfTask = CalendarTasks.PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null);
    }
}
