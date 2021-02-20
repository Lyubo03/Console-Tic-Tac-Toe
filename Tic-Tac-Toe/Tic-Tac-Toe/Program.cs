using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    //When you save the file in file doi it in loop. When you end the game delete the containing in the file to restrart the leve of the game!
    //Only in case "Computer"
    //Write something to remove wrong pressing (It's very annoying)
    class Program
    {
        static void Intializing(char[,] board)
        {
            // Initializing spaces between symbol and border
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }
        static void PrintBoard(char[,] board)
        {
            //board printing
            Console.WriteLine("  | 0 | 1 | 2 |");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " | ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            ContinueAfterWin:;
            char[,] board = new char[3, 3];
            int counter = 0;
            char playerOne = ' ';
            char playerTwo = ' ';
            int row, col;
            bool win = false;
            char symbolPicker;
            char computer = ' ';
            char currentPlayer = playerOne;
            Random r = new Random();
            Mistake:;
            Console.WriteLine("Do you wanna play with friend or vs the computer? (Type Computer or Friend)");
            string computerOrFriend = Console.ReadLine();
            switch (computerOrFriend)
            {
                case "Computer":
                    //Picking symbol
                    Console.WriteLine("Let's pick a symbol. (Type X or O)");
                    symbolPicker = char.Parse(Console.ReadLine());
                    Intializing(board);
                    currentPlayer = playerOne;
                    while (symbolPicker != 'X' || symbolPicker != 'O')
                    {
                        if (symbolPicker == 'X' || symbolPicker == 'O')
                        {
                            Console.WriteLine("You decided to play " + symbolPicker + "! :D");
                            playerOne = symbolPicker;
                            if (playerOne == 'O')
                            {
                                computer = 'X';
                            }
                            else
                            {
                                computer = 'O';
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong symbol, buddy!");
                            symbolPicker = char.Parse(Console.ReadLine());
                        }
                        goto Continue;
                    }
                    Continue:;
                    while (true)
                    {
                        Console.Clear();
                        PrintBoard(board);
                        counter++;
                        if (currentPlayer == playerOne)
                        {
                            Stealer:;
                            SomethingW:;
                            
                                Console.WriteLine("Please, enter a row: ");
                                row = int.Parse(Console.ReadLine());
                                Console.WriteLine("Please, enter a colum: ");
                                col = int.Parse(Console.ReadLine());
                                if (currentPlayer == board[row, col] && playerOne == board[row, col] || computer == board[row, col])
                                {
                                    Console.WriteLine("Pussy! :D");
                                    goto Stealer;
                                }
                                board[row, col] = currentPlayer;
                            counter++;
                            currentPlayer = computer;
                        }
                        else
                        {
                            StealerPC:;
                            row = r.Next(3);
                            col = r.Next(3);
                            if (currentPlayer == board[row, col] && computer == board[row, col] || playerOne == board[row, col])
                            {
                                goto StealerPC;
                            }
                            board[row, col] = currentPlayer;
                            counter++;
                            currentPlayer = playerOne;
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            if (currentPlayer == board[i, 0] && currentPlayer == board[i, 1] && currentPlayer == board[i, 2])
                            {
                                Console.WriteLine("Oh yeah " + currentPlayer + " win!;");
                                win = true;
                            }
                            if (currentPlayer == board[0, i] && currentPlayer == board[1, i] && currentPlayer == board[i, 2])
                            {
                                Console.WriteLine("Oh yeah " + currentPlayer + " win!;");
                                win = true;
                            }
                        }
                        if (currentPlayer == board[0, 0] && currentPlayer == board[1, 1] && currentPlayer == board[2, 2] || currentPlayer == board[0, 2] && currentPlayer == board[1, 1] && currentPlayer == board[2, 0])
                        {
                            Console.WriteLine("Oh yeah " + currentPlayer + " win!;");
                            win = true;
                        }
                        if (counter == 9)
                        {
                            Console.WriteLine("We don't have a winer(boring). It's draw!");
                            goto ContinueAfterWin;
                        }
                        if (win == true)
                        {
                            WrongTyped:;
                            Console.WriteLine("Do you want to play again?\nType (yes or no)");
                            string question = Console.ReadLine();
                            switch (question)
                            {
                                case "yes": goto ContinueAfterWin;
                                case "no":
                                    Console.WriteLine("Bye! :D");
                                    return;
                                default: goto WrongTyped;
                            }
                        }
                    }
                case "Friend":
                    //Player One is picking symbol
                    Console.WriteLine("Let's first player pick his symbol (X or O)\nWrite it with caps");
                    symbolPicker = char.Parse(Console.ReadLine());
                    while (symbolPicker != 'X' || symbolPicker != 'O')
                    {
                        if (symbolPicker == 'X' || symbolPicker == 'O')
                        {
                            Console.WriteLine("Player one decided to play " + symbolPicker + "! :D");
                            playerOne = symbolPicker;
                            if (symbolPicker == 'X')
                            {
                                playerTwo = 'O';
                            }
                            else
                            {
                                playerTwo = 'X';
                            }
                            goto CONTINUE;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong symbol, buddy!");
                            symbolPicker = char.Parse(Console.ReadLine());
                        }
                    }
                    CONTINUE:;
                    currentPlayer = playerOne;
                    //Final point;
                    Intializing(board);
                    while (true)
                    {
                        Console.Clear();
                        Stealer:;
                        PrintBoard(board);
                        Console.Write("Please enter a row: ");
                        SomethingW:;
                        row = int.Parse(Console.ReadLine());
                        Console.Write("Please enter a colum: ");
                        col = int.Parse(Console.ReadLine());
                        if (row != 0 || row != 1 || row != 2 || col != 0 || col != 1 || col != 2)
                        {
                            Console.WriteLine("Something's wrong! ");
                            goto SomethingW;
                        }
                        if (currentPlayer == board[row, col] && playerTwo == board[row, col] || playerOne == board[row, col])
                        {
                            Console.Clear();
                            Console.WriteLine("Don't try to steal, mate! It is inappropriate!");
                            goto Stealer;
                        }
                        board[row, col] = currentPlayer;
                        counter++;

                        // Do i win?
                        for (int rowCh = 0; rowCh < 3; rowCh++)
                        {
                            if (currentPlayer == board[rowCh, 0] && currentPlayer == board[rowCh, 1] && currentPlayer == board[rowCh, 2])
                            {
                                Console.WriteLine("Congrats! You won this game player " + currentPlayer + "! :D");
                                win = true;
                            }
                            else if (currentPlayer == board[0, rowCh] && currentPlayer == board[1, rowCh] && currentPlayer == board[2, rowCh])
                            {
                                Console.WriteLine("Congrats! You won this game player " + currentPlayer + "! :D");
                                win = true;
                            }
                            else if (currentPlayer == board[0, 0] && currentPlayer == board[1, 1] && currentPlayer == board[2, 2])
                            {
                                Console.WriteLine("Congrats! You won this game player " + currentPlayer + "! :D");
                                win = true;
                            }
                            else if (currentPlayer == board[0, 2] && currentPlayer == board[1, 1] && currentPlayer == board[2, 0])
                            {
                                Console.WriteLine("Congrats! You won this game player " + currentPlayer + "! :D");
                                win = true;
                            }
                            //You already know :D
                        }
                        if (counter == 9)
                        {
                            Console.WriteLine("Draw. Both of you are stupid! ");
                            win = true;
                        }
                        //Switch between players
                        if (currentPlayer == playerOne)
                        {
                            currentPlayer = playerTwo;
                        }
                        else
                        {
                            currentPlayer = playerOne;
                        }
                        if (win == true)
                        {
                            WrongTyped:;
                            Console.WriteLine("Do you want to play again?\nType (yes or no)");
                            string question = Console.ReadLine();
                            switch (question)
                            {
                                case "yes": goto ContinueAfterWin;
                                case "no":
                                    Console.WriteLine("Bye! :D");
                                    return;
                                default: goto WrongTyped;
                            }
                        }
                    }
                default:
                    goto Mistake;
            }
        }
    }
}



