namespace Architecture.Experiments.AmViComp
{
	partial class AutoMapper2ValueInjecterCompareScreen
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.executeMappingButton = new System.Windows.Forms.Button ();
			this.autoMapperTakesLabel = new System.Windows.Forms.Label ();
			this.autoMapperTakesValueLabel = new System.Windows.Forms.Label ();
			this.valueInjecterTakesLabel = new System.Windows.Forms.Label ();
			this.valueInjecterTakesValueLabel = new System.Windows.Forms.Label ();
			this.autoMapperOutputTextBox = new System.Windows.Forms.TextBox ();
			this.valueInjecterOutputTextBox = new System.Windows.Forms.TextBox ();
			this.serializedOutputFromAutoMapperLabel = new System.Windows.Forms.Label ();
			this.serializedOutputFromValueInjecterLabel = new System.Windows.Forms.Label ();
			this.SuspendLayout ();
			// 
			// executeMappingButton
			// 
			this.executeMappingButton.Location = new System.Drawing.Point (13, 13);
			this.executeMappingButton.Name = "executeMappingButton";
			this.executeMappingButton.Size = new System.Drawing.Size (175, 23);
			this.executeMappingButton.TabIndex = 0;
			this.executeMappingButton.Text = "Execute Mapping Task";
			this.executeMappingButton.UseVisualStyleBackColor = true;
			this.executeMappingButton.Click += new System.EventHandler (this.executeMappingButton_Click);
			// 
			// autoMapperTakesLabel
			// 
			this.autoMapperTakesLabel.Location = new System.Drawing.Point (292, 13);
			this.autoMapperTakesLabel.Name = "autoMapperTakesLabel";
			this.autoMapperTakesLabel.Size = new System.Drawing.Size (140, 23);
			this.autoMapperTakesLabel.TabIndex = 1;
			this.autoMapperTakesLabel.Text = "AutoMapper takes :";
			this.autoMapperTakesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// autoMapperTakesValueLabel
			// 
			this.autoMapperTakesValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.autoMapperTakesValueLabel.Location = new System.Drawing.Point (439, 13);
			this.autoMapperTakesValueLabel.Name = "autoMapperTakesValueLabel";
			this.autoMapperTakesValueLabel.Size = new System.Drawing.Size (124, 23);
			this.autoMapperTakesValueLabel.TabIndex = 2;
			this.autoMapperTakesValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// valueInjecterTakesLabel
			// 
			this.valueInjecterTakesLabel.Location = new System.Drawing.Point (847, 13);
			this.valueInjecterTakesLabel.Name = "valueInjecterTakesLabel";
			this.valueInjecterTakesLabel.Size = new System.Drawing.Size (140, 23);
			this.valueInjecterTakesLabel.TabIndex = 1;
			this.valueInjecterTakesLabel.Text = "ValueInjecter takes :";
			this.valueInjecterTakesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// valueInjecterTakesValueLabel
			// 
			this.valueInjecterTakesValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.valueInjecterTakesValueLabel.Location = new System.Drawing.Point (994, 13);
			this.valueInjecterTakesValueLabel.Name = "valueInjecterTakesValueLabel";
			this.valueInjecterTakesValueLabel.Size = new System.Drawing.Size (124, 23);
			this.valueInjecterTakesValueLabel.TabIndex = 2;
			this.valueInjecterTakesValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// autoMapperOutputTextBox
			// 
			this.autoMapperOutputTextBox.Font = new System.Drawing.Font ("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.autoMapperOutputTextBox.Location = new System.Drawing.Point (13, 43);
			this.autoMapperOutputTextBox.Multiline = true;
			this.autoMapperOutputTextBox.Name = "autoMapperOutputTextBox";
			this.autoMapperOutputTextBox.ReadOnly = true;
			this.autoMapperOutputTextBox.Size = new System.Drawing.Size (550, 475);
			this.autoMapperOutputTextBox.TabIndex = 3;
			// 
			// valueInjecterOutputTextBox
			// 
			this.valueInjecterOutputTextBox.Font = new System.Drawing.Font ("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.valueInjecterOutputTextBox.Location = new System.Drawing.Point (569, 43);
			this.valueInjecterOutputTextBox.Multiline = true;
			this.valueInjecterOutputTextBox.Name = "valueInjecterOutputTextBox";
			this.valueInjecterOutputTextBox.ReadOnly = true;
			this.valueInjecterOutputTextBox.Size = new System.Drawing.Size (550, 475);
			this.valueInjecterOutputTextBox.TabIndex = 3;
			// 
			// serializedOutputFromAutoMapperLabel
			// 
			this.serializedOutputFromAutoMapperLabel.Location = new System.Drawing.Point (13, 517);
			this.serializedOutputFromAutoMapperLabel.Name = "serializedOutputFromAutoMapperLabel";
			this.serializedOutputFromAutoMapperLabel.Size = new System.Drawing.Size (550, 56);
			this.serializedOutputFromAutoMapperLabel.TabIndex = 1;
			this.serializedOutputFromAutoMapperLabel.Text = "Serialized AutoMapper Output";
			// 
			// serializedOutputFromValueInjecterLabel
			// 
			this.serializedOutputFromValueInjecterLabel.Location = new System.Drawing.Point (569, 517);
			this.serializedOutputFromValueInjecterLabel.Name = "serializedOutputFromValueInjecterLabel";
			this.serializedOutputFromValueInjecterLabel.Size = new System.Drawing.Size (549, 56);
			this.serializedOutputFromValueInjecterLabel.TabIndex = 1;
			this.serializedOutputFromValueInjecterLabel.Text = "Serialized ValueInjecter Output";
			// 
			// AutoMapper2ValueInjecterCompareScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (1135, 575);
			this.Controls.Add (this.serializedOutputFromValueInjecterLabel);
			this.Controls.Add (this.serializedOutputFromAutoMapperLabel);
			this.Controls.Add (this.valueInjecterOutputTextBox);
			this.Controls.Add (this.autoMapperOutputTextBox);
			this.Controls.Add (this.valueInjecterTakesValueLabel);
			this.Controls.Add (this.valueInjecterTakesLabel);
			this.Controls.Add (this.autoMapperTakesValueLabel);
			this.Controls.Add (this.autoMapperTakesLabel);
			this.Controls.Add (this.executeMappingButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "AutoMapper2ValueInjecterCompareScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Compare AutoMapper with ValueInjecter";
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.Button executeMappingButton;
		private System.Windows.Forms.Label autoMapperTakesLabel;
		private System.Windows.Forms.Label autoMapperTakesValueLabel;
		private System.Windows.Forms.Label valueInjecterTakesLabel;
		private System.Windows.Forms.Label valueInjecterTakesValueLabel;
		private System.Windows.Forms.TextBox autoMapperOutputTextBox;
		private System.Windows.Forms.TextBox valueInjecterOutputTextBox;
		private System.Windows.Forms.Label serializedOutputFromAutoMapperLabel;
		private System.Windows.Forms.Label serializedOutputFromValueInjecterLabel;
	}
}

