namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Player
    {
        private string playerName;

        private int playerPoints;

        public Player(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name
        {
            get
            {
                return this.playerName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be left empty!");
                }

                this.playerName = value;
            }
        }

        public int Points
        {
            get
            {
                return this.playerPoints;
            }

            set
            {
                this.playerPoints = value;
            }
        }
    }
}
