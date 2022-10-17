using System.Text.Json;

namespace Ex13_DronesAPI.Models
{
    public static class FileHelper
    {
        public static void SerializeAndWrite<T>(IEnumerable<T> itemList, string path)
        {
            var serializedList = JsonSerializer.Serialize(itemList);
            File.WriteAllText(path, serializedList);
        }

        public static IEnumerable<T> ReadAndDesirializeFile<T>(string path)
        {
            var fileContent = File.ReadAllText(path);
            if(fileContent == string.Empty)
            {
                return null;
            }
            return JsonSerializer.Deserialize<List<T>>(fileContent);
        }
    }
}
