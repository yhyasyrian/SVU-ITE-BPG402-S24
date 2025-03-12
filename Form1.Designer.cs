namespace HomeWork
{
    partial class HomeWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeWork));
            this.DrawPoints = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.DeCasteljau = new System.Windows.Forms.Button();
            this.PanelPoints = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // DrawPoints
            // 
            this.DrawPoints.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DrawPoints.Location = new System.Drawing.Point(12, 12);
            this.DrawPoints.Name = "DrawPoints";
            this.DrawPoints.Size = new System.Drawing.Size(96, 45);
            this.DrawPoints.TabIndex = 0;
            this.DrawPoints.Text = "Draw Points";
            this.DrawPoints.UseVisualStyleBackColor = true;
            this.DrawPoints.Click += new System.EventHandler(this.DrawPoints_Click);
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Clear.Location = new System.Drawing.Point(12, 63);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(96, 45);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // DeCasteljau
            // 
            this.DeCasteljau.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DeCasteljau.Location = new System.Drawing.Point(12, 114);
            this.DeCasteljau.Name = "DeCasteljau";
            this.DeCasteljau.Size = new System.Drawing.Size(96, 45);
            this.DeCasteljau.TabIndex = 2;
            this.DeCasteljau.Text = "De Casteljau";
            this.DeCasteljau.UseVisualStyleBackColor = true;
            this.DeCasteljau.Click += new System.EventHandler(this.DeCasteljau_Click);
            // 
            // PanelPoints
            // 
            this.PanelPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PanelPoints.Location = new System.Drawing.Point(128, 1);
            this.PanelPoints.Name = "PanelPoints";
            this.PanelPoints.Size = new System.Drawing.Size(653, 448);
            this.PanelPoints.TabIndex = 3;
            this.PanelPoints.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPoints_Paint);
            this.PanelPoints.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelPoints_MouseClick);
            // 
            // HomeWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(781, 447);
            this.Controls.Add(this.PanelPoints);
            this.Controls.Add(this.DeCasteljau);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.DrawPoints);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomeWork";
            this.Text = "HomeWork";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DrawPoints;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button DeCasteljau;
        private System.Windows.Forms.Panel PanelPoints;
    }
}

