using ControlWork.Abstarction;
using System.Text.Json;
using System.Text;
using ControlWork.Model;

namespace ControlWork.Service
{
	public class JsonService : IFileService
	{
		public T GetFromFile<T>(string path) where T : class
		{

			string jsonFromFile = File.ReadAllText(path);
			var dic = JsonSerializer.Deserialize<List<Book>>(jsonFromFile);

			return (T)(object) dic;
		}

		public void SaveToFile<T>(T file, string path) where T : class
		{
			string jsonToFile = JsonSerializer.Serialize(file);

			File.WriteAllText(path, jsonToFile);
		}
	}
}
