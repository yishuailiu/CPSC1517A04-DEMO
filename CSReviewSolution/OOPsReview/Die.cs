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
        private int _Side;//? after datatype means it can be null value or an int
        private string _Color;
        private int _FaceValue;

        //class level random generator which will be an instance of the System namespace match class Random
        //static instance which will be used for ALL Die intances created by the programmer developer
        //this instance of Random will be generated once on the first Die instance that is created


        private static Random _rnd = new Random();


        //properties
        //properties are responsible to assignming and retrieving data from/to their associated data member, 
        //retreiving data from a data member uses the get{}, assigning data to data member using the set{}.  
        // properties need to be exposed to outside users
        //properties will have a return datatype BUT no parameter list

        //fully implemeted property
        //fully implemented property has a defined data member that the developer can directly access.

        public int Side //question means that this properties can be null. 
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
                    Roll();
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

        //if your auto implement properties to have validation, then a good protice is to use a private set and have the validation done somewhre/somehow else where in the class
        public int FaceValue { get; private set; }

        /*public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (value.Replace(" ","").Length == 0 )
                {
                    throw new Exception("color wrong");
                }
                else
                {
                    _Color = value;
                }
            }
        }*/

        public string Color
        {
            get
            {
                return _Color;   
            }
            set
            {
                if (/*value.Trim() == "" || value == null is the same thing to string.IsNullOrWhiteSpace or */ string.IsNullOrEmpty(value))
                {
                    throw new Exception("color wrong");
                }
                else
                {
                    _Color = value;
                }
            }
        }

        //Constructor
        //Constuctor is optional, purpose of a constructor is to ensure that when an instanceo f this class is create, it will be create within a stable state
        //ALWAYS 
        // you DO NOT call the constructor directly. It is called for you when you create an instance of the clas.
        //if you do not code a constructor then the system will assign a default value to each data member/auto implement property internal member matching the data type of that item
        // int default = 0, string default = null
        //If you DO code a constructor then you are responsible for ALL constructors for the class
        
        //syntax publc classname([list of parameters]){coding block}

        //Default Constructor
        //is similar to the system default constructor, outside user will not assign any values of the class

        
        public Die()
        {
            //if we leave this coding block empty  it would be the same as using a system default constructor
            //optionally, you can set your own default values

            _Side = 6; // via datamember
            Color = "White";//via properties
            Roll();
        }

        //Greedy Constructor
        //this constructor will allow the user of the class to pass in a set of values which willl be used at the time of instance creation to set the values of the internall datamembers/ auto properties
        public Die( int side, string color)
        {
            Side = side;
            Color = color;
            //FaceValue = facevalue; we need to have validation here
            Roll();
        }

        //Behaviours(methods)
        //are methods that can be used by the outside user to
        //a> affect values within the instance
        //b) use instance data to generate and return information

        public void Roll()
        {
            //Random can take a set of values and produce a integer value between the two values, where the minimum value is inclusive and the maximum value is exclusive.
            FaceValue = _rnd.Next(1,_Side+1);
        }
    }
}
