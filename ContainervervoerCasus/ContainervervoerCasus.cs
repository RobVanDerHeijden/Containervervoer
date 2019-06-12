using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContainervervoerCasus.Models;

namespace ContainervervoerCasus
{
    public partial class ContainervervoerCasus : Form
    {
        // Fields + objecten aanmaken
        Dock _dock = new Dock();

        public ContainervervoerCasus()
        {
            InitializeComponent();
        }
        
        private void Btn_AddContainer_Click(object sender, EventArgs e)
        {
            Enum.TryParse(Cbbx_ContainerType.SelectedValue.ToString(), out ContainerType status);
            int weight = (int) Nud_ContainerWeight.Value;

            if (status == ContainerType.Regular)
            {
                Container newContainer = new Container(weight, status);
                _dock.AddContainer(newContainer);
                Lbx_Containers.Items.Add(newContainer);
            }
            else if (status == ContainerType.Valuable)
            {
                ValuableContainer newContainer = new ValuableContainer(weight, status);
                _dock.AddContainer(newContainer);
                Lbx_Containers.Items.Add(newContainer);
            }
            else if (status == ContainerType.Cooled)
            {
                CooledContainer newContainer = new CooledContainer(weight, status);
                _dock.AddContainer(newContainer);
                Lbx_Containers.Items.Add(newContainer);
            }

            UpdateContainerStats();
        }

        private void ContainervervoerCasus_Load(object sender, EventArgs e)
        {
            Cbbx_ContainerType.DataSource = Enum.GetValues(typeof(ContainerType));
        }

        private void UpdateContainerStats()
        {
            Lbl_TotalRegular.Text = "Total Regular: " + Models.Dock.TotalRegularContainers;
            Lbl_TotalValuable.Text = "Total Valuable: " + Models.Dock.TotalValuableContainers;
            Lbl_TotalCooled.Text = "Total Cooled: " + Models.Dock.TotalCooledContainers;
            Lbl_TotalContainerWeight.Text = "Total weight all containers: " + Models.Dock.TotalWeightContainers;
        }

        private void Btn_ResetContainers_Click(object sender, EventArgs e)
        {
            _dock.Containers.Clear();
            Lbx_Containers.Items.Clear();
            Models.Dock.TotalRegularContainers = 0;
            Models.Dock.TotalValuableContainers = 0;
            Models.Dock.TotalCooledContainers = 0;
            Models.Dock.TotalWeightContainers = 0;

            UpdateContainerStats();
        }

        private void Btn_AddCargoShip_Click(object sender, EventArgs e)
        {
            CargoShip cargoShip = new CargoShip((int) Nud_CargoShipWidth.Value, (int) Nud_CargoShipLength.Value);
            _dock.CargoShips.Add(cargoShip);
            Lbx_CargoShips.Items.Add(cargoShip);
        }

        private void Btn_ResetCargoShip_Click(object sender, EventArgs e)
        {
            _dock.CargoShips.Clear();
            Lbx_CargoShips.Items.Clear();

            UpdateContainerStats();
        }

        private void Lbx_CargoShips_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lbx_Stacks.Items.Clear();
            if (Lbx_CargoShips.SelectedIndex != -1)
            {
                CargoShip cargoShip = Lbx_CargoShips.SelectedItem as CargoShip;
                foreach (Stack stack in cargoShip.Stacks)
                {
                    Lbx_Stacks.Items.Add(stack);
                }
            }
            
        }
    }
}
