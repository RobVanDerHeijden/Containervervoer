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
                if (DGV_Stacks.DataSource != null)
                {
                    DGV_Stacks.DataSource = null;
                }
                CargoShip cargoShip = Lbx_CargoShips.SelectedItem as CargoShip;

                DataTable dt = new DataTable();
                DGV_Stacks.DataSource = dt;

                for (int j = 0; j < cargoShip.Width; j++)
                {
                    dt.Columns.Add("Column: " + j);
                }
                int counter = 0;
                for (int currentRow = 0; currentRow < cargoShip.Length; currentRow++)
                {
                    DataRow dr = dt.NewRow();
                    
                    for (int currentColumn = 0; currentColumn < cargoShip.Width; currentColumn++)
                    {
                        int amountContainers = 0;
                        if (cargoShip.Stacks[counter].Containers != null)
                        {
                            amountContainers = cargoShip.Stacks[counter].Containers.Count;
                        }
                        int stackId = cargoShip.Stacks[counter].StackID;

                        dr[currentColumn] = stackId + " =ID | Containers: " + amountContainers;
                        counter++;
                    }
                    dt.Rows.Add(dr);
                }
            }
            
        }

        private void DGV_Stacks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (DGV_Stacks.Rows[e.RowIndex]. != -1)
            //{

            //}
            //MessageBox.Show(DGV_Stacks.CurrentCell.Value.ToString());
            int stackId = Convert.ToInt32(DGV_Stacks.CurrentCell.Value.ToString().Substring(0, 1));
            MessageBox.Show("StackId: " + stackId);
            //if (DGV_Stacks.SelectedCells.Count > 0)
            //{
            //    string cellContent = DGV_Stacks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //    //MessageBox.Show(cellContent);
            //    int stackId = Convert.ToInt32(cellContent.Substring(0, 1));
            //    MessageBox.Show("StackId: " + stackId);
            //}

            //if (DGV_Stacks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    string cellContent = DGV_Stacks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //    //MessageBox.Show(cellContent);
            //    int stackId = Convert.ToInt32(cellContent.Substring(0, 1));
            //    MessageBox.Show("StackId: " + stackId);

            //}
        }
    }
}
