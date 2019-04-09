using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



#region additional namespace
using NorthWindSystem.Data;
using NorthWindSystem.DAL;
using System.Data.SqlClient;
using System.ComponentModel;//need to expose classes and method for ODS dialogs
#endregion

namespace NorthWindSystem.BLL
{
    [DataObject]
    //this class will be called from an external source
    //in our example, this source will be the web page
    //naming standard is <T>Controller which represents a particular data class (sql table)
    public class ProductController
    {
        #region queries
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
        [DataObjectMethod(DataObjectMethodType.Select, false)]
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
        #endregion
        //add update and delete
        //the add method will be used insert a product instance into the database
        //this method will receive an instance of product
        //this method can optionally return the new identity primary key
        public int Product_Add(Product item) {
            using (var context = new NorthwindContext())
            {
                //step 1:stating
                //one adds the new instance to the appropriate DBSet<T>
                //the data needs to be in an instance of <T>
                //staging does not place the record on the database
                //if the primary key of the <T> is an identity type
                //the pkey value is NOT yet set
                context.Products.Add(item);

                //stpe2: committing transaction,
                // if the command to save your DBSet changes is not executed. the transaction fails and a RollBack is proformed.
                //if the command to save your DBSet changes is executed and fils the transaction is RollBacked and the appropriate error message is issued
                //at this point ANY entity validation is executed
                //if the command to save your DBSet changes is successful then the data is in the database(unlesss the database finds an exception)
                //at this point your new identity pkey value is present in your <T> intance and can be retrived
                context.SaveChanges();

                return item.ProductID;
            }
        }
        //update, this logic will maintain the entire database record when updating
        //the results of the commit will return the number of rows affected
        //input: an instance of your <T> , with the pkey value included
        //output : rows affected

        public int Product_Update(Product item)
        {
            using (var context = new NorthwindContext())
            {
                //staging
                //the entire record will be staged
                //optionally
                //there may be additional attributes on your record that track when updates are done and / or track who did the updates
                //these attributes are filled by the logic in this control and SHOULD NOT be expected form the user
                //item.LastModified = DateTime.Now;
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                //commit 
                //this will return the number of rows affected
                return context.SaveChanges();
            }
        }
        public int Product_Delete(int productid)
        {
            using (var context = new NorthwindContext())
            {
                //delete has two ways
                // pysical delete, physical removal of the record from the database
                // logical delete, usually some record attribute is set to indicate that this record should be ignored
                //input : the pkey value of the record
                // output : rows affected
                // physical delete
                #region physical delete
                //staging
                //find the record to remove, stage record for removal and then commit
                //var existing = context.Products.Find(productid);
                //context.Products.Remove(existing);
                //return context.SaveChanges();
                #endregion

                #region logical delete
                //this action will actually be an update
                //any attributes that are required for tracking needto be handled
                //the attributes that indicates the record is logically removed needs to be hanlded
                //find record to be "deleted"
                var existing = context.Products.Find(productid);
                //existing.LastModified = DateTime.Now;
                existing.Discontinued = true;
                //stage for update
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                //commit
                return context.SaveChanges();
                #endregion
            }
        }
    }
}
