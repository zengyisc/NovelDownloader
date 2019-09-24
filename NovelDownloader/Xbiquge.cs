using HtmlAgilityPack;
using NovelDownloader.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovelDownloader
{
    /// <summary>
    /// 站名：新笔趣阁
    /// 地址：http://www.xbiquge.la
    /// </summary>
    public class Xbiquge
    {
        List<Chapter> chapters = new List<Chapter>();

        /// <summary>
        /// 开始下载
        /// </summary>
        /// <param name="url"></param>
        public void Start(string url, string name)
        {
            GetChapters(url);

            GetContent(name);
        }

        /// <summary>
        /// 获取章节
        /// </summary>
        /// <param name="url"></param>
        private void GetChapters(string url)
        {
            HttpHelper http = new HttpHelper();

            HttpItem httpItem = new HttpItem();
            httpItem.URL = url;

            var result = http.GetHtml(httpItem);

            HtmlDocument doc = new HtmlDocument();

            doc.LoadHtml(result.Html);

            //通过xpath 选中指定元素；xpath 参考：http://www.w3school.com.cn/xpath/xpath_syntax.asp
            HtmlNodeCollection nodecollection = doc.DocumentNode.SelectNodes("//dd/a[@href]");


            foreach (var item in nodecollection)
            {
                chapters.Add(new Chapter()
                {
                    Name = item.InnerText,
                    Url = "http://www.xbiquge.la" + item.Attributes["href"].Value
                });
            }
        }

        /// <summary>
        /// 获取章节内容
        /// </summary>
        private void GetContent(string name)
        {
            Console.WriteLine($"共{chapters.Count}章");
            HttpHelper http = new HttpHelper();

            foreach (var chapter in chapters)
            {
                if (!string.IsNullOrWhiteSpace(chapter.Content)) continue;

                HttpItem httpItem = new HttpItem
                {
                    URL = chapter.Url
                };

                var result = http.GetHtml(httpItem);

                HtmlDocument doc = new HtmlDocument();

                doc.LoadHtml(result.Html);

                //通过xpath 选中指定元素；xpath 参考：http://www.w3school.com.cn/xpath/xpath_syntax.asp
                HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@id='content']");

                chapter.Content = FormatContent(node.InnerText);

                string path = Configs.MyDocuments + $"\\{name}.txt";
                var th = new TextHelper(path);
                th.Write(path, chapter.Name);
                th.Write(path, chapter.Content);

                Console.WriteLine($"{chapters.IndexOf(chapter) + 1}/{chapters.Count}" + chapter.Name);
                Console.WriteLine("");                
            }
        }

        public string FormatContent(string content)
        {
            content = content.Replace(" ", "");
            content = content.Replace("&nbsp;&nbsp;&nbsp;&nbsp;", "\n\t\n\t");

            return content;
        }
    }
}
