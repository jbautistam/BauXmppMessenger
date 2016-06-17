namespace TestSharpXmpp
{
	partial class frmMain
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
			this.trvContacts = new TestSharpXmpp.UC.TreeContacts();
			this.collapsiblePanelSplitter1 = new Bau.Controls.Split.CollapsiblePanelSplitter();
			this.tabChat = new Bau.Controls.TabControls.TabControlExtended();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtMessages = new System.Windows.Forms.TextBox();
			this.cmdNew = new System.Windows.Forms.ToolStripButton();
			this.cmdUpdate = new System.Windows.Forms.ToolStripButton();
			this.cmdDelete = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.collapsiblePanelSplitter1)).BeginInit();
			this.collapsiblePanelSplitter1.Panel1.SuspendLayout();
			this.collapsiblePanelSplitter1.Panel2.SuspendLayout();
			this.collapsiblePanelSplitter1.SuspendLayout();
			this.tabChat.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// trvContacts
			// 
			this.trvContacts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.trvContacts.ForeColor = System.Drawing.Color.Black;
			this.trvContacts.Location = new System.Drawing.Point(0, 0);
			this.trvContacts.Name = "trvContacts";
			this.trvContacts.Size = new System.Drawing.Size(229, 666);
			this.trvContacts.TabIndex = 0;
			this.trvContacts.CreateConnection += new System.EventHandler(this.trvContacts_CreateConnection);
			this.trvContacts.CreateUser += new System.EventHandler(this.trvContacts_CreateUser);
			this.trvContacts.SetStatus += new System.EventHandler<TestSharpXmpp.UC.SetStatusEventArgs>(this.trvContacts_SetStatus);
			this.trvContacts.SelectedContact += new System.EventHandler<TestSharpXmpp.UC.SelectedContactEventArgs>(this.trvContacts_SelectedContact);
			// 
			// collapsiblePanelSplitter1
			// 
			this.collapsiblePanelSplitter1.BackColorSplitter = System.Drawing.SystemColors.Control;
			this.collapsiblePanelSplitter1.CollapseAction = Bau.Controls.Split.CollapsiblePanelSplitter.CollapseMode.CollapsePanel1;
			this.collapsiblePanelSplitter1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.collapsiblePanelSplitter1.Location = new System.Drawing.Point(0, 0);
			this.collapsiblePanelSplitter1.Name = "collapsiblePanelSplitter1";
			// 
			// collapsiblePanelSplitter1.Panel1
			// 
			this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.trvContacts);
			this.collapsiblePanelSplitter1.Panel1MinSize = 0;
			// 
			// collapsiblePanelSplitter1.Panel2
			// 
			this.collapsiblePanelSplitter1.Panel2.Controls.Add(this.tabChat);
			this.collapsiblePanelSplitter1.Panel2MinSize = 0;
			this.collapsiblePanelSplitter1.Size = new System.Drawing.Size(679, 666);
			this.collapsiblePanelSplitter1.SplitterDistance = 229;
			this.collapsiblePanelSplitter1.SplitterStyle = Bau.Controls.Split.CollapsiblePanelSplitter.VisualStyles.Mozilla;
			this.collapsiblePanelSplitter1.SplitterWidth = 8;
			this.collapsiblePanelSplitter1.TabIndex = 2;
			// 
			// tabChat
			// 
			this.tabChat.Controls.Add(this.tabPage2);
			this.tabChat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabChat.Location = new System.Drawing.Point(0, 0);
			this.tabChat.Name = "tabChat";
			this.tabChat.SelectedIndex = 0;
			this.tabChat.Size = new System.Drawing.Size(442, 666);
			this.tabChat.TabIndex = 1;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtMessages);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(5);
			this.tabPage2.Size = new System.Drawing.Size(434, 640);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Log";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtMessages
			// 
			this.txtMessages.BackColor = System.Drawing.Color.White;
			this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMessages.Location = new System.Drawing.Point(5, 5);
			this.txtMessages.Multiline = true;
			this.txtMessages.Name = "txtMessages";
			this.txtMessages.ReadOnly = true;
			this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtMessages.Size = new System.Drawing.Size(424, 630);
			this.txtMessages.TabIndex = 0;
			// 
			// cmdNew
			// 
			this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdNew.Image = global::TestSharpXmpp.Properties.Resources.page;
			this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdNew.Name = "cmdNew";
			this.cmdNew.Size = new System.Drawing.Size(23, 22);
			this.cmdNew.Text = "Nuevo";
			this.cmdNew.ToolTipText = "Nuevo";
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdUpdate.Image = global::TestSharpXmpp.Properties.Resources.page_white_text_width;
			this.cmdUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.Size = new System.Drawing.Size(23, 22);
			this.cmdUpdate.Text = "Modificar";
			this.cmdUpdate.ToolTipText = "Modificar";
			// 
			// cmdDelete
			// 
			this.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdDelete.Image = global::TestSharpXmpp.Properties.Resources.cross;
			this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(23, 22);
			this.cmdDelete.Text = "Borrar";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(679, 666);
			this.Controls.Add(this.collapsiblePanelSplitter1);
			this.Name = "frmMain";
			this.Text = "BauMessenger";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.collapsiblePanelSplitter1.Panel1.ResumeLayout(false);
			this.collapsiblePanelSplitter1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.collapsiblePanelSplitter1)).EndInit();
			this.collapsiblePanelSplitter1.ResumeLayout(false);
			this.tabChat.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private Bau.Controls.Split.CollapsiblePanelSplitter collapsiblePanelSplitter1;
		private System.Windows.Forms.TextBox txtMessages;
		private System.Windows.Forms.ToolStripButton cmdNew;
		private System.Windows.Forms.ToolStripButton cmdUpdate;
		private System.Windows.Forms.ToolStripButton cmdDelete;
		private UC.TreeContacts trvContacts;
		private Bau.Controls.TabControls.TabControlExtended tabChat;
		private System.Windows.Forms.TabPage tabPage2;
	}
}

