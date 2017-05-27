namespace CreatingTwinDatabase
{
    public class Startup
    {
        public static void Main()
        {
            // Change connection string database name and execute to create the new database

            var context = new NorthwindEntities();

            context.Database.CreateIfNotExists();
        }
    }
}
