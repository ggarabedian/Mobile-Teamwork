namespace PersonalOrganiser.Data
{
    using System;
    using System.IO;

    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;

    using Windows.Storage;

    public static class DbInstance
    {
        private static SQLiteAsyncConnection connection;

        private static async void InitAsync()
        {
            connection = GetDbConnectionAsync();
            var result = connection.CreateTablesAsync<ScheduledEventModel, TaskDataModel>();
            while (!result.IsCompleted)
            {

            }
        }

        private static SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "eventScheduler.data");

            var connectionFactory =
                 new Func<SQLiteConnectionWithLock>(
                     () =>
                     new SQLiteConnectionWithLock(
                         new SQLitePlatformWinRT(),
                         new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        public static SQLiteAsyncConnection Get()
        {
            if (connection == null)
            {
                InitAsync();
            }

            return connection;
        }
    }
}
