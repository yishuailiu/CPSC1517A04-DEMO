using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthWindSystem.BLL;
using NorthWindSystem.Data;


namespace WebApp.SamplePages
{
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear old messages
            MessageLabel.Text = "";

            //the dropdownlist(ddl)control will be loaded with data from the database
            //consideration needs to be given to the data as to it change frequence
            //if your data does not change frequently then you can consider loading on page load
            if (!Page.IsPostBack)
            {
                //use userfriendly error handling
                try
                {
                    //create and connect to the appropriate BLL class
                    CategoryController sysmgr = new CategoryController();
                    //issue the request to the appropriate BLL class method and capture results

                    List<Category> datainfo = sysmgr.Category_List();

                    //optionally: sort the results

                    datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                    //attach data source collection to ddl

                    CategoryList.DataSource = datainfo;

                    //set the ddl DataTextField and DataValue Field Properties
                    CategoryList.DataTextField = nameof(Category.CategoryName);
                    CategoryList.DataValueField = "CategoryID";

                    //physically bind the data to the ddl control and lastely 
                    CategoryList.DataBind();
                    //optionally: add a propmt to the ddl control
                    CategoryList.Items.Insert(0, "select...");
                }
                catch (Exception ex)
                {

                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //ensure a selection was made
            if (CategoryList.SelectedIndex == 0)
            {
                //no selection: message to user
                MessageLabel.Text = "Select something please";
            }
            else
            {
                //yes selection: process lookup
                try
                {
                    //create and connect to BLL class
                    ProductController sysmgr = new ProductController();
                    //issue request for loop up to appropriate BLL class method and capture resultss
                    List<Product> datainfo = sysmgr.Product_GetByCategory(int.Parse(CategoryList.SelectedValue));
                    //check result(.Count() == 0)
                    if (datainfo.Count() == 0)
                    {
                        //no records: message to user
                        MessageLabel.Text = "no data found for select category";
                        //you may wish to remove from the display any old data
                        CategoryProductList.DataSource = null;
                        CategoryProductList.DataBind();
                    }
                    else
                    {
                        //yes record: display data
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }


                }
                catch (Exception ex)
                {
                    //error handling 
                    MessageLabel.Text = ex.Message;
                }          

            }



            //yes selection: process lookup

            //error handling 

            //create and connect to BLL class

            //issue request for loop up to appropriate BLL class method and capture resultss
            //check result(.Count() == 0)
            //no records: message to user
            //yes record: display data
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();

        }
    }
}