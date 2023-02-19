using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeeseGameAstonHacks
{
    class Poop
    {
        public Color color;
        public int x, y, size;

        public Poop(int _x, int _y, int _size, Color _color)
        {
            x = _x;
            y = _y;
            size = _size;
            color = _color;
        }

        public void Move(int speed)
        {
            y += speed + 7;
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
