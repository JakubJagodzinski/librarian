using librarian.Data.Managers;
using librarian.Data.Views;

namespace librarian.Data.Initialization
{
    public static class DatabaseInitializer
    {
        public static void Initialize(bool clearTables = false)
        {
            using (var context = new LibraryDbContext())
            {
                if (context.Database.EnsureCreated())
                {
                    var indexManager = new IndexManager(context);
                    indexManager.CreateIndexes();

                    var viewManager = new ViewManager(context);
                    viewManager.CreateViews();

                    var triggerManager = new TriggerManager(context);
                    triggerManager.CreateTriggers();

                    var procedureManager = new ProcedureManager(context);
                    procedureManager.CreateProcedures();

                    var functionManager = new FunctionManager(context);
                    functionManager.CreateFunctions();

                    var seederManager = new SeederManager(context);
                    seederManager.Seed(clearTables);
                }
            }
        }
    }
}
