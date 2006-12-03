using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace DOL.Tools.QuestDesigner.Util
{
    class Zip
    {

        public static void Unzip(string filename,string destination) 
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(filename));
            Unzip(s,destination);
        }

        public static void Unzip(Stream stream, string destination) 
        {
            ZipInputStream s = new ZipInputStream(stream);
            Unzip(s,destination);
        }

        public static void Unzip(ZipInputStream s, string destination)
        {            
            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {

                Console.WriteLine(theEntry.Name);

                string directoryName = Path.GetDirectoryName(theEntry.Name);
                string fileName = Path.GetFileName(theEntry.Name);

                // create directory
                if (directoryName.Length > 0)
                {
                    Directory.CreateDirectory(destination+ "\\"+ directoryName);
                }

                if (fileName != String.Empty)
                {
                    using (FileStream streamWriter = File.Create(destination + "\\" + theEntry.Name))
                    {

                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            
        }
    }
}
