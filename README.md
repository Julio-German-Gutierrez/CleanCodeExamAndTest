# Clean Code - "Exam and Test"

![image](tittle_image.jpg)

## Table of contents
* [.NET Clean Code Examination](#.net-clean-code-examination)
* [The Program](#the-program)
* [The Task](#the-task)
* [Refactoring](#refactoring)
* [Testning](#testning)
* [Original Smelly Code](#original-smelly-code)
* [My Solution](#my-solution)
* [Overview](#overview)
* [The New Refactoring](#the-new-refactoring)
* [Final Thoughts](#final-thoughts)


## .NET Clean Code Examination
The Clean Code test is solved individually. The examination will be taken in two parts. The first one will be written (by submitting code and report files) and the second one oral. Both reports are required for Approval. The written report should be about a A4 page which briefly describes the refactorings and other improvements made. During the oral presentation, the program must be able to run and all refactoring and tests must be able to be described, discussed and justified.

### The Program
The code to be refactored and tested is deliberately full of code smells but works in normal use. It implements the game "Moo", which is a Mastermind-like game where the program randomly produces a four-digit string that the player must guess, with as few guesses as possible. The random string is guaranteed to have four unique digits. The player guesses with four numbers. In response, the game shows a number of B's and C's (bulls and cows). A "B" for each number that has been put in the correct place and a "C" for each number that is in the four but is in the wrong place. "B," therefore means that one of four numbers in the guess is correct and is in the correct place (but you don't find out which one is correct). ",CCC" means that three guessed numbers are present, but none of them are in the correct place. "BBBB," is thus the goal and then the round is over.

Play a few times with a "cheat printout" of the hidden number so you can understand the rules. The player may make guesses with non-unique numbers if they wish, but the target always has four unique ones. After each game, the average number of guesses of all players is printed in a leaderboard, ordered by best guess average. The game keeps statistics of completed games in a file, from which the leaderboard is calculated and printed after each game.

### The Task
The task for the examination is to refactor the program by identifying code smells and minimize/eliminate them as well as to make the code parts testable for unit testing and write tests that test the program's logic.

### Refactoring
The program must be made "more beautiful" by performing refactoring on appropriate parts. If any design pattern is appropriate to use, do so. The different layers of the program that manage, user interface, program logic, statistics collection/accounting, must be separated and the parts must not know anything about the other parts other than an interface and must use Dependency Injection for assembly of the parts. Concrete object creation and assembly of the parts can be handled with manual code in the main method/class.

### Testning
Tests must be written for the program logic code. Since it calls IO and UI code, these may need to be Mock-Object-implemented to be able to perform the tests. Perhaps the method that generates the random numbers also needs to be mocked, so that tests on the program logic can be performed with known "random" numbers.

## Original Smelly Code
``` C#
using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
	class MainClass
	{

		public static void Main(string[] args)
		{

			bool playOn = true;
			Console.WriteLine("Enter your user name:\n");
			string name = Console.ReadLine();

			while (playOn)
			{
				string goal = makeGoal();

				
				Console.WriteLine("New game:\n");
				//comment out or remove next line to play real games!
				Console.WriteLine("For practice, number is: " + goal + "\n");
				string guess = Console.ReadLine();
				
				int nGuess = 1;
				string bbcc = checkBC(goal, guess);
				Console.WriteLine(bbcc + "\n");
				while (bbcc != "BBBB,")
				{
					nGuess++;
					guess = Console.ReadLine();
					Console.WriteLine(guess + "\n");
					bbcc = checkBC(goal, guess);
					Console.WriteLine(bbcc + "\n");
				}
				StreamWriter output = new StreamWriter("result.txt", append: true);
				output.WriteLine(name + "#&#" + nGuess);
				output.Close();
				showTopList();
				Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
				string answer = Console.ReadLine();
				if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
				{
					playOn = false;
				}
			}
		}
		static string makeGoal()
		{
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				goal = goal + randomDigit;
			}
			return goal;
		}

		static string checkBC(string goal, string guess)
		{
			int cows = 0, bulls = 0;
			guess += "    ";     // if player entered less than 4 chars
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (goal[i] == guess[j])
					{
						if (i == j)
						{
							bulls++;
						}
						else
						{
							cows++;
						}
					}
				}
			}
			return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
		}


		static void showTopList()
		{
			StreamReader input = new StreamReader("result.txt");
			List<PlayerData> results = new List<PlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				PlayerData pd = new PlayerData(name, guesses);
				int pos = results.IndexOf(pd);
				if (pos < 0)
				{
					results.Add(pd);
				}
				else
				{
					results[pos].Update(guesses);
				}
				
				
			}
			results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
			Console.WriteLine("Player   games average");
			foreach (PlayerData p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
			}
			input.Close();
		}
	}

	class PlayerData
	{
		public string Name { get; private set; }
        public int NGames { get; private set; }
		int totalGuess;
		

		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			NGames = 1;
			totalGuess = guesses;
		}

		public void Update(int guesses)
		{
			totalGuess += guesses;
			NGames++;
		}

		public double Average()
		{
			return (double)totalGuess / NGames;
		}

		
	    public override bool Equals(Object p)
		{
			return Name.Equals(((PlayerData)p).Name);
		}

		
	    public override int GetHashCode()
        {
			return Name.GetHashCode();
		}
	}
}
```

## My Solution
Julio Gutierrez

### Overview
I decided to divide the program in four parts:<br/>
* The Multigame Platform -> (MultiConsoleGames)
* The Games -> (MastermindGame & NumberMaster Dummy)
* The Views -> (ConsoleViews IViews)
* The Logic -> (FourDigitsLogic ILogic)
* The Data Access -> (FileData IData)

![image](code-clean-exam.jpg)

### The New Refactoring
The MastermindGame (Game class) controls the flow of the program and it does it through its dependencies (Injected). It handles basic information like the player’s name, guesses and attempts, the game’s goal, etc. It uses its dependencies (abstractions) to interact with the user (IViews), consult game’s logic (ILogic) and to read and write the score data (IData).

Each of these three implementations (Views, Logic and Data) are stateless. The game data is administrated by the MastermindGame class. With this design, one could create a mobile or WPF version and would only need to implement the IViews interface. In the same spirit, it would only take an implementation of ILogic to create or update the game’s logic. The same abstraction applies to the data access.

## Final Thoughts
It is very difficult to address all the work done in a short one page document, as this is supposed to be. I hope the code will be self explanatory.
