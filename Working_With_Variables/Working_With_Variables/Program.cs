using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Working_With_Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ************* Working With Variables *******************
            //Int Variable 
            int a = 15;
            int b = 20;
            int result = a + b;
            Console.WriteLine(result);

            // Double Datatype 
            double d = 12.5555555D;
            Console.WriteLine(d);

            // long Variable
            long l1 = 1231344641531351351;
            long l2 = 3446846846834683;
            Console.WriteLine("\n" + (l1 + l2));

            //Float variable
             float add()
            {
                float f1 = 12.20F;
                float f2 = 12.56F;
                return f1 + f2;
            }

            char ch = 'a';
            Console.WriteLine(ch);
            Console.WriteLine("Size of a Char Variable : - " + sizeof(char));
            Console.WriteLine(add());


            // Boolean Datatype
            bool isCSharpFun = true;

            Console.Write("isCSharpFun" + isCSharpFun);


            // *****************  Operators  *****************

            int num1 = 20;
            int num2 = 5;

            // add 
            Console.WriteLine(" \n Addition is "+(num1 + num2));

            // subtraction 
            Console.WriteLine(" \n Subtraction is "+ (num1 - num2));

            // Multiplication Opr
            Console.WriteLine(" \n Multiplication is  "+num1 * num2);

            // Division Opr
            Console.WriteLine(" \n Division is  "+num1 / num2);
            Console.WriteLine("\n");
            // inCrement Decrement 
            Console.WriteLine("Before Increment " + num1);
            num1++;
            Console.WriteLine( "After Increment" + num1);

            Console.WriteLine("Before Decrement " + num1);
            num1--;
            Console.WriteLine("After Decrement" + num1);

            // Wap to find the reminder 

            int x = 123;
            int y = 12;
            Console.WriteLine("Reminder is :- "+ 123 % 12);



            Console.ReadLine();
        }
    }
}
