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
    public MathProblem Create(ref bool pdfMode)
    {
        string pdfModeText = pdfMode ? "On" : "Off";
        MathProblem prob = null;
        int choice;

        Menu starterMenu = new Menu($"PDF mode is {pdfModeText}",
            "Please make a selection",
             new List<string> {
                "Toggle PDF Mode",
                "Speed Reading Complements",
                "Speed Reading Subtractions",
                "Speed Reading Addition",
                "Addition",
                "Subtraction"
             });
        do
        {
            choice = starterMenu.Select();

            if (choice == 0)
            {
                Console.Clear();
                pdfMode = !pdfMode;

                pdfModeText = pdfMode ? "On!" : "Off!";

                starterMenu.Prefix = $"PDF mode is {pdfModeText}";
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

