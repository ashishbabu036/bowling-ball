using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class FrameFactory : AbstractFrameFactory
    {
        protected override Frame MakeSingleFrame()
        {
            Frame frame = new SingleFrame();
            return frame;
        }

        protected override Frame MakeSpecialFrame()
        {
            Frame frame = new SpecialFrame();
            return frame;
        }
    }    
}
