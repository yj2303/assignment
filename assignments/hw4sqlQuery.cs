using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using ConsoleDump;
using System.Data;

namespace AdoNetSample
{
    internal class Program
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["NorthwindDb"].ConnectionString;

        static void Main(string[] args)
        {
            DataReaderDemo();

            

            DataSetDemo();

           
            ParameterizedQueryDemo(productId);

           
            ExecuteNonQueryDemo(productId);

            Console.ReadKey();
        }


        private static IEnumerable<Order> DataReaderToOrdersDemo()
        {
            var orders = new List<Order>();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var sql = "SELECT * FROM Orders";

                using (var sqlCommand = new SqlCommand(sql, sqlConnection))
               using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ProductID", productId);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        var productIDOrdinal = dataReader.GetOrdinal("ProductID");
                        var productNameOrdinal = dataReader.GetOrdinal("ProductName");
                        var supplierIDOrdinal = dataReader.GetOrdinal("SupplierID");
                        var categoryIDOrdinal = dataReader.GetOrdinal("CategoryID");
                        var quantityPerUnitOrdinal = dataReader.GetOrdinal("QuantityPerUnit");
                        var unitPriceOrdinal = dataReader.GetOrdinal("UnitPrice");
                        var unitsInStockOrdinal = dataReader.GetOrdinal("UnitsInStock");
                        var unitsOnOrderOrdinal = dataReader.GetOrdinal("UnitsOnOrder");
                        var reorderLevelOrdinal = dataReader.GetOrdinal("ReorderLevel");
                        var discontinuedOrdinal = dataReader.GetOrdinal("Discontinued");
                        while (dataReader.Read())
                        {
                            product.Add(new Product
                            {
                            
                                ProductID = !dataReader.IsDBNull(productIDOrdinal) ? dataReader.GetString(productIDOrdinal) : null,
                                ProductName = !dataReader.IsDBNull(productNameOrdinal) ? dataReader.GetInt32(productNameOrdinal) : (int?)null,
                                SupplierId = !dataReader.IsDBNull(supplierIDOrdinal) ? dataReader.GetDateTime(supplierIDOrdinal) : (DateTime?)null,
                                CategoryId = !dataReader.IsDBNull(categoryIDOrdinal) ? dataReader.GetDateTime(categoryIDOrdinal) : (DateTime?)null,
                                QuantityPerUnit = !dataReader.IsDBNull(quantityPerUnitOrdinal) ? dataReader.GetDateTime(quantityPerUnitOrdinal) : (DateTime?)null,
                                UnitPrice = !dataReader.IsDBNull(unitPriceOrdinal) ? dataReader.GetInt32(unitPriceOrdinal) : (int?)null,
                                UnitsInStock = !dataReader.IsDBNull(unitsInStockOrdinal) ? dataReader.GetDecimal(unitsInStockOrdinal) : (decimal?)null,
                                UnitsOnOrder = !dataReader.IsDBNull(unitsOnOrderOrdinal) ? dataReader.GetString(unitsOnOrderOrdinal) : null,
                                ReorderLevel = !dataReader.IsDBNull(reorderLevelOrdinal) ? dataReader.GetString(reorderLevelOrdinal) : null,
                                Discontinued = !dataReader.IsDBNull(discontinuedOrdinal) ? dataReader.GetString(discontinuedOrdinal) : null,
                             });
                        }
                    }
                }

                }
            

            return Product.AsEnumerable();
        }

        
        private static void ParameterizedQueryDemo(int productId)
        {
            var orders = new List<Order>();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var sql = "UPDATE Products SET UnitPrice = 1000 WHERE ProductID=productId;";

                using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ProductID", productId);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        var productIDOrdinal = dataReader.GetOrdinal("ProductID");
                        var productNameOrdinal = dataReader.GetOrdinal("ProductName");
                        var supplierIDOrdinal = dataReader.GetOrdinal("SupplierID");
                        var categoryIDOrdinal = dataReader.GetOrdinal("CategoryID");
                        var quantityPerUnitOrdinal = dataReader.GetOrdinal("QuantityPerUnit");
                        var unitPriceOrdinal = dataReader.GetOrdinal("UnitPrice");
                        var unitsInStockOrdinal = dataReader.GetOrdinal("UnitsInStock");
                        var unitsOnOrderOrdinal = dataReader.GetOrdinal("UnitsOnOrder");
                        var reorderLevelOrdinal = dataReader.GetOrdinal("ReorderLevel");
                        var discontinuedOrdinal = dataReader.GetOrdinal("Discontinued");
                        while (dataReader.Read())
                        {
                            product.Add(new Product
                            {
                            
                                ProductID = !dataReader.IsDBNull(productIDOrdinal) ? dataReader.GetString(productIDOrdinal) : null,
                                ProductName = !dataReader.IsDBNull(productNameOrdinal) ? dataReader.GetInt32(productNameOrdinal) : (int?)null,
                                SupplierId = !dataReader.IsDBNull(supplierIDOrdinal) ? dataReader.GetDateTime(supplierIDOrdinal) : (DateTime?)null,
                                CategoryId = !dataReader.IsDBNull(categoryIDOrdinal) ? dataReader.GetDateTime(categoryIDOrdinal) : (DateTime?)null,
                                QuantityPerUnit = !dataReader.IsDBNull(quantityPerUnitOrdinal) ? dataReader.GetDateTime(quantityPerUnitOrdinal) : (DateTime?)null,
                                UnitPrice = !dataReader.IsDBNull(unitPriceOrdinal) ? dataReader.GetInt32(unitPriceOrdinal) : (int?)null,
                                UnitsInStock = !dataReader.IsDBNull(unitsInStockOrdinal) ? dataReader.GetDecimal(unitsInStockOrdinal) : (decimal?)null,
                                UnitsOnOrder = !dataReader.IsDBNull(unitsOnOrderOrdinal) ? dataReader.GetString(unitsOnOrderOrdinal) : null,
                                ReorderLevel = !dataReader.IsDBNull(reorderLevelOrdinal) ? dataReader.GetString(reorderLevelOrdinal) : null,
                                Discontinued = !dataReader.IsDBNull(discontinuedOrdinal) ? dataReader.GetString(discontinuedOrdinal) : null,
                             });
                        }
                    }
                }
            }
        }

        
        private static void ExecuteNonQueryDemo(int productId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var sql = @"DELETE FROM Products WHERE ProductID= productId";

               using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ProductID", productId);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        var productIDOrdinal = dataReader.GetOrdinal("ProductID");
                        var productNameOrdinal = dataReader.GetOrdinal("ProductName");
                        var supplierIDOrdinal = dataReader.GetOrdinal("SupplierID");
                        var categoryIDOrdinal = dataReader.GetOrdinal("CategoryID");
                        var quantityPerUnitOrdinal = dataReader.GetOrdinal("QuantityPerUnit");
                        var unitPriceOrdinal = dataReader.GetOrdinal("UnitPrice");
                        var unitsInStockOrdinal = dataReader.GetOrdinal("UnitsInStock");
                        var unitsOnOrderOrdinal = dataReader.GetOrdinal("UnitsOnOrder");
                        var reorderLevelOrdinal = dataReader.GetOrdinal("ReorderLevel");
                        var discontinuedOrdinal = dataReader.GetOrdinal("Discontinued");
                        while (dataReader.Read())
                        {
                            product.Add(new Product
                            {
                            
                                ProductID = !dataReader.IsDBNull(productIDOrdinal) ? dataReader.GetString(productIDOrdinal) : null,
                                ProductName = !dataReader.IsDBNull(productNameOrdinal) ? dataReader.GetInt32(productNameOrdinal) : (int?)null,
                                SupplierId = !dataReader.IsDBNull(supplierIDOrdinal) ? dataReader.GetDateTime(supplierIDOrdinal) : (DateTime?)null,
                                CategoryId = !dataReader.IsDBNull(categoryIDOrdinal) ? dataReader.GetDateTime(categoryIDOrdinal) : (DateTime?)null,
                                QuantityPerUnit = !dataReader.IsDBNull(quantityPerUnitOrdinal) ? dataReader.GetDateTime(quantityPerUnitOrdinal) : (DateTime?)null,
                                UnitPrice = !dataReader.IsDBNull(unitPriceOrdinal) ? dataReader.GetInt32(unitPriceOrdinal) : (int?)null,
                                UnitsInStock = !dataReader.IsDBNull(unitsInStockOrdinal) ? dataReader.GetDecimal(unitsInStockOrdinal) : (decimal?)null,
                                UnitsOnOrder = !dataReader.IsDBNull(unitsOnOrderOrdinal) ? dataReader.GetString(unitsOnOrderOrdinal) : null,
                                ReorderLevel = !dataReader.IsDBNull(reorderLevelOrdinal) ? dataReader.GetString(reorderLevelOrdinal) : null,
                                Discontinued = !dataReader.IsDBNull(discontinuedOrdinal) ? dataReader.GetString(discontinuedOrdinal) : null,
                             });
                        }
                    }
                }

            }
        }
    }
}
