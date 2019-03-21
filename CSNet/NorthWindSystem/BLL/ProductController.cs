using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region additional namespace
using NorthWindSystem.Data;
using NorthWindSystem.DAL;
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
    }
}
