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
            VoegAlleDierenSamenInEenLijst(sortedCooledContainers, sortedRegularContainers, sortedValuableContainers);
        }

        public void VoegAlleDierenSamenInEenLijst(IOrderedEnumerable<Container> coolios, IOrderedEnumerable<Container> regulars, IOrderedEnumerable<Container> valuables)
        {
            AllContainers.Clear();
            AllContainers.AddRange(coolios);
            AllContainers.AddRange(regulars);
            AllContainers.AddRange(valuables);
        }


        public void ActivateAlgorithm(CargoShip _cargoShip)
        {
            //MessageBox.Show("Container count before: " + AllContainers.Count());

            // foreach container in AllContainers
            // if containertype = Cooled
            // if stack hascooling = true
            // Then check if left or right is lighter or =. put container in lighter side (start Left side)
            // (ignore middle side for now)

            // valuable possible locations = V
            /* -    column1 column2 column3 column4
             * row1 V   V   V   V   V   V   V   
             * row2 V   V   V   V   V   V   V
             * row3 x   x   x   x   x   x   x
             * row4 V   V   V   V   V   V   V
             * row5 V   V   V   V   V   V   V
             * row6 x   x   x   x   x   x   x
             */

            List<Stack> leftSideStacks = new List<Stack>();
            List<Stack> rightSideStacks = new List<Stack>();
            List<Stack> middleSideStacks = new List<Stack>();
            foreach (Stack stack in _cargoShip.Stacks)
            {
                if (stack.BalansPosition == BalansPosition.Left)
                {
                    leftSideStacks.Add(stack);
                }
                else if (stack.BalansPosition == BalansPosition.Right)
                {
                    rightSideStacks.Add(stack);
                }
                else if (stack.BalansPosition == BalansPosition.Middle)
                {
                    middleSideStacks.Add(stack);
                }
            }
            
            // First itteration: Left + Right
            foreach (Container container in AllContainers.ToList())
            {
                bool hasBeenProcessed = false;

                if (_cargoShip.WeightLeftSide <= _cargoShip.WeightRightSide 
                    && !hasBeenProcessed)
                {
                    foreach (Stack lStack in leftSideStacks)
                    {
                        // CooledContainers
                        if (container.ContainerType == ContainerType.Cooled 
                            && lStack.IsStackableForNonValuable 
                            && lStack.HasCooling)
                        {
                            Stack correctStack = _cargoShip.FindStackWithId(lStack.StackID);
                            correctStack.AddContainer(container);
                            _cargoShip.WeightLeftSide = _cargoShip.CalcWeightLeftSide();
                            hasBeenProcessed = true;
                            AllContainers.Remove(container);
                            break;
                        }
                        // RegularContainers
                        if (container.ContainerType == ContainerType.Regular 
                            && lStack.IsStackableForNonValuable)
                        {
                            Stack correctStack = _cargoShip.FindStackWithId(lStack.StackID);
                            correctStack.AddContainer(container);
                            _cargoShip.WeightLeftSide = _cargoShip.CalcWeightLeftSide();
                            hasBeenProcessed = true;
                            AllContainers.Remove(container);
                            break;
                        }
                        // ValuableContainers
                        if (container.ContainerType == ContainerType.Valuable 
                            && lStack.IsStackableForValuable 
                            && (lStack.Row + 1) % 3 != 0)
                        {
                            Stack correctStack = _cargoShip.FindStackWithId(lStack.StackID);
                            correctStack.AddContainer(container);
                            correctStack.IsStackableForValuable = false;
                            _cargoShip.WeightLeftSide = _cargoShip.CalcWeightLeftSide();
                            hasBeenProcessed = true;
                            AllContainers.Remove(container);
                            break;
                        }
                    } // END foreach Left Stack
                } // END If Left is lighter

                if (_cargoShip.WeightRightSide < _cargoShip.WeightLeftSide 
                    && !hasBeenProcessed)
                {
                    foreach (Stack rStack in rightSideStacks)
                    {
                        // CooledContainers
                        if (container.ContainerType == ContainerType.Cooled 
                            && rStack.IsStackableForNonValuable 
                            && rStack.HasCooling)
                        {
                            Stack correctStack = _cargoShip.FindStackWithId(rStack.StackID);
                            correctStack.AddContainer(container);
                            _cargoShip.WeightRightSide = _cargoShip.CalcWeightRightSide();
                            hasBeenProcessed = true;
                            AllContainers.Remove(container);
                            break;
                        }
                        // RegularContainers
                        if (container.ContainerType == ContainerType.Regular 
                            && rStack.IsStackableForNonValuable)
                        {
                            Stack correctStack = _cargoShip.FindStackWithId(rStack.StackID);
                            correctStack.AddContainer(container);
                            _cargoShip.WeightRightSide = _cargoShip.CalcWeightRightSide();
                            hasBeenProcessed = true;
                            AllContainers.Remove(container);
                            break;
                        }
                        // ValuableContainers
                        if (container.ContainerType == ContainerType.Valuable 
                            && rStack.IsStackableForValuable 
                            && (rStack.Row + 1) % 3 != 0)
                        {
                            Stack correctStack = _cargoShip.FindStackWithId(rStack.StackID);
                            correctStack.AddContainer(container);
                            correctStack.IsStackableForValuable = false;
                            _cargoShip.WeightRightSide = _cargoShip.CalcWeightRightSide();
                            hasBeenProcessed = true;
                            AllContainers.Remove(container);
                            break;
                        }
                    } // END foreach Right Stack
                } // END If Right is lighter
            } // END foreach Container

            // Second itteration: Middle
            foreach (Container container in AllContainers.ToList())
            {
                foreach (Stack lStack in middleSideStacks)
                {
                    // CooledContainers
                    if (container.ContainerType == ContainerType.Cooled
                        && lStack.IsStackableForNonValuable
                        && lStack.HasCooling)
                    {
                        Stack correctStack = _cargoShip.FindStackWithId(lStack.StackID);
                        correctStack.AddContainer(container);
                        _cargoShip.WeightMiddleSide = _cargoShip.CalcWeightMiddleSide();
                        AllContainers.Remove(container);
                        break;
                    }
                    // RegularContainers
                    if (container.ContainerType == ContainerType.Regular
                        && lStack.IsStackableForNonValuable)
                    {
                        Stack correctStack = _cargoShip.FindStackWithId(lStack.StackID);
                        correctStack.AddContainer(container);
                        _cargoShip.WeightMiddleSide = _cargoShip.CalcWeightMiddleSide();
                        AllContainers.Remove(container);
                        break;
                    }
                    // ValuableContainers
                    if (container.ContainerType == ContainerType.Valuable
                        && lStack.IsStackableForValuable
                        && (lStack.Row + 1) % 3 != 0)
                    {
                        Stack correctStack = _cargoShip.FindStackWithId(lStack.StackID);
                        correctStack.AddContainer(container);
                        correctStack.IsStackableForValuable = false;
                        _cargoShip.WeightMiddleSide = _cargoShip.CalcWeightMiddleSide();
                        AllContainers.Remove(container);
                        break;
                    }
                } // END foreach Left Stack
            } // END foreach Container


            //MessageBox.Show("Container count after: " + AllContainers.Count());
            _cargoShip.CalcCurrentWeight();
        }
    }
}
