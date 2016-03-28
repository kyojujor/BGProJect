namespace CompositeControllerDemo
{
    partial class LabelTextBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Text = new System.Windows.Forms.Label();
            this.textBox_Content = new System.Windows.Forms.TextBox();
            this.label_Relate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Text
            // 
            this.label_Text.AutoSize = true;
            this.label_Text.Location = new System.Drawing.Point(8, 6);
            this.label_Text.Name = "label_Text";
            this.label_Text.Size = new System.Drawing.Size(29, 12);
            this.label_Text.TabIndex = 0;
            this.label_Text.Text = "内容";
            // 
            // textBox_Content
            // 
            this.textBox_Content.Location = new System.Drawing.Point(105, 3);
            this.textBox_Content.Name = "textBox_Content";
            this.textBox_Content.Size = new System.Drawing.Size(100, 21);
            this.textBox_Content.TabIndex = 1;
            // 
            // label_Relate
            // 
            this.label_Relate.AutoSize = true;
            this.label_Relate.ForeColor = System.Drawing.Color.Red;
            this.label_Relate.Location = new System.Drawing.Point(211, 6);
            this.label_Relate.Name = "label_Relate";
            this.label_Relate.Size = new System.Drawing.Size(29, 12);
            this.label_Relate.TabIndex = 2;
            this.label_Relate.Text = "链接";
            this.label_Relate.Click += new System.EventHandler(this.label_Relate_Click);
            // 
            // LabelTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label_Relate);
            this.Controls.Add(this.textBox_Content);
            this.Controls.Add(this.label_Text);
            this.Name = "LabelTextBox";
            this.Size = new System.Drawing.Size(311, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Text;
        private System.Windows.Forms.TextBox textBox_Content;
        private System.Windows.Forms.Label label_Relate;
    }
}
