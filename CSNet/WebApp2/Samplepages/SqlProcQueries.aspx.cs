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

        }
    }
}