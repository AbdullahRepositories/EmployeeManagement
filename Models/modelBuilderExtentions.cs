using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public static class modelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "abood",
                   Department = Dept.IT,
                   Email = "abood@gmail.com"
               },
               new Employee
               {
                   Id = 2,
                   Name = "mary",
                   Department = Dept.HR,
                   Email = "mary@gmail.com"
               }


               );
        }
    }
}
