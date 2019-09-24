using System;
using System.Collections.Generic;
using System.Text;

namespace NovelDownloader.Models
{
    public class Chapter
    {
        /// <summary>
        /// 章节名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 章节地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
