using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ContainervervoerCasus.Models
{
    public class Dock
    {
        // Fields
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

        public void AddRandomContainers(int amountContainers)
        {
            Random random = new Random();
            for (int i = 0; i < amountContainers; i++)
            {
                Array enumValues = Enum.GetValues(typeof(ContainerType));
                ContainerType type = (ContainerType)enumValues.GetValue(random.Next(enumValues.Length));
                int randomWeight = random.Next(Container.MinimumWeight, Container.MaximumWeight+1);

                if (type == ContainerType.Regular)
                {
                    Container newContainer = new Container(randomWeight);
                    AllContainers.Add(newContainer);
                }
                else if (type == ContainerType.Valuable)
                {
                    ValuableContainer newContainer = new ValuableContainer(randomWeight);
                    AllContainers.Add(newContainer);
                }
                else if (type == ContainerType.Cooled)
                {
                    CooledContainer newContainer = new CooledContainer(randomWeight);
                    AllContainers.Add(newContainer);
                }
            }
        }
        
        public void SplitListContainers()
        {
            RegularContainers.Clear();
            CooledContainers.Clear();
            ValuableContainers.Clear();
            // split all containers up into 3 lists
            foreach (Container container in AllContainers)
            {
                if (container.ContainerType == ContainerType.Regular)
                {
                    RegularContainers.Add(container);
                }
                else if (container.ContainerType == ContainerType.Cooled)
                {
                    CooledContainers.Add(container);
                }
                else if (container.ContainerType == ContainerType.Valuable)
                {
                    ValuableContainers.Add(container);
                }
            }
            // order lists by weight (heaviests first)
            var sortedCooledContainers = CooledContainers.OrderByDescending(Container => Container.Weight);
            var sortedRegularContainers = RegularContainers.OrderByDescending(Container => Container.Weight);
            var sortedValuableContainers = ValuableContainers.OrderByDescending(Container => Container.Weight);
            CombineSplittedLists(sortedCooledContainers, sortedRegularContainers, sortedValuableContainers);
        }

        public void CombineSplittedLists(IOrderedEnumerable<Container> coolios, IOrderedEnumerable<Container> regulars, IOrderedEnumerable<Container> valuables)
        {
            AllContainers.Clear();
            AllContainers.AddRange(coolios);
            AllContainers.AddRange(regulars);
            AllContainers.AddRange(valuables);
        }


        public void ActivateAlgorithm(CargoShip cargoShip)
        {
            IEnumerable<Stack> leftSideStacks = cargoShip.Stacks.Where(e => e.BalansPosition == BalansPosition.Left);
            IEnumerable<Stack> rightSideStacks = cargoShip.Stacks.Where(e => e.BalansPosition == BalansPosition.Right);
            IEnumerable<Stack> middleSideStacks = cargoShip.Stacks.Where(e => e.BalansPosition == BalansPosition.Middle);
            
            // First itteration: Left + Right
            foreach (Container container in AllContainers.ToList())
            {
                bool hasBeenProcessed = false;

                if (cargoShip.WeightLeftSide <= cargoShip.WeightRightSide)
                {
                    foreach (Stack lStack in leftSideStacks)
                    {
                        // CooledContainers
                        if (container.ContainerType == ContainerType.Cooled 
                            && lStack.IsStackableForNonValuable 
                            && lStack.HasCooling)
                        {
                            Stack correctStack = cargoShip.FindStackWithId(lStack.StackID);
                            correctStack.AddContainer(container);
                            cargoShip.WeightLeftSide = cargoShip.CalcWeightLeftSide();
                            hasBeenProcessed = true;
                            AllContainers.Remove(container);
                            break;
                        }
                        // RegularContainers
                        if (container.ContainerType == ContainerType.Regular 
                            && lStack.IsStackableForNonValuable)
                        {
                            Stack correctStack = cargoShip.FindStackWithId(lStack.StackID);
                            correctStack.AddContainer(container);
                            cargoShip.WeightLeftSide = cargoShip.CalcWeightLeftSide();
                            hasBeenProcessed = true;
                            AllContainers.Remove(container);
                            break;
                        }
                        // ValuableContainers
                        if (container.ContainerType == ContainerType.Valuable 
                            && lStack.IsStackableForValuable 
                            && lStack.IsStackInAValuableRow)
                        {
                            Stack correctStack = cargoShip.FindStackWithId(lStack.StackID);
                            correctStack.AddContainer(container);
                            correctStack.IsStackableForValuable = false;
                            cargoShip.WeightLeftSide = cargoShip.CalcWeightLeftSide();
                            hasBeenProcessed = true;
                            AllContainers.Remove(container);
                            break;
                        }
                    } // END foreach Left Stack
                } // END If Left is lighter

                if (cargoShip.WeightRightSide < cargoShip.WeightLeftSide 
                    && !hasBeenProcessed)
                {
                    foreach (Stack rStack in rightSideStacks)
                    {
                        // CooledContainers
                        if (container.ContainerType == ContainerType.Cooled 
                            && rStack.IsStackableForNonValuable 
                            && rStack.HasCooling)
                        {
                            Stack correctStack = cargoShip.FindStackWithId(rStack.StackID);
                            correctStack.AddContainer(container);
                            cargoShip.WeightRightSide = cargoShip.CalcWeightRightSide();
                            AllContainers.Remove(container);
                            break;
                        }
                        // RegularContainers
                        if (container.ContainerType == ContainerType.Regular 
                            && rStack.IsStackableForNonValuable)
                        {
                            Stack correctStack = cargoShip.FindStackWithId(rStack.StackID);
                            correctStack.AddContainer(container);
                            cargoShip.WeightRightSide = cargoShip.CalcWeightRightSide();
                            AllContainers.Remove(container);
                            break;
                        }
                        // ValuableContainers
                        if (container.ContainerType == ContainerType.Valuable 
                            && rStack.IsStackableForValuable 
                            && rStack.IsStackInAValuableRow)
                        {
                            Stack correctStack = cargoShip.FindStackWithId(rStack.StackID);
                            correctStack.AddContainer(container);
                            correctStack.IsStackableForValuable = false;
                            cargoShip.WeightRightSide = cargoShip.CalcWeightRightSide();
                            AllContainers.Remove(container);
                            break;
                        }
                    } // END foreach Right Stack
                } // END If Right is lighter
            } // END foreach Container

            // Second itteration: MIDDLE
            foreach (Container container in AllContainers.ToList())
            {
                foreach (Stack mStack in middleSideStacks)
                {
                    // CooledContainers
                    if (container.ContainerType == ContainerType.Cooled
                        && mStack.IsStackableForNonValuable
                        && mStack.HasCooling)
                    {
                        Stack correctStack = cargoShip.FindStackWithId(mStack.StackID);
                        correctStack.AddContainer(container);
                        cargoShip.WeightMiddleSide = cargoShip.CalcWeightMiddleSide();
                        AllContainers.Remove(container);
                        break;
                    }
                    // RegularContainers
                    if (container.ContainerType == ContainerType.Regular
                        && mStack.IsStackableForNonValuable)
                    {
                        Stack correctStack = cargoShip.FindStackWithId(mStack.StackID);
                        correctStack.AddContainer(container);
                        cargoShip.WeightMiddleSide = cargoShip.CalcWeightMiddleSide();
                        AllContainers.Remove(container);
                        break;
                    }
                    // ValuableContainers
                    if (container.ContainerType == ContainerType.Valuable
                        && mStack.IsStackableForValuable
                        && mStack.IsStackInAValuableRow)
                    {
                        Stack correctStack = cargoShip.FindStackWithId(mStack.StackID);
                        correctStack.AddContainer(container);
                        correctStack.IsStackableForValuable = false;
                        cargoShip.WeightMiddleSide = cargoShip.CalcWeightMiddleSide();
                        AllContainers.Remove(container);
                        break;
                    }
                } // END foreach Left Stack
            } // END foreach Container
            
            cargoShip.CalcCurrentWeight();
        }
    }
}
