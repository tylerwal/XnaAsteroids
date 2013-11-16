using ShipGame.GameDisplay;

namespace ShipGame.GameForms
{
	partial class GameForm
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
			this.mnsTopMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.highScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlGamePanel = new System.Windows.Forms.Panel();
			this.xnaGame = new ShipGame.GameDisplay.XnaGame();
			this.gameStatusBar = new ShipGame.GameForms.GameStatusControl();
			this.mnsTopMenu.SuspendLayout();
			this.pnlGamePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnsTopMenu
			// 
			this.mnsTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.mnsTopMenu.Location = new System.Drawing.Point(0, 0);
			this.mnsTopMenu.Name = "mnsTopMenu";
			this.mnsTopMenu.Size = new System.Drawing.Size(784, 24);
			this.mnsTopMenu.TabIndex = 1;
			this.mnsTopMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.highScoresToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.newGameToolStripMenuItem.Text = "New Game";
			// 
			// highScoresToolStripMenuItem
			// 
			this.highScoresToolStripMenuItem.Name = "highScoresToolStripMenuItem";
			this.highScoresToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.highScoresToolStripMenuItem.Text = "High Scores";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// pnlGamePanel
			// 
			this.pnlGamePanel.Controls.Add(this.xnaGame);
			this.pnlGamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGamePanel.Location = new System.Drawing.Point(0, 24);
			this.pnlGamePanel.Name = "pnlGamePanel";
			this.pnlGamePanel.Size = new System.Drawing.Size(784, 455);
			this.pnlGamePanel.TabIndex = 3;
			// 
			// xnaGame
			// 
			this.xnaGame.Content = null;
			this.xnaGame.Cursor = System.Windows.Forms.Cursors.Cross;
			this.xnaGame.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xnaGame.GameObjects = null;
			this.xnaGame.GameUpdateStopWatch = null;
			this.xnaGame.GameUtility = null;
			this.xnaGame.GlobalGameStopWatch = null;
			this.xnaGame.LastBulletCreationTime = System.TimeSpan.Parse("00:00:00");
			this.xnaGame.Location = new System.Drawing.Point(0, 0);
			this.xnaGame.Name = "xnaGame";
			this.xnaGame.Size = new System.Drawing.Size(784, 455);
			this.xnaGame.SpriteBatch = null;
			this.xnaGame.TabIndex = 0;
			this.xnaGame.Text = "XnaGame";
			// 
			// gameStatusBar
			// 
			this.gameStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gameStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.gameStatusBar.Location = new System.Drawing.Point(0, 479);
			this.gameStatusBar.Name = "gameStatusBar";
			this.gameStatusBar.Size = new System.Drawing.Size(784, 83);
			this.gameStatusBar.TabIndex = 2;
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.pnlGamePanel);
			this.Controls.Add(this.gameStatusBar);
			this.Controls.Add(this.mnsTopMenu);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.mnsTopMenu;
			this.Name = "GameForm";
			this.Text = "Ship Commander";
			this.mnsTopMenu.ResumeLayout(false);
			this.mnsTopMenu.PerformLayout();
			this.pnlGamePanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private XnaGame xnaGame;
		private System.Windows.Forms.MenuStrip mnsTopMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
		private GameStatusControl gameStatusBar;
		private System.Windows.Forms.Panel pnlGamePanel;
		private System.Windows.Forms.ToolStripMenuItem highScoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	}
}