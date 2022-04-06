using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Casino
{
    class Casino
    {
        private static Player player;
        public static void displayMenuAndHandlingTheGame()
        {
			Console.WriteLine("Welcome!");
			Console.Write("Introduce the player name: ");
			string name = Console.ReadLine();
			Console.Write("Introduce the starting balance: ");
			float balance = float.Parse(Console.ReadLine());
			player = new Player(name, balance);
			char continueGame = 'Y';
			while (continueGame == 'Y')
			{
				char c = choosingGame();
				float bettingAmount = bettingConsole();
				Console.Write("Let the games begin!");
				if (playingTheGame(c) == true)
				{
					switch (c)
					{
						case '1':
							player.updateBalance(bettingAmount * 5, '+');
							break;
						case '2':
							player.updateBalance(bettingAmount * 5, '+'); 
							break;
						case '3':
							player.updateBalance(bettingAmount * 5, '+');
							break;
					}
				}
				else
				{
					player.updateBalance(bettingAmount, '-');
				}
				Console.WriteLine("\nPlayer " + player.Name + ", your new balance is " + player.Balance + "$.");
				if (player.Balance > 0)
				{
					Console.WriteLine("Do you want to play again?");
					Console.Write("Press Y for yes and N for no: ");
					continueGame = Console.ReadLine()[0];
					while (continueGame != 'Y' && continueGame != 'N')
					{
						Console.Write("Wrong character! Introduce it again: ");
						continueGame = Console.ReadLine()[0];
					}
				}
				else
				{
					continueGame = 'N';
					Console.WriteLine("Your balance is 0$! You can't play anymore! See you next time!");
				}
			}
		}
		private static char choosingGame()
        {
			Console.Clear();
			Console.WriteLine("Select one of the following numbers in order to play a game: ");
			Console.WriteLine("1. Blackjack");
			Console.WriteLine("2. Number guessing");
			Console.WriteLine("3. Pokies");
			char c = Console.ReadLine()[0];
			while (c != '1' && c != '2' && c != '3')
			{
				Console.Write("Incorrect character/number. Introduce it again: ");
				c = Console.ReadLine()[0];
			}
			return c;
		}
		private static float bettingConsole()
        {
			Console.WriteLine("How much do you bet?");
			float amount = float.Parse(Console.ReadLine());
			while (amount > player.Balance)
			{
				Console.WriteLine("You can't bet more than you have in your balance!");
				Console.WriteLine("Your current balance is: " + player.Balance + "$!");
				Console.WriteLine("Introduce again the amount: ");
				amount = float.Parse(Console.ReadLine());
			}
			return amount;
		}
		private static bool playingTheGame(char c)
        {
			switch (c)
			{
				case '1':
					return Game.Blackjack();
					break;
				case '2':
					return Game.NumberGuessing();
					break;
				case '3':
					return Game.Pokies();
					break;
				default:
					return Game.NumberGuessing();
					break;
			}
		}
    }
}
