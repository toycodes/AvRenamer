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
            this.StartScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadFolderPath = new System.Windows.Forms.TextBox();
            this.FileView = new System.Windows.Forms.DataGridView();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentifyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartMove = new System.Windows.Forms.Button();
            this.SelectDownloadFolderButton = new System.Windows.Forms.Button();
            this.SelectWorkingFolderButton = new System.Windows.Forms.Button();
            this.WorkingFolderPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RenameMovies = new System.Windows.Forms.Button();
            this.SmartMove = new System.Windows.Forms.Button();
            this.GetImages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FileView)).BeginInit();
            this.SuspendLayout();
            // 
            // StartScan
            // 
            this.StartScan.Location = new System.Drawing.Point(353, 108);
            this.StartScan.Name = "StartScan";
            this.StartScan.Size = new System.Drawing.Size(75, 23);
            this.StartScan.TabIndex = 0;
            this.StartScan.Text = "StartScan";
            this.StartScan.UseVisualStyleBackColor = true;
            this.StartScan.Click += new System.EventHandler(this.StartScan_Click);
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
            this.FilePath,
            this.IdentifyCode,
            this.Action});
            this.FileView.Location = new System.Drawing.Point(28, 151);
            this.FileView.Name = "FileView";
            this.FileView.RowTemplate.Height = 23;
            this.FileView.Size = new System.Drawing.Size(989, 568);
            this.FileView.TabIndex = 3;
            // 
            // FilePath
            // 
            this.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilePath.FillWeight = 70F;
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            // 
            // IdentifyCode
            // 
            this.IdentifyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdentifyCode.FillWeight = 20F;
            this.IdentifyCode.HeaderText = "IdentifyCode";
            this.IdentifyCode.Name = "IdentifyCode";
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.FillWeight = 10F;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // StartMove
            // 
            this.StartMove.Enabled = false;
            this.StartMove.Location = new System.Drawing.Point(516, 108);
            this.StartMove.Name = "StartMove";
            this.StartMove.Size = new System.Drawing.Size(75, 23);
            this.StartMove.TabIndex = 4;
            this.StartMove.Text = "StartMove";
            this.StartMove.UseVisualStyleBackColor = true;
            this.StartMove.Click += new System.EventHandler(this.StartRename_Click);
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
            // RenameMovies
            // 
            this.RenameMovies.Location = new System.Drawing.Point(671, 108);
            this.RenameMovies.Name = "RenameMovies";
            this.RenameMovies.Size = new System.Drawing.Size(98, 23);
            this.RenameMovies.TabIndex = 9;
            this.RenameMovies.Text = "RenameMovies";
            this.RenameMovies.UseVisualStyleBackColor = true;
            this.RenameMovies.Click += new System.EventHandler(this.button1_Click);
            // 
            // SmartMove
            // 
            this.SmartMove.Location = new System.Drawing.Point(220, 108);
            this.SmartMove.Name = "SmartMove";
            this.SmartMove.Size = new System.Drawing.Size(75, 23);
            this.SmartMove.TabIndex = 10;
            this.SmartMove.Text = "SmartMove";
            this.SmartMove.UseVisualStyleBackColor = true;
            this.SmartMove.Click += new System.EventHandler(this.SmartMove_Click);
            // 
            // GetImages
            // 
            this.GetImages.Location = new System.Drawing.Point(816, 108);
            this.GetImages.Name = "GetImages";
            this.GetImages.Size = new System.Drawing.Size(98, 23);
            this.GetImages.TabIndex = 11;
            this.GetImages.Text = "GetImages";
            this.GetImages.UseVisualStyleBackColor = true;
            this.GetImages.Click += new System.EventHandler(this.GetImages_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 767);
            this.Controls.Add(this.GetImages);
            this.Controls.Add(this.SmartMove);
            this.Controls.Add(this.RenameMovies);
            this.Controls.Add(this.SelectWorkingFolderButton);
            this.Controls.Add(this.WorkingFolderPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectDownloadFolderButton);
            this.Controls.Add(this.StartMove);
            this.Controls.Add(this.FileView);
            this.Controls.Add(this.DownloadFolderPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartScan);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "avmanager";
            ((System.ComponentModel.ISupportInitialize)(this.FileView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DownloadFolderPath;
        private System.Windows.Forms.DataGridView FileView;
        private System.Windows.Forms.Button StartMove;
        private System.Windows.Forms.Button SelectDownloadFolderButton;
        private System.Windows.Forms.Button SelectWorkingFolderButton;
        private System.Windows.Forms.TextBox WorkingFolderPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentifyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.Button RenameMovies;
        private System.Windows.Forms.Button SmartMove;
        private System.Windows.Forms.Button GetImages;
    }
}

