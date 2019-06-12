using System.Collections.Generic;

namespace ContainervervoerCasus.Models
{
    
    public class Stack
    {
        // Fields
        public int StackID { get; set; }
        public List<Container> Containers { get; set; }
        public BalansPosition BalansPosition { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        // Constructors
        public Stack(int row, int column)
        {
            Row = row;
            Column = column;
            BalansPosition = BalansPosition.Left;
        }

        public override string ToString()
        {
            return "[Row: " + Row + "] [Column: " + Column + "]";
        }
    }
}
