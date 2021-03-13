using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class SpecialFrame : Frame
    {
        public SpecialFrame()
        {
            this.FirstRollScore = -1;
            this.SecondRollScore = -1;
            this.ThirdRollScore = -1;
            this.strikeType = StrikeType.SPECIALFRAME;
        }

        private int thirdRollScore;
        public int ThirdRollScore { get => thirdRollScore; set => thirdRollScore = value; }

        public override int Score()
        {
            return (this.FirstRollScore > -1 ? this.FirstRollScore : 0) +
                   (this.SecondRollScore > -1 ? this.SecondRollScore : 0) +
                   (this.ThirdRollScore > -1 ? this.ThirdRollScore : 0);
        }

    }
}
