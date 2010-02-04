namespace Cecil.Decompiler.Gui.Controls
{
    partial class AssemblyBrowserControl
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
            this.components = new System.ComponentModel.Container();
            this.treeView = new System.Windows.Forms.TreeView();
            this.assemblyDefinitionBrowserMenu = new Cecil.Decompiler.Gui.Controls.ContentMenuComponent();
            this.iconsImageList = new System.Windows.Forms.ImageList(this.components);
            this.moduleDefinitionBrowserMenu = new Cecil.Decompiler.Gui.Controls.ContentMenuComponent();
            this.assemblyNameReferenceBrowserMenu = new Cecil.Decompiler.Gui.Controls.ContentMenuComponent();
            this.typeDefinitionBrowserMenu = new Cecil.Decompiler.Gui.Controls.ContentMenuComponent();
            this.methodDefinitionBrowserMenu = new Cecil.Decompiler.Gui.Controls.ContentMenuComponent();
            this.eventDefinitionBrowserMenu = new Cecil.Decompiler.Gui.Controls.ContentMenuComponent();
            this.propertyDefinitionBrowserMenu = new Cecil.Decompiler.Gui.Controls.ContentMenuComponent();
            this.fieldDefinitionBrowserMenu = new Cecil.Decompiler.Gui.Controls.ContentMenuComponent();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.iconsImageList;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(405, 272);
            this.treeView.TabIndex = 0;
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView_BeforeExpand);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // assemblyDefinitionBrowserMenu
            // 
            this.assemblyDefinitionBrowserMenu.Name = "assemblyBrowserMenu";
            this.assemblyDefinitionBrowserMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // iconsImageList
            // 
            this.iconsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iconsImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.iconsImageList.TransparentColor = System.Drawing.Color.Green;
            // 
            // moduleDefinitionBrowserMenu
            // 
            this.moduleDefinitionBrowserMenu.Name = "assemblyBrowserMenu";
            this.moduleDefinitionBrowserMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // assemblyNameReferenceBrowserMenu
            // 
            this.assemblyNameReferenceBrowserMenu.Name = "assemblyNameReferenceBrowserMenu";
            this.assemblyNameReferenceBrowserMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // typeDefinitionBrowserMenu
            // 
            this.typeDefinitionBrowserMenu.Name = "typeDefinitionBrowserMenu";
            this.typeDefinitionBrowserMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // methodDefinitionBrowserMenu
            // 
            this.methodDefinitionBrowserMenu.Name = "methodDefinitionBrowserMenu";
            this.methodDefinitionBrowserMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // eventDefinitionBrowserMenu
            // 
            this.eventDefinitionBrowserMenu.Name = "eventDefinitionBrowserMenu";
            this.eventDefinitionBrowserMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // propertyDefinitionBrowserMenu
            // 
            this.propertyDefinitionBrowserMenu.Name = "propertyDefinitionBrowserMenu";
            this.propertyDefinitionBrowserMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // fieldDefinitionBrowserMenu
            // 
            this.fieldDefinitionBrowserMenu.Name = "fieldDefinitionBrowserMenu";
            this.fieldDefinitionBrowserMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // AssemblyBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView);
            this.DoubleBuffered = true;
            this.Name = "AssemblyBrowserControl";
            this.Size = new System.Drawing.Size(405, 272);
            this.Load += new System.EventHandler(this.AssemblyBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ImageList iconsImageList;
        internal ContentMenuComponent assemblyDefinitionBrowserMenu;
        internal ContentMenuComponent moduleDefinitionBrowserMenu;
        internal ContentMenuComponent assemblyNameReferenceBrowserMenu;
        internal ContentMenuComponent typeDefinitionBrowserMenu;
        internal ContentMenuComponent methodDefinitionBrowserMenu;
        internal ContentMenuComponent eventDefinitionBrowserMenu;
        internal ContentMenuComponent propertyDefinitionBrowserMenu;
        internal ContentMenuComponent fieldDefinitionBrowserMenu;
    }
}
