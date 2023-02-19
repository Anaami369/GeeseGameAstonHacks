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
        public Color color;
        public int x, y, size;

        public Egg(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
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
