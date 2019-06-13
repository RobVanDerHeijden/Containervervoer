using System.Collections.Generic;

namespace ContainervervoerCasus.Models
{
    public class Dock
    {
        // Fields
        public int DockID { get; set; } // Probally unnecessary
        public List<CargoShip> CargoShips = new List<CargoShip>();
        public List<Container> Containers = new List<Container>();

        public static int TotalWeightContainers;
        public static int TotalRegularContainers;
        public static int TotalValuableContainers;
        public static int TotalCooledContainers;
        public static int TotalContainers;

        // Constructors
        public Dock()
        {

        }

        public void AddContainer(Container container)
        {
            Containers.Add(container);
        }

        public void AddCargoShips(CargoShip cargoShip)
        {
            CargoShips.Add(cargoShip);
        }
    }
}
