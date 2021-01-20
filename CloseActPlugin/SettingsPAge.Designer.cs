namespace CloseActPlugin
{
    public partial class SettingsPage
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
            this.ChkMinimize = new System.Windows.Forms.CheckBox();
            this.ChkClose = new System.Windows.Forms.CheckBox();
            this.ChkClear = new System.Windows.Forms.CheckBox();
            this.ChkSingleton = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ChkMinimize
            // 
            this.ChkMinimize.AutoSize = true;
            this.ChkMinimize.Location = new System.Drawing.Point(13, 13);
            this.ChkMinimize.Name = "ChkMinimize";
            this.ChkMinimize.Size = new System.Drawing.Size(140, 17);
            this.ChkMinimize.TabIndex = 0;
            this.ChkMinimize.Text = "Minimize ACT on startup";
            this.ChkMinimize.UseVisualStyleBackColor = true;
            this.ChkMinimize.CheckedChanged += new System.EventHandler(this.ChkMinimize_CheckedChanged);
            // 
            // ChkClose
            // 
            this.ChkClose.AutoSize = true;
            this.ChkClose.Location = new System.Drawing.Point(13, 36);
            this.ChkClose.Name = "ChkClose";
            this.ChkClose.Size = new System.Drawing.Size(142, 17);
            this.ChkClose.TabIndex = 1;
            this.ChkClose.Text = "Close ACT on FFXIV exit";
            this.ChkClose.UseVisualStyleBackColor = true;
            this.ChkClose.CheckedChanged += new System.EventHandler(this.ChkClose_CheckedChanged);
            // 
            // ChkClear
            // 
            this.ChkClear.AutoSize = true;
            this.ChkClear.Location = new System.Drawing.Point(13, 59);
            this.ChkClear.Name = "ChkClear";
            this.ChkClear.Size = new System.Drawing.Size(289, 17);
            this.ChkClear.TabIndex = 2;
            this.ChkClear.Text = "Clear encounters on combat end (useful for low-end PC)";
            this.ChkClear.UseVisualStyleBackColor = true;
            this.ChkClear.CheckedChanged += new System.EventHandler(this.ChkClear_CheckedChanged);
            // 
            // ChkSingleton
            // 
            this.ChkSingleton.AutoSize = true;
            this.ChkSingleton.Location = new System.Drawing.Point(13, 82);
            this.ChkSingleton.Name = "ChkSingleton";
            this.ChkSingleton.Size = new System.Drawing.Size(203, 17);
            this.ChkSingleton.TabIndex = 3;
            this.ChkSingleton.Text = "Disallow more than one ACT instance";
            this.ChkSingleton.UseVisualStyleBackColor = true;
            this.ChkSingleton.CheckedChanged += new System.EventHandler(this.ChkSingleton_CheckedChanged);
            // 
            // SettingsPage
            // 
            this.Controls.Add(this.ChkSingleton);
            this.Controls.Add(this.ChkClear);
            this.Controls.Add(this.ChkClose);
            this.Controls.Add(this.ChkMinimize);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "SettingsPage";
            this.Size = new System.Drawing.Size(375, 255);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox ChkMinimize;
        public System.Windows.Forms.CheckBox ChkClose;
        public System.Windows.Forms.CheckBox ChkClear;
        public System.Windows.Forms.CheckBox ChkSingleton;
    }
}
