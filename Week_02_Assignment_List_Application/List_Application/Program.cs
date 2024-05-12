using System;
using System.Collections.Generic;
using System.ComponentModel;

class Task
{
    public string Title { get; set; }
    public string Description { get; set; } 
}

namespace List_Application
{
   
    public class Program
    {
        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            int choice;
           

            Console.WriteLine("Welcome TO the List Application Created By Nisarga Jamdhare : - ");
            do
            {
                Console.WriteLine("\n Task List Application Menu \n");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("!! Press 1 : Create ");
                Console.WriteLine("!! Press 2 : Display ");
                Console.WriteLine("!! Press 3 : Update ");
                Console.WriteLine("!! Press 4 : Delete ");
                Console.WriteLine("!! Press 5 : Exit ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("!! Enter your choice \n\n");

                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("---------------------------------");

                switch (choice)
                {
                    // Case for Create Task
                    case 1:
                        Create();
                        break;

                    // Case To Display All Tasks
                    case 2:
                        Display();
                        break;

                    // Case To Update All Tasks 
                    case 3:
                        Update();
                        break;

                    //Case For Remove Task 
                    case 4:
                        Delete();
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

        static void Create()
        {
            Task newTask = new Task();

            Console.WriteLine("Enter Task Title:- ");
            newTask.Title = Console.ReadLine();

            Console.WriteLine("Enter Task Description:- ");
            newTask.Description = Console.ReadLine();

            tasks.Add(newTask);
            Console.WriteLine(" \n Yey !! Task Created!!");
        }
        static void Display()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Sorry!! \n No Tasks Available.");

            }
            else
            {
                Console.WriteLine("Your Task List:- ");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"Title: {task.Title} \n - Description: {task.Description}");
                }
            }
        }
        static void Update()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Sorry!!\nNo tasks available \n First Create the Task.");
            }
            else
            {
                Console.WriteLine("Enter Any Index to Update the task");
                int index = Convert.ToInt32(Console.ReadLine());

                if (index >= 0 && index < tasks.Count)
                {
                    Console.WriteLine("Enter New Title:- ");
                    tasks[index].Title = Console.ReadLine();

                    Console.WriteLine("Enter New  Description:- ");
                    tasks[index].Description = Console.ReadLine();

                    Console.WriteLine("Yey!! \n Your Titke and Description is Updated Successfully!!\n");
                }
                else
                {
                    Console.WriteLine("Sorry!!\n Enter Valid Index");
                }

            }
        }
        static void Delete()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Sorry!!\n Tasks List is Empty \n First Please Create the Task.");
            }
            else
            {
                
                Console.WriteLine("Enter the index Of Task To Delete the Task:- ");
                int index = Convert.ToInt32(Console.ReadLine());

                if (index >= 0 && index < tasks.Count)
                {
                    tasks.RemoveAt(index);
                    Console.WriteLine("\n Your Task Deleted!!");
                }
                else
                {
                    Console.WriteLine("Opps!!\n Enter Valid Index");
                }
            }

        }

    }
}

