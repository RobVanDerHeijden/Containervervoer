using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainervervoerCasus.Models
{
    public class Row
    {
        public List<Column> Columns;

        public Row(List<Column> columnso)
        {
            Columns = columnso;
        }
    }
}
