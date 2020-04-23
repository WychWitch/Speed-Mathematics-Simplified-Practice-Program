using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Program
{
    class Division : MathProblem
    {
        public double Number;
        bool wholeDivision = false;
        public double baseNum;
        int precision = 0;
        public Division() : base()
        {
            BufferSize = 100;
            Console.Write("What's the max digit length " +
                    "would you like?: ");
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
            baseNum = rnum.Next(1, numMax);

            if (wholeDivision)
            {
                Answer = rnum.Next(1, 99); //to prevent the Number from being huge
                Number = baseNum * Answer;
            }
            else
            {
                Number = rnum.Next(1, numMax);
                Answer = baseNum / Number;
                Answer = Math.Round(Answer, precision);
            }

        }

        public override string ToString()
        {
            string spacing = new string('_', length);
            Problem = $"{Number}/{baseNum}\n{spacing}";
            return Problem;
        }

        public override string PDFstring()
        {
            string spacing = new string('_', length*3);
            return $"{baseNum}({Number})\n{spacing}";
        }

        public override string CheckAnswer()
        {
            return base.CheckAnswer();
        }

        public override string Desc()
        => "This is nothing more than regular" +
        " division! \nJust remember to go right to left :)\nHit any key to start";
    }
}
