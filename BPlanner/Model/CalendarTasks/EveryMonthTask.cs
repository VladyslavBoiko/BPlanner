using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CalendarTasks
{
    [Serializable]
    public class EveryMonthTask : CalendarTask
    {
        public sealed override DateTime? Date { get => date;
            set
            {
                int day = value.Value.Day;
                int year = value.Value.Year;
                date = new DateTime(year, 0, day);
            }
        }

        public EveryMonthTask(string name, DateTime? date, PriorityOfTask priorityOfTask = PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null):base(name, priorityOfTask, timeOfBegin, timeOfEnd)
        {
            Date = date;
        }
    }
}
