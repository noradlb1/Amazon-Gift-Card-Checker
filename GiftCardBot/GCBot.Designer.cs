namespace GiftCardBot
{
	// Token: 0x02000002 RID: 2
	public partial class GCBot : global::System.Windows.Forms.Form
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00003D04 File Offset: 0x00001F04
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003D3C File Offset: 0x00001F3C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GiftCardBot.GCBot));
			this.BGo = new global::System.Windows.Forms.Button();
			this.BPause = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.LThreads = new global::System.Windows.Forms.Label();
			this.TBThreads = new global::System.Windows.Forms.TrackBar();
			this.LVCards = new global::System.Windows.Forms.ListView();
			this.GCNum = new global::System.Windows.Forms.ColumnHeader();
			this.Value = new global::System.Windows.Forms.ColumnHeader();
			this.LStatus = new global::System.Windows.Forms.Label();
			this.TChangeIcon = new global::System.Windows.Forms.Timer(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			this.GBAmazon = new global::System.Windows.Forms.GroupBox();
			this.TBAPassword = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.TBAEmail = new global::System.Windows.Forms.TextBox();
			this.GBDBC = new global::System.Windows.Forms.GroupBox();
			this.TBDBCPassword = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.TBDBCEmail = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.BExport = new global::System.Windows.Forms.Button();
			this.GBGiftCards = new global::System.Windows.Forms.GroupBox();
			this.TBGiftCards = new global::System.Windows.Forms.TextBox();
			this.RBAmazonCom = new global::System.Windows.Forms.RadioButton();
			this.RBAmazonCoUK = new global::System.Windows.Forms.RadioButton();
			this.BClear = new global::System.Windows.Forms.Button();
			this.LValid = new global::System.Windows.Forms.Label();
			this.LNotValid = new global::System.Windows.Forms.Label();
			this.LValue = new global::System.Windows.Forms.Label();
			this.LRedeemed = new global::System.Windows.Forms.Label();
			this.BImport = new global::System.Windows.Forms.Button();
			this.OFDInput = new global::System.Windows.Forms.OpenFileDialog();
			this.LDBCBalance = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.TBThreads).BeginInit();
			this.GBAmazon.SuspendLayout();
			this.GBDBC.SuspendLayout();
			this.GBGiftCards.SuspendLayout();
			base.SuspendLayout();
			this.BGo.Location = new global::System.Drawing.Point(373, 266);
			this.BGo.Name = "BGo";
			this.BGo.Size = new global::System.Drawing.Size(75, 23);
			this.BGo.TabIndex = 8;
			this.BGo.Text = "Go!";
			this.BGo.UseVisualStyleBackColor = true;
			this.BGo.Click += new global::System.EventHandler(this.BGo_Click);
			this.BPause.Location = new global::System.Drawing.Point(454, 266);
			this.BPause.Name = "BPause";
			this.BPause.Size = new global::System.Drawing.Size(75, 23);
			this.BPause.TabIndex = 9;
			this.BPause.Text = "Pause";
			this.BPause.UseVisualStyleBackColor = true;
			this.BPause.Click += new global::System.EventHandler(this.BPause_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(190, 234);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(89, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Num Of Threads:";
			this.label3.Visible = false;
			this.LThreads.AutoSize = true;
			this.LThreads.Location = new global::System.Drawing.Point(488, 234);
			this.LThreads.Name = "LThreads";
			this.LThreads.Size = new global::System.Drawing.Size(63, 13);
			this.LThreads.TabIndex = 13;
			this.LThreads.Text = "1 Thread(s)";
			this.LThreads.Visible = false;
			this.TBThreads.AutoSize = false;
			this.TBThreads.BackColor = global::System.Drawing.SystemColors.Control;
			this.TBThreads.LargeChange = 2;
			this.TBThreads.Location = new global::System.Drawing.Point(285, 226);
			this.TBThreads.Maximum = 7;
			this.TBThreads.Minimum = 1;
			this.TBThreads.Name = "TBThreads";
			this.TBThreads.Size = new global::System.Drawing.Size(197, 21);
			this.TBThreads.TabIndex = 5;
			this.TBThreads.Value = 1;
			this.TBThreads.Visible = false;
			this.TBThreads.Scroll += new global::System.EventHandler(this.TBThreads_Scroll);
			this.LVCards.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.GCNum,
				this.Value
			});
			this.LVCards.FullRowSelect = true;
			this.LVCards.GridLines = true;
			this.LVCards.Location = new global::System.Drawing.Point(367, 12);
			this.LVCards.MultiSelect = false;
			this.LVCards.Name = "LVCards";
			this.LVCards.Size = new global::System.Drawing.Size(361, 208);
			this.LVCards.TabIndex = 10;
			this.LVCards.UseCompatibleStateImageBehavior = false;
			this.LVCards.View = global::System.Windows.Forms.View.Details;
			this.GCNum.Text = "Giftcard #";
			this.GCNum.Width = 238;
			this.Value.Text = "Value";
			this.Value.Width = 97;
			this.LStatus.AutoSize = true;
			this.LStatus.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.LStatus.Location = new global::System.Drawing.Point(9, 321);
			this.LStatus.Name = "LStatus";
			this.LStatus.Size = new global::System.Drawing.Size(0, 13);
			this.LStatus.TabIndex = 17;
			this.TChangeIcon.Enabled = true;
			this.TChangeIcon.Interval = 1000;
			this.TChangeIcon.Tick += new global::System.EventHandler(this.TChangeIcon_Tick);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(35, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Email:";
			this.GBAmazon.Controls.Add(this.TBAPassword);
			this.GBAmazon.Controls.Add(this.label2);
			this.GBAmazon.Controls.Add(this.TBAEmail);
			this.GBAmazon.Controls.Add(this.label1);
			this.GBAmazon.Location = new global::System.Drawing.Point(12, 12);
			this.GBAmazon.Name = "GBAmazon";
			this.GBAmazon.Size = new global::System.Drawing.Size(329, 46);
			this.GBAmazon.TabIndex = 0;
			this.GBAmazon.TabStop = false;
			this.GBAmazon.Text = "Amazon";
			this.TBAPassword.Location = new global::System.Drawing.Point(216, 13);
			this.TBAPassword.Name = "TBAPassword";
			this.TBAPassword.Size = new global::System.Drawing.Size(100, 20);
			this.TBAPassword.TabIndex = 21;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(153, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(57, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Password:";
			this.TBAEmail.Location = new global::System.Drawing.Point(47, 13);
			this.TBAEmail.Name = "TBAEmail";
			this.TBAEmail.Size = new global::System.Drawing.Size(100, 20);
			this.TBAEmail.TabIndex = 19;
			this.GBDBC.Controls.Add(this.TBDBCPassword);
			this.GBDBC.Controls.Add(this.label4);
			this.GBDBC.Controls.Add(this.TBDBCEmail);
			this.GBDBC.Controls.Add(this.label5);
			this.GBDBC.Location = new global::System.Drawing.Point(12, 64);
			this.GBDBC.Name = "GBDBC";
			this.GBDBC.Size = new global::System.Drawing.Size(329, 46);
			this.GBDBC.TabIndex = 1;
			this.GBDBC.TabStop = false;
			this.GBDBC.Text = "DeathByCaptcha";
			this.TBDBCPassword.Location = new global::System.Drawing.Point(216, 13);
			this.TBDBCPassword.Name = "TBDBCPassword";
			this.TBDBCPassword.Size = new global::System.Drawing.Size(100, 20);
			this.TBDBCPassword.TabIndex = 21;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(153, 16);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(57, 13);
			this.label4.TabIndex = 20;
			this.label4.Text = "Password:";
			this.TBDBCEmail.Location = new global::System.Drawing.Point(47, 13);
			this.TBDBCEmail.Name = "TBDBCEmail";
			this.TBDBCEmail.Size = new global::System.Drawing.Size(100, 20);
			this.TBDBCEmail.TabIndex = 19;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(35, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Email:";
			this.BExport.Location = new global::System.Drawing.Point(292, 266);
			this.BExport.Name = "BExport";
			this.BExport.Size = new global::System.Drawing.Size(75, 23);
			this.BExport.TabIndex = 7;
			this.BExport.Text = "Export";
			this.BExport.UseVisualStyleBackColor = true;
			this.BExport.Click += new global::System.EventHandler(this.BExport_Click);
			this.GBGiftCards.Controls.Add(this.TBGiftCards);
			this.GBGiftCards.Location = new global::System.Drawing.Point(12, 116);
			this.GBGiftCards.Name = "GBGiftCards";
			this.GBGiftCards.Size = new global::System.Drawing.Size(329, 104);
			this.GBGiftCards.TabIndex = 2;
			this.GBGiftCards.TabStop = false;
			this.GBGiftCards.Text = "GiftCards";
			this.TBGiftCards.Location = new global::System.Drawing.Point(9, 13);
			this.TBGiftCards.Multiline = true;
			this.TBGiftCards.Name = "TBGiftCards";
			this.TBGiftCards.Size = new global::System.Drawing.Size(307, 85);
			this.TBGiftCards.TabIndex = 21;
			this.RBAmazonCom.AutoSize = true;
			this.RBAmazonCom.Checked = true;
			this.RBAmazonCom.Location = new global::System.Drawing.Point(12, 232);
			this.RBAmazonCom.Name = "RBAmazonCom";
			this.RBAmazonCom.Size = new global::System.Drawing.Size(86, 17);
			this.RBAmazonCom.TabIndex = 3;
			this.RBAmazonCom.TabStop = true;
			this.RBAmazonCom.Text = "Amazon.com";
			this.RBAmazonCom.UseVisualStyleBackColor = true;
			this.RBAmazonCoUK.AutoSize = true;
			this.RBAmazonCoUK.Location = new global::System.Drawing.Point(104, 232);
			this.RBAmazonCoUK.Name = "RBAmazonCoUK";
			this.RBAmazonCoUK.Size = new global::System.Drawing.Size(93, 17);
			this.RBAmazonCoUK.TabIndex = 4;
			this.RBAmazonCoUK.Text = "Amazon.co.uk";
			this.RBAmazonCoUK.UseVisualStyleBackColor = true;
			this.BClear.Location = new global::System.Drawing.Point(130, 266);
			this.BClear.Name = "BClear";
			this.BClear.Size = new global::System.Drawing.Size(75, 23);
			this.BClear.TabIndex = 6;
			this.BClear.Text = "Clear";
			this.BClear.UseVisualStyleBackColor = true;
			this.BClear.Click += new global::System.EventHandler(this.BClear_Click);
			this.LValid.AutoSize = true;
			this.LValid.Location = new global::System.Drawing.Point(566, 234);
			this.LValid.Name = "LValid";
			this.LValid.Size = new global::System.Drawing.Size(133, 13);
			this.LValid.TabIndex = 18;
			this.LValid.Text = "# Of Valid Cards: 0 Cards ";
			this.LNotValid.AutoSize = true;
			this.LNotValid.Location = new global::System.Drawing.Point(566, 256);
			this.LNotValid.Name = "LNotValid";
			this.LNotValid.Size = new global::System.Drawing.Size(143, 13);
			this.LNotValid.TabIndex = 19;
			this.LNotValid.Text = "# Of Invalid Cards: 0 Cards ";
			this.LValue.AutoSize = true;
			this.LValue.Location = new global::System.Drawing.Point(566, 298);
			this.LValue.Name = "LValue";
			this.LValue.Size = new global::System.Drawing.Size(95, 13);
			this.LValue.TabIndex = 20;
			this.LValue.Text = "Total Value: 00.00";
			this.LRedeemed.AutoSize = true;
			this.LRedeemed.Location = new global::System.Drawing.Point(566, 276);
			this.LRedeemed.Name = "LRedeemed";
			this.LRedeemed.Size = new global::System.Drawing.Size(159, 13);
			this.LRedeemed.TabIndex = 21;
			this.LRedeemed.Text = "# Of Redeemed Cards: 0 Cards";
			this.BImport.Location = new global::System.Drawing.Point(211, 266);
			this.BImport.Name = "BImport";
			this.BImport.Size = new global::System.Drawing.Size(75, 23);
			this.BImport.TabIndex = 22;
			this.BImport.Text = "Import";
			this.BImport.UseVisualStyleBackColor = true;
			this.BImport.Click += new global::System.EventHandler(this.BImport_Click);
			this.OFDInput.Filter = "TXT File|*.txt";
			this.LDBCBalance.AutoSize = true;
			this.LDBCBalance.Location = new global::System.Drawing.Point(566, 321);
			this.LDBCBalance.Name = "LDBCBalance";
			this.LDBCBalance.Size = new global::System.Drawing.Size(71, 13);
			this.LDBCBalance.TabIndex = 23;
			this.LDBCBalance.Text = "DBC Balance:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(740, 344);
			base.Controls.Add(this.LDBCBalance);
			base.Controls.Add(this.BImport);
			base.Controls.Add(this.LRedeemed);
			base.Controls.Add(this.LValue);
			base.Controls.Add(this.LNotValid);
			base.Controls.Add(this.LValid);
			base.Controls.Add(this.BClear);
			base.Controls.Add(this.RBAmazonCoUK);
			base.Controls.Add(this.RBAmazonCom);
			base.Controls.Add(this.GBGiftCards);
			base.Controls.Add(this.BExport);
			base.Controls.Add(this.GBDBC);
			base.Controls.Add(this.GBAmazon);
			base.Controls.Add(this.LStatus);
			base.Controls.Add(this.LVCards);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.LThreads);
			base.Controls.Add(this.TBThreads);
			base.Controls.Add(this.BPause);
			base.Controls.Add(this.BGo);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "GCBot";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Giftcard Bot";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.GCBot_FormClosing);
			base.Load += new global::System.EventHandler(this.GCBot_Load);
			((global::System.ComponentModel.ISupportInitialize)this.TBThreads).EndInit();
			this.GBAmazon.ResumeLayout(false);
			this.GBAmazon.PerformLayout();
			this.GBDBC.ResumeLayout(false);
			this.GBDBC.PerformLayout();
			this.GBGiftCards.ResumeLayout(false);
			this.GBGiftCards.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000019 RID: 25
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button BGo;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Button BPause;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Label LThreads;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.TrackBar TBThreads;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.ListView LVCards;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.ColumnHeader GCNum;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.ColumnHeader Value;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Label LStatus;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.Timer TChangeIcon;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.GroupBox GBAmazon;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.TextBox TBAPassword;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.TextBox TBAEmail;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.GroupBox GBDBC;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.TextBox TBDBCPassword;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.TextBox TBDBCEmail;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Button BExport;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.GroupBox GBGiftCards;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.TextBox TBGiftCards;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.RadioButton RBAmazonCom;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.RadioButton RBAmazonCoUK;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.Button BClear;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Label LValid;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Label LNotValid;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Label LValue;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Label LRedeemed;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.Button BImport;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.OpenFileDialog OFDInput;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Label LDBCBalance;
	}
}
