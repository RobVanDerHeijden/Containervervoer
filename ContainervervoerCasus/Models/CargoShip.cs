using System.Collections.Generic;

namespace ContainervervoerCasus.Models
{
    public class CargoShip
    {
        // Fields
        public int CargoShipID { get; set; }
        public List<Stack> Stacks { get; set; }
        public int WeightLeftSide { get; set; }
        public int WeightRightSide { get; set; }
        public int MaximumCarryWeight { get; set; }
        public int IsCarying { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        // Constructors
        public CargoShip()
        {

        }
    }
}
