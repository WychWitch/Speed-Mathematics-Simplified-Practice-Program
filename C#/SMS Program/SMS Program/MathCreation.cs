using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum MathProblems
{
    COMP_READING = 1,
    COMP_ADD,
    COMP_SUB,
    ADDITION,
    SUBTRACTION
}
class MathCreation
{
    public MathProblem Create(ref bool printMode)
    {
        Menu starterMenu = new Menu("Please make a selection",
             new List<string> {
                "Toggle Print Mode",
                "Speed Reading Complements",
                "Speed Reading Subtractions",
                "Speed Reading Addition",
                "Addition",
                "Subtraction"
             });


        MathProblem prob = null;

        int choice;
        do
        {
            choice = starterMenu.Select();

            if (choice == 0)
            {
                Console.Clear();
                printMode = !printMode;

                string printModeText = printMode ? "On" : "Off";

                Console.WriteLine($"Print mode is {printModeText}");
            }
            else
            {
                prob = SelectMathProblem(choice);
            }

        } while(choice == 0);

        return prob;
        
    }
    public MathProblem SelectMathProblem(int choice)
    {
        switch (choice)
        {
            case (int)MathProblems.COMP_READING:
                return new SpeedReading();
            case (int)MathProblems.COMP_ADD:
                return new AdditionSpeedReading();
            case (int)MathProblems.COMP_SUB:
                return new SubtractionSpeedReading();
            case (int)MathProblems.ADDITION:
                return new Addition();
            default:
                return new Subtraction();
        }
    }
}

