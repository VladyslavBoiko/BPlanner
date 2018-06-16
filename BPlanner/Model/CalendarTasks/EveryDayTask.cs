using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CalendarTasks
{
    [Serializable]
    public class EveryDayTask : CalendarTask
    {
        public sealed override DateTime? Date { get => date; set => date = new DateTime(0, 0, 0); }

        public EveryDayTask(string name, DateTime? date, PriorityOfTask priorityOfTask = PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null):base(name, priorityOfTask, timeOfBegin, timeOfEnd)
        {
            Date = date;
        }
    }
}
