/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

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
