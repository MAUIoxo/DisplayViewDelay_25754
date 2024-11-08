namespace DisplayViewDelayDatabase.Core
{
    public static class DatabaseConstants
    {
        public static string AppDataDirectory;

        public static string DatabasePath => Path.Combine(AppDataDirectory, "DisplayViewDelayDatabaseSQLite.db3");
    }
}
