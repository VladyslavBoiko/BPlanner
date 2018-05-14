using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Model
{
    [Serializable]
    public class TasksController
    {
        private static TasksController tasksController = null;

        
        private List<CalendarTask> everyday;
        private TasksController()
        {
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
    }
}
