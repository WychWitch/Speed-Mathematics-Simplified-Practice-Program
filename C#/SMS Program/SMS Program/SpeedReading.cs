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
        int baseNum = rnum.Next(1, 10);

        Answer = 10 - baseNum;

        Problem = $"{baseNum}\n_";
    }
    public override string ToString()
    {
        return Problem;
    }
}

