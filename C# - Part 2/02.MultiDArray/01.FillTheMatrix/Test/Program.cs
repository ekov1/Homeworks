using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static char[,] lab =
    {
        {' ',' ',' ','*',' ',' ',' '},
        {'*','*',' ','*',' ','*',' '},
        {' ',' ',' ',' ',' ',' ',' '},
        {' ','*','*','*','*','*',' '},
        {' ',' ',' ',' ',' ',' ','e'},
    };
    static int count = 0;
    static void FindExit(int row, int col)
    {
        if (col < 0 || row < 0 ||
            col >= lab.GetLength(1) ||
            row >= lab.GetLength(0))
        {
            //Out of labyrinth
            return;
        }

        if (lab[row, col] == 'e')
        {
            //Found path
            count++;
            Console.WriteLine(count);
            return;
        }

        if (lab[row, col] != ' ')
        {
            //Current cell is taken
            return;
        }

        //Mark current cell as visited
        lab[row, col] = 's';

        //Recursion for all possible directions
        FindExit(row, col - 1); //Left
        FindExit(row - 1, col); //Up
        FindExit(row, col + 1); //Right
        FindExit(row + 1, col); //Down

        //Mark back current cell as free
        lab[row, col] = ' ';
    }

    static void Main()
    {
        FindExit(0, 0);
    }
}