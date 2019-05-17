using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;
using Medallion;

namespace SMS_Program
//Eventually include a timer function and display how long it took the player to finish and the current highscore for that limit
//TODO: get the problem sheet function working where you can freely select what to generate, and ask the user if you want to return to min menu


{
    class Program
    {
        static void Main()
        {
            int initRoundNumber = 0;
            bool isValid = false;
            int modeChoice = 0;
            int initMaxDigits = 0;
            int initMinDigits = 0;
            int maxRows = 0;
            bool tryAgain = true;

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
                
                if (modeChoice <= 5)
                {   
                    if (modeChoice == 0)
                    {
                        Console.WriteLine("generating pdf");
                        generatePDF(1, 1, 1, 1, 1);
                    }
                    if (modeChoice <= 3 & modeChoice != 0) //checking to make sure the user wants a speed read, which only needs the number of rounds rather than the number of digits as well.
                    {
                        
                        Console.WriteLine("How many rounds do you want? For speed readings I reccomend a high number of rounds, minimum of 10.");
                        int userInputInt = 0;
                        tryAgain = true;
                        while (tryAgain) //making sure try loop repeats
                        {
                            try
                            {
                                userInput = Console.ReadLine();
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
                                userInput = Console.ReadLine();
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
                                userInput = Console.ReadLine();
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
                                userInput = Console.ReadLine();
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
                                userInput = Console.ReadLine();
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
                speedMathmaticsRun(initRoundNumber, modeChoice, initMaxDigits, initMinDigits, maxRows);
            }
            
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
                    tryAgain = false;
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
            //TODO: Currently there is no way to check if the choice is greater or lower than the avaiable choices. Add a simple IF statement in the tryAgain loop to check to see if the choice is greater than zero and less than the maxChoiceInt




        }

        public static void generatePDF (int initRoundNumber, int modeChoice, int initMaxDigits, int initMinDigits, int maxRows)
        {

            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();

            Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print;

            string pdfString = "<body><ul style=\"list-style-type: none; column-count: 4; column - gap: 20px; -moz-column-count: 4;-moz-column-gap: 20px -webkit-column-count: 4; -webkit-column-gap: 20px; font-size: 20px;text-align: right;\">"; //the html + css code for formatting the string

            Tuple<int, string> currentRoundProblem;

            for (int i = 1; i <= 20; i++)
            {
                currentRoundProblem = subtractionProblems(3,1,3);
                string problemText = currentRoundProblem.Item2;
                pdfString += "<li style=\"float: left;width: 50 %;padding: 25px 25px 100px 50px \">" + problemText.Replace("\n", "<br>") + "</li>"; //replacing /n with html-friendly <br>
            }
            pdfString += "</ul></body>";    

            var PDF = Renderer.RenderHtmlAsPdf(pdfString);
            var OutputPath = "html-string.pdf";
            
            PDF.SaveAs(OutputPath);
            System.Diagnostics.Process.Start(OutputPath);

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
        //consider asking player of they wanna save the round number, max digitsm and min digits for next time. Only one file at first, but tlater suport more. Save it as a simple yaml

        // Add a Complement Problem option for purely learning complements (9 = 1, 6 = 4, 2 = 8, etc)
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
