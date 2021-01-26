using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using static WAW_CAT_Tranlsate_XLZ.HtmlFindNodes;

namespace WAW_CAT_Tranlsate_XLZ_Tests
{
    [TestClass]
    public class HtmlFindNodes_Tests
    {
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0020.html", "span", 44)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "div", 15)]
        [DataTestMethod]
        public void HtmlFindNodes_HtmlNodesByTagName(string inputFile, string tagName, int expectedOutcome)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile);

            IEnumerable<HtmlNode> nodesFoundByTagName = HtmlNodesByTagName(htmlDocument, tagName);

            Assert.AreEqual(expectedOutcome, nodesFoundByTagName.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0020.html", 44)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", 5)]
        [DataTestMethod]
        public void HtmlFindNodes_GetSpanNodes(string inputFile, int expectedOutcome)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile);

            IEnumerable<HtmlNode> nodesFoundByTagName = GetSpanNodes(htmlDocument);

            Assert.AreEqual(expectedOutcome, nodesFoundByTagName.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "div", "class", "header", 2)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "*", "class", "search", 9)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "button", "type", "button", 1)]
        [DataTestMethod]
        public void HtmlFindNodes_HtmlNodesByTagNameContainingInAttributeValue(string inputFile, string tagName, string attributeName, string containedText, int expectedOutcome)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile);

            IEnumerable<HtmlNode> nodesFoundByTagName = HtmlNodesByTagNameContainingInAttributeValue(htmlDocument, tagName, attributeName, containedText);

            Assert.AreEqual(expectedOutcome, nodesFoundByTagName.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "div", "figure", 3)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "img", "print", 2)]
        [DataTestMethod]
        public void HtmlFindNodes_HtmlNodesByTagNameContainingInClass(string inputFile, string tagName, string containedText, int expectedOutcome)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile);

            IEnumerable<HtmlNode> nodesFoundByTagName = HtmlNodesByTagNameContainingInClass(htmlDocument, tagName, containedText);

            Assert.AreEqual(expectedOutcome, nodesFoundByTagName.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-01_Preparations_0090.html", 14)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-01_Preparations_0090.html", 14)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0020.html", 15)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-02_BasicShooting_0020.html", 15)]
        [DataTestMethod]
        public void HtmlFindNodes_GetSpanNodesUi(string inputFile, int expectedOutcome)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile);

            IEnumerable<HtmlNode> nodesFoundByTagName = GetSpanNodesUi(htmlDocument);

            Assert.AreEqual(expectedOutcome, nodesFoundByTagName.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0090.html", 27)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-00_Before_0090.html", 27)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0040.html", 12)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-02_BasicShooting_0040.html", 12)]
        [DataTestMethod]
        public void HtmlFindNodes_GetSpanNodesTm(string inputFile, int expectedOutcome)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile);

            IEnumerable<HtmlNode> nodesFoundByTagName = GetSpanNodesTm(htmlDocument);

            Assert.AreEqual(expectedOutcome, nodesFoundByTagName.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0090.html", 30)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-00_Before_0090.html", 30)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0040.html", 15)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-02_BasicShooting_0040.html", 15)]
        [DataTestMethod]
        public void HtmlFindNodes_GetSpanNodesUiTm(string inputFile, int expectedOutcome)
        {

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(inputFile);

            IEnumerable<HtmlNode> nodesFoundByTagName = GetSpanNodesUiTm(htmlDocument);

            Assert.AreEqual(expectedOutcome, nodesFoundByTagName.Count());

        }
    }
}
