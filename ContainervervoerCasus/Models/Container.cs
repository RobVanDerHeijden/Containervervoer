namespace ContainervervoerCasus.Models
{
    public class Container
    {
        protected static int ContainerIncrement;
        // Fields
        public int ContainerID { get; set; }
        public int Weight { get; set; }
        public int MinimumWeight = 4;
        public int MaximumWeight = 30;
        public int MaximumCarryWeight { get; set; }
        public int IsCarying { get; set; }
        public ContainerType ContainerType { get; set; }
        
        
        // Constructors
        public Container()
        {
            ContainerID = ContainerIncrement;
            ContainerIncrement++;
        }

        public Container(int weight, ContainerType containerType)
        {
            ContainerID = ContainerIncrement;
            Weight = weight;
            MaximumCarryWeight = 30;
            IsCarying = 0;
            ContainerType = containerType;


            if (containerType == ContainerType.Regular)
            {
                Dock.TotalRegularContainers++;
            }
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
