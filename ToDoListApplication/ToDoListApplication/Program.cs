using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication
{
    public class ToDoList 
    {
        static void Main(string[] args)
        {
            //login interface ACCOUNT
            string usr = "lorweljohn24";
            string pwd = "lorwel";

            //login attempts
            int x = 0;
            for(;x < 3; x++)
            {
                Console.Write("Input your Username: ");
                string usrInput = Console.ReadLine();
                Console.Write("Input your password: ");
                string pwdInput = Console.ReadLine();

                Console.WriteLine();
                if (usrInput == usr && pwdInput == pwd)
                {
                    Console.WriteLine("Login Successfully!");
                    ToDoList.ItemList();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                //will exit after 3 wrong attempts
                if (x == 3)
                {
                    Console.WriteLine("Exiting");
                    Environment.Exit(0);
                }

            }
            
            

        }
        public static void ItemList()
        {
            //since you can't populate manually the arrays the solution i found is using the array list which is more dynamic and enables adding and removing an item from array
           ArrayList todolist = new ArrayList();

            var appRunning = true;
            //instructions about the program
            Console.WriteLine("|~~~~~~~TO DO List Application~~~~~~~|");
            Console.WriteLine("Commands to use: '-exit', '-show', '-' \n");
            todolist.Add("Breakdowns");
            todolist.Add("Work");
            todolist.Add("Mental Breakdown");
            todolist.Add("Commit Sepuku");
            Console.WriteLine(todolist[0]);
            Console.WriteLine(todolist[1]);
            Console.WriteLine(todolist[2]);
            Console.WriteLine(todolist[3]);
            //prevent exiting while not being told to exit the app
            while (appRunning == true)
            {
                Console.WriteLine("Please add a to do list item to add or a command to use");
                //process what the user types

                var input = Console.ReadLine();
                switch (input)
                {
                    //if inputted exit, the app will close
                    case string a when a.StartsWith("-exit"):
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

                    //showing the todo list using foreach
                    case string c when c.StartsWith("-show"):
                        Console.WriteLine("\n --------- TO DO LIST ---------");
                        foreach (var task in todolist)
                        {
                            Console.WriteLine(task);
                        }
                        Console.WriteLine("-----------------------\n");
                        break;

                    //add anything typed into the todolist
                    default:
                       
                        Console.WriteLine(input + " has been added!");
                        todolist.Add(input);
                        break;


                }
            }

        }
       
    }
}