using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace WAW_CAT_Tranlsate_XLZ
{
    class RegexExpressions
    {

        static public string GetTagBeginning(string inputText, string tagName)
        {
            Regex regex = new Regex("<" + tagName + ".*?>");
            MatchCollection matches = regex.Matches(inputText);

            if (matches.Count == 1)
            {
                return matches[0].Value;
            }
            else
            {
                return "";
            }
        }

        static public string GetTagEnd(string inputText, string tagName)
        {
            Regex regex = new Regex("<//" + tagName + ".*?>");
            MatchCollection matches = regex.Matches(inputText);

            if (matches.Count == 1)
            {
                return matches[0].Value;
            }
            else
            {
                return "";
            }
        }

        static public string GetTextBetweenTags(string inputText, string tagName)
        {
            Regex regex = new Regex("<" + tagName + ".*?>(.*?)<//" + tagName + ".*?>");
            MatchCollection matches = regex.Matches(inputText);

            if (matches.Count == 1)
            {
                return matches[0].Groups[1].Value;
            }
            else
            {
                return "";
            }
        }



    }
}
