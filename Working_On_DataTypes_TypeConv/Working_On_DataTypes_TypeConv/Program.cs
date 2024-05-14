using System;

namespace Working_On_DataTypes_TypeConv
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ************************* Working with String ****************************************
            string st = "Hello EveryOne !! My self ";
            Console.Write("\n" + st);
            string str = "nisarga Vijay Jamdhare";
            Console.Write("\n"+str);
            
            // Concatinate Two Strings 
            Console.Write( "\n"+ st + str);
            
            //Method To Reverse a String 

            void reverse(string s)
            {
                for(int i = st.Length-1; i >= 0; i--)
                {
                    Console.Write(st[i]);
                }
            }

            reverse(st);
            // method for finding string length
            int length= st.Length;
            Console.WriteLine(" \n Length of a string is " +length);
            // Method to find the substring 
            string sb = st.Substring(0, 3);
            Console.WriteLine(sb);

            //Converting string to Character Array
            char [] ch= st.ToCharArray();
            foreach(Char Ch in ch)
            {
                Console.Write(Ch);
            }

            // ********************<<Type Castring>>   char --> int --> long --> float --> Double

            Console.WriteLine("********************<<Type Castring>>   char --> int --> long --> float --> Double ");

            char c = 'a';
            int mynum = c;
            Console.WriteLine(c);
            Console.WriteLine(mynum);

            long l = mynum;
            Console.WriteLine(l);

            float f = l;
            Console.WriteLine(f);

            double d = f;
            Console.WriteLine(d);


            // ******************* User Input **************************

            Console.WriteLine("******************* User Input **************************");
            Console.WriteLine("Enter a number ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Number is :- "+n);

            Console.WriteLine("Enter your name :- ");
            string name = Console.ReadLine();
            Console.WriteLine("Your name is :- "+name);



            Console.ReadLine();
        }
    }
}
