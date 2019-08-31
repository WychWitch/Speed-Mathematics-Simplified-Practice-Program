using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medallion;
using PdfSharp;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace SMS_Program
//Eventually include a timer function and display how long it took the player to finish and the current highscore for that limit

//Sections of the book left to include: no-carry multiplication, short-hand division, accuracy (quick check and backup check) shortcuts(?) Aliquots Factors Proportionate Chage, Fractions, Decimals, Percentags, business arithmetic

//---For accuracy problems, i think i'm going to generate and show the answer to a random problem, but the answer has a chance to be wrong (+ or - a random amount, or purposefully recreate common problems and bake them in(forgetting to subtract the component and instead adding it, vice versa)) I'm not sure yet

// TODO IMPORTANT replace checking inputs with int.TryParse() or Int32.TryParse() it is so much better that what you;re doing rn

// TODO add Subtraction next (w/o making sure the answer is positive)


{
    class Program
    {
        static void Main()
        {
            
            bool isValid = false;

            int modeChoice;

            Console.WriteLine("Hello, welcome to the program. Please select what you want to study");
            Console.WriteLine("0) Generate Problem Sheet");
            Console.WriteLine("1) Complements Speed Reading");
            Console.WriteLine("2) Addition Speed Reading");
            Console.WriteLine("3) Subtraction Speed Reading");
            Console.WriteLine("4) Addition Problems");
            Console.WriteLine("5) Subtraction Problems (easy)");


            while (isValid == false)
            {
                string userInput = Console.ReadLine();

                try //making sure the user inputs a valid int
                {
                    modeChoice = int.Parse(userInput); // saving the mode
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Please enter an int.");
                    continue;
                   
                }

                if (modeChoice == 0)
                {
                    Console.WriteLine("[Please select an option to print.]");
                    Console.WriteLine("1) Complements Speed Reading");
                    Console.WriteLine("2) Addition Speed Reading");
                    Console.WriteLine("3) Subtraction Speed Reading");
                    Console.WriteLine("4) Addition Problems");
                    Console.WriteLine("5) Subtraction Problems (easy)");


                    while (isValid == false)
                    {
                        userInput = Console.ReadLine();
                        try //making sure the user inputs a valid int
                        {
                            modeChoice = int.Parse(userInput); // saving the mode
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message + " Please enter an int.");
                            continue;

                        }
                        isValid = true;
                    }

                    var selectionList = selection(modeChoice);
                    generatePDF(selectionList[0], selectionList[1], selectionList[2], selectionList[3], selectionList[4]);

                }
                else
                {
                    var selectionList = selection(modeChoice);
                    speedMathmaticsRun(selectionList[0], selectionList[1], selectionList[2], selectionList[3], selectionList[4]);
                    isValid = true;
                }


            }
            
        }

        public static List<int> selection(int modeChoice)
        {
            int initRoundNumber = 0;
            int initMaxDigits = 0;
            int initMinDigits = 0;
            int maxRows = 0;
            bool tryAgain = true;
            bool isValid = false;

            while (isValid == false)
            {
                if (modeChoice <= 5)
                {
                    if (modeChoice <= 3 & modeChoice != 0) //checking to make sure the user wants a speed read, which only needs the number of rounds rather than the number of digits as well.
                    {

                        Console.WriteLine("How many rounds do you want? For speed readings I reccomend a high number of rounds, minimum of 10.");
                        int userInputInt = 0;
                        tryAgain = true;
                        while (tryAgain) //making sure try loop repeats
                        {
                            try
                            {
                                string userInput = Console.ReadLine();
                                userInputInt = int.Parse(userInput);
                                tryAgain = false;
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message + " Please enter an int.");
                                continue;

                            }
                        }

                        initRoundNumber = userInputInt;

                    }
                    else if (modeChoice >= 4)
                    {
                        Console.WriteLine("How many rounds do you want?");
                        int userInputInt = 0;
                        tryAgain = true;
                        while (tryAgain) //making sure try loop repeats
                        {
                            try
                            {
                                string userInput = Console.ReadLine();
                                userInputInt = int.Parse(userInput);
                                tryAgain = false;
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message + " Please enter an int.");
                                continue;

                            }
                        }

                        initRoundNumber = userInputInt;

                        Console.WriteLine("What are the max amount of digits do you want? The minimum is 1, and max is 7.");
                        userInputInt = 0;
                        tryAgain = true;
                        while (tryAgain) //making sure try loop repeats
                        {
                            try
                            {
                                string userInput = Console.ReadLine();
                                userInputInt = int.Parse(userInput);

                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message + " Please enter an int.");
                                continue;

                            }
                            if (userInputInt < 1)
                            {
                                Console.WriteLine("The minimum is 1.");
                                continue;
                            }
                            else if (userInputInt > 7)
                            {
                                Console.WriteLine("The maximum is 7.");
                                continue;
                            }
                            else
                            {
                                tryAgain = false;
                            }
                        }

                        initMaxDigits = userInputInt;

                        Console.WriteLine("What are the min amount of digits do you want? The minimum is 1,and the max is the max you entered  previous.");
                        userInputInt = 0;
                        tryAgain = true;
                        while (tryAgain) //making sure try loop repeats
                        {
                            try
                            {
                                string userInput = Console.ReadLine();
                                userInputInt = int.Parse(userInput);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message + " Please enter an int.");
                                continue;
                            }
                            if (userInputInt < 1)
                            {
                                Console.WriteLine("The minimum is 1.");
                                continue;
                            }
                            else if (userInputInt > initMaxDigits)
                            {
                                Console.WriteLine("The minimum is " + initMaxDigits);
                                continue;
                            }
                            else
                            {
                                tryAgain = false;
                            }
                        }

                        initMinDigits = userInputInt;

                        Console.WriteLine("What are the max amount of rows do you want? The minimum is 2.");
                        userInputInt = 0;
                        tryAgain = true;
                        while (tryAgain) //making sure try loop repeats
                        {
                            try
                            {
                                string userInput = Console.ReadLine();
                                userInputInt = int.Parse(userInput);

                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message + " Please enter an int.");
                                continue;

                            }
                            if (userInputInt < 2)
                            {
                                Console.WriteLine("The minimum is 2.");
                                continue;
                            }
                            else
                            {
                                tryAgain = false;
                            }
                        }

                        maxRows = userInputInt;

                    }
                    else
                    {
                        Console.WriteLine("Not a valid choice.");
                        continue;
                    }
                    isValid = true;

                }
            }

            var returnList = new List<int>();

            returnList.Add(initRoundNumber);
            returnList.Add(modeChoice);
            returnList.Add(initMaxDigits);
            returnList.Add(initMinDigits);
            returnList.Add(maxRows);

            return returnList;
        }

        public static void speedMathmaticsRun(int initRoundNumber, int modeChoice, int initMaxDigits, int initMinDigits, int maxRows)
        {
            //Method that actually does the running of the mathmatics problems.

            bool tryAgain = true;

            Console.WriteLine("Let's go!");

            Console.ReadKey();

            int winCount = 0;
            int loseCount = 0;

            if (modeChoice == 1)
            {
                Console.WriteLine("Remember that you have to write the complement of the HIGHER number and IGNORE the lower one. This is to renforce complement speed-reading.");
                Console.ReadKey();
            }
            else if (modeChoice == 2)
            {
                Console.WriteLine("For these exercises, if a number >= 10 ignore the tens place and just type the ones place.");
                Console.ReadKey();
            }
            else if (modeChoice == 3)
            {
                Console.WriteLine("Just like the addition speed read, for these exercises, if a number >= 0 don't bother typing the negative symbol and just type the positive number. This reinforces the number *strike out previous number* method as mentioned in the book");
                Console.ReadKey();
            }
            else if (modeChoice == 4)
            {
                Console.WriteLine("This is nothing more than regular addition! Just remmeber to go right to left :)");
                Console.ReadKey();
            }
            else if (modeChoice == 5)
            {
                Console.WriteLine("This is easy subtraction! By easy, I mean you don't have to worry about the answer being a negative number, no matter how many rows you have!");
                Console.ReadKey();
            }


            for (int i = 1; i <= initRoundNumber; i++)
            {
                Console.WriteLine("Current Round:" + i + "/" + initRoundNumber);
                Console.WriteLine();

                Tuple<int, string> currentRoundProblem;
                if (modeChoice == 1) //Grabs the correct int and string from the correct method. All of these methods return an int and a string tuple, but some of them need additional information such as max number length or a max number of rows.
                {
                    currentRoundProblem = complementSpeedRead();
                    
                }
                else if (modeChoice == 2)
                {
                    currentRoundProblem = additionSpeedRead();
                    
                }
                else if (modeChoice == 3)
                {
                    currentRoundProblem = subtractionSpeedRead();
                    
                }
                else if (modeChoice == 4)
                {
                    currentRoundProblem = additionProblems(initMaxDigits, initMinDigits, maxRows);

                }
                else
                {
                    currentRoundProblem = subtractionProblems(initMaxDigits, initMinDigits, maxRows);
                }

                int answer = currentRoundProblem.Item1;

                string problemText = currentRoundProblem.Item2;

                Console.WriteLine(problemText);
                Console.WriteLine();
                

                int userInputInt = 0;

                tryAgain = true;
                while (tryAgain)
                {
                    string userInput = Console.ReadLine();
                    try
                    {
                        userInputInt = int.Parse(userInput);
                        tryAgain = false;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message + " Please enter an int.");
                        continue;

                    }
                }

                if (userInputInt == answer)
                {
                    winCount++;

                    Console.WriteLine("You got it right!");
                    Console.WriteLine();

                }
                else
                {
                    loseCount++;

                    Console.WriteLine("You got it wrong... answer was: " + answer);
                    Console.WriteLine();
                }


            }

            string result = "You won, " + winCount + " times and lost " + loseCount + " times! Want to play again?\n\n1) Yes\n2) No - return to main menu\n3) No - Exit Application.";

            Console.WriteLine(result);


            int userChoiceInt = 0;
            tryAgain = true;
            while (tryAgain)
            {
                string userChoice = Console.ReadLine();

                
                try
                {
                    userChoiceInt = int.Parse(userChoice);
                    if (userChoiceInt < 1 || userChoiceInt > 3)
                    {
                        Console.WriteLine("Please choose a number between 1 and 3.");
                        continue;
                    }
                    else
                    {
                        tryAgain = false;
                    }
                    
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Please enter an int.");
                    continue;

                }

            }



            if (userChoiceInt == 1)
            {
                speedMathmaticsRun(initRoundNumber, modeChoice, initMaxDigits, initMinDigits, maxRows);
            }
            else if (userChoiceInt == 2)
            {
                Main();
            }
            else if (userChoiceInt == 3)
            {
                Environment.Exit(0);
            }




        }

        public static void generatePDF (int initRoundNumber, int modeChoice, int initMaxDigits, int initMinDigits, int maxRows)
        {
            int bottomPadSize = 100; //100px default

            Console.WriteLine("Generating PDF, it might take some time...");

            string modeText = "";

            if (modeChoice == 1)
            {
                modeText = "COMPLEMENT SPEED-READ";
            }
            else if (modeChoice == 2)
            {
                modeText = "ADDITION SPEED-READ";
            }
            else if (modeChoice == 3)
            {
                modeText = "SUBTRACTION SPEED-READ";
            }
            else if (modeChoice == 4)
            {
                modeText = "ADDITION";
            }
            else if (modeChoice == 5)
            {
                modeText = "SUBTRACTION (EASY)";
            }

            var time = DateTime.Now;

            string formattedTime = time.ToString("yyyy-MM-dd, hh:mmtt");


            string pdfString = "<body><h1 style=\"font-size: 40px;text-align: right;> " + modeText+ " PROBLEMS</h1><br><p style=\"font-size: 10px;text-align: right;>"+formattedTime+"</p>"; //the html + css code for formatting the string

            string pdfStringAnswers = "<body><h1 style=\"font-size: 40px;text-align: right;> " + modeText + " ANSWERS</h1><br><p style=\"font-size: 10px;text-align: right;>" + formattedTime + "</p>";

            Tuple<int, string> currentRoundProblem;

            pdfString += "<table style=\"width:35%; page-break-inside: avoid\" >";

            pdfStringAnswers += "<table style=\"width:35%; page-break-inside: avoid\" >";

            for (int i = 1; i <= initRoundNumber;)
            {
                pdfString += "<tr>";
                pdfStringAnswers += "<tr>";
                for (int ii = 1; ii <= 10&& i <= initRoundNumber; ii++)
                {
                    
                    if (modeChoice == 1)
                    {
                        currentRoundProblem = complementSpeedRead();
                        string problemText = currentRoundProblem.Item2;
                        int answerText = currentRoundProblem.Item1;

                        pdfString += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#b04cdb; font-size: 12px; font-style: italic\">" + i + ".</div>" + problemText.Replace("\n", "<br>") + "</th>"; //replacing /n with html-friendly <br>

                        pdfStringAnswers += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#ff007b; font-size: 12px; font-style: italic\">" + i + ".</div>" + answerText + "</th>"; //replacing /n with html-friendly <br>
                        i++;
                    }
                    else if (modeChoice == 2)
                    {
                        currentRoundProblem = additionSpeedRead();
                        string problemText = currentRoundProblem.Item2;
                        int answerText = currentRoundProblem.Item1;

                        pdfString += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#b04cdb; font-size: 12px; font-style: italic\">" + i + ".</div>" + problemText.Replace("\n", "<br>") + "</th>"; //replacing /n with html-friendly <br>

                        pdfStringAnswers += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#ff007b; font-size: 12px; font-style: italic\">" + i + ".</div>" + answerText + "</th>"; //replacing /n with html-friendly <br>
                        i++;
                    }
                    else if (modeChoice == 3)
                    {
                        currentRoundProblem = subtractionSpeedRead();
                        string problemText = currentRoundProblem.Item2;
                        int answerText = currentRoundProblem.Item1;

                        pdfString += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#b04cdb; font-size: 12px; font-style: italic\">" + i + ".</div>" + problemText.Replace("\n", "<br>") + "</th>"; //replacing /n with html-friendly <br>

                        pdfStringAnswers += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#ff007b; font-size: 12px; font-style: italic\">" + i + ".</div>" + answerText + "</th>"; //replacing /n with html-friendly <br>
                        i++;
                    }
                    else if (modeChoice == 4)
                    {
                        currentRoundProblem = additionProblems(initMaxDigits, initMinDigits, maxRows);
                        string problemText = currentRoundProblem.Item2;
                        int answerText = currentRoundProblem.Item1;

                        pdfString += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#b04cdb; font-size: 12px; font-style: italic\">" + i + ".</div>" + problemText.Replace("\n", "<br>") + "</th>"; //replacing /n with html-friendly <br>

                        pdfStringAnswers += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#ff007b; font-size: 12px; font-style: italic\">" + i + ".</div>" + answerText + "</th>"; //replacing /n with html-friendly <br>
                        i++;
                    }
                    else if (modeChoice == 5)
                    {
                        currentRoundProblem = subtractionProblems(initMaxDigits, initMinDigits, maxRows);
                        string problemText = currentRoundProblem.Item2;
                        int answerText = currentRoundProblem.Item1;

                        pdfString += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#b04cdb; font-size: 12px; font-style: italic\">" + i + ".</div>" + problemText.Replace("\n", "<br>") + "</th>"; //replacing /n with html-friendly <br>

                        pdfStringAnswers += "<th style=\"float: left;width: 30 %;padding: 1px 1px " + bottomPadSize.ToString() + "px 1px; text-align: right; font-weight: normal \"> <div style=\"color:#ff007b; font-size: 12px; font-style: italic\">" + i + ".</div>" + answerText + "</th>"; //replacing /n with html-friendly <br>
                        i++;
                    }
                    
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

            Console.WriteLine("Done generating PDF. Would you like to print this again?\n\n1) Yes\n2) No - return to main menu\n3) No - Exit Application.");

            int userChoiceInt = 0;
            bool tryAgain = true;
            while (tryAgain)
            {
                string userChoice = Console.ReadLine();

                try
                {
                    userChoiceInt = int.Parse(userChoice);
                    if (userChoiceInt < 1 || userChoiceInt > 3)
                    {
                        Console.WriteLine("Please choose a number between 1 and 3.");
                        continue;
                    }
                    else
                    {
                        tryAgain = false;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Please enter an int.");
                    continue;

                }

            }


            if (userChoiceInt == 1)
            {
                generatePDF(initRoundNumber, modeChoice, initMaxDigits, initMinDigits, maxRows);
            }
            else if (userChoiceInt == 2)
            {
                Main();
            }
            else if (userChoiceInt == 3)
            {
                Environment.Exit(0);
            }

        }

        public static Tuple<int, string> complementSpeedRead()
        {


            int a = Rand.Next(1, 9);

            int b = Rand.Next(1, 9);

            int answer = 0;

            if (a >= b)
            {
                answer = 10 - a;
            }
            else if (b > a)
            {
                answer = 10 - b;
            }

            string problemString = a + "\n-\n" + b;


            return Tuple.Create(answer, problemString);

        }

        public static Tuple<int, string> additionSpeedRead()
        {
            

            int a = Rand.Next(1,9);

            int b = Rand.Next(1, 9);

            int answer = a + b;

            if (answer >= 10)
            {
                answer = answer - 10;
            }

            string problemString = a + "\n-\n"+ b;


            return Tuple.Create(answer, problemString);

        }

        public static Tuple<int, string> subtractionSpeedRead()
        {

            int a = Rand.Next(1, 9);

            int b = Rand.Next(1, 9);

            int answer = a - b;

            if (answer < 0)
            {
                answer = answer + 10;
            }

            string problemString = a + "\n-\n" + b;


            return Tuple.Create(answer, problemString);

        }
        //consider asking player if they wanna save the round number, max digitsm and min digits for next time. Only one file at first, but tlater suport more. Save it as a simple yaml

        public static Tuple<int, string> additionProblems(int initMaxDigits, int initMinDigits, int maxRows)
         {
            var numbersList = new List<int>();

            

            string maxDigitString = new string('9', initMaxDigits);

            int maxDigitInt = int.Parse(maxDigitString);

            int minDigitInt = 1;

            string problemString = "";

            int answer = 0;

            if (initMinDigits > 1)
            {
                initMaxDigits = initMaxDigits - 1; //this is to set the number of zeros to one less int, since we will be tacking on a 1
                string minDigitStringZeros = new string('0', initMaxDigits); //Generate the needed number of 0's

                string finalizedMinDigitString = "1" + minDigitStringZeros;

                minDigitInt = int.Parse(finalizedMinDigitString);

            }

            for (int i = 1; i <= maxRows; i++) 
            {
                int a = Rand.Next(minDigitInt, maxDigitInt);
                numbersList.Add(a);


            }

            numbersList = numbersList.OrderByDescending(p => p).ToList();
            numbersList.Reverse();
            foreach (int i in numbersList)
            {
                if (i.ToString().Length < maxDigitInt.ToString().Length)
                {
                    int difference = maxDigitInt.ToString().Length - i.ToString().Length;
                    string spaces = new string(' ', difference);
                    string fixedA = spaces + i;
                    problemString = problemString + fixedA + "\n";
                }
                else
                {
                    problemString = problemString.Insert(0, i + "\n");
                }
            }

            answer = numbersList.Sum();

            return Tuple.Create(answer, problemString);

        }

        public static Tuple<int, string> subtractionProblems(int initMaxDigits, int initMinDigits, int maxRows)
        {
            var numbersList = new List<int>();

            string maxDigitString = new string('9', initMaxDigits);

            int maxDigitInt = int.Parse(maxDigitString);

            int minDigitInt = 1;

            string problemString = "";

            int answer = 0;

            if (initMinDigits > 1)
            {
                initMaxDigits = initMaxDigits - 1; //this is to set the number of zeros to one less int, since we will be tacking on a 1
                string minDigitStringZeros = new string('0', initMaxDigits); //Generate the needed number of 0's

                string finalizedMinDigitString = "1" + minDigitStringZeros;

                minDigitInt = int.Parse(finalizedMinDigitString);

            }

            int a = Rand.Next(minDigitInt, maxDigitInt); // This is initializing the "top" number. This is so I can manipulate this number more easily if I need to (you'll see below )
            

            if (a.ToString().Length < maxDigitInt.ToString().Length)
            {
                int difference = maxDigitInt.ToString().Length - a.ToString().Length;
                string spaces = new string(' ', difference);
                string fixedA = spaces + a;
            }
            else
            {
                string dashes = new string('-', maxDigitInt.ToString().Length);
            }

            int bAddedTogether;
            int attempts = 0;
            while (true)
            {
                numbersList = new List<int>();
                problemString = "";
                for (int i = 1; i <= maxRows - 1; i++) //-1 because a will be added to problem string later
                {
                    int b = Rand.Next(minDigitInt, maxDigitInt);
                    numbersList.Add(b);


                }

                numbersList = numbersList.OrderByDescending(p => p).ToList();
                numbersList.Reverse();
                foreach(int i in numbersList)
                {
                    if (i.ToString().Length < maxDigitInt.ToString().Length)
                    {
                        int difference = maxDigitInt.ToString().Length - i.ToString().Length;
                        string spaces = new string(' ', difference);
                        string fixedB = spaces + i;
                        problemString = problemString + fixedB + "\n";
                    }
                    else
                    {
                        problemString = problemString.Insert(0, i + "\n");
                    }
                }

                bAddedTogether = numbersList.Sum();

                if (bAddedTogether < maxDigitInt) //make sure bAddedTogether is less than Max Digits
                {
                    break;
                }
                else
                {
                    attempts += 1;
                    continue; //restarts if it's larger than Max Digits
                }
                
            }


            a = Rand.Next(bAddedTogether, maxDigitInt);

            answer = a - bAddedTogether;

            string formattedA = a + "\n" + "----" + "\n"; //this formats that the 'a' number is formatted correctly and is ready to be inserted into the problem string

            problemString = problemString.Insert(0, formattedA);

            return Tuple.Create(answer, problemString);

        }

    }
}
