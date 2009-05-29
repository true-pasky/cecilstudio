namespace Cecil.Decompiler.Gui.Controls
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusbarControl = new Cecil.Decompiler.Gui.Controls.StatusbarControl();
            this.fillPanel = new System.Windows.Forms.Panel();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.assemblyBrowserControl = new Cecil.Decompiler.Gui.Controls.AssemblyBrowserControl();
            this.previewControl = new Cecil.Decompiler.Gui.Controls.PreviewControl();
            this.windowStackerControl = new Cecil.Decompiler.Gui.Controls.WindowStackerControl();
            this.topPanel = new System.Windows.Forms.Panel();
            this.breadCrumbControl = new Cecil.Decompiler.Gui.Controls.BreadCrumbControl();
            this.toolbarControl = new Cecil.Decompiler.Gui.Controls.ToolbarControl();
            this.menuControl = new Cecil.Decompiler.Gui.Controls.MenuControl();
            this.assemblyManager = new Cecil.Decompiler.Gui.Controls.AssemblyManagerComponent();
            this.bottomPanel.SuspendLayout();
            this.fillPanel.SuspendLayout();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.leftSplitContainer.Panel1.SuspendLayout();
            this.leftSplitContainer.Panel2.SuspendLayout();
            this.leftSplitContainer.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.statusbarControl);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 539);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(792, 27);
            this.bottomPanel.TabIndex = 0;
            // 
            // statusbarControl
            // 
            this.statusbarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusbarControl.Location = new System.Drawing.Point(0, 0);
            this.statusbarControl.Name = "statusbarControl";
            this.statusbarControl.Size = new System.Drawing.Size(792, 27);
            this.statusbarControl.TabIndex = 0;
            // 
            // fillPanel
            // 
            this.fillPanel.Controls.Add(this.mainSplitContainer);
            this.fillPanel.Controls.Add(this.topPanel);
            this.fillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fillPanel.Location = new System.Drawing.Point(0, 0);
            this.fillPanel.Name = "fillPanel";
            this.fillPanel.Size = new System.Drawing.Size(792, 539);
            this.fillPanel.TabIndex = 1;
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 74);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.leftSplitContainer);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.windowStackerControl);
            this.mainSplitContainer.Size = new System.Drawing.Size(792, 465);
            this.mainSplitContainer.SplitterDistance = 263;
            this.mainSplitContainer.TabIndex = 1;
            // 
            // leftSplitContainer
            // 
            this.leftSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.leftSplitContainer.Name = "leftSplitContainer";
            this.leftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // leftSplitContainer.Panel1
            // 
            this.leftSplitContainer.Panel1.Controls.Add(this.assemblyBrowserControl);
            // 
            // leftSplitContainer.Panel2
            // 
            this.leftSplitContainer.Panel2.Controls.Add(this.previewControl);
            this.leftSplitContainer.Size = new System.Drawing.Size(263, 465);
            this.leftSplitContainer.SplitterDistance = 304;
            this.leftSplitContainer.TabIndex = 0;
            // 
            // assemblyBrowserControl
            // 
            this.assemblyBrowserControl.ActiveItem = null;
            this.assemblyBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyBrowserControl.Location = new System.Drawing.Point(0, 0);
            this.assemblyBrowserControl.Name = "assemblyBrowserControl";
            this.assemblyBrowserControl.Size = new System.Drawing.Size(261, 302);
            this.assemblyBrowserControl.TabIndex = 0;
            // 
            // previewControl
            // 
            this.previewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl.Location = new System.Drawing.Point(0, 0);
            this.previewControl.Name = "previewControl";
            this.previewControl.Size = new System.Drawing.Size(261, 155);
            this.previewControl.TabIndex = 0;
            // 
            // windowStackerControl
            // 
            this.windowStackerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowStackerControl.Location = new System.Drawing.Point(0, 0);
            this.windowStackerControl.Name = "windowStackerControl";
            this.windowStackerControl.Size = new System.Drawing.Size(523, 463);
            this.windowStackerControl.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.toolbarControl);
            this.topPanel.Controls.Add(this.breadCrumbControl);
            this.topPanel.Controls.Add(this.menuControl);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(792, 74);
            this.topPanel.TabIndex = 0;
            // 
            // breadCrumbControl
            // 
            this.breadCrumbControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.breadCrumbControl.Location = new System.Drawing.Point(0, 24);
            this.breadCrumbControl.Name = "breadCrumbControl";
            this.breadCrumbControl.Size = new System.Drawing.Size(792, 25);
            this.breadCrumbControl.TabIndex = 1;
            // 
            // toolbarControl
            // 
            this.toolbarControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolbarControl.Location = new System.Drawing.Point(0, 49);
            this.toolbarControl.Name = "toolbarControl";
            this.toolbarControl.Size = new System.Drawing.Size(792, 25);
            this.toolbarControl.TabIndex = 1;
            // 
            // menuControl
            // 
            this.menuControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuControl.Location = new System.Drawing.Point(0, 0);
            this.menuControl.Name = "menuControl";
            this.menuControl.Size = new System.Drawing.Size(792, 24);
            this.menuControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.fillPanel);
            this.Controls.Add(this.bottomPanel);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cecil.Decompiler";
            this.bottomPanel.ResumeLayout(false);
            this.fillPanel.ResumeLayout(false);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.leftSplitContainer.Panel1.ResumeLayout(false);
            this.leftSplitContainer.Panel2.ResumeLayout(false);
            this.leftSplitContainer.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel fillPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer leftSplitContainer;
        private Cecil.Decompiler.Gui.Controls.AssemblyBrowserControl assemblyBrowserControl;
        private Cecil.Decompiler.Gui.Controls.PreviewControl previewControl;
        private Cecil.Decompiler.Gui.Controls.ToolbarControl toolbarControl;
        private Cecil.Decompiler.Gui.Controls.BreadCrumbControl breadCrumbControl;
        private Cecil.Decompiler.Gui.Controls.MenuControl menuControl;
        private Cecil.Decompiler.Gui.Controls.StatusbarControl statusbarControl;
        private Cecil.Decompiler.Gui.Controls.WindowStackerControl windowStackerControl;
        private Cecil.Decompiler.Gui.Controls.AssemblyManagerComponent assemblyManager;
    }
}