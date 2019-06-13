using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ContainervervoerCasus.Models
{
    public class CargoShip
    {
        // Fields
        public int CargoShipID { get; set; }
        public List<Stack> Stacks = new List<Stack>();
        public int WeightLeftSide { get; set; }
        public int WeightRightSide { get; set; }
        public int WeightMiddleSide { get; set; }
        public int CurrentWeight { get; set; }
        public int MaximumCarryWeight { get; set; }
        public int IsCarying { get; set; }
        public int Width { get; set; } //columns
        public int Length { get; set; } //rows
        // maxgekoeld??

        // Constructors
        public CargoShip(int width, int length)
        {
            Width = width;
            Length = length;
            for (int i = 0; i < length; i++) // for each row
            {
                for (int j = 0; j < width; j++) // for each column in the row
                {
                    // if j > width/2 left
                    // CASE: Width = 3 ->
                    // 0 < (2) / 2 = Left
                    // 1 == (2) / 2 = Middle
                    // 2 > (2) / 2 = Right
                    BalansPosition balansPosition = BalansPosition.None;
                    if (j < (width-1) / 2)
                    {
                        balansPosition = BalansPosition.Left;
                    } else if (j == (width - 1) / 2)
                    {
                        balansPosition = BalansPosition.Middle;
                    }
                    else if (j > (width - 1) / 2)
                    {
                        balansPosition = BalansPosition.Right;
                    }
                    AddStack(new Stack(i,j, balansPosition));

                }
            }
            MaximumCarryWeight = width * length * 150; 
        }
        public void AddStack(Stack stack)
        {
            Stacks.Add(stack);
        }

        public Stack FindStackWithId(int stackId)
        {
            //Stack result = list.Find(item => item > 20);
            Stack result = (from a in Stacks
                          where a.StackID == stackId
                select a).SingleOrDefault();
            //MessageBox.Show("Result:" + result);
            return result;
        }

        public void AddWeightLeftSide(int weight)
        {
            WeightLeftSide += weight;
            CurrentWeight += weight;
        }
        public void AddWeightRightSide(int weight)
        {
            WeightRightSide += weight;
            CurrentWeight += weight;
        }

        public override string ToString()
        {
            return "[Stacks: " + Stacks.Count + "] Columns/Width: " + Width + " Rows/Length: " + Length;
        }
    }
}
