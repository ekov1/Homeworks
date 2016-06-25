using System;

namespace _05.ParseTags
{
    class Program
    {
        static void Main()
        {
            string main = Console.ReadLine();
            ParsingTags(main);
        }

        static void ParsingTags(string main)
        {
            string startTag = "<upcase>";
            string endTag = "</upcase>";
            for (int i = 0; i < main.Length; i++)
            {
                int start = main.IndexOf(startTag, i);
                if (start < 0)
                {
                    break;
                }
                int end = main.IndexOf(endTag, start + 1);
                if (end < 0)
                {
                    break;
                }
                string content = main.Substring(start + 8, end - start - 8);
                string tagAndCont = startTag + content + endTag;
                main = main.Replace(tagAndCont, tagAndCont.ToUpper());
                content = "";
                if (end + 1 < main.Length)
                {
                    i = end;
                }
            }
            main = main.Replace("<UPCASE>", "");
            main = main.Replace("</UPCASE>", "");

            Console.WriteLine(main);
        }
    }
}
