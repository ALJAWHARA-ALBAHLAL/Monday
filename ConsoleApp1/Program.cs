using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;

namespace Monday
{
    // Generic, ToString, GetHashCode, Equals, Convert.ToString, System String, System Text, partial class, ....., ......, ....., ....., ......., ......
    internal class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Generic<int>(10));
            Console.WriteLine(Generic<string>("s"));
            Console.WriteLine(Generic<double>(10.8));
            Console.WriteLine(Generic<bool>(true));

            Customer c  = new Customer();   
            c.name = "Aljawhara";
            c.lastName ="Albahlal";
            Console.WriteLine(c.ToString());
            //Convert.ToString -- print string not only object, like null  ((Handels null))
            //ToString -- Cant print nul obj, an exception will occured ((Throw an Exception))

            Customer c2 = c;
            Console.WriteLine(c.Equals(c2)); //compare the values
            Console.WriteLine(c==c2); //compare the refrence

            Console.WriteLine(c.GetHashCode()); 
            Console.WriteLine(c2.GetHashCode()); 
            
            Console.ReadLine();
        }
        public static T Generic<T> (T t) {
            return t;
        }//
    }

    public class Customer
    {
        public string name { get; set; }
        public string lastName { get; set; } // System.String Immutable, every time we need to modify this string will create object, low performance

        StringBuilder s = new StringBuilder("hi"); //System.Text Mutibule, every time we need to modify this string will modify same object, high performance

        public override string ToString() //by defult string print namespace with class name 
        {
            return this.name + " " + this.lastName;
        }

        public override bool Equals(object obj) // compare values in objects 
        {
            if(obj == null) return false;
            if(obj is Customer) return true;
            return this.name == ((Customer)obj).name && this.lastName == ((Customer)obj).lastName;  
        }

        public override int GetHashCode() // unique for each instance lm
        {
            return base.GetHashCode();
        }
    }

    public class Student
    {
        //partial class, splitting class into phyiscal files usng partial key word
        private string _Fname;
        private string _Lname;
    
        public string Fname { get => _Fname; set => _Fname = value; }
        public string Lname { get => _Lname; set => _Lname = value; }

        public string FullName() { 
        return _Fname+ " " + _Lname;
        }
    }
}


public partial class PartialStudent1 { // AS one class in  same namespace with Student
    public string FullName()
    {
        //  return _Fname + " " + _Lname; // in same namespace the eror will not occur
        return "";
    }

}
public partial class PartialStudent2 {  // AS one class in compiler time
    public string FullName() { 
        //  return _Fname + " " + _Lname;  // in same namespace the eror will  occur
        return "";
    }// Partial file is sprated physical, not in a same file 
}
