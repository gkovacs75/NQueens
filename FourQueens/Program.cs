using System;
using System.Drawing;

namespace FourQueens
{
    internal class Program
    {
        private static int n;
        private static int[,]? chessBoard;

        static void Main(string[] args)
        {
            for (n = 2; n < 10; n++)
            {
                Console.WriteLine();
                Console.WriteLine($"# n:{n}");

                chessBoard = new int[n, n];

                InitializeChessBoard();

                bool allQueensPlaced = PlaceQueen(n);
                Console.WriteLine($"## All Queens were placed: {allQueensPlaced}");

                Console.WriteLine();
                Console.WriteLine($"## Chessboard:");

                DisplayChessBoard();
            }
        }

        private static bool PlaceQueen(int curentQueenToPlace)
        {
            if (curentQueenToPlace == 0)
            {
                return true; // No more queens to place
            }

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    bool isPositionOccupied = IsPositionOccupied(row, column);

                    bool isPositionClear = IsPositionSafe(row, column);

                    if (!isPositionOccupied && isPositionClear)
                    {
                        chessBoard[row, column] = curentQueenToPlace;

                        if (PlaceQueen(curentQueenToPlace - 1))
                        {
                            return true;
                        }
                        else
                        {
                            // Remove current queen
                            chessBoard[row, column] = 0;
                        }
                    }
                }
            }

            return false;
        }

        private static bool IsPositionOccupied(int row, int column)
        {
            return chessBoard[row, column] > 0;
        }

        private static bool IsPositionSafe(int row, int column)
        {
            // 1. Is there already a queen on this row?
            for (int c = 0; c < n; c++)
            {
                if (chessBoard[row, c] > 0)
                {
                    return false;
                }
            }

            // 2. Is there already a queen on this column?
            for (int r = 0; r < n; r++)
            {
                if (chessBoard[r, column] > 0)
                {
                    return false;
                }
            }

            // 3. Is there already a queen on this diagonal?
            bool isUpAndLeftClear = IsDiagonalUpAndLeftClear(row - 1, column - 1);
            bool isDownAndLeftClear = IsDiagonalDownAndLeftClear(row + 1, column - 1);
            bool isUpAndRightClear = IsDiagonalUpAndRightClear(row - 1, column + 1);
            bool isDownAndRightClear = IsDiagonalDownAndRightClear(row + 1, column + 1);

            if (!isUpAndLeftClear || !isDownAndLeftClear || !isUpAndRightClear || !isDownAndRightClear)
            {
                return false;
            }

            return true;
        }

        private static bool IsDiagonalUpAndLeftClear(int row, int column)
        {
            if (!IsOutOfBounds(row, column))
            {
                if (chessBoard[row, column] == 0)
                {
                    return IsDiagonalUpAndLeftClear(row - 1, column - 1);
                }
                else
                {
                    return false; // Queen already here
                }
            }
            else
            {
                return true; // Out of bounds, no queens found
            }
        }

        private static bool IsDiagonalDownAndLeftClear(int row, int column)
        {
            if (!IsOutOfBounds(row, column))
            {
                if (chessBoard[row, column] == 0)
                {
                    return IsDiagonalDownAndLeftClear(row + 1, column - 1);
                }
                else
                {
                    return false; // Queen already here
                }
            }
            else
            {
                return true; // Out of bounds, no queens found
            }
        }

        private static bool IsDiagonalUpAndRightClear(int row, int column)
        {
            if (!IsOutOfBounds(row, column))
            {
                if (chessBoard[row, column] == 0)
                {
                    return IsDiagonalUpAndRightClear(row - 1, column + 1);
                }
                else
                {
                    return false; // Queen already here
                }
            }
            else
            {
                return true; // Out of bounds, no queens found
            }
        }

        private static bool IsDiagonalDownAndRightClear(int row, int column)
        {
            if (!IsOutOfBounds(row, column))
            {
                if (chessBoard[row, column] == 0)
                {
                    return IsDiagonalUpAndRightClear(row + 1, column + 1);
                }
                else
                {
                    return false; // Queen already here
                }
            }
            else
            {
                return true; // Out of bounds, no queens found
            }
        }

        private static bool IsOutOfBounds(int row, int column)
        {
            return row < 0 || column < 0 || row > (n - 1) || column > (n - 1);
        }

        private static void InitializeChessBoard()
        {
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    chessBoard[row, column] = 0;
                }
            }
        }

        private static void DisplayChessBoard()
        {
            for (int column = 0; column < n; column++)
            {
                Console.Write($"{column}");

                if (column < (n - 1))
                {
                    Console.Write($" | ");
                }
            }

            Console.WriteLine();

            for (int column = 0; column < n; column++)
            {
                Console.Write($":---:");

                if (column < (n - 1))
                {
                    Console.Write($" | ");
                }
            }

            Console.WriteLine();

            string q;

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    if (chessBoard[row, column] > 0)
                    {
                        q = $"Q{chessBoard[row, column]}";
                    }
                    else
                    {
                        q = "";
                    }

                    Console.Write($" [{row},{column}]:{q} ");

                    if (column < (n - 1))
                    {
                        Console.Write($" | ");
                    }
                }

                Console.WriteLine();
            }

        }
    }
}
