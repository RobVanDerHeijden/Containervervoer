namespace ContainervervoerCasus.Models
{
    public class ValuableContainer : Container
    {
        public ValuableContainer(int weight, ContainerType containerType)
        {
            Weight = weight;
            MaximumCarryWeight = 0;
            IsCarying = 0;
            ContainerType = containerType;

            Dock.TotalWeightContainers += weight;
            Dock.TotalValuableContainers++;
        }
    }
}
