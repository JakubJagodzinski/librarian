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
            using (var context = new LibraryContext())
            {
                if (context.TestConnection())
                {
                    MessageBox.Show("Database connection is working.", "Connection Status");
                }
                else
                {
                    MessageBox.Show("Database connection failed.", "Connection Status");
                }
            }
            Application.Run(new Form1());



        }
    }
}