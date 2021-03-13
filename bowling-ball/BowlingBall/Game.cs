using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        #region variables
        private FrameFactory frameFactory;
        private int countFrame = 1;
        private SpecialFrame specialFrame = null;
        private SingleFrame singleFrame = null;
        List<Frame> framesList = new List<Frame>();
        #endregion
        public int CountFrame { get => countFrame; set => countFrame = value; }

        public Game()
        {
            frameFactory = new FrameFactory();
        }

        public void Roll(int pins)
        {
            if (pins == 10)
            {
                if (CountFrame == 10)
                {
                    if (specialFrame != null)
                    {
                        if (specialFrame.SecondRollScore == -1)
                            specialFrame.SecondRollScore = pins;
                        else if (specialFrame.ThirdRollScore == -1)
                        {
                            specialFrame.ThirdRollScore = pins;
                            framesList.Add(specialFrame);
                        }
                    }
                    else
                    {
                        specialFrame = (SpecialFrame)frameFactory.CreateSpecialFrame();
                        specialFrame.FirstRollScore = 10;
                    }
                }
                else
                {
                    singleFrame = (SingleFrame)frameFactory.CreateSingleFrame();
                    singleFrame.FirstRollScore = 10;
                    singleFrame.strikeType = StrikeType.STRIKE;
                    framesList.Add(singleFrame);
                    CountFrame++;
                    singleFrame = null;
                }
            }
            else
            {              
                if (CountFrame != 10)
                {
                    singleFrame = singleFrame ?? (SingleFrame)frameFactory.CreateSingleFrame();
                    if (singleFrame.FirstRollScore == -1)
                        singleFrame.FirstRollScore = pins;
                    else
                    {
                        singleFrame.SecondRollScore = pins;
                        framesList.Add(singleFrame);
                        singleFrame.strikeType = singleFrame.FirstRollScore + singleFrame.SecondRollScore == 10 ? StrikeType.SPARE : StrikeType.PINSLEFT;
                        CountFrame = (CountFrame < 10) ? (CountFrame + 1) : CountFrame;
                        singleFrame = null;
                    }
                }
                else
                {
                    specialFrame = specialFrame ?? (SpecialFrame)frameFactory.CreateSpecialFrame();
                    if (specialFrame.FirstRollScore == -1)
                        specialFrame.FirstRollScore = pins;
                    else if (specialFrame.SecondRollScore == -1)
                    {
                        specialFrame.SecondRollScore = pins;
                        if(!(specialFrame.FirstRollScore == 10 || (specialFrame.FirstRollScore + specialFrame.SecondRollScore == 10)))
                            framesList.Add(specialFrame);
                    }
                    else
                    {
                        specialFrame.ThirdRollScore = pins;
                        framesList.Add(specialFrame);
                    }
                }
            }            
        }

        public int GetScore()
        {
            int score = 0;
            Frame frame = null;
            for (int i = 0; i < framesList.Count; i++)
            {
                frame = framesList[i];
                if (i == 9)
                {
                    SpecialFrame sframe = (SpecialFrame)frame;
                    score = score + frame.Score();
                    Console.WriteLine(score);
                }
                else
                {
                    SingleFrame singleFrame = (SingleFrame)frame;
                    if (singleFrame.strikeType == StrikeType.STRIKE)
                    {
                        score = score + 10;                        
                        if ((framesList[i + 1]).strikeType == StrikeType.SPARE)
                        { 
                            score = score + 10;                            
                        }
                        else if(framesList[i + 1].strikeType == StrikeType.STRIKE)
                        {
                            score = score + 10 + framesList[i + 2].FirstRollScore;           
                        }
                        else
                        {
                            score = score + framesList[i + 1].FirstRollScore + framesList[i + 1].SecondRollScore;
                        }

                    }
                    else if (frame.strikeType == StrikeType.SPARE)
                    {
                        score = score + 10 + (framesList[i + 1]).FirstRollScore;
                        Console.WriteLine(score);
                    }
                    else
                    {
                        score = score + frame.Score();
                        Console.WriteLine(score);
                    }

                }
            }
            return score;
        }
    }
}
