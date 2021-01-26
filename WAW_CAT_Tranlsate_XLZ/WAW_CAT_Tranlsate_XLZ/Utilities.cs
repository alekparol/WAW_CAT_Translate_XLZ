using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using WAW_CAT_Tranlsate_XLZ;
using static WAW_CAT_Tranlsate_XLZ.XLZ_Manipulation;
using static WAW_CAT_Tranlsate_XLZ.XmlFindNodes;
using static WAW_CAT_Tranlsate_XLZ.HtmlSearchFile;
using System.Text;

namespace WAW_CAT_Tranlsate_XLZ
{
    public class Utilities
    {

        /* */

        static public List<string> GetListOfParentFolders(List<string> fileList)
        {
            List<string> listOfParentFolders = new List<string>();

            foreach (string file in fileList)
            {
                listOfParentFolders.Add(Directory.GetParent(file).Name);
            }

            listOfParentFolders = listOfParentFolders.Distinct().ToList();
            return listOfParentFolders;
        }


        static public void f4(List<string> xlzFiles, List<string> sourceFiles, List<string> targetFiles)
        {
            foreach (string xlzFile in xlzFiles)
            {
                f3(xlzFile, sourceFiles, targetFiles);
            }
        }

        static public string f3(string xlzFile, List<string> sourceFiles, List<string> targetFiles)
        {
            if (sourceFiles.Count > 0 && targetFiles.Count > 0)
            {
                string sourceFile = sourceFiles.Find(x => Path.GetFileName(x) == Path.GetFileName(xlzFile).Replace(".xlz",""));
                f2(xlzFile, sourceFile, targetFiles);

                return sourceFile;
            }

            return "";
        }

        static public void f2(string xlzFile, string sourceFile, List<string> targetFiles)
        {
            if (File.Exists(xlzFile) && File.Exists(sourceFile) && targetFiles.Count > 0)             
            {

                List<string> sourceUITM = SearchXmlFile(sourceFile);
                List<string> targetUITM = SearchCorrespondingXmlFile(sourceFile, targetFiles);

                for (int i = 0; i < sourceUITM.Count; i++)
                {

                    f1(xlzFile, sourceUITM[i], targetUITM[i]);

                }
            }
        }

        static public void f1(string xlzFile, string sourceString, string targetString)
        {

            if (File.Exists(xlzFile) && sourceString.Length > 0 && targetString.Length > 0)
            {

                XmlDocument xlfDocument = new XmlDocument();
                xlfDocument.LoadXml(XLZ_Manipulation.ReadContentXLF(xlzFile));

                XmlNodeList sourceNodes = XmlFindNodes.GetSourceNodesContaining(xlfDocument, sourceString);

                foreach (XmlNode sourceNode in sourceNodes)
                {
                    XmlNode targetNode = xlfDocument.CreateNode("element", "target", "");
                    targetNode.InnerXml = sourceNode.InnerXml.Replace(sourceString, targetString);

                    sourceNode.ParentNode.AppendChild(targetNode);
                }

                XLZ_Manipulation.UpdateContentXLF(xlzFile, xlfDocument.OuterXml);

            }
        }

        static public void f12(string xlzFile, string sourceString, string targetString)
        {

            if (File.Exists(xlzFile) && sourceString.Length > 0 && targetString.Length > 0)
            {

                XmlDocument xlfDocument = new XmlDocument();
                xlfDocument.LoadXml(XLZ_Manipulation.ReadContentXLF(xlzFile));

                XmlNodeList sourceNodes = xlfDocument.SelectNodes(@"//source[contains(.,'class=""ui') or contains(., 'class=""tm')]");

                foreach (XmlNode sourceNode in sourceNodes)
                {
                    XmlNode targetNode = xlfDocument.CreateNode("element", "target", "");
                    targetNode.InnerXml = sourceNode.InnerXml.Replace(sourceString, targetString);

                    sourceNode.ParentNode.AppendChild(targetNode);
                }

                XLZ_Manipulation.UpdateContentXLF(xlzFile, xlfDocument.OuterXml);

            }
        }


