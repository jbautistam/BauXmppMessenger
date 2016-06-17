namespace TestSharpXmpp.UC
{
	partial class TreeContacts
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeContacts));
			this.trvContacts = new Bau.Controls.Tree.TreeViewExtended();
			this.tlbList = new System.Windows.Forms.ToolStrip();
			this.cmdSetStatus = new System.Windows.Forms.ToolStripDropDownButton();
			this.mnuConnect = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDisconnect = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuOnline = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAway = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuChat = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDnd = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuXa = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdNew = new System.Windows.Forms.ToolStripButton();
			this.cmdUpdate = new System.Windows.Forms.ToolStripButton();
			this.cmdDelete = new System.Windows.Forms.ToolStripButton();
			this.cmdCreateUser = new System.Windows.Forms.ToolStripButton();
			this.cmdNewConnection = new System.Windows.Forms.ToolStripButton();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.tlbList.SuspendLayout();
			this.SuspendLayout();
			// 
			// trvContacts
			// 
			this.trvContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trvContacts.CheckRecursive = false;
			this.trvContacts.HideSelection = false;
			this.trvContacts.Location = new System.Drawing.Point(3, 28);
			this.trvContacts.Name = "trvContacts";
			this.trvContacts.ShowNodeToolTips = true;
			this.trvContacts.Size = new System.Drawing.Size(381, 572);
			this.trvContacts.TabIndex = 3;
			this.trvContacts.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvContacts_NodeMouseDoubleClick);
			// 
			// tlbList
			// 
			this.tlbList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tlbList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdSetStatus,
            this.toolStripSeparator1,
            this.cmdNew,
            this.cmdUpdate,
            this.cmdDelete,
            this.cmdCreateUser,
            this.cmdNewConnection});
			this.tlbList.Location = new System.Drawing.Point(0, 0);
			this.tlbList.Name = "tlbList";
			this.tlbList.Size = new System.Drawing.Size(387, 25);
			this.tlbList.TabIndex = 4;
			this.tlbList.Text = "toolStrip1";
			// 
			// cmdSetStatus
			// 
			this.cmdSetStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdSetStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect,
            this.mnuDisconnect,
            this.toolStripMenuItem1,
            this.mnuOnline,
            this.mnuAway,
            this.mnuChat,
            this.mnuDnd,
            this.mnuXa});
			this.cmdSetStatus.Image = global::TestSharpXmpp.Properties.Resources.ContactAway;
			this.cmdSetStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdSetStatus.Name = "cmdSetStatus";
			this.cmdSetStatus.Size = new System.Drawing.Size(29, 22);
			this.cmdSetStatus.Text = "toolStripButton1";
			this.cmdSetStatus.ToolTipText = "Cambio de estado";
			this.cmdSetStatus.DropDownOpening += new System.EventHandler(this.cmdSetStatus_DropDownOpening);
			// 
			// mnuConnect
			// 
			this.mnuConnect.Name = "mnuConnect";
			this.mnuConnect.Size = new System.Drawing.Size(139, 22);
			this.mnuConnect.Text = "Conectar";
			this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
			// 
			// mnuDisconnect
			// 
			this.mnuDisconnect.Name = "mnuDisconnect";
			this.mnuDisconnect.Size = new System.Drawing.Size(139, 22);
			this.mnuDisconnect.Text = "Desconectar";
			this.mnuDisconnect.Click += new System.EventHandler(this.mnuDisconnect_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 6);
			// 
			// mnuOnline
			// 
			this.mnuOnline.Name = "mnuOnline";
			this.mnuOnline.Size = new System.Drawing.Size(139, 22);
			this.mnuOnline.Text = "Online";
			this.mnuOnline.Click += new System.EventHandler(this.mnuOnline_Click);
			// 
			// mnuAway
			// 
			this.mnuAway.Name = "mnuAway";
			this.mnuAway.Size = new System.Drawing.Size(139, 22);
			this.mnuAway.Text = "Away";
			this.mnuAway.Click += new System.EventHandler(this.mnuAway_Click);
			// 
			// mnuChat
			// 
			this.mnuChat.Name = "mnuChat";
			this.mnuChat.Size = new System.Drawing.Size(139, 22);
			this.mnuChat.Text = "Chat";
			this.mnuChat.Click += new System.EventHandler(this.mnuChat_Click);
			// 
			// mnuDnd
			// 
			this.mnuDnd.Name = "mnuDnd";
			this.mnuDnd.Size = new System.Drawing.Size(139, 22);
			this.mnuDnd.Text = "Dnd";
			this.mnuDnd.Click += new System.EventHandler(this.mnuDnd_Click);
			// 
			// mnuXa
			// 
			this.mnuXa.Name = "mnuXa";
			this.mnuXa.Size = new System.Drawing.Size(139, 22);
			this.mnuXa.Text = "Xa";
			this.mnuXa.Click += new System.EventHandler(this.mnuXa_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
			this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
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
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdCreateUser
			// 
			this.cmdCreateUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.cmdCreateUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdCreateUser.Image = global::TestSharpXmpp.Properties.Resources.user_edit;
			this.cmdCreateUser.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdCreateUser.Name = "cmdCreateUser";
			this.cmdCreateUser.Size = new System.Drawing.Size(23, 22);
			this.cmdCreateUser.Text = "Crear usuario";
			this.cmdCreateUser.ToolTipText = "Crear usuario";
			this.cmdCreateUser.Click += new System.EventHandler(this.cmdCreateUser_Click);
			// 
			// cmdNewConnection
			// 
			this.cmdNewConnection.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.cmdNewConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdNewConnection.Image = global::TestSharpXmpp.Properties.Resources.accept;
			this.cmdNewConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdNewConnection.Name = "cmdNewConnection";
			this.cmdNewConnection.Size = new System.Drawing.Size(23, 22);
			this.cmdNewConnection.Text = "Nueva conexión";
			this.cmdNewConnection.Click += new System.EventHandler(this.cmdNewConnection_Click);
			// 
			// imgList
			// 
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			this.imgList.Images.SetKeyName(0, "Connectionr.png");
			this.imgList.Images.SetKeyName(1, "ServerDisconnected.png");
			this.imgList.Images.SetKeyName(2, "Group.png");
			this.imgList.Images.SetKeyName(3, "Contact.png");
			this.imgList.Images.SetKeyName(4, "ContactOnline.png");
			this.imgList.Images.SetKeyName(5, "ContactChat.png");
			this.imgList.Images.SetKeyName(6, "ContactOffline.png");
			this.imgList.Images.SetKeyName(7, "ContactRequested.png");
			this.imgList.Images.SetKeyName(8, "user_female.png");
			this.imgList.Images.SetKeyName(9, "user_go.png");
			this.imgList.Images.SetKeyName(10, "user_gray.png");
			this.imgList.Images.SetKeyName(11, "user_green.png");
			this.imgList.Images.SetKeyName(12, "user_orange.png");
			this.imgList.Images.SetKeyName(13, "user_red.png");
			this.imgList.Images.SetKeyName(14, "user_suit.png");
			// 
			// TreeContacts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tlbList);
			this.Controls.Add(this.trvContacts);
			this.Name = "TreeContacts";
			this.Size = new System.Drawing.Size(387, 603);
			this.tlbList.ResumeLayout(false);
			this.tlbList.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Bau.Controls.Tree.TreeViewExtended trvContacts;
		private System.Windows.Forms.ToolStrip tlbList;
		private System.Windows.Forms.ToolStripButton cmdNew;
		private System.Windows.Forms.ToolStripButton cmdUpdate;
		private System.Windows.Forms.ToolStripButton cmdDelete;
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.ToolStripButton cmdNewConnection;
		private System.Windows.Forms.ToolStripButton cmdCreateUser;
		private System.Windows.Forms.ToolStripDropDownButton cmdSetStatus;
		private System.Windows.Forms.ToolStripMenuItem mnuConnect;
		private System.Windows.Forms.ToolStripMenuItem mnuDisconnect;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuOnline;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mnuAway;
		private System.Windows.Forms.ToolStripMenuItem mnuChat;
		private System.Windows.Forms.ToolStripMenuItem mnuDnd;
		private System.Windows.Forms.ToolStripMenuItem mnuXa;
	}
}
