using System.Collections.Generic;

namespace ContainervervoerCasus.Models
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
