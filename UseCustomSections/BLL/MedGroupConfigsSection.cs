using System.Configuration;

namespace UseCustomSections.BLL
{
    //Extend the ConfigurationSection class.  Your class name should match your section name and be postfixed with "Section".
    public class MedGroupConfigsSection : ConfigurationSection
    {
        //Decorate the property with the tag for your collection.
        [ConfigurationProperty("medGroups")]
        public MedGroupElementCollection MedGroups
        {
            get { return (MedGroupElementCollection)this["medGroups"]; }
        }
    }
}
