using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OutputMessage.Text = "";
            //this event method is executed EACH and EVERY time this page is processed
            //this event method is executed BEFORE ANY EVENT method is processed

            //this page is an excellent place to do page initialization of your controls
            //there is a property to test for post back of your page called Page.IsPostBack (Razor: IsPost)
            if (!Page.IsPostBack)
            {
                //do 1st page initialization processing
                //create an intence of the Data colletion list
                DataCollection = new List<DDLClass>();

                //load the data collection with dummy data, normally this data would com from your database
                DataCollection.Add(new DDLClass(1, "Comp1008"));
                DataCollection.Add(new DDLClass(2, "Cpsc1517"));
                DataCollection.Add(new DDLClass(3, "Dmit2018"));
                DataCollection.Add(new DDLClass(4, "Dmit1508"));

                //to sort List<T> use the method .Sort()
                //(x,y) x and y represent any two instances in your list at any time.
                // x.firld compared to y.field : ascending
                // y.field compared to x.field : desending
                DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

                //setup the dropdown list

                //a, assign your data to the control
                CollectionList.DataSource = DataCollection;
                //b, assign the data list field names to the approriate control properties
                //  i), .DatavalueField this is the value of the selection
                //  ii) .DataTextFiled this is the display of the selection optio
                CollectionList.DataValueField = "ValueField";
                CollectionList.DataTextField = nameof(DDLClass.DisplayField);
                //bind the data to the control for show
                CollectionList.DataBind();

                //promt
                //one can adda  prompt to the start of the BOUND controllist
                //one will use the index 0 to position the prompt
                CollectionList.Items.Insert(0, "plese select");
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            //this is method is executed when the submit button is pressed
            //this method is concerned with the actions needed for the submit button

            //to access the data of a control, you use the appropriate 
            //  control(object) property (get,set) and access technique

            //for TextBox, Label, Literal use .Text
            //for a list(DropDownList, RadioButtonlist) use one of .selectedIndex the physical location of the item in the list
            //  .selectdValue the assoicated adata value of the item in the list
            //  .SelectedItem the assoicateddata display text of the item in the list
            // for boolean controls (RadioButton, Checkbox) use  .Checked

            //most controls will use strings, expect for boolean controls
            
            string submitchoice = TextBoxNumericChoice.Text;
            //sample validation
            if (string.IsNullOrEmpty(submitchoice))
            {
                OutputMessage.Text = "Enter a course choice of 1 to 4";
            }
            else
            {
                //set the radiobutton list using the entered data value
                //property:.SelectedValue
                RadioButtonListChoice.SelectedValue = submitchoice;

                if (submitchoice.Equals("2")||submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }
                //position in the dropdownlist
                //use the entered datavalue to position
                //property: .SelectedValue
                CollectionList.SelectedValue = submitchoice;

                //demonstrate the 3 different access techniques for a list
                //output will be ato a label(appearance will be read only)
                DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + "has a value of " + CollectionList.SelectedValue;

            
            }
        }

        //this static variable is being used in this demo example
        //  to hang unto the dummy data.
        //if the data is coming from database, we dont need this. 
        public static List<DDLClass> DataCollection;

        protected void listbutton_Click(object sender, EventArgs e)
        {
            if (CollectionList.SelectedIndex == 0)
            {
                OutputMessage.Text = "Select a course to view";
            }
            else
            {
                string submitchoice = CollectionList.SelectedValue;
                TextBoxNumericChoice.Text = submitchoice;
                RadioButtonListChoice.SelectedValue = submitchoice;
                DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + "has a value of " + CollectionList.SelectedValue;
                if (submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }
            }
        }
    }
}