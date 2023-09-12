using System;

namespace Exercise_2
{
    public class Exercise2
    {
        
        public Exercise2()
        {

            // Difference between object.Equals(),"==" operation and object.ReferenceEquals()

            // The Equals() method compares the contents of a string by value
            // (==) is the comparison operator it compares the reference

            // in the following example 
            // a string variable is assigned to another string variable so they are
            // refferring to the same identity and both have the same content by 
            // referenceso we get True

            string Name = "Pranto";
            string RealName = Name;
            
            Console.WriteLine("== operator result is: {0}", Name == RealName);
            Console.WriteLine("Equals() result is: {0}", Name.Equals(RealName));

            // In the 2nd example Both are form different reference so 
            // "==" is giving us False But the contents are same 
            // so Eeuals method is giving us true
            Object FirstName = "Pranto";
            char[] arr = {'P', 'r', 'a', 'n', 't', 'o' };
            Object MyName = new string(arr);
            Console.WriteLine("== operation result is: {0}", FirstName == MyName);
            Console.WriteLine("Equals method result is: {0}", MyName.Equals(FirstName));

            // Object.ReferenceEquals() Method is used to determine whether the specified 
            // object instance are the same instence or not. This method cannot be
            // Overridden
            Object a1 = "pranto";
            Object a2 = "pranto";
            bool ckeck = Object.ReferenceEquals(a1, a2);
            Console.WriteLine(ckeck);
          


            a1 = null;
            a2 = "NULL";
            ckeck = Object.ReferenceEquals(a1, a2);
            Console.WriteLine(ckeck);
        }
    }
}
