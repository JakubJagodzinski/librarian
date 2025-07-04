using librarian.Models;

namespace librarian.Seeders
{
    public class EmployeeSeeder : ISeeder
    {
        public void Seed(LibraryContext context)
        {
            try
            {
                if (!context.Employees.Any())
                {
                    var employees = new List<Employee>();
                    var random = new Random();

                    for (int i = 1; i <= 15; i++)
                    {
                        var hireDate = DateTime.Now.AddYears(-random.Next(1, 10)).AddDays(-random.Next(0, 365));
                        DateTime? terminationDate = i % 4 == 0 ? hireDate.AddYears(random.Next(1, 3)) : null;

                        employees.Add(new Employee
                        {
                            FullName = $"Employee {i}",
                            Email = $"employee{i}@library.com",
                            PhoneNumber = $"555-100-{i:0000}",
                            HireDate = hireDate,
                            TerminationDate = terminationDate
                        });
                    }

                    context.Employees.AddRange(employees);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Employee seeding error: {ex.Message}\nInner: {ex.InnerException?.Message}", "Seeder Error");
            }
        }
    }
}
