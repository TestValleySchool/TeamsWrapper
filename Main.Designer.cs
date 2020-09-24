namespace TeamsWrapper
{
    partial class Main
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 23);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(455, 23);
            this.progressBar.TabIndex = 0;
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(12, 54);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(455, 34);
            this.label.TabIndex = 1;
            this.label.Text = "Looking for Teams...";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(201, 91);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(97, 34);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 137);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label);
            this.Controls.Add(this.progressBar);
            this.Name = "Main";
            this.Text = "Teams Wrapper";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button closeButton;
    }
}

