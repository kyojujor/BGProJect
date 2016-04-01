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
        private string _FstTeamID = "";

         public int ID { get; set; }

        public string PackageID { get; set; }

        public string Name { get; set; }

        public string FstTeamID
        {
            get
            {
                return _FstTeamID;
            }
            set
            {
                //_FstTeamID = value;
                //FstTeamItemList = new List<FstTeamItem>();
                //if (!string.IsNullOrWhiteSpace(_FstTeamID))
                //{
                //    var itemList = _FstTeamID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                //    if (itemList != null && itemList.Count > 0)
                //    {
                //        foreach (var item in itemList)
                //        {
                //            var model = new FstTeamItem();
                //            var list = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                //            if (list.Count==3)
                //            {
                //                model.TeamID = list[0];
                //                model.MinDropCount = Convert.ToInt32(list[1]);
                //                model.MaxDropCount = Convert.ToInt32(list[2]);
                //                FstTeamItemList.Add(model);
                //            }
                //        }
                //    }
                //}
                SplitHelper.splitDropStr(value, ref this. _FstTeamID, ref _FstTeamItemList);
            }
        }

        private List<FstTeamItem> _FstTeamItemList;
        public List<FstTeamItem> FstTeamItemList
        {
            get
            {
                return _FstTeamItemList;
            }
        }
    }

    public class FstTeamItem
    {
        public string TeamID { get; set; }

        public int MinDropCount { get; set; }

        public int MaxDropCount { get; set; }
    }

}
