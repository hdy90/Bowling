using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Model
{
    public class Frame
    {
        private int _firstThrow { get; set; }
        private int _secondThrow { get; set; }

        public Frame() 
        {
            
        }

        public void AddPins(int firstThrow, int secondThrow)
        {
            _firstThrow = firstThrow;
            _secondThrow = secondThrow;
        }

        public bool IsStrike()
        {
            return (_firstThrow == 10);
        }

        public bool IsSpare()
        {
            return _firstThrow + _secondThrow == 10;
        }

        public int FrameSum()
        {
            return _firstThrow + _secondThrow;
        }

        public int FirstThrown()
        {
            return _firstThrow;
        }
    }
}
