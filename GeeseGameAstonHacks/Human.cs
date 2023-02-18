using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace GeeseGameAstonHacks
{
    class Human
    {
        public int x, y, playerSize, speed;

        public Human(int _x, int _y, int _speed, int _playerSize)
        {
            x = _x;
            y = _y;
            speed = _speed;
            playerSize = _playerSize;
        }

        public void Move(string direction)
        {
            //true represents right
            if (direction == "right")
            {
                x += speed;
            }
            else if (direction == "left")
            {
                x -= speed;
            }

            else if (direction == "up")
            {
                y -= speed * 5;
            }

            else if (direction == "down")
            {
                y += speed * 5;
            }
        }
    }
}
