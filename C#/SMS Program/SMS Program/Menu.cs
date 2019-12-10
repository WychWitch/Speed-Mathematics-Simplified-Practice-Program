using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Menu
{
    public string[] Options { get; set; }
    public string Question { get; set; }

    public Menu(string question, string[] options)
    {
        Options = options;
        Question = question;
    }

    public int Select()
    {
        int count = 0;
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

            if (inputInt >= 0 && inputInt < Options.Length)
            {
                Console.WriteLine("************************");
            }
            else
            {
                Console.WriteLine("Enter a valid option.");
            }

        } while (inputInt < 0 || inputInt >= Options.Length);

        return inputInt;
    }
}

