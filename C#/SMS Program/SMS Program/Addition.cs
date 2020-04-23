using System;
using System.Collections.Generic;
using System.Linq;


class Addition : MathProblem
{
    public Addition() 
        :base()
    {
        Console.Write("How Many rows of numbers" +
                "would you like?: ");
        int rows = intValidator();
        Console.Write("What's the max digit length " +
                "would you like?: ");
        int length = intValidator();

        Console.Write("Would you like the numbers " +
                "to be sorted? y/n\n: ");
        string response = "";
        do
        {
            response = Console.ReadLine();
            if (response.ToUpper() == "Y")
            {
                sort = true;
            }
            else if (response.ToUpper() == "N")
            {
                sort = false;
            }
            else
            {
                Console.WriteLine("Please enter a valid option.\n: ");
            }
        } while (response.ToUpper() != "Y" &&
        response.ToUpper() != "N");


        if (rows >= 1)
        {
            this.rows = rows;
        }
        if (length >= 1)
        {
            this.length = length;
        }
        numMax = (int)(Math.Pow(10, length));
        Numbers = new List<int>();
        symbol = "(+)";
    }

    public override void Generate()
    {
        base.Generate();
        Numbers = new List<int>();
        for(int i = 0; i < rows; i++)
        {
            Numbers.Add(rnum.Next(1, numMax));
        }
        Answer = Numbers.Sum();
    }
    public override string Desc() 
        => "This is nothing more than regular"+
        " addition! \nJust remember to go right to left :)\nHit any key to start";
}

