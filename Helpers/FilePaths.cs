using SpecFlowBasics.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasics.Helpers
{
    internal class FilePaths
    {
        private static readonly string ProjectPath = CommonMethods.GetCurrentProjectPath();

        public static readonly string UsersJson = Path.Combine(ProjectPath, "TestData/DataFiles/Account/Users.json");

    }
}
