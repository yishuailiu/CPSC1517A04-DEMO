﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthWindSystem.Data; //obtains the <T> devinitions
using NorthWindSystem.DAL;  //obtains the context class
#endregion
using System.ComponentModel;//need to expose classes and method for ODS dialogs
namespace NorthWindSystem.BLL

{
    [DataObject]
    public class CategoryController
    {
        public Category Category_Get(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Category> Category_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }
    }
}
