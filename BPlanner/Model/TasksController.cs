using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Model.CalendarTasks;
using Model.TasksFactory;
using System.Collections.ObjectModel;
using DAL;

namespace Model
{
    public enum TypeOfTask
    {
        SingleUseTask,
        EveryDayTask,
        EveryMonthTask,
        EveryYearTask
    }

    public class TasksController
    {
        private static TasksController tasksController;
        readonly ObservableCollection<CalendarTask> calendarTasks;

        private TasksController()
        { 
            calendarTasks = Task.Run(() => InitializeTasks(new BinSerializationDA(calendarTasks.GetType().ToString()))).Result;
        }

        private ObservableCollection<CalendarTask> InitializeTasks(IDataAccess wayToInitialize)
        {
            ObservableCollection<CalendarTask> tasks = null;

            try
            {
                tasks = (ObservableCollection<CalendarTask>)wayToInitialize.GetData();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            if (tasks == null)
                tasks = new ObservableCollection<CalendarTask>();

            return tasks;
        }

        public static TasksController GetTasksController()
        {
            if (tasksController != null)
                return tasksController;

            TasksController temp = new TasksController();
            Interlocked.CompareExchange(ref tasksController, temp, null);
            return tasksController;
        }

        public async Task AddAsync(TypeOfTask typeOfTask, string name, DateTime? date, PriorityOfTask priorityOfTask = PriorityOfTask.Neutral, string timeOfBegin = null, string timeOfEnd = null)
        {
            ITasksCreator taskFactory = null;

            switch(typeOfTask)
            {
                case TypeOfTask.SingleUseTask:
                    taskFactory = new SingleUseTaskCreator();
                    break;
                case TypeOfTask.EveryDayTask:
                    taskFactory = new EveryDayTaskCreator();
                    break;
                case TypeOfTask.EveryMonthTask:
                    taskFactory = new EveryMonthTaskCreator();
                    break;
                case TypeOfTask.EveryYearTask:
                    taskFactory = new EveryYearTaskCreator();
                    break;
            }
            await Task.Run(() => calendarTasks.Add(taskFactory.Create(name, date, priorityOfTask, timeOfBegin, timeOfEnd)));
        }

        public async Task RemoveAsync(CalendarTask calendarTask)
        {
            await Task.Run(() => calendarTasks.Remove(calendarTask));
        }

        public async Task<ObservableCollection<CalendarTask>> GetTasksByTypeAsync(TypeOfTask typeOfTask)
        {
            ObservableCollection<CalendarTask> result = null;

            switch (typeOfTask)
            {
                case TypeOfTask.SingleUseTask:
                    result = await GetSingleUseTasksAsync();
                    break;
                case TypeOfTask.EveryDayTask:
                    result = await GetEveryDayTasksAsync();
                    break;
                case TypeOfTask.EveryMonthTask:
                    result = await GetEveryMonthTasksAsync();
                    break;
                case TypeOfTask.EveryYearTask:
                    result = await GetEveryYearTasksAsync();
                    break;
            }

            return result;
        }

        private async Task<ObservableCollection<CalendarTask>> GetSingleUseTasksAsync()
        {
            var result = await Task.Run(() => calendarTasks.Where(t => t is SingleUseTask));
            return result as ObservableCollection<CalendarTask>;
        }

        private async Task<ObservableCollection<CalendarTask>> GetEveryDayTasksAsync()
        {
            var result = await Task.Run(() => calendarTasks.Where(t => t is EveryDayTask));
            return result as ObservableCollection<CalendarTask>;
        }

        private async Task<ObservableCollection<CalendarTask>> GetEveryMonthTasksAsync()
        {
            var result = await Task.Run(() => calendarTasks.Where(t => t is EveryMonthTask));
            return result as ObservableCollection<CalendarTask>;
        }

        private async Task<ObservableCollection<CalendarTask>> GetEveryYearTasksAsync()
        {
            var result = await Task.Run(() => calendarTasks.Where(t => t is EveryYearTask));
            return result as ObservableCollection<CalendarTask>;
        }
    }
}
