using librarian.Models;

namespace librarian.Data.Seeders.Implementations
{
    public class EmployeeSeeder : ISeeder
    {
        private void ClearTable(LibraryDbContext context)
        {
            var existingEmployees = context.Employees.ToList();
            var relatedCredentials = context.UserCredentials
                .Where(c => c.EmployeeId != null)
                .ToList();

            context.UserCredentials.RemoveRange(relatedCredentials);
            context.Employees.RemoveRange(existingEmployees);
            context.SaveChanges();
        }

        public void Seed(LibraryDbContext context, bool clearTable)
        {
            context.Employees.RemoveRange();
            try
            {
                if (clearTable)
                {
                    ClearTable(context);
                }

                if (!context.Employees.Any())
                {
                    var employees = new List<Employee>();
                    var credentials = new List<UserCredentials>();
                    var random = new Random();

                    for (int i = 1; i <= 15; i++)
                    {
                        var hireDate = DateTime.Now.AddYears(-random.Next(1, 10)).AddDays(-random.Next(0, 365));
                        DateTime? terminationDate = i % 4 == 0 ? hireDate.AddYears(random.Next(1, 3)) : null;

                        var employee = new Employee
                        {
                            FullName = $"Employee {i}",
                            Email = $"employee{i}@librarian.com",
                            PhoneNumber = $"555-100-{i:0000}",
                            HireDate = hireDate,
                            TerminationDate = terminationDate
                        };

                        employees.Add(employee);

                        credentials.Add(new UserCredentials
                        {
                            Email = employee.Email,
                            PasswordHash = PasswordHasher.Hash("123"),
                            Employee = employee
                        });
                    }

                    context.Employees.AddRange(employees);
                    context.UserCredentials.AddRange(credentials);
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
