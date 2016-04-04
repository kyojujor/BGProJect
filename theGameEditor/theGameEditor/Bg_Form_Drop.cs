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
using System.ComponentModel;

namespace theGameEditor
{
    public partial class FormMain : Form
    {

        #region    元数据
        public List<World_Drop_Complex> WorldDrop { get; set; }
        public List<Drop_Team> TeamDrop { get; set; }
        public List<Drop_Item> ItemDrop { get; set; }
        #endregion

        public List<World_Drop_Complex> dropSearchList { get; set; }

        private List<Drop_TeamByWorld> _WorldShowData;
        public List<Drop_TeamByWorld> WorldShowData { get { return _WorldShowData; } set { _WorldShowData = value; } }
        private List<Drop_ItemByTeam> _TeamShowData;
        public List<Drop_ItemByTeam> TeamShowData { get { return _TeamShowData; } set { _TeamShowData = value; } }
        private List<Drop_ItemByModel> _ItemShowData;
        public List<Drop_ItemByModel> ItemShowData { get { return _ItemShowData; } set { _ItemShowData = value; } }

        /// <summary>
        /// 双击事件
        /// 世界掉落
        /// 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVDrop_World_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DGV_Team.DataSource = null;
            DGV_Item.DataSource = null;

            var dgv = (DataGridView)sender;
            //var tempSource = new List<World_Drop_Complex>();
            var BindingSource = (IList<World_Drop_Complex>)dgv.DataSource;
            if (BindingSource == null || BindingSource.Count == 0)
            {
                return;
            }


            var index = e.RowIndex;

            if (index < 0 || index >= BindingSource.Count)
                return;
            var item = BindingSource[index];
            SplitHelper.SplitDropStr(item.FstTeamID, ref _WorldShowData);
            if (_WorldShowData != null || _WorldShowData.Count > 0)
            {
                foreach (var sk in _WorldShowData)
                {
                    var temp = TeamDrop.Find(x => x.FstTeamID == sk.TeamId);
                    if (temp != null)
                    {
                        sk.Name = temp.Name;
                    }
                }
            }
            DGVDrop_Team.GirdViewBlindData(WorldShowData);
        }

        /// <summary>
        ///  dgv2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVDrop_Team_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DGV_Item.DataSource = null;

            var dgv = (DataGridView)sender;
            var index = e.RowIndex;
            var tempSource = (IList<Drop_TeamByWorld>)dgv.DataSource;
            if (tempSource==null||index < 0 || index >= tempSource.Count)
                return;

            var item = tempSource[index];
            SplitHelper.SplitDropStr(TeamDrop.Find(x => x.FstTeamID == item.TeamId).ItemTeamID, ref _TeamShowData);
            if (_TeamShowData != null && _TeamShowData.Count > 0)
            {
                foreach (var sk in _TeamShowData)
                {
                    var tm = ItemDrop.Find(x => x.ItemTeamID == sk.ItemTeamID);
                    if(tm!=null)
                    sk.Name = tm.TeamName;
                }
            }
            DGV_Team.GirdViewBlindData(TeamShowData);
        }

        /// <summary>
        /// dGV3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_Team_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var index = e.RowIndex;

            var tempSource = (IList<Drop_ItemByTeam>)dgv.DataSource;
            if (tempSource == null || index < 0 || index >= tempSource.Count)
                return;

            var item = tempSource[index];
            SplitHelper.SplitDropStr(ItemDrop.Find(x => x.ItemTeamID == item.ItemTeamID).ItemID, ref _ItemShowData);
            if (_ItemShowData != null && _ItemShowData.Count > 0)
            {
                foreach (var sk in _ItemShowData)
                {
                    var temp = BGService.BgService.ItemSearch(sk.ItemUseID, DataModelList, true).FirstOrDefault();
                    if (temp != null)
                        sk.Name = temp.Desc;
                }
            }
            DGV_Item.GirdViewBlindData(ItemShowData);
        }

        /// <summary>
        /// drop1 搜索接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DropSearch_Click(object sender, EventArgs e)
        {
            var text = TB_DropWSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }
            dropSearchList = WorldDrop.FindAll(x => x.Name.Contains(text) || x.PackageID.Contains(text));
            DGVDrop_World.GirdViewBlindData(dropSearchList);
        }
    }
}
