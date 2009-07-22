namespace Cecil.Decompiler.Gui.Controls
{
    partial class ToolbarControl
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.backButton = new Cecil.Decompiler.Gui.Controls.BarButton();
            this.forwardButton = new Cecil.Decompiler.Gui.Controls.BarButton();
            this.loadButton = new Cecil.Decompiler.Gui.Controls.BarButton();
            this.languageSelector = new Cecil.Decompiler.Gui.Controls.LanguageSelectorControl();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton,
            this.forwardButton,
            this.toolStripSeparator,
            this.loadButton,
            this.languageSelector});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(150, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.ItemAdded);
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ItemClick);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // backButton
            // 
            this.backButton.ActionName = Cecil.Decompiler.Gui.Services.ActionNames.GoBack;
            this.backButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backButton.Image = global::Cecil.Decompiler.Gui.Properties.Resources.go_back;
            this.backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(23, 22);
            this.backButton.Text = "Back";
            // 
            // forwardButton
            // 
            this.forwardButton.ActionName = Cecil.Decompiler.Gui.Services.ActionNames.GoForward;
            this.forwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardButton.Image = global::Cecil.Decompiler.Gui.Properties.Resources.go_forward;
            this.forwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(23, 22);
            this.forwardButton.Text = "Forward";
            // 
            // loadButton
            // 
            this.loadButton.ActionName = Cecil.Decompiler.Gui.Services.ActionNames.LoadAssembly;
            this.loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadButton.Image = global::Cecil.Decompiler.Gui.Properties.Resources.folder;
            this.loadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(23, 22);
            this.loadButton.Text = "Load ...";
            // 
            // languageSelector
            // 
            this.languageSelector.ActiveLanguage = null;
            this.languageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageSelector.Name = "languageSelector";
            this.languageSelector.Size = new System.Drawing.Size(128, 21);
            // 
            // ToolbarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Name = "ToolbarControl";
            this.Size = new System.Drawing.Size(150, 25);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private Cecil.Decompiler.Gui.Controls.LanguageSelectorControl languageSelector;
        private Cecil.Decompiler.Gui.Controls.BarButton loadButton;
        private Cecil.Decompiler.Gui.Controls.BarButton backButton;
        private Cecil.Decompiler.Gui.Controls.BarButton forwardButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    }
}
