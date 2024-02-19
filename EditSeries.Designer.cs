namespace RmvDose
{
	partial class dlgEditSeries
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chartDemo = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.udWidth = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnColor = new System.Windows.Forms.Button();
			this.dlgEditColor = new System.Windows.Forms.ColorDialog();
			this.panelColor = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.chartDemo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udWidth)).BeginInit();
			this.SuspendLayout();
			// 
			// chartDemo
			// 
			chartArea1.Name = "ChartArea1";
			this.chartDemo.ChartAreas.Add(chartArea1);
			this.chartDemo.Location = new System.Drawing.Point(84, 61);
			this.chartDemo.Name = "chartDemo";
			series1.ChartArea = "ChartArea1";
			series1.Name = "Series1";
			this.chartDemo.Series.Add(series1);
			this.chartDemo.Size = new System.Drawing.Size(508, 355);
			this.chartDemo.TabIndex = 0;
			this.chartDemo.Text = "chart1";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(209, 434);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(370, 434);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// udWidth
			// 
			this.udWidth.Location = new System.Drawing.Point(150, 21);
			this.udWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.udWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udWidth.Name = "udWidth";
			this.udWidth.Size = new System.Drawing.Size(48, 20);
			this.udWidth.TabIndex = 3;
			this.udWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udWidth.ValueChanged += new System.EventHandler(this.udWidth_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(98, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Width";
			// 
			// btnColor
			// 
			this.btnColor.Location = new System.Drawing.Point(226, 21);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(75, 23);
			this.btnColor.TabIndex = 5;
			this.btnColor.Text = "Color...";
			this.btnColor.UseVisualStyleBackColor = true;
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// panelColor
			// 
			this.panelColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelColor.Location = new System.Drawing.Point(318, 16);
			this.panelColor.Name = "panelColor";
			this.panelColor.Size = new System.Drawing.Size(84, 28);
			this.panelColor.TabIndex = 6;
			this.panelColor.Click += new System.EventHandler(this.panelColor_Click);
			// 
			// dlgEditSeries
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(800, 469);
			this.Controls.Add(this.panelColor);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.udWidth);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.chartDemo);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgEditSeries";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Series";
			((System.ComponentModel.ISupportInitialize)(this.chartDemo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udWidth)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chartDemo;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.NumericUpDown udWidth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnColor;
		private System.Windows.Forms.ColorDialog dlgEditColor;
		private System.Windows.Forms.Panel panelColor;
	}
}