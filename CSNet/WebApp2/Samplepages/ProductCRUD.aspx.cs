using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using NorthWindSystem.BLL;
using NorthWindSystem.Data;
using NorthwindSystem.BLL;
using NorthwindSystem.Data;

namespace WebApp.NorthwindPages
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();

            if (!Page.IsPostBack)
            {
                BindProductList();
                BindSupplierList();
                BindCategoryList();
            }
        }

        protected void BindProductList()
        {
            try
            {
                ProductController sysmgr = new ProductController();
                List<Product> datainfo = sysmgr.Product_List();
                datainfo.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                ProductList.DataSource = datainfo;
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, "..select");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindSupplierList()
        {
            try
            {
                SupplierController sysmgr = new SupplierController();
                List<Supplier> datainfo = sysmgr.Supplier_List();
                datainfo.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));
                SupplierList.DataSource = datainfo;
                SupplierList.DataTextField = nameof(Supplier.CompanyName);
                SupplierList.DataValueField = nameof(Supplier.SupplierID);
                SupplierList.DataBind();
                SupplierList.Items.Insert(0, "..select");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindCategoryList()
        {
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> datainfo = sysmgr.Category_List();
                datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = datainfo;
                CategoryList.DataTextField = nameof(Category.CategoryName);
                CategoryList.DataValueField = nameof(Category.CategoryID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0, "..select");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        //use this method to discover the inner most error message.
        //this rotuing has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (ProductList.SelectedIndex == 0)
            {
                errormsgs.Add("select a product");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    ProductController sysmgr = new ProductController();
                    Product result = sysmgr.Product_Get(int.Parse(ProductList.SelectedValue));
                    ProductID.Text = result.ProductID.ToString();
                    ProductName.Text = result.ProductName;
                    SupplierList.SelectedValue = result.SupplierID.ToString();
                    CategoryList.SelectedValue = result.CategoryID.ToString();
                    QuantityPerUnit.Text = result.QuantityPerUnit.ToString();
                    UnitPrice.Text = result.UnitPrice.ToString();
                    UnitsInStock.Text = result.UnitsInStock.ToString();
                    UnitsOnOrder.Text = result.UnitsOnOrder.ToString();
                    ReorderLevel.Text = result.ReorderLevel.ToString();
                    Discontinued.Checked = result.Discontinued;
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).Message);
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                    
                }            

            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ProductID.Text = "";
            ProductName.Text = "";
            SupplierList.SelectedIndex = 0;
            CategoryList.SelectedIndex = 0;
            QuantityPerUnit.Text = "";
            UnitPrice.Text = "";
            UnitsInStock.Text = "";
            UnitsOnOrder.Text = "";
            ReorderLevel.Text = "";
            Discontinued.Checked = false;
            Message.DataSource = null;
            Message.DataBind();
        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            //execute your form validation
            //if (Page.IsValid)
            //{
            //any logic validation on covered by form validation, for this example ,we assume thatthe category ID and supplier ID are needed
            if (SupplierList.SelectedIndex ==0)
            {
                errormsgs.Add("Select a supplier");
            }
            if (CategoryList.SelectedIndex == 0)
            {
                errormsgs.Add("select a category");
            }
            if (errormsgs.Count() >0 )
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                //create an instance of <T>
                //extract data from ofrm and load <T>
                //DbConnectionInfo to appropriate BLL class
                //issue a call to the appropriate BLL method passing the intance of <T>
                //handle the results
                try
                {
                    Product item = new Product();
                    item.ProductName = ProductName.Text;
                    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    item.CategoryID = int.Parse(SupplierList.SelectedValue);
                    item.QuantityPerUnit = string.IsNullOrEmpty(QuantityPerUnit.Text.Trim()) ? null : QuantityPerUnit.Text;
                    if (string.IsNullOrEmpty(UnitPrice.Text.Trim()))
                    {
                        item.UnitPrice = null;
                    }
                    else
                    {
                        item.UnitPrice = decimal.Parse(UnitPrice.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(UnitsInStock.Text.Trim()))
                    {
                        item.UnitsInStock = null;
                    }
                    else
                    {
                        item.UnitsInStock = Int16.Parse(UnitsInStock.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(UnitsOnOrder.Text.Trim()))
                    {
                        item.UnitsOnOrder = null;
                    }
                    else
                    {
                        item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(ReorderLevel.Text.Trim()))
                    {
                        item.ReorderLevel = null;
                    }
                    else
                    {
                        item.ReorderLevel = Int16.Parse(ReorderLevel.Text.Trim());
                    }
                    item.Discontinued = false;
                    ProductController sysmgr = new ProductController();
                    int newProductID = sysmgr.Product_Add(item);
                    errormsgs.Add(ProductName.Text + " has been added to database with id of" + newProductID.ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-successs");

                    //refresh of the web page/web controls
                    //display the new product id in its field
                    ProductID.Text = newProductID.ToString();
                    BindProductList();
                    ProductList.SelectedValue = ProductID.Text;
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }


            }


            //}
        }

        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            //execute your form validation
            //if (Page.IsValid)
            //{
            //any logic validation on covered by form validation, for this example ,we assume thatthe category ID and supplier ID are needed
            if (SupplierList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a supplier");
            }
            if (CategoryList.SelectedIndex == 0)
            {
                errormsgs.Add("select a category");
            }
            //on the update you must insure that the records's pkey value is present
            if (string.IsNullOrEmpty(ProductID.Text.Trim()))
            {
                errormsgs.Add("Pleaes select a product first.");
            }

            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                //create an instance of <T>
                //extract data from ofrm and load <T>
                //DbConnectionInfo to appropriate BLL class
                //issue a call to the appropriate BLL method passing the intance of <T>
                //handle the results
                try
                {
                    Product item = new Product();
                    item.ProductID = int.Parse(ProductID.Text.Trim());
                    item.ProductName = ProductName.Text;
                    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    item.CategoryID = int.Parse(SupplierList.SelectedValue);
                    item.QuantityPerUnit = string.IsNullOrEmpty(QuantityPerUnit.Text.Trim()) ? null : QuantityPerUnit.Text;
                    if (string.IsNullOrEmpty(UnitPrice.Text.Trim()))
                    {
                        item.UnitPrice = null;
                    }
                    else
                    {
                        item.UnitPrice = decimal.Parse(UnitPrice.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(UnitsInStock.Text.Trim()))
                    {
                        item.UnitsInStock = null;
                    }
                    else
                    {
                        item.UnitsInStock = Int16.Parse(UnitsInStock.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(UnitsOnOrder.Text.Trim()))
                    {
                        item.UnitsOnOrder = null;
                    }
                    else
                    {
                        item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(ReorderLevel.Text.Trim()))
                    {
                        item.ReorderLevel = null;
                    }
                    else
                    {
                        item.ReorderLevel = Int16.Parse(ReorderLevel.Text.Trim());
                    }
                    //on update, take tha value from control
                    item.Discontinued = Discontinued.Checked;
                    ProductController sysmgr = new ProductController();
                    int rowsAffected = sysmgr.Product_Update(item);
                    if (rowsAffected ==0)
                    {
                        errormsgs.Add(ProductName.Text + " has not been updated , rows affected is " + rowsAffected.ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                        //consider refreshing the necessary controls on your form
                        BindProductList();
                        ProductID.Text = "";
                    }
                    else
                    {
                        errormsgs.Add(ProductName.Text + " has been updated, rows affected is" + rowsAffected.ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-successs");
                        BindProductList();
                        ProductList.SelectedValue = ProductID.Text;
                    }                    
                    
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }


            }
        }

        protected void RemoveProduct_Click(object sender, EventArgs e)
        {
            
            //on the update you must insure that the records's pkey value is present
            if (string.IsNullOrEmpty(ProductID.Text.Trim()))
            {
                errormsgs.Add("Pleaes select a product first.");
            }

            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                //create an instance of <T>
                //extract data from ofrm and load <T>
                //DbConnectionInfo to appropriate BLL class
                //issue a call to the appropriate BLL method passing the intance of <T>
                //handle the results
                try
                {                  
                    
                    ProductController sysmgr = new ProductController();
                    int rowsAffected = sysmgr.Product_Delete(int.Parse(ProductID.Text.Trim()));
                    if (rowsAffected == 0)
                    {
                        errormsgs.Add(ProductName.Text + " has not been discontinued , rows affected is " + rowsAffected.ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                        //consider refreshing the necessary controls on your form
                        BindProductList();
                        ProductID.Text = "";
                    }
                    else
                    {
                        errormsgs.Add(ProductName.Text + " has been discontinued, rows affected is" + rowsAffected.ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-successs");
                        //physical option
                        //Clear_Click(sender, new EventArgs());
                        //ProductID.Text = "";
                        BindProductList();
                        //refresh ofrm controls to indicate removal
                        Discontinued.Checked = true;
                        ProductList.SelectedValue = ProductID.Text;
                    }

                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }


            }
        }
    }
}