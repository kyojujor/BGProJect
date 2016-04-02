using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGModel.CommonHelper;

namespace BGModel
{
    public class Drop_Team
    {
        public Drop_Team()
        {
            //Drop_ItemList = new List<Drop_ItemByTeam>();
        }

        public int ID { get; set; }
        /// <summary>
        /// key
        /// </summary>
        public string FstTeamID { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// child
        /// </summary>
        public string ItemTeamID
        {
            get;set;
        }

        //public List<Drop_ItemByTeam> Drop_ItemList { get; set; }
    }

    public class Drop_ItemByTeam
    {

        public string Name { get; set; }

        public string ItemTeamID { get; set; }
        /// <summary>
        /// 出几种
        /// </summary>
        public string OutCount { get; set; }

        /// <summary>
        /// 总共几种
        /// </summary>
        public string TotalCount { get; set; }

        /// <summary>
        /// 几率
        /// </summary>
        public string Change { get; set; }
    }
}
