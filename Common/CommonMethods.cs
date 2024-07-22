using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasics.Common
{
    internal class CommonMethods
    {
        public static string GetCurrentProjectPath()
        {
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin", StringComparison.Ordinal));
            var projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }

        public static string GenerateRandomEmail()
        {
            string prefix = "testAutomation_";
            string domain = "@test.com";
            string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 5; // Length of the random string between prefix and domain

            Random random = new Random();
            string randomString = new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return prefix + randomString + domain;
        }

        public static string GenerateRandomInvalidEmail()
        {
            string prefix = "testAutomation_";
            string domain = "@test.";
            string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 5; // Length of the random string between prefix and domain

            Random random = new Random();
            string randomString = new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return prefix + randomString + domain;
        }

    }
}
