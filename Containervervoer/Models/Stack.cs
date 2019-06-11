using System;
using System.Collections.Generic;
using System.Text;

namespace Containervervoer2
{
    public enum BalansPosition { Left = 0, Middle = 1, Right = 2 };
    public class Stack
    {
        // Fields
        public int StackID { get; set; }
        public List<Container> Containers { get; set; }
        public BalansPosition BalansPosition { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        // Constructors
        public Stack()
        {

        }
    }
}
