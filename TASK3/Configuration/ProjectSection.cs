using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3
{
    public class ProjectSection: ConfigurationSection
    {
        [ConfigurationProperty("Capacity")]
        public ProjectConfigElement CapacityValue
        {
            get 
            {
                return ((ProjectConfigElement) (base["Capacity"]));
            }
        }
    }
}
