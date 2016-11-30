using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peli1
{
    [Serializable()]
    class Kentta
    {
        List<List<int>> lt = new List<List<int>>();

        public List<List<int>> Lt
        {
            get
            {
                return lt;
            }
            set
            {
                lt = value;
            }
        }
    }
}