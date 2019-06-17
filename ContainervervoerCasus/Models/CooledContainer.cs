namespace ContainervervoerCasus.Models
{
    public class CooledContainer : Container
    {
        public CooledContainer(int weight)
        {
            Weight = weight;
            ContainerType = ContainerType.Cooled;
            IsCarying = 0;

            Dock.TotalWeightContainers += weight;
            Dock.TotalContainers++;
            Dock.TotalCooledContainers++;
        }
    }
}
