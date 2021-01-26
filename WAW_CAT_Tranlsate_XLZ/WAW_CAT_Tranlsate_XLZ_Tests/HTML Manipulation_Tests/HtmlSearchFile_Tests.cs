using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using static WAW_CAT_Tranlsate_XLZ.HtmlSearchFile;

namespace WAW_CAT_Tranlsate_XLZ_Tests
{
    [TestClass]
    public class HtmlSearchFile_Tests
    {

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0020.html", "span", 44)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "div", 15)]
        [DataTestMethod]
        public void HtmlSearchFile_SearchHtmlForNodesByTagName(string inputFile, string tagName, int expectedOutcome)
        {

            List<string> foundNodeContent = SearchHtmlForNodesByTagName(inputFile, tagName);

            Assert.AreEqual(expectedOutcome, foundNodeContent.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0020.html", 44)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", 5)]
        [DataTestMethod]
        public void HtmlSearchFile_SearchHtmlForSpanNodes(string inputFile, int expectedOutcome)
        {

            List<string> foundNodeContent = SearchHtmlForSpanNodes(inputFile);

            Assert.AreEqual(expectedOutcome, foundNodeContent.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "div", "class", "header", 2)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "*", "class", "search", 9)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "button", "type", "button", 1)]
        [DataTestMethod]
        public void HtmlSearchFile_SearchHtmlForNodesByTagNameContainingInAttributeValue(string inputFile, string tagName, string attributeName, string containedText, int expectedOutcome)
        {

            List<string> foundNodeContent = SearchHtmlForNodesByTagNameContainingInAttributeValue(inputFile, tagName, attributeName, containedText);

            Assert.AreEqual(expectedOutcome, foundNodeContent.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "div", "figure", 3)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0030.html", "img", "print", 2)]
        [DataTestMethod]
        public void HtmlSearchFile_HtmlNodesByTagNameContainingInClass(string inputFile, string tagName, string containedText, int expectedOutcome)
        {

            List<string> foundNodeContent = SearchHtmlForNodesByTagNameContainingInClass(inputFile, tagName, containedText);

            Assert.AreEqual(expectedOutcome, foundNodeContent.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-01_Preparations_0090.html", 14)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-01_Preparations_0090.html", 14)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0020.html", 15)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-02_BasicShooting_0020.html", 15)]
        [DataTestMethod]
        public void HtmlSearchFile_SearchHtmlForSpanNodesUi(string inputFile, int expectedOutcome)
        {

            List<string> foundNodeContent = SearchHtmlForSpanNodesUi(inputFile);

            Assert.AreEqual(expectedOutcome, foundNodeContent.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0090.html", 27)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-00_Before_0090.html", 27)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0040.html", 12)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-02_BasicShooting_0040.html", 12)]
        [DataTestMethod]
        public void HtmlSearchFile_SearchHtmlForSpanNodesTm(string inputFile, int expectedOutcome)
        {

            List<string> foundNodeContent = SearchHtmlForSpanNodesTm(inputFile);

            Assert.AreEqual(expectedOutcome, foundNodeContent.Count());

        }

        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-00_Before_0090.html", 30)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-00_Before_0090.html", 30)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\01_Src\en-us\UG-02_BasicShooting_0040.html", 15)]
        [DataRow(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Scripts\WAW CAT HTML Script\\02_Target\da-dk\UG-02_BasicShooting_0040.html", 15)]
        [DataTestMethod]
        public void HtmlSearchFile_SearchHtmlForSpanNodesUiTm(string inputFile, int expectedOutcome)
        {

            List<string> foundNodeContent = SearchHtmlForSpanNodesUiTm(inputFile);

            Assert.AreEqual(expectedOutcome, foundNodeContent.Count());

        }

    }
}
