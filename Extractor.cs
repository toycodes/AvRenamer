using avmanager.Scraper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace avmanager
{
    class ExtractorResult
    {
        public string fileName;
        public string filePath;
        public string destName;
        public string recommandCode;
        public string[] possibleCode;
    }

    class CodeExtractor
    {
        private static string codePattern = "([A-Za-z]{2,5})[-|_]?([0-9]{2,5})(?![0-9])";

        private static Dictionary<string, int> possibleCodePrefix = new Dictionary<string, int>();
        private static HashSet<string> impossibleCodePrefix = new HashSet<string>();

        private static string[] videoExtensions =
        {
            ".avi",".rmvb",".rm",".asf",".divx",".mpg",".mpeg",".mpe",".wmv",".mp4",".mkv",".vob",".m4v",
            ".iso"
        };

        private static string urlFilter(string name)
        {
            string pattern = "[A-Za-z0-9]+\\u002E(com|net|cc|la|name|info|ws|tv|fm|asia|jp|uk)";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(name);
            foreach (Match match in matches)
            {
                name = name.Replace(match.Groups[0].Value, "");
            }
            return name;
        }

        public static string[] extract(string name)
        {
            name = urlFilter(name);
            List<string> codes = new List<string>();
            Regex regex = new Regex(codePattern);
            MatchCollection matches = regex.Matches(name);
            foreach(Match match in matches)
            {
                codes.Add(match.Groups[1].Value.ToUpper() + "-" + match.Groups[2].Value);
            }
            if(matches.Count==1)
            {
                Match match = matches[0];
                if (possibleCodePrefix.ContainsKey(match.Groups[1].Value.ToUpper()))
                    possibleCodePrefix[match.Groups[1].Value.ToUpper()]++;
                else
                    possibleCodePrefix.Add(match.Groups[1].Value.ToUpper(), 1);
            }
            return codes.ToArray<string>();
        }

        public static ExtractorResult extractOne(string path)
        {
            ExtractorResult result = new ExtractorResult();
            
            if(!File.Exists(path))
            {
                return null;
            }

            string externs = Path.GetExtension(path);
            if (!videoExtensions.Contains(Path.GetExtension(path)))
            {
                return null;
            }

            result.filePath = path;
            result.fileName = Path.GetFileNameWithoutExtension(path);
            result.possibleCode = extract(result.fileName);

            return result;
        }

        private static List<ExtractorResult> extractFolderInternal(FileSystemInfo[] FSInfo)
        {
            List<ExtractorResult> result = new List<ExtractorResult>();

            if (FSInfo == null) return result;

            foreach(FileSystemInfo info in FSInfo)
            {
                if(info is DirectoryInfo)
                {
                    DirectoryInfo dInfo = (DirectoryInfo)info;
                    result.AddRange(extractFolderInternal(dInfo.GetFileSystemInfos()));
                }
                if(info is FileInfo)
                {
                    FileInfo dInfo = (FileInfo)info;
                    ExtractorResult eRes = extractOne(dInfo.FullName);
                    if (eRes != null)
                        result.Add(eRes);
                }
            }
            return result;
        }

        public static List<ExtractorResult> extractFolder(string path)
        {
            List<ExtractorResult> result = new List<ExtractorResult>();

            if (!Directory.Exists(path))
            {
                MessageBox.Show("Can not access " + path, "Error", MessageBoxButtons.OK);
                return result;
            }

            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Exists) return result;

            FileSystemInfo[] infos = dir.GetFileSystemInfos();

            result.AddRange(extractFolderInternal(infos));

            while(true)
            {
                int beginSize = impossibleCodePrefix.Count;
                foreach(ExtractorResult er in result)
                {
                    er.recommandCode = getRecommandCode(er.possibleCode);
                }
                int endSize = impossibleCodePrefix.Count;
                if (beginSize == endSize) break;
            }

            HashSet<string> codeCollections = new HashSet<string>();
            foreach(ExtractorResult er in result)
            {
                int order = 2;
                if (er.recommandCode == "") continue;
                if(codeCollections.Contains(er.recommandCode))
                {
                    while (codeCollections.Contains(er.recommandCode +"."+ order)) order++;
                    er.recommandCode = er.recommandCode + "." + order;
                }
                codeCollections.Add(er.recommandCode);
            }
            foreach (ExtractorResult er in result)
            {
                if (codeCollections.Contains(er.recommandCode+".2"))
                {
                    er.recommandCode = er.recommandCode + ".1";
                }
            }

            foreach (ExtractorResult er in result)
            {
                if (er.fileName.EndsWith("_C") || er.fileName.EndsWith("_c"))
                {
                    er.recommandCode = er.recommandCode + ".C"; 
                }
            }

            return result;
        }

        public static string getRecommandCode(string[] possibleCode)
        {
            string candidate = "";
            int count = 0;
            foreach (string code in possibleCode)
            {
                if (impossibleCodePrefix.Contains(code.Split('-')[0])) continue;
                string tmp = code.Split('-')[0];
                if (possibleCodePrefix.ContainsKey(tmp) && possibleCodePrefix[tmp] > count)
                {
                    candidate = code;
                    count = possibleCodePrefix[tmp];
                }
            }
            if (candidate != "")
            {
                possibleCodePrefix[candidate.Split('-')[0]]++;
                foreach(string code in possibleCode)
                {
                    if(code!= candidate && !impossibleCodePrefix.Contains(code.Split('-')[0]))
                    {
                        impossibleCodePrefix.Add(code.Split('-')[0]);
                    }
                }
            }
            return candidate;
        }
    }
}
