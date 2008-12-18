namespace Cecil.Decompiler.Gui.Controls
{
    partial class MenuControl
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new Cecil.Decompiler.Gui.Controls.ToolStripMenuItem();
            this.loadMenuItem = new Cecil.Decompiler.Gui.Controls.ToolStripMenuItem();
            this.unloadMenuItem = new Cecil.Decompiler.Gui.Controls.ToolStripMenuItem();
            this.viewMenuItem = new Cecil.Decompiler.Gui.Controls.ToolStripMenuItem();
            this.backMenuItem = new Cecil.Decompiler.Gui.Controls.ToolStripMenuItem();
            this.forwardMenuItem = new Cecil.Decompiler.Gui.Controls.ToolStripMenuItem();
            this.toolsMenuItem = new Cecil.Decompiler.Gui.Controls.ToolStripMenuItem();
            this.analyzeMenuItem = new Cecil.Decompiler.Gui.Controls.ToolStripMenuItem();
            this.disassembleMenuItem = new Cecil.Decompiler.Gui.Controls.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.viewMenuItem,
            this.toolsMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(150, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.MenuStrip_ItemAdded);
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.ActionName = Cecil.Decompiler.Gui.Actions.ActionNames.None;
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenuItem,
            this.unloadMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileMenuItem.Text = "&File";
            // 
            // loadMenuItem
            // 
            this.loadMenuItem.ActionName = Cecil.Decompiler.Gui.Actions.ActionNames.LoadAssembly;
            this.loadMenuItem.Image = global::Cecil.Decompiler.Gui.Properties.Resources.folder;
            this.loadMenuItem.Name = "loadMenuItem";
            this.loadMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.loadMenuItem.Size = new System.Drawing.Size(160, 22);
            this.loadMenuItem.Text = "Load...";
            // 
            // unloadMenuItem
            // 
            this.unloadMenuItem.ActionName = Cecil.Decompiler.Gui.Actions.ActionNames.UnloadAssembly;
            this.unloadMenuItem.Image = global::Cecil.Decompiler.Gui.Properties.Resources.window_close;
            this.unloadMenuItem.Name = "unloadMenuItem";
            this.unloadMenuItem.Size = new System.Drawing.Size(160, 22);
            this.unloadMenuItem.Text = "Unload...";
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.ActionName = Cecil.Decompiler.Gui.Actions.ActionNames.None;
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backMenuItem,
            this.forwardMenuItem});
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewMenuItem.Text = "&View";
            // 
            // backMenuItem
            // 
            this.backMenuItem.ActionName = Cecil.Decompiler.Gui.Actions.ActionNames.GoBack;
            this.backMenuItem.Image = global::Cecil.Decompiler.Gui.Properties.Resources.go_back;
            this.backMenuItem.Name = "backMenuItem";
            this.backMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left)));
            this.backMenuItem.Size = new System.Drawing.Size(178, 22);
            this.backMenuItem.Text = "Back";
            // 
            // forwardMenuItem
            // 
            this.forwardMenuItem.ActionName = Cecil.Decompiler.Gui.Actions.ActionNames.GoForward;
            this.forwardMenuItem.Image = global::Cecil.Decompiler.Gui.Properties.Resources.go_forward;
            this.forwardMenuItem.Name = "forwardMenuItem";
            this.forwardMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right)));
            this.forwardMenuItem.Size = new System.Drawing.Size(178, 22);
            this.forwardMenuItem.Text = "Forward";
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.ActionName = Cecil.Decompiler.Gui.Actions.ActionNames.None;
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analyzeMenuItem,
            this.disassembleMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsMenuItem.Text = "&Tools";
            // 
            // analyzeMenuItem
            // 
            this.analyzeMenuItem.ActionName = Cecil.Decompiler.Gui.Actions.ActionNames.Analyze;
            this.analyzeMenuItem.Image = global::Cecil.Decompiler.Gui.Properties.Resources.analyze;
            this.analyzeMenuItem.Name = "analyzeMenuItem";
            this.analyzeMenuItem.ShortcutKeyDisplayString = "";
            this.analyzeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.analyzeMenuItem.Text = "Analyze";
            // 
            // disassembleMenuItem
            // 
            this.disassembleMenuItem.ActionName = Cecil.Decompiler.Gui.Actions.ActionNames.Disassemble;
            this.disassembleMenuItem.Image = global::Cecil.Decompiler.Gui.Properties.Resources.disassemble;
            this.disassembleMenuItem.Name = "disassembleMenuItem";
            this.disassembleMenuItem.ShortcutKeyDisplayString = "";
            this.disassembleMenuItem.Size = new System.Drawing.Size(152, 22);
            this.disassembleMenuItem.Text = "Disassemble";
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(150, 24);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private Cecil.Decompiler.Gui.Controls.ToolStripMenuItem fileMenuItem;
        private Cecil.Decompiler.Gui.Controls.ToolStripMenuItem loadMenuItem;
        private Cecil.Decompiler.Gui.Controls.ToolStripMenuItem toolsMenuItem;
        private Cecil.Decompiler.Gui.Controls.ToolStripMenuItem disassembleMenuItem;
        private Cecil.Decompiler.Gui.Controls.ToolStripMenuItem viewMenuItem;
        private Cecil.Decompiler.Gui.Controls.ToolStripMenuItem backMenuItem;
        private Cecil.Decompiler.Gui.Controls.ToolStripMenuItem forwardMenuItem;
        private ToolStripMenuItem unloadMenuItem;
        private ToolStripMenuItem analyzeMenuItem;
    }
}
