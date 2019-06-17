namespace ContainervervoerCasus.Models
{
    public class ValuableContainer : Container
    {
        public ValuableContainer(int weight)
        {
            Weight = weight;
            IsCarying = 0;
            ContainerType = ContainerType.Valuable;

            Dock.TotalWeightContainers += weight;
            Dock.TotalContainers++;
            Dock.TotalValuableContainers++;
        }
    }
}
