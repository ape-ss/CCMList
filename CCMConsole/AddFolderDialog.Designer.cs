namespace CCMAddrBook
{
    partial class AddFolderDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFolderDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbFolderName = new System.Windows.Forms.Label();
            this.edFolderName = new System.Windows.Forms.TextBox();
            this.btAddFolder = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lbFolderName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.edFolderName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btAddFolder, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lbFolderName
            // 
            resources.ApplyResources(this.lbFolderName, "lbFolderName");
            this.lbFolderName.Name = "lbFolderName";
            // 
            // edFolderName
            // 
            resources.ApplyResources(this.edFolderName, "edFolderName");
            this.edFolderName.Name = "edFolderName";
            this.edFolderName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edFolderName_KeyPress);
            // 
            // btAddFolder
            // 
            resources.ApplyResources(this.btAddFolder, "btAddFolder");
            this.btAddFolder.Name = "btAddFolder";
            this.btAddFolder.UseVisualStyleBackColor = true;
            this.btAddFolder.Click += new System.EventHandler(this.btAddFolder_Click);
            // 
            // AddFolderDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddFolderDialog";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddFolderDialog_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddFolderDialog_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbFolderName;
        private System.Windows.Forms.TextBox edFolderName;
        private System.Windows.Forms.Button btAddFolder;
    }
}