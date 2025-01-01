namespace PostmanCloneUI
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            urlBox = new TextBox();
            urlLabel = new Label();
            resultsLabel = new Label();
            resultsBox = new TextBox();
            getButton = new Button();
            statusStrip = new StatusStrip();
            systemStatus = new ToolStripStatusLabel();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // urlBox
            // 
            urlBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlBox.Location = new Point(118, 69);
            urlBox.Name = "urlBox";
            urlBox.Size = new Size(1147, 39);
            urlBox.TabIndex = 0;
            urlBox.TextChanged += urlBox_TextChanged;
            urlBox.Enter += urlBox_Enter;
            // 
            // urlLabel
            // 
            urlLabel.AutoSize = true;
            urlLabel.Location = new Point(30, 69);
            urlLabel.Name = "urlLabel";
            urlLabel.Size = new Size(90, 32);
            urlLabel.TabIndex = 1;
            urlLabel.Text = "API Url:";
            // 
            // resultsLabel
            // 
            resultsLabel.AutoSize = true;
            resultsLabel.Location = new Point(30, 136);
            resultsLabel.Name = "resultsLabel";
            resultsLabel.Size = new Size(93, 32);
            resultsLabel.TabIndex = 2;
            resultsLabel.Text = "Results:";
            // 
            // resultsBox
            // 
            resultsBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultsBox.BackColor = SystemColors.HighlightText;
            resultsBox.BorderStyle = BorderStyle.FixedSingle;
            resultsBox.Location = new Point(30, 171);
            resultsBox.Multiline = true;
            resultsBox.Name = "resultsBox";
            resultsBox.ScrollBars = ScrollBars.Both;
            resultsBox.Size = new Size(1316, 499);
            resultsBox.TabIndex = 3;
            // 
            // getButton
            // 
            getButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            getButton.Location = new Point(1271, 69);
            getButton.Name = "getButton";
            getButton.Size = new Size(75, 39);
            getButton.TabIndex = 4;
            getButton.Text = "GET";
            getButton.UseVisualStyleBackColor = true;
            getButton.Click += getButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.Wheat;
            statusStrip.Items.AddRange(new ToolStripItem[] { systemStatus });
            statusStrip.Location = new Point(0, 686);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1380, 30);
            statusStrip.TabIndex = 5;
            statusStrip.Text = "statusStrip1";
            // 
            // systemStatus
            // 
            systemStatus.Font = new Font("Segoe UI", 14F);
            systemStatus.Name = "systemStatus";
            systemStatus.Size = new Size(62, 25);
            systemStatus.Text = "Ready";
            systemStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1380, 716);
            Controls.Add(statusStrip);
            Controls.Add(getButton);
            Controls.Add(resultsBox);
            Controls.Add(resultsLabel);
            Controls.Add(urlLabel);
            Controls.Add(urlBox);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6);
            Name = "Dashboard";
            Text = "API Dashboard";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox urlBox;
        private Label urlLabel;
        private Label resultsLabel;
        private TextBox resultsBox;
        private Button getButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel systemStatus;
    }
}
