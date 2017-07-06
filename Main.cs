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

        private void StartScan_Click(object sender, EventArgs e)
        {
            StartScan.Enabled = false;
            List<ExtractorResult> results = CodeExtractor.extractFolder(DownloadFolderPath.Text);
            FileView.Rows.Clear();
            foreach(ExtractorResult result in results)
            {
                DataGridViewRow row = new DataGridViewRow();
                if (result.possibleCode.Length == 1)
                {
                    DataGridViewTextBoxCell filePath = new DataGridViewTextBoxCell();
                    filePath.Value = result.filePath;
                    row.Cells.Add(filePath);

                    DataGridViewTextBoxCell possibleCode = new DataGridViewTextBoxCell();
                    possibleCode.Value = result.recommandCode;
                    row.Cells.Add(possibleCode);

                    DataGridViewCheckBoxCell isRename = new DataGridViewCheckBoxCell();
                    isRename.Value = false;
                    row.Cells.Add(isRename);
                }
                if(result.possibleCode.Length == 0)
                {
                    DataGridViewTextBoxCell filePath = new DataGridViewTextBoxCell();
                    filePath.Value = result.filePath;
                    row.Cells.Add(filePath);

                    DataGridViewTextBoxCell possibleCode = new DataGridViewTextBoxCell();
                    possibleCode.Value = "";
                    row.Cells.Add(possibleCode);

                    DataGridViewCheckBoxCell isRename = new DataGridViewCheckBoxCell();
                    isRename.Value = false;
                    row.Cells.Add(isRename);
                }
                if (result.possibleCode.Length > 1)
                {
                    
                    DataGridViewTextBoxCell filePath = new DataGridViewTextBoxCell();
                    filePath.Value = result.filePath;
                    row.Cells.Add(filePath);
                    
                    DataGridViewComboBoxCell possibleCode = new DataGridViewComboBoxCell();
                    possibleCode.Items.AddRange(result.possibleCode);
                    possibleCode.Value = result.recommandCode;
                    row.Cells.Add(possibleCode);

                    DataGridViewCheckBoxCell isRename = new DataGridViewCheckBoxCell();

                    if ((string)possibleCode.Value != "")
                        isRename.Value = false;
                    else
                        isRename.Value = false;
                    row.Cells.Add(isRename);
                }
                FileView.Rows.Add(row);
            }
            StartScan.Enabled = true;
            StartMove.Enabled = true;
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

        private void StartRename_Click(object sender, EventArgs e)
        {
            StartMove.Enabled = false;
            int row = FileView.Rows.Count;
            for(int i=0;i< row; i++)
            {
                if (FileView.Rows[i].Cells.Count < 2 || !(FileView.Rows[i].Cells[2] is DataGridViewCheckBoxCell)) continue;
                DataGridViewCheckBoxCell selectedStatus = (DataGridViewCheckBoxCell)FileView.Rows[i].Cells[2];
                if((bool)selectedStatus.Value)
                {
                    string orgiPath = (string)FileView.Rows[i].Cells[0].Value;
                    string identifyCode = (string)FileView.Rows[i].Cells[1].Value;
                    string destPath = WorkingFolderPath.Text + "\\" + identifyCode + Path.GetExtension(orgiPath);
                    File.Move(orgiPath, destPath);
                }
            }
            StartMove.Enabled = true;
            StartScan_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JavLibraryScraper scraper = new JavLibraryScraper();
            DirectoryInfo folder = new DirectoryInfo(WorkingFolderPath.Text);
            RenameMovies.Enabled = false;
            foreach (FileInfo file in folder.GetFiles())
            {
                try
                {
                    if (file.Name.Contains("[")) continue;
                    string[] name = file.Name.Split('.');
                    MoiveInfo info = scraper.getMoiveInfoByIdentifyCode(name[0]);
                    string actor_list = string.Join(",", info.Actors);
                    actor_list = "[" + actor_list + "]";
                    string genres = string.Join(",", info.Tags);
                    genres = "[" + genres + "]";
                    string leftName = "";
                    for (int i = 1;i < name.Length;i++) leftName += "."+name[i];
                    string destFile = Path.GetDirectoryName(file.FullName) + "\\" + info.Name + actor_list + genres + leftName;
                    File.Move(file.FullName, destFile);
                }
                catch
                {
                    continue;
                }   
            }
            RenameMovies.Enabled = true;
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
                if(names[0].LastIndexOf('[') != -1)
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
            return string.Join(".",names);
        }

        private void SmartMove_Click(object sender, EventArgs e)
        {
            SmartMove.Enabled = false;
            JavLibraryScraper scraper = new JavLibraryScraper();
            List<ExtractorResult> results = CodeExtractor.extractFolder(DownloadFolderPath.Text);
            foreach(ExtractorResult er in results)
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
                    string destFile = WorkingFolderPath.Text + "\\" + getAllowedFileName(info.Name + actor_list + genres + leftName)+Path.GetExtension(er.filePath);
                    Text = info.Name;
                    File.Move(er.filePath, destFile);
                }
                catch
                {
                    continue;
                }
            }
            SmartMove.Enabled = true;
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
            GetImages.Enabled = false;
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
            GetImages.Enabled = true;
        }
    }
}
