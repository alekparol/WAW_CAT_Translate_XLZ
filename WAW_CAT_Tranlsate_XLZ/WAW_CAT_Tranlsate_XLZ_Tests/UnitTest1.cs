using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using WAW_CAT_Tranlsate_XLZ;
using HtmlAgilityPack;

namespace WAW_CAT_Tranlsate_XLZ_Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
            /*string sourceFile = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html";
            string xlzFile = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0030.html.xlz";

            List<string> sourceUITM = HTML_ChangingNodes.SearchXmlFile(sourceFile);

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(XLZ_Manipulation.ReadContentXLF(xlzFile));

            XmlNodeList sourceNodes = XML_ChangingNodes.GetSourceNodesContaining(xlfDocument, sourceUITM.ElementAt(0));

            Assert.AreEqual("", sourceNodes.Item(0).InnerXml);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string sourceFile = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html";
            List<string> targetFiles = Directory.GetFiles(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\02_Target\da-dk").ToList();
            string xlzFile = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0030.html.xlz";

            List<string> sourceUITM = HTML_ChangingNodes.SearchXmlFile(sourceFile);
            List<string> targetUITM = HTML_ChangingNodes.SearchCorrespondingXmlFile(sourceFile, targetFiles);

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(XLZ_Manipulation.ReadContentXLF(xlzFile));

            XmlNodeList sourceNodes = XML_ChangingNodes.GetSourceNodesContaining(xlfDocument, sourceUITM.ElementAt(0));

            XmlNode targetNode = xlfDocument.CreateNode("element", "target", "");
            targetNode.InnerXml = sourceNodes.Item(0).InnerXml.Replace(sourceUITM.ElementAt(0), targetUITM.ElementAt(0));

            Assert.AreEqual("", targetNode.InnerXml);

        }

        [TestMethod]
        public void TestMethod3()
        {
            string sourceFile = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0020.html";
            List<string> targetFiles = Directory.GetFiles(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\02_Target\da-dk").ToList();
            string xlzFile = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-02_BasicShooting_0020.html.xlz";

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(sourceFile);

            List<string> sourceUITM = HTML_ChangingNodes.ConvertIEnumerableHtmlNodeToStringList(HTML_ChangingNodes.GetSpanNodesUi(htmlDocument), 1);
            //List<string> targetUITM = HTML_ChangingNodes.SearchCorrespondingXmlFile(sourceFile, targetFiles);

            //Assert.AreEqual(0, sourceUITM.Count);
            //Assert.AreEqual("", sourceUITM.ElementAt(0));

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.LoadXml(XLZ_Manipulation.ReadContentXLF(xlzFile));

            Regex regex = new Regex("<span.*?>");
            Match match = regex.Match(sourceUITM.ElementAt(0));

            XmlNodeList sourceNodes = XML_ChangingNodes.GetSourceNodesContaining(xlfDocument, match.Value);

            //XmlNode targetNode = xlfDocument.CreateNode("element", "target", "");
            //targetNode.InnerXml = sourceNodes.Item(0).InnerXml.Replace(sourceUITM.ElementAt(0), targetUITM.ElementAt(0));

            Assert.AreEqual("", sourceNodes.Item(0).InnerXml);

        }

        [TestMethod]
        public void TestMethodx()
        {

            string sourceFile = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html";
            List<string> targetFiles = Directory.GetFiles(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\02_Target\da-dk").ToList();
            string correspondingXlzFile = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\03_XLZ\UG-00_Before_0030.html.xlz";
            //List<string> listOfSourceNodes = Utilities.SearchXmlFile(sourceFile);
            //List<string> listOfTargeNodes = Utilities.SearchCorrespondingXmlFile(sourceFile, targetFiles);

            //Utilities.f1(correspondingXlzFile, listOfSourceNodes.ElementAt(0), listOfTargeNodes.ElementAt(0));*/

           
       // }
    }
}
