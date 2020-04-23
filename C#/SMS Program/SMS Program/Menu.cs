using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Menu
{
    public List<string> Options { get; set; }
    public string Question { get; set; }
    public string Prefix { get; set; }

    public Menu(string question, List<string> options)
    {
        Options = options;
        Question = question;
        Options.Add("Quit");
    }

    public Menu(string prefix, string question, List<string> options)
    {
        Prefix = prefix;
        Options = options;
        Question = question;
        Options.Add("Quit");
    }

    public int Select()
    {
        int count = 0;
        if (Prefix != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{Prefix}\n");
            Console.ResetColor();
        }
        foreach (string option in Options)
        {
            Console.Write($"{count}) {option} \n");
            count++;
        }
        Console.Write($"\n{Question} :");

        int inputInt = -1;
        do
        {
            string input = Console.ReadLine();
                
            try
            {
                inputInt = int.Parse(input);
            } catch (Exception)
            {
                Console.WriteLine("Please enter a valid Int.");
            }
            finally
            {

            }

            if (inputInt >= 0 && inputInt < Options.Count() - 1)
            {
                Console.WriteLine("************************");
            }
            else if (inputInt == Options.Count() - 1)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Enter a valid option.");
            }

        } while (inputInt < 0 || inputInt >= Options.Count());

        return inputInt;
    }
}

