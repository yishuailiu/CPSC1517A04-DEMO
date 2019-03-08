﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApplication : System.Web.UI.Page
    {
        public static List<GridViewCollection> gvCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                gvCollection = new List<GridViewCollection>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string fullname = FullName.Text;
            string emailaddress = EmailAddress.Text;
            string phonenumber = PhoneNumber.Text;
            string fullorparttime = FullOrPartTime.SelectedValue;
            //process checkbox list
            // the control can be treated as a collection. one can step through the collection line by line usting the foreach loop
            string jobs = "";
            foreach (ListItem jobrow in Jobs.Items)
            {
                if (jobrow.Selected)
                {
                    jobs += jobrow.Text + " ";
                }
            }
            gvCollection.Add(new GridViewCollection(fullname, emailaddress, phonenumber, fullorparttime, jobs));

            //display the colleced gridview data records
            JobApplicantsList.DataSource = gvCollection;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FullName.Text = "";
            EmailAddress.Text = "";
            PhoneNumber.Text = "";
            FullOrPartTime.SelectedIndex = -1;
            //FullOrPartTime.ClearSelection(); Alternetive way
            Jobs.ClearSelection();
        }
    }
}