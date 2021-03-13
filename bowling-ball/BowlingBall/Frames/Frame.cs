using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public abstract class Frame
    {
        private int firstRollScore;
        private int secondRollScore;
        public StrikeType strikeType;
        public int FirstRollScore { get => firstRollScore; set => firstRollScore = value; }
        public int SecondRollScore { get => secondRollScore; set => secondRollScore = value; }        
        public abstract int Score();

    }
}
