using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApplication
{
    public class ToDoList 
    {
        static void Main(string[] args)
        {
            ToDoList.ItemList();
        }
        public static void ItemList()
        {
            var todolist = new List<string>();
            var appRunning = true;
            //instructions about the program
            Console.WriteLine("TO DO List Application");
            Console.WriteLine("Commands to use: '-exit', '-show', '-' \n");
            //prevent exiting while not being told to exit the app
            while (appRunning == true)
            {
                Console.WriteLine("Please add a to do list item to add or a command to use");
                //process what the user types

                var input = Console.ReadLine();
                switch (input)
                {
                    //if inputted exit, the app will close
                    case string a when a.StartsWith("-Exit"):
                        appRunning = false;
                        break;

                    // removing a item in the todolist remove it
                    case string b when b.EndsWith("-"):
                        var endIndex = b.IndexOf("-");
                        var item = b.Substring(0,endIndex);
                        if (todolist.Contains(item))
                        {
                            todolist.Remove(item);
                            Console.WriteLine("Removed {0} \n", item);
                        }
                        else
                        {
                            Console.WriteLine("{0} is not currently in the list, it cannot be removed", item);
                        }
                        break;

                    //showing the todo list
                    case string c when c.StartsWith("-show"):
                        Console.WriteLine("\n --------- TO DO LIST ---------");
                        foreach (var task in todolist)
                        {
                            Console.WriteLine(task);
                        }
                        Console.WriteLine("--------------------\n");
                        break;

                    //add anything typed into the todolist
                    default:
                        todolist.Add(input);
                        break;

                }
            }
        }
    }
}