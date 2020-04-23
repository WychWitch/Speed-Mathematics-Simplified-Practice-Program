using System;
using System.Collections.Generic;
using PdfSharp;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

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

    For now, just create a list of MathProblem objects and randomly select
        one each time (this will require adding a symbol to the strings to 
        denote what kind of problem they are, also the default for subtraction
        will be False
 */


class Program
{
    static void Main()
    {
        MathProblem prob = null;

        //creates a new math creator class
        MathCreation mathCreator = new MathCreation();

        //creates a new mathProblem object
        prob = mathCreator.Create();

        if (mathCreator.PdfMode)
        {
            GeneratePDF(prob);
        }
        else
        {
            RunProblems(prob);
        }
        
    }

    //Run math problems in console.
    static void RunProblems(MathProblem prob) 
    {
        Console.Clear();
        Console.WriteLine(prob.Desc());
        Console.ReadLine();
        for (int i = 0; i < prob.Rounds; i++)
        {
            Console.Clear();
            prob.Generate(); //Generates a new problem
            Console.WriteLine($"{prob.GetType()} Problems "+
                $"\nRound {i + 1}/{prob.Rounds}\n***********");
            Console.WriteLine(prob);
            Console.WriteLine(
                prob.CheckAnswer());//checks answer given
            Console.ReadLine();
        }
        Console.WriteLine(prob.Stats());

        //Create and display new menu
        Menu printMenu = new Menu(
           "Would you like to go again ?", new List<String>
           {"Yes","No - return to main menu"});

        int menuSelect = printMenu.Select();

        switch(menuSelect)
        {
            case 0:
                RunProblems(prob);
                break;
            case 1:
                Main();
                break;
            default:
                Environment.Exit(0);
                    break;
        }
    }

    //Creates a PDF 
    static void GeneratePDF(MathProblem problem)
    {
        List<string> colors = new List<string>{
            "#2E8B57",
            "#8FBC8F",
            "#D2691E",
            "#BC8F8F",
            "#00BFFF",
            "#00CED1",
            "#B22222",
            "#DA70D6",
            "#7B68EE",
            "#000000",
            "#F08080",
            "#8A2BE2",
            "#800080",
            "#4169E1",
            "#DC143C",
            "#4682B4",
            "#808080",
            "#DC143C",
            "#FF7F50",
            "#696969",
            "#BA55D3",
            "#2F4F4F",
            "#40E0D0",
            "#A52A2A",
            "#DDA0DD"
        };

        List<string> adjectives = new List<string> {
            "permissible",
            "vengeful",
            "careful",
            "profuse",
            "beautiful",
            "determined",
            "offbeat",
            "protective",
            "massive",
            "enchanted",
            "quaint",
            "secretive",
            "solid",
            "liquid",
            "shining",
            "defeated",
            "astonishing",
            "true",
            "final",
            "glorious",
            "malicious",
            "puzzling",
            "knowledgeable",
            "quiet",
            "silent"
        };

        List<string> animals = new List<string>
        {
            "salamander",
            "horse",
            "porcupine",
            "hog",
            "deer",
            "prairie dog",
            "orangutan",
            "yak",
            "antelope",
            "crocodile",
            "giraffe",
            "lizard",
            "ram",
            "rabbit",
            "toad",
            "octopus",
            "jerboa",
            "mole",
            "panther",
            "snake",
            "chameleon",
            "bat",
            "ocelot",
            "crab",
            "hyena",
            "horse"
        };
        Random ranChoice = new Random();
        string ranName = $"<div style =\"color:{colors[ranChoice.Next(colors.Count)]}\">";
        ranName += $"<b>{adjectives[ranChoice.Next(adjectives.Count)]}";
        ranName += $" {animals[ranChoice.Next(animals.Count)]}</b></div>";

        int answerBottomPadSize = 10; //100px default


        Console.WriteLine("Generating PDF, it might take some time...");

        string modeText = $"{problem.GetType()}".ToUpper();
        var time = DateTime.Now;

        string formattedTime = time.ToString("yyyy-MM-dd, hh:mmtt");

        //the html + css code for formatting the string
        string header = "<body><h1 style=\"font-size: " +
            "40px;text-align: right;> " + modeText +
            " PROBLEMS</h1><br><p style=\"font-size: 10px;text-align: " +
            "right;>" + ranName +" "+ formattedTime + "</p>";
        
        
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
                    " 1px 1px " + problem.BufferSize.ToString() + "px"+
                    " 1px; text-align: right; font-weight: normal \">"+
                    " <div style=\"color:#b04cdb; font-size: 12px;"+
                    " font-style: italic\">" + i + ".</div>" + 
                    $"{problem.PDFstring()}".Replace("\n", "<br>") + "</th>"; 

                pdfStringAnswers += "<th style=\"float: left;width: 30"+
                    $" %;padding: 1px 1px {answerBottomPadSize}px"+
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

        try
        {
            pdf.Save("Generated Problems.pdf");

            pdf = PdfGenerator.GeneratePdf(pdfStringAnswers, PageSize.Letter);
            pdf.Save("answers.pdf");
            System.Diagnostics.Process.Start("Generated Problems.pdf");
            System.Diagnostics.Process.Start("answers.pdf");
        } 
        catch (System.IO.IOException exc)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" Error: Could not generate PDF. {exc.Message}");
            Console.ResetColor();
            Console.Write("Hit enter to continue: ");
            Console.ReadLine();
        }
        finally
        {
            Menu printMenu = new Menu("Finished. " +
    "Would you like to make a pdf of this again ?", new List<String>
    {"Yes","No - return to main menu"});

            int menuSelect = printMenu.Select();

            switch (menuSelect)
            {
                case 0:
                    GeneratePDF(problem);
                    break;
                case 1:
                    Main();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

