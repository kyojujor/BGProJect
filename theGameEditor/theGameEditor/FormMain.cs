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
         static readonly string pathTest =@"C:\game\blackGold\resServer\ini\Item\ItemUse.xml";
        public DataEnity DataEnity { get; set; }

        public FormMain()
        {
            InitializeComponent();
            DataEnity = new DataEnity();
            DataEnity.ItemUseModel = XmlHelper.GetModelObjectListByPath(pathTest) as List<ItemUse>;
            Action<List<ItemUse>> tempMethod = ListInitation;
            tempMethod.BeginInvoke(DataEnity.ItemUseModel, null, null);
        }

        public void ListInitation(List<ItemUse> para)
        {
            if (para == null)
                throw new NullReferenceException("para为空");

            foreach (var item in para)
            {
                var temp = item.Desc.GetLenthRe(20, " ");
                //ItemListBox.Items.Add(item.Desc.GetLenthRe(14," ")+"|"+item.ID.GetLenth(6));
                ItemListBox.Items.Add(temp + "|" + temp.Length);
            }
        }
    }
}
