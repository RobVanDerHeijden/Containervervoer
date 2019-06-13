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
        CargoShip _cargoShip;

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
            Lbx_StackContainers.Items.Clear();
            if (Lbx_CargoShips.SelectedIndex != -1)
            {
                if (DGV_Stacks.DataSource != null)
                {
                    DGV_Stacks.DataSource = null;
                }
                _cargoShip = Lbx_CargoShips.SelectedItem as CargoShip;

                DataTable dt = new DataTable();
                DGV_Stacks.DataSource = dt;

                for (int j = 0; j < _cargoShip.Width; j++)
                {
                    dt.Columns.Add("Column: " + j);
                }
                int counter = 0;
                for (int currentRow = 0; currentRow < _cargoShip.Length; currentRow++)
                {
                    DataRow dr = dt.NewRow();
                    
                    for (int currentColumn = 0; currentColumn < _cargoShip.Width; currentColumn++)
                    {
                        int amountContainers = 0;
                        if (_cargoShip.Stacks[counter].Containers != null)
                        {
                            amountContainers = _cargoShip.Stacks[counter].Containers.Count;
                        }
                        int stackId = _cargoShip.Stacks[counter].StackID;

                        dr[currentColumn] = stackId + ";=ID | Containers[" + amountContainers + "]";
                        counter++;
                    }
                    dt.Rows.Add(dr);
                }
            }
        }

        private void DGV_Stacks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int stackId = Convert.ToInt32(DGV_Stacks.CurrentCell.Value.ToString().Split(';')[0]);
            //MessageBox.Show("StackId: " + stackId);
            _cargoShip.FindStackWithId(stackId);
            //int result = list.Find(item => item > 20);

            //Console.WriteLine(result);

        }

        private void Btn_AddContainerToStack_Click(object sender, EventArgs e)
        {
            int stackId = Convert.ToInt32(DGV_Stacks.CurrentCell.Value.ToString().Split(';')[0]);
            Stack selectedStack = _cargoShip.FindStackWithId(stackId);
            Container selectedContainer = Lbx_Containers.SelectedItem as Container;
            _cargoShip = Lbx_CargoShips.SelectedItem as CargoShip;
            selectedStack.AddContainer(selectedContainer);
            MessageBox.Show(selectedStack.Containers.Count.ToString());
        }
    }
}
