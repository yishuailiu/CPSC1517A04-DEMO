﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class GridViewCollection
    {
        public string Fullname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FullorPartTime { get; set; }
        public string Jobs { get; set; }

        public GridViewCollection(string fullname, string emailaddress,string phonenumber,string fullorparttime,string jobs)
        {
            Fullname = fullname;
            EmailAddress = emailaddress;
            PhoneNumber = phonenumber;
            FullorPartTime = fullname;
            Jobs = jobs;
        }
        public GridViewCollection()
        {

        }
    }
}