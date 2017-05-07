using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace WinRecomendationSystem
{
    public class HTMLParser
    {
        private string url = "https://www.ebilet.pl/muzyka/";
        public HtmlDocument Html { get; private set; }
        public HTMLParser()
        {
            Html = new HtmlDocument();
            Html.LoadHtml(new WebClient { Encoding = System.Text.Encoding.UTF8 }.DownloadString(url));
            var divs = GetDivWithClassName(Html.DocumentNode, "events");
        }
        public static IEnumerable<HtmlNode> GetDivWithClassName(HtmlNode node, string className)
        {
            return node.Descendants("div").Where(div=>div.HasAttributes && div.Attributes["class"].Name==className);
        }
    }
}
