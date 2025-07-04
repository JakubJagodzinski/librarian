using System.Text;
using librarian.Data;
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
                context.Seed();
            }

            Application.Run(new LoginForm());

        }
    }
}