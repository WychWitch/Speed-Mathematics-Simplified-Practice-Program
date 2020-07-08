using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RandomMath : MathProblem
{
    private int rowMax;
    private int rowMin;
    private int lengthMax;
    private int lengthMin;
    public MathProblem prob;

    enum MathProblems
    {
        ADDITION = 1,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION
    }
    public RandomMath()
        :base()
    {
        Console.WriteLine("What's the max rows you want?");
        rowMax = intValidator();
        Console.WriteLine("What's the min rows you want?");
        rowMin = intValidator();
        Console.WriteLine("What the max digit length you want?");
        lengthMax = intValidator();
        Console.WriteLine("What the min digit length you want?");
        lengthMin = intValidator();
    }

    public override void Generate()
    {
        int choice = rnum.Next(1, 
            Enum.GetNames(typeof(MathProblems)).Length);
        int length = rnum.Next(lengthMin, lengthMax);
        int rows = rnum.Next(rowMin, rowMax);
        switch (choice)
        {
            case (int)MathProblems.ADDITION:
                prob = new Addition(true);
                prob.MathSetup(rows, length);
                prob.Generate();
                break;
            case (int)MathProblems.SUBTRACTION:
                prob = new Subtraction(true);
                prob.MathSetup(rows, length);
                break;
            case (int)MathProblems.MULTIPLICATION:
                prob = new Multiplication(true);
                prob.MathSetup(rows, length);
                break;
            case (int)MathProblems.DIVISION:
                prob = new Division(true);
                prob.MathSetup(length);
                break;
            default:
                break;
        }
        Problem = prob.Problem;
        Answer = prob.Answer;
        currentType = prob.GetType().ToString();
    }
    public override string ToString()
    {
        return prob.ToString();
    }

    public override string PDFstring()
    {
        return prob.PDFstring();
    }
    public override string Desc()
    {
        return prob.Desc();
    }
}
