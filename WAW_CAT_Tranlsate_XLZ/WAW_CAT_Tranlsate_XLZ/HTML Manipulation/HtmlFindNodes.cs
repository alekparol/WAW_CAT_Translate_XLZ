using System.Linq;
using HtmlAgilityPack;
using System.Collections.Generic;
using static WAW_CAT_Tranlsate_XLZ.XPathExpressions;

/*
 * This class simplyfies finding specific nodes in HTML file. It 
 * 
 * It uses a class containing XPath expressions.
 *
 */

namespace WAW_CAT_Tranlsate_XLZ
{
    public class HtmlFindNodes
    {

        /* The method gets the IEnumerable list of all HtmlNode elements in the source document, which are of a tag name specified by the argument.
         * It takes two arguments:
         * 1) HtmlDocument htmlDocument which is the document on which it works;
         * 2) string tagName which is contains the information about name of the nodes to be searched.
         * 
         * HtmlNodesByTagName() as a function works very similar to the XmlDocument method GetElementsByTagName(), but here we are using a normalized version of a tag name - version in which apostrophes are 
         * replaced by xml entities, as C# does support only XPath 1.0. 
         * 
         */
        static public IEnumerable<HtmlNode> HtmlNodesByTagName(HtmlDocument htmlDocument, string tagName)
        {

            IEnumerable<HtmlNode> foundHtmlNodes = null;

            if (htmlDocument != null)
            { 
                foundHtmlNodes = htmlDocument.DocumentNode.SelectNodes(GetTagNameXPath(tagName));
            }

            return foundHtmlNodes;
        }

        /* The method gets the IEnumerable list of all HtmlNode elements in the source document, which are of a span tag name.
         * It takes one argument:
         * 1) HtmlDocument htmlDocument which is the document on which it works;
         * 
         * HtmlSpanNodes() as a function is built-up on HtmlNodesByTagName, where tag name is just specified. 
         * 
         */
        static public IEnumerable<HtmlNode> HtmlSpanNodes(HtmlDocument htmlDocument)
        { 
               return HtmlNodesByTagName(htmlDocument, "span");
        }


        /*
         * 
         */
        static public IEnumerable<HtmlNode> HtmlNodesByTagNameContainingInAttributeValue(HtmlDocument htmlDocument, string tagName, string attributeName, string textContained)
        {

            IEnumerable<HtmlNode> foundHtmlNodes = null;

            if (htmlDocument != null)
            {
                foundHtmlNodes = HtmlNodesByTagName(htmlDocument, tagName).
                                 Where(x => x.GetAttributeValue(attributeName, "").Contains(textContained));
            }

            return foundHtmlNodes;
        }

        /*
         * 
         */
        static public IEnumerable<HtmlNode> HtmlNodesByTagNameContainingInClass(HtmlDocument htmlDocument, string tagName, string textContained)
        {
            return HtmlNodesByTagNameContainingInAttributeValue(htmlDocument, tagName, "class", textContained);
        }


        /*
         *
         */
        static public IEnumerable<HtmlNode> HtmlSpanNodesUi(HtmlDocument htmlDocument)
        {
            return HtmlNodesByTagNameContainingInClass(htmlDocument, "span", "ui");
        }

       /*
        *
        */
        static public IEnumerable<HtmlNode> HtmlSpanNodesTm(HtmlDocument htmlDocument)
        {
            return HtmlNodesByTagNameContainingInClass(htmlDocument, "span", "tm");
        }


        static public IEnumerable<HtmlNode> HtmlSpanNodesUiTm(HtmlDocument htmlDocument)
        {
            return HtmlSpanNodesUi(htmlDocument).Concat(HtmlSpanNodesTm(htmlDocument));
        }
    }
}
