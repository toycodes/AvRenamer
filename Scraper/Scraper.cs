using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avmanager.Scraper
{
    public class MoiveInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentifyCode { get; set; }
        public string IssueDate { get; set; }
        public string RunningTime { get; set; }
        public string Director { get; set; }
        public string Producers { get; set; }
        public string Publisher { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Actors { get; set; }
        public string imgUrl { get; set; }
        public byte[] imgData { get; set; }
    } 
    interface Scraper
    {
        MoiveInfo getMoiveInfoByIdentifyCode(string code);
    }
}
