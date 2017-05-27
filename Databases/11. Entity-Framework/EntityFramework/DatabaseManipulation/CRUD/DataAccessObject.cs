using System;
using System.Linq;

namespace DatabaseManipulation
{
    public static class DataAccessObject
    {
        public static void InsertCustomer(NorthwindEntities context, string customerId, string companyName, string contactName = null, string contactTitle = null, string address = null,
            string city = null, string region = null, string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            using (context)
            {
                var dbCustomers = context.Customers;

                var newCustomer = new Customer
                {
                    CustomerID = customerId,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                dbCustomers.Add(newCustomer);

                context.SaveChanges();
            }
        }

        public static void UpdateCustomerContactName(NorthwindEntities context, string customerId, string contactName)
        {
            using (context)
            {
                var customerToUpdate = GetCustomerById(context, customerId);

                customerToUpdate.ContactName = contactName;

                context.SaveChanges();
            }
        }

        public static void UpdateCustomerAddress(NorthwindEntities context, string customerId, string newAddress)
        {
            using (context)
            {
                var customerToUpdate = GetCustomerById(context, customerId);

                customerToUpdate.Address = newAddress;

                context.SaveChanges();
            }
        }

        public static void DeleteCustomer(NorthwindEntities context, string customerId)
        {
            using (context)
            {
                var customerToDelete = GetCustomerById(context, customerId);

                context.Customers.Remove(customerToDelete);

                context.SaveChanges();
            }
        }

        private static Customer GetCustomerById(NorthwindEntities context, string customerId)
        {
            var customer = context.Customers.Where(c => c.CustomerID == customerId).FirstOrDefault();

            return customer;
        }

        public static void FindCustomersWithSpecificOrders(NorthwindEntities context)
        {
            using (context)
            {
                var matchingCustomers = context.Orders
                    .Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada")
                    .Select(o => o.Customer)
                    .Distinct()
                    .ToList();

                foreach (var customer in matchingCustomers)
                {
                    Console.WriteLine("Customer contact name -> " + customer.ContactName);
                }
            }
        }

        public static void FindCustomersWithSpecificOrdersLINQ(NorthwindEntities context)
        {
            using (context)
            {
                string sqlQueryString = @"SELECT DISTINCT c.ContactName FROM Customers c
                                          JOIN Orders o ON c.CustomerID = o.CustomerID
                                            WHERE YEAR(o.OrderDate) = 1997 AND o.ShipCountry = 'Canada'";

                var matchingCustomers = context.Database.SqlQuery<string>(sqlQueryString);

                foreach (var name in matchingCustomers)
                {
                    Console.WriteLine("Customer contact name -> " + name);
                }
            }
        }

        public static void FindSalesByRegionAndPeriod(NorthwindEntities context, string region, DateTime startDate, DateTime endDate)
        {
            using (context)
            {

                var matchingSales = context.Orders
                    .Where(x => x.ShipRegion == region && x.ShippedDate >= startDate && x.ShippedDate <= endDate)
                    .Select(c => c.Customer.ContactName)
                    .Distinct()
                    .ToList();

                Console.WriteLine("Customer names by sale in period and region:" + Environment.NewLine);

                foreach (var order in matchingSales)
                {
                    Console.WriteLine("{0}", order);
                }
            }
        }
    }
}
