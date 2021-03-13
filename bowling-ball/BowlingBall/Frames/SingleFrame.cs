using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class SingleFrame : Frame
    {
        public SingleFrame()
        {
            this.FirstRollScore = -1;
            this.SecondRollScore = -1;
        }     

        public override int Score()
        {            
            return (this.FirstRollScore > -1 ? this.FirstRollScore : 0) +
                (this.SecondRollScore > -1 ? this.SecondRollScore : 0);
        }
    }
}
