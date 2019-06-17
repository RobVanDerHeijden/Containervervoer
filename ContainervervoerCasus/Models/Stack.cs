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
        // every stack has value based on how much % stackable it is based on maxstackable
        // MaxStackableContainers  = 31 // [container.maxcarryweight[120]/container.minimumweight[4] + 1]
        // MaxStackableWeight  = 150 // [container.maxcarryweight[120] + MaximumWeight[30]]

        // e.g. StackableWeight = MaxStackableWeight - weightToSubstract;
        // int weightToSubstract 0;
        // if (containers.count() > 0)
        // {
        //  weightToSubstract = container.maxcarryweight[120] - 4*(containers.count()-1);
        // }
        // StackableContainers = MaxStackableContainers - containers.count();
        // StackableValue = ((StackableContainers/MaxStackableContainers*100) + (StackableWeight/MaxStackableWeight*100)) / 2
        public int StackWeight { get; set; }
        public static int MaxStackableContainers = Container.MaximumCarryWeight / Container.MinimumWeight; // 31
        public static int MaxStackableWeight = Container.MaximumCarryWeight + Container.MaximumWeight; // 150
        // MaxStackableWeight - weightToSubstract;
        public int StackableWeight { get; set; } 
        // MaxStackableContainers - containers.count();
        public int StackableContainers { get; set; } 
        // ((StackableContainers/MaxStackableContainers*100) + (StackableWeight/MaxStackableWeight*100)) / 2
        public int StackableValue { get; set; }

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
            int weightToSubstract = 0;
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
        }

        private void CheckIfStackIsStillStackableForValuable()
        {
            if (StackableWeight > Container.MinimumWeight &&
                StackableContainers > 0)
            {
                IsStackableForValuable = true;
            }
            else
            {
                IsStackableForValuable = false;
            }
        }

        private void CheckIfStackIsStillStackableForNonValuable()
        {
            if (StackableWeight-Container.MaximumWeight > Container.MinimumWeight &&
            StackableContainers > 0)
            {
                IsStackableForNonValuable = true;
            }
            else
            {
                IsStackableForNonValuable = false;
            }
        }

        public override string ToString()
        {
            return "[Row: " + Row + "] [Column: " + Column + "] [BalansPosition: " + BalansPosition + "]";
        }
    }
}
