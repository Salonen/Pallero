using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peli1
{
    class Pallero
    {
        private int xspeed, yspeed, x, y;

        public Pallero(int xs,int ys, int xx, int yy)
        {
            this.xspeed = xs;
            this.yspeed = ys;
            this.x = xx;
            this.y = yy;
        }

        public int Xspeed
        {
            get
            {
                return xspeed;
            }
            set
            {
                xspeed = value;
            }
        }
        public int Yspeed
        {
            get
            {
                return yspeed;
            }
            set
            {
                yspeed = value;
            }
        }
        public int Xpal
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Ypal
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

    }
}
