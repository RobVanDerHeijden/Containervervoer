namespace ContainervervoerCasus.Models
{
    public class ValuableContainer : Container
    {
        public ValuableContainer(int weight, ContainerType containerType)
        {
            Weight = weight;
            ContainerType = containerType;
            TotalWeightContainers += weight;
            TotalValuableContainers++;
        }
    }
}
