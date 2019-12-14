using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


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

    public int Rounds { get; set; }


    protected Random rnum = new Random();

    public MathProblem()
    {
        rnum = new Random();
        Console.Write("How Many problems " +
                "would you like?: ");
        Rounds = intValidator();
    }

    public virtual void Generate()
    {
        Problem = "";
    }
    public virtual string CheckAnswer()
    {
        int answer;
        bool success;

        do
        {
            success = int.TryParse(Console.ReadLine(), out answer);
            if (success != true)
            {
                Console.WriteLine("Input valid int.");
            }
        } while (success != true);

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
        bool success;
        do
        {
            success = int.TryParse(
                Console.ReadLine(),
                out num);
            if (success != true)
            {
                Console.WriteLine("Input Valid Integer.");
            }
        } while (success != true);
        return num;
    }

    public override string ToString()
    {
        Numbers.Sort();
        Numbers.Reverse();
        foreach (int number in Numbers)
        {
            Problem += $"{number,3}\n";
        }

        string spacing = new string('_', (length));

        Problem += spacing;

        return Problem;
    }

    public string Stats()
    {
        return $"You correctly guessed {NumCorrect} out of {Rounds}"+
            " problems! ";
    }

    public virtual string Desc() => "Override This With A Description.";
}
