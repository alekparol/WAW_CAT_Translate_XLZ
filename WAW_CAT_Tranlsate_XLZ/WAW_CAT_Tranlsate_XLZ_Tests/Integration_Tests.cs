using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using static WAW_CAT_Tranlsate_XLZ.XmlFindNodes;
using static WAW_CAT_Tranlsate_XLZ.HtmlSearchFile;
using static WAW_CAT_Tranlsate_XLZ.XLZ_Manipulation;
using static WAW_CAT_Tranlsate_XLZ.Utilities;
using System.Xml;
using System;
using System.Text;

namespace WAW_CAT_Tranlsate_XLZ_Tests
{
    [TestClass]
    public class Integration_Tests
    {

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\TestXLZ\UG-00_Before_0090.html.xlz", 0, "Canon : Product Manual : EOS M50 Mark II : Part Names")]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\TestXLZ\UG-00_Before_0090.html.xlz", 1, "Canon")]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\TestXLZ\UG-00_Before_0090.html.xlz", 3, "fffffffffffffffffff ")]
        [DataTestMethod]
        public void Integration_Tests_GetTargetNode(string inputFile, int nodeNumber, string targetInnerXml)
        {


            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodes = xlfDocument.SelectNodes("//trans-unit[@translate='yes']/source");

            XmlNode targetNode = GetTargetNode(sourceNodes.Item(nodeNumber));
            Assert.AreEqual(targetInnerXml, targetNode.InnerXml);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\TestXLZ\UG-00_Before_0090.html.xlz", 4)]
        [DataTestMethod]
        public void Integration_Tests_GetTargetNodeExceptions(string inputFile, int nodeNumber)
        {


            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            Exception expectedExeption = null;
            XmlNodeList sourceNodes = xlfDocument.SelectNodes("//trans-unit[@translate='yes']/source");

            try
            {
                XmlNode targetNode = GetTargetNode(sourceNodes.Item(nodeNumber));
            }
            catch (Exception ex)
            {
                expectedExeption = ex;
            }

            Assert.IsNotNull(expectedExeption);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\TestXLZ\UG-00_Before_0080.html.xlz", 0, "Handling", "test translation")]
        [DataTestMethod]
        public void Integration_Tests_ChangeTargetNode(string inputFile, int nodeNumber, string replacableString, string replaceString)
        {


            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            XmlNodeList sourceNodes = xlfDocument.SelectNodes("//trans-unit[@translate='yes']/source");
            XmlNode targetNode = GetTargetNode(sourceNodes.Item(nodeNumber));

            string expectedOutcome = targetNode.InnerXml;
            targetNode = ChangeTargetNode(targetNode, replacableString, replaceString);

            Assert.AreEqual(expectedOutcome.Replace(replacableString, replaceString), targetNode.InnerXml);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\TestXLZ\UG-00_Before_0090.html.xlz", @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0090.html", @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\02_Target\pl-pl\UG-00_Before_0090.html")]
        [DataTestMethod]
        public void Integration_Tests_UpdateUIStrings(string inputFile, string sourceFile, string targetFile)
        {


            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            List<string> sourceUI = SearchHtmlForSpanNodesUi(sourceFile);
            List<string> targetUI = SearchHtmlForSpanNodesUi(targetFile);

            XmlNodeList sourceNodesXml = GetSourceNodesContaining(xlfDocument, sourceUI[0]);
            Assert.AreEqual(0, sourceNodesXml.Count);

            XmlNode targetNode = GetTargetNode(sourceNodesXml.Item(0));
            targetNode = ChangeTargetNode(targetNode, sourceUI[0], targetUI[0]);

            UpdateContentXLF(inputFile, xlfDocument.OuterXml);

            //Assert.AreEqual(0, sourceUI.Count);
            //Assert.AreEqual(0, targetUI.Count);

            //Assert.AreEqual("", sourceUI.ElementAt(0));
            //Assert.AreEqual("", targetUI.ElementAt(0));

            //XmlNodeList sourceNodes = xlfDocument.SelectNodes("//trans-unit[@translate='yes']/source");
            //XmlNode targetNode = GetTargetNode(sourceNodes.Item(nodeNumber));

            //UpdateUIStringsInFile(inputFile, xlfDocument, sourceUI, targetUI);

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\TestXLZ\UG-02_BasicShooting_0170.html.xlz", @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0170.html", @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\02_Target\pl-pl\UG-02_BasicShooting_0170.html")]
        [DataTestMethod]
        public void Integration_Tests_UpdateUIStrings2(string inputFile, string sourceFile, string targetFile)
        {


            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(ReadContentXLF(inputFile));

            List<string> sourceUI = SearchHtmlForSpanNodesUi(sourceFile);
            List<string> targetUI = SearchHtmlForSpanNodesUi(targetFile);

            XmlNodeList sourceNodesXml = GetSourceNodesContaining(xlfDocument, sourceUI[0]);
            //Assert.AreEqual(0, sourceNodesXml.Count);

            byte[] utf8Byte = Encoding.UTF8.GetBytes(targetUI[0]);
            string utf8New = Encoding.UTF8.GetString(utf8Byte);

            Assert.AreEqual("", utf8New);

            XmlNode targetNode = GetTargetNode(sourceNodesXml.Item(0));
            targetNode = ChangeTargetNode(targetNode, sourceUI[0], targetUI[0]);

            UpdateContentXLF(inputFile, xlfDocument.OuterXml);

            //Assert.AreEqual(0, sourceUI.Count);
            //Assert.AreEqual(0, targetUI.Count);

            //Assert.AreEqual("", sourceUI.ElementAt(0));
            //Assert.AreEqual("", targetUI.ElementAt(0));

            //XmlNodeList sourceNodes = xlfDocument.SelectNodes("//trans-unit[@translate='yes']/source");
            //XmlNode targetNode = GetTargetNode(sourceNodes.Item(nodeNumber));

            //UpdateUIStringsInFile(inputFile, xlfDocument, sourceUI, targetUI);

        }

        /* Update XLZ file with a given value */
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0090.html.xlz", "Scene Intelligent Auto", "śćżłó", 0)]
        [DataTestMethod]
        public void Integration_Tests_GetTargetNode2(string inputFile, string sourceString, string targetString, int expectedOutcome)
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

    }
}
