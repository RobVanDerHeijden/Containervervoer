using System;
using System.Collections.Generic;
using System.Text;

namespace Containervervoer2
{
    public class Container
    {
        // Fields
        public int ContainerID { get; set; }
        public int Weight { get; set; }
        public int MinimumWeight { get; set; }
        public int MaximumWeight { get; set; }
        public int MaximumCarryWeight { get; set; }
        public int IsCarying { get; set; }

        // Constructors
        public Container()
        {

        }
    }
}
