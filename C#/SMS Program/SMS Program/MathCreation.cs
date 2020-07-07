using System;
using System.Collections.Generic;

/*Creates a menu for creating mathProblem objects and returns it.
 */

enum MathProblems
{
    ADDITION = 1,
    SUBTRACTION,
    MULTIPLICATION,
    DIVISION
}

enum SMSProblems
{
    COMP_READING = 1,
    COMP_SUB,
    COMP_ADD
}

class MathCreation
{
    public bool PdfMode { get; set; }
    string pdfModeText = "";
    public MathProblem Create()
    {
        pdfModeText = PdfMode ? "On" : "Off";
        MathProblem prob = null;
        int choice;
        int smsChoice;
        int mathChoice;
        bool choseProblem = false;

        Menu starterMenu = new Menu($"PDF mode is {pdfModeText}",
            "Please make a selection",
             new List<string> {
                "Toggle PDF Mode",
                "Speed Mathmatics Simplified Problems",
                "Normal Math Problems"
             });
        do
        {
            choice = starterMenu.Select();

            switch (choice)
            {
                case 0:
                    Console.Clear();
                    PdfMode = !PdfMode;

                    pdfModeText = PdfMode ? "On!" : "Off!";

                    starterMenu.Prefix = $"PDF mode is {pdfModeText}";
                    break;
                case 1:
                    Menu smsMenu = new Menu($"PDF mode is {pdfModeText}",
                    "Please make a selection",
                    new List<string>
                    {
                        "Toggle PDF Mode",
                        "Component Speed-reading",
                        "Component Addition",
                        "Component Subtraction",
                        "Return To Previous Menu"
                    });

                    do
                    {
                        smsChoice = smsMenu.Select();
                        switch (smsChoice)
                        {
                            case 0:
                                Console.Clear();
                                PdfMode = !PdfMode;

                                pdfModeText = PdfMode ? "On!" : "Off!";
                                smsMenu.Prefix = $"PDF mode is {pdfModeText}";
                                break;
                            case 4:
                                break;
                            default:
                                choseProblem = true;
                                return SMSProblem(smsChoice);
                        }
                    } while (smsChoice == 0);
                    break;
                default:
                    Menu mathMenu = new Menu($"PDF mode is {pdfModeText}",
                    "Please make a selection",
                    new List<string>
                    {
                        "Toggle PDF Mode",
                        "Addition",
                        "Subtraction",
                        "Multiplication",
                        "Division",
                        "Return To Previous Menu"
                    });
                    do
                    {
                        mathChoice = mathMenu.Select();
                        switch (mathChoice)
                        {
                            case 0:
                                Console.Clear();
                                PdfMode = !PdfMode;

                                pdfModeText = PdfMode ? "On!" : "Off!";
                                mathMenu.Prefix = $"PDF mode is {pdfModeText}";
                                break;
                            case 5:
                                break;
                            default:
                                choseProblem = true;
                                return MathProblem(mathChoice);
                        }
                    } while (mathChoice == 0);
                    break;
            }
        } while(choice == 0 || !choseProblem);

        return prob;
        
    }

    private MathProblem SMSProblem(int choice)
    {
        switch (choice)
        {
            case (int)SMSProblems.COMP_READING:
                return new SpeedReading();
            case (int)SMSProblems.COMP_ADD:
                return new AdditionSpeedReading();
            default:
                return new SubtractionSpeedReading();
        }
    }

    public MathProblem MathProblem(int choice)
    {
        switch (choice)
        {
            case (int)MathProblems.ADDITION:
                return new Addition();
            case (int)MathProblems.SUBTRACTION:
                return new Subtraction();
            case (int)MathProblems.MULTIPLICATION:
                return new Multiplication();
            case (int)MathProblems.DIVISION:
                return new Division();
            default:
                return new Division();
        }
    }
}

