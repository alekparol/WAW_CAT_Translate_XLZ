using System.Linq;
using HtmlAgilityPack;
using System.Collections.Generic;
using static WAW_CAT_Tranlsate_XLZ.HtmlConvertNodes;
using static WAW_CAT_Tranlsate_XLZ.HtmlFindNodes;
using System.IO;
using System.Web;
using System.Text;



namespace WAW_CAT_Tranlsate_XLZ
{
    public class HtmlSearchFile
    {

        /*
         *
         */
        static public List<string> SearchHtmlForNodesByTagName(string inputFile, string tagName)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile);

            IEnumerable<HtmlNode> foundNodes = HtmlNodesByTagName(htmlDocument, tagName);
            List<string> listOfStringNodes = ConvertIEnumerableHtmlNodeToStringList(foundNodes, 3);

            return listOfStringNodes;

        }

        /*
         *
         */
        static public List<string> SearchHtmlForSpanNodes(string inputFile)
        {
            return SearchHtmlForNodesByTagName(inputFile, "span");
        }

        /*
         *
         */
        static public List<string> SearchHtmlForNodesByTagNameContainingInAttributeValue(string inputFile, string tagName, string attributeName, string textContained)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile, Encoding.UTF8);

            IEnumerable<HtmlNode> foundNodes = HtmlNodesByTagNameContainingInAttributeValue(htmlDocument, tagName, attributeName, textContained);
            List<string> listOfStringNodes = ConvertIEnumerableHtmlNodeToStringList(foundNodes, 3);

            return listOfStringNodes;

        }

        /*
         *
         */
        static public List<string> SearchHtmlForNodesByTagNameContainingInClass(string inputFile, string tagName, string textContained)
        {
            return SearchHtmlForNodesByTagNameContainingInAttributeValue(inputFile, tagName, "class", textContained);
        }

        /*
         *
         */
        static public List<string> SearchHtmlForSpanNodesUi(string inputFile)
        {
            return SearchHtmlForNodesByTagNameContainingInAttributeValue(inputFile, "span", "class", "ui");
        }

        /*
         *
         */
        static public List<string> SearchHtmlForSpanNodesTm(string inputFile)
        {
            return SearchHtmlForNodesByTagNameContainingInAttributeValue(inputFile, "span", "class", "tm");
        }

        /*
         *
         */
        static public List<string> SearchHtmlForSpanNodesUiTm(string inputFile)
        {

            List<string> foundUiNodes = SearchHtmlForSpanNodesUi(inputFile);
            foundUiNodes.AddRange(SearchHtmlForSpanNodesTm(inputFile));

            return foundUiNodes;

        }


        /*
         *
         */
        static public List<string> SearchCorrespondingXmlFile(string inputFile, List<string> targetFiles)
        {
            List<string> correspondingList = targetFiles.FindAll(x => Path.GetFileName(x) == Path.GetFileName(inputFile));

            return SearchXmlFile(correspondingList.ElementAt(0));
        }

        /*static public List<string> SearchHtmlForNodesContainingInClass(string inputFile, string tagName, string textContained)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile);

            IEnumerable<HtmlNode> foundNodes = HtmlNodesByTagNameContainingInClass(htmlDocument, tagName, textContained);
            List<string> listOfStringNodes = ConvertIEnumerableHtmlNodeToStringList(foundNodes, 1);

            return listOfStringNodes;

        }*/

        /*
         *
         */
        /*static public List<string> SearchHtmlForNodesContainingInClasses(string inputFile, string tagName, List<string> textContainedList)
        {

            List<string> listOfStringNodes = new List<string>();

            foreach (string textContained in textContainedList)
            {
                listOfStringNodes.AddRange(SearchHtmlForNodesContainingInClass(inputFile, tagName, textContained));
            }

            return listOfStringNodes;

        }*/
        /*
         *
         */
        static public List<string> SearchXmlFile(string inputFile)
        {

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(inputFile);

            List<string> listOfStringNodes = new List<string>();

            HtmlNodeCollection uiClassNodes = htmlDoc.DocumentNode.SelectNodes("//span[contains(@class,\"ui\")]");
            HtmlNodeCollection tmClassNodes = htmlDoc.DocumentNode.SelectNodes("//span[contains(@class,\"tm\")]");

            if (uiClassNodes != null)
            {
                foreach (HtmlNode uiNode in uiClassNodes)
                {
                    listOfStringNodes.Add(HttpUtility.HtmlDecode(uiNode.InnerText));
                }
            }


            if (tmClassNodes != null)
            {
                foreach (HtmlNode tmNode in tmClassNodes)
                {
                    listOfStringNodes.Add(tmNode.InnerText);
                }
            }

            return listOfStringNodes;

        }
    }
}
