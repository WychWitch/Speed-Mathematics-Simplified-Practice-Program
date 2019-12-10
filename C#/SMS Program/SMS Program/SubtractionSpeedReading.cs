using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SubtractionSpeedReading : SpeedReading
{
    public SubtractionSpeedReading() : base()
    {
    }

    public override void Generate()
    {
        int numA = rnum.Next(1, 10);
        int numB = rnum.Next(1, 10);
        int answer = numA - numB;

        if (answer < 0)
        {
            Answer = answer + 10;
        }
        else
        {
            Answer = answer;
        }

        Problem = $"{numA}\n-\n{numB}\n_";
    }

    public override string Desc()
        => "Just like the addition speed read, for these exercises, if a"+
        " number > 0 don't bother typing the negative symbol and just type"+
        " the positive number. This reinforces the number *strike out"+
        " previous number* method as mentioned in the book";
}

