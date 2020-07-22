using System;
using System.Configuration;
using UseCustomSections.BLL;

namespace UseCustomSections
{
    class Program
    {
        static void Main(string[] args)
        {
            //dynamic abc = ConfigurationManager.GetSection("medGroupConfigs");
            
            foreach (MedGroupElement mg in MedGroups.GetMedGroups())
            {
                if (String.CompareOrdinal("medical-group-one", mg.QueryString) == 0)
                {
                    Console.WriteLine(mg.Username);
                }
            }

            Console.Read();
        }
    }
}
