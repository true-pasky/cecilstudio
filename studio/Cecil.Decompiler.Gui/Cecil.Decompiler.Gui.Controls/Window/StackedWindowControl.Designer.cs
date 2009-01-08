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
            this.closeBox = new System.Windows.Forms.PictureBox();
            this.iconPanel = new System.Windows.Forms.Panel();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.splitter = new Cecil.Decompiler.Gui.Controls.TableLayoutSplitter();
            this.topPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeBox)).BeginInit();
            this.iconPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
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
            // iconPanel
            // 
            this.iconPanel.Controls.Add(this.iconBox);
            this.iconPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconPanel.Location = new System.Drawing.Point(1, 1);
            this.iconPanel.Name = "iconPanel";
            this.iconPanel.Size = new System.Drawing.Size(16, 16);
            this.iconPanel.TabIndex = 2;
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
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 20);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(347, 130);
            this.mainPanel.TabIndex = 2;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.splitter);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 120);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(347, 10);
            this.bottomPanel.TabIndex = 2;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.SystemColors.Window;
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(347, 120);
            this.contentPanel.TabIndex = 3;
            // 
            // splitter
            // 
            this.splitter.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.Location = new System.Drawing.Point(0, 6);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(347, 4);
            this.splitter.StackedControl = this;
            this.splitter.TabIndex = 0;
            // 
            // StackedWindowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "StackedWindowControl";
            this.Size = new System.Drawing.Size(347, 150);
            this.topPanel.ResumeLayout(false);
            this.actionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.closeBox)).EndInit();
            this.iconPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox closeBox;
        private System.Windows.Forms.Panel iconPanel;
        protected internal System.Windows.Forms.PictureBox iconBox;
        protected internal System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel mainPanel;
        private TableLayoutSplitter splitter;
        private System.Windows.Forms.Panel bottomPanel;
        internal System.Windows.Forms.Panel contentPanel;
        internal System.Windows.Forms.Panel actionPanel;
    }
}
