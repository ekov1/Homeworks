namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Globals;
    using Models;

    public class MinesStartup
    {
        public static void Main()
        {
            string command = string.Empty;

            char[,] gameField = CreateGameField();
            char[,] fieldBombs = SetupFieldBombs();
            List<Player> players = new List<Player>();

            int openedCells = 0;
            int row = 0;
            int col = 0;
            bool isDead = false;
            bool restartGame = true;
            bool isWinner = false;

            do
            {
                if (restartGame)
                {
                    Console.WriteLine(GlobalConstants.IntroGameMessage);

                    DrawGameBoard(gameField);
                    restartGame = false;
                }

                Console.Write(GlobalConstants.InputCommandMessage);
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= gameField.GetLength(0) && col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case GlobalConstants.LeaderboardCommand:

                        GetLeaderboard(players);
                        break;
                    case GlobalConstants.RestartGameCommand:

                        gameField = CreateGameField();
                        fieldBombs = SetupFieldBombs();
                        DrawGameBoard(gameField);

                        isDead = false;
                        restartGame = false;
                        break;
                    case GlobalConstants.ExitGameCommand:

                        Console.WriteLine(GlobalConstants.ExitMessage);
                        break;
                    case GlobalConstants.PlayTurnCommand:

                        if (fieldBombs[row, col] != GlobalConstants.BombCellChar)
                        {
                            if (fieldBombs[row, col] == GlobalConstants.EmptyCellChar)
                            {
                                PlayTurn(gameField, fieldBombs, row, col);
                                openedCells++;
                            }

                            if (GlobalConstants.MaxOpenedCells == openedCells)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                DrawGameBoard(gameField);
                            }
                        }
                        else
                        {
                            isDead = true;
                        }

                        break;
                    default:
                        Console.WriteLine(Environment.NewLine + GlobalConstants.InvalidCommandMessage);
                        break;
                }

                if (isDead)
                {
                    DrawGameBoard(fieldBombs);
                    Console.Write(
                        Environment.NewLine +
                        GlobalConstants.LoserMessage +
                        Environment.NewLine +
                        GlobalConstants.InputNicknameMessage,
                        openedCells);

                    string nickName = Console.ReadLine();
                    Player player = new Player(nickName, openedCells);

                    if (players.Count < 5)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < player.Points)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    GetLeaderboard(players);

                    gameField = CreateGameField();
                    fieldBombs = SetupFieldBombs();
                    openedCells = 0;
                    isDead = false;
                    restartGame = true;
                }

                if (isWinner)
                {
                    Console.WriteLine(Environment.NewLine + GlobalConstants.WinnerMessage);
                    DrawGameBoard(fieldBombs);
                    Console.WriteLine(GlobalConstants.InputNicknameMessage);

                    string playerName = Console.ReadLine();
                    Player player = new Player(playerName, openedCells);
                    players.Add(player);

                    GetLeaderboard(players);

                    gameField = CreateGameField();
                    fieldBombs = SetupFieldBombs();
                    openedCells = 0;
                    isWinner = false;
                    restartGame = true;
                }
            }
            while (command != GlobalConstants.ExitGameCommand);

            Console.Read();
        }

        private static void GetLeaderboard(List<Player> players)
        {
            var builder = new StringBuilder();

            builder.AppendLine();
            builder.AppendLine(GlobalConstants.LeaderboardPlayers);

            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    builder.AppendLine(string.Format(GlobalConstants.LeaderboardPlayerMessage, i + 1, players[i].Name, players[i].Points));
                }

                builder.AppendLine();
            }
            else
            {
                builder.AppendLine(GlobalConstants.EmptyLeaderboardMessage);
            }

            Console.WriteLine(builder.ToString());
        }

        private static void PlayTurn(char[,] field, char[,] bombs, int row, int col)
        {
            char bombCount = GetBombCount(bombs, row, col);

            bombs[row, col] = bombCount;
            field[row, col] = bombCount;
        }

        private static void DrawGameBoard(char[,] board)
        {
            var builder = new StringBuilder();

            builder.AppendLine();
            builder.AppendLine(GlobalConstants.FieldColumnNumber);
            builder.AppendLine(GlobalConstants.FieldBorder);

            for (int i = 0; i < GlobalConstants.BoardRows; i++)
            {
                builder.AppendFormat("{0} {1} ", i, GlobalConstants.BoarderSeparator);

                for (int j = 0; j < GlobalConstants.BoardCols; j++)
                {
                    builder.AppendFormat("{0} ", board[i, j]);
                }

                builder.AppendLine(GlobalConstants.BoarderSeparator);
            }

            builder.AppendLine(GlobalConstants.FieldBorder);

            Console.WriteLine(builder.ToString());
        }

        private static char[,] CreateGameField()
        {
            char[,] board = new char[GlobalConstants.BoardRows, GlobalConstants.BoardCols];

            for (int i = 0; i < GlobalConstants.BoardRows; i++)
            {
                for (int j = 0; j < GlobalConstants.BoardCols; j++)
                {
                    board[i, j] = GlobalConstants.UnknownCellChar;
                }
            }

            return board;
        }

        private static char[,] SetupFieldBombs()
        {
            char[,] gameField = new char[GlobalConstants.BoardRows, GlobalConstants.BoardCols];

            for (int i = 0; i < GlobalConstants.BoardRows; i++)
            {
                for (int j = 0; j < GlobalConstants.BoardCols; j++)
                {
                    gameField[i, j] = GlobalConstants.EmptyCellChar;
                }
            }

            var bombCellNumbers = GenerateBombCellNumbers();

            foreach (int bombNumber in bombCellNumbers)
            {
                int row = bombNumber % GlobalConstants.BoardCols;
                int col = bombNumber / GlobalConstants.BoardCols;

                if (row == 0 && bombNumber != 0)
                {
                    col--;
                    row = GlobalConstants.BoardRows;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = GlobalConstants.BombCellChar;
            }

            return gameField;
        }

        private static List<int> GenerateBombCellNumbers()
        {
            var bombCellNumbers = new List<int>();

            while (bombCellNumbers.Count < GlobalConstants.MaxBombsToGenerate)
            {
                var random = new Random();
                int cellNumber = random.Next(GlobalConstants.TotalCellNumber);

                if (!bombCellNumbers.Contains(cellNumber))
                {
                    bombCellNumbers.Add(cellNumber);
                }
            }

            return bombCellNumbers;
        }

        private static char GetBombCount(char[,] bombs, int row, int col)
        {
            int count = 0;
            int bombRows = bombs.GetLength(0);
            int bombCols = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, col] == GlobalConstants.BombCellChar)
                {
                    count++;
                }
            }

            if (row + 1 < bombRows)
            {
                if (bombs[row + 1, col] == GlobalConstants.BombCellChar)
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (bombs[row, col - 1] == GlobalConstants.BombCellChar)
                {
                    count++;
                }
            }

            if (col + 1 < bombCols)
            {
                if (bombs[row, col + 1] == GlobalConstants.BombCellChar)
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bombs[row - 1, col - 1] == GlobalConstants.BombCellChar)
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < bombCols))
            {
                if (bombs[row - 1, col + 1] == GlobalConstants.BombCellChar)
                {
                    count++;
                }
            }

            if ((row + 1 < bombRows) && (col - 1 >= 0))
            {
                if (bombs[row + 1, col - 1] == GlobalConstants.BombCellChar)
                {
                    count++;
                }
            }

            if ((row + 1 < bombRows) && (col + 1 < bombCols))
            {
                if (bombs[row + 1, col + 1] == GlobalConstants.BombCellChar)
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
