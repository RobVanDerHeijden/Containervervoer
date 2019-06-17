using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ContainervervoerCasus.Models
{
    
    public class Stack
    {
        protected static int StackIncrement;
        // Fields
        public int StackID { get; set; }
        public List<Container> Containers = new List<Container>();
        public BalansPosition BalansPosition { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool HasCooling { get; set; }
        public bool IsStackableForNonValuable { get; set; }
        public bool IsStackableForValuable { get; set; }
        public bool IsStackInAValuableRow { get; set; }
        public int StackWeight { get; set; }
        public static int MaxStackableContainers = Container.MaximumCarryWeight / Container.MinimumWeight; // 31
        public static int MaxStackableWeight = Container.MaximumCarryWeight + Container.MaximumWeight; // 150
        // MaxStackableWeight - weightToSubstract;
        public int StackableWeight { get; set; } 
        // MaxStackableContainers - containers.count();
        public int StackableContainers { get; set; } 

        // Constructors
        public Stack(int row, int column, BalansPosition balansPosition)
        {
            StackID = StackIncrement;
            BalansPosition = balansPosition;
            Row = row;
            Column = column;
            if (row == 0)
            {
                HasCooling = true;
            }
            else
            {
                HasCooling = false;
            }

            IsStackableForNonValuable = true;
            IsStackableForValuable = true;
            if ((Row + 1) % 3 != 0)
            {
                IsStackInAValuableRow = true;
            }
            StackableWeight = MaxStackableWeight;
            StackableContainers = MaxStackableContainers;
            StackWeight = 0;
            CalcStackWeight();
            StackIncrement++;
        }

        public void CalcStackWeight()
        {
            StackWeight = 0;
            foreach (Container container in Containers)
            {
                StackWeight += container.Weight;
            }
        }

        // For Unit Testing
        public bool HasValuableContainer
        {
            get
            {
                if (Containers.Count > 0 && Containers[Containers.Count - 1].ContainerType == ContainerType.Valuable)
                {
                    return true;
                }
                return false;
            }
        }

        public void CalcStackableContainers()
        {
            StackableContainers = MaxStackableContainers - Containers.Count();
        }

        public void CalcStackableWeight()
        {
            if (Containers.Any())
            {
                CalcStackWeight();
                int restContainerWeight = 0;
                foreach (Container container in Containers.Where(n => n.ContainerID != 0))
                {
                    restContainerWeight += container.Weight;
                }
                StackableWeight = (MaxStackableWeight - Container.MaximumWeight) - restContainerWeight;
            }
        }

        public void AddContainer(Container container)
        {
            Containers.Add(container);
            CalcStackWeight();
            CalcStackableContainers();
            CalcStackableWeight();
            CheckIfStackIsStillStackableForNonValuable();
            CheckIfStackIsStillStackableForValuable();
            if (container.ContainerType == ContainerType.Valuable)
            {
                IsStackableForValuable = false;
            }
        }

        public bool CanContainerBeAddedToStack()
        {
            IEnumerable<Container> valuables = Containers.Where(e => e.ContainerType == ContainerType.Valuable);
            if (valuables.ToList().Any())
            {
                // Cant stack
                return false;
            }
            return true;
        }

        private void CheckIfStackIsStillStackableForValuable()
        {
            // Assignement statement instead of if statement
            IsStackableForValuable = StackableWeight > Container.MinimumWeight &&
                                     StackableContainers > 0;
        }

        private void CheckIfStackIsStillStackableForNonValuable()
        {
            // Assignement statement instead of if statement
            IsStackableForNonValuable = StackableWeight - Container.MaximumWeight > Container.MinimumWeight &&
                                        StackableContainers > 0;
        }

        public override string ToString()
        {
            return "[Row: " + Row + "] [Column: " + Column + "] [BalansPosition: " + BalansPosition + "]";
        }
    }
}