        static public void f10(string xlzFile, string sourceString, string targetString)
        {
            if (File.Exists(xlzFile) && sourceString.Length > 0 && targetString.Length > 0)
            {
                XmlDocument xlfDocument = new XmlDocument();
                xlfDocument.LoadXml(ReadContentXLF(xlzFile));

                XmlNodeList sourceNodes = xlfDocument.SelectNodes(@"//source[contains(.,'class=""ui') or contains(., 'class=""tm')]");

            }
        }

        static public string FindFileWithoutXLZExtension(string fileName, List<string> fileList)
        {

            List<string> foundFiles = fileList.FindAll((x => Path.GetFileName(x) == Path.GetFileName(fileName).Replace(".xlz", "")));


            if (foundFiles.Count > 0)
            {
                if (foundFiles.Count == 1)
                {
                    return foundFiles.ElementAt(0);
                }
                else
                {
                    throw new Exception(String.Format("There are mutliple files found."));
                }
            }
            else
            {
                return String.Empty;
            }

            /*if(Path.GetExtension(fileName) == ".xlz")
            {
                List<string> foundFiles = fileList.FindAll((x => Path.GetFileName(x) == Path.GetFileName(fileName).Replace(".xlz", "")));


                if (foundFiles.Count > 0)
                {
                    if (foundFiles.Count == 1)
                    {
                        return foundFiles.ElementAt(0);
                    }
                    else
                    {
                        throw new Exception(String.Format("There are mutliple files found."));
                    }
                }
                else
                {
                    return String.Empty;
                }
            }
            else
            {
                throw new Exception(String.Format("The file provided was not an XLZ."));
            }*/

        }


        /*
         *
         * XmlNode targetNode = GetTargetNode(sourceNode);
         * targetNode = ChangeTargetNode(targetNode, sourceString[i], targetString[i]);
         *
         */

        /* Method to get target node - empty if there is no target node yet and fill it with source innerXml and nonempty in the obvious case. It returns this node. */

        static public XmlNode GetTargetNode(XmlNode sourceNode)
        {

            if (sourceNode.Name == "source")
            {
                XmlNode targetNode = sourceNode.NextSibling;

                if (targetNode != null)
                {
                    if (targetNode.Name == "target")
                    {
                        if (targetNode.NextSibling == null)
                        {
                            return targetNode;
                        }
                        else
                        {
                            throw new Exception(String.Format("There are multiple target nodes in the node of a name {0} and content {1}", sourceNode.Name, sourceNode.InnerXml));
                        }
                    }
                    else
                    {
                        throw new Exception(String.Format("There is a sibling node of a name different than expected. Name {0}, content {1}", targetNode.Name, targetNode.InnerXml));
                    }
                }
                else
                {
                    XmlNode newTargetNode = sourceNode.OwnerDocument.CreateNode("element", "target", "");
                    newTargetNode.InnerXml = sourceNode.InnerXml;

                    sourceNode.ParentNode.AppendChild(newTargetNode);
                    return newTargetNode;
                }
            }
            else
            {
                return null;
            }

        }

        /* Method that will take 3 arguments - XmlNode target node, string sourceText, string targetText. And by searching witha Regex MatchCollection will assess if sourceText can be found between <bpt><ept> nodes. 
         * If yes it will be changed. 
         * 
         * Here is the regex: <bpt.*?>&lt;.*?class="ui.*?"&gt;<\/bpt.*?>[\W\w]*?<ept.*?>&lt;\/span&gt;<\/ept.*?>
         
         NOTE: We need innerTExt of source and target strings here! 
        
         Note: For now, as we have a lot of exceptions, we will go with a simples solution - just replacing sourceString with a targetString*/

