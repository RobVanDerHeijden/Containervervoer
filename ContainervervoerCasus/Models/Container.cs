namespace ContainervervoerCasus.Models
{
    public class Container
    {
        protected static int ContainerIncrement;
        // Fields
        public int ContainerID { get; set; }
        public int Weight { get; set; }
        public static int MinimumWeight = 4;
        public static int MaximumWeight = 30;
        public static int MaximumCarryWeight = 120;
        public int IsCarying { get; set; }
        public ContainerType ContainerType { get; set; }
        
        // Constructors
        public Container()
        {
            ContainerID = ContainerIncrement;
            ContainerIncrement++;
        }

        public Container(int weight)
        {
            ContainerID = ContainerIncrement;
            Weight = weight;
            IsCarying = 0;
            ContainerType = ContainerType.Regular;
            
            
            Dock.TotalRegularContainers++;
            Dock.TotalWeightContainers += weight;
            Dock.TotalContainers++;
            
            ContainerIncrement++;
        }
        
        public override string ToString()
        {
            return ContainerID + ";ID [" + Weight + "] " + ContainerType;
        }
    }
}
