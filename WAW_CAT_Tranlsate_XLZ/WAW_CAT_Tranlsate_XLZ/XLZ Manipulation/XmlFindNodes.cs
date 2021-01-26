using System.Linq;
using System.Xml;

namespace WAW_CAT_Tranlsate_XLZ
{
    public class XmlFindNodes
    {

        /*
         * 
         */
        static public XmlNodeList HtmlNodesByTagName(XmlDocument xmlDocument, string tagName)
        {
            XmlNodeList foundNodes = null;

            if (xmlDocument != null)
            {
                foundNodes = xmlDocument.GetElementsByTagName(tagName);
            }

            return foundNodes;
        }

        static public XmlNodeList GetTransUnitNodes(XmlDocument xmlDocument)
        {
            return HtmlNodesByTagName(xmlDocument, "trans-unit");
        }

        static public XmlNodeList GetSourceNodes(XmlDocument xmlDocument)
        {
            return HtmlNodesByTagName(xmlDocument, "source");
        }

        static public XmlNodeList GetTargetNodes(XmlDocument xmlDocument)
        {
            return HtmlNodesByTagName(xmlDocument, "target");
        }

        /*
         * 
         */
        static public XmlNodeList GetNodesContaining(XmlDocument xmlDocument, string tagName, string containedText)
        {
            XmlNodeList foundNodes = null;

            string limitedTagNameXPath = XPathExpressions.GetTagNameContainingTextXPath(tagName, containedText);

            if (xmlDocument != null)
            {
                foundNodes = xmlDocument.SelectNodes(limitedTagNameXPath);
            }

            return foundNodes;
        }

        static public XmlNodeList GetSourceNodesContaining(XmlDocument xmlDocument, string containedText)
        {
            return GetNodesContaining(xmlDocument, "source", containedText);
        }

        static public XmlNodeList GetTargetNodesContaining(XmlDocument xmlDocument, string containedText)
        {
            return GetNodesContaining(xmlDocument, "target", containedText);
        }

        static public XmlNodeList GetSourceNodesContainingUi(XmlDocument xmlDocument)
        {
            return GetNodesContaining(xmlDocument, "source", "class=\"ui");
        }

        static public XmlNodeList GetSourceNodesContainingTm(XmlDocument xmlDocument)
        {
            return GetNodesContaining(xmlDocument, "source", "class=\"tm");
        }

        static public XmlNodeList GetTargetNodesContainingUi(XmlDocument xmlDocument)
        {
            return GetNodesContaining(xmlDocument, "target", "class=\"ui");
        }

        static public XmlNodeList GetTargetNodesContainingTm(XmlDocument xmlDocument)
        {
            return GetNodesContaining(xmlDocument, "target", "class=\"tm");
        }


        /*
         * 
         */
        static public XmlNodeList GetTransUnitNodesContainingInSource(XmlDocument xmlDocument, string containedText)
        {
            XmlNodeList foundNodes = null;

            string limitedTagNameXPath = "//source" + "[contains(., \'" + containedText + "\')]/parent::trans-unit";

            if (xmlDocument != null)
            {
                foundNodes = xmlDocument.SelectNodes(limitedTagNameXPath);
            }

            return foundNodes;
        }

        /*
         * 
         */
        static public XmlNodeList GetTransUnitNodesContainingInTarget(XmlDocument xmlDocument, string containedText)
        {
            XmlNodeList foundNodes = null;

            string limitedTagNameXPath = "//target" + "[contains(., \'" + containedText + "\')]/parent::trans-unit";

            if (xmlDocument != null)
            {
                foundNodes = xmlDocument.SelectNodes(limitedTagNameXPath);
            }

            return foundNodes;
        }

        /*
         * 
         */
        static public void AppendTargetNode(XmlNode transUnitNode, XmlNode targetNode)
        {

        }
    }
}
