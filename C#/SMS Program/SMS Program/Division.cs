using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Division : MathProblem
{
    public double dividend;
    bool wholeDivision = false;
    public double divisor;
    int precision = 0;
    public Division() : base()
    {
        BufferSize = 100;
        Console.Write("What's what would you likethe max digit length of the divisor" +
                " to be??: ");
        int length = intValidator();

        this.rows = 2;
        if (length >= 1)
        {
            this.length = length;
        }
        numMax = (int)(Math.Pow(10, length));
        Numbers = new List<int>();
        symbol = "(/)";

        Console.Write("Do you only want whole division? (y/n) : ");
        string userInput = Console.ReadLine();
        if (userInput.ToUpper() == "Y")
        {
            wholeDivision = true;
        }
        else
        {
            wholeDivision = false;
            Console.Write("What's the max decimal precision  " +
                "would you like?: ");
            precision = intValidator();
        }
    }

    public override void Generate()
    {
        base.Generate();
        divisor = rnum.Next(1, numMax);

        if (wholeDivision)
        {
            Answer = rnum.Next(1, 99); //to prevent the Number from being huge
            dividend = divisor * Answer;
        }
        else
        {
            dividend = rnum.Next(1, numMax);
            Answer = divisor / dividend;
            Answer = Math.Round(Answer, precision);
        }

    }

    public override string ToString()
    {
        string spacing = new string('_', length);
        Problem = $"{dividend}/{divisor}\n{spacing}";
        return Problem;
    }

    public override string PDFstring()
    {
        string problemString = $"<br><br>{divisor})<span style=\"border-top: 1px black solid;\">{dividend}</span>";
        return $"{problemString}";
    }

    public override string CheckAnswer()
    {
        return base.CheckAnswer();
    }

    public override string Desc()
    => "This is nothing more than regular" +
    " division! \nJust remember to go right to left :)\nHit any key to start";
}

