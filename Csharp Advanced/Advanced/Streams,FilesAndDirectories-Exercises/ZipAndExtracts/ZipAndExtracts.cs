using System.IO.Compression;

namespace ZipAndExtract
{
    using System;
    using System.IO;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string zipArchiveFilePath = @"..\..\..\archive.zip";
            string outputFilePath = @"..\..\..\extracted.png";
            ZipFileToArchive(inputFilePath, zipArchiveFilePath);
             var fileName=Path.GetFileName(inputFilePath);
             ExtractFileFromArchive(zipArchiveFilePath, fileName,outputFilePath);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using var archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create);
            var fileName= Path.GetFileName(inputFilePath);
            archive.CreateEntryFromFile(inputFilePath, fileName);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using var archive = ZipFile.OpenRead(zipArchiveFilePath);
            var extraction = archive.GetEntry(fileName);
            extraction.ExtractToFile(outputFilePath);
        }
    }
}
