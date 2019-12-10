using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Medallion;
using PdfSharp;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;


//Eventually include a timer function and display how long it took the player to finish and the current highscore for that limit

//Sections of the book left to include: no-carry multiplication, short-hand division, accuracy (quick check and backup check) shortcuts(?) Aliquots Factors Proportionate Chage, Fractions, Decimals, Percentags, business arithmetic

//---For accuracy problems, i think i'm going to generate and show the answer to a random problem, but the answer has a chance to be wrong (+ or - a random amount, or purposefully recreate common problems and bake them in(forgetting to subtract the component and instead adding it, vice versa)) I'm not sure yet

// TODO IMPORTANT replace checking inputs with int.TryParse() or Int32.TryParse() it is so much better that what you;re doing rn

// TODO add Subtraction next (w/o making sure the answer is positive)

/*TODO improve EASY subtraction by giving a chance (50%?) that instead of adding a random number to the answer to make it 
big enough to be positive, instead set one of the components to be set to a random number from 1 to itself(divided by 2?? rounded)
That way instead of numbers MOSTLY being in the higher end, theres a chance you can get lower numbers as well
 
TODO!!!!!!!!!!!!! 
WHEN YOU GENERATE EASY SUBTRACTION ALL YOU HAVE TO DO IS GENERATE A RANDOM NUMBER 
THATS LESS THAN THE BASE NUMBER

inf act make it a for loop like

baseNum = randomnum
list.add(basenum)
for i = 0; i < row; i++
    if baseNum > 1: //checks if basenum is bigger than 1
        newnum = random(1, basenum)
        basenum -= newNum
        list.add(newNum)
list.Sort()
 */


class Program
{
    static void Main()
    {
        MathProblem prob = null;

        Menu starterMenu = new Menu("Please make a selection",
            new string[] { "Print",
                "Speed Reading Complements",
                "Speed Reading Subtractions",
                "Speed Reading Addition",
                "Addition",
                "Subtraction",
                "Quit"
            });
        int selection = starterMenu.Select();
        switch (selection)
        {
            case 0:
                Menu printerMenu = new Menu("Please select which problems"+
                    "you would like to print",
            new string[] {
                "Speed Reading Complements",
                "Speed Reading Addition",
                "Speed Reading Subtraction",
                "Addition",
                "Subtraction",
                "Quit"
            });
                int printSelection = printerMenu.Select();
                switch (printSelection)
                {
                    case 0:
                        prob = new SpeedReading();
                        break;
                    case 1:
                        prob = 
                            new AdditionSpeedReading();
                        break;
                    case 2:
                        prob =
                            new SubtractionSpeedReading();
                        break;
                    case 3:
                        prob = new Addition();
                        break;
                    case 4:
                        prob = new Subtraction();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
                GeneratePDF(prob);
                break;
            case 1:
                prob = new SpeedReading();
                break;
            case 2:
                prob =
                    new AdditionSpeedReading();
                break;
            case 3:
                prob =
                    new SubtractionSpeedReading();
                break;
            case 4:
                prob = new Addition();
                break;
            case 5:
                prob = new Subtraction();
                break;
            case 6:
                Environment.Exit(0);
                break;
        }
        RunProblems(prob);
        

    }
    static void RunProblems(MathProblem prob)
    {
        for (int i = 0; i < prob.Rounds; i++)
        {
            Console.Clear();
            prob.Generate();
            Console.WriteLine($"{prob.GetType()} Problems "+
                $"\nRound {i + 1}/{prob.Rounds} Answer: {prob.Answer}\n***********");
            Console.WriteLine(prob);
            Console.WriteLine(
                prob.Verify());
            Console.ReadLine();
        }
        Console.WriteLine(prob.Stats());
        Menu printMenu = new Menu(
           "Would you like to go again ?", new string[]
           {"Yes","No - return to main menu","No - Exit Application"});

        int menuSelect = printMenu.Select();

        if (menuSelect == 0)
        {
            RunProblems(prob);
        }
        else if (menuSelect == 1)
        {
            Main();
        }
        else if (menuSelect == 2)
        {
            Environment.Exit(0);
        }

    }
    static void GeneratePDF(MathProblem problem)
    {
        int bottomPadSize = 100; //100px default


        Console.WriteLine("Generating PDF, it might take some time...");

        string modeText = $"{problem.GetType()}".ToUpper();
        var time = DateTime.Now;

        string formattedTime = time.ToString("yyyy-MM-dd, hh:mmtt");

        //the html + css code for formatting the string
        string header = "<body><h1 style=\"font-size: " +
            "40px;text-align: right;> " + modeText +
            " PROBLEMS</h1><br><p style=\"font-size: 10px;text-align: " +
            "right;>" + formattedTime + "</p>";
        
        
        string pdfString = header;

        string pdfStringAnswers = header;

        pdfString += "<table style=\"width:35%; page-break-inside: avoid\" >";

        pdfStringAnswers += "<table style=\"width:35%; page-break-inside: avoid\" >";

        for (int i = 1; i <= problem.Rounds;)
        {
            pdfString += "<tr>";
            pdfStringAnswers += "<tr>";
            for (int ii = 1; ii <= 10 && i <= problem.Rounds; ii++)
            {

                problem.Generate();

                //replacing /n with html-friendly <br>
                pdfString += "<th style=\"float: left;width: 30 %;padding:"+
                    " 1px 1px " + bottomPadSize.ToString() + "px"+
                    " 1px; text-align: right; font-weight: normal \">"+
                    " <div style=\"color:#b04cdb; font-size: 12px;"+
                    " font-style: italic\">" + i + ".</div>" + 
                    $"{problem}".Replace("\n", "<br>") + "</th>"; 

                pdfStringAnswers += "<th style=\"float: left;width: 30"+
                    " %;padding: 1px 1px " + bottomPadSize.ToString() + "px"+
                    " 1px; text-align: right; font-weight: normal \">"+
                    " <div style=\"color:#ff007b; font-size: 12px;"+
                    " font-style: italic\">" + i + ".</div>" +
                    (int)problem.Answer + "</th>";
                i++;
            }
            pdfString += "</tr>";
            pdfStringAnswers += "</tr>";



        }
        pdfString += "</table></body>";
        pdfStringAnswers += "</table></body>";

        PdfDocument pdf = PdfGenerator.GeneratePdf(pdfString, PageSize.Letter);
        pdf.Save("Generated Problems.pdf");

        pdf = PdfGenerator.GeneratePdf(pdfStringAnswers, PageSize.Letter);
        pdf.Save("answers.pdf");

        System.Diagnostics.Process.Start("Generated Problems.pdf");
        System.Diagnostics.Process.Start("answers.pdf");

        Menu printMenu = new Menu("Done generating PDF. " +
            "Would you like to print this again ?", new string[]
            {"Yes","No - return to main menu","No - Exit Application"});

        int menuSelect = printMenu.Select();

        if (menuSelect == 0)
        {
            GeneratePDF(problem);
        }
        else if (menuSelect == 1)
        {
            Main();
        }
        else if (menuSelect == 2)
        {
            Environment.Exit(0);
        }

    }

}

