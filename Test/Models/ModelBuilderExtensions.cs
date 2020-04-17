using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Marco",
                    Department = Dept.IT,
                    Email = "marco@yupi.cl"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Rob",
                    Department = Dept.HR,
                    Email = "rob@yupi.cl"
                }
            );
        }
    }
}
