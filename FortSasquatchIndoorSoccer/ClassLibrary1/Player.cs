using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FSISSystem.Yliu.Data
{
    [Table("Player")]
    public class Player
    {

        private char _Gender;
        private string _MedicalAlertDetails;
        [Key]
        public int PlayerID { get; set; }
        [ForeignKey]
        public int GuardianID { get; set; }
        [ForeignKey]
        public int TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = char.ToUpper(value);
            }
        }
        public string AlbertaHealthCareNumber { get; set; }
        public string MedicalAlertDetails
        {
            get
            {
                return _MedicalAlertDetails;
            }
            set
            {
                _MedicalAlertDetails = string.IsNullOrEmpty(value.Trim()) ? null : value;
            }
        }

        [NotMapped]
        public string FullName
        {
            get { return FirstName + "," + LastName; }
        }
    }

}
}
