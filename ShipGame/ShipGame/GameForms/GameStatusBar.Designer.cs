using ShipGame.Entities;

namespace ShipGame.GameForms
{
	partial class MainWindowMenu
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
			this.txtPlayerOneScore = new System.Windows.Forms.TextBox();
			this.lblPlayerOne = new System.Windows.Forms.Label();
			this.lblPlayerTwo = new System.Windows.Forms.Label();
			this.txtPlayerTwoScore = new System.Windows.Forms.TextBox();
			this.bsGameStats = new System.Windows.Forms.BindingSource(this.components);
			this.pbPlayerTwoHealth = new System.Windows.Forms.ProgressBar();
			this.lblPlayerTwoHealth = new System.Windows.Forms.Label();
			this.lblPlayerTwoScore = new System.Windows.Forms.Label();
			this.lblPlayerOneScore = new System.Windows.Forms.Label();
			this.lblPlayerOneHealth = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bsGameStats)).BeginInit();
			this.SuspendLayout();
			// 
			// pbPlayerOneHealth
			// 
			this.pbPlayerOneHealth.Location = new System.Drawing.Point(182, 42);
			this.pbPlayerOneHealth.Name = "pbPlayerOneHealth";
			this.pbPlayerOneHealth.Size = new System.Drawing.Size(100, 23);
			this.pbPlayerOneHealth.TabIndex = 3;
			// 
			// txtPlayerOneScore
			// 
			this.txtPlayerOneScore.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGameStats, "PlayerOneScore", true));
			this.txtPlayerOneScore.Enabled = false;
			this.txtPlayerOneScore.Location = new System.Drawing.Point(182, 11);
			this.txtPlayerOneScore.Name = "txtPlayerOneScore";
			this.txtPlayerOneScore.ReadOnly = true;
			this.txtPlayerOneScore.Size = new System.Drawing.Size(100, 20);
			this.txtPlayerOneScore.TabIndex = 4;
			// 
			// lblPlayerOne
			// 
			this.lblPlayerOne.AutoSize = true;
			this.lblPlayerOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerOne.Location = new System.Drawing.Point(20, 14);
			this.lblPlayerOne.Name = "lblPlayerOne";
			this.lblPlayerOne.Size = new System.Drawing.Size(69, 13);
			this.lblPlayerOne.TabIndex = 5;
			this.lblPlayerOne.Text = "Player One";
			// 
			// lblPlayerTwo
			// 
			this.lblPlayerTwo.AutoSize = true;
			this.lblPlayerTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerTwo.Location = new System.Drawing.Point(487, 14);
			this.lblPlayerTwo.Name = "lblPlayerTwo";
			this.lblPlayerTwo.Size = new System.Drawing.Size(70, 13);
			this.lblPlayerTwo.TabIndex = 8;
			this.lblPlayerTwo.Text = "Player Two";
			// 
			// txtPlayerTwoScore
			// 
			this.txtPlayerTwoScore.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGameStats, "PlayerTwoScore", true));
			this.txtPlayerTwoScore.Enabled = false;
			this.txtPlayerTwoScore.Location = new System.Drawing.Point(667, 11);
			this.txtPlayerTwoScore.Name = "txtPlayerTwoScore";
			this.txtPlayerTwoScore.ReadOnly = true;
			this.txtPlayerTwoScore.Size = new System.Drawing.Size(100, 20);
			this.txtPlayerTwoScore.TabIndex = 7;
			// 
			// bsGameStats
			// 
			this.bsGameStats.DataSource = typeof(GameStats);
			// 
			// pbPlayerTwoHealth
			// 
			this.pbPlayerTwoHealth.Location = new System.Drawing.Point(667, 42);
			this.pbPlayerTwoHealth.Name = "pbPlayerTwoHealth";
			this.pbPlayerTwoHealth.Size = new System.Drawing.Size(100, 23);
			this.pbPlayerTwoHealth.TabIndex = 6;
			// 
			// lblPlayerTwoHealth
			// 
			this.lblPlayerTwoHealth.AutoSize = true;
			this.lblPlayerTwoHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerTwoHealth.Location = new System.Drawing.Point(592, 42);
			this.lblPlayerTwoHealth.Name = "lblPlayerTwoHealth";
			this.lblPlayerTwoHealth.Size = new System.Drawing.Size(38, 13);
			this.lblPlayerTwoHealth.TabIndex = 9;
			this.lblPlayerTwoHealth.Text = "Health";
			// 
			// lblPlayerTwoScore
			// 
			this.lblPlayerTwoScore.AutoSize = true;
			this.lblPlayerTwoScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerTwoScore.Location = new System.Drawing.Point(592, 11);
			this.lblPlayerTwoScore.Name = "lblPlayerTwoScore";
			this.lblPlayerTwoScore.Size = new System.Drawing.Size(35, 13);
			this.lblPlayerTwoScore.TabIndex = 10;
			this.lblPlayerTwoScore.Text = "Score";
			// 
			// lblPlayerOneScore
			// 
			this.lblPlayerOneScore.AutoSize = true;
			this.lblPlayerOneScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerOneScore.Location = new System.Drawing.Point(107, 11);
			this.lblPlayerOneScore.Name = "lblPlayerOneScore";
			this.lblPlayerOneScore.Size = new System.Drawing.Size(35, 13);
			this.lblPlayerOneScore.TabIndex = 11;
			this.lblPlayerOneScore.Text = "Score";
			// 
			// lblPlayerOneHealth
			// 
			this.lblPlayerOneHealth.AutoSize = true;
			this.lblPlayerOneHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerOneHealth.Location = new System.Drawing.Point(107, 43);
			this.lblPlayerOneHealth.Name = "lblPlayerOneHealth";
			this.lblPlayerOneHealth.Size = new System.Drawing.Size(38, 13);
			this.lblPlayerOneHealth.TabIndex = 12;
			this.lblPlayerOneHealth.Text = "Health";
			// 
			// MainWindowMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.lblPlayerOneHealth);
			this.Controls.Add(this.lblPlayerOneScore);
			this.Controls.Add(this.lblPlayerTwoScore);
			this.Controls.Add(this.lblPlayerTwoHealth);
			this.Controls.Add(this.lblPlayerTwo);
			this.Controls.Add(this.txtPlayerTwoScore);
			this.Controls.Add(this.pbPlayerTwoHealth);
			this.Controls.Add(this.lblPlayerOne);
			this.Controls.Add(this.txtPlayerOneScore);
			this.Controls.Add(this.pbPlayerOneHealth);
			this.Name = "MainWindowMenu";
			this.Size = new System.Drawing.Size(798, 83);
			((System.ComponentModel.ISupportInitialize)(this.bsGameStats)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar pbPlayerOneHealth;
		private System.Windows.Forms.TextBox txtPlayerOneScore;
		private System.Windows.Forms.Label lblPlayerOne;
		private System.Windows.Forms.Label lblPlayerTwo;
		private System.Windows.Forms.TextBox txtPlayerTwoScore;
		private System.Windows.Forms.ProgressBar pbPlayerTwoHealth;
		private System.Windows.Forms.BindingSource bsGameStats;
		private System.Windows.Forms.Label lblPlayerTwoHealth;
		private System.Windows.Forms.Label lblPlayerTwoScore;
		private System.Windows.Forms.Label lblPlayerOneScore;
		private System.Windows.Forms.Label lblPlayerOneHealth;

	}
}
