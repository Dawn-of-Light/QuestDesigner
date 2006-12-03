using System.IO;
using System.Reflection;

namespace DOL.Tools.Mapping.Resource
{
    public class ResourceMgr
    {
     
        const string PACKAGE_PATH = "DOL.Tools.QuestDesigner";
        public static Stream GetStream(string name)
        {
            string file = PACKAGE_PATH + "." + name;
            
            
            if (!ResourceExists(file))
                return null;
            
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(file);
        }

        public static bool ResourceExists(string file)
        {
            if (!file.StartsWith(PACKAGE_PATH))
            {
                file = PACKAGE_PATH + "." + file;
            }

            ManifestResourceInfo info = Assembly.GetExecutingAssembly().GetManifestResourceInfo(file);

            if (info == null)
                return false;
            else
                return true;
        }
    }
}