using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum TypeOfTask
    {   
        SingleUseTask,
        EveryDayTask,
        EveryMonthTask,
        EveryYearTask
    }

    [Serializable]
    public enum PriorityOfTask
    {
        Low,
        Neutral,
        High
    }

    [Serializable]
    public sealed class CalendarTask
    {
        
        private string name;
        private DateTime? date;
        private string timeOfBegin;
        private string timeOfEnd;
        private string description;
        [NonSerialized]
        private TypeOfTask typeOfTask;
        private PriorityOfTask priorityOfTask;

        public string Name { get => name; private set => name = value; }
        
        public TypeOfTask TaskType { get => typeOfTask; set => typeOfTask = value; }

        public DateTime? Date {
            get => date;
            set {
                switch (typeOfTask)
                {
                    case TypeOfTask.SingleUseTask:
                        date = value;
                        break;

                    case TypeOfTask.EveryDayTask:
                        date = new DateTime(0, 0, 0);
                        break;

                    case TypeOfTask.EveryMonthTask:
                        int day = value.Value.Day;
                        int year1 = value.Value.Year;
                        date = new DateTime(year1, 0, day);
                        break;

                    case TypeOfTask.EveryYearTask:
                        int month1 = value.Value.Month;
                        int dayOfMonth = value.Value.Day;
                        date = new DateTime(0, month1, dayOfMonth);
                        break;
                }
            }
        }

        public string TimeOfBegin { get => timeOfBegin; set => timeOfBegin = value; }

        public string TimeOfEnd { get => timeOfEnd; set => timeOfEnd = value; }

        public string Description { get => timeOfEnd; set => description = value; }

        public PriorityOfTask TaskPriority { get => priorityOfTask; set => priorityOfTask = value; }

        public CalendarTask(string name, TypeOfTask typeOfTask, DateTime? date = null, PriorityOfTask priorityOfTask = PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null)
        {
            Name = name;
            TaskType = typeOfTask;
            Date = date;
            TaskPriority = priorityOfTask;
            TimeOfBegin = timeOfBegin;
            TimeOfEnd = timeOfEnd;
        }


    }
}
