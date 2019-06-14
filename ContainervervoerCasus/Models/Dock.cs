using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainervervoerCasus.Models
{
    public class Dock
    {
        // Fields
        public int DockID { get; set; } // Probally unnecessary 
        public List<CargoShip> CargoShips = new List<CargoShip>();
        public List<Container> AllContainers = new List<Container>();

        public List<Container> RegularContainers = new List<Container>();
        public List<Container> ValuableContainers = new List<Container>();
        public List<Container> CooledContainers = new List<Container>();

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
            AllContainers.Add(container);
        }

        public void AddRandomContainers(int amountContainers)
        {
            //List<Container> randomContainers = new List<Container>();
            Random random = new Random();
            for (int i = 0; i < amountContainers; i++)
            {
                Array enumValues = Enum.GetValues(typeof(ContainerType));
                ContainerType type = (ContainerType)enumValues.GetValue(random.Next(enumValues.Length));
                int randomWeight = random.Next(Container.MinimumWeight, Container.MaximumWeight+1);

                if (type == ContainerType.Regular)
                {
                    Container newContainer = new Container(randomWeight, type);
                    AllContainers.Add(newContainer);
                }
                else if (type == ContainerType.Valuable)
                {
                    ValuableContainer newContainer = new ValuableContainer(randomWeight, type);
                    AllContainers.Add(newContainer);
                }
                else if (type == ContainerType.Cooled)
                {
                    CooledContainer newContainer = new CooledContainer(randomWeight, type);
                    AllContainers.Add(newContainer);
                }
            }
            //return randomContainers;
        }

        public void AddCargoShips(CargoShip cargoShip)
        {
            CargoShips.Add(cargoShip);
        }

        public void SplitListContainers()
        {
            // split all containers up into 3 lists
            foreach (Container container in AllContainers)
            {
                if (container.ContainerType == ContainerType.Regular)
                {
                    RegularContainers.Add(container);
                    //AllContainers.Remove(container);
                }
                else if (container.ContainerType == ContainerType.Cooled)
                {
                    CooledContainers.Add(container);
                    //AllContainers.Remove(container);
                }
                else if (container.ContainerType == ContainerType.Valuable)
                {
                    ValuableContainers.Add(container);
                    //AllContainers.Remove(container);
                }
            }
            // order lists by weight (heaviests first)
            var sortedCooledContainers = CooledContainers.OrderByDescending(Container => Container.Weight);
            var sortedRegularContainers = RegularContainers.OrderByDescending(Container => Container.Weight);
            var sortedValuableContainers = ValuableContainers.OrderByDescending(Container => Container.Weight);
            VoegAlleDierenSamenInEenLijst(sortedCooledContainers, sortedRegularContainers, sortedValuableContainers);
        }

        public void VoegAlleDierenSamenInEenLijst(IOrderedEnumerable<Container> coolios, IOrderedEnumerable<Container> regulars, IOrderedEnumerable<Container> valuables)
        {
            AllContainers.Clear();
            AllContainers.AddRange(coolios);
            AllContainers.AddRange(regulars);
            AllContainers.AddRange(valuables);
        }


        public void ActivateAlgorithm()
        {
            throw new NotImplementedException();
        }
    }
}
