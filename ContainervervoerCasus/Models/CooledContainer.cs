namespace ContainervervoerCasus.Models
{
    public class CooledContainer : Container
    {
        public CooledContainer(int weight, ContainerType containerType)
        {
            Weight = weight;
            ContainerType = containerType;
        }
    }
}
