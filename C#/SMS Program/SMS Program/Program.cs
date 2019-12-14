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


//
//

//
/*
TODO
Eventually include a timer function and display how long it
took the player to finish and the current highscore for that limit

---For the accuracy problems, i think i'm going to generate and show the 
answer to a random problem, but the answer has a chance to be wrong 
(+ or - a random amount, or purposefully recreate common problems and 
bake them in(forgetting to subtract the component and instead adding it, vice 
versa)) I'm not sure yet

Sections of the book left to include: 
    no-carry multiplication, 
    short-hand division, 
    accuracy (quick check and backup check)
    shortcuts(?) 
    Aliquots 
    Factors 
    Proportionate Change, 
    Fractions, 
    Decimals, 
    Percentags, 
    business arithmetic

    Ask if user wants random kinds of problems (letting the user select the problems, pass)

    FOr now, just create a list of MathProblem objects and randomly select
        one each time (this will require adding a symbol to the strings to 
        denote what kind of problem they are, also the default for subtraction
        will be False
 */


class Program
{
    static void Main()
    {
        bool printMode = false;
        MathProblem prob = null;

        MathCreation mathCreator = new MathCreation();

        prob = mathCreator.Create(ref printMode);

        if (printMode)
        {
            GeneratePDF(prob);
        }
        else
        {
            RunProblems(prob);
        }
        
    }
    static void RunProblems(MathProblem prob)
    {
        Console.Clear();
        Console.WriteLine(prob.Desc());
        Console.ReadLine();
        for (int i = 0; i < prob.Rounds; i++)
        {
            Console.Clear();
            prob.Generate();
            Console.WriteLine($"{prob.GetType()} Problems "+
                $"\nRound {i + 1}/{prob.Rounds}\n***********");
            Console.WriteLine(prob);
            Console.WriteLine(
                prob.CheckAnswer());
            Console.ReadLine();
        }
        Console.WriteLine(prob.Stats());
        Menu printMenu = new Menu(
           "Would you like to go again ?", new List<String>
           {"Yes","No - return to main menu"});

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
        MathCreation mathCreator = new MathCreation();

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
            "Would you like to print this again ?", new List<String>
            {"Yes","No - return to main menu"});

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

