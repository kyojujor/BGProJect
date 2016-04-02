using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGModel.CommonHelper;
using System.Web;
using System.Web.Caching;

namespace BGModel
{
    public class Drop_Item
    {
        public Drop_Item()
        {
            //ItemModelList = new List<Drop_ItemByModel>();
        }

        public int ID { get; set; }
        /// <summary>
        /// key
        /// </summary>
        public string ItemTeamID { get; set; }
        public string TeamName { get; set; }

        /// <summary>
        /// child
        /// </summary>
        public string ItemID { get; set; }

        //public List<Drop_ItemByModel> ItemModelList { get; set; }
    }

    public class Drop_ItemByModel
    {

        public string Name { get; set; }

        public string ItemUseID { get; set; }


        public int Count { get; set; }



    }
}
