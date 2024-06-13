using System;
using System.Collections.Generic;

namespace Inventory_Management_System
{
    class Item
    {
        public int id { get; }
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

        public Item(int id, string name, double price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public string getItemData()
        {
            string data = $"ID: {id}, Item Name: {name}, Price: {price}, Quantity: {quantity}";
            return data;
        }

        public class Inventory
        {
            private List<Item> items;

            public Inventory()
            {
                items = new List<Item>();
            }

            public void AddItem(Item item)
            {
                items.Add(item);
                Console.WriteLine("Item added successfully in the Inventory.");
            }

            public void ShowAllItems()
            {
                if (items.Count == 0)
                {
                    Console.WriteLine("Opps! There are no items present in the inventory.");
                }
                else
                {
                    foreach (Item item in items)
                    {
                        Console.WriteLine(item.getItemData());
                    }
                }
            }

            public Item GetItemById(int id)
            {
                foreach (Item item in items)
                {
                    if (item.id == id)
                    {
                        return item;
                    }
                }
                return null;
            }

            public void UpdateItem(int id, string name, double price, int quantity)
            {
                Item item = GetItemById(id);
                if (item != null)
                {
                    item.name = name;
                    item.price = price;
                    item.quantity = quantity;
                    Console.WriteLine("Item updated successfully.");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }

            public void RemoveItem(int id)
            {
                Item item = GetItemById(id);
                if (item != null)
                {
                    items.Remove(item);
                    Console.WriteLine("Item removed successfully.");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }

            // Method to update only the name of an item
            public void UpdateItemName(int id, string newName)
            {
                Item item = GetItemById(id);
                if (item != null)
                {
                    item.name = newName;
                    Console.WriteLine("Item name updated successfully.");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }

            // Method to update only the price of an item
            public void UpdateItemPrice(int id, double newPrice)
            {
                Item item = GetItemById(id);
                if (item != null)
                {
                    item.price = newPrice;
                    Console.WriteLine("Item price updated successfully.");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }

            // Method to update only the quantity of an item
            public void UpdateItemQuantity(int id, int newQuantity)
            {
                Item item = GetItemById(id);
                if (item != null)
                {
                    item.quantity = newQuantity;
                    Console.WriteLine("Item quantity updated successfully.");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }
        }

        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Show All Items");
                Console.WriteLine("3. Find Item By ID");
                Console.WriteLine("4. Update All Details of An Item");
                Console.WriteLine("5. Update Item Name Only");
                Console.WriteLine("6. Update Item Price Only");
                Console.WriteLine("7. Update Item Quantity Only");
                Console.WriteLine("8. Remove Item");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");
                Console.WriteLine(" \n********************************************");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddNewItem(inventory);
                        break;
                    case 2:
                        inventory.ShowAllItems();
                        break;
                    case 3:
                        GetItemById(inventory);
                        break;
                    case 4:
                        UpdateItem(inventory);
                        break;
                    case 5:
                        UpdateItemName(inventory);
                        break;
                    case 6:
                        UpdateItemPrice(inventory);
                        break;
                    case 7:
                        UpdateItemQuantity(inventory);
                        break;
                    case 8:
                        RemoveItem(inventory);
                        break;
                    case 9:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddNewItem(Inventory inventory)
        {
            Console.Write("Enter Item ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Item Price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Item Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Item item = new Item(id, name, price, quantity);
            inventory.AddItem(item);
        }

        static void GetItemById(Inventory inventory)
        {
            Console.Write("Enter Item ID to find: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Item item = inventory.GetItemById(id);
            if (item != null)
            {
                Console.WriteLine(item.getItemData());
            }
            else
            {
                Console.WriteLine("Item not found. Enter Valid Id ");
            }
        }

        static void UpdateItem(Inventory inventory)
        {
            Console.Write("Enter Item ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter New Price: ");
            double newPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter New Quantity: ");
            int newQuantity = Convert.ToInt32(Console.ReadLine());

            inventory.UpdateItem(id, name, newPrice, newQuantity);
        }

        static void UpdateItemName(Inventory inventory)
        {
            Console.Write("Enter Item ID to update the name: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine();

            inventory.UpdateItemName(id, newName);
        }

        static void UpdateItemPrice(Inventory inventory)
        {
            Console.Write("Enter Item ID to update the price: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Price for Item : ");
            double newPrice = Convert.ToDouble(Console.ReadLine());

            inventory.UpdateItemPrice(id, newPrice);
        }

        static void UpdateItemQuantity(Inventory inventory)
        {
            Console.Write("Enter Item ID to update the quantity: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Quantity: ");
            int newQuantity = Convert.ToInt32(Console.ReadLine());

            inventory.UpdateItemQuantity(id, newQuantity);
        }

        static void RemoveItem(Inventory inventory)
        {
            Console.Write("Enter Item ID to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());
            inventory.RemoveItem(id);
        }
    }
}
