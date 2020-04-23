using System;
using System.Collections.Generic;
using System.Linq;


class Subtraction : MathProblem
{
    public bool SimpleSubtract { get; set; }
    private int baseNum;

    public int BaseNum
    {
        get
        {
            return baseNum;
        }
        set
        {
            if(value > 0)
            {
                baseNum = value;
            }
        }
        
    }

    public Subtraction()
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
            this.rows = rows - 1;
        }
        if (length >= 1)
        {
            this.length = length;
        }
        numMax = (int)(Math.Pow(10, length));
        Numbers = new List<int>();
        symbol = "(-)";

        Console.Write("Would you like the posibility of "+
            "negative answers?(y/n) : ");
        string userInput = Console.ReadLine();
        if (userInput.ToUpper() == "Y")
        {
            SimpleSubtract = false;
        }
        else
        {
            SimpleSubtract = true;
        }
        
    }

    public override void Generate()
    {
        base.Generate();
        Numbers = new List<int>();

        BaseNum = rnum.Next(1, numMax);
        if (SimpleSubtract)
        {
            positiveProbGen();
        }
        else
        {
            //this is to ensure a 50% chance at getting a positive 
            //number each time a problem is generated
            int choice = rnum.Next(1,10);
            
            //This is an if/else statement cos switch statements end up
            //All resolving to either positive or negative for some reason
            if (choice >=5)
            {
                positiveProbGen();
            }
            else
            {
                negativeProbGen();
            }
            
        }
    }

    private void positiveProbGen() 
    {
        for (int i = 0; i < rows; i++)
        {
            if (BaseNum > Numbers.Sum())
            {
                Numbers.Add(rnum.Next(1, (BaseNum - Numbers.Sum())));
            }
        }
        Answer = BaseNum - Numbers.Sum();
    }

    private void negativeProbGen()
    {
        for (int i = 0; i<rows; i++)
            {
                Numbers.Add(rnum.Next(1, numMax));
            }
        Answer = BaseNum - Numbers.Sum();
    }

    public override string Desc()
    {
        if (SimpleSubtract)
        {
            return "This is easy subtraction! \n" +
                "By easy, I mean you don't have to worry about the answer \n" +
                "being a negative number, no matter how many rows you have!";
        }
        else
        {
            return "This is normal subtraction! Many (if not most) answers"+
                " will be in the negatives!";
        }
    }

    public override string ToString()
    {
        string spacing = new string('-', (length));
        return $"{BaseNum,3}\n{spacing}\n{base.ToString()}";
    }
}

