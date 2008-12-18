namespace Cecil.Decompiler.Gui.Controls
{
    partial class StackedWindowControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.iconPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.closeBox = new System.Windows.Forms.PictureBox();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.topPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.iconPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.Info;
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Controls.Add(this.label);
            this.topPanel.Controls.Add(this.actionPanel);
            this.topPanel.Controls.Add(this.iconPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(1);
            this.topPanel.Size = new System.Drawing.Size(347, 20);
            this.topPanel.TabIndex = 0;
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(17, 1);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(311, 16);
            this.label.TabIndex = 1;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.closeBox);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.actionPanel.Location = new System.Drawing.Point(328, 1);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(16, 16);
            this.actionPanel.TabIndex = 0;
            // 
            // iconPanel
            // 
            this.iconPanel.Controls.Add(this.iconBox);
            this.iconPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconPanel.Location = new System.Drawing.Point(1, 1);
            this.iconPanel.Name = "iconPanel";
            this.iconPanel.Size = new System.Drawing.Size(16, 16);
            this.iconPanel.TabIndex = 2;
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 20);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(347, 130);
            this.contentPanel.TabIndex = 1;
            // 
            // closeBox
            // 
            this.closeBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closeBox.Image = global::Cecil.Decompiler.Gui.Properties.Resources.window_close;
            this.closeBox.Location = new System.Drawing.Point(0, 0);
            this.closeBox.Name = "closeBox";
            this.closeBox.Size = new System.Drawing.Size(16, 16);
            this.closeBox.TabIndex = 0;
            this.closeBox.TabStop = false;
            this.closeBox.Click += new System.EventHandler(this.CloseBox_Click);
            // 
            // iconBox
            // 
            this.iconBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconBox.Location = new System.Drawing.Point(0, 0);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(16, 16);
            this.iconBox.TabIndex = 0;
            this.iconBox.TabStop = false;
            // 
            // StackedWindowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "StackedWindowControl";
            this.Size = new System.Drawing.Size(347, 150);
            this.topPanel.ResumeLayout(false);
            this.actionPanel.ResumeLayout(false);
            this.iconPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.closeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        protected internal System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.PictureBox closeBox;
        private System.Windows.Forms.Panel iconPanel;
        protected internal System.Windows.Forms.PictureBox iconBox;
        protected internal System.Windows.Forms.Label label;
    }
}
