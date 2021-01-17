using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Data;

namespace FileExplorer
{
    class FileCrawler
    {
        public static IEnumerable<string> EnumerateFilesRecursively(string path)
        {
            foreach (string dir_path in Directory.EnumerateDirectories(path))
            {
                foreach (string file_path in EnumerateFilesRecursively(dir_path))
                    yield return file_path;
            }
                
            foreach (string file_path in Directory.EnumerateFiles(path))
                yield return file_path;
            
        }

        public static string FormatByteSize(long byteSize)
        {
            string formatted = "";

            if (byteSize >= 1 && byteSize < (long)Math.Pow(10, 3))
                formatted = String.Format("{0:0.00}", byteSize) + " B";

            else if (byteSize >= (long)Math.Pow(10, 3) && byteSize < (long)Math.Pow(10, 6))
            {
                double kiloByte = byteSize / Math.Pow(10, 3);
                kiloByte = Math.Floor(kiloByte * 100) / 100;
                formatted = kiloByte.ToString() + " kB";
            }

            else if (byteSize >= (long)Math.Pow(10, 6) && byteSize < (long)Math.Pow(10, 9))
            {
                double megaByte = byteSize / Math.Pow(10, 6);
                megaByte = Math.Floor(megaByte * 100) / 100;
                formatted = megaByte.ToString() + " MB";
            }

            else if (byteSize >= (long)Math.Pow(10, 9) && byteSize < (long)Math.Pow(10, 12))
            {
                double gigaByte = byteSize / Math.Pow(10, 9);
                gigaByte = Math.Floor(gigaByte * 100) / 100;
                formatted = gigaByte.ToString() + " GB";
            }

            else if (byteSize >= (long)Math.Pow(10, 12) && byteSize < (long)Math.Pow(10, 15))
            {
                double teraByte = byteSize / Math.Pow(10, 12);
                teraByte = Math.Floor(teraByte * 100) / 100;
                formatted = teraByte.ToString() + " TB";
            }

            else if (byteSize >= (long)Math.Pow(10, 15) && byteSize < (long)Math.Pow(10, 18))
            {
                double petaByte = byteSize / Math.Pow(10, 15);
                petaByte = Math.Floor(petaByte * 100) / 100;
                formatted = petaByte.ToString() + " PB";
            }

            else if (byteSize >= (long)Math.Pow(10, 18) && byteSize < (long)Math.Pow(10, 21))
            {
                double exaByte = byteSize / Math.Pow(10, 18);
                exaByte = Math.Floor(exaByte * 100) / 100;
                formatted = exaByte.ToString() + " EB";
            }

            else if (byteSize >= (long)Math.Pow(10, 21) && byteSize < (long)Math.Pow(10, 24))
            {
                double zettaByte = byteSize / Math.Pow(10, 21);
                zettaByte = Math.Floor(zettaByte * 100) / 100;
                formatted = zettaByte.ToString() + " ZB";
            }

            return formatted;
        }

        public static XDocument CreateReport(IEnumerable<string> files)
        {
           var table = files.GroupBy(file => new FileInfo(file).Extension.ToLower()).
           Select(fileGroup => new
           {
               Type = fileGroup.Key,
               Count = fileGroup.Count(),
               Size = fileGroup.Select(f => new FileInfo(f).Length).Sum()
           }).OrderByDescending(size => size.Size);

           XDocument htmlReport = new XDocument(
                  new XComment("DOCTYPE html"),
                  new XElement("html", 
                  new XElement("head",
                    new XElement("style",
                       new XAttribute("type", "text/css"), " th, td {border: 1px solid green;}"),
                    new XElement("body",
                    new XElement("h1", "File Report"),
                    new XElement("table",
                         new XAttribute("style", "width: 40%"),
                         new XAttribute("border", 1),
                            new XElement("tr",
                               new XElement("th", "Type"),
                               new XElement("th", "Count"),
                               new XElement("th", "Size")),
                            new XElement("tr", from row in table select
                                new XElement("tr",
                                    new XElement("td", row.Type, new XAttribute("style", "text-align:center")),
                                    new XElement("td", row.Count, new XAttribute("style", "text-align:center")),
                                    new XElement("td", FormatByteSize(row.Size), new XAttribute("style", "text-align:center")))))))));
            
            return htmlReport;
        }     
    }

    class Program
    {
        static void Main(string[] args)
        {
            // string dir_path = "C:\\Users\\kyawh\\Desktop\\foo";
            // string dir_path = "C:\\Users\\kyawh\\Desktop\\Machine Learning";

            string dir_path = "/Users/kyawhtetwin/Desktop/ImageClassifier";
            Console.WriteLine("\nExploring the file...");
           
            var files = FileCrawler.EnumerateFilesRecursively(dir_path);
           
            var fileReport = FileCrawler.CreateReport(files);
            fileReport.Save("FileReport.html");
            Console.WriteLine("\nReport Ready!");
           

        }
    }
}