using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGModel.CommonHelper;

namespace BGModel
{
    public class World_Drop_Complex
    {
        public World_Drop_Complex()
        {
            //Drop_TeamList = new List<Drop_TeamByWorld>();
        }

         public int ID { get; set; }

        /// <summary>
        /// key
        /// </summary>
        public string PackageID { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// child
        /// </summary>
        public string FstTeamID {
            get;set;
        }

        //public List<Drop_TeamByWorld> Drop_TeamList { get; set; }
    }

    public class Drop_TeamByWorld
    {

        public string Name { get; set; }
        public string TeamId { get; set; }


        public int MinCount { get; set; }

        public int MaxCount { get; set; }
    } 

}
