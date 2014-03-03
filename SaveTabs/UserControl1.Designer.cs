namespace SaveTabs
{
	partial class UserControl1
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("UserControl1.cs");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("References");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("SaveTabs", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Kasko Online Gönder");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
			this.treeListe = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.açıkPencereyiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtYeniCalismaAlani = new System.Windows.Forms.TextBox();
			this.btnYeniCalismaAlani = new System.Windows.Forms.Button();
			this.btnAcikTekPencereEkle = new System.Windows.Forms.Button();
			this.btnTumAciklariEkle = new System.Windows.Forms.Button();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeListe
			// 
			this.treeListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
			this.treeListe.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeListe.ContextMenuStrip = this.contextMenuStrip1;
			this.treeListe.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.treeListe.ForeColor = System.Drawing.SystemColors.Window;
			this.treeListe.LineColor = System.Drawing.Color.DimGray;
			this.treeListe.Location = new System.Drawing.Point(1, 69);
			this.treeListe.Name = "treeListe";
			treeNode1.Name = "Node2";
			treeNode1.Text = "UserControl1.cs";
			treeNode1.ToolTipText = "Child 1";
			treeNode2.Name = "Node3";
			treeNode2.Text = "References";
			treeNode2.ToolTipText = "Child 2";
			treeNode3.Name = "Node0";
			treeNode3.Text = "SaveTabs";
			treeNode3.ToolTipText = "Root";
			treeNode4.Name = "Node1";
			treeNode4.Text = "Kasko Online Gönder";
			this.treeListe.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
			this.treeListe.PathSeparator = "~";
			this.treeListe.ShowNodeToolTips = true;
			this.treeListe.Size = new System.Drawing.Size(307, 691);
			this.treeListe.TabIndex = 0;
			this.treeListe.DoubleClick += new System.EventHandler(this.treeListe_DoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.açıkPencereyiEkleToolStripMenuItem,
            this.silToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(176, 48);
			// 
			// açıkPencereyiEkleToolStripMenuItem
			// 
			this.açıkPencereyiEkleToolStripMenuItem.Name = "açıkPencereyiEkleToolStripMenuItem";
			this.açıkPencereyiEkleToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.açıkPencereyiEkleToolStripMenuItem.Text = "Açık Pencereyi Ekle";
			this.açıkPencereyiEkleToolStripMenuItem.Click += new System.EventHandler(this.acikPencereyiEkleToolStripMenuItem_Click);
			// 
			// silToolStripMenuItem
			// 
			this.silToolStripMenuItem.Name = "silToolStripMenuItem";
			this.silToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.silToolStripMenuItem.Text = "Sil";
			this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
			// 
			// txtYeniCalismaAlani
			// 
			this.txtYeniCalismaAlani.Location = new System.Drawing.Point(3, 3);
			this.txtYeniCalismaAlani.Name = "txtYeniCalismaAlani";
			this.txtYeniCalismaAlani.Size = new System.Drawing.Size(114, 20);
			this.txtYeniCalismaAlani.TabIndex = 1;
			// 
			// btnYeniCalismaAlani
			// 
			this.btnYeniCalismaAlani.Location = new System.Drawing.Point(123, 1);
			this.btnYeniCalismaAlani.Name = "btnYeniCalismaAlani";
			this.btnYeniCalismaAlani.Size = new System.Drawing.Size(125, 23);
			this.btnYeniCalismaAlani.TabIndex = 2;
			this.btnYeniCalismaAlani.Text = "Yeni Çalışma Alanı Ekle";
			this.btnYeniCalismaAlani.UseVisualStyleBackColor = true;
			this.btnYeniCalismaAlani.Click += new System.EventHandler(this.btnYeniCalismaAlani_Click);
			// 
			// btnAcikTekPencereEkle
			// 
			this.btnAcikTekPencereEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnAcikTekPencereEkle.Image")));
			this.btnAcikTekPencereEkle.Location = new System.Drawing.Point(3, 29);
			this.btnAcikTekPencereEkle.Name = "btnAcikTekPencereEkle";
			this.btnAcikTekPencereEkle.Size = new System.Drawing.Size(31, 34);
			this.btnAcikTekPencereEkle.TabIndex = 4;
			this.btnAcikTekPencereEkle.UseVisualStyleBackColor = true;
			this.btnAcikTekPencereEkle.Click += new System.EventHandler(this.btnAcikTekPencereEkle_Click);
			// 
			// btnTumAciklariEkle
			// 
			this.btnTumAciklariEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnTumAciklariEkle.Image")));
			this.btnTumAciklariEkle.Location = new System.Drawing.Point(40, 29);
			this.btnTumAciklariEkle.Name = "btnTumAciklariEkle";
			this.btnTumAciklariEkle.Size = new System.Drawing.Size(35, 34);
			this.btnTumAciklariEkle.TabIndex = 5;
			this.btnTumAciklariEkle.UseVisualStyleBackColor = true;
			this.btnTumAciklariEkle.Click += new System.EventHandler(this.btnTumAciklariEkle_Click);
			// 
			// UserControl1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Controls.Add(this.btnTumAciklariEkle);
			this.Controls.Add(this.btnAcikTekPencereEkle);
			this.Controls.Add(this.btnYeniCalismaAlani);
			this.Controls.Add(this.txtYeniCalismaAlani);
			this.Controls.Add(this.treeListe);
			this.Name = "UserControl1";
			this.Size = new System.Drawing.Size(311, 763);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeListe;
		private System.Windows.Forms.TextBox txtYeniCalismaAlani;
		private System.Windows.Forms.Button btnYeniCalismaAlani;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem açıkPencereyiEkleToolStripMenuItem;
		private System.Windows.Forms.Button btnAcikTekPencereEkle;
		private System.Windows.Forms.Button btnTumAciklariEkle;
		private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
	}
}
