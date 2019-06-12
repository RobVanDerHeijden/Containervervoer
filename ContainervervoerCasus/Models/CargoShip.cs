using System;
using System.Collections.Generic;

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
        //public int Height { get; set; }
        // maxgekoeld??
        //public int [,,] ContainerLocations; /*= new int[x=W,2,3];*/

        // Constructors
        public CargoShip(int width, /*int height,*/ int length)
        {
            Width = width;
            Length = length;
            for (int i = 0; i < length; i++) // for each row
            {
                for (int j = 0; j < width; j++) // for each column in the row
                {
                    // if j > width/2 left
                    AddStack(new Stack(i,j));

                }
            }
            //Height = height;
            MaximumCarryWeight = width * length * 150; 
            //ContainerLocations = new int[width, height, length];
        }
        public void AddStack(Stack stack)
        {
            Stacks.Add(stack);
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
