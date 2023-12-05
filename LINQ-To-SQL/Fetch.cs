using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LINQ_To_SQL
{
    enum QueryType
    {
        LINQ,
        SQL
    };
    

    class Fetch
    {
        #region "Private Fields"
            private string customerName;
            private bool useLINQ;
            private SqlConnectionStringBuilder builder;
        #endregion

        #region "Attribute Accessors"
            public bool UseLINQ
            {
                get
                {
                    return this.useLINQ;
                }
                set
                {
                    this.useLINQ = value;
                }
            }
        #endregion

        public List<string> GetCustomerList()
        {
            if (this.UseLINQ)
            {
                return GetCustomerList_LINQ();
            }
            else
            {
                return  GetCustomerList_SQL();
            }
        }

        private SqlDataReader GetDataReader(string sqlString)
        {
            SqlConnection dataConnection = new SqlConnection();
            SqlDataReader dataReader = null;

            try
            {
                dataConnection.ConnectionString = builder.ConnectionString;
                dataConnection.Open();
                SqlCommand dataCommand = new SqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandType = CommandType.Text;
                dataCommand.CommandText = sqlString;
                dataReader = dataCommand.ExecuteReader();
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Error accessing the database: {0}", exception.Message);
            }
            finally
            {
                dataConnection.Close();
            }

            return dataReader;
        }

        private List<string> GetCustomerList_SQL()
        {
            List<string> theList = new List<string>();
            //SqlConnection dataConnection = new SqlConnection();

            //try
            //{
            //    dataConnection.ConnectionString = builder.ConnectionString;
            //    dataConnection.Open();

            //    string sqlString = "Select distinct CompanyName ";
            //    sqlString += "From Customers " ;
            //    sqlString += "Order by CompanyName";
                           
            //    SqlCommand dataCommand = new SqlCommand();
            //    dataCommand.Connection = dataConnection;
            //    dataCommand.CommandType = CommandType.Text;
            //    dataCommand.CommandText = sqlString;

            //    SqlDataReader dataReader = dataCommand.ExecuteReader();
            //    while (dataReader.Read())
            //    {
            //        if (! dataReader.IsDBNull(0))
            //        {
            //            string companyName = dataReader.GetString(0);
            //            theList.Add(companyName);
            //        }
            //    }
            //    dataReader.Close();
            //}
            //catch (SqlException exception)
            //{
            //    Console.WriteLine("Error accessing the database: {0}", exception.Message);
            //}
            //finally
            //{
            //    dataConnection.Close();
            //}


                string sqlString = "Select distinct CompanyName ";
                sqlString += "From Customers ";
                sqlString += "Order by CompanyName";
                SqlDataReader dataReader = GetDataReader(sqlString);

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        string companyName = dataReader.GetString(0);
                        theList.Add(companyName);
                    }
                }
                dataReader.Close();
            return theList;
        }

        private List<string> GetCustomerList_LINQ()
        {
            List<string> theList = new List<string>();
            NorthwindDataContext northwindDB = new NorthwindDataContext();
            var customersQuery = from c in northwindDB.Customers
                                orderby c.CompanyName ascending
                                select c;

            foreach (var customer in customersQuery)
            {
                theList.Add(customer.CompanyName);
            }

            return theList;
        }

        public List<ListViewItem> GetOrders(string customer)
        {
            this.customerName = customer;
            if (this.UseLINQ)
            {
                return GetOrders_LINQ();
            }
            else
            {
                return GetOrders_SQL();
            }
        }

        private List<ListViewItem> GetOrders_LINQ()
        {
            List<ListViewItem> theList = new List<ListViewItem>();
            NorthwindDataContext northwindDB = new NorthwindDataContext();
            Table<Customer> Customers = northwindDB.GetTable<Customer>();
            Table<Order> Orders = northwindDB.GetTable<Order>();

            var ordersQuery = from o in Orders 
                            join c in Customers 
                            on o.CustomerID equals c.CustomerID
                            where String.Equals(c.CompanyName, customerName.Trim())
                            orderby c.CustomerID ascending
                            select new {o.OrderID, o.OrderDate, o.ShippedDate, o.ShipName, o.ShipAddress, o.ShipCity, o.ShipCountry };
                        
            foreach (var order in ordersQuery)
            {
                ListViewItem item = new ListViewItem(order.OrderID.ToString());
                item.SubItems.Add(String.Format("{0:MM/dd/yyyy}", order.OrderDate));
                if (order.ShippedDate == null)
                {
                    item.SubItems.Add("Not yet shipped");
                }
                else
                {
                    item.SubItems.Add(String.Format("{0:MM/dd/yyyy}", order.ShippedDate));
                }
                item.SubItems.Add(order.ShipName);
                item.SubItems.Add(order.ShipAddress);
                item.SubItems.Add(order.ShipCity);
                item.SubItems.Add(order.ShipCountry);
                theList.Add(item);
            }

            return theList;
        }

        private List<ListViewItem> GetOrders_SQL()
        {
            List<ListViewItem> theList = new List<ListViewItem>();
            SqlConnection dataConnection = new SqlConnection();

            try
            {
                dataConnection.ConnectionString = builder.ConnectionString;
                dataConnection.Open();

                
                string sqlString = "Select o.OrderID, o.OrderDate, o.ShippedDate, o.ShipName, o.ShipAddress, o.ShipCity, o.ShipCountry ";
                sqlString += "From Customers c ";
                sqlString += "Inner Join Orders o ";
                sqlString += "On c.CustomerID = o.CustomerID ";
                sqlString += "Where c.CompanyName = @CustomerIdParam ";
                sqlString += "Order by o.OrderID";
                           
                SqlCommand dataCommand = new SqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandType = CommandType.Text;
                dataCommand.CommandText = sqlString;

                SqlParameter param = new SqlParameter("@CustomerIdParam", SqlDbType.VarChar, 55, "customerName");
                param.Value = this.customerName;
                dataCommand.Parameters.Add(param);

                SqlDataReader dataReader = dataCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    int orderId = dataReader.GetInt32(0);
                    if (dataReader.IsDBNull(2))
                    {
                        Console.WriteLine("Order {0} not yet shipped\n\n", orderId);
                    }
                    else
                    {
                        DateTime orderDate = dataReader.GetDateTime(1);
                        DateTime shipDate = dataReader.GetDateTime(2);
                        string shipName = dataReader.GetString(3);
                        string shipAddress = dataReader.GetString(4);
                        string shipCity = dataReader.GetString(5);
                        string shipCountry = dataReader.GetString(6);

                        ListViewItem item = new ListViewItem(orderId.ToString());
                        item.SubItems.Add(String.Format("{0:MM/dd/yyyy}", orderDate));
                        if (shipDate == null)
                        {
                            item.SubItems.Add("Not yet shipped");
                        }
                        else
                        {
                            item.SubItems.Add(String.Format("{0:MM/dd/yyyy}", shipDate));
                        }
                        item.SubItems.Add(shipName);
                        item.SubItems.Add(shipAddress);
                        item.SubItems.Add(shipCity);
                        item.SubItems.Add(shipCountry);
                        theList.Add(item);
                    }
                }
                dataReader.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Error accessing the database: {0}", exception.Message);
            }
            finally
            {
                dataConnection.Close();
            }

            return theList;
        }

        #region "Constructor\Destructors"
            public Fetch()
            {
                builder = new SqlConnectionStringBuilder();
                builder.DataSource = ".\\SQLExpress";
                builder.InitialCatalog = "Northwind";
                builder.IntegratedSecurity = true;
                this.UseLINQ = true;
            }

            ~Fetch()
            {
                builder = null;
            }
        #endregion
    }
}
