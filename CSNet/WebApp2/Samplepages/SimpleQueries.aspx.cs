using NorthWindSystem.BLL;
using NorthWindSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp2.Samplepages
{
    public partial class SimpleQueries : System.Web.UI.Page
    {
        private int productid;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //validate your input
            //bad : messsage to ser
            //good : standard look up pattern and display 
            if (string.IsNullOrEmpty(SearchArg.Text.Trim()))
            {
                MessageLabel.Text = "Enter something";
            }
            else if (int.TryParse(SearchArg.Text,out productid))
            {
                //since we are leaving this project(webapp) and going to another project (BLL) user friendly error handling is required
                try
                {
                    //create an instance of the appropriate BLL class
                    ProductController sysmgr = new ProductController();
                    //issue your request to the appropriate BLL class
                    //method
                    Product result = sysmgr.Product_Get(int.Parse(SearchArg.Text));
                    //test results to see if anything was found
                    //null; product id not foud
                    //otherwise Product instance exists
                    if (result == null)
                    {
                        MessageLabel.Text = "No data found for supplied id";
                    }
                    else
                    {
                        ProductID.Text = result.ProductID.ToString();
                        ProductName.Text = result.ProductName;
                    }
                }
                catch (Exception ex)
                {

                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            SearchArg.Text = "";
            ProductID.Text = "";
            ProductName.Text = "";
        }
    }
}