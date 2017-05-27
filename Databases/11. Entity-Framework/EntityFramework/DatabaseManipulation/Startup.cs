using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManipulation
{
    public class Startup
    {
        public static void Main()
        {
            var dbContext = new NorthwindEntities();

            //DataAccessObject.InsertCustomer(dbContext, "KSDSS", "Telerik New Ltd.");
            //DataAccessObject.UpdateCustomerContactName(dbContext, "KSDSS", "Pesho Ivanov");
            //DataAccessObject.DeleteCustomer(dbContext, "KKKKK");

            //DataAccessObject.FindCustomersWithSpecificOrders(dbContext);
            //DataAccessObject.FindCustomersWithSpecificOrdersLINQ(dbContext);

            //var startDate = DateTime.Parse("1996-01-01");
            //var endDate = DateTime.Parse("1999-12-30");
            //DataAccessObject.FindSalesByRegionAndPeriod(dbContext, "BC", startDate, endDate);
        }
    }
}
