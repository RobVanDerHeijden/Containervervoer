﻿using System;
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
            Lbl_TotalContainers.Text = "Total containers: " + Models.Dock.TotalContainers;
        }

        private void Btn_ResetContainers_Click(object sender, EventArgs e)
        {
            _dock.AllContainers.Clear();
            Lbx_Containers.Items.Clear();
            Models.Dock.TotalRegularContainers = 0;
            Models.Dock.TotalValuableContainers = 0;
            Models.Dock.TotalCooledContainers = 0;
            Models.Dock.TotalWeightContainers = 0;
            Models.Dock.TotalContainers = 0;

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
            Lbx_StackContainers.Items.Clear();

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

                        Stack stock =_cargoShip.FindStackWithId(stackId);
                        stock.CalcStackWeight();
                        Lbl_StackWeight.Text = "Stack Weight: " + stock.StackWeight;
                        dr[currentColumn] = stackId + ";=ID Cont:" + amountContainers + " Cool:" + stock.HasCooling;
                        counter++;
                    }
                    dt.Rows.Add(dr);
                }
            }
        }

        private void DGV_Stacks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Lbx_StackContainers.Items.Clear();
            int stackId = Convert.ToInt32(DGV_Stacks.CurrentCell.Value.ToString().Split(';')[0]);
            Stack stacko = _cargoShip.FindStackWithId(stackId);
            foreach (var conto in stacko.Containers)
            {
                Lbx_StackContainers.Items.Add(conto);
            }

            stacko.CalcStackWeight();
            Lbl_StackWeight.Text = "Stack Weight: " + stacko.StackWeight;
        }

        private void Btn_AddContainerToStack_Click(object sender, EventArgs e)
        {
            Lbx_StackContainers.Items.Clear();
            int stackId = Convert.ToInt32(DGV_Stacks.CurrentCell.Value.ToString().Split(';')[0]);
            
            _cargoShip = Lbx_CargoShips.SelectedItem as CargoShip;
            Stack selectedStack = _cargoShip.FindStackWithId(stackId);
            Container selectedContainer = Lbx_Containers.SelectedItem as Container;

            selectedStack.AddContainer(selectedContainer);
            foreach (var conto in selectedStack.Containers)
            {
                Lbx_StackContainers.Items.Add(conto);
            }

            _dock.AllContainers.Remove(Lbx_Containers.SelectedItems[0] as Container);
            Lbx_Containers.Items.Remove(Lbx_Containers.SelectedItems[0]);
        }

        private void Btn_AddRandomContainers_Click(object sender, EventArgs e)
        {
            Lbx_Containers.Items.Clear();
            int amountContainersToMake = (int)Nud_RandomContainers.Value;
            _dock.AddRandomContainers(amountContainersToMake);
            
            foreach (var newContainer in _dock.AllContainers)
            {
                Lbx_Containers.Items.Add(newContainer);
            }
            UpdateContainerStats();
        }

        private void Btn_SortContainers_Click(object sender, EventArgs e)
        {
            _dock.SplitListContainers();
            Lbx_Containers.Items.Clear();
            foreach (var conto in _dock.AllContainers)
            {
                Lbx_Containers.Items.Add(conto);
            }
        }

        private void Btn_Algorithm_Click(object sender, EventArgs e)
        {
            _cargoShip = Lbx_CargoShips.SelectedItem as CargoShip;
            _dock.ActivateAlgorithm(_cargoShip);
        }
    }
}
