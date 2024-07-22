using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: XmlConfigurator(ConfigFile = "Configurations\\Log4netConfigs\\log4net.config", Watch = true)]


namespace SpecFlowBasics.Configurations.Log4netConfigs
{
    internal class Log4netConfigs
    {
    }
}
