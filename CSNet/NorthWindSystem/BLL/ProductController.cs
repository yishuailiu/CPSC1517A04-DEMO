﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



#region additional namespace
using NorthWindSystem.Data;
using NorthWindSystem.DAL;
using System.Data.SqlClient;
#endregion

namespace NorthWindSystem.BLL
{
    //this class will be called from an external source
    //in our example, this source will be the web page
    //naming standard is <T>Controller which represents a particular data class (sql table)
    public class ProductController
    {
        //code methods which will be called for processing 
        //methods will be public
        //these methods are referred to as the system interface

        //a method to lookup a record on the databse table by primary key
        //input: primary key value
        //output: instance of data class
        public Product Product_Get(int productid)
        {
            //the processing of the request will be done in a transaction using the Context class 
            //a) instance of Context class
            //b) issue the request for lookup via the appropriate DbSet<T>
            //c) return results
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productid);
            }
        }
        // a method to retrive all records on the DbSet<T>
        //input:none
        //output:List<T>
        public List<Product> Product_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }


        //at times you will need to do a NON-PROMARY KEY lookup
        //you will NOT be able to use .Find(pkday)
        //you can call sql procedures via your context clas with in your BLL class method
        //use .Database.SqlQuery<T>()  not DbSet<T>
        //the arguments(s) for SqlQuery are         
        //a) the sql procedure execute statement as a string
        //b) if required, any arguments for the procedure 
        //passing the data arguments to the procedure will make use of new .SqlParameter() object
        //the SqlParameter object needs a using clause : System.Data.SqlClient
        //SqlParameter takes two arguments
        //a) procedure paramter name
        //b) value to be passed
        public List<Product> Product_GetByCategory(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                //normally you will find taht data from EntityFramework returns as an IEnumerable<T> datatype
                //one can conver the Ienumerable<T> to a List<T> .ToList()
                IEnumerable<Product> results = context.Database.SqlQuery<Product>("Products_GetByCategories @CategoryID",new SqlParameter("CategoryID",categoryid));
                return results.ToList();
            }
        }
        public List<Product> Products_GetByPartialProductName(string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByPartialProductName @PartialName",
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }


        public List<Product> Products_GetBySupplierPartialProductName(int supplierid, string partialproductname)
        {
            using (var context = new NorthwindContext())
            {
                //sometimes there may be a sql error that does not like the new SqlParameter()
                //       coded directly in the SqlQuery call
                //if this happens to you then code your parameters as shown below then
                //       use the parm1 and parm2 in the SqlQuery call instead of the new....
                //don't know why but its weird
                //var parm1 = new SqlParameter("SupplierID", supplierid);
                //var parm2 = new SqlParameter("PartialProductName", partialproductname);
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetBySupplierPartialProductName @SupplierID, @PartialProductName",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("PartialProductName", partialproductname));
                return results.ToList();
            }
        }

        public List<Product> Products_GetForSupplierCategory(int supplierid, int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetForSupplierCategory @SupplierID, @CategoryID",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("CategoryID", categoryid));
                return results.ToList();
            }
        }

        public List<Product> Products_GetByCategoryAndName(int category, string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByCategoryAndName @CategoryID, @PartialName",
                                    new SqlParameter("CategoryID", category),
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
    }
}