        static public XmlNode ChangeTargetNode(XmlNode targetNode, string sourceString, string targetString)
        {
            if (targetNode.Name == "target")
            {

                targetNode.InnerXml = targetNode.InnerXml.Replace(sourceString, targetString);
                return targetNode;
            }
            else
            {
                return null;
            }

        }

        /* Methods changing all UI strings. */

        public static void UpdateUIStringsInFile(string xlzFile, XmlDocument xlfFile, List<string> sourceUI, List<string> targetUI)
        {
            for (int i = 0; i < sourceUI.Count; i++)
            {

                XmlNodeList sourceNodesXml = GetSourceNodesContaining(xlfFile, sourceUI[i]);

                foreach (XmlNode sourceNode in sourceNodesXml)
                {

                    XmlNode targetNode = GetTargetNode(sourceNode);
                    targetNode = ChangeTargetNode(targetNode, sourceUI[i], targetUI[i]);
                }

                UpdateContentXLF(xlzFile, xlfFile.OuterXml);
            }
        }


        /* Methods changing all UI strings. */

        public static void UpdateUIStringsInFileUsingFiles(string xlzFile, XmlDocument xlfFile, string sourceFile, string targetFile)
        {

            List<string> sourceUI = SearchHtmlForSpanNodesUi(sourceFile);
            List<string> targetUI = SearchHtmlForSpanNodesUi(targetFile);

            UpdateUIStringsInFile(xlzFile, xlfFile, sourceUI, targetUI);

        }

        public static void UpdateTMStringsInFileUsingFiles(string xlzFile, XmlDocument xlfFile, string sourceFile, string targetFile)
        {

            List<string> sourceTM = SearchHtmlForSpanNodesTm(sourceFile);
            List<string> targetTM = SearchHtmlForSpanNodesTm(targetFile);

            UpdateUIStringsInFile(xlzFile, xlfFile, sourceTM, targetTM);

        }

        /* Methods changing all UI strings. */

        public static void UpdateUIStringsInFileUsingFileLists(string xlzFile, XmlDocument xlfFile, List<string> sourceFiles, List<string> targetFiles)
        {

            string sourceFile = FindFileWithoutXLZExtension(xlzFile, sourceFiles);
            string targetFile = FindFileWithoutXLZExtension(xlzFile, targetFiles);

            UpdateUIStringsInFileUsingFiles(xlzFile, xlfFile, sourceFile, targetFile);

        }

        public static void UpdateTMStringsInFileUsingFileLists(string xlzFile, XmlDocument xlfFile, List<string> sourceFiles, List<string> targetFiles)
        {

            string sourceFile = FindFileWithoutXLZExtension(xlzFile, sourceFiles);
            string targetFile = FindFileWithoutXLZExtension(xlzFile, targetFiles);

            UpdateTMStringsInFileUsingFiles(xlzFile, xlfFile, sourceFile, targetFile);

        }


        /* Final Method */
        static public void G(List<string> xlzFiles, List<string> sourceFiles, List<string> targetFiles)
        {
            if (xlzFiles.Count > 0 && sourceFiles.Count > 0 && targetFiles.Count > 0)
            {
                foreach (string xlzFile in xlzFiles)
                {
                    XmlDocument xlfDocument = new XmlDocument();
                    xlfDocument.LoadXml(ReadContentXLF(xlzFile));

                    XmlNodeList sourceNodesUi = GetSourceNodesContainingUi(xlfDocument);

                    if (sourceNodesUi.Count > 0)
                    {
                        UpdateUIStringsInFileUsingFileLists(xlzFile, xlfDocument, sourceFiles, targetFiles);
                    }

                    XmlNodeList sourceNodesTm = GetSourceNodesContainingTm(xlfDocument);

                    if (sourceNodesTm.Count > 0)
                    {
                        UpdateTMStringsInFileUsingFileLists(xlzFile, xlfDocument, sourceFiles, targetFiles);
                    }

                }
            }
        }

    }
}