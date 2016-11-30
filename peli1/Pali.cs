using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peli1
{
    //int[,] pali = new int[10, 10];
    //int[,] pali = new int[10, 10];
    
    class Pali
    {
        List<List<int>> pal = new List<List<int>>();

        public Pali()
        {
        }


        public List<List<int>> Pal
        {
            get
            {
                return pal;
            }
            set
            {
                pal = value;
            }
        }


    }
}
