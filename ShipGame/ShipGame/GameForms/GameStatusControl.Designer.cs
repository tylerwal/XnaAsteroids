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
			this.pbPlayerOneHealth = new System.Windows.Forms.ProgressBar();
			this.lblAmmoLeft = new System.Windows.Forms.Label();
			this.lblPlayerOneScore = new System.Windows.Forms.Label();
			this.lblPlayerOneHealth = new System.Windows.Forms.Label();
			this.lblAsteroidsLeft = new System.Windows.Forms.Label();
			this.dtlAmmoLeft = new System.Windows.Forms.Label();
			this.dtlScore = new System.Windows.Forms.Label();
			this.dtlAsteroidsLeft = new System.Windows.Forms.Label();
			this.lblShield = new System.Windows.Forms.Label();
			this.pbShield = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// pbPlayerOneHealth
			// 
			this.pbPlayerOneHealth.Location = new System.Drawing.Point(71, 9);
			this.pbPlayerOneHealth.Name = "pbPlayerOneHealth";
			this.pbPlayerOneHealth.Size = new System.Drawing.Size(100, 23);
			this.pbPlayerOneHealth.TabIndex = 3;
			// 
			// lblAmmoLeft
			// 
			this.lblAmmoLeft.AutoSize = true;
			this.lblAmmoLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAmmoLeft.Location = new System.Drawing.Point(177, 27);
			this.lblAmmoLeft.Name = "lblAmmoLeft";
			this.lblAmmoLeft.Size = new System.Drawing.Size(96, 20);
			this.lblAmmoLeft.TabIndex = 9;
			this.lblAmmoLeft.Text = "Ammo Left";
			// 
			// lblPlayerOneScore
			// 
			this.lblPlayerOneScore.AutoSize = true;
			this.lblPlayerOneScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerOneScore.Location = new System.Drawing.Point(362, 27);
			this.lblPlayerOneScore.Name = "lblPlayerOneScore";
			this.lblPlayerOneScore.Size = new System.Drawing.Size(56, 20);
			this.lblPlayerOneScore.TabIndex = 11;
			this.lblPlayerOneScore.Text = "Score";
			// 
			// lblPlayerOneHealth
			// 
			this.lblPlayerOneHealth.AutoSize = true;
			this.lblPlayerOneHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerOneHealth.Location = new System.Drawing.Point(3, 9);
			this.lblPlayerOneHealth.Name = "lblPlayerOneHealth";
			this.lblPlayerOneHealth.Size = new System.Drawing.Size(62, 20);
			this.lblPlayerOneHealth.TabIndex = 12;
			this.lblPlayerOneHealth.Text = "Health";
			// 
			// lblAsteroidsLeft
			// 
			this.lblAsteroidsLeft.AutoSize = true;
			this.lblAsteroidsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAsteroidsLeft.Location = new System.Drawing.Point(530, 27);
			this.lblAsteroidsLeft.Name = "lblAsteroidsLeft";
			this.lblAsteroidsLeft.Size = new System.Drawing.Size(122, 20);
			this.lblAsteroidsLeft.TabIndex = 10;
			this.lblAsteroidsLeft.Text = "Asteroids Left";
			// 
			// dtlAmmoLeft
			// 
			this.dtlAmmoLeft.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dtlAmmoLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dtlAmmoLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtlAmmoLeft.ForeColor = System.Drawing.Color.Lime;
			this.dtlAmmoLeft.Location = new System.Drawing.Point(279, 26);
			this.dtlAmmoLeft.Name = "dtlAmmoLeft";
			this.dtlAmmoLeft.Size = new System.Drawing.Size(77, 29);
			this.dtlAmmoLeft.TabIndex = 14;
			this.dtlAmmoLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dtlScore
			// 
			this.dtlScore.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dtlScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dtlScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtlScore.ForeColor = System.Drawing.Color.Lime;
			this.dtlScore.Location = new System.Drawing.Point(424, 26);
			this.dtlScore.Name = "dtlScore";
			this.dtlScore.Size = new System.Drawing.Size(100, 29);
			this.dtlScore.TabIndex = 15;
			this.dtlScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dtlAsteroidsLeft
			// 
			this.dtlAsteroidsLeft.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dtlAsteroidsLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dtlAsteroidsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtlAsteroidsLeft.ForeColor = System.Drawing.Color.Lime;
			this.dtlAsteroidsLeft.Location = new System.Drawing.Point(658, 26);
			this.dtlAsteroidsLeft.Name = "dtlAsteroidsLeft";
			this.dtlAsteroidsLeft.Size = new System.Drawing.Size(77, 29);
			this.dtlAsteroidsLeft.TabIndex = 16;
			this.dtlAsteroidsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblShield
			// 
			this.lblShield.AutoSize = true;
			this.lblShield.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblShield.Location = new System.Drawing.Point(3, 44);
			this.lblShield.Name = "lblShield";
			this.lblShield.Size = new System.Drawing.Size(59, 20);
			this.lblShield.TabIndex = 18;
			this.lblShield.Text = "Shield";
			// 
			// pbShield
			// 
			this.pbShield.Location = new System.Drawing.Point(71, 44);
			this.pbShield.Name = "pbShield";
			this.pbShield.Size = new System.Drawing.Size(100, 23);
			this.pbShield.TabIndex = 17;
			// 
			// GameStatusControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.lblShield);
			this.Controls.Add(this.pbShield);
			this.Controls.Add(this.dtlAsteroidsLeft);
			this.Controls.Add(this.dtlScore);
			this.Controls.Add(this.dtlAmmoLeft);
			this.Controls.Add(this.lblPlayerOneHealth);
			this.Controls.Add(this.lblPlayerOneScore);
			this.Controls.Add(this.lblAsteroidsLeft);
			this.Controls.Add(this.lblAmmoLeft);
			this.Controls.Add(this.pbPlayerOneHealth);
			this.Name = "GameStatusControl";
			this.Size = new System.Drawing.Size(798, 83);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar pbPlayerOneHealth;
		private System.Windows.Forms.Label lblAmmoLeft;
		private System.Windows.Forms.Label lblPlayerOneScore;
		private System.Windows.Forms.Label lblPlayerOneHealth;
		private System.Windows.Forms.Label lblAsteroidsLeft;
		private System.Windows.Forms.Label dtlAmmoLeft;
		private System.Windows.Forms.Label dtlScore;
		private System.Windows.Forms.Label dtlAsteroidsLeft;
		private System.Windows.Forms.Label lblShield;
		private System.Windows.Forms.ProgressBar pbShield;

	}
}
