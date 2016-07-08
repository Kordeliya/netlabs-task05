using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3
{
    public class ProjectConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("defaultValue", DefaultValue="0", IsKey = true, IsRequired=true)]
        public int IntDefaultCapacity
        {
            get 
            {
                return ((int)(base["defaultValue"]));
            }
            set
            {
                base["defaultValue"] = value;
            }
        }
    }
}
