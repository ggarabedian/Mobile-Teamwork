namespace PersonalOrganiser.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Models;

    public static class TaskerDataRequester
    {
        public static async Task<List<TaskModel>> GetAllTasksAsync()
        {
            var connection = DbInstance.Get();

            var data = await connection.Table<TaskDataModel>().ToListAsync().ConfigureAwait(false);
            var result = new List<TaskModel>();

            var importances = new TaskModel().Importances;

            foreach (var task in data)
            {
                var curTask = new TaskModel()
                {
                    Id = task.Id,
                    Title = task.Title,
                    IsDone = task.IsDone,
                    TaskDateTime = task.Date,
                    TaskImportance = importances.Where(t => t.Id == task.TaskImportanceId).FirstOrDefault(),
                    ImageUrl = task.ImageUrl
                };

                result.Add(curTask);
            }

            return result;
        }

        public static async void UpdateTask(TaskModel finishedTask)
        {
            var connection = DbInstance.Get();

            var taskToUpdate = new TaskDataModel()
            {
                Id = finishedTask.Id,
                Title = finishedTask.Title,
                Date = finishedTask.TaskDateTime,
                TaskImportanceId = finishedTask.TaskImportance.Id,
                IsDone = finishedTask.IsDone,
                ImageUrl = finishedTask.ImageUrl
            };

            var result = await connection.UpdateAsync(taskToUpdate);
        }
    }
}
