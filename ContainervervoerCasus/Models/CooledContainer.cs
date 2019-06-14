namespace ContainervervoerCasus.Models
{
    public class CooledContainer : Container
    {
        public CooledContainer(int weight, ContainerType containerType)
        {
            Weight = weight;
            ContainerType = containerType;
            MaximumCarryWeight = 120;
            IsCarying = 0;

            Dock.TotalWeightContainers += weight;
            Dock.TotalContainers++;
            Dock.TotalCooledContainers++;
        }
    }
}
