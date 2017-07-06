using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace avmanager.Scraper
{
    class JavLibraryScraper : Scraper
    {
        private static string HTMLDeCode(string sHTML)
        {
            string sTemp = "";
            if (sHTML.Length == 0)
            {
                return "";
            }
            sTemp = sHTML.Replace("&lt;", "<");
            sTemp = sTemp.Replace("&gt;", ">");
            sTemp = sTemp.Replace("&#39;", "'");
            sTemp = sTemp.Replace("&nbsp;", " ");
            sTemp = sTemp.Replace("&quot;", "\"");
            sTemp = sTemp.Replace("&amp;", "&");
            sTemp = sTemp.Replace("<br />", "\n");
            return sTemp.TrimEnd().TrimStart();
        }

        public MoiveInfo getMoiveInfoByIdentifyCode(string code)
        {
            
            MoiveInfo info = new MoiveInfo();
            var url = "http://www.javlibrary.com/cn/vl_searchbyid.php?keyword=" + code;
            var web = new HtmlWeb();
            HtmlDocument doc;
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                    doc = web.Load(url);
                    break;
                }
                catch
                {
                    continue;
                }
            }
            if(doc.DocumentNode.SelectNodes("//*[@id=\"rightcolumn\"]/div")[0].InnerText.Contains("识别码搜寻结果"))
            {
                var videos = doc.DocumentNode.SelectNodes("//*[@id=\"rightcolumn\"]/div[2]/div/div");
                foreach(var video in videos)
                {
                    if(video.InnerText.Contains(code.ToUpper()))
                    {
                        var url_t = "http://www.javlibrary.com/cn/?v=" + video.Id.Replace("vid_", "");
                        while(true)
                        {
                            try
                            {
                                Thread.Sleep(500);
                                doc = web.Load(url_t);
                                break;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        break;
                    }
                }
            }
            info.Name = HTMLDeCode(doc.DocumentNode.SelectNodes("//*[@id=\"video_title\"]/h3/a")[0].InnerText);
            info.IdentifyCode = HTMLDeCode(doc.DocumentNode.SelectNodes("//*[@id=\"video_id\"]/table/tr/td")[1].InnerText);
            info.IssueDate = HTMLDeCode(doc.DocumentNode.SelectNodes("//*[@id=\"video_date\"]/table/tr/td")[1].InnerText);
            info.RunningTime = HTMLDeCode(doc.DocumentNode.SelectNodes("//*[@id=\"video_length\"]/table/tr/td")[1].InnerText);
            info.Director = HTMLDeCode(doc.DocumentNode.SelectNodes("//*[@id=\"video_director\"]/table/tr/td")[1].InnerText);
            info.Producers = HTMLDeCode(doc.DocumentNode.SelectNodes("//*[@id=\"video_maker\"]/table/tr/td")[1].InnerText);
            info.Publisher = HTMLDeCode(doc.DocumentNode.SelectNodes("//*[@id=\"video_label\"]/table/tr/td")[1].InnerText);

            info.Tags = new List<string>();
            var video_genres = doc.DocumentNode.SelectNodes("//*[@id=\"video_genres\"]/table/tr/td")[1];
            foreach (var genre in video_genres.ChildNodes)
            {
                info.Tags.Add(HTMLDeCode(genre.InnerText));
            }

            info.Actors = new List<string>();
            var video_cast = doc.DocumentNode.SelectNodes("//*[@id=\"video_cast\"]/table/tr/td")[1];
            foreach (var actor in video_cast.ChildNodes)
            {
                info.Actors.Add(HTMLDeCode(actor.ChildNodes[0].InnerText));
            }

            info.imgUrl = doc.DocumentNode.SelectNodes("//*[@id=\"video_jacket_img\"]")[0].Attributes["src"].Value;
            return info;
        }
    }
}
