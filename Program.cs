using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning;
            string playerWeapon;
            int weaponNumber;
            string computerWeapon;

            Console.WriteLine("Do you want to play Rock, Paper, Scissors?");
            Console.WriteLine("Enter Y to play or N to exit");

            isRunning = playGame(); // determine if player wants to play. Y = continue, N = exit, invalid = reprompt;


            do
            {
                playerWeapon = playerPicksWeapon(); // prompt user for a valid entry of R,P,S;
                weaponNumber = weaponNumberGenerator(); // random number generator: provides integer to be passed into a method to make a selection;
                computerWeapon = computerPicksWeapon(weaponNumber); // selects R,P,S based on the random number generated;

                Console.WriteLine(); // spacing
                Console.WriteLine($"You: {playerWeapon}"); // feedback to user;
                Console.WriteLine($"Computer: {computerWeapon}"); // feedback to user;
                Console.WriteLine();

                championDecider(playerWeapon, computerWeapon); // Determine who the victor is based on user input and comp selection;
                isRunning = playAgain(); // play again? Prompt the user and restart the game;
            } while (isRunning);
            

        #region Old Comments
        // static void playerPick()
        // {
        //     //Prompt user for rock, paper, or scissors
        //     //User will enter rock, paper, scissors
        //     //Console will read the line and save it to a variable
        //     //have a variable ready to receive new user input
        //     //Use a while loop to keep prompting user for a valid entry
        //     //The output should be the users choice of R,P,S

        //     Console.WriteLine("Rock, Paper, or Scissors?");

        //     string playerChoice = Console.ReadLine();
        //     string choiceToLowercase = playerChoice.ToLower();
        //     string newUserInput;
        //     bool isUserInputValid = true;

        //     while(isUserInputValid)
        //     {
        //         if(choiceToLowercase == "rock" || choiceToLowercase == "paper" || choiceToLowercase == "scissors")
        //     {
        //         Console.WriteLine(); // Add a space
        //         isUserInputValid = false;
        //         Console.WriteLine(choiceToLowercase);

        //     }
        //     else
        //     {
        //         Console.WriteLine("Please choose rock, paper, or scissors");
        //         newUserInput = Console.ReadLine();
        //         choiceToLowercase = newUserInput.ToLower();
        //     }
        //     }
        // }
        // static int randomNumberPicker()
        // {
        //     // This function will be used to generate a random number

        //     // Will call the function after the user selects their pick
        //     var rand = new Random();
        //     int numSelect = rand.Next(1,9);
        //     return numSelect;
        // }

        // static string numberToWeapon(int num)
        //{
        // random number will be used to pick either R,P,S
        //use a tuple to return R,P,S

        //     var weaponChoice = new Tuple<string, string, string>("rock", "paper", "scissors");

        //     if(num <= 3)
        //     {
        //         return weaponChoice.Item1;
        //     }
        //     else if(num > 3 && num <= 6)
        //     {
        //         return weaponChoice.Item2;
        //     }
        //     else
        //     {
        //         return weaponChoice.Item3;
        //     }
        // }
        #endregion

        static bool playGame()
        {
            string answer;
            string answerLC;
            string newAnswer;
            bool startGame = true;
            bool playingGame = false;


            answer = Console.ReadLine();
            answerLC = answer.ToLower();


            while (startGame)
            {
                if (answerLC == "y")
                {
                    startGame = false;
                    playingGame = true;
                }
                else if (answerLC == "n")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter Y to play or N to exit");
                    newAnswer = Console.ReadLine();
                    answerLC = newAnswer.ToLower();
                }
            }
            return playingGame;
        }

        static string playerPicksWeapon()
        {
            Console.WriteLine("Rock, Paper, or Scissors?");

            bool runningStatus = true;
            string playerChoice = Console.ReadLine();
            string playerChoiceLC = playerChoice.ToLower();
            string finalChoice = " ";
            string newChoice;

            while (runningStatus)
            {
                if (playerChoiceLC == "rock")
                {
                    finalChoice = playerChoiceLC;
                    runningStatus = false;
                }
                else if (playerChoiceLC == "paper")
                {
                    finalChoice = playerChoiceLC;
                    runningStatus = false;
                }
                else if (playerChoiceLC == "scissors")
                {
                    finalChoice = playerChoiceLC;
                    runningStatus = false;
                }
                else
                {
                    Console.WriteLine("Please select Rock, Paper, or Scissors.");
                    newChoice = Console.ReadLine();
                    playerChoiceLC = newChoice.ToLower();
                }
            }
            return finalChoice;
        }

        static int weaponNumberGenerator()
        {
            var rand = new Random();
            int numSelect = rand.Next(1, 9);
            return numSelect;
        }

        static string computerPicksWeapon(int randNum)
        {
            string weaponName;

            if (randNum <= 3)
            {
                weaponName = "rock";
            }
            else if (randNum > 3 && randNum <= 6)
            {
                weaponName = "paper";
            }
            else
            {
                weaponName = "scissors";
            }
            return weaponName;
        }

        static void championDecider(string myWeapon, string enemyWeapon)
        {
            if (myWeapon == enemyWeapon)
            {
                Console.WriteLine("Game is a draw");
            }

            else if (myWeapon == "rock")
            {
                if (enemyWeapon == "paper")
                {
                    Console.WriteLine("Computer wins :(");
                }
                else
                {
                    Console.WriteLine("You win! :D");
                }
            }

            else if (myWeapon == "paper")
            {
                if (enemyWeapon == "scissors")
                {
                    Console.WriteLine("Computer wins :(");
                }
                else
                {
                    Console.WriteLine("You win! :D");
                }
            }

            else if (myWeapon == "scissors")
            {
                if (enemyWeapon == "rock")
                {
                    Console.WriteLine("Computer wins :(");
                }
                else
                {
                    Console.WriteLine("You win! :D");
                }
            }

        }

        static bool playAgain()
        {
            bool nextRound = false;
            bool decisionLoop = true;
            string playerDecision = Console.ReadLine();
            string playerDecisionLC = playerDecision.ToLower();
            string newAnswer;
            

            Console.WriteLine("Do you want to play again?");

            while (decisionLoop)
            {
                if (playerDecisionLC == "y")
                {
                    nextRound = true;
                    decisionLoop = false;
                }
                else if (playerDecisionLC == "n")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter 'Y' to play again or 'N' to exit");
                    newAnswer = Console.ReadLine();
                    playerDecisionLC = newAnswer.ToLower();
                } 
            }
            return nextRound;
        }
    }
}