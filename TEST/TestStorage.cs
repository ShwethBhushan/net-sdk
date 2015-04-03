using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls.Resource;

namespace TEST
{
    public static class TestStorage
    {
        public static string CallerIdId { get; set; }
        public static string RecordingId { get; set; }
        public static string KeywordId { get; set; }
        public static List<string> Contacts { get; set; }
        public static List<string> Groups { get; set; }
    }
}
