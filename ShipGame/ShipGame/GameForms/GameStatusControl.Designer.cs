using ShipGame.Entities;

namespace ShipGame.GameForms
{
	partial class GameStatusControl
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
			this.pbPlayerOneHealth = new System.Windows.Forms.ProgressBar();
			this.txtScore = new System.Windows.Forms.TextBox();
			this.bsGameStats = new System.Windows.Forms.BindingSource(this.components);
			this.lblAmmoLeft = new System.Windows.Forms.Label();
			this.lblPlayerOneScore = new System.Windows.Forms.Label();
			this.lblPlayerOneHealth = new System.Windows.Forms.Label();
			this.txtAsteroidsLeft = new System.Windows.Forms.TextBox();
			this.lblAsteroidsLeft = new System.Windows.Forms.Label();
			this.txtAmmoLeft = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.bsGameStats)).BeginInit();
			this.SuspendLayout();
			// 
			// pbPlayerOneHealth
			// 
			this.pbPlayerOneHealth.Location = new System.Drawing.Point(47, 8);
			this.pbPlayerOneHealth.Name = "pbPlayerOneHealth";
			this.pbPlayerOneHealth.Size = new System.Drawing.Size(100, 23);
			this.pbPlayerOneHealth.TabIndex = 3;
			// 
			// txtScore
			// 
			this.txtScore.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGameStats, "PlayerOneScore", true));
			this.txtScore.Enabled = false;
			this.txtScore.Location = new System.Drawing.Point(363, 8);
			this.txtScore.Name = "txtScore";
			this.txtScore.ReadOnly = true;
			this.txtScore.Size = new System.Drawing.Size(100, 20);
			this.txtScore.TabIndex = 4;
			// 
			// bsGameStats
			// 
			this.bsGameStats.DataSource = typeof(ShipGame.Entities.GameStats);
			// 
			// lblAmmoLeft
			// 
			this.lblAmmoLeft.AutoSize = true;
			this.lblAmmoLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAmmoLeft.Location = new System.Drawing.Point(153, 11);
			this.lblAmmoLeft.Name = "lblAmmoLeft";
			this.lblAmmoLeft.Size = new System.Drawing.Size(57, 13);
			this.lblAmmoLeft.TabIndex = 9;
			this.lblAmmoLeft.Text = "Ammo Left";
			// 
			// lblPlayerOneScore
			// 
			this.lblPlayerOneScore.AutoSize = true;
			this.lblPlayerOneScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerOneScore.Location = new System.Drawing.Point(322, 11);
			this.lblPlayerOneScore.Name = "lblPlayerOneScore";
			this.lblPlayerOneScore.Size = new System.Drawing.Size(35, 13);
			this.lblPlayerOneScore.TabIndex = 11;
			this.lblPlayerOneScore.Text = "Score";
			// 
			// lblPlayerOneHealth
			// 
			this.lblPlayerOneHealth.AutoSize = true;
			this.lblPlayerOneHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerOneHealth.Location = new System.Drawing.Point(3, 11);
			this.lblPlayerOneHealth.Name = "lblPlayerOneHealth";
			this.lblPlayerOneHealth.Size = new System.Drawing.Size(38, 13);
			this.lblPlayerOneHealth.TabIndex = 12;
			this.lblPlayerOneHealth.Text = "Health";
			// 
			// txtAsteroidsLeft
			// 
			this.txtAsteroidsLeft.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGameStats, "PlayerTwoScore", true));
			this.txtAsteroidsLeft.Enabled = false;
			this.txtAsteroidsLeft.Location = new System.Drawing.Point(546, 8);
			this.txtAsteroidsLeft.Name = "txtAsteroidsLeft";
			this.txtAsteroidsLeft.ReadOnly = true;
			this.txtAsteroidsLeft.Size = new System.Drawing.Size(100, 20);
			this.txtAsteroidsLeft.TabIndex = 7;
			// 
			// lblAsteroidsLeft
			// 
			this.lblAsteroidsLeft.AutoSize = true;
			this.lblAsteroidsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAsteroidsLeft.Location = new System.Drawing.Point(469, 11);
			this.lblAsteroidsLeft.Name = "lblAsteroidsLeft";
			this.lblAsteroidsLeft.Size = new System.Drawing.Size(71, 13);
			this.lblAsteroidsLeft.TabIndex = 10;
			this.lblAsteroidsLeft.Text = "Asteroids Left";
			// 
			// txtAmmoLeft
			// 
			this.txtAmmoLeft.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGameStats, "PlayerTwoScore", true));
			this.txtAmmoLeft.Enabled = false;
			this.txtAmmoLeft.Location = new System.Drawing.Point(216, 8);
			this.txtAmmoLeft.Name = "txtAmmoLeft";
			this.txtAmmoLeft.ReadOnly = true;
			this.txtAmmoLeft.Size = new System.Drawing.Size(100, 20);
			this.txtAmmoLeft.TabIndex = 13;
			// 
			// MainWindowMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.txtAmmoLeft);
			this.Controls.Add(this.lblPlayerOneHealth);
			this.Controls.Add(this.lblPlayerOneScore);
			this.Controls.Add(this.lblAsteroidsLeft);
			this.Controls.Add(this.lblAmmoLeft);
			this.Controls.Add(this.txtAsteroidsLeft);
			this.Controls.Add(this.txtScore);
			this.Controls.Add(this.pbPlayerOneHealth);
			this.Name = "MainWindowMenu";
			this.Size = new System.Drawing.Size(798, 83);
			((System.ComponentModel.ISupportInitialize)(this.bsGameStats)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar pbPlayerOneHealth;
		private System.Windows.Forms.TextBox txtScore;
		private System.Windows.Forms.BindingSource bsGameStats;
		private System.Windows.Forms.Label lblAmmoLeft;
		private System.Windows.Forms.Label lblPlayerOneScore;
		private System.Windows.Forms.Label lblPlayerOneHealth;
		private System.Windows.Forms.TextBox txtAsteroidsLeft;
		private System.Windows.Forms.Label lblAsteroidsLeft;
		private System.Windows.Forms.TextBox txtAmmoLeft;

	}
}
