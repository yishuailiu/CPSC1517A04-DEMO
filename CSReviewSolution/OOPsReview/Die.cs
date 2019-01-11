using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Die
    {
        //Data members
        //usually private
        private int? _Side;//? after datatype means it can be null value or an int
        private string _Color;
        private int _FaceValue;

        //properties
        //properties are responsible to assignming and retrieving data from/to their associated data member, 
        //retreiving data from a data member uses the get{}, assigning data to data member using the set{}.  
        // properties need to be exposed to outside users
        //properties will have a return datatype BUT no parameter list

        //fully implemeted property
        //fully implemented property has a defined data member that the developer can directly access.

        public int? Side
        {
            get
            {
                //returns data of a specific datatype
                return _Side;
            }
            set
            {
                //assigns a supplied value to the data member
                if (value >= 6 && value <= 20)
                {
                    _Side = value;
                }
                else
                {
                    throw new Exception("wrong, cant be" + value.ToString() + "sided");
                }
                
            }
        }

        //auto implemented property
        //no data member definition
        //the data member is internally created for you
        //the data member datatype is take from your return datatype
        //  specified on the property header
        //auto implemeted properties are usually used when there is no need to internal validation
        //access to a value managed by an auto implemented property NUST be done via the property
        public int FaceValue { get; set; }



    }
}
