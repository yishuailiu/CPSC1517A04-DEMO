using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        //if we had a database , the data would be stored there
        // using this static List<T> is only done in this example because we have no database
        public static List<Entry> entryCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                entryCollection = new List<Entry>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            

            //validation
            // required: ensures that the user has supplied a value
            // range: checks a suppliedvalue against a set lower-upper range of numbers or characters
            // RegularExperession: checks a supplied value against a given pattern such as postal code email phone.ect
            //Custom: is a call to a server side program validation method
            //Compare: i) can be used to compare a value to a specific data type
            //          ii) can be used to compare a valve to a specified constant value( == != >= <=)
            //          ii) can be used to compare a value in one control to a value in another control(password)
            //validation message: statc, dynamic, none

            if (Page.IsValid)
            {
                if (Terms.Checked)
                {
                    string firstname = FirstName.Text;
                    string lastname = LastName.Text;
                    string streetaddress1 = StreetAddress1.Text;
                    string streetaddress2 = StreetAddress2.Text;
                    string city = City.Text;
                    string province = Province.SelectedValue;
                    string postalcode = PostalCode.Text;
                    string emailaddress = EmailAddress.Text;
                    bool termcheck = Terms.Checked;
                    string checkanswer = CheckAnswer.Text;

                    entryCollection.Add(new Entry(firstname, lastname, streetaddress1, streetaddress2, city, province, postalcode, emailaddress));

                    EntryList.DataSource = entryCollection;
                    EntryList.DataBind();
                }
                else
                {
                    Message.Text = "You have to agree the term.";
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            Province.SelectedIndex = -1;
            PostalCode.Text = "";
            EmailAddress.Text = "";
            Terms.Checked = false;
            CheckAnswer.Text = "";

            //clear grid view
        }
    }
}