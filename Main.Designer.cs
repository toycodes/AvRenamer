namespace avmanager
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadFolderPath = new System.Windows.Forms.TextBox();
            this.FileView = new System.Windows.Forms.DataGridView();
            this.SelectDownloadFolderButton = new System.Windows.Forms.Button();
            this.SelectWorkingFolderButton = new System.Windows.Forms.Button();
            this.WorkingFolderPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SmartMove = new System.Windows.Forms.Button();
            this.GetImageData = new System.Windows.Forms.Button();
            this.OriginalFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangedFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FileView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Folder";
            // 
            // DownloadFolderPath
            // 
            this.DownloadFolderPath.Location = new System.Drawing.Point(164, 29);
            this.DownloadFolderPath.Name = "DownloadFolderPath";
            this.DownloadFolderPath.Size = new System.Drawing.Size(714, 21);
            this.DownloadFolderPath.TabIndex = 2;
            this.DownloadFolderPath.Text = "X:\\btdownload";
            // 
            // FileView
            // 
            this.FileView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.FileView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OriginalFilename,
            this.ChangedFilename});
            this.FileView.Location = new System.Drawing.Point(28, 151);
            this.FileView.Name = "FileView";
            this.FileView.RowTemplate.Height = 23;
            this.FileView.Size = new System.Drawing.Size(989, 568);
            this.FileView.TabIndex = 3;
            // 
            // SelectDownloadFolderButton
            // 
            this.SelectDownloadFolderButton.Location = new System.Drawing.Point(898, 27);
            this.SelectDownloadFolderButton.Name = "SelectDownloadFolderButton";
            this.SelectDownloadFolderButton.Size = new System.Drawing.Size(75, 23);
            this.SelectDownloadFolderButton.TabIndex = 5;
            this.SelectDownloadFolderButton.Text = "...";
            this.SelectDownloadFolderButton.UseVisualStyleBackColor = true;
            this.SelectDownloadFolderButton.Click += new System.EventHandler(this.SelectDownloadFolderButton_Click);
            // 
            // SelectWorkingFolderButton
            // 
            this.SelectWorkingFolderButton.Location = new System.Drawing.Point(898, 65);
            this.SelectWorkingFolderButton.Name = "SelectWorkingFolderButton";
            this.SelectWorkingFolderButton.Size = new System.Drawing.Size(75, 23);
            this.SelectWorkingFolderButton.TabIndex = 8;
            this.SelectWorkingFolderButton.Text = "...";
            this.SelectWorkingFolderButton.UseVisualStyleBackColor = true;
            this.SelectWorkingFolderButton.Click += new System.EventHandler(this.SelectWorkingFolderButton_Click);
            // 
            // WorkingFolderPath
            // 
            this.WorkingFolderPath.Location = new System.Drawing.Point(164, 67);
            this.WorkingFolderPath.Name = "WorkingFolderPath";
            this.WorkingFolderPath.Size = new System.Drawing.Size(714, 21);
            this.WorkingFolderPath.TabIndex = 7;
            this.WorkingFolderPath.Text = "X:\\Movies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dest Folder";
            // 
            // SmartMove
            // 
            this.SmartMove.Location = new System.Drawing.Point(361, 108);
            this.SmartMove.Name = "SmartMove";
            this.SmartMove.Size = new System.Drawing.Size(75, 23);
            this.SmartMove.TabIndex = 10;
            this.SmartMove.Text = "SmartMove";
            this.SmartMove.UseVisualStyleBackColor = true;
            this.SmartMove.Click += new System.EventHandler(this.SmartMove_Click);
            // 
            // GetImageData
            // 
            this.GetImageData.Location = new System.Drawing.Point(572, 108);
            this.GetImageData.Name = "GetImageData";
            this.GetImageData.Size = new System.Drawing.Size(174, 23);
            this.GetImageData.TabIndex = 11;
            this.GetImageData.Text = "GetImageData(not ready)";
            this.GetImageData.UseVisualStyleBackColor = true;
            this.GetImageData.Click += new System.EventHandler(this.GetImages_Click);
            // 
            // OriginalFilename
            // 
            this.OriginalFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OriginalFilename.FillWeight = 50F;
            this.OriginalFilename.HeaderText = "Original Filename";
            this.OriginalFilename.Name = "OriginalFilename";
            // 
            // ChangedFilename
            // 
            this.ChangedFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChangedFilename.FillWeight = 50F;
            this.ChangedFilename.HeaderText = "ChangedFilename";
            this.ChangedFilename.Name = "ChangedFilename";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 767);
            this.Controls.Add(this.GetImageData);
            this.Controls.Add(this.SmartMove);
            this.Controls.Add(this.SelectWorkingFolderButton);
            this.Controls.Add(this.WorkingFolderPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectDownloadFolderButton);
            this.Controls.Add(this.FileView);
            this.Controls.Add(this.DownloadFolderPath);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AvRenamer";
            ((System.ComponentModel.ISupportInitialize)(this.FileView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DownloadFolderPath;
        private System.Windows.Forms.DataGridView FileView;
        private System.Windows.Forms.Button SelectDownloadFolderButton;
        private System.Windows.Forms.Button SelectWorkingFolderButton;
        private System.Windows.Forms.TextBox WorkingFolderPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SmartMove;
        private System.Windows.Forms.Button GetImageData;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangedFilename;
    }
}

