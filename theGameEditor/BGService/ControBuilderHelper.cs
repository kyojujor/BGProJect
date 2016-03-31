using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompositeControllerDemo;

namespace BGService
{
    /// <summary>
    /// 组件操作类
    /// </summary>
    public static class ControBuilderHelper
    {
        /// <summary>
        /// Listbox需要重新绑数据源的方法
        /// </summary>
        /// <param name="con">listbox控件</param>
        /// <param name="obj">所绑定的数据源,必须实现迭代接口</param>
        /// <param name="desc">需要展示的项的名字</param>
        public static void ListBoxBlindData(this ListBox con ,object obj,string desc, List<LabelTextBox> listBox)
        {
            con.DataSource = null;
            con.DataSource = obj;
            con.DisplayMember = desc;
            con.SelectedIndex = 0;
            BgService.ItemBlindToLabelTextBox(listBox, con.SelectedItem);
            //con.SelectedItem
        }
    }
}
