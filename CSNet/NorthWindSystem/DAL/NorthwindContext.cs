using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using NorthWindSystem.Data;
using System.Data.Entity;


//this class needs to have access to ADO.Net EntityFrameWork
//the Nuget package EntityFramework has already be added to this project
//this project also needs the assembly System.Data.Entity
//this project will need using clauses that point to 
//  a)System.Data.Entity namespace
//  b) your data project namespaces
namespace NorthWindSystem.DAL
{
    //the class access internal restrict alls to this call to methods within this project
    //this context class needs to inherit DContext from EntityFramework
    internal class NorthwindContext:DbContext
    {
         //setup the class default constructor to supply your connection string name to the DbContext inherited class
         //base passes value to the base class of DbContext
        public NorthwindContext():base("NWDB")
        {

        } 
        //create a Entityfromwork DbSet<T> for each mapped sql table
        //<T> is your class the .Data project
        public DbSet<Product> Products { get; set; }
    }
}
