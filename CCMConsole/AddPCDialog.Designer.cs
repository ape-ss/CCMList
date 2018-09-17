namespace CCMList
{
    partial class AddPCDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPCDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbAddress = new System.Windows.Forms.Label();
            this.edIpAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edFrendlyName = new System.Windows.Forms.TextBox();
            this.btAddPC = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lbAddress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.edIpAddress, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.edFrendlyName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btAddPC, 0, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lbAddress
            // 
            resources.ApplyResources(this.lbAddress, "lbAddress");
            this.lbAddress.Name = "lbAddress";
            // 
            // edIpAddress
            // 
            resources.ApplyResources(this.edIpAddress, "edIpAddress");
            this.edIpAddress.Name = "edIpAddress";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // edFrendlyName
            // 
            resources.ApplyResources(this.edFrendlyName, "edFrendlyName");
            this.edFrendlyName.Name = "edFrendlyName";
            this.edFrendlyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edFrendlyName_KeyPress);
            // 
            // btAddPC
            // 
            resources.ApplyResources(this.btAddPC, "btAddPC");
            this.btAddPC.Name = "btAddPC";
            this.btAddPC.UseVisualStyleBackColor = true;
            this.btAddPC.Click += new System.EventHandler(this.btAddPC_Click);
            // 
            // AddPCDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddPCDialog";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddPCDialog_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddPCDialog_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.TextBox edIpAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edFrendlyName;
        private System.Windows.Forms.Button btAddPC;
    }
}