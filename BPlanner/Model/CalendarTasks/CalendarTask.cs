using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CalendarTasks
{
        [Serializable]
        public enum PriorityOfTask
        {
            Low,
            Neutral,
            High
        }

        [Serializable]
        public abstract class CalendarTask
        {
            protected string name;
            protected DateTime? date;
            protected string timeOfBegin;
            protected string timeOfEnd;
            protected string description;
            protected PriorityOfTask priorityOfTask;

            public string Name { get => name; set => name = value; }

            public abstract DateTime? Date { get; set; }

            public string TimeOfBegin { get => timeOfBegin; set => timeOfBegin = value; }

            public string TimeOfEnd { get => timeOfEnd; set => timeOfEnd = value; }

            public string Description { get => timeOfEnd; set => description = value; }

            public PriorityOfTask TaskPriority { get => priorityOfTask; set => priorityOfTask = value; }

            public CalendarTask(string name, DateTime? date, PriorityOfTask priorityOfTask = PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null)
            {
                Name = name;
                Date = date;
                TaskPriority = priorityOfTask;
                TimeOfBegin = timeOfBegin;
                TimeOfEnd = timeOfEnd;
            }
        }
}
