using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CalendarTasks
{
    [Serializable]
    class EveryYearTask : CalendarTask
    {
        public override DateTime? Date
        {
            get => date;
            set
            {
                int month = value.Value.Month;
                int dayOfMonth = value.Value.Day;
                date = new DateTime(0, month, dayOfMonth);
            }
        }

        public EveryYearTask(string name, DateTime? date, PriorityOfTask priorityOfTask = PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null) : base(name, date, priorityOfTask, timeOfBegin, timeOfEnd)
        { }
    }
}
