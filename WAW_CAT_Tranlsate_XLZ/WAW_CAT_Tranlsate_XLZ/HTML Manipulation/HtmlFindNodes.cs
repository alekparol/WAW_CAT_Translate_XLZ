using System.Linq;
using HtmlAgilityPack;
using System.Collections.Generic;
using static WAW_CAT_Tranlsate_XLZ.XPathExpressions;

/*
 * This class simplyfies finding specific nodes in HTML file. It 
 *
 */

namespace WAW_CAT_Tranlsate_XLZ
{
    public class HtmlFindNodes
    {

        /* */

        /*
         * 
         */
        static public IEnumerable<HtmlNode> GetNodesByTagName(HtmlDocument htmlDocument, string tagName)
        {

            IEnumerable<HtmlNode> foundHtmlNodes = null;

            if (htmlDocument != null)
            {
                foundHtmlNodes = htmlDocument.DocumentNode.SelectNodes(GetTagNameXPath(tagName));
            }

            return foundHtmlNodes;
        }

        /*
         * 
         */
        static public IEnumerable<HtmlNode> GetSpanNodes(HtmlDocument htmlDocument)
        { 
               return GetNodesByTagName(htmlDocument, "span");
        }


        /*
         * 
         */
        static public IEnumerable<HtmlNode> GetNodesByTagNameContainingInAttributeValue(HtmlDocument htmlDocument, string tagName, string attributeName, string textContained)
        {

            IEnumerable<HtmlNode> foundHtmlNodes = null;

            if (htmlDocument != null)
            {
                foundHtmlNodes = GetNodesByTagName(htmlDocument, tagName).
                                 Where(x => x.GetAttributeValue(attributeName, "").Contains(textContained));
            }

            return foundHtmlNodes;
        }

        /*
         * 
         */
        static public IEnumerable<HtmlNode> GetNodesByTagNameContainingInClass(HtmlDocument htmlDocument, string tagName, string textContained)
        {
            return GetNodesByTagNameContainingInAttributeValue(htmlDocument, tagName, "class", textContained);
        }


        /*
         *
         */
        static public IEnumerable<HtmlNode> GetSpanNodesUi(HtmlDocument htmlDocument)
        {
            return GetNodesByTagNameContainingInClass(htmlDocument, "span", "ui");
        }

       /*
        *
        */
        static public IEnumerable<HtmlNode> GetSpanNodesTm(HtmlDocument htmlDocument)
        {
            return GetNodesByTagNameContainingInClass(htmlDocument, "span", "tm");
        }


        static public IEnumerable<HtmlNode> GetSpanNodesUiTm(HtmlDocument htmlDocument)
        {
            return GetSpanNodesUi(htmlDocument).Concat(GetSpanNodesTm(htmlDocument));
        }
    }
}
