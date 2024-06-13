namespace Work_With_DateTime_Array_List_ENUM
{
    public class Program
    {
        static void Main(string[] args)
        {
            // To Get Current Time And Date
            DateTime datetime = DateTime.Now;

            // To Get Current Time only 
            TimeOnly timeOnly = TimeOnly.FromDateTime(DateTime.Now);
            // To Get Current Date Only
            DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);

            Console.WriteLine("Current Date&Time :-" + datetime);
            Console.WriteLine("Current Time :-" + timeOnly);
            Console.WriteLine("Current Date :-" + dateOnly);



            //***************** Array ****************
           /* // Array is a collection of similar data Type Which is stored in Contigious memory location

            // Array Syntax
            int[] Math_marks = new int[5] { 50, 75, 91, 92, 95 };

            int length = Math_marks.Length;
            Console.WriteLine(length);

            int Math_Score = Math_marks[0]; // 0 rool no student marks
            Console.WriteLine(Math_Score);

            // TO access all the elements
            foreach (int i in Math_marks)
            {
                Console.WriteLine(i);
            }

            // Taking array Input from User 
            Console.WriteLine("Enter the Size Of an Array :- ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] subject = new string[n]; 

            for(int i= 0; i<subject.Length; i++)
            {
                subject[i] = Console.ReadLine();
            }

            //  matghod to print array
            void print(string[] arr)
            {
                foreach (string i in arr)
                {
                    Console.WriteLine(i);
                }
            }
            print(subject);
            Console.WriteLine(Array.BinarySearch(subject, "Math"));*/

            // ********************* List *********************
            Console.WriteLine("********************* List *********************");

            List<int> ll = new List<int>();

            ll.Add(1);
            ll.Add(2);
            ll.Add(3);
            ll.Add(4);  

            int size_Of_List = ll.Count;
            Console.WriteLine("Size of List "+size_Of_List);
            int capacity = ll.Capacity;
            Console.WriteLine("Capacity of List :- "+ capacity);

            Console.Write(ll.Contains(4));
            foreach (int i in ll)
            {
                Console.WriteLine(i);
            }

            /* **************** Working with ENUMS   *********************                      */

            Console.WriteLine(cars.audi + "is car at number #" + (int)cars.audi);

            Console.WriteLine(cars.Mustang + " is a car at number " + (int)cars.Mustang);


            Console.ReadLine();
        }
        enum cars
        {
            audi ,
            BMW,
            Mustang,
            ford,
            toyota,
            supra,
            alto
        }
    }
}
