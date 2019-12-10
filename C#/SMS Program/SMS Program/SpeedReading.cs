using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SpeedReading : MathProblem
{
    public SpeedReading() : base()
    {
    }

    public override void Generate()
    {
        int numA = rnum.Next(1, 10);
        int numB = rnum.Next(1, 10);

        if (numA >= numB)
        {
            Answer = 10 - numA;
        }
        else
        {
            Answer = 10 - numB;
        }
        

        Problem = $"{numA}\n-\n{numB}\n_";
    }
    public override string ToString()
    {
        return Problem;
    }

    public override string Desc()
        => "Remember that you have to write the complement of the HIGHER"+
        " number and IGNORE the lower one. This is to renforce complement"+
        " speed-reading.";
}

