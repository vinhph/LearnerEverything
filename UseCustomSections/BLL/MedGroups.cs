using System.Configuration;

namespace UseCustomSections.BLL
{
    //This class reads the defined config section (if available) and stores it locally in the static _Config variable.
    //This config data is available by calling MedGroups.GetMedGroups().
    public class MedGroups
    {
        public static MedGroupConfigsSection Config = ConfigurationManager.GetSection("medGroupConfigs") as MedGroupConfigsSection;
        public static MedGroupElementCollection GetMedGroups()
        {
            return Config.MedGroups;
        }
    }
}
