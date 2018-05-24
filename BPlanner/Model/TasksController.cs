using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Model.CalendarTasks;
using Model.TasksFactory;
using System.Collections.ObjectModel;

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
    public class TasksController
    {
        private static TasksController tasksController = null;

        private ObservableCollection<SingleUseTask> singleUseTasks;
        private ObservableCollection<EveryDayTask> everyDayTasks;
        private ObservableCollection<EveryMonthTask> everyMonthTasks;
        private ObservableCollection<EveryYearTask> everyYearTasks;


        private TasksController()
        {
            /*
             * Realize DAL and Repository Pattern, 
             * then initilize collections
             */
            singleUseTasks = new ObservableCollection<SingleUseTask>();
            Task.WaitAll();
        }

        public static TasksController GetTasksController()
        {
            if (tasksController != null)
                return tasksController;

            TasksController temp = new TasksController();
            Interlocked.CompareExchange(ref tasksController, temp, null);
            return tasksController;
        }

        public async void Add(TypeOfTask typeOfTask, string name, DateTime? date, PriorityOfTask priorityOfTask = PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null)
        {
            ITasksCreator taskFactory;

            switch(typeOfTask)
            {
                case TypeOfTask.SingleUseTask:
                    taskFactory = new SingleUseTaskCreator();
                    await Task.Run(() => singleUseTasks.Add(taskFactory.Create(name, date, priorityOfTask, timeOfBegin, timeOfEnd) as SingleUseTask));
                    break;
                case TypeOfTask.EveryDayTask:
                    taskFactory = new EveryDayTaskCreator();
                    await Task.Run(() => everyDayTasks.Add(taskFactory.Create(name, date, priorityOfTask, timeOfBegin, timeOfEnd) as EveryDayTask));
                    break;
                case TypeOfTask.EveryMonthTask:
                    taskFactory = new EveryMonthTaskCreator();
                    await Task.Run(() => everyMonthTasks.Add(taskFactory.Create(name, date, priorityOfTask, timeOfBegin, timeOfEnd) as EveryMonthTask));
                    break;
                case TypeOfTask.EveryYearTask:
                    taskFactory = new EveryYearTaskCreator();
                    await Task.Run(() => everyYearTasks.Add(taskFactory.Create(name, date, priorityOfTask, timeOfBegin, timeOfEnd) as EveryYearTask));
                    break;
            }
        }

        public async void Remove(CalendarTask calendarTask)
        {
            if (calendarTask is SingleUseTask)
            {
                await Task.Run(() => singleUseTasks.Remove(calendarTask as SingleUseTask));
                return;
            }
            if (calendarTask is EveryDayTask)
            {
                await Task.Run(() => everyDayTasks.Remove(calendarTask as EveryDayTask));
                return;
            }
            if(calendarTask is EveryMonthTask)
            {
                await Task.Run(() => everyMonthTasks.Remove(calendarTask as EveryMonthTask));
                return;
            }
            if(calendarTask is EveryYearTask)
            {
                await Task.Run(() => everyYearTasks.Remove(calendarTask as EveryYearTask));
                return;
            }
        }
    }
}
