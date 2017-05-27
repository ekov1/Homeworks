using System;
using System.Linq;

namespace ConcurrentDbChanges
{
    public class Startup
    {
        public static void Main()
        {
            PerformConcurrentChanges();
        }

        private static void PerformConcurrentChanges()
        {
            var firstContext = new NorthwindEntities();
            var secondContext = new NorthwindEntities();
            string customerId = "KDKDK";

            // Final result is formed from the last saved changes to the updated record

            using (firstContext)
            {
                using (secondContext)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        UpdateCustomerCompanytName(firstContext, customerId, "My Company Ltd.");
                        UpdateCustomerCompanytName(secondContext, customerId, "My Second Company Ltd.");

                        secondContext.SaveChanges();
                        firstContext.SaveChanges();

                        var afterResult = new NorthwindEntities().Customers.Where(x => x.CustomerID == customerId).FirstOrDefault();
                        Console.WriteLine("Company name after both updates -> " + afterResult.CompanyName);
                    }
                }
            }
        }

        private static void UpdateCustomerCompanytName(NorthwindEntities context, string customerId, string companyName)
        {
            var customerToUpdate = context.Customers.Where(x => x.CustomerID == customerId).FirstOrDefault();

            customerToUpdate.CompanyName = companyName;
        }
    }
}
