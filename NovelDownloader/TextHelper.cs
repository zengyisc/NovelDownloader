namespace NovelDownloader
{
    /// <summary>
    /// 本地文件读写
    /// </summary>
    public class TextHelper
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path"></param>
        public TextHelper(string path)
        {
            if (!System.IO.File.Exists(path))
            {

                using (System.IO.StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// 把内容写入文本
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public void Write(string path, string content)
        {
            System.IO.File.AppendAllText(path, content);
            System.IO.File.AppendAllText(path, "\n\t");
        }
    }
}
