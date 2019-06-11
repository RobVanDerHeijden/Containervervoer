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
        public ContainervervoerCasus()
        {
            InitializeComponent();
        }
        
        private void Btn_AddContainer_Click(object sender, EventArgs e)
        {
            Enum.TryParse<ContainerType>(Cbbx_ContainerType.SelectedValue.ToString(), out ContainerType status);
            string containerType = Cbbx_ContainerType.SelectedValue.ToString();
            if (containerType == "Cooled")
            {
                CooledContainer newContainer = new CooledContainer();
                Lbx_Containers.Items.Add(newContainer);
            }
            else if (containerType == "Valuable")
            {
                ValuableContainer newContainer = new ValuableContainer();
                Lbx_Containers.Items.Add(newContainer);
            }
            else if (containerType == "Regular")
            {
                Container newContainer = new Container(5, status);
                Lbx_Containers.Items.Add(newContainer);
            }

            //UpdateContainersStats();
        }

        private void ContainervervoerCasus_Load(object sender, EventArgs e)
        {
            Cbbx_ContainerType.DataSource = Enum.GetValues(typeof(ContainerType));
        }
    }
}
