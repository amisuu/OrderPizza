using RelevantPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelevantPizza.Data
{
    public class DbInitializer
    {
        public static void Initialize(PizzaContext context)
        {
            if (context.Employees.Any())
            {
                return;
            }

            Employe[] employees = new Employe[]
            {
                new Employe {FirstName = "John", LastName = "Prescot", PhoneNumber="123-1234-1356",Role=Roles.Manager,Salary=40000},
                new Employe { FirstName = "Jim", LastName = "Smith", PhoneNumber = "123-4324-1326", Role = Roles.AssistantManager, Salary = 15000 },
                new Employe { FirstName = "Bob", LastName = "Anderson", PhoneNumber = "123-1234-1356", Role = Roles.Cashier, Salary = 8000 }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
