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
            bool isRunning; // bool variable for keeping the game running;
            string playerWeapon; // store the player's entry of R,P,S;
            int weaponNumber; // store the random num for computer to select R,P,S;
            string computerWeapon; // store the computer's choice of R,P,S;
            var (playerWins, computerWins, draws, victoryMessage) = (false, false, false, " "); // store the bool vals to help the victory counter;
            int totalDraws = 0; // will be used to store total # of Draws;
            int totalPlayerWins = 0; // will be used to store total # of player wins;
            int totalComputerWins = 0; // will be used to store total # of computer wins;

            Console.WriteLine("Do you want to play Rock, Paper, Scissors?");
            Console.WriteLine("Enter Y to play or N to exit");
            Console.WriteLine(); // spacing

            isRunning = playGame(); // determine if player wants to play. Y = continue, N = exit, invalid = reprompt;
            Console.WriteLine("********************** Fight Area **********************"); // spacing
            Console.WriteLine(); // spacing

            do
            {
                playerWeapon = playerPicksWeapon(); // prompt user for a valid entry of R,P,S;
                weaponNumber = weaponNumberGenerator(); // random number generator: provides integer to be passed into a method to make a selection;
                computerWeapon = computerPicksWeapon(weaponNumber); // selects R,P,S based on the random number generated;

                Console.WriteLine(); // spacing
                Console.WriteLine($"You: {playerWeapon}"); // feedback to user;
                Console.WriteLine($"Computer: {computerWeapon}"); // feedback to user;
                Console.WriteLine(); // spacing

                championDecider(playerWeapon, computerWeapon); // Determine who the victor is based on user input and comp selection;
                playerWins = championDecider(playerWeapon, computerWeapon).Item1; //param to pass into victoryCounter();
                computerWins = championDecider(playerWeapon, computerWeapon).Item2; //param to pass into victoryCounter();
                draws = championDecider(playerWeapon, computerWeapon).Item3; //param to pass into victoryCounter();
                victoryMessage = championDecider(playerWeapon, computerWeapon).Item4; //param to pass into victoryCounter();

                Console.WriteLine(victoryMessage); //Display who won the match;
                Console.WriteLine(); // spacing;
                Console.WriteLine("********************** Statistics ***********************");
                Console.WriteLine(); // spacing;

                victoryCounter(playerWins, computerWins, draws); // It counts the number of draws and victories;
                totalDraws += victoryCounter(playerWins, computerWins, draws).Item1; // allows the continuous update of # of draws every match;
                totalPlayerWins += victoryCounter(playerWins, computerWins, draws).Item2; // allows the continuous update of # of player wins every match;
                totalComputerWins += victoryCounter(playerWins, computerWins, draws).Item3; // allows the continuous update of # of computer wins every match;

                Console.WriteLine($"Total Draws: {totalDraws}");
                Console.WriteLine($"Your Victories: {totalPlayerWins}");
                Console.WriteLine($"Computer Victories: {totalComputerWins}");

                isRunning = playAgain(); // play again? Prompt the user and restart the game;
            } while (isRunning);
        }

        static bool playGame()
        {

            //Continously prompt the user for a valid entry of Y or N;
            //put their response into a variable that allows some flexibility of how they enter Y or N;
            //if no valid entry -> ask user to enter it again;

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

            // Continously prompt user for R,P,S;
            // if no valid entry, keep asking them for a valid entry;
            // added toLowercase for some flexibility;

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

            //generate a random number between 1-9;

            var rand = new Random();
            int numSelect = rand.Next(1, 9);
            return numSelect;
        }

        static string computerPicksWeapon(int randNum)
        {
            //determine a weapon choice based off the number passed into the method;

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

        static (bool, bool, bool, string) championDecider(string myWeapon, string enemyWeapon)
        {

            // determine win conditions based on user's weapon choice;
            // return a string to announce who won;
            // return boolean values to assist the victoryCounter method;

            (bool playerWins, bool computerWins, bool draws) winners = (false, false, false);
            string victoryMessage = " ";

            if (myWeapon == enemyWeapon)
            {
                victoryMessage = "Game is a draw";
                winners.draws = true;
                winners.playerWins = false;
                winners.computerWins = false;

            }

            else if (myWeapon == "rock")
            {
                if (enemyWeapon == "paper")
                {
                    victoryMessage = "Computer wins :(";
                    winners.draws = false;
                    winners.playerWins = false;
                    winners.computerWins = true;

                }
                else
                {
                    victoryMessage = "You win! :D";
                    winners.draws=false;
                    winners.computerWins=false;
                    winners.playerWins=true;
                }
            }

            else if (myWeapon == "paper")
            {
                if (enemyWeapon == "scissors")
                {
                    victoryMessage = "Computer wins :(";
                    winners.draws = false;
                    winners.playerWins = false;
                    winners.computerWins = true;
                }
                else
                {
                    victoryMessage = "You win! :D";
                    winners.draws = false;
                    winners.computerWins = false;
                    winners.playerWins = true;
                }
            }

            else if (myWeapon == "scissors")
            {
                if (enemyWeapon == "rock")
                {
                    victoryMessage = "Computer wins :(";
                    winners.draws = false;
                    winners.playerWins = false;
                    winners.computerWins = true;
                }
                else
                {
                    victoryMessage = "You win! :D";
                    winners.draws = false;
                    winners.computerWins = false;
                    winners.playerWins = true;
                }
            }
            return (winners.playerWins, winners.computerWins, winners.draws, victoryMessage);
        }

        static (int, int, int) victoryCounter(bool playerWon, bool computerWon, bool gameTied)
        {
            // return integers of respective draws, player wins, and computer wins;
            // take in the boolean values from championDecider();
            // every loop iteration should reset the values and return the completed set of integers;
            // the final values will be +='d to a variable in Main so everything doesn't get reset;

            int numOfDraws = 0;
            int numOfPlayerWins = 0;
            int numOfComputerWins = 0;

            if (gameTied == true)
            {
                numOfDraws++;
            }
            else if(playerWon == true)
            {
                numOfPlayerWins++;
            }
            else
            {
                numOfComputerWins++;
            }
            return (numOfDraws, numOfPlayerWins, numOfComputerWins);
        }

        static bool playAgain()
        {
            // Continously Prompt the user for a valid entry if they want to play again;
            // Should be similar to the initial playGame() method;
            // the return value should be assigned to the value that is in the WHILE portion of the Do-while loop;

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Do you want to play again?");
            Console.WriteLine("Enter 'Y' to play again or 'N' to exit");

            bool nextRound = false;
            bool decisionLoop = true;
            string playerDecision = Console.ReadLine();
            string playerDecisionLC = playerDecision.ToLower();
            string newAnswer;


            

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