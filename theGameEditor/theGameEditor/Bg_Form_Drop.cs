using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BGService;
using BGModel;
using System.Threading;
using CompositeControllerDemo;

namespace theGameEditor
{
    public partial class FormMain : Form
    {
       

        public List<World_Drop_Complex> WorldDrop { get; set; }
        public List<Drop_Team> TeamDrop { get; set; }
        public List<Drop_Item> ItemDrop { get; set; }

        private List<Drop_TeamByWorld> _WorldShowData;
        public List<Drop_TeamByWorld> WorldShowData { get { return _WorldShowData; } set { _WorldShowData = value; } }
        private List<Drop_ItemByTeam> _TeamShowData;
        public List<Drop_ItemByTeam> TeamShowData { get { return _TeamShowData; } set { _TeamShowData = value; } }
        private List<Drop_ItemByModel> _ItemShowData;
        public List<Drop_ItemByModel> ItemShowData { get { return _ItemShowData; } set { _ItemShowData = value; } }

        /// <summary>
        /// 双击事件
        /// 世界掉落
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVDrop_World_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            //var a =  dgv.CurrentRow.Cells;
            var index = e.RowIndex;
            var item = WorldDrop[index];
            SplitHelper.SplitDropStr(item.FstTeamID, ref _WorldShowData);
            if (_WorldShowData!=null && _WorldShowData.Count>0)
            {
                foreach (var sk in _WorldShowData)
                {
                    sk.Name = TeamDrop.Find(x => x.FstTeamID == sk.TeamId).Name;
                }
            }
            DGVDrop_Team.GirdViewBlindData(WorldShowData);
        }

        private void DGVDrop_Team_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var index = e.RowIndex;
            var item = WorldShowData[index];
            SplitHelper.SplitDropStr(TeamDrop.Find(x => x.FstTeamID ==item.TeamId).ItemTeamID , ref _TeamShowData);
            if (_TeamShowData != null && _TeamShowData.Count > 0)
            {
                foreach (var sk in _TeamShowData)
                {
                    sk.Name = ItemDrop.Find(x => x.ItemTeamID == sk.ItemTeamID).TeamName;
                }
            }
            DGV_Team.GirdViewBlindData(TeamShowData);
        }

        private void DGV_Team_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var index = e.RowIndex;
            var item = TeamShowData[index];
            SplitHelper.SplitDropStr(ItemDrop.Find(x => x.ItemTeamID == item.ItemTeamID).ItemID, ref _ItemShowData);
            if (_ItemShowData != null && _ItemShowData.Count > 0)
            {
                //foreach (var sk in _ItemShowData)
                //{
                //    sk.Name = ItemDrop.Find(x => x.ItemTeamID == sk.ItemTeamID).TeamName;
                //}
            }
            DGV_Item.GirdViewBlindData(ItemShowData);
        }
    }
}
