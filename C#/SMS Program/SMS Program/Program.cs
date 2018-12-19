using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int initRoundNumber = 0;
            string userInput;
            bool isValid = false;
            int userInputInt = 9;

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello, welcome to the program. Please select what you want to study");
            Console.WriteLine("1) Addition Speed Reading");
            Console.WriteLine("2) Subtraction Speed Reading");
            Console.WriteLine("3) Addition Problems");
            

            while (isValid == false)
            {
                userInput = Console.ReadLine();
                try
                {
                    userInputInt = int.Parse(userInput);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Please enter an int.");
                   
                }

                if (userInputInt <= 3)
                {
                    if (userInputInt == 1)
                    {
                        Console.WriteLine("How many rounds do you want? For speed readings I reccomend a high number of rounds, minimum of 10.");
                        try
                        {
                            userInput = Console.ReadLine();
                            userInputInt = int.Parse(userInput);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message + " Please enter an int.");
                           
                        }

                        initRoundNumber = userInputInt;

                        Console.WriteLine("Let's go!");

                        Console.ReadKey();

                        int winCount = 0;
                        int loseCount = 0;
                        for (int i = 1; i<=initRoundNumber; i++)
                        {
                            Console.WriteLine("Current Round:"+ i + "/" + initRoundNumber);
                            Console.WriteLine();

                            var currentRoundProblem = additionSpeedRead();

                            int answer = currentRoundProblem.Item1;

                            string problemText = currentRoundProblem.Item2;

                            Console.WriteLine(problemText);
                            Console.WriteLine();
                            userInput = Console.ReadLine();

                            try
                            {
                                userInputInt = int.Parse(userInput);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message + " Please enter an int.");

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

                        string result = "You won, " + winCount + " times and lost " + loseCount + " times! Want to play again? 1 for yes, 2 for no.";

                        Console.WriteLine(result);

                        



                    }
                    else if (userInputInt == 2)
                    {
                        Console.WriteLine("This feature is not implemented yet");
                        continue;
                    }
                    else if (userInputInt == 3)
                    {
                        Console.WriteLine("This feature is not implemented yet");
                        continue;
                    }
                }
            }
            
            //Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
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
        //consider asking player of they wanna save the round number, max digitsm and min digits for next time. Only one file at first, but tlater suport more. Save it as a simple yaml

        // Add a Complement Problem option for purely learning complements (9 = 1, 6 = 4, 2 = 8, etc)
       /* private static void AdditionProblems(int initMaxDigits, int initMinDigits, out Array problemOutput)
        {

        }*/
    }
}
