using System;

namespace Selling
{
    class Program
    {
        static char[][] matrix;

        static string command;

        static int playerRow;
        static int playerCol;

        static int pillarRow;
        static int pillarCol;

        static int moneyCounter;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            InitializeMatrix(n, matrix);

            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                }
            }
        }



        private static void InitializeMatrix(int n, char[][] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                char[] currentInput = Console.ReadLine()
                    .ToCharArray();
                matrix[row] = currentInput;

                for (int col = 0; col < currentInput.Length; col++)
                {
                    if (currentInput[col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (currentInput[col] == 'O')
                    {
                        pillarRow = row;
                        pillarCol = col;
                    }
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Length
                && col >= 0 && col < matrix.Length;
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void Move(int row, int col)
        {
            if (IsInside(playerRow + row, playerCol + col))
            {
                if (matrix[playerRow][playerCol] == 'S')
                {
                    matrix[playerRow][playerCol] = '-';
                }

                playerRow += row;
                playerCol += col;
                char currentChar = matrix[playerRow][playerCol];

                if (matrix[playerRow][playerCol] == '-')
                {
                    matrix[playerRow][playerCol] = 'S';
                }

                if (Char.IsDigit(currentChar))
                {
                    int val = (int)Char.GetNumericValue(currentChar);
                    moneyCounter += val;
                    matrix[playerRow][playerCol] = 'S';

                    if (moneyCounter >= 50)
                    {
                        Console.WriteLine($"Good news! You succeeded in collecting enough money!");
                        Console.WriteLine($"Money: {moneyCounter}");
                        PrintMatrix();
                        Environment.Exit(0);
                    }
                }

                else if (matrix[playerRow][playerCol] == 'O')
                {
                    matrix[playerRow][playerCol] = '-';

                    for (int rows = 0; rows < matrix.Length; rows++)
                    {
                        for (int cols = 0; cols < matrix[rows].Length; cols++)
                        {
                            if (matrix[rows][cols] == 'O')
                            {
                                matrix[rows][cols] = 'S';
                                playerRow = rows;
                                playerCol = cols;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                matrix[playerRow][playerCol] = '-';
                Console.WriteLine($"Bad news, you are out of the bakery.");
                Console.WriteLine($"Money: {moneyCounter}");
                PrintMatrix();
                Environment.Exit(0);
            }
        }
    }
}
