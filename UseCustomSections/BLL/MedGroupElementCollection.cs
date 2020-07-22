using System.Configuration;

namespace UseCustomSections.BLL
{
    //Extend the ConfigurationElementCollection class.
    //Decorate the class with the class that represents a single element in the collection.
    [ConfigurationCollection(typeof(MedGroupElement))]
    public class MedGroupElementCollection : ConfigurationElementCollection
    {
        public MedGroupElement this[int index]
        {
            get { return (MedGroupElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new MedGroupElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MedGroupElement)element).Name;
        }
    }
}
