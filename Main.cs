using avmanager.Scraper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace avmanager
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void SelectDownloadFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            DownloadFolderPath.Text = fbd.SelectedPath;
        }

        private void SelectWorkingFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            WorkingFolderPath.Text = fbd.SelectedPath;
        }

        private static string getAllowedFileName(string name)
        {
            char[] errorChars = Path.GetInvalidFileNameChars();
            foreach (char chr in errorChars)
            {
                name = name.Replace(chr, ' ');
            }
            string[] names = name.Split('.');
            while (System.Text.Encoding.Default.GetBytes(names[0]).Length > 170)
            {
                if (names[0].LastIndexOf('[') != -1)
                {
                    names[0] = names[0].Substring(0, names[0].LastIndexOf('['));
                }
                else if (name.LastIndexOf(' ') != -1)
                {
                    names[0] = names[0].Substring(0, names[0].LastIndexOf(' '));
                }
                else
                {
                    break;
                }
            }
            return string.Join(".", names);
        }

        private void doWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            JavLibraryScraper scraper = new JavLibraryScraper();
            List<ExtractorResult> results = CodeExtractor.extractFolder(DownloadFolderPath.Text);
            foreach (ExtractorResult er in results)
            {
                try
                {
                    if (er.recommandCode == "") continue;
                    string[] name = er.recommandCode.Split('.');
                    MoiveInfo info = scraper.getMoiveInfoByIdentifyCode(name[0]);
                    string actor_list = string.Join(",", info.Actors);
                    actor_list = "[" + actor_list + "]";
                    string genres = string.Join(",", info.Tags);
                    genres = "[" + genres + "]";
                    string leftName = "";
                    for (int i = 1; i < name.Length; i++) leftName += "." + name[i];
                    string destFile = WorkingFolderPath.Text + "\\" + getAllowedFileName(info.Name + actor_list + genres + leftName) + Path.GetExtension(er.filePath);
                    er.destName = destFile;
                    File.Move(er.filePath, er.destName);
                    bw.ReportProgress(0, er);
                }
                catch
                {
                    continue;
                }
            }
            bw.ReportProgress(100);
        }

        private void updateFileView(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                ExtractorResult er = e.UserState as ExtractorResult;
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell oriFilename = new DataGridViewTextBoxCell();
                oriFilename.Value = Path.GetFileName(er.filePath);
                row.Cells.Add(oriFilename);
                DataGridViewTextBoxCell changedFilename = new DataGridViewTextBoxCell();
                changedFilename.Value = Path.GetFileName(er.destName);
                row.Cells.Add(changedFilename);
                FileView.Rows.Add(row);
            }

            if (e.ProgressPercentage == 100) SmartMove.Enabled = true;
        }

        private void SmartMove_Click(object sender, EventArgs e)
        {
            SmartMove.Enabled = false;
            BackgroundWorker m_BackgroundWorker = new BackgroundWorker();
            m_BackgroundWorker.WorkerReportsProgress = true;
            m_BackgroundWorker.DoWork += new DoWorkEventHandler(doWork);
            m_BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(updateFileView);
            m_BackgroundWorker.RunWorkerAsync();
        }

        private byte[] downloadImgData(string url)
        {
            byte[] imgData;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.Headers.Add("User-Agent", "Chrome");
                imgData=wc.DownloadData(url);
            }
            return imgData;
        }

        private void GetImages_Click(object sender, EventArgs e)
        {
            GetImageData.Enabled = false;
            JavLibraryScraper scraper = new JavLibraryScraper();
            List<ExtractorResult> results = CodeExtractor.extractFolder(WorkingFolderPath.Text);
            foreach (ExtractorResult er in results)
            {
                try
                {
                    if (er.recommandCode == "") continue;
                    string[] name = er.recommandCode.Split('.');
                    MoiveInfo info = scraper.getMoiveInfoByIdentifyCode(name[0]);
                    while (true)
                    {
                        try
                        {
                            info.imgData = downloadImgData(info.imgUrl);
                            break;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
            GetImageData.Enabled = true;
        }
    }
}
