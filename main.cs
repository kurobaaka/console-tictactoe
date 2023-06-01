using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            InitializeBoard();

            while (true)
            {
                DrawBoard();

                Console.WriteLine("Player " + currentPlayer + ", enter your move (row[0-2] column[0-2]):");
                string input = Console.ReadLine();

                if (input == "exit")
                    break;

                if (!MakeMove(input))
                {
                    Console.WriteLine("Invalid move, try again.");
                    continue;
                }

                if (CheckForWin())
                {
                    DrawBoard();
                    Console.WriteLine("Player " + currentPlayer + " wins!");
                    break;
                }

                if (CheckForDraw())
                {
                    DrawBoard();
                    Console.WriteLine("It's a draw!");
                    break;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool MakeMove(string input)
        {
            string[] coordinates = input.Split(' ');

            if (coordinates.Length != 2)
                return false;

            if (!int.TryParse(coordinates[0], out int row) || !int.TryParse(coordinates[1], out int col))
                return false;

            if (row < 0 || row >= 3 || col < 0 || col >= 3)
                return false;

            if (board[row, col] != ' ')
                return false;

            board[row, col] = currentPlayer;
            return true;
        }

        static bool CheckForWin()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] != ' ' && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                    return true;
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] != ' ' && board[0, col] == board[1, col] && board[1, col] == board[2, col])
                    return true;
            }

            // Check diagonals
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;

            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            return false;
        }

        static bool CheckForDraw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                        return false;
                }
            }

            return true;
        }
    }
}
