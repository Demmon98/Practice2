using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static Model model = new Model();
        static UndergroundLine currObj = model.UndergroundLines.FirstOrDefault();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Change what do u want:\n" +
                    "1 - add new underground line\n" +
                    "2 - change curr underground line\n" +
                    "3 - delete curr underground line\n" +
                    "4 - find underground line on name\n" +
                    "5 - exit");

            while (true)
            {
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case ("1"):
                        currObj = new UndergroundLine("newItem", new List<Station>() { new Station(), new Station(), new Station() }, 1);
                        model.UndergroundLines.Add(currObj);

                        model.SaveChanges();

                        Console.WriteLine("Item added!\n");
                        Console.WriteLine(currObj);
                        break;
                    case ("2"):
                        if (currObj != null)
                        {
                            currObj.Name = "ChangedName";
                            currObj.SomeProp++;

                            Console.WriteLine($"Object name changed on: {currObj.Name}!\n");

                            model.SaveChanges();
                        }
                        else
                            Console.WriteLine("Invalid object");
                        break;
                    case ("3"):
                        model.UndergroundLines.Remove(currObj);

                        Console.WriteLine("Item deleted!\n");
                        break;
                    case ("4"):
                        Console.WriteLine("Enter the name:");
                        string name = Console.ReadLine();

                        currObj = model.UndergroundLines.FirstOrDefault(x => x.Name == name);

                        if (currObj != null)
                            Console.WriteLine(currObj);
                        else
                            Console.WriteLine("Invalid object");
                        break;
                    case ("5"):
                        goto Exit;
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
            }
            Exit:;
        }
    }
}
