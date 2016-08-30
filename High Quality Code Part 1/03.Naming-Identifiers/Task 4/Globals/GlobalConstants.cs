namespace Minesweeper.Globals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GlobalConstants
    {
        // Table data constants
        public const int BoardRows = 5;

        public const int BoardCols = 10;

        public const int MaxOpenedCells = 35;

        public const int TotalCellNumber = 50;

        public const int MaxBombsToGenerate = 15;

        public const char UnknownCellChar = '?';

        public const char BombCellChar = '*';

        public const char EmptyCellChar = '-';

        public const string FieldBorder = "   ---------------------";

        public const string FieldColumnNumber = "    0 1 2 3 4 5 6 7 8 9";

        public const string BoarderSeparator = "|";

        // Message contants
        public const string IntroGameMessage = "Minesweeper Game. Try to find all cells without a bomb!\n" +
                        " Commands are: 'top' to show Leaderboard,'x y' to pick a cell,\n 'restart' to start new game, 'exit' to exit game.";

        public const string WinnerMessage = "Congratulations!!! You finished the game untouched!";

        public const string InputNicknameMessage = "Nickname: ";

        public const string LoserMessage = "Hrrrrrr! You got killed! Cells opened : {0}";

        public const string InvalidCommandMessage = "Invalid command!";

        public const string InputCommandMessage = "Input command : ";

        public const string ExitMessage = "Thank you for playing!";

        public const string LeaderboardPlayers = "Players:";

        public const string EmptyLeaderboardMessage = "Leaderboard is empty!";

        public const string LeaderboardPlayerMessage = "{0}. {1} --> {2} cells opened";

        // Command constants
        public const string LeaderboardCommand = "top";

        public const string RestartGameCommand = "restart";

        public const string ExitGameCommand = "exit";

        public const string PlayTurnCommand = "turn";
    }
}
