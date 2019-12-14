using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Addition : MathProblem
{
    public Addition() 
        :base()
    {
        Console.Write("How Many rows " +
                "would you like?: ");
        int rows = intValidator();
        Console.Write("What's the max digit length " +
                "would you like?: ");
        int length = intValidator();


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
        " addition! \nJust remmeber to go right to left :)";
}

