using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class BuildArray
    {
        private Build[] array;

        public BuildArray()
        {
            array = new Build[10];
        }

        public Build this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }
    }
}
