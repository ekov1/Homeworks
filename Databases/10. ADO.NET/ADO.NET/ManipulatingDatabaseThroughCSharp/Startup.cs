using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace ManipulatingDatabaseThroughCSharp
{
    public class Startup
    {
        public static void Main()
        {
            //MSSQLServerCommands();
            //OleDbCommands();
            MySQLCommands();
        }

        private static void MSSQLServerCommands()
        {
            SqlConnection connection = new SqlConnection("Server=.;Database=Northwind;Trusted_Connection=True;");

            connection.Open();

            using (connection)
            {
                //CategoryTableRecordCount(connection);
                //GetNameAndDescriptionOfCategory(connection);
                //GetProductsByCategory(connection);
                //AddNewProduct(connection);
                //SavePicturesFromDatabase(connection);
                FindProductContainingString("ch", connection);
            }
        }

        private static void OleDbCommands()
        {

            var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\scores.xlsx;" + @"Extended Properties=""Excel 12.0 Xml; HDR = YES"";";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                //ReadExcelData(connection);
                AddNewRecordToSpreadsheet(connection);
            }
        }

        private static void MySQLCommands()
        {
            var connectionString = @"Server = localhost; Port = 3306; Database = library;
            Uid = root; Pwd = YOUR_PASSWORD; pooling = true";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                //ListAllBooks(connection);
                //FindBookByName(connection, "War and Peace");
                //AddNewBook(connection);
            }
        }

        private static void ListAllBooks(MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM books", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var bookProperties = new List<string>();

                    for (int i = 0; i < reader.VisibleFieldCount; i++)
                    {
                        bookProperties.Add(reader[i].ToString());
                    }

                    Console.WriteLine(string.Join(" - ", bookProperties));
                }
            }
        }

        private static void FindBookByName(MySqlConnection connection, string searchTitle)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM books", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                var matchingBooks = new List<string>();

                while (reader.Read())
                {
                    string bookTitle = ((string)reader["title"]).ToLower();

                    if (bookTitle == searchTitle.ToLower())
                    {
                        for (int i = 0; i < reader.VisibleFieldCount; i++)
                        {
                            matchingBooks.Add(reader[i].ToString());
                        }
                    }
                }

                Console.WriteLine(string.Join(" - ", matchingBooks));
            }
        }

        private static void AddNewBook(MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO books VALUES(@id, @title, @author, @publishDate, @isbn)", connection);

            command.Parameters.AddWithValue("@id", 4);
            command.Parameters.AddWithValue("@title", "The Adventures of Huckleberry Finn");
            command.Parameters.AddWithValue("@author", "Mark Twain");
            command.Parameters.AddWithValue("@publishDate", "2001-05-10 05:01:20");
            command.Parameters.AddWithValue("@isbn", "987456875");

            command.ExecuteNonQuery();
        }

        private static void CategoryTableRecordCount(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);

            var recordCount = (int)command.ExecuteScalar();

            Console.WriteLine($"Categories table record count => " + recordCount);
        }

        private static void GetNameAndDescriptionOfCategory(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", connection);

            var reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Category name : {0} - Description : {1}", reader[0], reader[1]);
                }
            }
        }

        private static void GetProductsByCategory(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(@"SELECT p.ProductName, c.CategoryName FROM Categories c 
                                                    JOIN Products p
                                                    ON p.CategoryID = c.CategoryID 
                                                    ORDER BY c.CategoryName", connection);

            var reader = command.ExecuteReader();
            var categoryName = string.Empty;
            var productName = string.Empty;
            var productInCategory = new Dictionary<string, IList<string>>();

            using (reader)
            {

                while (reader.Read())
                {
                    productName = (string)reader["ProductName"];
                    categoryName = (string)reader["CategoryName"];

                    if (productInCategory.ContainsKey(categoryName))
                    {
                        productInCategory[categoryName].Add(productName);
                    }
                    else
                    {
                        productInCategory[categoryName] = new List<string> { productName };
                    }
                }
            }

            foreach (var item in productInCategory)
            {
                var productsList = string.Join(", ", productInCategory[item.Key]);
                Console.WriteLine("Category: {0} {1} Products: {2}", item.Key, Environment.NewLine, productsList);
            }
        }

        private static void AddNewProduct(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Products
    VALUES( @name, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsInOrder, @reorderLevel, @discontinued)",
    connection);

            command.Parameters.AddWithValue("@name", "Bonbonki");
            command.Parameters.AddWithValue("@supplierId", 1);
            command.Parameters.AddWithValue("@categoryId", 3);
            command.Parameters.AddWithValue("@quantityPerUnit", "100 full trucks");
            command.Parameters.AddWithValue("@unitPrice", 1000.0000);
            command.Parameters.AddWithValue("@unitsInStock", 900);
            command.Parameters.AddWithValue("@unitsInOrder", 20);
            command.Parameters.AddWithValue("@reorderLevel", 10);
            command.Parameters.AddWithValue("@discontinued", 0);

            command.ExecuteNonQuery();
        }

        private static void SavePicturesFromDatabase(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", connection);

            var reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    byte[] binaryPicture = (byte[])reader["Picture"];
                    var categoryName = (string)reader["CategoryName"];

                    categoryName = categoryName.Replace('/', '-');

                    var filePath = @"C:\Downloads\Telerik\Homeworks\Databases\10. ADO.NET\SavedPictures\picture" + categoryName + ".jpg";
                    SaveFile(binaryPicture, 78, filePath);
                }
            }

            Console.WriteLine("Finished!");
        }

        private static void SaveFile(byte[] binaryPicture, int offset, string path)
        {
            FileStream stream = File.OpenWrite(path);

            using (stream)
            {
                stream.Write(binaryPicture, offset, binaryPicture.Length - offset);
            }
        }

        private static void ReadExcelData(OleDbConnection connection)
        {
            var command = new OleDbCommand("select * from [scores$]", connection);

            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} --- {1}", reader[0], reader[1]);
                }
            }
        }

        private static void AddNewRecordToSpreadsheet(OleDbConnection connection)
        {

        }

        private static void FindProductContainingString(string searchText, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT ProductName FROM Products", connection);
            var matchingProducts = new List<string>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string productName = (string)reader["ProductName"];

                    if (productName.Contains(searchText))
                    {
                        matchingProducts.Add(productName);
                    }
                }
            }

            Console.WriteLine("Products found: {0}", string.Join(", ", matchingProducts));
        }
    }
}
