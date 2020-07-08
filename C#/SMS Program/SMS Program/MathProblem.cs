using System;
using System.Collections.Generic;
using System.Web.Caching;

class MathProblem
{
    //This is going to be the base class for all math programs
    //Make a Question(string) and Answer(decimal) 
    //Make the components of the question added to a list
    //Make a generate() method
    protected int rows,
        length,
        numMax;
    public string symbol = "";
    public int NumCorrect { set; get; }
    public double Answer { set; get; }
    public string Problem { set; get; }
    public List<int> Numbers { get; set; }
    public int BufferSize { get; set; }
    public int Rounds { get; set; }
    public bool Auto { get; set; }
    public string currentType;
    public bool AutoTrigger { get; set; }
    protected Random rnum = new Random();
    protected bool sort = false;

    public MathProblem()
    {
        if (!Auto)
        {
            BufferSize = 40; //100px default
            rnum = new Random();
            Console.Write("How Many problems " +
                    "would you like?: ");
            Rounds = intValidator();
        }
        if (AutoTrigger)
        {
            Auto = true;
        }
    }
    public MathProblem(bool auto)
    {
        Auto = true;
    }

    public virtual void Generate()
    {
        Problem = "";
    }
    public virtual string CheckAnswer()
    {
        int answer = intValidator();

        if (answer == Answer)
        {
            NumCorrect++;
            return "Correct!";
        }
        else
        {
            return $"Incorrect... The Correct answer was {Answer}";
        }
    }
    protected int intValidator()
    {
        int num;
        bool validInt;
        do
        {
            //makes sure int is valid. If not, loop
            validInt = int.TryParse(
                Console.ReadLine(),
                out num);
            if (validInt != true)
            {
                Console.WriteLine("Please Input Valid Integer.");
            }
        } while (validInt != true);
        return num;
    }

    public override string ToString()
    {
        if (sort)
        {
            Numbers.Sort();
            Numbers.Reverse();
        }

        foreach (int number in Numbers)
        {
            Problem += $"{number,3}\n";
        }

        string spacing = new string('_', length);

        Problem += spacing;

        return Problem;
    }

    public string Stats()
    {
        string statString = $"You correctly guessed {NumCorrect} out of {Rounds}" +
            " problems! ";
        NumCorrect = 0;
        return statString;
    }

    public virtual string PDFstring()
    {
        return ToString();
    }
    public virtual void MathSetup(int rows, int length){}
    public virtual void MathSetup(int length) { }
    public virtual string Desc() => "Override This With A Description.";
}
