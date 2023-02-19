using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeseGameAstonHacks
{
    class Stump
    {
        public int x, y, height, width, speed;
        public Stump(int _x, int _y, int _height, int _width, int _speed)
        {
            x = _x;
            y = _y;
            height = _height;
            width = _width;
            speed = _speed;
        }

        public void Move(int speed)
        {
            x -= speed;
        }

        public void Move(string direction)
        {
            //true represents right
            if (direction == "right")
            {
                x -= speed;
            }
            else if (direction == "left")
            {
                x += speed;
            }
        }
    }
}
