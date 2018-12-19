using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Program
{
    class Program
    {
        static void Main()
        {
            int initRoundNumber = 0;
            bool isValid = false;
            int modeChoice = 0;
            bool tryAgain = true;

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello, welcome to the program. Please select what you want to study");
            Console.WriteLine("1) Addition Speed Reading");
            Console.WriteLine("2) Subtraction Speed Reading");
            Console.WriteLine("3) Addition Problems");
            

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
                
                if (modeChoice <= 3)
                {
                    if (modeChoice <= 2) //checking to make sure the user wants a speed read, which only needs the number of rounds rather than the number of digits as well.
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
                    else if (modeChoice == 3)
                    {
                        Console.WriteLine("This feature is not implemented yet");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid choice.");
                        continue;
                    }
                    isValid = true;
                    
                }
                speedMathmaticsRun(initRoundNumber, modeChoice);
            }
            
        }

        public static void speedMathmaticsRun(int initRoundNumber, int modeChoice)
        {
            //Method that actually does the running of the mathmatics problems.

            bool tryAgain = true;

            Console.WriteLine("Let's go!");

            Console.ReadKey();

            int winCount = 0;
            int loseCount = 0;
            for (int i = 1; i <= initRoundNumber; i++)
            {
                Console.WriteLine("Current Round:" + i + "/" + initRoundNumber);
                Console.WriteLine();

                Tuple<int, string> currentRoundProblem;

                if (modeChoice == 1) //Grabs the correct int and string from the correct method. All of these methods return an int and a string tuple, but some of them need additional information such as max number length or a max number of rows.
                {
                    currentRoundProblem = additionSpeedRead();
                }
                else
                {
                    currentRoundProblem = subtractionSpeedRead();
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

                    Console.WriteLine("You got it wrong...");
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
                speedMathmaticsRun(initRoundNumber, modeChoice);
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

        public static Tuple<int, string> additionSpeedRead()
        {
            
            List<object> problemOutput = new List<object>();

            Random rnd = new Random();

            int a = rnd.Next(1,9);

            int b = rnd.Next(1, 9);

            int answer = a + b;

            if (answer >= 10)
            {
                answer = answer - 10;
            }

            string problemString = a + "\n-\n"+ b;

            problemOutput.Add(answer);

            problemOutput.Add(problemString);

            return Tuple.Create(answer, problemString);

        }

        public static Tuple<int, string> subtractionSpeedRead()
        {

            List<object> problemOutput = new List<object>();

            Random rnd = new Random();

            int a = rnd.Next(1, 9);

            int b = rnd.Next(1, 9);

            int answer = a - b;

            if (answer <= 0)
            {
                answer = answer + 10;
            }

            string problemString = a + "\n-\n" + b;

            problemOutput.Add(answer);

            problemOutput.Add(problemString);

            return Tuple.Create(answer, problemString);

        }
        //consider asking player of they wanna save the round number, max digitsm and min digits for next time. Only one file at first, but tlater suport more. Save it as a simple yaml

        // Add a Complement Problem option for purely learning complements (9 = 1, 6 = 4, 2 = 8, etc)
        /* private static void AdditionProblems(int initMaxDigits, int initMinDigits, out Array problemOutput)
         {

         }*/
    }
}
