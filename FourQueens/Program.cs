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
            bool queenWasPlaced;

            for (n = 2; n < 10; n++)
            {
                Console.WriteLine();
                Console.WriteLine($"n:{n}");
                
                chessBoard = new int[n, n];

                InitializeChessBoard();

                queenWasPlaced = PlaceQueen(1);
                Console.WriteLine($"Queen {1} was placed: {queenWasPlaced}");

                queenWasPlaced = PlaceQueen(2);
                Console.WriteLine($"Queen {2} was placed: {queenWasPlaced}");

                queenWasPlaced = PlaceQueen(3);
                Console.WriteLine($"Queen {3} was placed: {queenWasPlaced}");

                queenWasPlaced = PlaceQueen(4);
                Console.WriteLine($"Queen {4} was placed: {queenWasPlaced}");

                Console.WriteLine();
                Console.WriteLine($"Chessboard:");
                DisplayChessBoard();
                Console.WriteLine("-------------------------------------------------");
            }
        }

        private static bool PlaceQueen(int queen)
        {
            bool queenWasSuccessfullyPlaced = false;

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    bool isPositionOccupied = IsPositionOccupied(row, column);

                    bool isPositionClear = IsPositionClear(row, column);

                    if (!isPositionOccupied && isPositionClear)
                    {
                        chessBoard[row, column] = queen;
                        queenWasSuccessfullyPlaced = true;
                        return true;
                    }
                }
            }

            return queenWasSuccessfullyPlaced;
        }

        private static bool IsPositionOccupied(int row, int column)
        {
            return chessBoard[row, column] > 0;
        }

        private static bool IsPositionClear(int row, int column)
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
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    Console.WriteLine($"[{row},{column}] : {chessBoard[row, column]}");
                }
            }

        }
    }
}
