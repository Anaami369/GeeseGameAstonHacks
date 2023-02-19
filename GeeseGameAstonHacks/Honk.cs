using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeseGameAstonHacks
{
    class Honk
    {
        public int x, y, height, width, speed;
        public Honk(int _x, int _y, int _height, int _width, int _speed)
        {
            x = _x;
            y = _y;
            height = _height;
            width = _width;
            speed = _speed;
        }

        public void GeeseMove(int speed)
        {
            x += speed;
        }
    }
}
