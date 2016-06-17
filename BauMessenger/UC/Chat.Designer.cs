namespace TestSharpXmpp.UC
{
	partial class Chat
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
			this.txtMessages = new System.Windows.Forms.TextBox();
			this.cmdSend = new System.Windows.Forms.Button();
			this.txtChat = new System.Windows.Forms.TextBox();
			this.cmdClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtMessages
			// 
			this.txtMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessages.BackColor = System.Drawing.Color.White;
			this.txtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMessages.Location = new System.Drawing.Point(6, 4);
			this.txtMessages.Multiline = true;
			this.txtMessages.Name = "txtMessages";
			this.txtMessages.ReadOnly = true;
			this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtMessages.Size = new System.Drawing.Size(422, 388);
			this.txtMessages.TabIndex = 0;
			// 
			// cmdSend
			// 
			this.cmdSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSend.ForeColor = System.Drawing.Color.Black;
			this.cmdSend.Location = new System.Drawing.Point(327, 396);
			this.cmdSend.Name = "cmdSend";
			this.cmdSend.Size = new System.Drawing.Size(73, 23);
			this.cmdSend.TabIndex = 2;
			this.cmdSend.Text = "Enviar";
			this.cmdSend.UseVisualStyleBackColor = true;
			this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
			// 
			// txtChat
			// 
			this.txtChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtChat.Location = new System.Drawing.Point(6, 397);
			this.txtChat.Name = "txtChat";
			this.txtChat.Size = new System.Drawing.Size(315, 20);
			this.txtChat.TabIndex = 1;
			// 
			// cmdClose
			// 
			this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = System.Drawing.Color.Black;
			this.cmdClose.Image = global::TestSharpXmpp.Properties.Resources.cancel;
			this.cmdClose.Location = new System.Drawing.Point(405, 396);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(23, 23);
			this.cmdClose.TabIndex = 2;
			this.cmdClose.UseVisualStyleBackColor = true;
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// Chat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cmdClose);
			this.Controls.Add(this.cmdSend);
			this.Controls.Add(this.txtChat);
			this.Controls.Add(this.txtMessages);
			this.Name = "Chat";
			this.Size = new System.Drawing.Size(433, 423);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtMessages;
		private System.Windows.Forms.Button cmdSend;
		private System.Windows.Forms.TextBox txtChat;
		private System.Windows.Forms.Button cmdClose;
	}
}
