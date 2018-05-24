using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CalendarTasks
{
    [Serializable]
    class SingleUseTask : CalendarTask
    {
        public override DateTime? Date { get => date; set => date = value; }

        public SingleUseTask(string name, DateTime? date, PriorityOfTask priorityOfTask = PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null) :base(name, date, priorityOfTask, timeOfBegin, timeOfEnd)
        {
        }
    }
}
