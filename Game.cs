using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Casino
{
    class Game
    {
		private static int[] deck = new int[15] { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
        public static bool Blackjack()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("The rules are:");
            Console.WriteLine("1. You will play against the dealer.");
            Console.WriteLine("2. You will be given 1 card.");
            Console.WriteLine("3. You can accept the hand or request extra cards.");
            Console.WriteLine("4. In order to win, you must have a higher total than the dealer, without exceeding 21.");
            Console.WriteLine("Ready to start the game?");
            Console.WriteLine("Press Y for yes: ");
            char option = Console.ReadLine()[0];
			while (option != 'Y')
            {
                Console.WriteLine("Wrong character! Introduce it again: ");
                option = Console.ReadLine()[0];
			}
            Console.Clear();
            return drawingCardsBlackjack();
        }
		private static bool drawingCardsBlackjack()
        {
			char option = 'Y';
			int[] playerCards = new int[21];
			int playerSum = 0;
			int dealerSum = 0;
			int i = 0;
			while (option == 'Y')
			{
				Console.WriteLine("The card you drew is: ");
				Random rd = new Random();
				int verifyCard = rd.Next(2, 14);
				while (deck[verifyCard] == 0)
				{
					verifyCard = rd.Next(2, 14);
				}
				switch (verifyCard)
				{
					case 14:
						Console.Write("K");
						break;
					case 13:
						Console.Write("Q");
						break;
					case 12:
						Console.Write("J");
						break;
					case 11:
						Console.Write("A");
						break;
					case 1:
						Console.Write("A");
						break;
					default:
						Console.Write(verifyCard);
						break;
				}
				if (verifyCard == 11)
                {
					Console.WriteLine("\nDo you wish to use it as 1 or 11?");
					Console.Write("Press A for 1 or B for 11: ");
					char c = Console.ReadLine()[0];
					while (c != 'A' && c != 'B')
                    {
						Console.WriteLine("Wrong character! Introduce it again: ");
						c = Console.ReadLine()[0];
					}
					if(c == 'A')
                    {
						deck[verifyCard]--;
						verifyCard = 1;
                    }
                }
				deck[verifyCard]--;
				playerCards[i] = verifyCard;
				playerSum += verifyCard;
				verifyCard = rd.Next(2, 14);
				while (deck[verifyCard] == 0)
				{
					verifyCard = rd.Next(2, 14);
				}
				if(verifyCard == 11)
                {
					if(dealerSum + verifyCard > 21)
                    {
						deck[verifyCard]--;
						verifyCard = 1;
                    }
                }
				deck[verifyCard]--;
				dealerSum += verifyCard;
				i++;
				if (dealerSum > 21 || playerSum > 21)
				{
					Console.WriteLine("\nOof! You lost! Better luck next time!");
					return false;
				}
				Console.WriteLine("\nDo you wish to draw one more card?");
				Console.Write("Press Y for yes and N for n: ");
				option = Console.ReadLine()[0];
				while (option != 'Y' && option != 'N')
				{
					Console.WriteLine("Wrong character! Introduce it again: ");
					option = Console.ReadLine()[0];
				}
				if (playerSum > 21 || dealerSum > 21)
				{
					option = 'N';
				}
			}
			for (int j = 0; i <= 15; i++)
			{
				deck[j] = 4;
			}
			if (dealerSum > 21 && playerSum > 21)
			{
				Console.WriteLine("Oof! You lost! Better luck next time!");
				return false;
			}
			else if ((playerSum > 21 && dealerSum <= 21)
				|| (playerSum <= 21 && dealerSum <= 21 && playerSum < dealerSum))
			{
				Console.WriteLine("Oof! You lost! Better luck next time!");
				Console.WriteLine("The dealer had a sum of " + dealerSum + ".");
				return false;
			}
			else
			{
				Console.Write("Congrats! You won!");
				return true;
			}
		}
		public static bool NumberGuessing()
        {
			Console.Clear();
			Console.WriteLine("Welcome to the Number Guessing game!");
			Console.WriteLine("The rules are:");
			Console.WriteLine("1. Choose a number between 1 and 10.");
			Console.WriteLine("2. Guess the correct number and win 5 times the betting amount.");
			Console.WriteLine("3. Wrong bet and you will lose the amount you bet.");
			Console.WriteLine("Good luck!");
			Console.Write("Enter your number: ");
			int guess = int.Parse(Console.ReadLine());
			Random rd = new Random();
			int dice = rd.Next(1, 10);
			if (dice == guess)
			{
				Console.WriteLine("You won! Your balance will be updated shortly.");
				return true;
			}
			else
			{
				Console.WriteLine("Wrong! The correct number was " + dice + "!");
				Console.Write("Better luck next time!");
				return false;
			}
		}
		public static bool Pokies()
        {
			Console.Clear();
			Console.WriteLine("Welcome to the Pokies game!");
			Console.WriteLine("The rules are:");
			Console.WriteLine("1. We will generate 9 random symbols.");
			Console.WriteLine("2. You win if there is at least a line (horizontally, vertically or diagonally) of the same 3 symbols.");
			Console.WriteLine("3. Your win depends on the number of lines and the symbols.");
			//Console.WriteLine("Here are the winnings for each symbol: ");
			//Console.WriteLine("\ta) A line of 7 values 50$.");
			//Console.WriteLine("\ta) A line of 7 values 50$.");
			//Console.WriteLine("\ta) A line of 7 values 50$.");
			Console.Write("Are you ready to start the game? Press Y for yes: ");
			char option = Console.ReadLine()[0];
			while (option != 'Y')
			{
				Console.WriteLine("Wrong character! Introduce it again: ");
				option = Console.ReadLine()[0];
			}
			Console.Clear();
			int[,] matrix = new int[3, 3];
			Random rd = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
					matrix[i, j] = rd.Next(1, 10);
                }
            }
            Console.WriteLine("The generated symbols are: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    switch (matrix[i, j])
                    {
                        case 1:
							Console.Write("&  ");
                            break;
                        case 2:
							Console.Write("#  ");
							break;
						case 3:
							Console.Write("$  ");
							break;
						case 4:
							Console.Write("*  ");
							break;
						case 5:
							Console.Write("@  ");
							break;
						case 6:
							Console.Write("!  ");
							break;
						case 7:
							Console.Write("7  ");
							break;
						case 8:
							Console.Write("+  ");
							break;
						case 9:
							Console.Write("-  ");
							break;
						default:
							Console.Write("=  ");
							break;
					}
                }
				Console.WriteLine();
            }
			for(int i = 0; i < 3; i++)
            {
				int j = 0;
				if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i, j + 2])
				{
					Console.WriteLine("Congratulations! You won.");
					return true;
				}
			}
			if((matrix[0, 0] == matrix[1, 1] && matrix[0, 0] == matrix[2, 2]) || 
				(matrix[0, 2] == matrix[1, 1] && matrix[0, 2] == matrix[2, 0]))
            {
				Console.WriteLine("Congratulations! You won.");
				return true;
            }
			for (int j = 0; j < 3; j++)
            {
				int i = 0;
				if (matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 2, j])
				{
					Console.WriteLine("Congratulations! You won.");
					return true;
				}
			}
			Console.WriteLine("Better luck next time!");
			return false;
		}
    }
}
