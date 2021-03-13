using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public abstract class AbstractFrameFactory
    {
        protected abstract Frame MakeSingleFrame();
        protected abstract Frame MakeSpecialFrame();
        public Frame CreateSingleFrame()
        {
            return this.MakeSingleFrame();
        }      
        public Frame CreateSpecialFrame()
        {
            return this.MakeSpecialFrame();
        }
    }
}
