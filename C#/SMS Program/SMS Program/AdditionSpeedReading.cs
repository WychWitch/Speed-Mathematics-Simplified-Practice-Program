using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AdditionSpeedReading : SpeedReading
{
    public AdditionSpeedReading() : base()
    {
    }

    public override void Generate()
    {
        rnum = new Random();
        int numA = rnum.Next(1,10);
        int numB = rnum.Next(1,10);
        int answer = numA + numB;

        if (answer >= 10)
        {
            Answer = answer - 10;
        }
        else
        {
            Answer = answer;
        }

        Problem = $"{numA}\n-\n{numB}\n_";

    }

    public override string Desc()
       => "For these exercises, if a number >= 10 ignore the tens place and"+
        " just type the ones place.";
}

