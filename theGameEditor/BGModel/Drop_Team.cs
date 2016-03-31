using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGModel
{
    public class Drop_Team
    {

        public int ID { get; set; }
        public string FstTeamID { get; set; }
        public string Name { get; set; }

        public string ItemTeamID { get; set; }

        public List<ItemTeamIModel> ItemTeamIList { get; set; }
    }

    public class ItemTeamIModel
    {
        public string ItemID { get; set; }
        public int DropCount { get; set; }
        public int TotalCount { get; set; }
        /// <summary>
        /// 概率
        /// </summary>
        public int Change { get; set; }
    }
}
