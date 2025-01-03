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
            getButton = new Button();
            statusStrip = new StatusStrip();
            systemStatus = new ToolStripStatusLabel();
            httpVerbList = new ComboBox();
            callData = new TabControl();
            bodyTab = new TabPage();
            bodyBox = new TextBox();
            resultsTab = new TabPage();
            resultsBox = new TextBox();
            statusStrip.SuspendLayout();
            callData.SuspendLayout();
            bodyTab.SuspendLayout();
            resultsTab.SuspendLayout();
            SuspendLayout();
            // 
            // urlBox
            // 
            urlBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlBox.Location = new Point(193, 38);
            urlBox.Name = "urlBox";
            urlBox.Size = new Size(976, 39);
            urlBox.TabIndex = 0;
            urlBox.TextChanged += urlBox_TextChanged;
            urlBox.Enter += urlBox_Enter;
            // 
            // urlLabel
            // 
            urlLabel.AutoSize = true;
            urlLabel.Location = new Point(27, 40);
            urlLabel.Name = "urlLabel";
            urlLabel.Size = new Size(53, 32);
            urlLabel.TabIndex = 1;
            urlLabel.Text = "API:";
            // 
            // getButton
            // 
            getButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            getButton.Location = new Point(1175, 37);
            getButton.Name = "getButton";
            getButton.Size = new Size(126, 40);
            getButton.TabIndex = 4;
            getButton.Text = "GET";
            getButton.UseVisualStyleBackColor = true;
            getButton.Click += getButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = SystemColors.Control;
            statusStrip.GripStyle = ToolStripGripStyle.Visible;
            statusStrip.Items.AddRange(new ToolStripItem[] { systemStatus });
            statusStrip.Location = new Point(0, 727);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1338, 30);
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
            // httpVerbList
            // 
            httpVerbList.DropDownStyle = ComboBoxStyle.DropDownList;
            httpVerbList.FormattingEnabled = true;
            httpVerbList.Items.AddRange(new object[] { "GET", "POST", "PUT", "PATCH", "DELETE" });
            httpVerbList.Location = new Point(78, 37);
            httpVerbList.Name = "httpVerbList";
            httpVerbList.Size = new Size(109, 40);
            httpVerbList.TabIndex = 6;
            httpVerbList.SelectedIndexChanged += httpVerbList_SelectedIndexChanged;
            // 
            // callData
            // 
            callData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            callData.Controls.Add(bodyTab);
            callData.Controls.Add(resultsTab);
            callData.Location = new Point(12, 104);
            callData.Name = "callData";
            callData.SelectedIndex = 0;
            callData.Size = new Size(1314, 620);
            callData.TabIndex = 7;
            // 
            // bodyTab
            // 
            bodyTab.Controls.Add(bodyBox);
            bodyTab.Location = new Point(4, 41);
            bodyTab.Name = "bodyTab";
            bodyTab.Padding = new Padding(3);
            bodyTab.Size = new Size(1306, 575);
            bodyTab.TabIndex = 0;
            bodyTab.Text = "Body";
            bodyTab.UseVisualStyleBackColor = true;
            // 
            // bodyBox
            // 
            bodyBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            bodyBox.BackColor = SystemColors.HighlightText;
            bodyBox.Location = new Point(3, 3);
            bodyBox.Multiline = true;
            bodyBox.Name = "bodyBox";
            bodyBox.ScrollBars = ScrollBars.Both;
            bodyBox.Size = new Size(1321, 565);
            bodyBox.TabIndex = 4;
            // 
            // resultsTab
            // 
            resultsTab.BackColor = Color.Black;
            resultsTab.Controls.Add(resultsBox);
            resultsTab.Location = new Point(4, 41);
            resultsTab.Name = "resultsTab";
            resultsTab.Padding = new Padding(3);
            resultsTab.Size = new Size(1306, 575);
            resultsTab.TabIndex = 1;
            resultsTab.Text = "Results";
            // 
            // resultsBox
            // 
            resultsBox.BackColor = SystemColors.HighlightText;
            resultsBox.Dock = DockStyle.Fill;
            resultsBox.Location = new Point(3, 3);
            resultsBox.Multiline = true;
            resultsBox.Name = "resultsBox";
            resultsBox.ScrollBars = ScrollBars.Both;
            resultsBox.Size = new Size(1300, 569);
            resultsBox.TabIndex = 4;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 757);
            Controls.Add(callData);
            Controls.Add(httpVerbList);
            Controls.Add(statusStrip);
            Controls.Add(getButton);
            Controls.Add(urlLabel);
            Controls.Add(urlBox);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6);
            MinimumSize = new Size(500, 400);
            Name = "Dashboard";
            Text = "API Dashboard";
            Load += Dashboard_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            callData.ResumeLayout(false);
            bodyTab.ResumeLayout(false);
            bodyTab.PerformLayout();
            resultsTab.ResumeLayout(false);
            resultsTab.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox urlBox;
        private Label urlLabel;
        private Button getButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel systemStatus;
        private ComboBox httpVerbList;
        private TabControl callData;
        private TabPage bodyTab;
        private TabPage resultsTab;
        private TabPage tabPage1;
        private TextBox bodyBox;
        private TextBox resultsBox;
    }
}
