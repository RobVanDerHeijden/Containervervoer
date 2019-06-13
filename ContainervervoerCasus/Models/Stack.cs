using System.Collections.Generic;

namespace ContainervervoerCasus.Models
{
    
    public class Stack
    {
        protected static int Increment;
        // Fields
        public int StackID { get; set; }
        public List<Container> Containers { get; set; }
        public BalansPosition BalansPosition { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        // Constructors
        public Stack(int row, int column, BalansPosition balansPosition)
        {
            StackID = Increment;
            Row = row;
            Column = column;
            BalansPosition = balansPosition;
            Increment++;
        }

        public override string ToString()
        {
            return "[Row: " + Row + "] [Column: " + Column + "]";
        }
    }
}
