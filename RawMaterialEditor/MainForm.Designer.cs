namespace RawMaterialEditor
{
    partial class MainForm
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
            propertyGrid = new PropertyGrid();
            btnOpen = new Button();
            btnSave = new Button();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            SuspendLayout();
            // 
            // propertyGrid
            // 
            propertyGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            propertyGrid.BackColor = Color.FromArgb(64, 64, 64);
            propertyGrid.CategorySplitterColor = Color.Silver;
            propertyGrid.CommandsBackColor = Color.FromArgb(64, 64, 64);
            propertyGrid.CommandsBorderColor = Color.FromArgb(64, 64, 64);
            propertyGrid.HelpBackColor = Color.Silver;
            propertyGrid.HelpBorderColor = Color.FromArgb(64, 64, 64);
            propertyGrid.LineColor = Color.Silver;
            propertyGrid.Location = new Point(12, 12);
            propertyGrid.Name = "propertyGrid";
            propertyGrid.PropertySort = PropertySort.Categorized;
            propertyGrid.SelectedItemWithFocusForeColor = Color.FromArgb(224, 224, 224);
            propertyGrid.Size = new Size(460, 308);
            propertyGrid.TabIndex = 0;
            propertyGrid.ToolbarVisible = false;
            propertyGrid.ViewBackColor = Color.Silver;
            propertyGrid.ViewBorderColor = Color.FromArgb(64, 64, 64);
            propertyGrid.Click += propertyGrid_Click;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOpen.Location = new Point(12, 326);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(75, 23);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open...";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Enabled = false;
            btnSave.Location = new Point(397, 326);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save...";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Raw material file|*.material";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Raw material file|*.material";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(484, 361);
            Controls.Add(btnSave);
            Controls.Add(btnOpen);
            Controls.Add(propertyGrid);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HD2 Raw Material Editor";
            ResumeLayout(false);
        }

        #endregion

        private PropertyGrid propertyGrid;
		private Button btnOpen;
		private Button btnSave;
		private OpenFileDialog openFileDialog;
		private SaveFileDialog saveFileDialog;
	}
}
