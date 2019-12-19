using System;
using System.Collections.Generic;

namespace sudokuSolver
{
    class Program
    {
        static int[,] sBoard = new int[,]{
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };
        static int[,] sBoard2 = new int[,]{
            {0, 0, 0, 4, 0, 1, 6, 3, 0},
            {8, 0, 0, 3, 6, 0, 0, 0, 2},
            {3, 6, 9, 0, 0, 0, 0, 7, 0},
            {0, 2, 5, 0, 0, 0, 0, 0, 9},
            {0, 0, 3, 0, 5, 2, 8, 0, 0},
            {0, 4, 0, 6, 0, 0, 7, 0, 0},
            {2, 0, 7, 0, 0, 6, 0, 0, 0},
            {4, 0, 0, 0, 7, 0, 0, 9, 0},
            {0, 0, 0, 0, 0, 8, 5, 1, 7}
        };
        static int[,] sBoardFail = new int[,]{
            {5, 3, 7, 0, 7, 0, 0, 0, 0},
            {6, 0, 7, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 8, 6, 0, 8, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };
        static bool SolveSudoku(int[,] board)
        {
            int _row = -1;
            int _col = -1;
            bool isEmpty = true;

            for(int row = 0; row < board.GetLength(0); row++)
            {
                for(int col = 0; col < board.GetLength(0); col++)
                {
                    if(board[row, col] == 0)
                    {
                        
                        _row = row;
                        _col = col;

                        isEmpty = false;
                        break;
                    }
                }
                if(!isEmpty)
                    break;
            }
            if(isEmpty)
                return true;

            for(int test = 1; test <= board.GetLength(0); test++)
            {
                if(IsValid(board))
                {
                    int[,] newBoard = board;
                    newBoard[_row, _col] = test;

                    if(_row == 8 && _col == 4)
                        Console.WriteLine("BUG");

                    if(SolveSudoku(newBoard))
                    {
                        return true;
                    }
                    else
                    {
                        board[_row, _col] = 0;
                    }
                }
            }
            return false;
        }
        static void PrintOut(int[,] board)
        {
            for(int row = 0; row < board.GetLength(0); row++)
            {
                for(int col = 0 ; col < board.GetLength(0); col++)
                {
                    Console.Write(board[row, col]);
                    
                }
                Console.WriteLine();
            }
        }
        static bool IsValid(int[,] board)
        {
            if(!IsValidInHorizontal(board))
                return false;
            if(!IsValidInVertical(board))
                return false;
            if(!IsValidInSection(board))
                return false;

            return true;
        }
        static bool IsValidInHorizontal(int[,] board)
        {
            for(int row = 0; row < board.GetLength(0); row++)
            {
                for(int col = 0; col < board.GetLength(0); col++)
                {
                    for(int i = col + 1; i < board.GetLength(0); i++)
                    {
                        if(board[row, col] == board[row, i] && board[row, col] != 0)
                        {
                        if(row == 8 && col == 4)
                            Console.WriteLine("BUG");

                            Console.WriteLine($"number {board[row, col]} is duplicate on this row");
                            return false;
                        }
                    }
                }
            }
            Console.WriteLine("all rows are valid horizontally");
            return true;
        }
        static bool IsValidInVertical(int[,] board)
        {
            for(int col = 0; col < board.GetLength(0); col++)
            {
                for(int row = 0; row < board.GetLength(0); row++)
                {
                    for(int i = row + 1; i < board.GetLength(0); i++)
                    {
                        if(board[row, col] == board[i, col] && board[row, col] != 0)
                        {
                            Console.WriteLine($"number {board[row, col]} is duplicate on this vertical row");
                            return false;
                        }
                    }
                }
            }
            Console.WriteLine("all rows are valid vertically");
            return true;
        }
        static bool IsValidInSection(int[,] board)
        {
            int[] section = new int[]{0, 3, 6};

            //goes through each section
            foreach(int secRow in section)
            {
                foreach(int secCol in section)
                {

                    List<int> intBox = new List<int>();

                    for(int row = 0; row < 3; row++)
                    {
                        for(int col = 0; col < 3; col++)
                        {
                            
                            intBox.Add(board[row + secRow, col + secCol]);

                            if(intBox.Count == 9)
                            {
                                if(HaveDuplicates(intBox.ToArray()))
                                {
                                    Console.WriteLine("there is a section/sections with duplicates");
                                    return false;    
                                }

                                intBox = new List<int>();
                            }
                        {

                    }

                }
            }}}
            Console.WriteLine("sections are valid");
            return true;
        }
        static bool HaveDuplicates(int[] array)
        {
            for(int x = 0; x < array.Length; x++)
            {
                for(int y = x + 1; y < array.Length; y++)
                {
                    if(array[x] == array[y] && array[x] != 0)
                        return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            if(IsValid(sBoard))
            {
                Console.WriteLine("first test passed!");
            }
            if(!IsValid(sBoardFail))
            {
                Console.WriteLine("second test passed!");
            }
            if(SolveSudoku(sBoard2))
                PrintOut(sBoard2);
            else
                Console.WriteLine("No Solution");

            if(IsValid(sBoard2))
                Console.WriteLine("board 2 IS VALID");
            else
                Console.WriteLine("board 2 Is Not Valid");
            Console.ReadLine();
        }
    }
}
