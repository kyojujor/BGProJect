using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BGModel;

namespace theGameEditor
{
    public partial class FormMain : Form
    {
        public List<ItemUse> itemUseList { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }
    }
}
