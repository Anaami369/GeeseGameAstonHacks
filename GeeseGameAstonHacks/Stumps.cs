using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeseGameAstonHacks
{
    class Stumps
    {
        public int x, y, size;

        public Stumps(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }

        public void Move(int speed)
        {
            x += speed + 7;
        }
    }
}
