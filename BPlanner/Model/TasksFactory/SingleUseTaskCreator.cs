﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TasksFactory
{
    public class SingleUseTaskCreator : ITasksCreator
    {
        public CalendarTasks.CalendarTask Create(string name, DateTime? date, CalendarTasks.PriorityOfTask priorityOfTask = CalendarTasks.PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null)
        {
            return new CalendarTasks.SingleUseTask(name, date, priorityOfTask, timeOfBegin, timeOfEnd);
        }
    }
}
