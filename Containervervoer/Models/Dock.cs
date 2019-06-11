using System;
using System.Collections.Generic;

namespace Containervervoer2
{
    public class Dock
    {
        // Fields
        public int DockID { get; set; }
        public CargoShip CargoShip { get; set; }
        public List<Container> Containers { get; set; }

        // Constructors
        public Dock()
        {

        }
    }
}
