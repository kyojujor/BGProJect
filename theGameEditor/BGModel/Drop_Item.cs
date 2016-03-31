using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGModel
{
    public class Drop_Item
    {
        public int ID { get; set; }

        public string ItemTeamID { get; set; }
        public string TeamName { get; set; }
        public string ItemID { get; set; }

        public List<ItemModelList> ItemList { get; set; }

    }

    public class ItemModelList
    {
        public string ID { get; set; }

        public int Count { get; set; }
    }
}
