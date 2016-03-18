using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BGService;
using BGModel;

namespace theGameEditor
{
    public partial class FormMain : Form
    {
         //static readonly string pathTest =@"C:\game\blackGold\resServer\ini\Item\ItemUse.xml";
        static readonly string pathTest = @"F:\服务端合集\resServer\ini\Item\ItemUse.xml";
        public DataEnity DataEnity { get; set; }

        public FormMain()
        {
            InitializeComponent();
            DataEnity = new DataEnity();
            #region test 动态组件
            var dytext = new TextBox();
            dytext.Location = new System.Drawing.Point(244, 141);
            dytext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            dytext.Name = "textBox1";
            dytext.Size = new System.Drawing.Size(125, 23);
            dytext.TabIndex = 1;
            dytext.Text = "2323";
            tabCommonItem.Controls.Add(dytext);
            #endregion
            DataEnity.ItemUseModel = XmlHelper.GetModelObjectListByPath<ItemUse>(pathTest);
            Action<List<ItemUse>> tempMethod = FirstLabelListInitation;
            tempMethod.BeginInvoke(DataEnity.ItemUseModel, null, null);
        }

        public void FirstLabelListInitation(List<ItemUse> para)
        {
            if (para == null)
                throw new NullReferenceException("para为空");

            foreach (var item in para)
            {
                var Desc = item.Desc.GetLenthRe(20, " ");
                //ItemListBox.Items.Add(item.Desc.GetLenthRe(14," ")+"|"+item.ID.GetLenth(6));
                ItemListBox.Items.Add(item.Desc + "|" + item.ID);
            }
        }
    }
}
