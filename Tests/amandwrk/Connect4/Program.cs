using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct playerDetail
{
    public String playerName;
    public char playerID;
};

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            playerDetail playerOne = new playerDetail();
            playerDetail playerTwo = new playerDetail();
            char[,] board = new char[9, 10];
            int placeChoice, winFlag, fullBoardFlag, exitFlag;
            
            Console.WriteLine("Player1 name: ");
            playerOne.playerName = Console.ReadLine();
            playerOne.playerID = 'X';
            Console.WriteLine("Player2 name: ");
            playerTwo.playerName = Console.ReadLine();
            playerTwo.playerID = 'O';

            fullBoardFlag = 0;
            winFlag = 0;
            exitFlag = 0;

            DisplayBoard(board);

            do
            {
                if (exitFlag != 1)
                {
                    placeChoice = PlayerChoice(board, playerOne);
                    PlaceTokenBellow(board, playerOne, placeChoice);
                    DisplayBoard(board);
                    winFlag = CheckFour(board, playerOne);
                    if (winFlag == 1)
                    {
                        PlayerWin(playerOne);

                        exitFlag = 1;
                    }
                }
                if (exitFlag != 1)
                {
                    placeChoice = PlayerChoice(board, playerTwo);
                    PlaceTokenBellow(board, playerTwo, placeChoice);
                    DisplayBoard(board);
                    winFlag = CheckFour(board, playerTwo);
                    if (winFlag == 1)
                    {
                        PlayerWin(playerTwo);

                        exitFlag = 1;
                    }
                }
                if (exitFlag != 1)
                {
                    fullBoardFlag = FullBoard(board);
                    if (fullBoardFlag == 7)
                    {
                        Console.WriteLine("The board is full, it is a draw!");

                        exitFlag = 1;
                    }
                }
            } while (exitFlag != 1);

            Console.WriteLine("Press a key to exit Connect4.....");
            Console.ReadKey();
        }
        static int PlayerChoice(char[,] board, playerDetail activePlayer)
        {
            int placeChoice;

            Console.WriteLine(activePlayer.playerName + "'s Turn ");
            do
            {
                Console.WriteLine("Enter a number between 1 and 7: ");
                placeChoice = Convert.ToInt32(Console.ReadLine());
            } while (placeChoice < 1 || placeChoice > 7);

            while (board[1, placeChoice] == 'X' || board[1, placeChoice] == 'O')
            {
                Console.WriteLine("Row is full, enter a new row: ");
                placeChoice = Convert.ToInt32(Console.ReadLine());
            }

            return placeChoice;
        }

        static void PlaceTokenBellow(char[,] board, playerDetail activePlayer, int placeChoice)
        {
            int length, turn;
            length = 6;
            turn = 0;

            do
            {
                if (board[length, placeChoice] != 'X' && board[length, placeChoice] != 'O')
                {
                    board[length, placeChoice] = activePlayer.playerID;
                    turn = 1;
                }
                else
                    --length;
            } while (turn != 1);


        }

        static void DisplayBoard(char[,] board)
        {
            int rows = 6;
            int columns = 7;
            int i, j;

            for (i = 1; i <= rows; i++)
            {
                for (j = 1; j <= columns; j++)
                {
                    if (board[i, j] != 'X' && board[i, j] != 'O')
                        board[i, j] = '*';

                    Console.Write(board[i, j]);

                }

                Console.Write("\n");
            }

        }

        static int CheckFour(char[,] board, playerDetail activePlayer)
        {
            char XO;
            int winFlag;

            XO = activePlayer.playerID;
            winFlag = 0;

            for (int i = 8; i >= 1; --i)
            {

                for (int j = 9; j >= 1; --j)
                {

                    if (board[i, j] == XO &&
                        board[i - 1, j - 1] == XO &&
                        board[i - 2, j - 2] == XO &&
                        board[i - 3, j - 3] == XO)
                    {
                        winFlag = 1;
                    }


                    if (board[i, j] == XO &&
                        board[i, j - 1] == XO &&
                        board[i, j - 2] == XO &&
                        board[i, j - 3] == XO)
                    {
                        winFlag = 1;
                    }

                    if (board[i, j] == XO &&
                        board[i - 1, j] == XO &&
                        board[i - 2, j] == XO &&
                        board[i - 3, j] == XO)
                    {
                        winFlag = 1;
                    }

                    if (board[i, j] == XO &&
                        board[i - 1, j + 1] == XO &&
                        board[i - 2, j + 2] == XO &&
                        board[i - 3, j + 3] == XO)
                    {
                        winFlag = 1;
                    }

                    if (board[i, j] == XO &&
                         board[i, j + 1] == XO &&
                         board[i, j + 2] == XO &&
                         board[i, j + 3] == XO)
                    {
                        winFlag = 1;
                    }
                }

            }

            return winFlag;
        }

        static int FullBoard(char[,] board)
        {
            int fullBoardFlag;
            fullBoardFlag = 0;
            for (int i = 1; i <= 7; ++i)
            {
                if (board[1, i] != '*')
                    ++fullBoardFlag;
            }

            return fullBoardFlag;
        }

        static void PlayerWin(playerDetail activePlayer)
        {
            Console.WriteLine("------- "+activePlayer.playerName + " Connected Four, You win! -------");
        }
    }
}