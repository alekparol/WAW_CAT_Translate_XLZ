using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using static WAW_CAT_Tranlsate_XLZ.XmlFindNodes;
using static WAW_CAT_Tranlsate_XLZ.XLZ_Manipulation;
using System.Xml;

namespace WAW_CAT_Tranlsate_XLZ_Tests
{
    [TestClass]
    public class XmlFindNodes_Tests
    {

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "trans-unit", 230)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "source", 230)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "target", 32)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "bpt", 239)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "ept", 168)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "ph", 17)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "it", 0)]
        [DataTestMethod]
        public void HtmlFindNodes_HtmlNodesByTagName(string inputFile, string tagName, int expectedOutcome)
        {

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodes = HtmlNodesByTagName(xlfDocument, tagName);

            Assert.AreEqual(expectedOutcome, sourceNodes.Count);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", 230)]
        [DataTestMethod]
        public void HtmlFindNodes_GetTransUnitNodes(string inputFile, int expectedOutcome)
        {

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodes = GetTransUnitNodes(xlfDocument);

            Assert.AreEqual(expectedOutcome, sourceNodes.Count);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", 230)]
        [DataTestMethod]
        public void HtmlFindNodes_GetSourceNodes(string inputFile, int expectedOutcome)
        {

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodes = GetSourceNodes(xlfDocument);

            Assert.AreEqual(expectedOutcome, sourceNodes.Count);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", 32)]
        [DataTestMethod]
        public void HtmlFindNodes_GetTargetNodes(string inputFile, int expectedOutcome)
        {

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodes = GetTargetNodes(xlfDocument);

            Assert.AreEqual(expectedOutcome, sourceNodes.Count);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "ph", "Global site tag", 1)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "ph", "", 17)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "source", "Canon", 2)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "target", "portret", 2)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "bpt", "&lt;a href", 0)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "bpt", "<a href", 5)]
        [DataTestMethod]
        public void HtmlFindNodes_GetNodesContaining(string inputFile, string tagName, string containedText, int expectedOutcome)
        {

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodes = GetNodesContaining(xlfDocument, tagName, containedText);

            Assert.AreEqual(expectedOutcome, sourceNodes.Count);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "Global site tag", 1)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "", 230)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "Canon", 2)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "portret", 0)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "&lt;a href", 0)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "<a href", 5)]
        [DataTestMethod]
        public void HtmlFindNodes_GetSourceNodesContaining(string inputFile, string containedText, int expectedOutcome)
        {

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodes = GetSourceNodesContaining(xlfDocument, containedText);

            Assert.AreEqual(expectedOutcome, sourceNodes.Count);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "Global site tag", 0)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "", 32)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "Canon", 0)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "portret", 2)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "&lt;a href", 0)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "<a href", 0)]
        [DataTestMethod]
        public void HtmlFindNodes_GetTargetNodesContaining(string inputFile, string containedText, int expectedOutcome)
        {

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList targetNodes = GetTargetNodesContaining(xlfDocument, containedText);

            Assert.AreEqual(expectedOutcome, targetNodes.Count);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "Scene Intelligent Auto", "śćżłó", 0)]
        [DataTestMethod]
        public void HtmlFindNodes_Integration(string inputFile, string sourceString, string targetString, int expectedOutcome)
        {

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodesUI = GetSourceNodesContainingUi(xlfDocument);
            XmlNodeList sourceNodesTM = GetSourceNodesContainingTm(xlfDocument);

            foreach (XmlNode sourceNode in sourceNodesUI)
            {
                XmlNode targetNode = xlfDocument.CreateNode("element", "target", "");
                targetNode.InnerXml = sourceNode.InnerXml.Replace(sourceString, targetString);

                sourceNode.ParentNode.AppendChild(targetNode);

                Assert.AreEqual("", targetNode.InnerXml);
            }

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "source", 3)]
        [DataTestMethod]
        public void HtmlFindNodes_HtmlNodesByTagNameContaining(string inputFile, string tagName, int expectedOutcome)
        {

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodes = GetNodesContaining(xlfDocument, tagName, "class=\"ui");
            XmlNodeList sourceNodes2 = GetNodesContaining(xlfDocument, tagName, "class=\"tm");

            Assert.AreEqual(expectedOutcome, sourceNodes.Count);

        }

    }
}
