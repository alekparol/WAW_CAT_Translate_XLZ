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
    public class XPathExpressions
    {

        static public string NormalizeXPath(string xpathExpression)
        {
            return xpathExpression.Replace("'", "&apos;");
        }

        static public string GetTagNameXPath(string tagName)
        {
            return "//" + NormalizeXPath(tagName);
        }

        static public string GetTagNameContainingXPath(string tagName, string containingAttribute, string containingValue)
        {
            return GetTagNameXPath(tagName) +
                   "[contains(@" + NormalizeXPath(containingAttribute) + ", \'"
                                 + NormalizeXPath(containingValue) + "\')]";
        }

        static public string GetTagNameContainingTextXPath(string tagName, string containingValue)
        {
            return GetTagNameXPath(tagName) + "[contains(., \'" 
                                            + NormalizeXPath(containingValue) + "\')]";
        }

    }
}
