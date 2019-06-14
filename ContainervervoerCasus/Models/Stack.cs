using System.Collections.Generic;
using System.Linq;

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
        public bool IsStackable { get; set; }
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

            IsStackable = true;
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
                weightToSubstract = Container.MaximumCarryWeight - StackWeight;
            }
            StackableWeight = MaxStackableWeight - weightToSubstract;
        }

        public void AddContainer(Container container)
        {
            Containers.Add(container);
            CalcStackWeight();
        }

        public override string ToString()
        {
            return "[Row: " + Row + "] [Column: " + Column + "] [BalansPosition: " + BalansPosition + "]";
        }
    }
}
