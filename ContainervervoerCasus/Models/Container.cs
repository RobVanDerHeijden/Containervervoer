namespace ContainervervoerCasus.Models
{
    public enum ContainerType { Regular = 0, Valuable = 1, Cooled = 2 };
    public class Container
    {
        // Fields
        public int ContainerID { get; set; }
        public int Weight { get; set; }
        public int MinimumWeight { get; set; }
        public int MaximumWeight { get; set; }
        public int MaximumCarryWeight { get; set; }
        public int IsCarying { get; set; }
        public ContainerType ContainerType { get; set; }
        public static int TotalWeightContainers;
        public static int TotalRegularContainers;
        public static int TotalValuableContainers;
        public static int TotalCooledContainers;
        
        // Constructors
        public Container()
        {


        }

        public Container(int weight, ContainerType containerType)
        {
            Weight = weight;
            ContainerType = containerType;
            TotalWeightContainers += weight;
            if (containerType == ContainerType.Regular)
            {
                TotalRegularContainers++;
            }
        }
        
        public override string ToString()
        {
            return "[" + Weight + "] " + ContainerType;
        }
    }
}
