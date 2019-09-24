using System;
using System.IO;

namespace NovelDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialization();

            Xbiquge xbiquge = new Xbiquge();

            xbiquge.Start("http://www.xbiquge.la/15/15409/", "牧神记");


            Console.WriteLine("");
            Console.ReadLine();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        static void Initialization()
        {
            try
            {
                if (!Directory.Exists(Configs.MyDocuments))
                {
                    Directory.CreateDirectory(Configs.MyDocuments);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("目录初始化失败");
                Console.WriteLine(ex);
            }
        }
    }
}
