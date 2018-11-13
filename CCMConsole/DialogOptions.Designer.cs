namespace CCMAddrBook
{
    partial class DialogOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogOptions));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSCCMPath = new System.Windows.Forms.Label();
            this.EdSCCMPath = new System.Windows.Forms.TextBox();
            this.BtSelect = new System.Windows.Forms.Button();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtApply = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.labelSCCMPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EdSCCMPath, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtSelect, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BtOk, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.BtApply, 0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // labelSCCMPath
            // 
            resources.ApplyResources(this.labelSCCMPath, "labelSCCMPath");
            this.tableLayoutPanel1.SetColumnSpan(this.labelSCCMPath, 2);
            this.labelSCCMPath.Name = "labelSCCMPath";
            // 
            // EdSCCMPath
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.EdSCCMPath, 2);
            resources.ApplyResources(this.EdSCCMPath, "EdSCCMPath");
            this.EdSCCMPath.Name = "EdSCCMPath";
            // 
            // BtSelect
            // 
            resources.ApplyResources(this.BtSelect, "BtSelect");
            this.BtSelect.Name = "BtSelect";
            this.BtSelect.UseVisualStyleBackColor = true;
            this.BtSelect.Click += new System.EventHandler(this.BtSelect_Click);
            // 
            // BtOk
            // 
            resources.ApplyResources(this.BtOk, "BtOk");
            this.BtOk.Name = "BtOk";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtApply
            // 
            resources.ApplyResources(this.BtApply, "BtApply");
            this.BtApply.Name = "BtApply";
            this.BtApply.UseVisualStyleBackColor = true;
            this.BtApply.Click += new System.EventHandler(this.BtApply_Click);
            // 
            // DialogOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DialogOptions";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelSCCMPath;
        private System.Windows.Forms.TextBox EdSCCMPath;
        private System.Windows.Forms.Button BtSelect;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtApply;
        private System.Windows.Forms.OpenFileDialog openDialog;
    }
}