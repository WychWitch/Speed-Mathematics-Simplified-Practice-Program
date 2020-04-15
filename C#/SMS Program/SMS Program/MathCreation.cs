using System;
using System.Collections.Generic;

/*Creates a menu for creating mathProblem objects and returns it.
 */

enum MathProblems
{
    COMP_READING = 1,
    COMP_SUB,
    COMP_ADD,
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

