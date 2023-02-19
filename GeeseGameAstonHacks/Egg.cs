using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeeseGameAstonHacks
{
    class Egg
    {
        public int x, y, height, width;

        public Egg(int _x, int _y, int _height, int _width)
        {
            x = _x;
            y = _y;
            height = _height;
            width = _width;
        }

        public void Move(string direction, int speed)
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
