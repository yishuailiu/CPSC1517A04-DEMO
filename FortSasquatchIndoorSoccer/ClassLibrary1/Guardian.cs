using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FSISSystem.Yliu.Data
{
    [Table("Guardian")]
    public class Guardian
    {

        [Key]
        public int GuardianID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmergencyPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return FirstName + "," + LastName; }
        }
    }
}
