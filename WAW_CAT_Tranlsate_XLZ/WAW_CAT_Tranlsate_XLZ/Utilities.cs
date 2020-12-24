using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WAW_CAT_Tranlsate_XLZ
{
    public class Utilities
    {

        /* Below function run through the passed file and gets the list of all nodes which class contains "ui" or "tm" in the name. */

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


        /* Below Function firstly searches through the list of target files for the file with the same name as the input file and invokes SearchXmlFile on this file. */

        static public List<string> SearchCorrespondingXmlFile(string inputFile, List<string> targetFiles)
        {
            List<string> correspondingList = targetFiles.FindAll(x => Path.GetFileName(x) == Path.GetFileName(inputFile));

            return SearchXmlFile(correspondingList.ElementAt(0));
        }


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

        static public void SaveToCSV(List<string> sourceFiles, List<string> targetFiles, string path)
        {

            if (sourceFiles.Count > 0 && targetFiles.Count > 0)
            {
                string sourceFolderName = Directory.GetParent(sourceFiles.ElementAt(0)).Name;
                string targetFolderName = Directory.GetParent(targetFiles.ElementAt(0)).Name;

                path = Path.Combine(path, sourceFolderName.ToUpper() + "_" + targetFolderName.ToUpper() + "_" + "Combined_HTML.csv");

                using (StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    string[] headers = { sourceFolderName, targetFolderName };
                    string headline = String.Join("\t", headers);

                    streamWriter.WriteLine(headline);

                    foreach (string sourceFile in sourceFiles)
                    {
                        List<string> listOfSourceNodes = SearchXmlFile(sourceFile);
                        List<string> listOfTargeNodes = SearchCorrespondingXmlFile(sourceFile, targetFiles);

                        for (int i = 0; i < listOfSourceNodes.Count; i++)
                        {
                            if (listOfTargeNodes.ElementAt(i) != string.Empty)
                            {
                                string val1 = NormalizeForExcel(listOfSourceNodes.ElementAt(i));
                                string val2 = NormalizeForExcel(listOfTargeNodes.ElementAt(i));
                                string[] values = { val1, val2 };
                                string line = String.Join("\t", values);

                                streamWriter.WriteLine(line);
                            }
                        }
                    }

                    streamWriter.Flush();
                }

            }

        }

        static public void SaveMultipleLanguages(List<string> sourceFiles, List<string> targetFiles, string path)
        {
            if (sourceFiles.Count > 0 && targetFiles.Count > 0)
            {
                List<string> sourceFolderNames = GetListOfParentFolders(sourceFiles);
                List<string> targetFolderNames = GetListOfParentFolders(targetFiles);

                List<string> sourceFilesSubList = new List<string>();
                List<string> targetFilesSubList = new List<string>();

                foreach (string sourceFolderName in sourceFolderNames)
                {

                    sourceFilesSubList = sourceFiles.FindAll(x => Directory.GetParent(x).Name == sourceFolderName);

                    foreach (string targetFolderName in targetFolderNames)
                    {

                        targetFilesSubList = targetFiles.FindAll(x => Directory.GetParent(x).Name == targetFolderName);
                    }
                }
            }
        }
    }
}
