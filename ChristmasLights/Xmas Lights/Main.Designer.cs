namespace JamesAllen.XmasLights
{
  partial class Main
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuAlternate = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuColors = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFlash = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.label3 = new System.Windows.Forms.Label();
      this.contextMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.contextMenu;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "Christmas Lights";
      this.notifyIcon.Visible = true;
      // 
      // contextMenu
      // 
      this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAlternate,
            this.mnuColors,
            this.mnuFlash,
            this.toolStripSeparator1,
            this.mnuExit});
      this.contextMenu.Name = "contextMenu";
      this.contextMenu.Size = new System.Drawing.Size(153, 120);
      // 
      // mnuAlternate
      // 
      this.mnuAlternate.Name = "mnuAlternate";
      this.mnuAlternate.Size = new System.Drawing.Size(152, 22);
      this.mnuAlternate.Text = "Alternate";
      this.mnuAlternate.Click += new System.EventHandler(this.mnuHandler_Click);
      // 
      // mnuColors
      // 
      this.mnuColors.Name = "mnuColors";
      this.mnuColors.Size = new System.Drawing.Size(152, 22);
      this.mnuColors.Text = "Colors";
      this.mnuColors.Click += new System.EventHandler(this.mnuHandler_Click);
      // 
      // mnuFlash
      // 
      this.mnuFlash.Name = "mnuFlash";
      this.mnuFlash.Size = new System.Drawing.Size(152, 22);
      this.mnuFlash.Text = "Flash";
      this.mnuFlash.Click += new System.EventHandler(this.mnuHandler_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
      // 
      // mnuExit
      // 
      this.mnuExit.Name = "mnuExit";
      this.mnuExit.Size = new System.Drawing.Size(152, 22);
      this.mnuExit.Text = "E&xit";
      this.mnuExit.Click += new System.EventHandler(this.mnuHandler_Click);
      // 
      // backgroundWorker
      // 
      this.backgroundWorker.WorkerSupportsCancellation = true;
      this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(99, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Christmas Lights";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(170, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "By James Allen, Copyright ©  2009";
      // 
      // linkLabel1
      // 
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new System.Drawing.Point(12, 79);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(166, 13);
      this.linkLabel1.TabIndex = 3;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "http://www.webdesignerwall.com";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 66);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(104, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Graphics courtesy of";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(251, 101);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.linkLabel1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "FormMain";
      this.ShowInTaskbar = false;
      this.Text = "Christmas Lights";
      this.TopMost = true;
      this.contextMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.ContextMenuStrip contextMenu;
    private System.Windows.Forms.ToolStripMenuItem mnuExit;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ToolStripMenuItem mnuAlternate;
    private System.Windows.Forms.ToolStripMenuItem mnuColors;
    private System.Windows.Forms.ToolStripMenuItem mnuFlash;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
  }
}

