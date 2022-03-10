﻿using System;
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
            

        }

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