using librarian.Data;
using librarian.Data.Managers;
using librarian.Data.Views;
using librarian.Forms;

namespace librarian
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var context = new LibraryDbContext())
            {
                var seederManager = new SeederManager(context);
                seederManager.Seed(true);

                var triggerManager = new TriggerManager(context);
                triggerManager.CreateTriggers();

                var procedureManager = new ProcedureManager(context);
                procedureManager.CreateProcedures();

                var indexManager = new IndexManager(context);
                indexManager.CreateIndexes();

                var functionManager = new FunctionManager(context);
                functionManager.CreateFunctions();

                var viewManager = new ViewManager(context);
                viewManager.CreateViews();
            }

            Application.Run(new LoginForm());

        }
    }
}