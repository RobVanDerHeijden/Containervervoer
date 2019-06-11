namespace ContainervervoerCasus.Models
{
    public enum ContainerType { Regular = 0, Cooled = 1, Valuable = 2 };
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

        // Constructors
        public Container()
        {


        }

        public Container(int weight, ContainerType containerType)
        {
            Weight = weight;
            ContainerType = containerType;
        }

        public override string ToString()
        {
            return "[" + Weight + "] " + ContainerType;
        }
    }
}
