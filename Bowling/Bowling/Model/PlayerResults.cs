using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bowling.Model
{
    public class PlayerResults
    {
        public string PlayerName { get; set; }
        public List<int> Throws { get; set; }
        private List<Frame> Frames {get;set;}
        public string ResultsInRoundsFormatted { get => String.Join("  |  ", Throws); }
        public int Sum { get => CalculateResults(); }

        public PlayerResults()
        {
            Throws = new List<int>();
            Frames = new List<Frame>(); 
        }

        private int CalculateResults()
        {
            FillFrames();
            return GetScore();
        }

        private int GetScore()
        {
            int res = 0;
            for (int i = 0; i < Frames.Count - 1; i++)
            {
                Frame frame = Frames[i];

                if (!frame.IsStrike() && !frame.IsSpare())
                {
                    res += frame.FrameSum();
                    continue;
                }

                if (frame.IsSpare())
                {
                    res += frame.FrameSum() + Frames[i + 1].FirstThrown();
                    continue;
                }

                if (frame.IsStrike())
                {
                    res += frame.FrameSum() + Frames[i + 1].FrameSum();
                    continue;
                }
            }

            return res;
        }

        private void FillFrames()
        {
            int throwIdx = 0;
            for (int i = 0; i < 11; i++)
            {
                var frame = new Frame();

                if (Throws.Count <= throwIdx) 
                {
                    Frames.Add(frame);
                    continue;
                }

                if (GetThrowValue(throwIdx) == 10)
                {
                    frame.AddPins(10, 0);
                    throwIdx += 1;
                }
                else
                {
                    frame.AddPins(GetThrowValue(throwIdx), GetThrowValue(throwIdx + 1));
                    throwIdx += 2;
                }
                
                Frames.Add(frame);
            }
        }

        private int GetThrowValue(int idx)
        {
            return Throws.ElementAtOrDefault(idx);
        }

    }        
}
