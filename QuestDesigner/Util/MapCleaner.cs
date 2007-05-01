using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace DOL.Tools.QuestDesigner.Util
{
    class MapCleaner
    {
        XmlDocument configDocument = new XmlDocument();

        int[] validRegions = new int[] { 1, 200, 100, 163, 73, 151, 51, 181, 2, 202, 102, 27 };

        public MapCleaner()
        {

            Array.Sort(validRegions);
            configDocument.Load(QuestDesignerMain.WorkingDirectory+"config\\dol\\zones.xml");

            XmlNodeList nodeList = configDocument.SelectNodes("QuestData/Zone");

            foreach (XmlNode xmlNode in nodeList) {
                int regionID = Convert.ToInt32(xmlNode.SelectSingleNode("regionID").InnerText);
                int zoneID = Convert.ToInt32(xmlNode.SelectSingleNode("zoneID").InnerText);

                if (Array.BinarySearch(validRegions, regionID) >= 0)
                {
                    Console.WriteLine("Valid zone " + zoneID);
                }
                else
                {
                    FileInfo zoneFile = new FileInfo(QuestDesignerMain.WorkingDirectory + "data\\maps\\" + zoneID + ".jpg");
                    if (zoneFile.Exists)
                    {
                        Console.WriteLine("Deleting zone " + zoneID);
                        zoneFile.Delete();
                    }
                }
            }
        }

    }
}
