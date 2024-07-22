using log4net;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Security.AccessControl;

namespace SpecFlowBasics.Helpers
{
    public class JsonFileManager
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(JsonFileManager));

        public T ConvertJsonToObject<T>(string filePath)
        {
            logger.Info($"Converting JSON to object: {typeof(T).Name}, File Path: {filePath}");

            try
            {
                string jsonContent = File.ReadAllText(filePath);
                T obj = JsonConvert.DeserializeObject<T>(jsonContent);

                logger.Info("JSON conversion successful");
                return obj;
            }
            catch (Exception ex)
            {
                logger.Error($"JSON conversion failed: {ex.Message}");
                throw;
            }
        }

        public static void UpdateJsonValue<T>(string filePath, string fieldName, T newValue)
        {
            try
            {
                // Read the JSON file
                string json;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    json = reader.ReadToEnd();
                }

                // Parse the JSON into a JArray or JObject based on the file structure
                JToken jsonData = JToken.Parse(json);

                // Update the value of the specified field
                if (jsonData is JArray jsonArray)
                {
                    foreach (JObject item in jsonArray)
                    {
                        item[fieldName] = JToken.FromObject(newValue);
                    }
                }
                else if (jsonData is JObject jsonObject)
                {
                    jsonObject[fieldName] = JToken.FromObject(newValue);
                }
                else
                {
                    throw new ArgumentException("Invalid JSON file structure.");
                }

                // Convert the JArray or JObject back to a JSON string
                string updatedJson = jsonData.ToString();

                // Write the updated JSON back to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(updatedJson);
                }

                logger.Info(fieldName + " updated successfully.");
            }
            catch (Exception ex)
            {
                logger.Error("Error updating " + fieldName + ": " + ex.Message);
            }
        }

        public static string GetJsonValue(string filePath, string key)
        {
            string jsonText = File.ReadAllText(filePath);
            var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);

            if (json.ContainsKey(key))
            {
                return json[key];
            }
            else
            {
                throw new KeyNotFoundException($"Key '{key}' not found in JSON file '{filePath}'.");
            }
        }

        public static string GetEmailAddressFromJson(string jsonFilePath, string key)
        {
            string jsonText = File.ReadAllText(jsonFilePath);
            List<Dictionary<string, string>> jsonData = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonText);

            foreach (var data in jsonData)
            {
                if (data.ContainsKey(key))
                {
                    return data[key];
                }
            }
            return null;
        }
    }
}
