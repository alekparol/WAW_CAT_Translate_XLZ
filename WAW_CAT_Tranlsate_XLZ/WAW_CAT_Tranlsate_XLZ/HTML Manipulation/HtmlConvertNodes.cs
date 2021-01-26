using System.Linq;
using HtmlAgilityPack;
using System.Collections.Generic;
using static System.Web.HttpUtility;

namespace WAW_CAT_Tranlsate_XLZ
{
    public class HtmlConvertNodes
    {

        /* */


        /*
         * 
         */

        static public List<string> ConvertHtmlNodeListToStringList(List<HtmlNode> htmlNodeCollection, int conversionOption)
        {

            List<string> htmlNodeCollectionString = new List<string>();

            if (htmlNodeCollection != null)
            {
                foreach (HtmlNode htmlNode in htmlNodeCollection)
                {
                    switch (conversionOption)
                    {
                        case 1:
                            htmlNodeCollectionString.Add(HtmlDecode(htmlNode.OuterHtml));
                            break;
                        case 2:
                            htmlNodeCollectionString.Add(HtmlDecode(htmlNode.InnerHtml));
                            break;
                        case 3:
                            htmlNodeCollectionString.Add(HtmlDecode(htmlNode.InnerText));
                            break;
                    }

                }
            }

            return htmlNodeCollectionString;

        }

        /*
         * 
         */
        static public List<string> ConvertIEnumerableHtmlNodeToStringList(IEnumerable<HtmlNode> htmlNodeCollection, int conversionOption)
        {

            List<HtmlNode> htmlNodeList = htmlNodeCollection.ToList();
            return ConvertHtmlNodeListToStringList(htmlNodeList, conversionOption);

        }

    }
}
