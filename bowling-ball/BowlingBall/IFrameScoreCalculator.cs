using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    interface iFrameScoreCalculator
    {
        int CalculateScoreFromFrames(List<Frame> framesList);
    }
}
