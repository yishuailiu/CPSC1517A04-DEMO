using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region Additional Namespace 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

//the annotation used within the .Data project will require the System.ComponentModel.DataAnnotation assembly
//this assembly is added via your References
namespace NorthWindSystem.Data
{
    //use an annotation to link this class to the appropriate SQL table
    //[Table("Products",Schema="")] schema is optional
    [Table("Products")]
    public class Product
    {
        private string _QuantityPerUnit;

        //mapping of the SQL table attributes will be to classproperties
        //identify the primary key using annotation
        //1) identity pkey on your sql table
        //[Key] pkey name must end in ID or Id, or default: [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //2) a compound pkey on your sql table
        //[Key, Column(Order=n)] where n is the natural number indicating the physical order the attribute in the Pkey
        //3) a user supplied pkey on your sql table
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(40,ErrorMessage = "Product name is limited to 40 characters")]
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        [StringLength(20, ErrorMessage = "Product name is limited to 20 characters")]
        public string QuantityPerUnit
        {
            get
            {
                return _QuantityPerUnit;
            }
            set
            {
                _QuantityPerUnit = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        [Range(0.00,double.MaxValue,ErrorMessage = "Unit price need to be greater than 0")]
        public decimal? UnitPrice { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "unit in stock need to be greater than 0")]
        public Int16? UnitsInStock { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "units on order need to be greater than 0")]
        public Int16? UnitsOnOrder { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "reorder level need to be greater than 0")]
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //sample of a computed filed on your sql
        //public decimal Total { get; set; } database dont supply data for Total
        //to annotate this property to be taken as a sql computed filed, use [Key,DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        //sample creatinga read only property that is NOT an actual field on your SQl table
        //example : FirstName LastName attributes are often combined into a single field for display purposes: FullName
        //use the NotMapped annotation to hadle this
        //[NotMapped]
        //public string FullName
        //{
        //    get FirstName + " " + LastName;
        //}
    }
}
