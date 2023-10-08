namespace Client
{
	partial class Client
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
			this.btnSendDocx = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.lsvMain = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// btnSendDocx
			// 
			this.btnSendDocx.Location = new System.Drawing.Point(467, 393);
			this.btnSendDocx.Name = "btnSendDocx";
			this.btnSendDocx.Size = new System.Drawing.Size(102, 45);
			this.btnSendDocx.TabIndex = 7;
			this.btnSendDocx.Text = "Send Docx";
			this.btnSendDocx.UseVisualStyleBackColor = true;
			this.btnSendDocx.Click += new System.EventHandler(this.btnSendDocx_Click);
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(575, 393);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(102, 45);
			this.btnSend.TabIndex = 6;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(123, 393);
			this.txtInput.Multiline = true;
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(338, 45);
			this.txtInput.TabIndex = 5;
			this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
			// 
			// lsvMain
			// 
			this.lsvMain.HideSelection = false;
			this.lsvMain.Location = new System.Drawing.Point(123, 12);
			this.lsvMain.Name = "lsvMain";
			this.lsvMain.Size = new System.Drawing.Size(554, 375);
			this.lsvMain.TabIndex = 4;
			this.lsvMain.UseCompatibleStateImageBehavior = false;
			this.lsvMain.View = System.Windows.Forms.View.List;
			this.lsvMain.SelectedIndexChanged += new System.EventHandler(this.lsvMain_SelectedIndexChanged);
			// 
			// Client
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnSendDocx);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtInput);
			this.Controls.Add(this.lsvMain);
			this.Name = "Client";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
			this.Load += new System.EventHandler(this.Client_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSendDocx;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.ListView lsvMain;
	}
}

