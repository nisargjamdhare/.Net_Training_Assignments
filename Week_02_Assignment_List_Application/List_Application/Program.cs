using System;
using System.Collections.Generic;

namespace List_Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choice;
            List<string> list = new List<string>();

            Console.WriteLine("Welcome TO the List Application : - ");
            do
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("!! Enter your choice ");
                Console.WriteLine("!! Press 1 : ADD_LIST ");
                Console.WriteLine("!! Press 2 : Display_List ");
                Console.WriteLine("!! Press 3 : Update_List ");
                Console.WriteLine("!! Press 4 : Delete_List ");
                Console.WriteLine("!! Press 5 : Exit ");
                Console.WriteLine("--------------------------------");

                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("---------------------------------");

                switch (choice)
                {
                    // Case for Adding Item
                    case 1:
                        Console.WriteLine("Enter Item To Add In The List :");
                        list.Add(Console.ReadLine());
                        Console.WriteLine(" YEY !! Item Added Sucessfully !! ");
                        break;

                    // Case To Display All List_Item
                    case 2:
                        Console.WriteLine("Items In The List:");

                        // For Loop is Just Use For Displaying The Index With the Items For User_Understanding

                        for (int j = 0; j < list.Count; j++)
                        {
                            Console.WriteLine( j+ " "+list[j]);
                        }
                       /* foreach (string s in list)
                        {
                            Console.WriteLine(s);
                        }*/
                        break;

                    // Case To Update List_Item 
                    case 3:
                        Console.WriteLine("Enter index you want update:");
                        int i = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter updated List_Item:");
                        list[i] = Console.ReadLine();
                        Console.WriteLine(" YEY !! Item Updated Sucessfully !! ");
                        break;

                    //Case For Remove List_Item 
                    case 4:
                        Console.WriteLine("Enter the Index of Item to Remove:");
                        int indexToRemove = Convert.ToInt32(Console.ReadLine());
                        list.RemoveAt(indexToRemove);
                        Console.WriteLine("Opps !! List Item Deleted !!");
                        break;

                    case 5:
                        Console.WriteLine("Exit SucessFull");
                        break;

                    default:
                        Console.WriteLine("Please Choose Correct Option !! ");
                        break;
                }
            } while (choice != 5);
        }
    }
}
